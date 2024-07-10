using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program.entityForm.Bonds
{
    public partial class BlanceSheet : Form
    {
        public BlanceSheet()
        {
            InitializeComponent();
        }

        private void BlanceSheet_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'companyDataSet.companyReport' table. You can move, or remove it, as needed.
            this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);
            // TODO: This line of code loads data into the 'blanceSheetDataSet.paper_payBlanceSheet' table. You can move, or remove it, as needed.
            this.paper_payBlanceSheetTableAdapter.Fill(this.blanceSheetDataSet.paper_payBlanceSheet);
            // TODO: This line of code loads data into the 'blanceSheetDataSet.supplierBlanceSheet' table. You can move, or remove it, as needed.
            this.supplierBlanceSheetTableAdapter.Fill(this.blanceSheetDataSet.supplierBlanceSheet);
            // TODO: This line of code loads data into the 'blanceSheetDataSet.asset' table. You can move, or remove it, as needed.
            this.assetTableAdapter.Fill(this.blanceSheetDataSet.asset);
            // TODO: This line of code loads data into the 'blanceSheetDataSet.paper_receiveBlanceSheet' table. You can move, or remove it, as needed.
            this.paper_receiveBlanceSheetTableAdapter.Fill(this.blanceSheetDataSet.paper_receiveBlanceSheet);
            // TODO: This line of code loads data into the 'blanceSheetDataSet.materialBlanceSheet' table. You can move, or remove it, as needed.
            this.materialBlanceSheetTableAdapter.Fill(this.blanceSheetDataSet.materialBlanceSheet);
            // TODO: This line of code loads data into the 'blanceSheetDataSet.customerBlanceSheet' table. You can move, or remove it, as needed.
            this.customerBlanceSheetTableAdapter.Fill(this.blanceSheetDataSet.customerBlanceSheet);
            // TODO: This line of code loads data into the 'blanceSheetDataSet.boxBlanceSheet' table. You can move, or remove it, as needed.
            this.boxBlanceSheetTableAdapter.Fill(this.blanceSheetDataSet.boxBlanceSheet);
            // TODO: This line of code loads data into the 'blanceSheetDataSet.bank_accountBlanceSheet' table. You can move, or remove it, as needed.
            this.bank_accountBlanceSheetTableAdapter.Fill(this.blanceSheetDataSet.bank_accountBlanceSheet);

            this.reportViewer1.RefreshReport();
        }
    }
}
