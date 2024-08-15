using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.CustomerControllarTableAdapters;

namespace Program.entityForm.customer.report
{
    public partial class CustomerSale : Form
    {
        public CustomerSale()
        {
            InitializeComponent();
            getCustomerNameAutocomplete();
        }

        public void getCustomerNameAutocomplete()
        {
            customerTableAdapter cta = new customerTableAdapter();
            entity.controllar.CustomerControllar.customerDataTable cdt = cta.GetData();
            string[] array = new string[cdt.Rows.Count];
            int count = 0;
            foreach (DataRow row in cdt.Rows)
            {
                array[count] = row["اسم_الربون"].ToString() + "." + row["الرقم"].ToString();
                count++;
            }
            cbCustomerName.AutoCompleteCustomSource.AddRange(array);
            cbCustomerName.Items.AddRange(array);
        }

        private void CustomerSale_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'companyDataSet.companyReport' table. You can move, or remove it, as needed.
            this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);
            this.reportViewer1.RefreshReport();
        }

        private void bReferch_Click(object sender, EventArgs e)
        {
            try
            {
                Guid id = Convert.ToInt32(cbCustomerName.Text.Split('.')[1]);
                // TODO: This line of code loads data into the 'customerDataSet.CustomerSale' table. You can move, or remove it, as needed.
                this.customerSaleTableAdapter.Fill(this.customerDataSet.CustomerSale, id);
                // TODO: This line of code loads data into the 'customerDataSet.CustomerReport' table. You can move, or remove it, as needed.
                this.customerReportTableAdapter.Fill(this.customerDataSet.CustomerReport, id);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

            }
        }

        private void cbCustomerName_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bReferch_Click(sender, e);

            }
        }

    }
}
