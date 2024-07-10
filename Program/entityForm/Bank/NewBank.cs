using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.BankControllarTableAdapters;
using System.Text.RegularExpressions;

namespace Program.entityForm
{
    public partial class NewBank : Form
    {
        public NewBank()
        {
            InitializeComponent();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPlace.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtWebSite.Text = "";
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            
            if (txtName.Text == "")
            {
                MessageBox.Show("هناك بعض الحقول فارغة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("هل تريد حفط البنك ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    bank_detailsTableAdapter bdta = new bank_detailsTableAdapter();
                    bdta.Insert(txtName.Text,
                        txtPlace.Text,
                        txtPhone.Text,
                        txtMobile.Text,
                        txtEmail.Text,
                        txtWebSite.Text,"");
                    MessageBox.Show("تم إضافة البنك ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getBankDetialsList();
                }
            }
        }

        private void NewBank_Load(object sender, EventArgs e)
        {
            getBankDetialsList();

        }

        private void getBankDetialsList()
        {
            try
            {
                bank_detailsTableAdapter bdta = new bank_detailsTableAdapter();
                dataGridViewBank.DataSource = bdta.GetData();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل اسم العميل فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }
        public static DataRow bankRow ;
        private void txtPlace_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bankRow["عنوان_البنك"] = txtPlace.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bankRow["هاتف"] = txtPhone.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bankRow["الموبايل"] = txtMobile.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bankRow["البريد_الالكتروني"] = txtEmail.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"\S+@\S+\.\S+");
            if (!regex.IsMatch(txtEmail.Text))
            {
                errorProvider2.SetError((Control)sender, "SomeOne@HostName.com");
            }
            else
            {
                errorProvider2.SetError((Control)sender, "");
            }
        }

        private void txtWebSite_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bankRow["الموقع_الالكتروني"] = txtWebSite.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        private void txtWebSite_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"www\.\S+\.\S+");
            if (!regex.IsMatch(txtWebSite.Text))
            {
                errorProvider2.SetError((Control)sender, "example : www.hostname.com");
            }
            else
            {
                errorProvider2.SetError((Control)sender, "");
            }
        }

        private void dataGridViewBank_Click(object sender, EventArgs e)
        {
            try
            {
                bank_detailsTableAdapter bdta = new bank_detailsTableAdapter();
                entity.controllar.BankControllar.bank_detailsDataTable cdt = bdta.getBankById(Convert.ToInt32(dataGridViewBank.Rows[dataGridViewBank.CurrentRow.Index].Cells[0].Value));
                bankRow = cdt.Rows[0];
                setBankValue();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        private void setBankValue()
        {
            txtName.Text = bankRow["اسم_البنك"].ToString();
            txtPlace.Text = bankRow["عنوان_البنك"].ToString();
            txtPhone.Text = bankRow["هاتف"].ToString();
            txtMobile.Text = bankRow["الموبايل"].ToString();
            txtEmail.Text = bankRow["البريد_الالكتروني"].ToString();
            txtWebSite.Text = bankRow["الموقع_الالكتروني"].ToString();
        }

        private void dataGridViewBank_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                bank_detailsTableAdapter bdta = new bank_detailsTableAdapter();
                entity.controllar.BankControllar.bank_detailsDataTable cdt = bdta.getBankById(Convert.ToInt32(dataGridViewBank.Rows[dataGridViewBank.CurrentRow.Index].Cells[0].Value));
                bankRow = cdt.Rows[0];
                setBankValue();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("هناك بعض الحقول فارغة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    bank_detailsTableAdapter bdta = new bank_detailsTableAdapter();
                    bdta.Update(bankRow);
                    getBankDetialsList();
                    MessageBox.Show("تم تعديل معلومات البنك ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }
        
    }
}
