using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.Connection;

namespace Program.entityForm.FileData
{
    public partial class BackUp : Form
    {
        public BackUp()
        {
            InitializeComponent();
        }

        private void bRestoe_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد إستعادة قاعدة البيانات؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                if (txtFileSave.Text != "")
                {
                    Connect c = new Connect();
                    c.RestoreDatabase(txtFileSave.Text);
                }
                else
                {
                    MessageBox.Show("قم بتحديد ملف الاستعادة", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtFile.Text = folderBrowserDialog1.SelectedPath;
        }

        private void bBackUp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد إنشاء نقطة إستعادة؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                if (txtFile.Text != "")
                {
                    Connect c = new Connect();
                    c.BackUp(txtFile.Text, Convert.ToInt32(txtNumber.Value));
                }
                else
                {
                    MessageBox.Show("قم بتحديد مكان حفظ الملف", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bBrowse1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtFileSave.Text = openFileDialog1.FileName;
        }
    }
}
