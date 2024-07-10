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
using Program.entity.controllar.SupplierControllarTableAdapters;
using Program.entityForm.Supplier.Report;

namespace Program.entityForm.customer
{
    public partial class ReturnBuy : Form
    {
        public ReturnBuy()
        {
            InitializeComponent();
            getReportId();
            dataGridViewMaterial.RowCount = 20;
            dataGridViewBond1.RowCount = 5;
            getCustomerNameAutocomplete();
            getMaterialNameAutocomplete();
            getBankAccounting();
            
            getReportBuyId();
        }

        private void ReturnBuy_Load(object sender, EventArgs e)
        {
            getReportId();

        }

        private void getReportId()
        {
            material_credit_returnTableAdapter mcta = new material_credit_returnTableAdapter();
            MaterialControllar.material_credit_returnDataTable mcdt = mcta.GetData();
            cbIds.Items.Clear();
            foreach (DataRow dr in mcdt.Rows)
            {
                cbIds.Items.Add(dr["الرقم"]);
            }
        }

        private void getBankAccounting()
        {
            try
            {
                bank_accountTableAdapter bata = new bank_accountTableAdapter();
                BankControllar.bank_accountDataTable badt = bata.GetData();
                foreach (DataRow dr in badt.Rows)
                {
                    cbBankAccounting.Items.Add(dr["اسم_الحساب"] + "." + dr["الرقم"]);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void getCustomerNameAutocomplete()
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
            txtCustomer.AutoCompleteCustomSource.AddRange(array);
        }

        public void getMaterialNameAutocomplete()
        {
            materialTableAdapter mta = new materialTableAdapter();
            MaterialControllar.materialDataTable mdt = mta.GetData();
            string[] array = new string[mdt.Rows.Count];
            int count = 0;
            foreach (DataRow row in mdt.Rows)
            {
                array[count] = row["اسم_المادة"].ToString();
                count++;
            }
            txtMaterialSearch.AutoCompleteCustomSource.AddRange(array);
        }

        private void Sale_Resize(object sender, EventArgs e)
        {
        }

        private void txtCustomer_Validating(object sender, CancelEventArgs e)
        {
            if (txtCustomer.Text == "")
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
                    bc.bondFrom = "مورد." + txtCustomer.Text;
                    bc.bondTo = "مردودات مشتريات." + (Convert.ToInt32(mcta.getMaxMaterialCredit()) + 1); 

                    //bcList.Add(bc);
                    dataGridViewBond1.Rows[0].Cells[0].Value = bc.balance;
                    dataGridViewBond1.Rows[0].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond1.Rows[0].Cells[2].Value = bc.bondTo;
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
                bc.bondTo = "مورد." + txtCustomer.Text;

                //bcList.Add(bc);
                dataGridViewBond1.Rows[1].Cells[0].Value = bc.balance;
                dataGridViewBond1.Rows[1].Cells[1].Value = bc.bondFrom;
                dataGridViewBond1.Rows[1].Cells[2].Value = bc.bondTo;
            }
            else
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";

                //bcList.Add(bc);
                dataGridViewBond1.Rows[1].Cells[0].Value = bc.balance;
                dataGridViewBond1.Rows[1].Cells[1].Value = bc.bondFrom;
                dataGridViewBond1.Rows[1].Cells[2].Value = bc.bondTo;
            }
           
            return bc;
        }

        private BondControllar setBond3()
        {
            if (rbCash.Checked)
            {
                if (totalPriceValue > 0&&cbTypeOperation.Text=="كاش")
                {
                    bc = new BondControllar();

                    bc.balance = totalPriceValue;
                    bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    bc.bondFrom = "صندوق.صندوق اليومية.1";
                    bc.bondTo = "مورد." + txtCustomer.Text;
                    
                    //bcList.Add(bc);
                    dataGridViewBond1.Rows[2].Cells[0].Value = bc.balance;
                    dataGridViewBond1.Rows[2].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond1.Rows[2].Cells[2].Value = bc.bondTo;
                }
                if (totalPriceValue > 0 && cbTypeOperation.Text == "شيك")
                {
                    bc = new BondControllar();

                    bc.balance = totalPriceValue;
                    bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    bc.bondFrom = "مصرف."+cbBankAccounting.Text;
                    bc.bondTo = "مورد." + txtCustomer.Text;

                    //bcList.Add(bc);
                    dataGridViewBond1.Rows[2].Cells[0].Value = bc.balance;
                    dataGridViewBond1.Rows[2].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond1.Rows[2].Cells[2].Value = bc.bondTo;
                }
            }
            if (rbAfter.Checked)
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo ="";

                //bcList.Add(bc);
                dataGridViewBond1.Rows[2].Cells[0].Value = bc.balance;
                dataGridViewBond1.Rows[2].Cells[1].Value = bc.bondFrom;
                dataGridViewBond1.Rows[2].Cells[2].Value = bc.bondTo;
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
            cbTypeOperation.Enabled = true;
            cbBankAccounting.Enabled=false;
            bAddBond_Click(sender, e);
        }

        private void rbAfter_CheckedChanged(object sender, EventArgs e)
        {
            cbTypeOperation.Enabled = false;
            cbBankAccounting.Enabled = false;   
            cbTypeOperation.Text = "";
            cbBankAccounting.Text = "";
            bAddBond_Click(sender, e);
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
            return value;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtCustomer.Text = "";
            txtTotalPrice.Text = "";
            txtDiscount.Text = "";

            dtpSaleDate.Value = DateTime.Now;
            dtpReciveDate.Value = DateTime.Now;
            totalPriceValue = 0;
            totalDiscountValue = 0;
            materialList.Clear();
            countMaterial = 0;
            //indexMaterialdebit = 0;
            getReportId();
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

        static bool isSaveBonds = true;
        static int indexMaterialCredit = 0;
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

        static DataRow rowMaterialdCredit;
        private void getReport(int indexValue)
        {
           try
           {
                txtId.Text = cbIds.Items[indexValue].ToString();
                int id = Convert.ToInt32(txtId.Text);
                material_credit_returnTableAdapter mcta = new material_credit_returnTableAdapter();
                MaterialControllar.material_credit_returnDataTable mcdt = mcta.getMaterialCreditById(id);
                rowMaterialdCredit = mcdt.Rows[0];

                txtCustomer.Text = rowMaterialdCredit["إلى"].ToString();
                txtTotalPrice.Text = rowMaterialdCredit["الرصيد"].ToString();
                totalPriceValue = Convert.ToDouble(txtTotalPrice.Text);
                txtDiscount.Text = rowMaterialdCredit["حسم_ممنوح"].ToString();
                totalDiscountValue = Convert.ToDouble(txtDiscount.Text);

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
                    rbPaperPay.Checked = true;
                }
                cbTypeOperation.Text = rowMaterialdCredit["طريقة_الدفع"].ToString();
                cbBankAccounting.Text = rowMaterialdCredit["اسم_الحساب"].ToString();
                dtpSaleDate.Value = Convert.ToDateTime(rowMaterialdCredit["تاريخ_البيع"]);
                dtpReciveDate.Value = Convert.ToDateTime(rowMaterialdCredit["تاريخ_التسليم"]);
                //txtMoreBills.Text = rowMaterialdCredit["مصاريف_مضافة"].ToString();
                //cbMoreBillsOption.Text = rowMaterialdCredit["مصاريف_على_حساب"].ToString();
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
                material_credit_list_returnTableAdapter mclta = new material_credit_list_returnTableAdapter();
                MaterialControllar.material_credit_list_returnDataTable mcldt = mclta.getMaterialCreditReport(id);

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
                    dataGridViewMaterial.Rows[count].Cells[4].Value = Convert.ToInt32((Convert.ToDouble(dr["حسم_ممنوح"]) / Convert.ToDouble(dr["السعر_الجمالي"])) * 100);
                    dataGridViewMaterial.Rows[count].Cells[5].Value = dr["حسم_ممنوح"];
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

        private void txtBiles_TextChanged(object sender, EventArgs e)
        {
            try
            {
                getReportBills(Convert.ToInt32(txtBiles.Text));
                bAddBond_Click(sender, e);
            }
            catch (Exception ex)
            {

            }
        }

        private void getReportBuyId()
        {
            material_debitTableAdapter mcta = new material_debitTableAdapter();
            MaterialControllar.material_debitDataTable mcdt = mcta.GetData();
            cbIds.Items.Clear();
            foreach (DataRow dr in mcdt.Rows)
            {
                txtBiles.Items.Add(dr["الرقم"]);
            }
        }

        private void getReportBills(int indexValue)
        {
            try
            {
                //txtId.Text = cbIds.Items[indexValue].ToString();
                int id = indexValue;
                material_debitTableAdapter mcta = new material_debitTableAdapter();
                MaterialControllar.material_debitDataTable mcdt = mcta.getMaterialDebitById(id);
                rowMaterialdCredit = mcdt.Rows[0];

                txtCustomer.Text = rowMaterialdCredit["من"].ToString().Split('.')[1] + "." + rowMaterialdCredit["من"].ToString().Split('.')[2];
                totalPriceValue = Convert.ToDouble(rowMaterialdCredit["الرصيد"]);
                txtTotalPrice.Text = rowMaterialdCredit["الرصيد"].ToString();
                totalDiscountValue = Convert.ToDouble(rowMaterialdCredit["حسم_مكتسب"]);
                txtDiscount.Text = rowMaterialdCredit["حسم_مكتسب"].ToString();
                
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
            catch (Exception ex)
            {

            }

        }

        private void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtCustomer.Text.Split('.')[1]);
                supplierTableAdapter cta = new supplierTableAdapter();
                SupplierControllar.supplierDataTable cdt = cta.getSupplierById(id);
                SupplierControllar.supplierRow cr = cdt[0];

                txtSupplierBalance.Text = cr["الرصيد"].ToString();
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

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            ReturnBuyBills rbb = new ReturnBuyBills();
            rbb.ShowDialog();
        }

        private void bHide_Click(object sender, EventArgs e)
        {
            gbBonds.Hide();
        }

        private void bShow_Click(object sender, EventArgs e)
        {
            gbBonds.Show();

        }

        private void bSaveAll_Click(object sender, EventArgs e)
        {
            if (SaveBuy)
            {
                if (MessageBox.Show("هل تريد حفط التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    material_credit_returnTableAdapter mcta = new material_credit_returnTableAdapter();

                    mcta.Insert(dtpSaleDate.Value,
                    dtpReciveDate.Value,
                    totalPriceValue,
                    nte.changeNumericToWords(totalPriceValue),
                    "مودر." + txtCustomer.Text,
                    cbTypeOperation.Text,
                    "",
                    Convert.ToInt32(txtCustomer.Text.Split('.')[1]),
                    "",
                    "",
                    getType(),
                    Convert.ToDouble(totalDiscountValue),
                    Convert.ToDouble(0),
                    "",
                    true.ToString(),
                    cbBankAccounting.Text);

                    int id = Convert.ToInt32(mcta.getMaxMaterialCredit());
                    material_credit_list_returnTableAdapter mclta = new material_credit_list_returnTableAdapter();
                    materialTableAdapter mta = new materialTableAdapter();

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
                                Convert.ToInt32(row["سعر"].ToString()),
                                totalvalue + discount,
                                row["Comment"].ToString(),
                                0,
                                nte.changeNumericToWords(Convert.ToInt32(row["كمية"].ToString())),
                                "",
                                discount);

                            int quantity = Convert.ToInt32(mta.getMaterialById(Convert.ToInt32(row["الرقم_الفني"]))[0]["كمية"]);

                            mta.UpdateMaterialQuantity((quantity - Convert.ToInt32(row["كمية"])),
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
                    //setBond4().SaveBonds();

                    //getReportId();
                    newToolStripButton_Click(sender, e);
                    MessageBox.Show("  تم إضافة التقرير  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnBuyBills rbb = new ReturnBuyBills();
                    rbb.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("رصيد النقدية غير كافي", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void bSaveCard_Click(object sender, EventArgs e)
        {
           if (SaveBuy)
            {
                if (MessageBox.Show("هل تريد حفط التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    material_credit_returnTableAdapter mcta = new material_credit_returnTableAdapter();

                    mcta.Insert(dtpSaleDate.Value,
                    dtpReciveDate.Value,
                    totalPriceValue,
                    nte.changeNumericToWords(totalPriceValue),
                    "مودر." + txtCustomer.Text,
                    "",
                    cbTypeOperation.Text,
                    Convert.ToInt32(txtCustomer.Text.Split('.')[1]),
                    "",
                    "",
                    getType(),
                    Convert.ToDouble(totalDiscountValue),
                    Convert.ToDouble(0),
                    "",
                    true.ToString(),
                    cbBankAccounting.Text);

                    int id = Convert.ToInt32(mcta.getMaxMaterialCredit());
                    material_credit_list_returnTableAdapter mclta = new material_credit_list_returnTableAdapter();
                    materialTableAdapter mta = new materialTableAdapter();

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
                                Convert.ToInt32(row["سعر"].ToString()),
                                totalvalue + discount,
                                row["Comment"].ToString(),
                                0,
                                nte.changeNumericToWords(Convert.ToInt32(row["كمية"].ToString())),
                                "",
                                discount);

                            int quantity = Convert.ToInt32(mta.getMaterialById(Convert.ToInt32(row["الرقم_الفني"]))[0]["كمية"]);

                            mta.UpdateMaterialQuantity((quantity - Convert.ToInt32(row["كمية"])),
                                Convert.ToInt32(row["الرقم_الفني"]));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("لم يتم إضافة " + row["اسم_المادة"].ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    getReportId();
                    newToolStripButton_Click(sender, e);
                    MessageBox.Show("  تم إضافة التقرير  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnBuyBills rbb = new ReturnBuyBills();
                    rbb.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("رصيد النقدية غير كافي", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                if (SaveBuy)
                {
                    if (MessageBox.Show("هل تريد ترحيل قيود الإدخال ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        setBond1().SaveBonds();
                        setBond2().SaveBonds();
                        setBond3().SaveBonds();
                        rowMaterialdCredit["مرحل"] = true.ToString();
                        material_credit_list_returnTableAdapter mcta = new material_credit_list_returnTableAdapter();
                        mcta.Update(rowMaterialdCredit);
                        MessageBox.Show("لقد تم ترحيل القيود ! ", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void bMaterialCard_Click(object sender, EventArgs e)
        {
            NewMaterial nm = new NewMaterial();
            nm.MdiParent = Main.ActiveForm;
            nm.LayoutMdi(MdiLayout.ArrangeIcons);
            nm.Show();
        }

        private void bDelete_Click(object sender, EventArgs e)
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
                    int id = Convert.ToInt32(rowMaterialdCredit["الرقم"]);
                    material_credit_returnTableAdapter mdta = new material_credit_returnTableAdapter();
                    material_credit_list_returnTableAdapter mdlta = new material_credit_list_returnTableAdapter();
                    mdlta.DeleteMaterialCreditList(id);
                    mdta.DeleteMaterialCredit(id);
                    newToolStripButton_Click(sender, e);
                    MessageBox.Show("تم حذف تقرير شراء البضاعة", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void ReturnBuy_FormClosed(object sender, FormClosedEventArgs e)
        {
            materialList.Clear();
        }

        private void bGetReport_Click(object sender, EventArgs e)
        {
            try
            {
                getReportBills(Convert.ToInt32(txtBiles.Text));
                bAddBond_Click(sender, e);
            }
            catch (Exception)
            {

            }
        }

        
    }
}
