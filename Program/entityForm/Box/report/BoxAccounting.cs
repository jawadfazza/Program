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

namespace Program.entityForm.Box.report
{
    public partial class BoxAccounting : Form
    {
        public BoxAccounting()
        {
            InitializeComponent();
            getAccountNameAutocomplete();
        }

        private void BoxAccounting_Load(object sender, EventArgs e)
        {           

            rbDay_CheckedChanged(sender, e);
        }

        public void getAccountNameAutocomplete()
        {
            boxTableAdapter bata = new boxTableAdapter();
            BoxControllar.boxDataTable badt = bata.GetData();
            string[] array = new string[badt.Rows.Count];
            int count = 0;
            foreach (DataRow row in badt.Rows)
            {
                array[count] = row["اسم_الصندوق"].ToString() + "." + row["الرقم"].ToString();
                count++;
            }
            cbBox.AutoCompleteCustomSource.AddRange(array);
            cbBox.Items.AddRange(array);
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Guid id = Convert.ToInt32(cbBox.Text.Split('.')[1]);
                // TODO: This line of code loads data into the 'boxDataSet.boxAccount' table. You can move, or remove it, as needed.
                this.boxAccountTableAdapter.Fill(this.boxDataSet.boxAccount, id);
                // TODO: This line of code loads data into the 'boxDataSet.boxAccount_debit' table. You can move, or remove it, as needed.
                this.boxAccount_debitTableAdapter.Fill(this.boxDataSet.boxAccount_debit, id, mcFrom.Value, mcTo.Value);
                // TODO: This line of code loads data into the 'boxDataSet.boxAccount_credit' table. You can move, or remove it, as needed.
                this.boxAccount_creditTableAdapter.Fill(this.boxDataSet.boxAccount_credit, id, mcFrom.Value, mcTo.Value);
                // TODO: This line of code loads data into the 'companyDataSet.companyReport' table. You can move, or remove it, as needed.
                this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);

                this.reportViewer1.RefreshReport();
                this.reportViewer2.RefreshReport();
            }
            catch (Exception ex)
            {

            }
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
            mcFrom.Value = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
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
