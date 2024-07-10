using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.BoxControllarTableAdapters;

namespace Program.entityForm.Box
{
    public partial class NewBox : Form
    {
        public NewBox()
        {
            InitializeComponent();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
        }

        Num2Wrd.NumberToEnglish nte = new Num2Wrd.NumberToEnglish();
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("حقل اسم الصندوق فارغ!!", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("هل تريد حفط ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    boxTableAdapter bta = new boxTableAdapter();
                    bta.Insert(txtName.Text,Convert.ToInt32(txtBoxValue.Text), nte.changeNumericToWords(Convert.ToInt32(txtBoxValue.Text)), DateTime.Now);
                    newToolStripButton_Click(sender, e);
                    MessageBox.Show("  تم إضافة الصندوق  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text!="")
            {
                epInformation.SetError((Control)sender, " يتم إضافة الرصيدالفتتاحي للصندوق من خلال قائمة إضافة و إزالة مبلغ من الصندوق  ");
            }
            else
            {
                epInformation.SetError((Control)sender, "");
            }
        }

        private void NewBox_Load(object sender, EventArgs e)
        {

        }
    }
}
