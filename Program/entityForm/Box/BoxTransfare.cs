using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.SupplierControllarTableAdapters;
using Program.entity.controllar.MaterialControllarTableAdapters;
using Program.entity.controllar;
using Program.entity.controllar.BankControllarTableAdapters;
using Num2Wrd;
using Program.entity.controllar.CustomerControllarTableAdapters;
using System.Collections;
using Program.entity.controllar.BoxControllarTableAdapters;
using Program.entityForm.Supplier.Report;
using Program.entity.controllar.BondTableAdapters;
using Program.entity.controllar.LiabilityControllarTableAdapters;
using Program.entity.controllar.AssetControllarTableAdapters;
using Program.entity.controllar.PaperPayControllarTableAdapters;
using Program.entity.controllar.PaperReceiveControllarTableAdapters;
using System.Threading;

namespace Program.entityForm.Supplier
{
    public partial class BoxTransfare : Form
    {
        public BoxTransfare()
        {
            InitializeComponent();

            getBondsAutocomplete();
            getAccountNameAutocomplete();
            dataGridViewBond.RowCount = 5;
            splitContainer1.SplitterDistance = 250;
        }

        private void BankTransfare_Load(object sender, EventArgs e)
        {
            dataGridViewBox.Columns.Add("مدين", "مدين");
            dataGridViewBox.Columns.Add("دائن", "دائن");
            dataGridViewBox.Columns["مدين"].DisplayIndex = 0;
            dataGridViewBox.Columns["دائن"].DisplayIndex = 1;
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

            txtCreditBond.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtDibetBond.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtCreditBond.Items.AddRange(array.ToArray());
            txtDibetBond.Items.AddRange(array.ToArray());

            txtCreditBond1.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtDibetBond1.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtCreditBond1.Items.AddRange(array.ToArray());
            txtDibetBond1.Items.AddRange(array.ToArray());

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
            txtbox.AutoCompleteCustomSource.AddRange(array);
            txtbox.Items.AddRange(array);
        }

        private void Sale_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 250;

        }

        private void bAddBond_Click(object sender, EventArgs e)
        {
            setBond1();
        }

        BondControllar bc;
        List<BondControllar> bcList = new List<BondControllar>();
        NumberToEnglish nte = new NumberToEnglish();

        static double totalPriceValue = 0;

        private BondControllar setBond1()
        {
            //cash
            if (rbReceive.Checked)
            {
                if (totalPriceValue > 0)
                {
                    bc = new BondControllar();

                    bc.balance = totalPriceValue;
                    bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    bc.bondFrom = "صندوق."+txtbox.Text;
                    bc.bondTo = txtCreditBond.Text;
                    if (txtComent.Text != "")
                    {
                        bc.comment = txtComent.Text;
                    }
                    else
                    {
                        bc.comment = "قبض مبلغ نقدي من " + txtCreditBond.Text;
                    }

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[0].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[0].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[0].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[0].Cells[3].Value = bc.comment;
                }
                if (totalPriceValue == 0)
                {
                    bc = new BondControllar();

                    bc.balance = 0;
                    bc.balanceText = "";
                    bc.bondFrom = "";
                    bc.bondTo = "";
                    bc.comment = "";
                    //bcList.Add(bc);
                    dataGridViewBond.Rows[0].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[0].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[0].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[0].Cells[3].Value = bc.comment;
                }
            }

            //check 
            if (rbPayment.Checked)
            {
                if (totalPriceValue > 0)
                {
                    bc = new BondControllar();

                    bc.balance = totalPriceValue;
                    bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    bc.bondFrom = txtDibetBond.Text;
                    bc.bondTo = "صندوق." + txtbox.Text;
                    if (txtComent.Text != "")
                    {
                        bc.comment = txtComent.Text;
                    }
                    else
                    {
                        bc.comment = "دفع مبلغ نقدي ل " + txtDibetBond.Text;
                    }
                    //bcList.Add(bc);
                    dataGridViewBond.Rows[0].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[0].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[0].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[0].Cells[3].Value = bc.comment;

                }
                if (totalPriceValue == 0)
                {
                    bc = new BondControllar();

                    bc.balance = 0;
                    bc.balanceText = "";
                    bc.bondFrom = "";
                    bc.bondTo = "";
                    bc.comment = "";

                    dataGridViewBond.Rows[0].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[0].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[0].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[0].Cells[3].Value = bc.comment;

                }
                
            }
            IsBondTrested = CheckBondsError("both", 0);
             return bc;
        }



        static bool IsBondTrested = true;
        public bool CheckBondsError(string dir,int index)
        {
            bool ok = true;
            string[] message = bc.CheckBonds(dir);
            if (message[0] != "")
            {
                dataGridViewBond.Rows[index].ErrorText = message[0];
                dataGridViewBond.Rows[index].Cells[1].ErrorText = message[0];
                dataGridViewBond.Rows[index].DefaultCellStyle.BackColor = Color.Gold;
                dataGridViewBond.Rows[index].DefaultCellStyle.ForeColor = Color.Green;
                ok = false;
            }
            if (message[1] != "")
            {
                dataGridViewBond.Rows[index].ErrorText +="\n"+ message[1];
                dataGridViewBond.Rows[index].Cells[2].ErrorText = message[1];
                dataGridViewBond.Rows[index].DefaultCellStyle.BackColor = Color.Gold;
                dataGridViewBond.Rows[index].DefaultCellStyle.ForeColor = Color.Green;
                ok = false;

            }
            //if there are no error
            if (message[0] == "" && message[1] == "")
            {
                dataGridViewBond.Rows[index].ErrorText = "";
                dataGridViewBond.Rows[index].Cells[1].ErrorText = message[0];
                dataGridViewBond.Rows[index].Cells[2].ErrorText = message[1];
                dataGridViewBond.Rows[index].DefaultCellStyle.BackColor = Color.White;
                dataGridViewBond.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
                ok = true;
            }
            return ok;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (IsBondTrested)
            {
                if (rbPayment.Checked)
                {
                    if (MessageBox.Show("هل تريد حفط التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        setBond1().SaveBonds();
                        if (MessageBox.Show("هل تريد عرض أمر الدفع؟ ", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            miPayBills_Click(sender, e);
                        }
                    }
                }
                if (rbReceive.Checked)
                {
                    if (MessageBox.Show("هل تريد حفط التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        setBond1().SaveBonds();
                        if (MessageBox.Show("هل تريد عرض أمر القبض؟ ", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information,MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            miReciveBills_Click(sender, e);
                        }
                    }
                }
                bAddSupplier_Click(sender, e);

            }
            else
            {
                MessageBox.Show("لا يمكن نجاز العملية هناك خطأ في الارصدة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtBoxBalance.Text = "";
            txtTotalPrice.Text = "";
            //txtDiscount.Text = "";
            //dtpSaleDate.Value = DateTime.Now;
           
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {

        }

        

        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    bAddSupplier_Click(sender, e);
                }
            }
            catch (Exception ex)
            {

            }
        }

        static Guid id = 0;
        private void bAddSupplier_Click(object sender, EventArgs e)
        {
            Thread t_Table = new Thread(new ThreadStart(StartThreadTable));
             t_Table.Start();
        }

        public void StartThreadTable()
        {
            myDelegate = new AddTable(getTableOpeartion);
            this.Invoke(myDelegate);
        }

       
        public delegate void AddTable();
        public AddTable myDelegate;
        private void getTableOpeartion()
        {
            try
            {
                id = Convert.ToInt32(txtbox.Text.Split('.')[1]);
                DateTime Sdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                boxTableAdapter bata = new boxTableAdapter();
                BoxControllar.boxDataTable cdt = bata.GetBoxById(id);
                BoxControllar.boxRow bar = cdt[0];

                txtBoxBalance.Text = bar["الرصيد"].ToString();

                bondsTableAdapter bta = new bondsTableAdapter();
                Bond.bondsDataTable bdt = bta.getSelectBonds("صندوق." + txtbox.Text, "صندوق." + txtbox.Text);
                int count = bdt.Rows.Count;

                dataGridViewBox.DataSource = bdt;
                dataGridViewBox.Columns["الرصيد"].Visible = false;
                dataGridViewBox.Columns["الرقم"].Visible = false;
                dataGridViewBox.Columns["الرصيد_كتابة"].Visible = false;
                dataGridViewBox.Columns["مرحل"].Visible = false;
                dataGridViewBox.Columns["من"].HeaderText = "ح/مدين";
                dataGridViewBox.Columns["من"].HeaderCell.SortGlyphDirection = SortOrder.None;
                dataGridViewBox.Columns["من"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewBox.Columns["إلى"].HeaderText = "ح/دائن";
                dataGridViewBox.Columns["إلى"].HeaderCell.SortGlyphDirection = SortOrder.None;
                dataGridViewBox.Columns["إلى"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewBox.Columns["ملاحطات"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewBox.Columns["ملاحطات"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dataGridViewBox.Columns["تاريخ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewBox.Columns["تاريخ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dataGridViewBox.DefaultCellStyle.WrapMode = DataGridViewTriState.True;



                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        String debit = bdt.Rows[i]["من"].ToString();
                        String credit = bdt.Rows[i]["إلى"].ToString();
                        if (debit.Split('.')[0] == "صندوق")
                        {
                            dataGridViewBox.Rows[i].Cells["مدين"].Value = bdt.Rows[i]["الرصيد"].ToString();
                            dataGridViewBox.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                            dataGridViewBox.Rows[i].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                        }
                        if (credit.Split('.')[0] == "صندوق")
                        {
                            dataGridViewBox.Rows[i].Cells["دائن"].Value = bdt.Rows[i]["الرصيد"].ToString();
                            dataGridViewBox.Rows[i].DefaultCellStyle.BackColor = Color.Gold;
                            dataGridViewBox.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                            dataGridViewBox.Rows[i].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Underline);
                        }
                        Application.DoEvents();
                    }
                    catch (Exception) { }
                }
            }
            catch { }
        }
    

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTotalPrice.Text == "")
                {
                    totalPriceValue = 0;
                    txtTotalPrice.Text = "0";
                }
                else
                {
                    totalPriceValue = Convert.ToInt32(txtTotalPrice.Text);
                }
                setBond1();
            }
            catch (Exception ex)
            {

            }
        }



        private void txtTotalPrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtTotalPrice.Text == "0")
            {
                errorProvider1.SetError((Control)sender, "المبلغ صفر");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void rbPayment_CheckedChanged(object sender, EventArgs e)
        {
            txtDibetBond.Enabled = true;
            txtCreditBond.Enabled = false;
            txtDibetBond1.Enabled = true;
            txtCreditBond1.Enabled = false;
            setBond1();
           
        }

        private void rpReceive_CheckedChanged(object sender, EventArgs e)
        {
            txtDibetBond.Enabled = false;
            txtCreditBond.Enabled = true;
            txtDibetBond1.Enabled = false;
            txtCreditBond1.Enabled = true;
            setBond1();
        }


        private void txtDibetBond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                setBond1();
            }
        }

        private void txtCreditBond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                setBond1();
            }
        }

        private void txtDibetBond1_TextChanged(object sender, EventArgs e)
        {
            txtDibetBond.Text = txtDibetBond1.Text;
            setBond1();
        }

      

        private void txtCreditBond1_TextChanged(object sender, EventArgs e)
        {
            txtCreditBond.Text = txtCreditBond1.Text;
            setBond1();
        }

        private void miPayBills_Click(object sender, EventArgs e)
        {
            PayBills pb = new PayBills();
            pb.ShowDialog();
        }

        private void miReciveBills_Click(object sender, EventArgs e)
        {
            ReceiveBills rb = new ReceiveBills();
            rb.ShowDialog();
        }

        private void cbComment_CheckedChanged(object sender, EventArgs e)
        {
            txtComent.Enabled = cbComment.Checked;
        }

        private void txtbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bAddSupplier_Click(sender, e);
        }

        private void dataGridViewBox_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
            getTableOpeartion();
        }
        
    }
}
