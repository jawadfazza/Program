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
using Program.entity.controllar.CustomerControllarTableAdapters;
using Program.entityForm.Customer.Report;
using System.Collections;
using Program.entity.controllar.PaperReceiveControllarTableAdapters;
using System.IO.Ports;
using System.Threading;

namespace Program.entityForm.customer
{
    public partial class ReturnSale : Form
    {
        public ReturnSale()
        {
            InitializeComponent();
        }
        SerialPort _serialPort;

        // delegate is used to write to a UI control from a non-UI thread
        private delegate void SetTextDeleg(string text);

        private void Sale_Load(object sender, EventArgs e)
        {
            dataGridViewMaterial.RowCount = 20;
            dataGridViewBond1.RowCount = 6;
            getCustomerNameAutocomplete();
            getMaterialNameAutocomplete();
            getBankAccounting();
            getReportId();
            getReportSaleId();

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

        private void getReportSaleId()
        {
            material_creditTableAdapter mcta = new material_creditTableAdapter();
            MaterialControllar.material_creditDataTable mcdt = mcta.GetData();
            txtBiles.Items.Clear();
            foreach (DataRow dr in mcdt.Rows)
            {
                txtBiles.Items.Add(dr["الرقم"]);
            }
        }

        private void getReportId()
        {
            material_debit_returnTableAdapter mcta = new material_debit_returnTableAdapter();
            MaterialControllar.material_debit_returnDataTable mcdt = mcta.GetData();
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

        public void getCustomerNameAutocomplete()
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
            txtMaterialSearch.Items.Clear();
            txtMaterialSearch.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtMaterialSearch.Items.AddRange(array.ToArray());
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
            txtMaterialSearch.Items.Clear();
            txtMaterialSearch.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtMaterialSearch.Items.AddRange(array.ToArray());
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
            txtMaterialSearch.Items.Clear();
            txtMaterialSearch.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtMaterialSearch.Items.AddRange(array.ToArray());
        }

        private void Sale_Resize(object sender, EventArgs e)
        {

        }

        private void txtCustomer_Validating(object sender, CancelEventArgs e)
        {
            if (txtCustomer.Text == "")
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
                    MaterialControllar.materialDataTable mdt = mta.getMaterialByName(txtMaterialSearch.Text);
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
                    MaterialControllar.materialDataTable mdt = mta.getMaterialByCode(txtMaterialSearch.Text);
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
            dataGridViewMaterial.Rows[countMaterial].Cells[3].Value = dr["سعر_البيع"];
            dataGridViewMaterial.Rows[countMaterial].Cells[4].Value = dr["DiscountPersent"];
            dataGridViewMaterial.Rows[countMaterial].Cells[5].Value = dr["Discount"];
            dataGridViewMaterial.Rows[countMaterial].Cells[6].Value = Convert.ToInt32(dr["كمية"]) * Convert.ToInt32(dr["سعر_البيع"]);
            dataGridViewMaterial.Rows[countMaterial].Cells[7].Value = dr["Comment"];
            dataGridViewMaterial.Rows[countMaterial].Cells[8].Value = dr["سعر_الشراء"];
            dataGridViewMaterial.Rows[countMaterial].Cells[9].Value = dr["TotalCost"];
            dataGridViewMaterial.Rows[countMaterial].Cells[10].Value = dr["profit"];

            txtMaterialSearch.Focus();
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
            DataRow dr = materialList.Find(
                delegate(DataRow row)
                {
                    return dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[0].Value.ToString().Trim() == row["الرقم_الفني"].ToString().Trim();
                });
            removeMaterial(dr);
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
        static double totalCostValue = 0;
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
                        int price_buy = Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[8].Value.ToString());
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
                        double PriceValue_buy = (quantity * price_buy);
                        ///////////////////////////////////////////
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[5].Value = discount;
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[6].Value = PriceValue;
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[9].Value = PriceValue_buy;
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[10].Value = (PriceValue - PriceValue_buy);

                        dr["كمية"] = quantity;
                        dr["DiscountPersent"] = DiscountPersent;
                        dr["Discount"] = discount;
                        dr["Comment"] = dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[7].Value.ToString();
                        dr["TotalValue"] = PriceValue;
                        dr["TotalCost"] = PriceValue_buy;

                        totalPriceValue = 0;
                        totalDiscountValue = 0;
                        totalCostValue = 0;
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
            material_debit_returnTableAdapter mcta = new material_debit_returnTableAdapter();
                if ( totalPriceValue > 0)
                {
                    bc = new BondControllar();

                    bc.balance = totalPriceValue + totalDiscountValue;
                    bc.balanceText = nte.changeNumericToWords(totalPriceValue + totalDiscountValue);
                    bc.bondFrom ="مردودات مبيعات." + (Convert.ToInt32(mcta.getMaxMaterialDebit()) + 1)/**/;
                    bc.bondTo = "زبون." + txtCustomer.Text;
                    bc.comment = "ردّ بضاعة من الزبون " + txtCustomer.Text;

                    //bcList.Add(bc);
                    dataGridViewBond1.Rows[0].Cells[0].Value = bc.balance;
                    dataGridViewBond1.Rows[0].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond1.Rows[0].Cells[2].Value = bc.bondTo;
                    dataGridViewBond1.Rows[0].Cells[3].Value = bc.comment;
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
                    dataGridViewBond1.Rows[0].Cells[0].Value = bc.balance;
                    dataGridViewBond1.Rows[0].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond1.Rows[0].Cells[2].Value = bc.bondTo;
                    dataGridViewBond1.Rows[0].Cells[2].Value = bc.comment;
                }
                //SaveReturnBuy = CheckBondsError("both", 0);

                return bc;
        }

        private BondControllar setBond2()
        {
            if (totalDiscountValue > 0)
            {
                bc = new BondControllar();

                bc.balance = totalDiscountValue;
                bc.balanceText = nte.changeNumericToWords(totalDiscountValue);
                bc.bondFrom = "زبون." + txtCustomer.Text;
                bc.bondTo = "حسم مكتسب";
                bc.comment = "الحصول على حسم من الزبون " + txtCustomer.Text +"نتيجة ردّ بضاعة مباعة سابقاً ";

                //bcList.Add(bc)
                dataGridViewBond1.Rows[1].Cells[0].Value = bc.balance;
                dataGridViewBond1.Rows[1].Cells[1].Value = bc.bondFrom;
                dataGridViewBond1.Rows[1].Cells[2].Value = bc.bondTo;
                dataGridViewBond1.Rows[1].Cells[3].Value = bc.comment; 
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
                dataGridViewBond1.Rows[1].Cells[0].Value = bc.balance;
                dataGridViewBond1.Rows[1].Cells[1].Value = bc.bondFrom;
                dataGridViewBond1.Rows[1].Cells[2].Value = bc.bondTo;
                dataGridViewBond1.Rows[1].Cells[2].Value = bc.comment;
            }
            //SaveReturnBuy = CheckBondsError("both", 1);

            return bc;
        }

        private BondControllar setBond3()
        {
            if (rbCash.Checked)
            {
                if (totalPriceValue > 0 && cbTypeOperation.Text=="كاش")
                {
                    bc = new BondControllar();

                    bc.balance = totalPriceValue;
                    bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    bc.bondFrom = "زبون." + txtCustomer.Text;
                    bc.bondTo = "صندوق.صندوق اليومية.1";
                    bc.comment = "الدفع للزبون " + txtCustomer.Text + " نقداً نتيجة ردّ البضاعة المباعة له";

                    //bcList.Add(bc);
                    dataGridViewBond1.Rows[2].Cells[0].Value = bc.balance;
                    dataGridViewBond1.Rows[2].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond1.Rows[2].Cells[2].Value = bc.bondTo;
                    dataGridViewBond1.Rows[2].Cells[3].Value = bc.comment;
                }
                if (totalPriceValue > 0 && cbTypeOperation.Text == "شيك")
                {
                    bc = new BondControllar();

                    bc.balance = totalPriceValue;
                    bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    bc.bondFrom = "زبون." + txtCustomer.Text;
                    bc.bondTo =  "مصرف." + cbBankAccounting.Text;
                    bc.comment = "الدفع للزبون " + txtCustomer.Text + " بشيك بنكي نتيجة ردّ البضاعة المباعة له";

                    //bcList.Add(bc);
                    dataGridViewBond1.Rows[2].Cells[0].Value = bc.balance;
                    dataGridViewBond1.Rows[2].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond1.Rows[2].Cells[2].Value = bc.bondTo;
                    dataGridViewBond1.Rows[2].Cells[3].Value = bc.comment;

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
                dataGridViewBond1.Rows[2].Cells[0].Value = bc.balance;
                dataGridViewBond1.Rows[2].Cells[1].Value = bc.bondFrom;
                dataGridViewBond1.Rows[2].Cells[2].Value = bc.bondTo;
                dataGridViewBond1.Rows[2].Cells[3].Value = bc.comment;

            }
            SaveReturnBuy = CheckBondsError("both", 2);

            return bc;
        }

        static Guid idPaperReceived = 0;
        private BondControllar setBond4()
        {
            if (rbPaperReceived.Checked)
            {
                if (totalPriceValue > 0)
                {
                    bc = new BondControllar();

                    bc.balance = totalPriceValue;
                    bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    paper_receiveTableAdapter prta = new paper_receiveTableAdapter();

                    bc.bondFrom = "زبون." + txtCustomer.Text;
                    bc.bondTo = "سند قبض." + txtCustomer.Text.Split('.')[0] + "." + (idPaperReceived);
                    bc.comment = "إلغاء سند القبص المسحوب بحق الزبون" + txtCustomer.Text ;

                    //bcList.Add(bc);
                    dataGridViewBond1.Rows[3].Cells[0].Value = bc.balance;
                    dataGridViewBond1.Rows[3].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond1.Rows[3].Cells[2].Value = bc.bondTo;
                    dataGridViewBond1.Rows[3].Cells[3].Value = bc.comment;
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
                dataGridViewBond1.Rows[3].Cells[0].Value = bc.balance;
                dataGridViewBond1.Rows[3].Cells[1].Value = bc.bondFrom;
                dataGridViewBond1.Rows[3].Cells[2].Value = bc.bondTo;
                dataGridViewBond1.Rows[3].Cells[3].Value = bc.comment;

            }
            SaveReturnBuy = CheckBondsError("both", 3);
            return bc;
        }


        bool SaveReturnBuy = true;
        static string[] IsBondTrested = new string[3];
        public bool CheckBondsError(string dir, int index)
        {
            bool ok = true;
            string[] message = bc.CheckBonds(dir);
            if (message[0] != "")
            {
                dataGridViewBond1.Rows[index].ErrorText = message[0];
                dataGridViewBond1.Rows[index].Cells[1].ErrorText = message[0];
                dataGridViewBond1.Rows[index].DefaultCellStyle.BackColor = Color.Gold;
                dataGridViewBond1.Rows[index].DefaultCellStyle.ForeColor = Color.Green;
                ok = false;
            }
            if (message[1] != "")
            {
                dataGridViewBond1.Rows[index].ErrorText += "\n" + message[1];
                dataGridViewBond1.Rows[index].Cells[2].ErrorText = message[1];
                dataGridViewBond1.Rows[index].DefaultCellStyle.BackColor = Color.Gold;
                dataGridViewBond1.Rows[index].DefaultCellStyle.ForeColor = Color.Green;
                ok = false;

            }
            //if there are no error
            if (message[0] == "" && message[1] == "")
            {
                dataGridViewBond1.Rows[index].ErrorText = "";
                dataGridViewBond1.Rows[index].Cells[1].ErrorText = message[0];
                dataGridViewBond1.Rows[index].Cells[2].ErrorText = message[1];
                dataGridViewBond1.Rows[index].DefaultCellStyle.BackColor = Color.White;
                dataGridViewBond1.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
                ok = true;
            }
            return ok;
        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            cbTypeOperation.Enabled = true;
            cbBankAccounting.Enabled=false;
            bAddBond_Click(sender, e);
            if (rbCash.Checked)
            {
                epInformation.SetError((Control)sender, "لقد تم دفع هده الفاتورة من خلال الصندوق");
            }
            else
            {
                epInformation.SetError((Control)sender, "");
            }
        }

        private void rbAfter_CheckedChanged(object sender, EventArgs e)
        {
            cbTypeOperation.Enabled = false;
            cbBankAccounting.Enabled = false;   
           // cbTypeOperation.Text = "";
            cbBankAccounting.Text = "";
            bAddBond_Click(sender, e);
            if (rbAfter.Checked)
            {
                epInformation.SetError((Control)sender, "لم تكتمل");
            }
            else
            {
                epInformation.SetError((Control)sender, "");
            }
        }

        private void rbPaperReceived_CheckedChanged(object sender, EventArgs e)
        {
            cbTypeOperation.Enabled = false;
            cbBankAccounting.Enabled = false;
            cbTypeOperation.Text = "";
            cbBankAccounting.Text = "";
            bAddBond_Click(sender, e);
            if (rbPaperReceived.Checked)
            {
                epInformation.SetError((Control)sender, "تم الدفع عن طريق كمبيالة قبض ");
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
                //bAddBond_Click(sender, e);
            }
            else
            {
                cbBankAccounting.Enabled = false;
                //bAddBond_Click(sender, e);
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
            return value;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtCustomer.Text = "";
            txtTotalPrice.Text = "";
            txtDiscount.Text = "";
            totalPriceValue = 0;
            totalDiscountValue = 0;
            dtpSaleDate.Value = DateTime.Now;
            dtpBillDate.Value = DateTime.Now;
            countMaterial = 0;
           // indexMaterialdebit = 0;
            materialList.Clear();

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
                dataGridViewMaterial.Rows[i].Cells[8].Value = "";
                dataGridViewMaterial.Rows[i].Cells[9].Value = "";
                dataGridViewMaterial.Rows[i].Cells[10].Value = "";
            }

            gbBonds.Text = "قيد العملية";
            gbBonds.ForeColor = Color.Black;

            for (int i = 0; i <= 4; i++)
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";
                bc.comment = "";

                //bcList.Add(bc);
                dataGridViewBond1.Rows[i].Cells[0].Value = bc.balance;
                dataGridViewBond1.Rows[i].Cells[1].Value = bc.bondFrom;
                dataGridViewBond1.Rows[i].Cells[2].Value = bc.bondTo;
                dataGridViewBond1.Rows[i].Cells[3].Value = "";
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
                    Console.WriteLine("id: " + txtCustomer.Text.Split('.')[1]);
                }
            }
            catch (Exception ex)
            {

            }
        }

        int indexMaterialdebit = 0;
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


        static bool isSaveBonds = true;
        private void getReport(int indexValue)
        {
           /* try
            {*/
                rowMaterialdCredit = null;
                txtId.Text = cbIds.Items[indexValue].ToString();
                Guid id = Guid.Parse(rowMaterialdDebit["الرقم"].ToString());
                material_debit_returnTableAdapter mcta = new material_debit_returnTableAdapter();
                MaterialControllar.material_debit_returnDataTable mcdt = mcta.getMaterialDebitById(id);
                rowMaterialdCredit = mcdt.Rows[0];
                txtCustomer.Text = rowMaterialdCredit["من"].ToString().Split('.')[1] + "." + rowMaterialdCredit["من"].ToString().Split('.')[2];
                totalPriceValue = Convert.ToDouble(rowMaterialdCredit["الرصيد"].ToString());
                totalDiscountValue = Convert.ToDouble(rowMaterialdCredit["حسم_مكتسب"].ToString());
                txtTotalPrice.Text = totalPriceValue.ToString();
                txtDiscount.Text = totalDiscountValue.ToString();

                if (rowMaterialdCredit["نوع_العملية"].ToString() == "نقداً")
                {
                    rbCash.Checked = true;
                }
                if (rowMaterialdCredit["نوع_العملية"].ToString() == "لأجل")
                {
                    rbAfter.Checked = true;
                }
                if (rowMaterialdCredit["نوع_العملية"].ToString() == "سند قبض لأجل")
                {
                    rbPaperReceived.Checked = true;
                }
                cbTypeOperation.Text = rowMaterialdCredit["طريقة_الدفع"].ToString();
                cbBankAccounting.Text = rowMaterialdCredit["اسم_الحساب"].ToString();
                dtpSaleDate.Value = Convert.ToDateTime(rowMaterialdCredit["تاريخ"]);
                //txtBiles.Text = rowMaterialdCredit["رقم_فاتورة_المصدر"].ToString();
                //dtpBillDate.Value = Convert.ToDateTime(rowMaterialdCredit["تاريخ_فاتورة_المصدر"]);
                //txtMoreBills.Text = rowMaterialdDebit["مصاريف_مضافة"].ToString();
                //cbMoreBillsOption.Text = rowMaterialdDebit["مصاريف_على_حساب"].ToString();
                isSaveBonds = Convert.ToBoolean(rowMaterialdCredit["مرحل"]);

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

                material_debit_list_returnTableAdapter mclta = new material_debit_list_returnTableAdapter();
                MaterialControllar.material_debit_list_returnDataTable mcldt = mclta.getMaterialDebitReport(id);

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
                    dataGridViewMaterial.Rows[i].Cells[8].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[9].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[10].Value = "";
                }
                int count = 0;
                materialList.Clear();
                double material_cost = 0;
                foreach (DataRow dr in mcldt)
                {
                    try
                    {
                        materialTableAdapter mta1 = new materialTableAdapter();
                        MaterialControllar.materialDataTable material = mta1.getMaterialById(Guid.Parse(dr["الرقم_الفني"].ToString()));

                        dataGridViewMaterial.Rows[count].Cells[0].Value = dr["رقم_المادة"];
                        dataGridViewMaterial.Rows[count].Cells[1].Value = dr["اسم_المادة"];
                        dataGridViewMaterial.Rows[count].Cells[2].Value = dr["الكمية"];
                        dataGridViewMaterial.Rows[count].Cells[3].Value = dr["السعر"];
                        dataGridViewMaterial.Rows[count].Cells[4].Value = Convert.ToInt32((Convert.ToDouble(dr["حسم_مكتسب"]) / Convert.ToDouble(dr["السعر_الجمالي"])) * 100);
                        dataGridViewMaterial.Rows[count].Cells[5].Value = dr["حسم_مكتسب"];
                        dataGridViewMaterial.Rows[count].Cells[6].Value = dr["السعر_الجمالي"];
                        dataGridViewMaterial.Rows[count].Cells[7].Value = dr["ملاحظات"];
                        material_cost = Convert.ToDouble(dr["الكلفة"]) / Convert.ToDouble(dr["الكمية"]);

                        dataGridViewMaterial.Rows[count].Cells[8].Value = Convert.ToInt32(Convert.ToDouble(dr["الكلفة"]) / Convert.ToDouble(dr["الكمية"])).ToString();
                        dataGridViewMaterial.Rows[count].Cells[9].Value = (material_cost * Convert.ToDouble(dr["الكمية"])).ToString();
                        dataGridViewMaterial.Rows[count].Cells[10].Value = ((Convert.ToDouble(dr["السعر"]) * Convert.ToDouble(dr["الكمية"])) - (material_cost * Convert.ToDouble(dr["الكمية"]))).ToString();

                        count++;
                        material.Rows[0]["كمية"] = dr["الكمية"];
                        materialList.Add(material.Rows[0]);
                    }
                    catch (Exception) { }
                }

           /* }
            catch (Exception)
            {

            }*/
        }

        
        private void getReportBuyBills(int indexValue)
        {
           /* try
            {*/
                material_creditTableAdapter mcta = new material_creditTableAdapter();
                MaterialControllar.material_creditDataTable mcdt = mcta.getMaterialCreditById(indexValue);
                rowMaterialdCredit = mcdt.Rows[0];

                idPaperReceived = Convert.ToInt32(rowMaterialdCredit["سند_القبض"]);
                txtCustomer.Text = rowMaterialdCredit["إلى"].ToString().Split('.')[1] + "." + rowMaterialdCredit["إلى"].ToString().Split('.')[2];
                totalPriceValue = Convert.ToDouble(rowMaterialdCredit["الرصيد"].ToString());
                txtTotalPrice.Text = rowMaterialdCredit["الرصيد"].ToString();
                txtDiscount.Text = "0";
                totalDiscountValue = 0;
                if (rowMaterialdCredit["نوع_العملية"].ToString() == "نقداً")
                {
                    rbCash.Checked = true;
                }
                if (rowMaterialdCredit["نوع_العملية"].ToString() == "لأجل")
                {
                    rbAfter.Checked = true;
                }
                if (rowMaterialdCredit["نوع_العملية"].ToString() == "سند قبض لأجل")
                {
                    rbPaperReceived.Checked = true;
                }
                dtpBillDate.Value = Convert.ToDateTime(rowMaterialdCredit["تاريخ_البيع"]);

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
                    dataGridViewMaterial.Rows[i].Cells[8].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[9].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[10].Value = "";
                } 
            
                materialList.Clear();
                int count = 0;
                int totle_Price = 0;

                material_credit_listTableAdapter mclta = new material_credit_listTableAdapter();
                MaterialControllar.material_credit_listDataTable mcldt = mclta.getMaterialCreditReport(indexValue);

                materialTableAdapter mta1;
                double material_cost = 0;
                foreach (DataRow dr in mcldt)
                {
                    mta1 = new materialTableAdapter();
                    MaterialControllar.materialDataTable material = mta1.getMaterialById(Guid.Parse(dr["الرقم_الفني"].ToString()));

                    dataGridViewMaterial.Rows[count].Cells[0].Value = dr["رقم_المادة"];
                    dataGridViewMaterial.Rows[count].Cells[1].Value = dr["اسم_المادة"];
                    dataGridViewMaterial.Rows[count].Cells[2].Value = dr["الكمية"];
                    dataGridViewMaterial.Rows[count].Cells[3].Value = dr["السعر"];
                    dataGridViewMaterial.Rows[count].Cells[4].Value = 0;
                    dataGridViewMaterial.Rows[count].Cells[5].Value = 0;
                    dataGridViewMaterial.Rows[count].Cells[6].Value = dr["السعر_الجمالي"];
                    dataGridViewMaterial.Rows[count].Cells[7].Value = "";
                    material_cost = Convert.ToDouble(dr["الكلفة"]) / Convert.ToDouble(dr["الكمية"]);

                    dataGridViewMaterial.Rows[count].Cells[8].Value =Convert.ToInt32(Convert.ToDouble(dr["الكلفة"]) / Convert.ToDouble(dr["الكمية"])).ToString();
                    dataGridViewMaterial.Rows[count].Cells[9].Value = (material_cost * Convert.ToDouble(dr["الكمية"])).ToString();
                    dataGridViewMaterial.Rows[count].Cells[10].Value = ((Convert.ToDouble(dr["السعر"]) * Convert.ToDouble(dr["الكمية"])) - (material_cost * Convert.ToDouble(dr["الكمية"]))).ToString();


                    totle_Price += Convert.ToInt32(dr["السعر_الجمالي"]);
                    dataGridViewMaterial.Rows[count].Cells[7].Value = dr["ملاحظات"];

                    DataRow mr = material.Rows[0];
                    mr["TotalValue"] = dr["السعر_الجمالي"];
                    mr["سعر_الشراء"] = material_cost;
                    mr["كمية"] = dr["الكمية"];
                    materialList.Add(mr);
                    count++;
                }
            /*}
            catch (Exception ex)
            {
            }*/
        }

        private void clearMaterialTable()
        {
           
        }

        static DataRow rowMaterialdCredit;
        private void getReportBills(int indexValue)
        {
            try
            {
                Guid id = indexValue;
                material_debitTableAdapter mcta = new material_debitTableAdapter();
                MaterialControllar.material_debitDataTable mcdt = mcta.getMaterialDebitById(id);
                rowMaterialdCredit = mcdt.Rows[0];

                txtCustomer.Text = rowMaterialdCredit["من"].ToString().Split('.')[1] + "." + rowMaterialdCredit["من"].ToString().Split('.')[2];
                txtTotalPrice.Text = rowMaterialdCredit["الرصيد"].ToString();
                totalPriceValue = Convert.ToDouble(txtTotalPrice.Text);
                txtDiscount.Text = rowMaterialdCredit["حسم_مكتسب"].ToString();
                totalDiscountValue = Convert.ToDouble(txtDiscount.Text);

                if (rowMaterialdCredit["نوع_العملية"].ToString() == "نقداً")
                {
                    rbCash.Checked = true;

                }
                if (rowMaterialdCredit["نوع_العملية"].ToString() == "لأجل")
                {
                    rbAfter.Checked = true;
                }
                cbTypeOperation.Text = rowMaterialdCredit["طريقة_الدفع"].ToString();
                cbBankAccounting.Text = rowMaterialdCredit["اسم_الحساب"].ToString();
                dtpSaleDate.Value = Convert.ToDateTime(rowMaterialdCredit["تاريخ"]);
                isSaveBonds = Convert.ToBoolean(rowMaterialdCredit["مرحل"]);

                if (isSaveBonds)
                {
                    gbBonds.Text = "تم ترحيل قيد العملية";
                    // gbBonds.ForeColor = Color.Green;

                }
                if (!isSaveBonds)
                {
                    gbBonds.Text = "لم يتم ترحيل قيد العملية";
                    // gbBonds.ForeColor = Color.Red;
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
                    MaterialControllar.materialDataTable material = mta1.getMaterialById(Guid.Parse(dr["الرقم_الفني"].ToString()));

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
            catch (Exception ex)
            {

            }
        }


        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            bAddBond_Click(sender, e);
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            bAddBond_Click(sender, e);
        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Guid id = Convert.ToInt32(txtCustomer.Text.Split('.')[1]);
                customerTableAdapter cta = new customerTableAdapter();
                CustomerControllar.customerDataTable cdt = cta.getCustomerById(id);
                CustomerControllar.customerRow cr = cdt[0];

                txtCustomerBalance.Text = cr["الرصيد"].ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            ReturnSaleBills rsb = new ReturnSaleBills();
            rsb.ShowDialog();
        }

        private void bHide_Click(object sender, EventArgs e)
        {
            gbBonds.Hide();

        }

        private void bShow_Click(object sender, EventArgs e)
        {
            gbBonds.Show();

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bMaterialCard_Click(object sender, EventArgs e)
        {
            NewMaterial nm = new NewMaterial();
            nm.MdiParent = Main.ActiveForm;
            nm.LayoutMdi(MdiLayout.ArrangeIcons);
            nm.Show();
        }

        private void bSaveAll_Click(object sender, EventArgs e)
        {
            if (SaveReturnBuy)
            {
                if (MessageBox.Show("هل تريد حفط التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    material_debit_returnTableAdapter mcta = new material_debit_returnTableAdapter();

                    /**/
                    mcta.Insert(dtpSaleDate.Value,
                    totalPriceValue,
                    "مورد." + txtCustomer.Text,
                    nte.changeNumericToWords(totalPriceValue),
                    Convert.ToInt32(txtBiles.Text),
                    dtpBillDate.Value,
                    "",
                    "",
                    Convert.ToInt32(txtCustomer.Text.Split('.')[1]),
                    "",
                    getType(),
                    Convert.ToDouble(totalDiscountValue),
                    0.0,
                    "",
                    true.ToString(),
                    cbTypeOperation.Text,
                    cbBankAccounting.Text,
                    totalCostValue);

                    Guid id = Convert.ToInt32(mcta.getMaxMaterialDebit());
                    material_debit_list_returnTableAdapter mclrta = new material_debit_list_returnTableAdapter();
                    materialTableAdapter mta = new materialTableAdapter();

                    //to delete the row from seles materila list
                    material_credit_listTableAdapter mclta = new material_credit_listTableAdapter();

                    //to add new Row to calculate the fifo or lifo or avg
                    material_costTableAdapter mcta_cost = new material_costTableAdapter();
                    foreach (DataRow row in materialList)
                    {
                        try
                        {
                            double totalvalue = Convert.ToDouble(row["TotalValue"]);
                            double discount = Convert.ToDouble(row["Discount"]);

                            mclrta.Insert(Guid.Parse(row["الرقم_الفني"].ToString()),
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
                                discount ,
                                Convert.ToInt32(row["سعر_الشراء"].ToString()),
                                Convert.ToDouble(row["TotalCost"].ToString()));


                            mcta_cost.Insert(Guid.Parse(row["الرقم_الفني"].ToString()),
                              Convert.ToInt32(row["سعر_الشراء"].ToString()),
                              Convert.ToInt32(row["كمية"].ToString()),
                              DateTime.Now,
                              id);
                           // mclta.DeleteQuery(Guid.Parse(row["الرقم_الفني"].ToString()), Convert.ToInt32(txtBiles.Text));
                            int quantity = Convert.ToInt32(mta.getMaterialById(Guid.Parse(row["الرقم_الفني"].ToString()))[0]["كمية"]);
                            mta.UpdateMaterialQuantity((quantity + Convert.ToInt32(row["كمية"])),
                                Guid.Parse(row["الرقم_الفني"].ToString()));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("لم يتم إضافة " + row["اسم_المادة"].ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    setBond1().SaveBonds();
                    setBond2().SaveBonds();
                    setBond3().SaveBonds();
                    setBond4().SaveBonds();

                    getReportId();
                    MessageBox.Show("تم إضافة التقرير", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnSaleBills rsb = new ReturnSaleBills();
                    rsb.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("هناك خطأ في الأرصدة لا يمكن إتمام العملية", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bSaveCard_Click(object sender, EventArgs e)
        {
            if (SaveReturnBuy)
            {
                if (MessageBox.Show("هل تريد حفط التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    material_debit_returnTableAdapter mcta = new material_debit_returnTableAdapter();

                    /**/
                    mcta.Insert(dtpSaleDate.Value,
                    totalPriceValue,
                    "مورد." + txtCustomer.Text,
                    nte.changeNumericToWords(totalPriceValue),
                    Convert.ToInt32(txtBiles.Text),
                    dtpBillDate.Value,
                    "",
                    "",
                    Convert.ToInt32(txtCustomer.Text.Split('.')[1]),
                    "",
                    getType(),
                    Convert.ToDouble(totalDiscountValue),
                    0,
                    "",
                    true.ToString(),
                    cbTypeOperation.Text,
                    cbBankAccounting.Text,
                    totalCostValue);

                    Guid id = Convert.ToInt32(mcta.getMaxMaterialDebit());
                    material_debit_list_returnTableAdapter mclta = new material_debit_list_returnTableAdapter();
                    materialTableAdapter mta = new materialTableAdapter();

                    material_costTableAdapter mcta_cost = new material_costTableAdapter();
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
                                Convert.ToInt32(row["سعر"].ToString()),
                                totalvalue + discount,
                                row["Comment"].ToString(),
                                0,
                                nte.changeNumericToWords(Convert.ToInt32(row["كمية"].ToString())),
                                "",
                                discount,
                                    Convert.ToInt32(row["سعر_الشراء"].ToString()),
                                    Convert.ToDouble(row["TotalCost"].ToString()));

                            mcta_cost.Insert(Guid.Parse(row["الرقم_الفني"].ToString()),
                              Convert.ToInt32(row["سعر_الشراء"].ToString()),
                              Convert.ToInt32(row["كمية"].ToString()),
                              DateTime.Now,
                               0);

                            int quantity = Convert.ToInt32(mta.getMaterialById(Guid.Parse(row["الرقم_الفني"].ToString()))[0]["كمية"]);

                            mta.UpdateMaterialQuantity((quantity - Convert.ToInt32(row["كمية"])),
                                Guid.Parse(row["الرقم_الفني"].ToString()));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("لم يتم إضافة " + row["اسم_المادة"].ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    getReportId();
                    MessageBox.Show("  تم إضافة التقرير  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnSaleBills rsb = new ReturnSaleBills();
                    rsb.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("هناك خطأ في الأرصدة لا يمكن إتمام العملية", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bSaveBonds_Click(object sender, EventArgs e)
        {
            if (isSaveBonds)
            {
                MessageBox.Show("لقد تم ترحيل القيود مسبقاً! ", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (SaveReturnBuy)
                {
                    if (MessageBox.Show("هل تريد ترحيل قيود الإدخال ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        setBond1().SaveBonds();
                        setBond2().SaveBonds();
                        setBond3().SaveBonds();
                        setBond4().SaveBonds();


                        rowMaterialdCredit["مرحل"] = true.ToString();
                        material_debitTableAdapter mcta = new material_debitTableAdapter();
                        mcta.Update(rowMaterialdCredit);


                        material_costTableAdapter mcta_cost = new material_costTableAdapter();
                        foreach (DataRow row in materialList)
                        {
                            mcta_cost.Insert(Guid.Parse(row["الرقم_الفني"].ToString()),
                            Convert.ToInt32(row["سعر_الشراء"].ToString()),
                            Convert.ToInt32(row["كمية"].ToString()),
                            DateTime.Now,
                             0);
                        }
                        MessageBox.Show("لقد تم ترحيل القيود ! ", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void bDeleteBills_Click(object sender, EventArgs e)
        {
            if (isSaveBonds)
            {
                MessageBox.Show("لا يمكن حذف قسيمة الإدخال تم تثبيت القيود", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("هل تريد حذف التقرير؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    materialTableAdapter mta = new materialTableAdapter();
                    foreach (DataRow row in materialList)
                    {
                        materialTableAdapter mta1 = new materialTableAdapter();
                        MaterialControllar.materialDataTable material = mta1.getMaterialById(Convert.ToInt32(row["رقم_المادة"]));

                        mta.UpdateMaterialQuantity((Convert.ToInt32(material.Rows[0]["كمية"]) + Convert.ToInt32(row["كمية"])),
                        Guid.Parse(row["الرقم_الفني"].ToString()));

                    }
                    Guid id = Convert.ToInt32(rowMaterialdCredit["الرقم"]);
                    material_debit_returnTableAdapter mdta = new material_debit_returnTableAdapter();
                    material_debit_list_returnTableAdapter mdlta = new material_debit_list_returnTableAdapter();
                    mdlta.DeleteMaterialDebitList(id);
                    mdta.DeleteMaterialDebit(id);
                    newToolStripButton_Click(sender, e);
                    MessageBox.Show("تم حذف تقرير شراء البضاعة", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void txtBiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    bGetReport_Click(sender, e);     
                }
                catch (Exception ex)
                {

                }
            }
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
            txtMaterialSearch.Text = data.Trim();
        }

        private void ReturnSale_FormClosed(object sender, FormClosedEventArgs e)
        {
            materialList.Clear();
        }

        private void txtBiles_TextChanged_1(object sender, EventArgs e)
        {
            if (txtBiles.Text!="")
            {
                epInformation2.SetError((Control)sender, "قم بإدخال رقم فاتورة البيع");
            }
            else
            {
                epInformation2.SetError((Control)sender, "");
            }
        }

        private void bGetReport_Click(object sender, EventArgs e)
        {
            getReportBuyBills(Convert.ToInt32(txtBiles.Text));
            bAddBond_Click(sender, e);
            try
            {
                
            }
            catch (Exception ex)
            {

            }
        }

        private void txtBiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            bGetReport_Click(sender, e);
        }

        private void bFirst_Click(object sender, EventArgs e)
        {
            getReport(cbIds.Items.Count - 1);
        }

        private void bLast_Click(object sender, EventArgs e)
        {
            getReport(0);
        }

        private void dataGridViewMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                bRemoveMaterial_Click(sender, e);
            }
        }

        

        

    }
}
