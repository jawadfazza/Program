using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.SupplierControllarTableAdapters;

namespace Program.entityForm.Supplier.Report
{
    public partial class SupplierBuy : Form
    {
        public SupplierBuy()
        {
            InitializeComponent();
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

        private void SupplierBuy_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'companyDataSet.companyReport' table. You can move, or remove it, as needed.
            this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Guid id = Convert.ToInt32(cbSupplier.Text.Split('.')[1]);
                // TODO: This line of code loads data into the 'supplierDataSet.supplierAccounting' table. You can move, or remove it, as needed.
                this.supplierAccountingTableAdapter.Fill(this.supplierDataSet.supplierAccounting, id);
                // TODO: This line of code loads data into the 'supplierDataSet.SupplierBuy' table. You can move, or remove it, as needed.
                this.supplierBuyTableAdapter.Fill(this.supplierDataSet.SupplierBuy, id);

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
