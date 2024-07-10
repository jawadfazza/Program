using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.SupplierDataSetTableAdapters;
using Program.entity.controllar.SupplierControllarTableAdapters;

namespace Program.entityForm.Supplier.Report
{
    public partial class SupplierAccounting : Form
    {
        public SupplierAccounting()
        {
            InitializeComponent();
        }

        private void SupplierAccounting_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'companyDataSet.companyReport' table. You can move, or remove it, as needed.
            this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);
            getSupplierNameAutocomplete();
        }

        private void getSupplierNameAutocomplete()
        {
            supplierTableAdapter sta = new supplierTableAdapter();
            entity.controllar.SupplierControllar.supplierDataTable sdt = sta.GetData();
            string[] array = new string[sdt.Rows.Count];
            int count = 0;
            foreach (DataRow row in sdt.Rows)
            {
                array[count] = row["اسم_المورد"].ToString() + "." + row["الرقم"].ToString();
                count++;
            }
            cbSupplier.AutoCompleteCustomSource.AddRange(array);
            cbSupplier.Items.AddRange(array);
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cbSupplier.Text.Split('.')[1]);
                // TODO: This line of code loads data into the 'supplierDataSet.supplier' table. You can move, or remove it, as needed.
                this.supplierAccountingTableAdapter.Fill(this.supplierDataSet.supplierAccounting, id);
                // TODO: This line of code loads data into the 'supplierDataSet.supplier_debit' table. You can move, or remove it, as needed.
                this.supplierAccounting_debitTableAdapter.Fill(this.supplierDataSet.supplierAccounting_debit, id);
                // TODO: This line of code loads data into the 'supplierDataSet.supplier_credit' table. You can move, or remove it, as needed.
                this.supplierAccounting_creditTableAdapter.Fill(this.supplierDataSet.supplierAccounting_credit, id);
                // TODO: This line of code loads data into the 'companyDataSet.companyReport' table. You can move, or remove it, as needed.
                this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

            }
        }


        private void cbSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bRefresh_Click(sender, e);
            }
        }
    }
}
