﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.MaterialControllarTableAdapters;
using Program.entity.controllar;

namespace Program.entityForm.Customer.Report
{
    public partial class ReturnSaleBills : Form
    {
        public ReturnSaleBills()
        {
            InitializeComponent();
            try
            {
                getReportId();
                txtId.Text = cbIds.Items[cbIds.Items.Count - 1].ToString();
                getReport(Convert.ToInt32(cbIds.Items[cbIds.Items.Count - 1]));
            }
            catch (Exception ex)
            {
                MessageBox.Show("لا توجد تقارير", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getReportId()
        {
            material_debit_returnTableAdapter mcta = new material_debit_returnTableAdapter();
            MaterialControllar.material_debit_returnDataTable mcdt = mcta.GetData();
            cbIds.Items.Clear();
            foreach (DataRow dr in mcdt.Rows)
            {
                cbIds.Items.Add(dr["الرقم"]);
            }
        }

        private void BuyBills_Load(object sender, EventArgs e)
        {
           

            this.reportViewer1.RefreshReport();
        }

        static int indexMaterialCredit = 0;
        private void bNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text != "")
                {
                    indexMaterialCredit++;
                }
                getReport(Convert.ToInt32(cbIds.Items[indexMaterialCredit]));
                txtId.Text = cbIds.Items[indexMaterialCredit].ToString();
                if (indexMaterialCredit == (cbIds.Items.Count - 1))
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
                indexMaterialCredit--;
                getReport(Convert.ToInt32(cbIds.Items[indexMaterialCredit]));
                txtId.Text = cbIds.Items[indexMaterialCredit].ToString();
                if (indexMaterialCredit == 0)
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
                // TODO: This line of code loads data into the 'customerDataSet.material_debit_returnCard' table. You can move, or remove it, as needed.
                this.material_debit_returnCardTableAdapter.Fill(this.customerDataSet.material_debit_returnCard,id);
                // TODO: This line of code loads data into the 'customerDataSet.material_debit_list_returnCard' table. You can move, or remove it, as needed.
                this.material_debit_list_returnCardTableAdapter.Fill(this.customerDataSet.material_debit_list_returnCard,id);
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
