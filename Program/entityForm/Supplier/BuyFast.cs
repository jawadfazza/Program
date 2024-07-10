using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.MaterialControllarTableAdapters;
using Program.entity.controllar;
using Program.entity.controllar.BankControllarTableAdapters;
using Num2Wrd;
using Program.entity.controllar.SupplierControllarTableAdapters;
using Program.entityForm.Supplier.Report;
using System.Collections;
using Program.entity.controllar.CompanyControllarTableAdapters;
using Program.entity.controllar.PaperPayControllarTableAdapters;
using Program.entity.controllar.PaperReceiveControllarTableAdapters;
using System.IO.Ports;
using System.Threading;

namespace Program.entityForm.customer
{
    public partial class BuyFast : Form
    {
        public BuyFast()
        {
            InitializeComponent();
        }

        SerialPort _serialPort;

        // delegate is used to write to a UI control from a non-UI thread
        private delegate void SetTextDeleg(string text);
        private void Buy_Load(object sender, EventArgs e)
        {
            dataGridViewMaterial.RowCount = 50;
            dataGridViewBond.RowCount = 9;
            getSupplierNameAutocomplete();
            getMaterialNameAutocomplete();
            getBankAccounting();
            getReportId();
            //splitContainer2.SplitterDistance = 400;
            countMaterial = 0;
            totalPriceValue = 0;
            totalDiscountValue = 0;
            //pPayAfter.Hide();
            getgroupList();
            newToolStripButton_Click(sender, e);

            // all of the options for a serial device
            // can be sent through the constructor of the SerialPort class
            // PortName = "COM1", Baud Rate = 19200, Parity = None, 
            // Data Bits = 8, Stop Bits = One, Handshake = None
            _serialPort = new SerialPort("COM1", 19200, Parity.None, 8, StopBits.One);
            _serialPort.Handshake = Handshake.None;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;
            _serialPort.Open();
        }

        private void getgroupList()
        {
            cbGroup.Items.Clear();
            material_groupTableAdapter mgta = new material_groupTableAdapter();
            MaterialControllar.material_groupDataTable mgdt = mgta.GetDataByASC();
            ArrayList array = new ArrayList();
            foreach (DataRow row in mgdt.Rows)
            {
                cbGroup.Items.Add(row["اسم_المجموعة"].ToString() + "." + row["رقم_المجموعة"].ToString());
                array.Add(row["اسم_المجموعة"].ToString() + "." + row["رقم_المجموعة"].ToString());
            }

            //array.Sort();
            cbGroup.Items.Clear();
            cbGroup.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            cbGroup.Items.AddRange(array.ToArray());
        }

        private void getReportId()
        {
            material_debitTableAdapter mcta = new material_debitTableAdapter();
            MaterialControllar.material_debitDataTable mcdt = mcta.GetData();
            cbIds.Items.Clear();
            foreach (DataRow dr in mcdt.Rows)
            {
                cbIds.Items.Add(dr["الرقم"]);
            }
        }

        private void getBankAccounting()
        {
            bank_accountTableAdapter bata = new bank_accountTableAdapter();
            BankControllar.bank_accountDataTable badt = bata.GetData();
            foreach (DataRow dr in badt.Rows)
            {
                cbBankAccounting.Items.Add(dr["اسم_الحساب"] + "." + dr["الرقم"]);
            }
        }

        public void getSupplierNameAutocomplete()
        {
            supplierTableAdapter cta = new supplierTableAdapter();
            entity.controllar.SupplierControllar.supplierDataTable cdt = cta.GetData();
            string[] array = new string[cdt.Rows.Count];
            int count = 0;
            foreach (DataRow row in cdt.Rows)
            {
                array[count] = row["اسم_المورد"].ToString() + "." + row["الرقم"].ToString();
                count++;
            }
            txtSupplier.AutoCompleteCustomSource.AddRange(array);
            txtSupplier.Items.AddRange(array);
        }

        private void Sale_Resize(object sender, EventArgs e)
        {
            //splitContainer2.SplitterDistance = 400;
        }

        private void txtSupplier_Validating(object sender, CancelEventArgs e)
        {
            if (txtSupplier.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل اسم المورد فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void bAddMaterial_Click(object sender, EventArgs e)
        {
            bool found = false;
            if (cbSearchType.Text == "اسم المادة")
            {
                try
                {
                    materialTableAdapter mta = new materialTableAdapter();
                    MaterialControllar.materialDataTable mdt = mta.getMaterialById(Convert.ToInt32(txtSearchMaterial.Text.Split('.')[1]));
                    DataRow dr = mdt.Rows[0];
                    foreach (DataRow row in materialList)
                    {
                        if (row["الرقم_الفني"].ToString() == dr["الرقم_الفني"].ToString())
                        {
                            found = true;
                        }
                    }

                    if (found)
                    {
                        MessageBox.Show("تم إضافة المادة سابقاً", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        materialList.Add(dr);
                        addMaterial(dr);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            if (cbSearchType.Text == "كود المادة")
            {
                try
                {
                    materialTableAdapter mta = new materialTableAdapter();
                    MaterialControllar.materialDataTable mdt = mta.getMaterialByCode(txtSearchMaterial.Text);
                    DataRow dr = mdt.Rows[0];
                    foreach (DataRow row in materialList)
                    {
                        if (row["الرقم_الفني"].ToString() == dr["الرقم_الفني"].ToString())
                        {
                            found = true;
                        }
                    }

                    if (found)
                    {
                        MessageBox.Show("تم إضافة المادة سابقاً", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        materialList.Add(dr);
                        addMaterial(dr);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error : " + ex.Message);
                }
            }
        }

        static List<DataRow> materialList = new List<DataRow>();
        static int countMaterial = 0;
        private void addMaterial(DataRow dr)
        {
            dataGridViewMaterial.Rows[countMaterial].Cells[0].Value = dr["الرقم_الفني"];
            dataGridViewMaterial.Rows[countMaterial].Cells[1].Value = dr["اسم_المادة"];
            dataGridViewMaterial.Rows[countMaterial].Cells[2].Value = dr["كمية"];
            dataGridViewMaterial.Rows[countMaterial].Cells[3].Value = dr["سعر_الشراء"];
            dataGridViewMaterial.Rows[countMaterial].Cells[4].Value = dr["DiscountPersent"];
            dataGridViewMaterial.Rows[countMaterial].Cells[5].Value = dr["Discount"];
            dataGridViewMaterial.Rows[countMaterial].Cells[6].Value = dr["TotalValue"];
            dataGridViewMaterial.Rows[countMaterial].Cells[7].Value = dr["Comment"];

            txtSearchMaterial.Focus();
            countMaterial++;
        }

        private void txtMaterialSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bAddMaterial_Click(sender, e);
            }
        }

        private void bRemoveMaterial_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("إزالة المادة ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                DataRow dr = materialList.Find(
                    delegate(DataRow row)
                    {
                        return dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[0].Value.ToString().Trim() == row["الرقم_الفني"].ToString().Trim();
                    });
                removeMaterial(dr);
            }
        }

        private void removeMaterial(DataRow dr)
        {
            try
            {
                for (int i = 0; i < materialList.Count; i++)
                {
                    dataGridViewMaterial.Rows[i].Cells[0].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[1].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[2].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[3].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[4].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[5].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[6].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[7].Value = "";
                }
                materialList.Remove(dr);
                countMaterial = 0;
                foreach (DataRow row in materialList)
                {
                    addMaterial(row);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridViewMaterial_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            calculateReportValue();
        }

        static double totalPriceValue = 0;
        static double totalCostValue = 0;
        static double totalDiscountValue = 0;
        static double totalPenfitValue = 0;
        public void calculateReportValue()
        {
            try
            {
                if (dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[0].Value == null)
                {

                }
                else
                {
                    int quantity = Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[2].Value.ToString());
                    int price = Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    double DiscountPersent = Convert.ToDouble(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[4].Value.ToString());
                    double discount = quantity * price * (DiscountPersent / 100);
                    double PriceValue = (quantity * price) - discount;

                    dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[5].Value = discount;
                    dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[6].Value = PriceValue;

                    DataRow dr = materialList.Find(
                    delegate(DataRow row)
                    {
                        return dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[0].Value.ToString().Trim() == row["الرقم_الفني"].ToString().Trim();
                    });

                    dr["كمية"] = quantity;
                    dr["DiscountPersent"] = DiscountPersent;
                    dr["Discount"] = discount;
                    dr["Comment"] = dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[7].Value.ToString();
                    dr["TotalValue"] = PriceValue;
                    if (price != Convert.ToInt32(dr["سعر_الشراء"]))
                    {
                        if (MessageBox.Show("هل ترغب بتغير سعر بيع  " + dr["اسم_المادة"] + " ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            materialTableAdapter mta = new materialTableAdapter();
                            mta.UpdateBuyPrice(price, Convert.ToInt32(dr["الرقم_الفني"]));
                            dr["سعر_الشراء"] = price;
                        }
                        else
                        {
                            dr["سعر_الشراء"] = price;
                        }
                    }
                    else
                    {
                        dr["سعر_الشراء"] = price;
                    }
                    totalPriceValue = 0;
                    totalDiscountValue = 0;
                    foreach (DataRow row in materialList)
                    {
                        try
                        {
                            totalPriceValue += Convert.ToDouble(row["TotalValue"]);
                            totalDiscountValue += Convert.ToDouble(row["Discount"]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception1 :: " + ex.Message);
                        }
                    }
                    txtTotalPrice.Text = totalPriceValue.ToString();
                    txtDiscount.Text = totalDiscountValue.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception2 :: " + ex.Message);
            }/**/

        }

        private void bAddBond_Click(object sender, EventArgs e)
        {
            setBond1();
            setBond2();
            setBond3();
            setBond4();
        }

        BondControllar bc;
        List<BondControllar> bcList = new List<BondControllar>();
        NumberToEnglish nte = new NumberToEnglish();
        private BondControllar setBond1()
        {
            material_debitTableAdapter mcta = new material_debitTableAdapter();
            if (totalPriceValue > 0)
            {
                bc = new BondControllar();

                bc.balance = totalPriceValue + totalDiscountValue;
                bc.balanceText = nte.changeNumericToWords(totalPriceValue + totalDiscountValue);
                bc.bondFrom = "مشتريات بضاعة." + (Convert.ToInt32(mcta.getMaxMaterialDebit()) + 1);
                bc.bondTo = "مورد." + txtSupplier.Text;
                bc.comment = "شراء يضاعة من المورد " + txtSupplier.Text + " لقاء بضاعة ";

                //bcList.Add(bc);
                dataGridViewBond.Rows[0].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[0].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[0].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[0].Cells[3].Value = "شراء يضاعة من المورد " + txtSupplier.Text + " لقاء بضاعة ";
            }
            return bc;
        }

        private BondControllar setBond2()
        {
            if (totalDiscountValue > 0)
            {
                bc = new BondControllar();

                bc.balance = totalDiscountValue;
                bc.balanceText = nte.changeNumericToWords(totalDiscountValue);
                bc.bondFrom = "مورد." + txtSupplier.Text;
                bc.bondTo = "حسم مكتسب";
                bc.comment = "الحصول على حسم مكتسب من المورد  " + txtSupplier.Text + " لقاء بضاعة ";

                //bcList.Add(bc);
                dataGridViewBond.Rows[1].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[1].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[1].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[1].Cells[3].Value = bc.comment;
            }
            else
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";
                bc.comment = "";

                //bcList.Add(bc);
                dataGridViewBond.Rows[1].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[1].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[1].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[1].Cells[3].Value = "";
            }
            return bc;
        }

        private BondControllar setBond3()
        {
            material_debitTableAdapter mcta = new material_debitTableAdapter();
            if (Convert.ToInt32(txtMoreBills.Text) > 0)
            {
                if (cbMoreBillsOption.Text == "على المورد")
                {
                    bc = new BondControllar();

                    bc.balance = Convert.ToDouble(txtMoreBills.Text);
                    bc.balanceText = nte.changeNumericToWords(Convert.ToDouble(txtMoreBills.Text));
                    bc.bondFrom = "مصاريف شراء." + (Convert.ToInt32(mcta.getMaxMaterialDebit()) + 1);
                    bc.bondTo = "مورد." + txtSupplier.Text;
                    bc.comment = "مصاريف شراء يضاعة من المورد " + txtSupplier.Text;

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[2].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[2].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[2].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[2].Cells[3].Value = "مصاريف شراء يضاعة من المورد " + txtSupplier.Text + " لقاء بضاعة ";
                }
                if (cbMoreBillsOption.Text == "على الشركة")
                {
                    bc = new BondControllar();

                    bc.balance = Convert.ToDouble(txtMoreBills.Text);
                    bc.balanceText = nte.changeNumericToWords(Convert.ToDouble(txtMoreBills.Text));
                    bc.bondFrom = "مصاريف شراء." + (Convert.ToInt32(mcta.getMaxMaterialDebit()) + 1);
                    bc.bondTo = "صندوق.صندوق اليومية.1";
                    bc.comment = "مصاريف شراء يضاعة من المورد " + txtSupplier.Text;

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[2].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[2].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[2].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[2].Cells[3].Value = "مصاريف شراء يضاعة من المورد " + txtSupplier.Text + " لقاء بضاعة ";
                }

            }
            else
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";
                bc.comment = "";

                //bcList.Add(bc);
                dataGridViewBond.Rows[2].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[2].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[2].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[2].Cells[3].Value = "";

            }
            return bc;
        }

        private BondControllar setBond4()
        {
            if (rbCash.Checked)
            {
                if (totalPriceValue > 0 && cbTypeOperation.Text == "كاش")
                {
                    bc = new BondControllar();
                    if (cbMoreBillsOption.Text == "على الشركة")
                    {
                        bc.balance = totalPriceValue;
                        bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    }
                    else
                    {
                        bc.balance = totalPriceValue + Convert.ToDouble(txtMoreBills.Text);
                        bc.balanceText = nte.changeNumericToWords(totalPriceValue + Convert.ToDouble(txtMoreBills.Text));
                    }
                    bc.bondFrom = "مورد." + txtSupplier.Text;
                    bc.bondTo = "صندوق.صندوق اليومية.1";
                    bc.comment = "التسديد نقداً للمورد " + txtSupplier.Text + " لقاء بضاعة ";

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[3].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[3].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[3].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[3].Cells[3].Value = bc.comment;

                }
                if (totalPriceValue > 0 && cbTypeOperation.Text == "شيك")
                {
                    bc = new BondControllar();

                    if (cbMoreBillsOption.Text == "على الشركة")
                    {
                        bc.balance = totalPriceValue;
                        bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    }
                    else
                    {
                        bc.balance = totalPriceValue + Convert.ToDouble(txtMoreBills.Text);
                        bc.balanceText = nte.changeNumericToWords(totalPriceValue + Convert.ToDouble(txtMoreBills.Text));
                    }
                    bc.bondFrom = "مورد." + txtSupplier.Text;
                    bc.bondTo = "مصرف." + cbBankAccounting.Text;
                    bc.comment = "التسديد بشيك للمورد " + txtSupplier.Text + " لقاء بضاعة ";

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[3].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[3].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[3].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[3].Cells[3].Value = bc.comment;

                }
            }
            else
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";
                bc.comment = "";

                //bcList.Add(bc);
                dataGridViewBond.Rows[3].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[3].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[3].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[3].Cells[3].Value = bc.comment;

            }
            SaveBuy = CheckBondsError("to", 3);
            return bc;
        }

        bool SaveBuy = true;
        static string[] IsBondTrested = new string[2];
        public bool CheckBondsError(string dir, int index)
        {
            bool ok = true;
            string[] message = bc.CheckBonds(dir);
            if (message[0] != "")
            {
                dataGridViewBond.Rows[index].ErrorText = message[0];
                dataGridViewBond.Rows[index].Cells[1].ErrorText = message[0];
                dataGridViewBond.Rows[index].DefaultCellStyle.BackColor = Color.Gold;
                dataGridViewBond.Rows[index].DefaultCellStyle.ForeColor = Color.Green;
                ok = false;
            }
            if (message[1] != "")
            {
                dataGridViewBond.Rows[index].ErrorText += "\n" + message[1];
                dataGridViewBond.Rows[index].Cells[2].ErrorText = message[1];
                dataGridViewBond.Rows[index].DefaultCellStyle.BackColor = Color.Gold;
                dataGridViewBond.Rows[index].DefaultCellStyle.ForeColor = Color.Green;
                ok = false;

            }
            //if there are no error
            if (message[0] == "" && message[1] == "")
            {
                dataGridViewBond.Rows[index].ErrorText = "";
                dataGridViewBond.Rows[index].Cells[1].ErrorText = message[0];
                dataGridViewBond.Rows[index].Cells[2].ErrorText = message[1];
                dataGridViewBond.Rows[index].DefaultCellStyle.BackColor = Color.White;
                dataGridViewBond.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
                ok = true;
            }
            return ok;
        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            //pPayAfter.Hide();
            cbTypeOperation.Enabled = true;
            cbBankAccounting.Enabled = false;
            //dtpPaperRecieved.Enabled = false;
            cbTypeOperation.Text = "كاش";
            bAddBond_Click(sender, e);
            if (rbCash.Checked)
            {
                epInformation.SetError((Control)sender, "الدفع نقداً عن طريق الصندوق");
            }
            else
            {
                epInformation.SetError((Control)sender, "");
            }
        }

        private void rbAfter_CheckedChanged(object sender, EventArgs e)
        {
            //pPayAfter.Show();
            //dtpPaperRecieved.Enabled = false;
            cbTypeOperation.Enabled = true;
            cbBankAccounting.Enabled = false;
            //dtpPaperRecieved.Enabled = false;
            cbTypeOperation.Text = "كاش";
            cbBankAccounting.Text = "";
            bAddBond_Click(sender, e);
            if (rbAfter.Checked)
            {
                epInformation.SetError((Control)sender, "البيع من خلال عملية تقسيط المبيعات");
            }
            else
            {
                epInformation.SetError((Control)sender, "");
            }
        }

        private void cbTypeOperation_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbTypeOperation.Text == "شيك")
            {
                cbBankAccounting.Enabled = true;
                bAddBond_Click(sender, e);
            }
            else
            {
                cbBankAccounting.Enabled = false;
                bAddBond_Click(sender, e);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private string getType()
        {
            string value = "";
            if (rbCash.Checked)
            {
                value = "نقداً";
            }
            if (rbAfter.Checked)
            {
                value = "لأجل";
            }
            return value;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtSupplier.Text = "";
            txtTotalPrice.Text = "0";
            txtDiscount.Text = "0";
            txtMoreBills.Text = "0";
            txtBiles.Text = "0";
            totalPriceValue = 0;
            totalDiscountValue = 0;
            // indexMaterialdebit = 0;
            //dtpSaleDate.Value = DateTime.Now;
            dtpBillDate.Value = DateTime.Now;
            getReportId();
            materialList.Clear();
            countMaterial = 0;
            for (int i = 0; i < 20; i++)
            {
                dataGridViewMaterial.Rows[i].Cells[0].Value = "";
                dataGridViewMaterial.Rows[i].Cells[1].Value = "";
                dataGridViewMaterial.Rows[i].Cells[2].Value = "";
                dataGridViewMaterial.Rows[i].Cells[3].Value = "";
                dataGridViewMaterial.Rows[i].Cells[4].Value = "";
                dataGridViewMaterial.Rows[i].Cells[5].Value = "";
                dataGridViewMaterial.Rows[i].Cells[6].Value = "";
                dataGridViewMaterial.Rows[i].Cells[7].Value = "";
            }

            gbBonds.Text = "قيد العملية";
            gbBonds.ForeColor = Color.Black;

            for (int i = 0; i < 9; i++)
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";
                bc.comment = "";

                //bcList.Add(bc);
                dataGridViewBond.Rows[i].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[i].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[i].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[i].Cells[3].Value = "";
            }

        }

        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Console.WriteLine("id: " + txtSupplier.Text.Split('.')[1]);
                }
            }
            catch (Exception ex)
            {

            }
        }

        static int indexMaterialdebit = 0;
        private void bNext_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                indexMaterialdebit++;
            }
            getReport(indexMaterialdebit);
            if (indexMaterialdebit == (cbIds.Items.Count - 1))
            {
                bNext.Enabled = false;
                bPrevious.Enabled = true;
            }
            else
            {
                bPrevious.Enabled = true;
            }
        }

        private void bPrevious_Click(object sender, EventArgs e)
        {
            indexMaterialdebit--;
            getReport(indexMaterialdebit);
            if (indexMaterialdebit == 0)
            {
                bPrevious.Enabled = false;
                bNext.Enabled = true;
            }
            else
            {
                bNext.Enabled = true;
            }
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            getReport(Convert.ToInt16(cbIds.SelectedIndex));
        }

        static DataRow rowMaterialdDebit;
        static bool isSaveBonds = true;
        private void getReport(int indexValue)
        {
            try
            {
                txtId.Text = cbIds.Items[indexValue].ToString();
                int id = Convert.ToInt32(txtId.Text);
                material_debitTableAdapter mcta = new material_debitTableAdapter();
                MaterialControllar.material_debitDataTable mcdt = mcta.getMaterialDebitById(id);
                rowMaterialdDebit = mcdt.Rows[0];

                txtSupplier.Text = rowMaterialdDebit["من"].ToString().Split('.')[1] + "." + rowMaterialdDebit["من"].ToString().Split('.')[2];
                totalPriceValue = Convert.ToDouble(rowMaterialdDebit["الرصيد"].ToString());
                txtTotalPrice.Text = rowMaterialdDebit["الرصيد"].ToString();
                txtDiscount.Text = rowMaterialdDebit["حسم_مكتسب"].ToString();
                totalDiscountValue = Convert.ToDouble(txtDiscount.Text);
                txtTotalCost.Text = (totalPriceValue - totalDiscountValue).ToString();
                if (rowMaterialdDebit["نوع_العملية"].ToString() == "نقداً")
                {
                    rbCash.Checked = true;
                }
                if (rowMaterialdDebit["نوع_العملية"].ToString() == "لأجل")
                {
                    rbAfter.Checked = true;
                }
                cbTypeOperation.Text = rowMaterialdDebit["طريقة_الدفع"].ToString();
                cbBankAccounting.Text = rowMaterialdDebit["اسم_الحساب"].ToString();
                // dtpSaleDate.Value = Convert.ToDateTime(rowMaterialdDebit["تاريخ"]);
                txtBiles.Text = rowMaterialdDebit["رقم_فاتورة_المصدر"].ToString();
                dtpBillDate.Value = Convert.ToDateTime(rowMaterialdDebit["تاريخ_فاتورة_المصدر"]);
                txtMoreBills.Text = rowMaterialdDebit["مصاريف_مضافة"].ToString();
                cbMoreBillsOption.Text = rowMaterialdDebit["مصاريف_على_حساب"].ToString();
                isSaveBonds = Convert.ToBoolean(rowMaterialdDebit["مرحل"]);
                idPaperPay = Convert.ToInt32(rowMaterialdDebit["سند_الدفع"]);


                if (isSaveBonds)
                {
                    gbBonds.Text = "تم ترحيل قيد العملية";
                    gbBonds.ForeColor = Color.Green;

                }
                if (!isSaveBonds)
                {
                    gbBonds.Text = "لم يتم ترحيل قيد العملية";
                    gbBonds.ForeColor = Color.Red;
                }

                material_debit_listTableAdapter mclta = new material_debit_listTableAdapter();
                MaterialControllar.material_debit_listDataTable mcldt = mclta.getMaterialDebitReport(id);

                for (int i = 0; i < 20; i++)
                {
                    dataGridViewMaterial.Rows[i].Cells[0].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[1].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[2].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[3].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[4].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[5].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[6].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[7].Value = "";
                }
                int count = 0;
                materialList.Clear();

                foreach (DataRow dr in mcldt)
                {
                    materialTableAdapter mta1 = new materialTableAdapter();
                    MaterialControllar.materialDataTable material = mta1.getMaterialById(Convert.ToInt32(dr["رقم_المادة"]));

                    dataGridViewMaterial.Rows[count].Cells[0].Value = dr["رقم_المادة"];
                    dataGridViewMaterial.Rows[count].Cells[1].Value = dr["اسم_المادة"];
                    dataGridViewMaterial.Rows[count].Cells[2].Value = dr["الكمية"];
                    dataGridViewMaterial.Rows[count].Cells[3].Value = dr["السعر"];
                    dataGridViewMaterial.Rows[count].Cells[4].Value = Convert.ToInt32((Convert.ToDouble(dr["حسم_مكتسب"]) / Convert.ToDouble(dr["السعر_الجمالي"])) * 100);
                    dataGridViewMaterial.Rows[count].Cells[5].Value = dr["حسم_مكتسب"];
                    dataGridViewMaterial.Rows[count].Cells[6].Value = dr["السعر_الجمالي"];
                    dataGridViewMaterial.Rows[count].Cells[7].Value = dr["ملاحظات"];
                    count++;
                    material.Rows[0]["كمية"] = dr["الكمية"];
                    materialList.Add(material.Rows[0]);
                }

            }
            catch (Exception)
            {

            }
        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception ex)
            {

            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception ex)
            {

            }
        }

        private void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception ex)
            {

            }
        }

        private void bMaterialCard_Click(object sender, EventArgs e)
        {
            NewMaterial nm = new NewMaterial();
            nm.MdiParent = Main.ActiveForm;
            nm.LayoutMdi(MdiLayout.ArrangeIcons);
            nm.Show();
        }

        private void miBuyBills_Click(object sender, EventArgs e)
        {
            BuyBills bb = new BuyBills();
            bb.ShowDialog();
        }

        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSearchType.Text == "اسم المادة")
                {
                    getMaterialNameAutocomplete();
                }
                if (cbSearchType.Text == "كود المادة")
                {
                    getMaterialCodeAutocomplete();
                    // Makes sure serial port is open before trying to write
                    try
                    {
                        if (!_serialPort.IsOpen)
                            _serialPort.Open();

                        _serialPort.Write("SI\r\n");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
            string data = _serialPort.ReadLine();
            this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
        }

        private void si_DataReceived(string data)
        {
            txtSearchMaterial.Text = data.Trim();
        }

        public void getMaterialNameAutocomplete()
        {
            materialTableAdapter mta = new materialTableAdapter();
            MaterialControllar.materialDataTable mdt = mta.GetData();
            ArrayList array = new ArrayList();
            foreach (DataRow row in mdt.Rows)
            {
                if (row["اسم_المادة"].ToString() != "")
                {
                    array.Add(row["اسم_المادة"].ToString() + "." + row["الرقم_الفني"].ToString());
                }
            }
            array.Sort();
            txtSearchMaterial.Items.Clear();
            txtSearchMaterial.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtSearchMaterial.Items.AddRange(array.ToArray());
        }


        public void getMaterialCodeAutocomplete()
        {
            materialTableAdapter mta = new materialTableAdapter();
            MaterialControllar.materialDataTable mdt = mta.GetData();
            ArrayList array = new ArrayList();
            foreach (DataRow row in mdt.Rows)
            {
                if (row["كود_المادة"].ToString() != "")
                {
                    array.Add(row["كود_المادة"].ToString());
                }
            }
            array.Sort();
            txtSearchMaterial.Items.Clear();
            txtSearchMaterial.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtSearchMaterial.Items.AddRange(array.ToArray());
        }

        private void Buy_FormClosed(object sender, FormClosedEventArgs e)
        {
            materialList.Clear();
        }



        private void bHide_Click(object sender, EventArgs e)
        {
            gbBonds.Hide();

        }

        private void bShow_Click(object sender, EventArgs e)
        {
            gbBonds.Show();
        }

        private void bEditBills_Click(object sender, EventArgs e)
        {

        }

        private void bDeleteBills_Click(object sender, EventArgs e)
        {
            if (isSaveBonds)
            {
                MessageBox.Show("لا يمكن حذف قسيمة الإدخال تم تثبيت القيود", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("هل تريد حذف التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    materialTableAdapter mta = new materialTableAdapter();
                    foreach (DataRow row in materialList)
                    {
                        materialTableAdapter mta1 = new materialTableAdapter();
                        MaterialControllar.materialDataTable material = mta1.getMaterialById(Convert.ToInt32(row["الرقم_الفني"]));

                        mta.UpdateMaterialQuantity((Convert.ToInt32(material.Rows[0]["كمية"]) + Convert.ToInt32(row["كمية"])),
                        Convert.ToInt32(row["الرقم_الفني"]));

                    }
                    int id = Convert.ToInt32(rowMaterialdDebit["الرقم"]);
                    material_debitTableAdapter mdta = new material_debitTableAdapter();
                    material_debit_listTableAdapter mdlta = new material_debit_listTableAdapter();
                    mdlta.DeleteMaterialDebitList(id);
                    mdta.DeleteMaterialDebit(id);
                    //getReportId();
                    newToolStripButton_Click(sender, e);
                    MessageBox.Show("تم حذف تقرير ردّ البضاعة", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void txtMoreBills_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMoreBills.Text == "")
                {
                    txtMoreBills.Text = "0";
                }
                bAddBond_Click(sender, e);
            }
            catch (Exception ex)
            {

            }
        }

        private void cbMoreBillsOption_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception ex)
            {

            }

        }

        private void cbBankAccounting_SelectedValueChanged(object sender, EventArgs e)
        {
            bAddBond_Click(sender, e);
        }

        private void bSaveAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveBuy)
                {
                    if (MessageBox.Show("هل تريد حفط التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        material_debitTableAdapter mcta = new material_debitTableAdapter();

                        double price = totalPriceValue + totalPenfitValue - totalDiscountValue;
                        if (cbMoreBillsOption.Text == "على الزبون")
                        {
                            price = price + Convert.ToDouble(txtMoreBills.Text);
                        }

                        mcta.Insert(DateTime.Now,
                        price,
                        "مورد." + txtSupplier.Text,
                        nte.changeNumericToWords(price),
                        Convert.ToInt32(txtBiles.Text),
                        dtpBillDate.Value,
                        "",
                        "",
                        Convert.ToInt32(txtSupplier.Text.Split('.')[1]),
                        "",
                        getType(),
                        Convert.ToDouble(totalDiscountValue),
                        Convert.ToDouble(txtMoreBills.Text),
                        cbMoreBillsOption.Text,
                        true.ToString(),
                        cbTypeOperation.Text,
                        cbBankAccounting.Text,
                        Convert.ToInt32(idPaperPay));

                        int id = Convert.ToInt32(mcta.getMaxMaterialDebit());
                        material_debit_listTableAdapter mclta = new material_debit_listTableAdapter();
                        materialTableAdapter mta = new materialTableAdapter();


                        material_costTableAdapter mcta_cost = new material_costTableAdapter();
                        foreach (DataRow row in materialList)
                        {
                            try
                            {
                                double totalvalue = Convert.ToDouble(row["TotalValue"]);
                                double discount = Convert.ToDouble(row["Discount"]);

                                mclta.Insert(Convert.ToInt32(row["الرقم_الفني"]),
                                    id,
                                    row["اسم_المادة"].ToString(),
                                    row["الوحدة"].ToString(),
                                    Convert.ToInt32(row["كمية"].ToString()),
                                    Convert.ToInt32(row["سعر_الشراء"].ToString()),
                                    totalvalue + discount,
                                    row["Comment"].ToString(),
                                    0,
                                    nte.changeNumericToWords(Convert.ToInt32(row["كمية"].ToString())),
                                    "",
                                    discount);


                                mcta_cost.Insert(Convert.ToInt32(row["الرقم_الفني"]),
                                    Convert.ToInt32(row["سعر_الشراء"].ToString()),
                                    Convert.ToInt32(row["كمية"].ToString()),
                                    DateTime.Now,
                                     id);

                                int quantity = Convert.ToInt32(mta.getMaterialById(Convert.ToInt32(row["الرقم_الفني"]))[0]["كمية"]);

                                mta.UpdateMaterialQuantity((quantity + Convert.ToInt32(row["كمية"])),
                                    Convert.ToInt32(row["الرقم_الفني"]));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("لم يتم إضافة " + row["اسم_المادة"].ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        setBond1().SaveBonds();
                        setBond2().SaveBonds();
                        setBond3().SaveBonds();
                        setBond4().SaveBonds();

                        getReportId();
                        MessageBox.Show("  تم إضافة التقرير  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        newToolStripButton_Click(sender, e);
                        BuyBills bb = new BuyBills();
                        bb.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("رصيد النقدية غير كافي", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("بعض العناصر مفقودة من بطاقة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void bSaveCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveBuy)
                {
                    if (MessageBox.Show("هل تريد حفط التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        material_debitTableAdapter mcta = new material_debitTableAdapter();

                        double price = totalPriceValue + totalPenfitValue - totalDiscountValue;
                        if (cbMoreBillsOption.Text == "على المورد")
                        {
                            price = price + Convert.ToDouble(txtMoreBills.Text);
                        }

                        mcta.Insert(DateTime.Now,
                        price,
                        "مورد." + txtSupplier.Text,
                        nte.changeNumericToWords(price),
                        Convert.ToInt32(txtBiles.Text),
                        dtpBillDate.Value,
                        "",
                        "",
                        Convert.ToInt32(txtSupplier.Text.Split('.')[1]),
                        "",
                        getType(),
                        Convert.ToDouble(totalDiscountValue),
                        Convert.ToDouble(txtMoreBills.Text),
                        cbMoreBillsOption.Text,
                        true.ToString(),
                        cbTypeOperation.Text,
                        cbBankAccounting.Text,
                        Convert.ToInt32(idPaperPay));

                        int id = Convert.ToInt32(mcta.getMaxMaterialDebit());
                        material_debit_listTableAdapter mclta = new material_debit_listTableAdapter();
                        materialTableAdapter mta = new materialTableAdapter();

                        material_costTableAdapter mcta_cost = new material_costTableAdapter();
                        foreach (DataRow row in materialList)
                        {
                            try
                            {
                                double totalvalue = Convert.ToDouble(row["TotalValue"]);
                                double discount = Convert.ToDouble(row["Discount"]);

                                mclta.Insert(Convert.ToInt32(row["الرقم_الفني"]),
                                    id,
                                    row["اسم_المادة"].ToString(),
                                    row["الوحدة"].ToString(),
                                    Convert.ToInt32(row["كمية"].ToString()),
                                    Convert.ToInt32(row["سعر_الشراء"].ToString()),
                                    totalvalue + discount,
                                    row["Comment"].ToString(),
                                    0,
                                    nte.changeNumericToWords(Convert.ToInt32(row["كمية"].ToString())),
                                    "",
                                    discount);

                                mcta_cost.Insert(Convert.ToInt32(row["الرقم_الفني"]),
                                  Convert.ToInt32(row["سعر_الشراء"].ToString()),
                                  Convert.ToInt32(row["كمية"].ToString()),
                                  DateTime.Now,
                                   id);

                                int quantity = Convert.ToInt32(mta.getMaterialById(Convert.ToInt32(row["الرقم_الفني"]))[0]["كمية"]);

                                mta.UpdateMaterialQuantity((quantity + Convert.ToInt32(row["كمية"])),
                                    Convert.ToInt32(row["الرقم_الفني"]));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("لم يتم إضافة " + row["اسم_المادة"].ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }



                        getReportId();
                        MessageBox.Show("  تم إضافة التقرير  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        newToolStripButton_Click(sender, e);
                        BuyBills bb = new BuyBills();
                        bb.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("رصيد النقدية غير كافي", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("بعض العناصر مفقودة من بطاقة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void bSaveBonds_Click(object sender, EventArgs e)
        {
            try
            {
                if (isSaveBonds)
                {
                    MessageBox.Show("لقد تم ترحيل القيود مسبقاً! ", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (SaveBuy)
                    {
                        if (MessageBox.Show("هل تريد ترحيل قيود الإدخال ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {


                            setBond1().SaveBonds();
                            setBond2().SaveBonds();
                            setBond3().SaveBonds();
                            setBond4().SaveBonds();

                            rowMaterialdDebit["مرحل"] = true.ToString();
                            material_debitTableAdapter mcta = new material_debitTableAdapter();
                            mcta.Update(rowMaterialdDebit);
                            MessageBox.Show("لقد تم ترحيل القيود ! ", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("بعض العناصر مفقودة من بطاقة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        static int idPaperPay = 0;
        private void rbPaperPay_CheckedChanged(object sender, EventArgs e)
        {
            //pPayAfter.Hide();
            //dtpPaperRecieved.Enabled = true;
            cbTypeOperation.Enabled = false;
            cbBankAccounting.Enabled = false;
            //cbTypeOperation.Text = "";
            cbBankAccounting.Text = "";
            paper_payTableAdapter prta = new paper_payTableAdapter();
            idPaperPay = Convert.ToInt32(prta.getMaxPaperPay()) + 1;
            bAddBond_Click(sender, e);

        }

        static int Quintity = 0;
        private void bAddMaterial1_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                materialTableAdapter mta = new materialTableAdapter();
                MaterialControllar.materialDataTable mdt = mta.getMaterialById(Convert.ToInt32(txtSearchMaterial.Text.Split('.')[1]));
                DataRow dr = mdt.Rows[0];
                foreach (DataRow row in materialList)
                {
                    if (row["الرقم_الفني"].ToString() == dr["الرقم_الفني"].ToString())
                    {
                        found = true;
                    }
                }

                if (found)
                {
                    MessageBox.Show("تم إضافة المادة سابقاً", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dr["كمية"] = Quintity;
                    materialList.Add(dr);
                    addMaterial(dr);
                }
            }
            catch (Exception ex)
            {

            }
            txtQuintity.Text = "0";
            txtQuintity1.Text = "0";
            calculateReportValue1();
        }

        public void calculateReportValue1()
        {
            /*try
              {*/
            for (int i = 0; i < materialList.Count; i++)
            {
                // dataGridViewMaterial.Rows[i].Selected = true;
                if (dataGridViewMaterial.Rows[i].Cells[0].Value == null)
                {

                }
                else
                {
                    materialTableAdapter mta = new materialTableAdapter();
                    int quantity = Convert.ToInt32(dataGridViewMaterial.Rows[i].Cells[2].Value.ToString());

                    quantity = Convert.ToInt32(dataGridViewMaterial.Rows[i].Cells[2].Value.ToString());
                    int price = Convert.ToInt32(dataGridViewMaterial.Rows[i].Cells[3].Value.ToString());

                    double DiscountPersent = Convert.ToDouble(dataGridViewMaterial.Rows[i].Cells[4].Value.ToString());
                    double discount = quantity * price * (DiscountPersent / 100);
                    double PriceValue = (quantity * price) - discount;

                    dataGridViewMaterial.Rows[i].Cells[5].Value = discount;
                    dataGridViewMaterial.Rows[i].Cells[6].Value = PriceValue;

                    DataRow dr = materialList.Find(
                    delegate(DataRow row)
                    {
                        return dataGridViewMaterial.Rows[i].Cells[0].Value.ToString().Trim() == row["الرقم_الفني"].ToString().Trim();
                    });

                    dr["كمية"] = quantity;
                    dr["DiscountPersent"] = DiscountPersent;
                    dr["Discount"] = discount;
                    dr["Comment"] = dataGridViewMaterial.Rows[i].Cells[7].Value.ToString();
                    dr["TotalValue"] = PriceValue;
                    if (price != Convert.ToInt32(dr["سعر_الشراء"]))
                    {
                        if (MessageBox.Show("هل ترغب بتغير سعر بيع  " + dr["اسم_المادة"] + " ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            mta = new materialTableAdapter();
                            mta.UpdateBuyPrice(price, Convert.ToInt32(dr["الرقم_الفني"]));
                            dr["سعر_الشراء"] = price;
                        }
                        else
                        {
                            dr["سعر_الشراء"] = price;
                        }
                    }
                    else
                    {
                        dr["سعر_الشراء"] = price;
                    }
                    totalPriceValue = 0;
                    totalCostValue = 0;
                    totalDiscountValue = 0;
                    foreach (DataRow row in materialList)
                    {
                        try
                        {
                            totalPriceValue += Convert.ToDouble(row["TotalValue"]);
                            totalCostValue += Convert.ToDouble(row["TotalCost"]);
                            totalDiscountValue += Convert.ToDouble(row["Discount"]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception1 :: " + ex.Message);
                        }
                    }
                    txtTotalPrice.Text = totalPriceValue.ToString();
                    txtDiscount.Text = totalDiscountValue.ToString();
                    //txtTotalCost.Text = totalCostValue.ToString();
                    txtTotalCost.Text = (totalPriceValue - totalDiscountValue).ToString();
                }

            }
            /*}
            catch (Exception ex)
            {
                Console.WriteLine("Exception2 :: " + ex.Message);
            }*/
        }
        private void b1_Click(object sender, EventArgs e)
        {
            txtQuintity1.Text += "1";
            txtQuintity1.Text = txtQuintity1.Text;
            Quintity = Convert.ToInt32(txtQuintity1.Text);

        }

        private void b2_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "2";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);

        }

        private void b3_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "3";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);

        }

        private void b4_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "4";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);

        }

        private void b5_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "5";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);

        }

        private void b6_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "6";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);

        }

        private void b7_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "7";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);

        }

        private void b8_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "8";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);

        }

        private void b9_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "9";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);

        }

        private void b0_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "0";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);

        }

        private void bAC_Click(object sender, EventArgs e)
        {
            txtQuintity.Text = "0";
            txtQuintity1.Text = txtQuintity.Text;

        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            materialTableAdapter mta = new materialTableAdapter();
            MaterialControllar.materialDataTable mdt = mta.GetDataByGroub(Convert.ToInt32(cbGroup.Text.Split('.')[1]));
            dataGridViewMaterilList.DataSource = mdt;

            dataGridViewMaterilList.Columns["الرقم_الفني"].HeaderText = "تسلسل";
            dataGridViewMaterilList.Columns["سعر_الشراء"].HeaderText = "السعر";
            dataGridViewMaterilList.Columns["اسم_المادة"].HeaderText = "المادة";

            //dataGridViewMaterilList.Columns["الرقم_الفني"].Visible = false;
            dataGridViewMaterilList.Columns["تواجد_المادة"].Visible = false;
            dataGridViewMaterilList.Columns["الوحدة"].Visible = false;
            dataGridViewMaterilList.Columns["سعر"].Visible = false;
            dataGridViewMaterilList.Columns["رمز_الطراز"].Visible = false;
            dataGridViewMaterilList.Columns["المجموعة"].Visible = false;
            dataGridViewMaterilList.Columns["الصانع"].Visible = false;
            dataGridViewMaterilList.Columns["المستودع"].Visible = false;
            dataGridViewMaterilList.Columns["بالة"].Visible = false;
            dataGridViewMaterilList.Columns["وصف_المادة"].Visible = false;
            dataGridViewMaterilList.Columns["صورة"].Visible = false;
            dataGridViewMaterilList.Columns["فرق_السعر"].Visible = false;
            dataGridViewMaterilList.Columns["فرق_الكمية"].Visible = false;
            //dataGridViewMaterilList.Columns["سعر_الشراء"].Visible = false;
            dataGridViewMaterilList.Columns["سعر_البيع"].Visible = false;
            dataGridViewMaterilList.Columns["كود_المادة"].Visible = false;
            dataGridViewMaterilList.Columns["DiscountPersent"].Visible = false;
            dataGridViewMaterilList.Columns["Discount"].Visible = false;
            dataGridViewMaterilList.Columns["Comment"].Visible = false;
            dataGridViewMaterilList.Columns["TotalValue"].Visible = false;
            dataGridViewMaterilList.Columns["TotalCost"].Visible = false;
            dataGridViewMaterilList.Columns["profit"].Visible = false;
            dataGridViewMaterilList.Columns["طريقة_حساب_الكلفة"].Visible = false;

            dataGridViewMaterilList.Columns["الرقم_الفني"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewMaterilList.Columns["اسم_المادة"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewMaterilList.Columns["كمية"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewMaterilList.Columns["سعر_الشراء"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void dataGridViewMaterilList_Click(object sender, EventArgs e)
        {
            txtSearchMaterial.Text = dataGridViewMaterilList.Rows[dataGridViewMaterilList.CurrentRow.Index].Cells["اسم_المادة"].Value.ToString();
            txtSearchMaterial.Text += "." + dataGridViewMaterilList.Rows[dataGridViewMaterilList.CurrentRow.Index].Cells["الرقم_الفني"].Value.ToString();
        }

        private void txtQuintity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bAddMaterial_Click(sender, e);
            }
        }

        private void dataGridViewMaterilList_KeyUp(object sender, KeyEventArgs e)
        {
            txtSearchMaterial.Text = dataGridViewMaterilList.Rows[dataGridViewMaterilList.CurrentRow.Index].Cells["اسم_المادة"].Value.ToString();
            txtSearchMaterial.Text += "." + dataGridViewMaterilList.Rows[dataGridViewMaterilList.CurrentRow.Index].Cells["الرقم_الفني"].Value.ToString();
        }

        private void dataGridViewMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                bRemoveMaterial_Click(sender, e);
            }
        }

        private void bFirst_Click(object sender, EventArgs e)
        {
            getReport(cbIds.Items.Count-1);
        }

        private void bLast_Click(object sender, EventArgs e)
        {
            getReport(0);
        }
    }
}
