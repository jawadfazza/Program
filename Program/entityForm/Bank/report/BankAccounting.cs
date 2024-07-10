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

namespace Program.entityForm.Bank.report
{
    public partial class BankAccounting : Form
    {
        public BankAccounting()
        {
            InitializeComponent();
            getAccountNameAutocomplete();
        }

        public void getAccountNameAutocomplete()
        {
            bank_accountTableAdapter bata = new bank_accountTableAdapter();
            BankControllar.bank_accountDataTable badt = bata.GetData();
            string[] array = new string[badt.Rows.Count];
            int count = 0;
            foreach (DataRow row in badt.Rows)
            {
                array[count] = row["اسم_الحساب"].ToString() + "." + row["الرقم"].ToString();
                count++;
            }
            cbBankAccount.AutoCompleteCustomSource.AddRange(array);
            cbBankAccount.Items.AddRange(array);
        }

        private void BankAccounting_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'companyDataSet.companyReport' table. You can move, or remove it, as needed.
            this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);
            
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cbBankAccount.Text.Split('.')[1]);
                // TODO: This line of code loads data into the 'bankDataSet.bankAccount_account' table. You can move, or remove it, as needed.
                this.bankAccount_accountTableAdapter.Fill(this.bankDataSet.bankAccount_account,id);
                // TODO: This line of code loads data into the 'bankDataSet.bankAccount_debit' table. You can move, or remove it, as needed.
                this.bankAccount_debitTableAdapter.Fill(this.bankDataSet.bankAccount_debit,id);
                // TODO: This line of code loads data into the 'bankDataSet.bankAccount_credit' table. You can move, or remove it, as needed.
                this.bankAccount_creditTableAdapter.Fill(this.bankDataSet.bankAccount_credit,id);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
