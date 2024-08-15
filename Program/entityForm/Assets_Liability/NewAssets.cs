using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Num2Wrd;
using Program.entity.controllar;
using Program.entity.controllar.AssetControllarTableAdapters;
using Program.entity.controllar.BankControllarTableAdapters;
using Program.entity.controllar.BoxControllarTableAdapters;
using Program.entity.controllar.CompanyControllarTableAdapters;
using Program.entity.controllar.CustomerControllarTableAdapters;
using Program.entity.controllar.PaperPayControllarTableAdapters;
using Program.entity.controllar.SupplierControllarTableAdapters;
using Program.entityForm.Supplier.Report;

namespace Program.entityForm.Assets
{
    public partial class NewAssets : Form
    {
        public NewAssets()
        {
            InitializeComponent();
            getBondsAutocomplete();
            getBankAccounting();
            getSupplierNameAutocomplete();
            getAssetNameAutocomplete();
            dataGridViewBond.RowCount = 5;
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

        public void getAssetNameAutocomplete()
        {
            assetTableAdapter ata = new assetTableAdapter();
            AssetControllar.assetDataTable adt = ata.GetData();
            string[] array = new string[adt.Rows.Count];
            int count = 0;
            foreach (DataRow row in adt.Rows)
            {
                array[count] = row["اسم_الأصل"].ToString() + "." + row["الرقم"].ToString();
                count++;
            }
            cbAssets.AutoCompleteCustomSource.AddRange(array);
            cbAssets.Items.AddRange(array);
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

        public void getBondsAutocomplete()
        {
            customerTableAdapter cta = new customerTableAdapter();
            entity.controllar.CustomerControllar.customerDataTable cdt = cta.GetData();
            ArrayList array = new ArrayList();
            foreach (DataRow row in cdt.Rows)
            {
                array.Add("زبون." + row["اسم_الربون"].ToString() + "." + row["الرقم"].ToString());
            }

            boxTableAdapter bta = new boxTableAdapter();
            BoxControllar.boxDataTable bdt = bta.GetData();
            foreach (DataRow row in bdt.Rows)
            {
                array.Add("صندوق." + row["اسم_الصندوق"].ToString() + "." + row["الرقم"].ToString());
            }

            bank_accountTableAdapter bata = new bank_accountTableAdapter();
            BankControllar.bank_accountDataTable badt = bata.GetData();
            foreach (DataRow row in badt.Rows)
            {
                array.Add("مصرف." + row["اسم_الحساب"].ToString() + "." + row["الرقم"].ToString());
            }

            supplierTableAdapter sta = new supplierTableAdapter();
            SupplierControllar.supplierDataTable sdt = sta.GetData();

            foreach (DataRow row in sdt.Rows)
            {
                array.Add("مورد." + row["اسم_المورد"].ToString() + "." + row["الرقم"].ToString());
            }

            txtCreditBond.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtDibetBond.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtCreditBond.Items.AddRange(array.ToArray());
            txtDibetBond.Items.AddRange(array.ToArray());
        }

        private void NewAssets_Load(object sender, EventArgs e)
        {
            assetTableAdapter ata = new assetTableAdapter();
            dataGridViewAssets.DataSource = ata.GetData();
            dataGridViewAssets.Columns["الرصيد_كتابة"].Visible = false;
            dataGridViewAssets.Columns["اسم_الأصل"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewAssets.Columns["تاريخ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewAssets.Columns["نوع_الأصل"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridViewAssets.DataSource = ata.GetData();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtAssetName.Text = "";
            cbAssetType.Text = "";
            txtSupplier.Text = "";
            txtTotalPrice.Text = "0";
            txtTruchPresent.Text = "0";

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
                dataGridViewBond.Rows[i].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[i].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[i].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[i].Cells[3].Value = bc.comment;
            }
        }

        private NumberToEnglish nte = new NumberToEnglish();

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (SaveBuy)
            {
                if (MessageBox.Show("هل تريد حفط الأصل ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    assetTableAdapter ata = new assetTableAdapter();
                    ata.Insert(txtAssetName.Text,
                        0,
                        nte.changeNumericToWords(0),
                        DateTime.Now,
                        cbAssetType.Text,
                        Convert.ToInt32(txtTruchPresent.Text),
                        Convert.ToInt32(txtTruchValue.Text),
                        0);

                    if (rbPaperPay.Checked)
                    {
                        companyTableAdapter cta = new companyTableAdapter();
                        CompanyControllar.companyDataTable cdt = cta.GetData();
                        DataRow company = cdt.Rows[0];
                        paper_payTableAdapter prta = new paper_payTableAdapter();
                        prta.Insert(0, "", DateTime.Now, dtpPaperRecieved.Value, txtCreditBond.Text, company["name"].ToString());
                    }

                    setBond1().SaveBonds();
                    setBond2().SaveBonds();
                    setBond3().SaveBonds();

                    MessageBox.Show("تم إضافة الأصل", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NewAssets_Load(sender, e);
                    newToolStripButton_Click(sender, e);
                    if (rbCash.Checked)
                    {
                        if (MessageBox.Show("هل تريد استعراض أمر الدفع ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            if (cbTypeOperation.Text == "كاش")
                            {
                                PayBills pb = new PayBills();
                                pb.ShowDialog();
                            }
                            if (cbTypeOperation.Text == "شيك")
                            {
                                PayCheck pc = new PayCheck();
                                pc.ShowDialog();
                            }
                        }
                    }
                    if (rbPaperPay.Checked)
                    {
                        if (MessageBox.Show("هل تريد استعراض سند الدفع ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("هناك خطأ بالأرصدة", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bAddBond_Click(object sender, EventArgs e)
        {
            setBond1();
            setBond2();
            setBond3();
        }

        private static double totalPriceValue = 0;
        private BondControllar bc;
        private List<BondControllar> bcList = new List<BondControllar>();

        private BondControllar setBond1()
        {
            assetTableAdapter ata = new assetTableAdapter();
            if (totalPriceValue > 0)
            {
                bc = new BondControllar();

                bc.balance = totalPriceValue;
                bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                bc.bondFrom = "أصل." + txtAssetName.Text + "." + (Convert.ToInt32(ata.getMaxId()));
                bc.bondTo = txtCreditBond.Text;
                bc.comment = "شراء " + txtAssetName.Text + " من المورد " + txtSupplier.Text;
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
            assetTableAdapter ata = new assetTableAdapter();
            if (rbCash.Checked)
            {
                if (totalPriceValue > 0 && cbTypeOperation.Text == "كاش")
                {
                    bc = new BondControllar();

                    bc.balance = totalPriceValue;
                    bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    bc.bondFrom = txtCreditBond.Text;
                    bc.bondTo = "صندوق.صندوق اليومية.1";
                    bc.comment = "دفع قيمة " + txtAssetName.Text + " عن طريق نقداً";

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[1].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[1].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[1].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[1].Cells[3].Value = bc.comment;
                    SaveBuy = CheckBondsError("to", 1);
                }
                if (totalPriceValue > 0 && cbTypeOperation.Text == "شيك")
                {
                    bc = new BondControllar();

                    bc.balance = totalPriceValue;
                    bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    bc.bondFrom = txtCreditBond.Text;
                    bc.bondTo = "مصرف." + cbBankAccounting.Text;
                    bc.comment = "دفع قيمة " + txtAssetName.Text + "عن طريق " + cbBankAccounting.Text;

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[1].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[1].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[1].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[1].Cells[3].Value = bc.comment;
                    SaveBuy = CheckBondsError("to", 1);
                }
            }
            if (!rbCash.Checked)
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
                SaveBuy = CheckBondsError("to", 1);
            }
            return bc;
        }

        private BondControllar setBond3()
        {
            if (rbPaperPay.Checked)
            {
                if (totalPriceValue > 0)
                {
                    bc = new BondControllar();
                    bc.balance = totalPriceValue;
                    bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    bc.bondFrom = txtCreditBond.Text;
                    bc.bondTo = "سند دفع." + txtCreditBond.Text.Split('.')[0] + "." + (idPaperPay);
                    bc.comment = "تقديم للمورد  " + txtCreditBond.Text + " كمبيالة (سند دفع) يستحق بتاريخ " + dtpPaperRecieved.Value;

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[2].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[2].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[2].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[2].Cells[3].Value = bc.comment;
                }
            }
            if (!rbPaperPay.Checked)
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
                dataGridViewBond.Rows[2].Cells[3].Value = bc.comment;
            }
            return bc;
        }

        private static bool SaveBuy = true;
        private static string[] IsBondTrested = new string[2];

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

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalPrice.Text == "")
            {
                txtTotalPrice.Text = "0";
            }
            totalPriceValue = Convert.ToDouble(txtTotalPrice.Text);
            bAddBond_Click(sender, e);
        }

        private void txtAssetName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception ex)
            {
            }
        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
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
            catch (Exception ex)
            {
            }
        }

        private void rbAfter_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbTypeOperation.Enabled = false;
                cbBankAccounting.Enabled = false;
                dtpPaperRecieved.Enabled = false;
                cbTypeOperation.Text = "";
                cbBankAccounting.Text = "";
                bAddBond_Click(sender, e);
                if (rbAfter.Checked)
                {
                    epInformation.SetError((Control)sender, "تأجيل دفع قيمة الأصل لفترة و تحميلها للحساب الدائن");
                }
                else
                {
                    epInformation.SetError((Control)sender, "");
                }
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

        private void txtSupplier_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtCreditBond.Text = "مورد." + txtSupplier.Text;
                bAddBond_Click(sender, e);
            }
            catch (Exception ex)
            {
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

        private void cbAssets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                bRefresh_Click(sender, e);
            }
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Guid id = Convert.ToInt32(cbAssets.Text.Split('.')[1]);
                assetTableAdapter ata = new assetTableAdapter();
                dataGridViewAssets.DataSource = ata.getAssetById(id);
            }
            catch (Exception ex)
            {
            }
        }

        private void txtCreditBond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    bAddBond_Click(sender, e);
                }
                catch (Exception ex)
                {
                }
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

        private void txtAssetName_Validating(object sender, CancelEventArgs e)
        {
            if (txtAssetName.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل اسم الأصل فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void cbAssetType_Validating(object sender, CancelEventArgs e)
        {
            if (cbAssetType.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل نوع الأصل فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private static Guid idPaperPay ;

        private void rbPaperReceived_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtpPaperRecieved.Enabled = true;
                cbTypeOperation.Enabled = false;
                cbBankAccounting.Enabled = false;
                cbTypeOperation.Text = "";
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
            catch (Exception ex)
            {
            }
        }

        private void rbCash_Validating(object sender, CancelEventArgs e)
        {
        }

        private void rbAfter_Validating(object sender, CancelEventArgs e)
        {
        }

        private void rbPaperReceived_Validating(object sender, CancelEventArgs e)
        {
        }

        private void miPayBillsCash_Click(object sender, EventArgs e)
        {
            PayBills pb = new PayBills();
            pb.ShowDialog();
        }

        private void miPayBillsCheck_Click(object sender, EventArgs e)
        {
            PayCheck pc = new PayCheck();
            pc.ShowDialog();
        }
    }
}