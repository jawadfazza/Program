using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.BoxControllarTableAdapters;
using Program.entity.controllar;
using Program.entity.controllar.BankControllarTableAdapters;

namespace Program.entityForm.Supplier.Report
{
    public partial class ReciveCheck : Form
    {
        public ReciveCheck()
        {
            try
            {
                InitializeComponent();
                
                getReportId();
                txtId.Text = cbIds.Items[cbIds.Items.Count - 1].ToString();
                getReport(Convert.ToInt32(cbIds.Items[cbIds.Items.Count - 1]));
                indexMaterialdebit = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("لا توجد تقارير", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReciveCheck_Load(object sender, EventArgs e)
        {

        }

        private void getReportId()
        {
            bank_debitTableAdapter mcta = new bank_debitTableAdapter();
            BankControllar.bank_debitDataTable mcdt = mcta.GetData();
            cbIds.Items.Clear();
            foreach (DataRow dr in mcdt.Rows)
            {
                cbIds.Items.Add(dr["الرقم"]);
            }
        }

        private void BuyBills_Load(object sender, EventArgs e)
        {

        }

        static int indexMaterialdebit = 0;
        private void bNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text != "")
                {
                    indexMaterialdebit++;
                }
                getReport(Convert.ToInt32(cbIds.Items[indexMaterialdebit]));
                txtId.Text = cbIds.Items[indexMaterialdebit].ToString();
                if (indexMaterialdebit == (cbIds.Items.Count - 1))
                {
                    bNext.Enabled = false;
                }
                else
                {
                    bPrevious.Enabled = true;
                }
            }
            catch (Exception ex)
            {

            }
        }



        private void bPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                indexMaterialdebit--;
                getReport(Convert.ToInt32(cbIds.Items[indexMaterialdebit]));
                txtId.Text = cbIds.Items[indexMaterialdebit].ToString();
                if (indexMaterialdebit == 0)
                {
                    bPrevious.Enabled = false;
                }
                else
                {
                    bNext.Enabled = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = cbIds.Items[cbIds.SelectedIndex].ToString();
                getReport(Convert.ToInt32(cbIds.Items[cbIds.SelectedIndex]));
            }
            catch (Exception ex)
            {

            }
        }

        private void getReport(Guid id)
        {
            try
            {
                // TODO: This line of code loads data into the 'bankDataSet.bank_creditPayCheck' table. You can move, or remove it, as needed.
                this.bank_debitReciveCheckTableAdapter.Fill(this.bankDataSet.bank_debitReciveCheck,id);
                // TODO: This line of code loads data into the 'companyDataSet.companyReport' table. You can move, or remove it, as needed.
                this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
