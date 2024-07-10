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

namespace Program.entityForm.customer.report
{
    public partial class SaleReport : Form
    {
        public SaleReport()
        {
            InitializeComponent();

        }
        public static DateTime from, to = DateTime.Now;
        public static int index = 0;
        private void SaleReport_Load(object sender, EventArgs e)
        {
            rbDay_CheckedChanged(sender, e);
            try
            {
                mcFrom.Value = from;
                mcTo.Value = to;
                tabControl1.SelectedIndex = index;
                if (index == 0)
                {
                    bPrintTable_Click(sender,e);
                }
                if (index == 1)
                {
                    bRefreshTable_Click(sender, e);
                }
                if (index == 2)
                {
                    bShowReportChart_Click(sender, e);
                }
            }
            catch { }
        }

        private void bRefreshTable_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            // TODO: This line of code loads data into the 'materialDataSet.material_credit_list_Bills_Details' table. You can move, or remove it, as needed.
            this.material_credit_list_Bills_DetailsTableAdapter.Fill(this.materialDataSet.material_credit_list_Bills_Details, mcFrom.Value, mcTo.Value);
            rbDay_CheckedChanged(sender, e);
            this.reportViewer2.RefreshReport();

        }

        private void bPrintTable_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedIndex = 0;
                // TODO: This line of code loads data into the 'materialDataSet.SalesReturnReport' table. You can move, or remove it, as needed.
                this.salesReturnReportTableAdapter.Fill(this.materialDataSet.SalesReturnReport, mcFrom.Value, mcTo.Value);
                // TODO: This line of code loads data into the 'materialDataSet.SalesReport' table. You can move, or remove it, as needed.
                this.salesReportTableAdapter.Fill(this.materialDataSet.SalesReport, mcFrom.Value, mcTo.Value);
                // TODO: This line of code loads data into the 'companyDataSet.companyReport' table. You can move, or remove it, as needed.
                this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {
            }  
        }

        private void bShowBills_Click(object sender, EventArgs e)
        {

        }

        private void bShowReportChart_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedIndex = 2;
                // TODO: This line of code loads data into the 'materialDataSet.SalesReport' table. You can move, or remove it, as needed.
                this.salesReportTableAdapter.Fill(this.materialDataSet.SalesReport, mcFrom.Value, mcTo.Value);
                this.reportViewer3.RefreshReport();
            }
            catch (Exception ex)
            {
            }
        }

        private void rbDay_CheckedChanged(object sender, EventArgs e)
        {
            mcFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); ;
            mcTo.Value = DateTime.Now;
            mcFrom.Enabled = false;
            mcTo.Enabled = false;
        }

        private void rbMonth_CheckedChanged(object sender, EventArgs e)
        {
            mcFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            mcTo.Value = DateTime.Now;
            mcFrom.Enabled = false;
            mcTo.Enabled = false;
        }

        private void rbYear_CheckedChanged(object sender, EventArgs e)
        {
            mcFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            mcTo.Value = DateTime.Now;
            mcFrom.Enabled = false;
            mcTo.Enabled = false;
        }

        private void rbOtherDate_CheckedChanged(object sender, EventArgs e)
        {
            mcFrom.Value = DateTime.Now;
            mcTo.Value = DateTime.Now;
            mcFrom.Enabled = true;
            mcTo.Enabled = true;
        }
    }
}
