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

namespace Program.entityForm.Material.report
{
    public partial class MaterialCard : Form
    {
        public MaterialCard()
        {
            InitializeComponent();
            getMaterialNameAutocomplete();
        }

        private void MaterialCard_Load(object sender, EventArgs e)
        {

        }

        public void getMaterialNameAutocomplete()
        {
            materialTableAdapter mta = new materialTableAdapter();
            MaterialControllar.materialDataTable mdt = mta.GetData();
            string[] array = new string[mdt.Rows.Count];
            int count = 0;
            foreach (DataRow row in mdt.Rows)
            {
                array[count] = row["اسم_المادة"].ToString() + "." + row["الرقم_الفني"].ToString();
                count++;
            }
            txtMaterialName.AutoCompleteCustomSource.AddRange(array);
            txtMaterialName.Items.AddRange(array);
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
          
                Guid id = Convert.ToInt32(txtMaterialName.Text.Split('.')[1]);
                // TODO: This line of code loads data into the 'materialDataSet.MaterialCard' table. You can move, or remove it, as needed.
                this.materialCardTableAdapter.Fill(this.materialDataSet.MaterialCard, id);
                // TODO: This line of code loads data into the 'materialDataSet.MaterialDebitCrad' table. You can move, or remove it, as needed.
                this.materialDebitCradTableAdapter.Fill(this.materialDataSet.MaterialDebitCrad, id);
                // TODO: This line of code loads data into the 'materialDataSet.MaterialCreditCard' table. You can move, or remove it, as needed.
                this.materialCreditCardTableAdapter.Fill(this.materialDataSet.MaterialCreditCard, id);
                // TODO: This line of code loads data into the 'materialDataSet.MaterialDebitCradReturn' table. You can move, or remove it, as needed.
                this.materialDebitCradReturnTableAdapter.Fill(this.materialDataSet.MaterialDebitCradReturn, id);
                // TODO: This line of code loads data into the 'materialDataSet.MaterialCreditCardReturn' table. You can move, or remove it, as needed.
                this.materialCreditCardReturnTableAdapter.Fill(this.materialDataSet.MaterialCreditCardReturn, id);
                // TODO: This line of code loads data into the 'companyDataSet.companyReport' table. You can move, or remove it, as needed.
                this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);
                this.reportViewer1.RefreshReport();
           

        }

        private void txtMaterialName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bRefresh_Click(sender, e);
            }
        }
    }
}
