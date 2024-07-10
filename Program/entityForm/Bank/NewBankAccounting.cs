using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.BankControllarTableAdapters;
using Program.entity.controllar;
using Num2Wrd;
using Program.entity.controllar.CustomerControllarTableAdapters;
using System.Collections;
using Program.entity.controllar.BoxControllarTableAdapters;
using Program.entity.controllar.SupplierControllarTableAdapters;

namespace Program.entityForm
{
    public partial class NewBankAccounting : Form
    {
        public NewBankAccounting()
        {
            InitializeComponent();
        }

        static int balance = 0;

        private void NewBankAccounting_Load(object sender, EventArgs e)
        {
            getBankName();
            getBankAccountingTable();
            addList();
            dataGridViewBond.RowCount = 5;
            getBondsAutocomplete();

        }

        public void getBondsAutocomplete()
        {
            customerTableAdapter cta = new customerTableAdapter();
            entity.controllar.CustomerControllar.customerDataTable cdt = cta.GetData();
            ArrayList array = new ArrayList();
            array.Add("رصيد أول المدة");
            foreach (DataRow row in cdt.Rows)
            {
                array.Add("زبون." + row["اسم_الربون"].ToString()+"."+row["الرقم"].ToString());
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
            txtCreditBond1.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtDibetBond.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtCreditBond.Items.AddRange(array.ToArray());
            txtCreditBond1.Items.AddRange(array.ToArray());
            txtDibetBond.Items.AddRange(array.ToArray());

        }

        private void getBankAccountingTable()
        {
            bank_accountTableAdapter bata = new bank_accountTableAdapter();
            dataGridViewBank.DataSource = bata.GetData();

            dataGridViewBank.Columns["bank_id"].Visible = false;

            dataGridViewBank.Columns["اسم_الحساب"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewBank.Columns["تاريخ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewBank.Columns["تعليق"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private void addList()
        {
            DataGridViewComboBoxColumn cbLsit = new DataGridViewComboBoxColumn();
            cbLsit.DisplayIndex = 0;
            cbLsit.HeaderText = "Name";
            cbLsit.ReadOnly = false;
            cbLsit.AutoComplete = true;
           // cbLsit.FlatStyle = FlatStyle.Popup;
            cbLsit.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            
            cbLsit.Items.Add("jawad");
            cbLsit.Items.Add("jawad fazza");
            cbLsit.Items.Add("nor");
            cbLsit.Items.Add("frdos");
            cbLsit.Items.Add("mes");
            cbLsit.Items.Add("rem");
            //dataGridView.Columns.Add(cbLsit);
        }

        private void getBankName()
        {
            bank_detailsTableAdapter bdta = new bank_detailsTableAdapter();
            BankControllar.bank_detailsDataTable bddt= bdta.GetData();
            cbBank.Items.Clear();
            foreach (DataRow row in bddt.Rows)
            {
                cbBank.Items.Add(row["اسم_البنك"]);
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            cbBank.Text = "";
            txtName.Text = "";
            txtNumber.Text = "";
            txtBalance.Text = "0";
            //txtBalanceText.Text = "صفر";
            cbType.Text = "";
        }

        private void editToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || cbBank.Text == "" || txtNumber.Text == "")
            {
                MessageBox.Show("هناك بعض الحقول فارغة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                if (MessageBox.Show("هل تريد حفط الحساب البنكي؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    bank_accountTableAdapter bata = new bank_accountTableAdapter();
                    string comment = "";
                    if (txtComent.Text != "")
                    {
                        comment = txtComent.Text;
                    }
                    else
                    {
                        comment = "فتح رصيد بنكي لدى بنك " + cbBank.Text;
                    }
                    bata.Insert(txtName.Text,
                        txtNumber.Text,
                        cbType.Text,
                        0,
                        "صفر",
                        DateTime.Now,
                        Convert.ToInt32(cbBank.SelectedIndex + 1),
                        comment);
                    //حفط القيود
                    bc.bondFrom = "مصرف." + txtName.Text + "." + (bata.getMaxId()).ToString();

                    setBonds().SaveBonds();
                    getBankAccountingTable();
                    MessageBox.Show("تمت الإضافة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void bBank_Click(object sender, EventArgs e)
        {
            NewBank nb = new NewBank();
            nb.MdiParent = Main.ActiveForm;
            nb.LayoutMdi(MdiLayout.ArrangeIcons);
            //nb.TopLevel = true;
            nb.Show();
        }

        private void cbBank_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل اسم البنك فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل اسم الحساب فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void txtNumber_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل رقم الحساب فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void cbType_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == "")
            {
                errorProvider2.SetError((Control)sender, "من الافضل تحديد نوع الحساب");
            }
            else
            {
                errorProvider2.SetError((Control)sender, "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getBankName();
        }

        private void NewBankAccounting_Resize(object sender, EventArgs e)
        {

        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NumberToEnglish nte = new NumberToEnglish();
                //txtBalanceText.Text = nte.changeNumericToWords(Convert.ToInt64(txtBalance.Text));
                txtBalanceBond.Text = txtBalance.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error : " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        BondControllar bc;
        List<BondControllar> bcList = new List<BondControllar>();
        private BondControllar setBonds()
        {
            
           if (txtCreditBond.Text == "")
            {
                MessageBox.Show("الطرف الدائن فارغ","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                balance = Convert.ToInt32(txtBalance.Text);
                if (balance > 0)
                {
                    bc = new BondControllar();
                    bank_accountTableAdapter bata = new bank_accountTableAdapter();
                    
                    bc.balance = balance;
                    bc.balanceText = "";
                    bc.bondFrom = "مصرف." + txtName.Text + "."+bata.getMaxId().ToString();
                    bc.bondTo = txtCreditBond.Text;
                    if (txtComent.Text != "")
                    {
                        bc.comment = txtComent.Text;
                    }
                    else
                    {
                        bc.comment = "فتح رصيد بنكي لدى بنك " + cbBank.Text;
                    }
                    //bcList.Add(bc);
                    dataGridViewBond.Rows[0].Cells[0].Value = balance;
                    dataGridViewBond.Rows[0].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[0].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[0].Cells[3].Value = bc.comment;
                    CheckBondsError("for", 0);
               }
               else{
                    bc = new BondControllar();

                    bc.balance = 0;
                    bc.balanceText = "";
                    bc.bondFrom = "";
                    bc.bondTo = "";
                    bc.comment = "";
                    
                    dataGridViewBond.Rows[0].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[0].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[0].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[0].Cells[3].Value = "";
                    IsBondTrested[0] = true.ToString();
                }
             }
                return bc;
        }

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



        private void bAddBond_Click(object sender, EventArgs e)
        {
            setBonds();
        }

        private void bRemoveBond_Click(object sender, EventArgs e)
        {
            bcList.RemoveAt(0);
        }



        public static DataRow accountRow;
        private void dataGridViewBank_Click(object sender, EventArgs e)
        {
            try
            {
                bank_accountTableAdapter bata = new bank_accountTableAdapter();
                BankControllar.bank_accountDataTable badt = bata.getBankAccountingId(Convert.ToInt32(dataGridViewBank.Rows[dataGridViewBank.CurrentRow.Index].Cells[0].Value));
                accountRow = badt.Rows[0];
                getBankAccountingRow(accountRow);
            }
            catch (Exception ex)
            {

            }
        }

        private void getBankAccountingRow(DataRow row)
        {
            cbBank.SelectedIndex = Convert.ToInt32( row["bank_id"].ToString())-1;
            txtName.Text = row["اسم_الحساب"].ToString();
            txtNumber.Text = row["رقم_الحساب"].ToString();
            cbType.Text = "0";
            txtBalance.Text = row["الرصيد"].ToString();
            //txtBalanceText.Text = row["الرصيد_كتابة"].ToString();
            //dtpDate.Value = Convert.ToDateTime(row["تاريخ"].ToString());

        }

        private void dataGridViewBank_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                bank_accountTableAdapter bata = new bank_accountTableAdapter();
                BankControllar.bank_accountDataTable badt = bata.getBankAccountingId(Convert.ToInt32(dataGridViewBank.Rows[dataGridViewBank.CurrentRow.Index].Cells[0].Value));
                accountRow = badt.Rows[0];
                getBankAccountingRow(accountRow);
            }
            catch (Exception ex)
            {
                
            }
        }

       
        private void dataGridViewBond_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtDibetBond.Text = "مصرف." + txtName.Text;
        }

        private void txtBalance_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception ex)
            {
            }
        }

        private void txtCreditBond1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCreditBond.Text = txtCreditBond1.Text;
                bAddBond_Click(sender, e);
            }
            catch (Exception ex)
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtComent.Enabled = checkBox1.Checked;
        }

     
    }
}
