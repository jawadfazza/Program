using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.SupplierControllarTableAdapters;
using Program.entity.controllar.MaterialControllarTableAdapters;
using Program.entity.controllar;
using Program.entity.controllar.BankControllarTableAdapters;
using Num2Wrd;
using Program.entityForm.Supplier.Report;
using Program.entity.controllar.BondTableAdapters;

namespace Program.entityForm.Supplier
{
    public partial class SupplierPayment : Form
    {
        public SupplierPayment()
        {
            InitializeComponent();
        }

        private void SupplierPayment_Load(object sender, EventArgs e)
        {
            //dataGridViewPayment.RowCount = 20;
            dataGridViewBond.RowCount = 5;
            getSupplierNameAutocomplete();
            getBankAccounting();
            splitContainer1.SplitterDistance = 250;

            dataGridViewPayment.Columns.Add("مدين", "مدين");
            dataGridViewPayment.Columns.Add("دائن", "دائن");
            dataGridViewPayment.Columns["مدين"].DisplayIndex = 0;
            dataGridViewPayment.Columns["دائن"].DisplayIndex = 1;
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
            splitContainer1.SplitterDistance = 250;

        }

        private void bAddBond_Click(object sender, EventArgs e)
        {
            setBond1();
            setBond2();
        }

        BondControllar bc;
        List<BondControllar> bcList = new List<BondControllar>();
        NumberToEnglish nte = new NumberToEnglish();

        static double totalDiscountValue = 0;
        static double totalPriceValue = 0;

        private BondControllar setBond1()
        {
                if (totalPriceValue > 0 && cbTypeOperation.Text=="كاش")
                 {
                     bc = new BondControllar();

                     bc.balance = totalPriceValue;
                     bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                     bc.bondFrom = "مورد." + txtSupplier.Text;
                     bc.bondTo =  "صندوق.صندوق.1";
                     if (txtComent.Text != "")
                     {
                         bc.comment = txtComent.Text;
                     }
                     else
                     {
                         bc.comment = "التسديد نقداً للمورد " + txtSupplier.Text;
                     }
                     //bcList.Add(bc);
                     dataGridViewBond.Rows[0].Cells[0].Value = bc.balance;
                     dataGridViewBond.Rows[0].Cells[1].Value = bc.bondFrom;
                     dataGridViewBond.Rows[0].Cells[2].Value = bc.bondTo;
                     dataGridViewBond.Rows[0].Cells[3].Value = bc.comment;
                 }
                 if (totalPriceValue > 0 && cbTypeOperation.Text == "شيك")
                 {
                     bc = new BondControllar();

                     bc.balance = totalPriceValue;
                     bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                     bc.bondFrom = "مورد." + txtSupplier.Text;
                     bc.bondTo =  "مصرف." + cbBankAccounting.Text;
                     if (txtComent.Text != "")
                     {
                         bc.comment = txtComent.Text;
                     }
                     else
                     {
                         bc.comment = "التسديد بشيك للمورد " + txtSupplier.Text;
                     }
                     //bcList.Add(bc);
                     dataGridViewBond.Rows[0].Cells[0].Value = bc.balance;
                     dataGridViewBond.Rows[0].Cells[1].Value = bc.bondFrom;
                     dataGridViewBond.Rows[0].Cells[2].Value = bc.bondTo;
                     dataGridViewBond.Rows[0].Cells[3].Value = bc.comment;

                 }
                 if (totalPriceValue == 0)
                 {
                     bc = new BondControllar();

                     bc.balance = 0;
                     bc.balanceText = "";
                     bc.bondFrom = "";
                     bc.bondTo = "";
                     bc.comment = "";

                     //bcList.Add(bc);
                     dataGridViewBond.Rows[0].Cells[0].Value = bc.balance;
                     dataGridViewBond.Rows[0].Cells[1].Value = bc.bondFrom;
                     dataGridViewBond.Rows[0].Cells[2].Value = bc.bondTo;
                     dataGridViewBond.Rows[0].Cells[3].Value = "";

                     IsBondTrested[0] = true.ToString();
                 }
                 IsBondTrested[0]=CheckBondsError("both", 0).ToString();

             return bc;
        }


        private BondControllar setBond2()
        {
           /**/ if (totalDiscountValue > 0)
            {
                bc = new BondControllar();

                bc.balance = totalDiscountValue;
                bc.balanceText = nte.changeNumericToWords(totalDiscountValue);
                bc.bondFrom =  "مورد." + txtSupplier.Text;
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
                IsBondTrested[1] = true.ToString();
            }
           SaveBuy = CheckBondsError("both", 1);
           return bc;
        }

        bool SaveBuy = true;
        static string[] IsBondTrested = new string[2];
        public bool CheckBondsError(string dir,int index)
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
                dataGridViewBond.Rows[index].ErrorText +="\n"+ message[1];
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
                //bAddBond_Click(sender, e);
            }
            else
            {
                cbBankAccounting.Enabled = false;
                //bAddBond_Click(sender, e);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (SaveBuy)
            {
                if (MessageBox.Show("هل تريد حفط التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    setBond1().SaveBonds();
                    setBond2().SaveBonds();
                    MessageBox.Show("  تم إضافة التقرير  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
            else
            {
                MessageBox.Show("لا يمكن نجاز العملية هناك خطأ في الارصدة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtSupplierBalance.Text = "";
            txtTotalPrice.Text = "";
            txtDiscount.Text = "";
            //dtpSaleDate.Value = DateTime.Now;
           
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {

        }

        

        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    bAddSupplier_Click(sender, e);
                }
            }
            catch (Exception ex)
            {

            }
        }

        static int id = 0;
        private void bAddSupplier_Click(object sender, EventArgs e)
        {
            Console.WriteLine("id: " + txtSupplier.Text.Split('.')[1]);

            id = Convert.ToInt32(txtSupplier.Text.Split('.')[1]);
            supplierTableAdapter cta = new supplierTableAdapter();
            SupplierControllar.supplierDataTable cdt = cta.getSupplierById(id);
            SupplierControllar.supplierRow cr = cdt[0];

            txtSupplierBalance.Text = cr["الرصيد"].ToString();
            getTableOpeartion();
        }

        private void getTableOpeartion()
        {
            bondsTableAdapter bta = new bondsTableAdapter();
            Bond.bondsDataTable bdt = bta.getSelectBonds("مورد." + txtSupplier.Text, "مورد." + txtSupplier.Text);
            int count = bdt.Rows.Count;

            dataGridViewPayment.DataSource = bdt;
            dataGridViewPayment.Columns["الرصيد"].Visible = false;
            dataGridViewPayment.Columns["الرصيد"].HeaderText = "المبلغ";
            dataGridViewPayment.Columns["الرقم"].Visible = false;
            dataGridViewPayment.Columns["الرصيد_كتابة"].Visible = false;
            dataGridViewPayment.Columns["مرحل"].Visible = false;
            dataGridViewPayment.Columns["من"].HeaderText = "ح/مدين";
            dataGridViewPayment.Columns["من"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewPayment.Columns["إلى"].HeaderText = "ح/دائن";
            dataGridViewPayment.Columns["إلى"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewPayment.Columns["ملاحطات"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewPayment.Columns["تاريخ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            int totalDebit = 0;
            int totalCredit = 0;
            for (int i = 0; i < count; i++)
            {
                String credit = bdt.Rows[i]["إلى"].ToString();
                if (credit.Split('.')[0] == "صندوق" || credit.Split('.')[0] == "مصرف")
                {
                    totalCredit = totalCredit + Convert.ToInt32(bdt.Rows[i]["الرصيد"]);
                    dataGridViewPayment.Rows[i].Cells["دائن"].Value = bdt.Rows[i]["الرصيد"].ToString();
                    dataGridViewPayment.Rows[i].DefaultCellStyle.BackColor = Color.Gold;
                    dataGridViewPayment.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                    dataGridViewPayment.Rows[i].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                }
                else
                {
                    totalDebit = totalDebit + Convert.ToInt32(bdt.Rows[i]["الرصيد"]);
                    dataGridViewPayment.Rows[i].Cells["مدين"].Value = bdt.Rows[i]["الرصيد"].ToString();
                    dataGridViewPayment.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridViewPayment.Rows[i].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Underline);
                }
            }
            //lTotleDebit.Text = "مدين " + totalDebit.ToString();
            //lTotleCredit.Text = "دائن " + totalCredit.ToString();
        }
        public void getPaymentTime()
        {
            try
            {
                int suppler_id = Convert.ToInt32(txtSupplier.Text.Split('.')[1]);
                supplier_PayTimeTableAdapter crtta = new supplier_PayTimeTableAdapter();
                SupplierControllar.supplier_PayTimeDataTable crdta = crtta.GetEarendPayment(suppler_id);

                dataGridViewPaymentTime.DataSource = crdta;

                dataGridViewPaymentTime.Columns["الرصيد"].HeaderText = "المبلغ";
                //dataGridViewPaymentTime.Columns["الرقم"].Visible = false;
                dataGridViewPaymentTime.Columns["Supplier_id"].Visible = false;
                dataGridViewPaymentTime.Columns["الرصيد_كتابة"].Visible = false;
                dataGridViewPaymentTime.Columns["ملاحطات"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewPaymentTime.Columns["تاريخ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                int count = crdta.Rows.Count;
                for (int i = 0; i < count; i++)
                {

                    int balance = Convert.ToInt32(crdta.Rows[i]["الرصيد"]);
                    DateTime date = Convert.ToDateTime(crdta.Rows[i]["تاريخ"]);
                    bool isPay = Convert.ToBoolean(crdta.Rows[i]["تم_الدفع"]);
                    if (isPay == true)
                    {

                    }
                    if (isPay == false)
                    {
                        if (date < DateTime.Now)
                        {
                            dataGridViewPaymentTime.Rows[i].DefaultCellStyle.BackColor = Color.Gold;
                            dataGridViewPaymentTime.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                            dataGridViewPaymentTime.Rows[i].ErrorText = "إن القسط مستحق الدفع";
                            dataGridViewPayment.Rows[i].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Underline);

                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTotalPrice.Text == "")
                {
                    totalPriceValue = 0;
                    txtTotalPrice.Text="0";
                }
                else
                {
                    totalPriceValue = Convert.ToInt32(txtTotalPrice.Text);
                }
                setBond1();
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
                    totalDiscountValue = 0;
                    txtDiscount.Text = "0";
                }
                else
                {
                    totalDiscountValue = Convert.ToInt32(txtDiscount.Text);
                }
                
                setBond2();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtTotalPrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtTotalPrice.Text == "0")
            {
                errorProvider1.SetError((Control)sender, "المبلغ صفر");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
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

        private void miPayBills_Click(object sender, EventArgs e)
        {
            PayBills pb = new PayBills();
            pb.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtComent.Enabled = checkBox1.Checked;
        }

        private void miPayBillsCheck_Click(object sender, EventArgs e)
        {
            PayCheck pc = new PayCheck();
            pc.ShowDialog();
        }

        private void cbPaymentTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPaymentTime.Checked)
            {
                tabControl1.SelectedIndex = 1;
                epInformation.SetError((Control)sender, "دفع أقساط المبيعات المستحقة من خلال تحديد القسط من جدول الأقساط");
            }
            if (!cbPaymentTime.Checked)
            {
                tabControl1.SelectedIndex = 0;
                epInformation.SetError((Control)sender, "");

            }
            getTableOpeartion();
            getPaymentTime();
        }
        
    }
}
