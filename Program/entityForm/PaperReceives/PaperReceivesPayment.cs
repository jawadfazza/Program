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
using Program.entityForm.Supplier.Report;
using Program.entity.controllar.PaperReceiveControllarTableAdapters;

namespace Program.entityForm.customer
{
    public partial class PaperReceivesPayment : Form
    {
        public PaperReceivesPayment()
        {
            InitializeComponent();
            getTable();
        }

        private void PaperReceivesPayment_Load(object sender, EventArgs e)
        {
            //dataGridViewPayment.RowCount = 20;
            dataGridViewBond.RowCount = 5;
            getId();
            getBankAccounting();
            splitContainer1.SplitterDistance = 250;
            bRefresh_Click(sender, e);
        }

        private void getTable()
        {
            paper_receiveTableAdapter prta = new paper_receiveTableAdapter();
            dataGridViewPayment.DataSource = prta.GetData();
            int count = dataGridViewPayment.Rows.Count;

            dataGridViewPayment.Columns["الرصيد_كتابة"].Visible = false;
            dataGridViewPayment.Columns["المسحوب_عليه"].DisplayIndex = 2;
            dataGridViewPayment.Columns["المسحوب_عليه"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewPayment.Columns["الساحب"].DisplayIndex = 3;
            dataGridViewPayment.Columns["الساحب"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewPayment.Columns["تاريخ_الإستحقاق"].DisplayIndex = 4;
            dataGridViewPayment.Columns["تاريخ_الإستحقاق"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            for (int i = 0; i < count; i++)
            {
                int balance = Convert.ToInt32(dataGridViewPayment.Rows[i].Cells["الرصيد"].Value);
                DateTime date = Convert.ToDateTime(dataGridViewPayment.Rows[i].Cells["تاريخ_الإستحقاق"].Value);
                if (balance == 0)
                {
                    dataGridViewPayment.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                    dataGridViewPayment.Rows[i].ErrorText = "";

                }
                if (balance != 0)
                {
                    if (date > DateTime.Now)
                    {
                        dataGridViewPayment.Rows[i].DefaultCellStyle.ForeColor = Color.Goldenrod;
                        dataGridViewPayment.Rows[i].ErrorText = "إن ورقة القبض لم تستحق بعد";
                    }
                    if (date < DateTime.Now)
                    {
                        dataGridViewPayment.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        dataGridViewPayment.Rows[i].ErrorText = "ورقة القبض مستحقة القبض";
                    }
                    
                }

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

        public void getId()
        {
            paper_receiveTableAdapter cta = new paper_receiveTableAdapter();
            entity.controllar.PaperReceiveControllar.paper_receiveDataTable prdt = cta.GetData();
            string[] array = new string[prdt.Rows.Count];
            int count = 0;
            foreach (DataRow row in prdt.Rows)
            {
                array[count] = row["الرقم"].ToString();
                count++;
            }
            txtid.AutoCompleteCustomSource.AddRange(array);
            txtid.Items.AddRange(array);
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
                if (totalPriceValue > 0&&cbTypeOperation.Text=="كاش")
                 {
                     bc = new BondControllar();

                     bc.balance = totalPriceValue;
                     bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                     bc.bondFrom = "صندوق.صندوق اليومية.1";
                     bc.bondTo = "سند قبض." + txtName.Text.Split('.')[0] + "." + txtid.Text;
                     if (txtComent.Text != "")
                     {
                         bc.comment = txtComent.Text;
                     }
                     else
                     {
                         bc.comment = "إستلام مبلغ نقدي من الزبون " + txtName.Text + " مقابل تسديد سند القبض رقم :"+txtid.Text ;
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
                     bc.bondFrom = "مصرف."+cbBankAccounting.Text;
                     bc.bondTo = "سند قبض." + txtName.Text.Split('.')[0].ToString() +"."+ txtid.Text;

                     if (txtComent.Text != "")
                     {
                         bc.comment = txtComent.Text;
                     }
                     else
                     {
                         bc.comment = "الحصول على شيك بنكي من الزبون " + txtName.Text + " مقابل تسديد سند القبض رقم :" + txtid.Text;
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

                     //IsBondTrested[0] = true.ToString();
                 }
                 IsBondTrested = CheckBondsError("to", 0);

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
                bc.bondTo = "سند قبض." + txtName.Text.Split('.')[0].ToString() + "." + txtid.Text;
                bc.comment = "تقديم حسم للزبون " + txtName.Text + " لقاء دفعة نقدية";

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
           IsBondTrested = CheckBondsError("to", 1);
            return bc;
        }


        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            cbTypeOperation.Enabled = true;
            cbBankAccounting.Enabled=false;
            bAddBond_Click(sender, e);
        }

        bool IsBondTrested =true;
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
            if (cbTypeOperation.Text == "كاش")
            {
                cbBankAccounting.Enabled = false;
            }
            if (cbTypeOperation.Text == "شيك")
            {
                cbBankAccounting.Enabled = true;
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (IsBondTrested)
            {
                if ((totalDiscountValue + totalPriceValue) <= Convert.ToInt32(txtBalance.Text))
                {
                    if (MessageBox.Show("هل تريد حفط التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        setBond1().SaveBonds();
                        setBond2().SaveBonds();
                        MessageBox.Show("  تم إضافة التقرير  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getTable();
                        if (MessageBox.Show("هل تريد استعراض أمر الدفع ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            if (cbTypeOperation.Text == "كاش")
                            {
                                ReceiveBills rp = new ReceiveBills();
                                rp.ShowDialog();
                            }
                            if (cbTypeOperation.Text == "شيك")
                            {
                                ReciveCheck rc = new ReciveCheck();
                                rc.ShowDialog();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("مجموع الحسم و المبلغ الدفوع أكبر من الرصيد", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("لا يمكن نجاز العملية هناك خطأ في الارصدة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtBalance.Text = "";
            txtTotalPrice.Text = "";
            txtDiscount.Text = "";
            txtComent.Text = "";
            dtpSaleDate.Value = DateTime.Now;

            dataGridViewBond.Rows[0].Cells[0].Value = bc.balance;
            dataGridViewBond.Rows[0].Cells[1].Value = bc.bondFrom;
            dataGridViewBond.Rows[0].Cells[2].Value = bc.bondTo;
            dataGridViewBond.Rows[0].Cells[3].Value = "";
           
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void txtCustomer_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    bAddCustomer_Click(sender, e);
                }
            }
            catch (Exception ex)
            {

            }
        }

        static Guid id = 0;
        private void bAddCustomer_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("id: " + txtid.Text.Split('.')[1]);

            id = Convert.ToInt32(txtid.Text);
            paper_receiveTableAdapter prta = new paper_receiveTableAdapter();
            entity.controllar.PaperReceiveControllar.paper_receiveDataTable pcdt = prta.PaperReceiveById(id);
            PaperReceiveControllar.paper_receiveRow prr = pcdt[0];

            txtName.Text = prr["المسحوب_عليه"].ToString();
            txtBalance.Text = prr["الرصيد"].ToString();
            dtpSaleDate.Value = Convert.ToDateTime(prr["تاريخ"].ToString());
            //customer_creditTableAdapter ccta = new customer_creditTableAdapter();
            //CustomerControllar.customer_creditDataTable dr = ccta.getCustomerPayment(id);
            
            

        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTotalPrice.Text == "")
                {
                    totalPriceValue = 0;
                    txtTotalPrice.Text = "0";
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
                    txtDiscount.Text = "0.0";
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

        private void bHide_Click(object sender, EventArgs e)
        {
            gbBonds.Hide();
        }

        private void bShow_Click(object sender, EventArgs e)
        {
            gbBonds.Show();
        }

        private void miReciveMoney_Click(object sender, EventArgs e)
        {
            ReceiveBills rb = new ReceiveBills();
            rb.ShowDialog();
        }

        private void miReciveMoneyBank_Click(object sender, EventArgs e)
        {
            ReciveCheck rc = new ReciveCheck();
            rc.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtComent.Enabled = checkBox1.Checked;
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            getTable();
        }

        private void dataGridViewPayment_Click(object sender, EventArgs e)
        {
            txtid.Text = dataGridViewPayment.Rows[dataGridViewPayment.CurrentRow.Index].Cells[0].Value.ToString();
            bAddCustomer_Click(sender, e);
        }

        
    }
}
