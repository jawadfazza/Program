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
    public partial class BondList : Form
    {
        public BondList()
        {
            InitializeComponent();
        }

        private void BondList_Load(object sender, EventArgs e)
        {
            
            getBondsAutocomplete();
            rbDay_CheckedChanged(sender, e);

            dataGridViewBondList.Columns.Add("مدين", "مدين");
            dataGridViewBondList.Columns.Add("دائن", "دائن");
            dataGridViewBondList.Columns["مدين"].DisplayIndex = 0;
            dataGridViewBondList.Columns["دائن"].DisplayIndex = 1;
        }

        public void getBondsAutocomplete()
        {
            customerTableAdapter cta = new customerTableAdapter();
            entity.controllar.CustomerControllar.customerDataTable cdt = cta.GetData();
            ArrayList array = new ArrayList();
            foreach (DataRow row in cdt.Rows)
            {
                array.Add("زبون." + row["اسم_الربون"].ToString() + "." + row["الرقم"].ToString());
            }

            paper_receiveTableAdapter prta = new paper_receiveTableAdapter();
            PaperReceiveControllar.paper_receiveDataTable prdt = prta.GetData();
            foreach (DataRow row in prdt.Rows)
            {
                array.Add("سند قبض." + row["المسحوب_عليه"].ToString().Split('.')[0] + "." + row["الرقم"].ToString());
            }

            paper_payTableAdapter ppta = new paper_payTableAdapter();
            PaperPayControllar.paper_payDataTable ppdt = ppta.GetData();
            foreach (DataRow row in ppdt.Rows)
            {
                array.Add("سند دفع." + row["المسحوب_عليه"].ToString().Split('.')[0] + "." + row["الرقم"].ToString());
            }

            boxTableAdapter bta = new boxTableAdapter();
            BoxControllar.boxDataTable bdt = bta.GetData();
            foreach (DataRow row in bdt.Rows)
            {
                array.Add("صندوق." + row["اسم_الصندوق"].ToString() + "." + row["الرقم"].ToString());
            }

            bank_accountTableAdapter bata = new bank_accountTableAdapter();
            BankControllar.bank_accountDataTable badt = bata.GetData();
            foreach (DataRow row in badt.Rows)
            {
                array.Add("مصرف." + row["اسم_الحساب"].ToString() + "." + row["الرقم"].ToString());
            }

            supplierTableAdapter sta = new supplierTableAdapter();
            SupplierControllar.supplierDataTable sdt = sta.GetData();
            foreach (DataRow row in sdt.Rows)
            {
                array.Add("مورد." + row["اسم_المورد"].ToString() + "." + row["الرقم"].ToString());
            }

            assetTableAdapter ata = new assetTableAdapter();
            AssetControllar.assetDataTable adt = ata.GetData();
            foreach (DataRow row in adt.Rows)
            {
                array.Add("أصل." + row["اسم_الأصل"].ToString() + "." + row["الرقم"].ToString());
            }

            liabilityTableAdapter lta = new liabilityTableAdapter();
            LiabilityControllar.liabilityDataTable ldt = lta.GetData();
            foreach (DataRow row in ldt.Rows)
            {
                array.Add("إلتزام." + row["الإلتزام"].ToString() + "." + row["الرقم"].ToString());
            }

            array.Add("حسم ممنوح");
            array.Add("حسم مكتسب");
            array.Add("مبيعات");
            array.Add("مشتريات");
            array.Add("مصروف");
            array.Add("رصيد");
            cbSearch.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            cbSearch.Items.AddRange(array.ToArray());

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

        private void bRefresh_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex =0;
            bondsTableAdapter bta = new bondsTableAdapter();
            Bond.bondsDataTable bdt= bta.getBondByDate(mcFrom.Value, mcTo.Value, cbSearch.Text);

            int count = bdt.Rows.Count;

            dataGridViewBondList.DataSource = bdt;

            dataGridViewBondList.Columns["الرصيد"].Visible = false;
            dataGridViewBondList.Columns["الرصيد"].HeaderText = "المبلغ";
            dataGridViewBondList.Columns["الرقم"].Visible = false;
            dataGridViewBondList.Columns["الرصيد_كتابة"].Visible = false;
            dataGridViewBondList.Columns["مرحل"].Visible = false;
            dataGridViewBondList.Columns["من"].HeaderText = "ح/مدين";
            dataGridViewBondList.Columns["من"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewBondList.Columns["إلى"].HeaderText = "ح/دائن";
            dataGridViewBondList.Columns["إلى"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewBondList.Columns["ملاحطات"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewBondList.Columns["تاريخ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            int totalDebit = 0;
            int totalCredit = 0;

            for (int i = 0; i < count; i++)
            {
                String debit = bdt.Rows[i]["من"].ToString();
                if (debit == cbSearch.Text)
                {
                    totalDebit =  totalDebit + Convert.ToInt32(bdt.Rows[i]["الرصيد"]);
                    dataGridViewBondList.Rows[i].Cells["مدين"].Value = bdt.Rows[i]["الرصيد"].ToString();
                    dataGridViewBondList.Rows[i].DefaultCellStyle.BackColor = Color.Gold;
                    dataGridViewBondList.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                    dataGridViewBondList.Rows[i].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                }
                String credit = bdt.Rows[i]["إلى"].ToString();
                if (credit == cbSearch.Text)
                {
                    totalCredit = totalCredit + Convert.ToInt32(bdt.Rows[i]["الرصيد"]);
                    dataGridViewBondList.Rows[i].Cells["دائن"].Value = bdt.Rows[i]["الرصيد"].ToString();
                    //dataGridViewBondList.Rows[i].DefaultCellStyle.BackColor = Color.Gold;
                    dataGridViewBondList.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    dataGridViewBondList.Rows[i].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Regular);
                }
            }
            txtTotleDebit.Text = totalDebit.ToString();
            txtTotlaCredit.Text = totalCredit.ToString();
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
            tabControl1.SelectedIndex = 1;
            // TODO: This line of code loads data into the 'bondDataSet.bondList' table. You can move, or remove it, as needed.
            this.bondListTableAdapter.Fill(this.bondDataSet.bondList, mcFrom.Value, mcTo.Value, cbSearch.Text);
            // TODO: This line of code loads data into the 'companyDataSet.companyReport' table. You can move, or remove it, as needed.
            this.companyReportTableAdapter.Fill(this.companyDataSet.companyReport);

            this.reportViewer1.RefreshReport();
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
