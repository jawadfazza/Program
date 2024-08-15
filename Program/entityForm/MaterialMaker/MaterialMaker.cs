using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.CustomerControllarTableAdapters;
using Program.entity.controllar.MaterialControllarTableAdapters;
using Program.entity.controllar;
using Program.entity.controllar.BankControllarTableAdapters;
using Num2Wrd;
using Program.entityForm.customer.report;
using System.Collections;
using Program.entity.controllar.PaperReceiveControllarTableAdapters;
using Program.entity.controllar.CompanyControllarTableAdapters;
using System.IO.Ports;
using System.Threading;
using Program.entity.controllar.MaterialMakerControllarTableAdapters;

namespace Program.entityForm.customer
{
    public partial class MaterialMaker : Form
    {
        public MaterialMaker()
        {
            InitializeComponent();
        }
        SerialPort _serialPort;

        // delegate is used to write to a UI control from a non-UI thread
        private delegate void SetTextDeleg(string text);
        private void Sale_Load(object sender, EventArgs e)
        {
            dataGridViewMaterial.RowCount = 20;
            dataGridViewBond.RowCount = 9;
            getMaterialMakerNameAutocomplete();
            getMaterialNameAutocomplete();
            getReportId();
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

        private void getReportId()
        {
            material_creditTableAdapter mcta = new material_creditTableAdapter();
            MaterialControllar.material_creditDataTable mcdt = mcta.GetData();
            cbIds.Items.Clear();
            foreach (DataRow dr in mcdt.Rows)
            {
                cbIds.Items.Add(dr["الرقم"]);
            }
        }



        public void getMaterialMakerNameAutocomplete()
        {
            try
            {
                material_makerTableAdapter mta = new material_makerTableAdapter();
                MaterialMakerControllar.material_makerDataTable mdt = mta.GetData();
                ArrayList array = new ArrayList();
                foreach (DataRow row in mdt.Rows)
                {
                    if (row["اسم_المادة"].ToString() != "")
                    {
                        array.Add(row["اسم_المادة"].ToString() + "." + row["الرقم"].ToString());
                    }
                }
                array.Sort();
                txtMaterialMaker.Items.Clear();
                txtMaterialMaker.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
                txtMaterialMaker.Items.AddRange(array.ToArray());
            }
            catch (Exception ex)
            {

            }
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
                    array.Add(row["اسم_المادة"].ToString());
                }
            }
            array.Sort();
            txtSearchMaterial.Items.Clear();
            txtSearchMaterial.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtSearchMaterial.Items.AddRange(array.ToArray());
        }

        private void getMaterialCodeAutocomplete()
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

        private void Sale_Resize(object sender, EventArgs e)
        {
        }

        private void txtCustomer_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaterialMaker.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل اسم العميل فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void bAddMaterial_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                materialTableAdapter mta = new materialTableAdapter();
                MaterialControllar.materialDataTable mdt = mta.getMaterialByName(txtSearchMaterial.Text);
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

        static List<DataRow> materialList = new List<DataRow>();
        static int countMaterial = 0;
        private void addMaterial(DataRow dr)
        {
            dataGridViewMaterial.Rows[countMaterial].Cells[0].Value = dr["الرقم_الفني"];
            dataGridViewMaterial.Rows[countMaterial].Cells[1].Value = dr["اسم_المادة"];
            dataGridViewMaterial.Rows[countMaterial].Cells[2].Value = dr["كمية"];
            dataGridViewMaterial.Rows[countMaterial].Cells[3].Value = dr["سعر_البيع"];
            dataGridViewMaterial.Rows[countMaterial].Cells[4].Value = dr["DiscountPersent"];
            dataGridViewMaterial.Rows[countMaterial].Cells[5].Value = dr["Discount"];
            dataGridViewMaterial.Rows[countMaterial].Cells[6].Value = dr["TotalValue"];
            dataGridViewMaterial.Rows[countMaterial].Cells[7].Value = dr["Comment"];
            dataGridViewMaterial.Rows[countMaterial].Cells[8].Value = dr["سعر_الشراء"];
            dataGridViewMaterial.Rows[countMaterial].Cells[9].Value = dr["TotalCost"];
            dataGridViewMaterial.Rows[countMaterial].Cells[10].Value = dr["profit"];
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
            if (MessageBox.Show("إزالة المادة ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information,MessageBoxDefaultButton.Button1) == DialogResult.OK)
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
                    dataGridViewMaterial.Rows[i].Cells[8].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[9].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[10].Value = "";
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
                    materialTableAdapter mta = new materialTableAdapter();
                    int quantity = Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[2].Value.ToString());

                    if (quantity > Convert.ToInt32(mta.getMaterialById(Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[0].Value.ToString()))[0]["كمية"]))
                    {
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[2].Value = 0;
                        MessageBox.Show("إن الكمية المطلوبة أكبر من الموجودة ب المستودع", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        quantity = Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[2].Value.ToString());
                        int price = Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[3].Value.ToString());
                        int price_buy = Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[8].Value.ToString());

                        double DiscountPersent = Convert.ToDouble(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[4].Value.ToString());
                        double discount = quantity * price * (DiscountPersent / 100);
                        double PriceValue = (quantity * price) - discount;
                        double PriceValue_buy = (quantity * price_buy);

                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[5].Value = discount;
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[6].Value = PriceValue;
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[9].Value = PriceValue_buy;
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[10].Value = (PriceValue-PriceValue_buy);

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
                        dr["TotalCost"] = PriceValue_buy;
                        dr["profit"] = PriceValue-PriceValue_buy;
                        if (price != Convert.ToInt32(dr["سعر_البيع"]))
                        {
                            if (MessageBox.Show("هل ترغب بتغير سعر بيع  " + dr["اسم_المادة"] + " ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                mta.UpdateBuyPrice( price,Convert.ToInt32(dr["الرقم_الفني"] ));
                                dr["سعر_البيع"] = price;
                            }
                            else
                            {
                                dr["سعر_البيع"] = price;
                            }
                        }
                        else
                        {
                            dr["سعر_البيع"] = price;
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
                        txtTotalCost.Text = totalCostValue.ToString();
                        txtTotalProfit.Text = (totalPriceValue-totalDiscountValue-totalCostValue+totalPenfitValue).ToString();
                    }
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
            material_creditTableAdapter mcta=new material_creditTableAdapter();
                if ( totalPriceValue > 0)
                {
                    bc = new BondControllar();

                    bc.balance = totalPriceValue + totalDiscountValue;
                    bc.balanceText = nte.changeNumericToWords(totalPriceValue + totalDiscountValue);
                    bc.bondFrom = "زبون." + txtMaterialMaker.Text;
                    bc.bondTo = "مبيعات." + (Convert.ToInt32(mcta.getMaxMaterialCredit()));
                    bc.comment = "بيع يضاعة للزبون " + txtMaterialMaker.Text ;

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[0].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[0].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[0].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[0].Cells[3].Value = bc.comment;

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
                bc.bondFrom = "حسم ممنوح";
                bc.bondTo = "زبون." + txtMaterialMaker.Text;
                bc.comment = "تقديم حسم ممنوح للزبو " + txtMaterialMaker.Text + " لقاء بضاعة ";

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
                dataGridViewBond.Rows[1].Cells[3].Value = bc.comment;

            }
           
            return bc;
        }

        private BondControllar setBond3()
        {
            material_creditTableAdapter mcta = new material_creditTableAdapter();
            if (Convert.ToInt32(txtMoreBills.Text) > 0)
            {

                bc = new BondControllar();

                bc.balance = Convert.ToDouble(txtMoreBills.Text);
                bc.balanceText = nte.changeNumericToWords(Convert.ToDouble(txtMoreBills.Text));
                bc.bondFrom = "زبون." + txtMaterialMaker.Text;
                bc.bondTo = "مصاريف البيع." + (Convert.ToInt32(mcta.getMaxMaterialCredit()));
                bc.comment = "مصاريف البيع يضاعة للزبون " + txtMaterialMaker.Text + " على حساب الزبون";

                //bcList.Add(bc);
                dataGridViewBond.Rows[2].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[2].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[2].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[2].Cells[3].Value = bc.comment;

                bc = new BondControllar();
                bc.balance = Convert.ToDouble(txtMoreBills.Text);
                bc.balanceText = nte.changeNumericToWords(Convert.ToDouble(txtMoreBills.Text));
                bc.bondFrom = "مصاريف البيع." + (Convert.ToInt32(mcta.getMaxMaterialCredit()) + 1);
                bc.bondTo = "صندوق.صندوق.1";
                bc.comment = "مصاريف البيع يضاعة للزبون " + txtMaterialMaker.Text + " على حساب الشركة";

                //bcList.Add(bc);
                dataGridViewBond.Rows[2].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[2].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[2].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[2].Cells[3].Value = bc.comment;
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
            if (totalPriceValue > 0)
            {

                bc.balance = totalPriceValue;
                bc.balanceText = nte.changeNumericToWords(totalPriceValue);

                bc.balance = totalPriceValue + Convert.ToDouble(txtMoreBills.Text);
                bc.balanceText = nte.changeNumericToWords(totalPriceValue + Convert.ToDouble(txtMoreBills.Text));

                bc.bondFrom = "صندوق.صندوق اليومية.1";
                bc.bondTo = "زبون." + txtMaterialMaker.Text;
                bc.comment = "تسديد الزبون " + txtMaterialMaker.Text + " نقداً لقاء بضاعة";

                //bcList.Add(bc);
                dataGridViewBond.Rows[4].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[4].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[4].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[4].Cells[3].Value = bc.comment;
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
                dataGridViewBond.Rows[4].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[4].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[4].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[4].Cells[3].Value = bc.comment;

            }
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

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            getReportId();
            //txtMaterialMaker.Text = "";
            txtTotalPrice.Text = "0";
            txtDiscount.Text = "0";

            //dtpSaleDate.Value = DateTime.Now;
            dtpReciveDate.Value = DateTime.Now;
            totalPriceValue = 0;
            totalDiscountValue = 0;
            txtMoreBills.Text = "0";
            materialList.Clear();
            countMaterial = 0;
           // indexMaterialdebit = 0;
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

        private void openToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Console.WriteLine("id: " + txtMaterialMaker.Text.Split('.')[1]);
                }
            }
            catch (Exception ex)
            {

            }
        }

        int indexMaterialCredit = 0;
        private void bNext_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                indexMaterialCredit++;
            }
            getReport(indexMaterialCredit);
            if (indexMaterialCredit == (cbIds.Items.Count - 1))
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
            indexMaterialCredit--;
            getReport(indexMaterialCredit);
            if (indexMaterialCredit == 0)
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

        static bool isSaveBonds = true;
        static DataRow rowMaterialdCredit;
        private void getReport(int indexValue)
        {
            try
            {
                txtId.Text = cbIds.Items[indexValue].ToString();
                Guid id = Guid.Parse(rowMaterialdDebit["الرقم"].ToString());
                material_creditTableAdapter mcta = new material_creditTableAdapter();
                MaterialControllar.material_creditDataTable mcdt = mcta.getMaterialCreditById(id);
                rowMaterialdCredit = mcdt.Rows[0];

                txtMaterialMaker.Text = rowMaterialdCredit["إلى"].ToString().Split('.')[1] + "." + rowMaterialdCredit["إلى"].ToString().Split('.')[2];
                totalPriceValue = Convert.ToDouble(rowMaterialdCredit["الرصيد"].ToString());
                txtTotalPrice.Text = rowMaterialdCredit["الرصيد"].ToString();
                totalDiscountValue = Convert.ToDouble(rowMaterialdCredit["حسم_ممنوح"].ToString());
                txtDiscount.Text = rowMaterialdCredit["حسم_ممنوح"].ToString();
                txtTotalCost.Text = rowMaterialdCredit["الكلفة"].ToString();

                //dtpSaleDate.Value = Convert.ToDateTime(rowMaterialdCredit["تاريخ_البيع"]);
                dtpReciveDate.Value = Convert.ToDateTime(rowMaterialdCredit["تاريخ_التسليم"]);
                txtMoreBills.Text = rowMaterialdCredit["مصاريف_مضافة"].ToString();
                isSaveBonds = Convert.ToBoolean(rowMaterialdCredit["مرحل"]);
                //idPaperReceived = 0;
                txtTotalProfit.Text = (totalPriceValue - totalDiscountValue + Convert.ToInt32(txtPenfitValue.Text) - Convert.ToInt32(rowMaterialdCredit["الكلفة"].ToString())).ToString();

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
                material_credit_listTableAdapter mclta = new material_credit_listTableAdapter();
                MaterialControllar.material_credit_listDataTable mcldt = mclta.getMaterialCreditReport(id);

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
                //change
                double price = 0;
                //
                foreach (DataRow dr in mcldt)
                {
                    materialTableAdapter mta1 = new materialTableAdapter();
                    MaterialControllar.materialDataTable material = mta1.getMaterialById(Guid.Parse(dr["الرقم_الفني"].ToString()));

                    dataGridViewMaterial.Rows[count].Cells[0].Value = dr["رقم_المادة"];
                    dataGridViewMaterial.Rows[count].Cells[1].Value = dr["اسم_المادة"];
                    dataGridViewMaterial.Rows[count].Cells[2].Value = dr["الكمية"];
                    dataGridViewMaterial.Rows[count].Cells[3].Value = dr["السعر"];
                    dataGridViewMaterial.Rows[count].Cells[4].Value = Convert.ToInt32((Convert.ToDouble(dr["حسم_ممنوح"]) / Convert.ToDouble(dr["السعر_الجمالي"])) * 100);
                    dataGridViewMaterial.Rows[count].Cells[5].Value = dr["حسم_ممنوح"];
                    dataGridViewMaterial.Rows[count].Cells[6].Value = dr["السعر_الجمالي"];
                    dataGridViewMaterial.Rows[count].Cells[7].Value = dr["ملاحظات"];
                    //change
                    price = price + Convert.ToDouble(dr["السعر_الجمالي"]);
                    //
                    count++;
                    material.Rows[0]["كمية"] = dr["الكمية"];
                    materialList.Add(material.Rows[0]);
                }
                //change
                txtTotalPrice.Text = price.ToString();
                //
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

        private void txtCustomer_TextChanged(object sender, EventArgs e)
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
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception ex)
            {

            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            SaleBills sb = new SaleBills();
            sb.ShowDialog();
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

        private void bSaveAll_Click(object sender, EventArgs e)
        {
            Guid id=0;
            if (SaveBuy)
            {
                if (MessageBox.Show("هل تريد حفط التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    materialMaker_creditTableAdapter mcta = new materialMaker_creditTableAdapter();

                    //mcta.Insert(DateTime.Now,

                     id = Convert.ToInt32(mcta.getMaxMaterailMaker());
                    material_credit_listTableAdapter mclta = new material_credit_listTableAdapter();
                    materialTableAdapter mta = new materialTableAdapter();


                    foreach (DataRow row in materialList)
                    {
                        try
                        {
                            double totalvalue = Convert.ToDouble(row["TotalValue"]);
                            double discount = Convert.ToDouble(row["Discount"]);

                            mclta.Insert(Guid.Parse(row["الرقم_الفني"].ToString()),
                                id,
                                row["اسم_المادة"].ToString(),
                                row["الوحدة"].ToString(),
                                Convert.ToInt32(row["كمية"].ToString()),
                                Convert.ToInt32(row["سعر_البيع"].ToString()),
                                totalvalue + discount,
                                row["Comment"].ToString(),
                                0,
                                nte.changeNumericToWords(Convert.ToInt32(row["كمية"].ToString())),
                                "",
                                discount,
                                Convert.ToInt32(row["سعر_الشراء"].ToString()),
                                Convert.ToDouble(row["TotalCost"].ToString()));

                            int quantity = Convert.ToInt32(mta.getMaterialById(Guid.Parse(row["الرقم_الفني"].ToString()))[0]["كمية"]);

                            mta.UpdateMaterialQuantity((quantity - Convert.ToInt32(row["كمية"])),
                                Guid.Parse(row["الرقم_الفني"].ToString()));
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
                    if (MessageBox.Show("هل ترغب بستعراض الفاتورة ؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        SaleBills sb = new SaleBills();
                        sb.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("هناك خطأ في الأرصدة لا يمكن إتمام العملية", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void bHide_Click(object sender, EventArgs e)
        {
            gbBonds.Hide();
        }

        private void bShow_Click(object sender, EventArgs e)
        {
            gbBonds.Show();
        }

        private void cbMoreBillsOption_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception ex)
            {

            }
        }

        private void Sale_FormClosed(object sender, FormClosedEventArgs e)
        {
            materialList.Clear();
        }

        private void txtCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception ex)
            {
            }
        }

        private void dtpPaperRecieved_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
                //lDatePayment.Text=" الإستحقاق في: "+dtpReciveDate.Value.;
            }
            catch (Exception ex)
            {
            }
        }




        private void dataGridViewMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                bRemoveMaterial_Click(sender, e);
            }
        }

        private void bMaterialCard_Click(object sender, EventArgs e)
        {
            NewMaterial nm = new NewMaterial();
            nm.MdiParent = Main.ActiveForm;
            nm.LayoutMdi(MdiLayout.ArrangeIcons);
            nm.Show();
        }

        private void txtMaterialMakerQuantity_TextChanged(object sender, EventArgs e)
        {
            newToolStripButton_Click(sender, e);
            material_maker_listTableAdapter mmlta = new material_maker_listTableAdapter();
            MaterialMakerControllar.material_maker_listDataTable mmldt = mmlta.getMaterialMakerList(Convert.ToInt32(txtMaterialMaker.Text.Split('.')[1]));
            foreach (DataRow mmr in mmldt.Rows)
            {
                bool found = false;
                try
                {
                    materialTableAdapter mta = new materialTableAdapter();
                    MaterialControllar.materialDataTable mdt = mta.getMaterialById(Convert.ToInt32(mmr["رقم_المادة"]));
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
                        dr["كمية"] = Convert.ToInt32( mmr["كمية"])*Convert.ToInt32(txtMaterialMakerQuantity.Text);
                        materialList.Add(dr);
                        addMaterial(dr);
                    }
                }
                catch (Exception ex)
                {

                }
            }

        }
        
    }
}
