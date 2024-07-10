using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.CustomerControllarTableAdapters;
using System.Collections;
using Program.entity.controllar.BoxControllarTableAdapters;
using Program.entity.controllar;
using Program.entity.controllar.BankControllarTableAdapters;
using Program.entity.controllar.SupplierControllarTableAdapters;
using Num2Wrd;
using Program.entity.controllar.LiabilityControllarTableAdapters;
using Program.entity.controllar.AssetControllarTableAdapters;
using Program.entity.controllar.PaperReceiveControllarTableAdapters;
using Program.entity.controllar.PaperPayControllarTableAdapters;

namespace Program.entityForm.Bonds
{
    public partial class WritBonds : Form
    {
        public WritBonds()
        {
            InitializeComponent();
        }

        private void WritBonds_Load(object sender, EventArgs e)
        {
            dataGridViewBond.RowCount = 50;
            getBondsAutocomplete();
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

            txtCreditBond.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtDibetBond.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtCreditBond.Items.AddRange(array.ToArray());
            txtDibetBond.Items.AddRange(array.ToArray());
        }

        private void bRemoveBonds_Click(object sender, EventArgs e)
        {
            removeBounds();
        }

        private void removeBounds()
        {
            if (MessageBox.Show("هل تريد حذف القيد ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                foreach (BondControllar value in bcList)
                {
                    dataGridViewBond.Rows[value.indexValue].Cells[0].Value = "";
                    dataGridViewBond.Rows[value.indexValue].Cells[1].Value = "";
                    dataGridViewBond.Rows[value.indexValue].Cells[2].Value = "";
                    dataGridViewBond.Rows[value.indexValue].Cells[3].Value = "";

                    dataGridViewBond.Rows[value.indexValue].ErrorText = "";
                    dataGridViewBond.Rows[value.indexValue].Cells[1].ErrorText = "";
                    dataGridViewBond.Rows[value.indexValue].Cells[2].ErrorText = "";
                    dataGridViewBond.Rows[value.indexValue].DefaultCellStyle.BackColor = Color.White;
                    dataGridViewBond.Rows[value.indexValue].DefaultCellStyle.ForeColor = Color.Black;

                }
                bc = bcList.Find(
                                delegate(BondControllar bcValue)
                                {
                                    return bcValue.indexValue == dataGridViewBond.CurrentRow.Index;
                                });
                bcList.Remove(bc);
                int count = 0;
                foreach (BondControllar value in bcList)
                {
                    value.indexValue = count;
                    bc = value;
                    addNewRow(value.indexValue);
                    count++;
                }
                bc = null;
            }
        }

        private void bAddBond_Click(object sender, EventArgs e)
        {
            if (bc == null)
            {
                setBond();
            }
            else
            {
                updateBonds();
            }
        }

        BondControllar bc;
        List<BondControllar> bcList = new List<BondControllar>();
        NumberToEnglish nte = new NumberToEnglish();
        static int index = 0;
        private void setBond()
        {

            if (txtBalanceBond.Text != "0" && txtDibetBond.Text!="" && txtCreditBond.Text!="")
            {
               bc = new BondControllar();
               bc.indexValue = bcList.Count;
               bc.balance = Convert.ToDouble(txtBalanceBond.Text);
               bc.balanceText = nte.changeNumericToWords(Convert.ToDouble(txtBalanceBond.Text));
               bc.bondFrom = txtDibetBond.Text;
               bc.bondTo = txtCreditBond.Text;
               bc.comment = txtBondsComment.Text;

               bcList.Add(bc);

               index = bcList.Count - 1;
               addNewRow(index);

               txtBalanceBond.Text = "0";
               txtDibetBond.Text = "";
               txtCreditBond.Text = "";
               txtBondsComment.Text = "";
               txtBalanceBond.Focus();

            }
            
             bc=null;
        }

        public void addNewRow(int rowIndex )
        {
            dataGridViewBond.Rows[rowIndex].Cells[0].Value = bc.balance;
            dataGridViewBond.Rows[rowIndex].Cells[1].Value = bc.bondFrom;
            dataGridViewBond.Rows[rowIndex].Cells[2].Value = bc.bondTo;
            dataGridViewBond.Rows[rowIndex].Cells[3].Value = bc.comment;   
            IsBondTrested[0] = CheckBondsError("both", rowIndex).ToString();

        }

        private void bUpdateBonds_Click(object sender, EventArgs e)
        {
            updateBonds();
            
        }

        private void updateBonds()
        {
            if (MessageBox.Show("هل تريد تعديل القيد ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                bc = bcList.Find(
                    delegate(BondControllar bcValue)
                    {
                        return bcValue.indexValue == dataGridViewBond.CurrentRow.Index;
                    });
                bc.balance = Convert.ToDouble(txtBalanceBond.Text);
                bc.balanceText = nte.changeNumericToWords(Convert.ToDouble(txtBalanceBond.Text));
                bc.bondFrom = txtDibetBond.Text;
                bc.bondTo = txtCreditBond.Text;
                bc.comment = txtBondsComment.Text;
                addNewRow(bc.indexValue);


                txtBalanceBond.Text = "0";
                txtDibetBond.Text = "";
                txtCreditBond.Text = "";
                txtBondsComment.Text = "";
                txtBalanceBond.Focus();
                IsBondTrested[0] = CheckBondsError("both", bc.indexValue).ToString();
                bc = null;
            }
        }


        static string[] IsBondTrested = new string[2];
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

        private void txtBondsComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bAddBond_Click(sender, e);
            }
        }

        private void txtCreditBond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bAddBond_Click(sender, e);
            }
        }

        private void txtDibetBond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bAddBond_Click(sender, e);
            }
        }

        private void txtBalanceBond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bAddBond_Click(sender, e);
            }
        }

        private void dataGridViewBond_Click(object sender, EventArgs e)
        {
            GetBond();
        }

        private void dataGridViewBond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                removeBounds();
            }
            else
            {
                GetBond();
            }
        }

        public void GetBond()
        {
            try
            {
                bc = bcList.Find(
                 delegate(BondControllar bcValue)
                 {
                     return bcValue.indexValue == dataGridViewBond.CurrentRow.Index;
                 });
                txtBalanceBond.Text = bc.balance.ToString();
                txtDibetBond.Text = bc.bondFrom;
                txtCreditBond.Text = bc.bondTo;
                txtBondsComment.Text = bc.comment;
                index = dataGridViewBond.CurrentRow.Index;
                //or
                //index = value.indexValue;
            }
            catch (Exception ex)
            {

            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (BondControllar value in bcList)
            {
                dataGridViewBond.Rows[value.indexValue].Cells[0].Value = "";
                dataGridViewBond.Rows[value.indexValue].Cells[1].Value = "";
                dataGridViewBond.Rows[value.indexValue].Cells[2].Value = "";
                dataGridViewBond.Rows[value.indexValue].Cells[3].Value = "";

                dataGridViewBond.Rows[value.indexValue].ErrorText = "";
                dataGridViewBond.Rows[value.indexValue].Cells[1].ErrorText = "";
                dataGridViewBond.Rows[value.indexValue].Cells[2].ErrorText = "";
                dataGridViewBond.Rows[value.indexValue].DefaultCellStyle.BackColor = Color.White;
                dataGridViewBond.Rows[value.indexValue].DefaultCellStyle.ForeColor = Color.Black;

            }
            bcList.Clear();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد إضافة القيود ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                foreach (BondControllar value in bcList)
                {
                     bc = value;
                     bool ok = CheckBondsError("both", bc.indexValue);
                    if (ok)
                    {
                        bc.SaveBonds();
                        dataGridViewBond.Rows[bc.indexValue].DefaultCellStyle.BackColor = Color.MediumSeaGreen;
                        dataGridViewBond.Rows[bc.indexValue].DefaultCellStyle.ForeColor = Color.Gold;
                    }
                    else
                    {
                        dataGridViewBond.Rows[bc.indexValue].DefaultCellStyle.BackColor = Color.OrangeRed;
                        dataGridViewBond.Rows[bc.indexValue].DefaultCellStyle.ForeColor = Color.Black;
                        MessageBox.Show("هناك خطأ في القيد في السطر " + (bc.indexValue + 1).ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {

        }

       
    }
}
