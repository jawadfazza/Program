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
    public partial class Buy : Form
    {
        public Buy()
        {
            InitializeComponent();
        }

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
            pPayAfter.Hide();
            newToolStripButton_Click(sender, e);

            // all of the options for a serial device
            // can be sent through the constructor of the SerialPort class
            // PortName = "COM1", Baud Rate = 19200, Parity = None, 
            // Data Bits = 8, Stop Bits = One, Handshake = None
            //_serialPort = new SerialPort("COM1", 19200, Parity.None, 8, StopBits.One);
            //_serialPort.Handshake = Handshake.None;
            //_serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            //_serialPort.ReadTimeout = 500;
            //_serialPort.WriteTimeout = 500;
            //_serialPort.Open();
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
        static double totalDiscountValue = 0;
        static double totalPenfitValue = 0;
        public void calculateReportValue()
        {
            try
            {
                var currentCell = dataGridViewMaterial.CurrentCell;
                if (currentCell == null)
                    return;

                var currentRow = dataGridViewMaterial.Rows[currentCell.RowIndex];
                if (currentRow.Cells[0].Value == null)
                    return;

                int quantity = Convert.ToInt32(currentRow.Cells[2].Value);
                int price = Convert.ToInt32(currentRow.Cells[3].Value);
                double discountPercent = Convert.ToDouble(currentRow.Cells[4].Value);
                double discount = quantity * price * (discountPercent / 100);
                double priceValue = (quantity * price) - discount;

                currentRow.Cells[5].Value = discount;
                currentRow.Cells[6].Value = priceValue;

                DataRow dr = materialList.Find(row =>
                    currentRow.Cells[0].Value.ToString().Trim() == row["الرقم_الفني"].ToString().Trim());

                if (dr != null)
                {
                    dr["كمية"] = quantity;
                    dr["DiscountPersent"] = discountPercent;
                    dr["Discount"] = discount;
                    dr["Comment"] = currentRow.Cells[7].Value.ToString();
                    dr["TotalValue"] = priceValue;

                    int currentPrice = Convert.ToInt32(dr["سعر_الشراء"]);
                    if (price != currentPrice)
                    {
                        if (MessageBox.Show($"هل ترغب بتغير سعر بيع {dr["اسم_المادة"]} ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            materialTableAdapter mta = new materialTableAdapter();
                            mta.UpdateBuyPrice(price, Guid.Parse(dr["الرقم_الفني"].ToString()));
                        }
                        dr["سعر_الشراء"] = price;
                    }

                    totalPriceValue = 0;
                    totalDiscountValue = 0;
                    foreach (DataRow row in materialList)
                    {
                        totalPriceValue += Convert.ToDouble(row["TotalValue"]);
                        totalDiscountValue += Convert.ToDouble(row["Discount"]);
                    }

                    txtTotalPrice.Text = totalPriceValue.ToString();
                    txtDiscount.Text = totalDiscountValue.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                MessageBox.Show($"An error occurred while calculating the report value: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bAddBond_Click(object sender, EventArgs e)
        {
            setBond1();
            setBond2();
            setBond3();
            setBond4();
            setBond5();
            setBond6();
            setBond7();
        }

        BondControllar bc;
        List<BondControllar> bcList = new List<BondControllar>();
        NumberToEnglish nte = new NumberToEnglish();
        private BondControllar setBond1()
        {
            material_debitTableAdapter mcta=new material_debitTableAdapter();
                if ( totalPriceValue > 0)
                {
                    bc = new BondControllar();

                    bc.balance = totalPriceValue + totalDiscountValue;
                    bc.balanceText = nte.changeNumericToWords(totalPriceValue + totalDiscountValue);
                    bc.bondFrom = "مشتريات بضاعة." + (Convert.ToInt32(mcta.getMaxMaterialDebit()) + 1); 
                    bc.bondTo = "مورد." + txtSupplier.Text;
                    bc.comment="شراء يضاعة من المورد "+txtSupplier.Text +" لقاء بضاعة " ;

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
                if (totalPriceValue > 0&&cbTypeOperation.Text=="كاش")
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
                    bc.bondTo =  "صندوق.صندوق اليومية.1";
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
                    bc.bondTo =  "مصرف." + cbBankAccounting.Text;
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
                bc.bondTo ="";
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

        private BondControllar setBond5()
        {
            if (rbPaperPay.Checked)
            {
                if (totalPriceValue > 0)
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
                    paper_payTableAdapter prta = new paper_payTableAdapter();
                    bc.bondFrom =  "مورد." + txtSupplier.Text;
                    bc.bondTo = "سند دفع." + txtSupplier.Text.Split('.')[0] + "." + (idPaperPay);
                    bc.comment = "تقديم ل " + txtSupplier.Text + " كمبيالة (سند دفع) يستحق بتاريخ " + dtpPaperRecieved.Value;

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[4].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[4].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[4].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[4].Cells[3].Value = bc.comment;

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
                dataGridViewBond.Rows[4].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[4].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[4].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[4].Cells[3].Value = bc.comment;

            }
            return bc;
        }


        private BondControllar setBond6()
        {
            if (rbAfter.Checked)
            {
                double penfitPersent = Convert.ToInt32(txtPenfitPresent.Text);
                if (txtPenfitPresent.Text == "")
                {
                    txtPenfitPresent.Text = "0";
                }
                {
                }
                if (penfitPersent >= 0 && penfitPersent <= 100)
                {
                    txtPenfitValue.Text = (Convert.ToInt32(txtTotalPrice.Text) * (penfitPersent / 100)).ToString();
                    totalPenfitValue = Convert.ToDouble(txtPenfitValue.Text);
                }
                else
                {
                    txtPenfitPresent.Text = "0";
                    MessageBox.Show("الفائدة بين 0 و 100", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                if (totalPenfitValue > 0)
                {
                    bc = new BondControllar();

                    bc.balance = totalPenfitValue;
                    bc.balanceText = nte.changeNumericToWords(totalPenfitValue);
                    bc.bondFrom = "فائدة مشتريات التقسيط";
                    bc.bondTo = "مورد." + txtSupplier.Text;
                    bc.comment = "الحصول على فائدة مشتريات التقسيط من المورد" + txtSupplier.Text + " لقاء بضاعة ";

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[5].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[5].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[5].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[5].Cells[3].Value = bc.comment;

                }
            }
            if (rbCash.Checked || rbPaperPay.Checked)
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";
                bc.comment = "";

                //bcList.Add(bc);
                dataGridViewBond.Rows[5].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[5].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[5].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[5].Cells[3].Value = bc.comment;

            }

            return bc;
        }

        private BondControllar setBond7()
        {
            if (rbAfter.Checked)
            {
                if (txtFiestCashPaymant.Text != "0" && cbTypeOperation.Text == "كاش")
                {
                    bc = new BondControllar();

                    bc.balance = Convert.ToDouble(txtFiestCashPaymant.Text);
                    bc.balanceText = nte.changeNumericToWords(Convert.ToDouble(txtFiestCashPaymant.Text));
                    bc.bondTo = "مورد." + txtSupplier.Text;
                    bc.bondFrom = "صندوق.صندوق اليومية.1";
                    
                    //change
                    bc.comment = "تسديد الزبون " + txtSupplier.Text + " نقداً رعبون بضاعة تقسيط";
                    //
                    //bcList.Add(bc);
                    dataGridViewBond.Rows[6].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[6].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[6].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[6].Cells[3].Value = bc.comment;

                }
                if (txtFiestCashPaymant.Text != "0" && cbTypeOperation.Text == "شيك")
                {
                    bc = new BondControllar();

                    bc.balance = Convert.ToDouble(txtFiestCashPaymant.Text); ;
                    bc.balanceText = nte.changeNumericToWords(Convert.ToDouble(txtFiestCashPaymant.Text));
                    bc.bondFrom = "مورد." + txtSupplier.Text;
                    bc.bondTo = "مصرف." + cbBankAccounting.Text;
                    //change
                    bc.comment = "تسديد مورد " + txtSupplier.Text + " بشيك لقاء رعبون بضاعة تقسيط";
                    //
                    //bcList.Add(bc);
                    dataGridViewBond.Rows[6].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[6].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[6].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[6].Cells[3].Value = bc.comment;

                }
            }else{
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";
                bc.comment = "";

                //bcList.Add(bc);
                dataGridViewBond.Rows[6].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[6].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[6].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[6].Cells[3].Value = bc.comment;

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

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            pPayAfter.Hide();
            cbTypeOperation.Enabled = true;
            cbBankAccounting.Enabled = false;
            dtpPaperRecieved.Enabled = false;
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
            pPayAfter.Show();
            dtpPaperRecieved.Enabled = false;
            cbTypeOperation.Enabled = true;
            cbBankAccounting.Enabled = false;
            dtpPaperRecieved.Enabled = false;
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
            if (rbPaperPay.Checked)
            {
                value = "سند دفع";
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

            for (int i = 0; i < 9 ; i++)
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
        static bool isSaveBonds=true;
        private void getReport(int indexValue)
        {
            try
            {
                if (indexValue < 0 || indexValue >= cbIds.Items.Count)
                {
                    MessageBox.Show("Invalid index value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtId.Text = cbIds.Items[indexValue].ToString();
                Guid id = Guid.Parse(rowMaterialdDebit["الرقم"].ToString());
                material_debitTableAdapter mcta = new material_debitTableAdapter();
                MaterialControllar.material_debitDataTable mcdt = mcta.getMaterialDebitById(id);

                if (mcdt.Rows.Count == 0)
                {
                    MessageBox.Show("No data found for the selected ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                rowMaterialdDebit = mcdt.Rows[0];

                txtSupplier.Text = rowMaterialdDebit["من"].ToString().Split('.')[1] + "." + rowMaterialdDebit["من"].ToString().Split('.')[2];
                totalPriceValue = Convert.ToDouble(rowMaterialdDebit["الرصيد"]);
                txtTotalPrice.Text = totalPriceValue.ToString();
                totalDiscountValue = Convert.ToDouble(rowMaterialdDebit["حسم_مكتسب"]);
                txtDiscount.Text = totalDiscountValue.ToString();

                SetOperationType(rowMaterialdDebit["نوع_العملية"].ToString());
                cbTypeOperation.Text = rowMaterialdDebit["طريقة_الدفع"].ToString();
                cbBankAccounting.Text = rowMaterialdDebit["اسم_الحساب"].ToString();
                txtBiles.Text = rowMaterialdDebit["رقم_فاتورة_المصدر"].ToString();
                dtpBillDate.Value = Convert.ToDateTime(rowMaterialdDebit["تاريخ_فاتورة_المصدر"]);
                txtMoreBills.Text = rowMaterialdDebit["مصاريف_مضافة"].ToString();
                cbMoreBillsOption.Text = rowMaterialdDebit["مصاريف_على_حساب"].ToString();
                isSaveBonds = Convert.ToBoolean(rowMaterialdDebit["مرحل"]);
                idPaperPay = Guid.Parse( rowMaterialdDebit["سند_الدفع"].ToString());

                UpdateBondStatus(isSaveBonds);

                material_debit_listTableAdapter mclta = new material_debit_listTableAdapter();
                MaterialControllar.material_debit_listDataTable mcldt = mclta.getMaterialDebitReport(id);

                ClearDataGridViewMaterial();

                materialList.Clear();
                int count = 0;

                foreach (DataRow dr in mcldt)
                {
                    AddMaterialToGrid(dr, count);
                    count++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetOperationType(string operationType)
        {
            switch (operationType)
            {
                case "نقداً":
                    rbCash.Checked = true;
                    break;
                case "لأجل":
                    rbAfter.Checked = true;
                    break;
                case "سند دفع":
                    rbPaperPay.Checked = true;
                    break;
                default:
                    rbCash.Checked = false;
                    rbAfter.Checked = false;
                    rbPaperPay.Checked = false;
                    break;
            }
        }

        private void UpdateBondStatus(bool isBondSaved)
        {
            if (isBondSaved)
            {
                gbBonds.Text = "تم ترحيل قيد العملية";
                gbBonds.ForeColor = Color.Green;
            }
            else
            {
                gbBonds.Text = "لم يتم ترحيل قيد العملية";
                gbBonds.ForeColor = Color.Red;
            }
        }

        private void ClearDataGridViewMaterial()
        {
            for (int i = 0; i < dataGridViewMaterial.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewMaterial.Columns.Count; j++)
                {
                    dataGridViewMaterial.Rows[i].Cells[j].Value = null;
                }
            }
        }

        private void AddMaterialToGrid(DataRow dr, int rowIndex)
        {
            materialTableAdapter mta1 = new materialTableAdapter();
            MaterialControllar.materialDataTable material = mta1.getMaterialById(Guid.Parse(dr["الرقم_الفني"].ToString()));

            dataGridViewMaterial.Rows[rowIndex].Cells[0].Value = dr["رقم_المادة"];
            dataGridViewMaterial.Rows[rowIndex].Cells[1].Value = dr["اسم_المادة"];
            dataGridViewMaterial.Rows[rowIndex].Cells[2].Value = dr["الكمية"];
            dataGridViewMaterial.Rows[rowIndex].Cells[3].Value = dr["السعر"];
            dataGridViewMaterial.Rows[rowIndex].Cells[4].Value = Convert.ToInt32((Convert.ToDouble(dr["حسم_مكتسب"]) / Convert.ToDouble(dr["السعر_الجمالي"])) * 100);
            dataGridViewMaterial.Rows[rowIndex].Cells[5].Value = dr["حسم_مكتسب"];
            dataGridViewMaterial.Rows[rowIndex].Cells[6].Value = dr["السعر_الجمالي"];
            dataGridViewMaterial.Rows[rowIndex].Cells[7].Value = dr["ملاحظات"];

            if (material.Rows.Count > 0)
            {
                material.Rows[0]["كمية"] = dr["الكمية"];
                materialList.Add(material.Rows[0]);
            }
        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
                txtTotalCost.Text = (Convert.ToInt32(txtTotalPrice.Text) - Convert.ToInt32(txtDiscount.Text) - Convert.ToInt32(txtPenfitValue.Text)).ToString();

            }
            catch (Exception ex)
            {

            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDiscount.Text == "")
                {
                    txtDiscount.Text = "0";
                }
                totalDiscountValue = Convert.ToDouble(txtDiscount.Text);
                txtTotalCost.Text = (Convert.ToInt32(txtTotalPrice.Text) - Convert.ToInt32(txtDiscount.Text) + Convert.ToInt32(txtPenfitValue.Text)).ToString();
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

        SerialPort _serialPort;

        // delegate is used to write to a UI control from a non-UI thread
        private delegate void SetTextDeleg(string text);
        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSearchType.Text == "اسم المادة")
                {
                    getMaterialNameAutocomplete();
                    _serialPort.Close();
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
                    array.Add(row["اسم_المادة"].ToString());
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
                        MaterialControllar.materialDataTable material = mta1.getMaterialById(Guid.Parse(row["الرقم_الفني"].ToString()));

                        mta.UpdateMaterialQuantity((Convert.ToInt32(material.Rows[0]["كمية"]) + Convert.ToInt32(row["كمية"])),
                        Guid.Parse(row["الرقم_الفني"].ToString()));

                    }
                    Guid id = Guid.Parse(rowMaterialdDebit["الرقم"].ToString());
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
                // Validate paper receipt date
                if (rbPaperPay.Checked && dtpPaperRecieved.Value.Date <= DateTime.Now.Date)
                {
                    MessageBox.Show("تاريخ إستحقاق ورقة القبض يجب أن لا يكون أصغر أو يساوي التاريخ اليوم", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method early if validation fails
                }

                if (!SaveBuy)
                {
                    MessageBox.Show("رصيد النقدية غير كافي", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("هل تريد حفظ التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                {
                    return; // Exit if the user cancels
                }

                Guid id = Guid.NewGuid();
                double price = totalPriceValue + totalPenfitValue - totalDiscountValue;

                // Adjust price based on the bill option
                if (cbMoreBillsOption.Text == "على الزبون")
                {
                    price += Convert.ToDouble(txtMoreBills.Text);
                }

                var mcta = new material_debitTableAdapter();
                mcta.Insert(
                    الرقم: id,
                    تاريخ: DateTime.Now,
                    الرصيد: price,
                    من: $"مورد.{txtSupplier.Text}",
                    الرصيد_كتابة: nte.changeNumericToWords(price),
                    رقم_فاتورة_المصدر: Convert.ToInt32(txtBiles.Text),
                    تاريخ_فاتورة_المصدر: dtpBillDate.Value,
                    المصدر: string.Empty,
                    المستودع: string.Empty,
                    المورد: Guid.Parse(txtSupplier.Text.Split('.')[1]),
                    حذفة: string.Empty,
                    نوع_العملية: getType(),
                    حسام_مكتسب: Convert.ToDouble(totalDiscountValue),
                    مصاريف_مضافة: Convert.ToDouble(txtMoreBills.Text),
                    مصاريف_على_حساب: cbMoreBillsOption.Text,
                    مرحل: true.ToString(),
                    طريقة_الدفع: cbTypeOperation.Text,
                    اسم_الحساب: cbBankAccounting.Text,
                    سند_الدفع: Convert.ToInt32(idPaperPay),
                    code: string.Empty,
                    companyID: null
                );

                var mclta = new material_debit_listTableAdapter();
                var mta = new materialTableAdapter();

                if (rbPaperPay.Checked)
                {
                    var cta = new companyTableAdapter();
                    var company = cta.GetData().Rows[0];
                    var prta = new paper_payTableAdapter();
                    prta.Insert(0, string.Empty, DateTime.Now, dtpPaperRecieved.Value, txtSupplier.Text, company["name"].ToString());
                }

                if (rbAfter.Checked)
                {
                    int payCount = Convert.ToInt32(txtPayCount.Text);
                    int payTime = Convert.ToInt32(txtPayTime.Text);
                    int payValue = (int)((totalPriceValue + totalPenfitValue - totalDiscountValue - Convert.ToInt32(txtFiestCashPaymant.Text)) / payCount);

                    var mcppta = new material_debit_penfit_paymentTableAdapter();
                    int? advancePayment = string.IsNullOrWhiteSpace(txtFiestCashPaymant.Text) ? (int?)null : Convert.ToInt32(txtFiestCashPaymant.Text);

                    mcppta.Insert1(
                        id,
                        Convert.ToInt32(totalPenfitValue),
                        Convert.ToInt32(txtPenfitPresent.Text),
                        payTime,
                        payCount,
                        Guid.NewGuid(), // or appropriate Guid
                        advancePayment
                    );

                    var crtta = new supplier_PayTimeTableAdapter();
                    for (int i = 1; i <= payCount; i++)
                    {
                        crtta.Insert(
                            payValue,
                            nte.changeNumericToWords(payValue),
                            $"قسط مشتريات من المورد {txtSupplier.Text.Split('.')[0]}",
                            DateTime.Now.AddDays(i * payTime),
                            Convert.ToInt32(txtSupplier.Text.Split('.')[1]),
                            "false"
                        );
                    }
                }

                var mcta_cost = new material_costTableAdapter();
                foreach (DataRow row in materialList)
                {
                    try
                    {
                        double totalValue = Convert.ToDouble(row["TotalValue"]);
                        double discount = Convert.ToDouble(row["Discount"]);

                        var materialId = Guid.Parse(row["الرقم_الفني"].ToString());
                        var reportId = Guid.NewGuid(); // or the actual report Guid

                        mclta.Insert1(
                            الرقم: Guid.NewGuid(),
                             id,
                            reportId,
                            row["اسم_المادة"].ToString(),
                            row["الوحدة"].ToString(),
                            Convert.ToInt32(row["كمية"].ToString()),
                            Convert.ToDouble(row["سعر_الشراء"].ToString()),
                            totalValue + discount,
                            row["Comment"].ToString(),
                            0,
                            nte.changeNumericToWords(Convert.ToInt32(row["كمية"].ToString())),
                            string.Empty,
                            discount
                        );

                        mcta_cost.Insert(
                            الرقم: Guid.NewGuid(),
                            المادة: materialId,
                            سعر_الشراء: Convert.ToInt32(row["سعر_الشراء"].ToString()),
                            كمية: Convert.ToInt32(row["كمية"].ToString()),
                            التاريخ: DateTime.Now,
                            رقم_فاتورة_الشراء: id,
                            companyID: null
                        );

                        var materialData = mta.getMaterialById(materialId);
                        if (materialData != null && materialData.Rows.Count > 0)
                        {
                            int quantity = Convert.ToInt32(materialData.Rows[0]["كمية"]);
                            mta.UpdateMaterialQuantity(quantity + Convert.ToInt32(row["كمية"]), materialId);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"لم يتم إضافة {row["اسم_المادة"]}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Save bonds
                SaveBonds();

                getReportId();
                MessageBox.Show("تم إضافة التقرير", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                newToolStripButton_Click(sender, e);
                var bb = new BuyBills();
                bb.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("بعض العناصر مفقودة من بطاقة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bSaveCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbPaperPay.Checked && dtpPaperRecieved.Value.Date <= DateTime.Now.Date)
                {
                    MessageBox.Show("تاريخ إستحقاق ورقة القبض يجب أن لا يكون أصغر أو يساوي التاريخ اليوم", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!SaveBuy)
                {
                    MessageBox.Show("رصيد النقدية غير كافي", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("هل تريد حفظ التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                {
                    return;
                }

                Guid id = Guid.NewGuid();
                double price = totalPriceValue + totalPenfitValue - totalDiscountValue;

                // Adjust price based on the bill option
                if (cbMoreBillsOption.Text == "على المورد")
                {
                    price += Convert.ToDouble(txtMoreBills.Text);
                }

                var mcta = new material_debitTableAdapter();
                mcta.Insert(
                    الرقم: id,
                    تاريخ: DateTime.Now,
                    الرصيد: price,
                    من: $"مورد.{txtSupplier.Text}",
                    الرصيد_كتابة: nte.changeNumericToWords(price),
                    رقم_فاتورة_المصدر: Convert.ToInt32(txtBiles.Text),
                    تاريخ_فاتورة_المصدر: dtpBillDate.Value,
                    المصدر: string.Empty,
                    المستودع: string.Empty,
                    المورد: Guid.Parse(txtSupplier.Text.Split('.')[1]),
                    حذفة: string.Empty,
                    نوع_العملية: getType(),
                    حسام_مكتسب: Convert.ToDouble(totalDiscountValue),
                    مصاريف_مضافة: Convert.ToDouble(txtMoreBills.Text),
                    مصاريف_على_حساب: cbMoreBillsOption.Text,
                    مرحل: true.ToString(),
                    طريقة_الدفع: cbTypeOperation.Text,
                    اسم_الحساب: cbBankAccounting.Text,
                    سند_الدفع: Convert.ToInt32(idPaperPay),
                    code: string.Empty,
                    companyID: null
                );

                var mclta = new material_debit_listTableAdapter();
                var mta = new materialTableAdapter();

                if (rbPaperPay.Checked)
                {
                    var cta = new companyTableAdapter();
                    var company = cta.GetData().Rows[0];
                    var prta = new paper_payTableAdapter();
                    prta.Insert(0, string.Empty, DateTime.Now, dtpPaperRecieved.Value, txtSupplier.Text, company["name"].ToString());
                }

                if (rbAfter.Checked)
                {
                    int payCount = Convert.ToInt32(txtPayCount.Text);
                    int payTime = Convert.ToInt32(txtPayTime.Text);
                    int payValue = (int)((totalPriceValue + totalPenfitValue - totalDiscountValue - Convert.ToInt32(txtFiestCashPaymant.Text)) / payCount);

                    var mcppta = new material_debit_penfit_paymentTableAdapter();
                    int? advancePayment = string.IsNullOrWhiteSpace(txtFiestCashPaymant.Text) ? (int?)null : Convert.ToInt32(txtFiestCashPaymant.Text);

                    mcppta.Insert1(
                        id,
                        Convert.ToInt32(totalPenfitValue),
                        Convert.ToInt32(txtPenfitPresent.Text),
                        payTime,
                        payCount,
                        Guid.NewGuid(), // or appropriate Guid
                        advancePayment
                    );

                    var crtta = new supplier_PayTimeTableAdapter();
                    for (int i = 1; i <= payCount; i++)
                    {
                        crtta.Insert(
                            payValue,
                            nte.changeNumericToWords(payValue),
                            $"قسط مشتريات من المورد {txtSupplier.Text.Split('.')[0]}",
                            DateTime.Now.AddDays(i * payTime),
                            Convert.ToInt32(txtSupplier.Text.Split('.')[1]),
                            "false"
                        );
                    }
                }

                var mcta_cost = new material_costTableAdapter();
                foreach (DataRow row in materialList)
                {
                    try
                    {
                        double totalValue = Convert.ToDouble(row["TotalValue"]);
                        double discount = Convert.ToDouble(row["Discount"]);

                        var materialId = Guid.Parse(row["الرقم_الفني"].ToString());
                        var reportId = Guid.NewGuid(); // or the actual report Guid

                        mclta.Insert1(
                            Guid.NewGuid(),
                            id,
                            reportId,
                            row["اسم_المادة"].ToString(),
                            row["الوحدة"].ToString(),
                            Convert.ToInt32(row["كمية"].ToString()),
                            Convert.ToDouble(row["سعر_الشراء"].ToString()),
                            totalValue + discount,
                            row["Comment"].ToString(),
                            0,
                            nte.changeNumericToWords(Convert.ToInt32(row["كمية"].ToString())),
                            string.Empty,
                            discount
                        );

                        mcta_cost.Insert(
                            الرقم: Guid.NewGuid(),
                            المادة: materialId,
                            سعر_الشراء: Convert.ToInt32(row["سعر_الشراء"].ToString()),
                            كمية: Convert.ToInt32(row["كمية"].ToString()),
                            التاريخ: DateTime.Now,
                            رقم_فاتورة_الشراء: id,
                            companyID: null
                        );

                        var materialData = mta.getMaterialById(materialId);
                        if (materialData != null && materialData.Rows.Count > 0)
                        {
                            int quantity = Convert.ToInt32(materialData.Rows[0]["كمية"]);
                            mta.UpdateMaterialQuantity(quantity + Convert.ToInt32(row["كمية"]), materialId);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"لم يتم إضافة {row["اسم_المادة"]}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Save bonds
                SaveBonds();

                getReportId();
                MessageBox.Show("تم إضافة التقرير", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                newToolStripButton_Click(sender, e);
                var bb = new BuyBills();
                bb.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("بعض العناصر مفقودة من بطاقة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveBonds()
        {
            setBond1().SaveBonds();
            setBond2().SaveBonds();
            setBond3().SaveBonds();
            setBond4().SaveBonds();
            setBond5().SaveBonds();
            setBond6().SaveBonds();
            setBond7().SaveBonds();
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
                            if (rbPaperPay.Checked)
                            {
                                companyTableAdapter cta = new companyTableAdapter();
                                CompanyControllar.companyDataTable cdt = cta.GetData();
                                DataRow company = cdt.Rows[0];
                                paper_payTableAdapter prta = new paper_payTableAdapter();
                                prta.Insert(0, "", DateTime.Now, dtpPaperRecieved.Value, txtSupplier.Text, company["name"].ToString());
                            }
                            if (rbAfter.Checked)
                            {
                                int payCount = Convert.ToInt32(txtPayCount.Text);
                                int payTime = Convert.ToInt32(txtPayTime.Text);
                                int payValue = Convert.ToInt32((totalPriceValue + totalPenfitValue - totalDiscountValue - Convert.ToInt32(txtFiestCashPaymant.Text))) / payCount;


                                supplier_PayTimeTableAdapter crtta = new supplier_PayTimeTableAdapter();
                                for (int i = 1; i <= payCount; i++)
                                {
                                    crtta.Insert(payValue,
                                        nte.changeNumericToWords(payValue),
                                        "قسط مشتريات المورد " + txtSupplier.Text.Split('.')[0],
                                        DateTime.Now.AddDays(i * payTime),
                                        Convert.ToInt32(txtSupplier.Text.Split('.')[1])
                                        , "false");
                                }
                            }

                            setBond1().SaveBonds();
                            setBond2().SaveBonds();
                            setBond3().SaveBonds();
                            setBond4().SaveBonds();
                            setBond5().SaveBonds();
                            setBond6().SaveBonds();
                            setBond7().SaveBonds();

                            rowMaterialdDebit["مرحل"] = true.ToString();
                            material_debitTableAdapter mcta = new material_debitTableAdapter();
                            mcta.Update(rowMaterialdDebit);
                            MessageBox.Show("لقد تم ترحيل القيود ! ", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("بعض العناصر مفقودة من بطاقة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        static Guid idPaperPay ;
        private void rbPaperPay_CheckedChanged(object sender, EventArgs e)
        {
            pPayAfter.Hide();
            dtpPaperRecieved.Enabled = true;
            cbTypeOperation.Enabled = false;
            cbBankAccounting.Enabled = false;
            //cbTypeOperation.Text = "";
            cbBankAccounting.Text = "";
            paper_payTableAdapter prta = new paper_payTableAdapter();
            idPaperPay = Guid.NewGuid();
            bAddBond_Click(sender, e);
            if (rbPaperPay.Checked)
            {
                epInformation.SetError((Control)sender, "الدفع عن طريق كمبيالة دفع بتاريخ إستحقاق ");
            }
            else
            {
                epInformation.SetError((Control)sender, "");
            }
        }

        private void txtFiestCashPaymant_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiestCashPaymant.Text == "")
                {
                    txtFiestCashPaymant.Text = "0";
                }
                bAddBond_Click(sender, e);
            }
            catch (Exception ex)
            {
            }
        }

        private void txtPenfitPresent_TextChanged(object sender, EventArgs e)
        {
            try
            {

                bAddBond_Click(sender, e);

            }
            catch (Exception ex)
            {
                txtPenfitPresent.Text = "0";
                //MessageBox.Show("error : "+ex.Message, "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPenfitValue_TextChanged(object sender, EventArgs e)
        {
            txtPenfitValue1.Text = txtPenfitValue.Text;
            if (txtPenfitValue.Text != "0")
            {
                epInformation2.SetError((Control)sender, "الفائدة المدفوعة على المبيعات");
            }
            else
            {
                epInformation2.SetError((Control)sender, "");
            }
        }

        private void txtPayCount_TextChanged(object sender, EventArgs e)
        {
            if (txtPenfitValue.Text != "0")
            {
                epInformation2.SetError((Control)sender, "عدد الأقساط التي يجب أن يدفعها الزبون");
            }
            else
            {
                epInformation2.SetError((Control)sender, "");
            }
        }

        private void txtPenfitValue1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPenfitValue.Text == "")
                {
                    txtPenfitValue.Text = "0";
                }
                totalPenfitValue = Convert.ToDouble(txtPenfitValue.Text);
                txtTotalCost.Text = (Convert.ToInt32(txtTotalPrice.Text) - Convert.ToInt32(txtDiscount.Text) + Convert.ToInt32(txtPenfitValue.Text)).ToString();
                bAddBond_Click(sender, e);
            }
            catch (Exception)
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

        private void bFirst_Click(object sender, EventArgs e)
        {
            getReport(cbIds.Items.Count - 1);
        }

        private void bLast_Click(object sender, EventArgs e)
        {
            getReport(0);
        }
        
    }
}
