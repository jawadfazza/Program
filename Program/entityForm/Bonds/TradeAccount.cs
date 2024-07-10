using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.BondTableAdapters;
using Program.entity.controllar;
using Program.entity.controllar.CustomerControllarTableAdapters;
using System.Collections;
using Program.entity.controllar.BoxControllarTableAdapters;
using Program.entity.controllar.BankControllarTableAdapters;
using Program.entity.controllar.SupplierControllarTableAdapters;
using Program.entity.controllar.PaperReceiveControllarTableAdapters;
using Program.entity.controllar.PaperPayControllarTableAdapters;
using Program.entity.controllar.AssetControllarTableAdapters;
using Program.entity.controllar.LiabilityControllarTableAdapters;

namespace Program.entityForm.Bonds
{
    public partial class TradeAccount : Form
    {
        public TradeAccount()
        {
            InitializeComponent();
        }

        private void BondList_Load(object sender, EventArgs e)
        {
            
            rbDay_CheckedChanged(sender, e);

            this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);
            this.reportViewer1.RefreshReport();
        }


        private void rbDay_CheckedChanged(object sender, EventArgs e)
        {
            mcFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); 
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

        private void bRefresh_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bondDataSet.TradeAccount' table. You can move, or remove it, as needed.
            this.tradeAccountTableAdapter.Fill(this.bondDataSet.TradeAccount, mcFrom.Value, mcTo.Value);
            // TODO: This line of code loads data into the 'companyDataSet.companyReport' table. You can move, or remove it, as needed.
            this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);
            this.reportViewer1.RefreshReport();

        }

        private void cbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bRefresh_Click(sender, e);
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void rbDaySelected_CheckedChanged(object sender, EventArgs e)
        {
            mcFrom.Value = DateTime.Now;
            mcTo.Value = DateTime.Now;
            mcFrom.Enabled = true;
            mcTo.Enabled = false;
        }

        private void mcFrom_ValueChanged(object sender, EventArgs e)
        {
            if (rbDaySelected.Checked)
            {
                //mc.Value = mcFrom.Value;
                mcFrom.Value = new DateTime(mcFrom.Value.Year, mcFrom.Value.Month, mcFrom.Value.Day, 0, 0, 0);
                mcTo.Value = new DateTime(mcFrom.Value.Year, mcFrom.Value.Month, mcFrom.Value.Day, 23, 59, 59);
            }
        }
    }
}
