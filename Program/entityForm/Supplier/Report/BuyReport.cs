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
    public partial class BuyReport : Form
    {
        public BuyReport()
        {
            InitializeComponent();

        }

        private void BuyReport_Load(object sender, EventArgs e)
        {     
            rbDay_CheckedChanged(sender, e);
        }

        private void bRefreshTable_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            material_debitTableAdapter mcta = new material_debitTableAdapter();
            MaterialControllar.material_debitDataTable mcdt = mcta.getBuyReport(mcFrom.Value, mcTo.Value);
            dataGridViewBuy.DataSource = mcdt;

            dataGridViewBuy.Columns["الرصيد"].HeaderText = "المبلغ";
            dataGridViewBuy.Columns["من"].HeaderText = "المورد";

            dataGridViewBuy.Columns["الرصيد"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewBuy.Columns["تاريخ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewBuy.Columns["مصاريف_على_حساب"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewBuy.Columns["من"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridViewBuy.Columns["تاريخ_فاتورة_المصدر"].Visible = false;
            dataGridViewBuy.Columns["الرصيد_كتابة"].Visible = false;
            dataGridViewBuy.Columns["المستودع"].Visible = false;
            dataGridViewBuy.Columns["المورد"].Visible = false;
            dataGridViewBuy.Columns["حذفة"].Visible = false;
            //dataGridViewBuy.Columns["بالة"].Visible = false;
            dataGridViewBuy.Columns["مرحل"].Visible = false;
            dataGridViewBuy.Columns["اسم_الحساب"].Visible = false;

        }
        
        private void bPrintTable_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedIndex = 1;

                // TODO: This line of code loads data into the 'companyDataSet.companyReport' table. You can move, or remove it, as needed.
                this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);
                // TODO: This line of code loads data into the 'materialDataSet.BuyReport' table. You can move, or remove it, as needed.
                this.buyReportTableAdapter.Fill(this.materialDataSet.BuyReport, mcFrom.Value, mcTo.Value);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
            }
        }

        private void bShowBills_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedIndex = 2;
                Guid id = Convert.ToInt32(dataGridViewBuy.Rows[dataGridViewBuy.CurrentRow.Index].Cells[0].Value);
                // TODO: This line of code loads data into the 'supplierDataSet.materialBills_debit' table. You can move, or remove it, as needed.
                this.materialBills_debitTableAdapter.Fill(this.supplierDataSet.materialBills_debit, id);
                // TODO: This line of code loads data into the 'supplierDataSet.materialBills_debit_list' table. You can move, or remove it, as needed.
                this.materialBills_debit_listTableAdapter.Fill(this.supplierDataSet.materialBills_debit_list, id);
                // TODO: This line of code loads data into the 'companyDataSet.companyReport' table. You can move, or remove it, as needed.
                this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);

                this.reportViewer2.RefreshReport();
            }
            catch (Exception ex)
            {
            }
        }

        private void bShowReportChart_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedIndex = 3;
                // TODO: This line of code loads data into the 'materialDataSet.BuyReport' table. You can move, or remove it, as needed.
                this.buyReportTableAdapter.Fill(this.materialDataSet.BuyReport, mcFrom.Value, mcTo.Value);

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
