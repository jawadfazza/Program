using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.CompanyControllarTableAdapters;
using System.IO;
using Program.entity.controllar.CountryControllarTableAdapters;
using Program.entity.controllar;
using System.Text.RegularExpressions;
using Program.Connection;

namespace Program
{
    public partial class NewCompany : Form
    {
        public NewCompany()
        {
            InitializeComponent();
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            start(sender, e);
           // getCountry();
        }

        public void getCompanyInfo()
        {

        }

        public void start(object sender, EventArgs e)
        {
            try
            {
                Connect c = new Connect();
                if (c.TestConnection() == false)
                {
                    if (MessageBox.Show("?هل ترغب بإستعادة النسخة الإحتياطية من قاعدة البيانات", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        bRestoe_Click(sender, e);
                        setCompanyValue();

                    }
                    else
                    {
                        companyTableAdapter cta = new companyTableAdapter();
                        int companyCount = Convert.ToInt32(cta.getCompanyCount());
                        if (companyCount == 0)
                        {
                            saveToolStripButton.Enabled = true;
                            updateToolStripButton1.Enabled = false;
                        }
                        else
                        {
                            saveToolStripButton.Enabled = false;
                            updateToolStripButton1.Enabled = true;
                            setCompanyValue();
                        }
                    }
                }
                else
                {
                    setCompanyValue();

                }
            }
            catch (Exception ex)
            {
                saveToolStripButton.Enabled = true;
                updateToolStripButton1.Enabled = false;
            }
        }

        private void setCompanyValue()
        {
            companyTableAdapter cta = new companyTableAdapter();
            CompanyControllar.companyDataTable cdt = cta.GetData();
            DataRow row = cdt.Rows[0];

             txtName.Text= row["name"].ToString() ;
             txtStreet.Text = row["street"].ToString();
             txtCity.Text = row["city"].ToString();
             cbCountry.Text = row["country"].ToString();
             txtPhone.Text = row["phone"].ToString();
             txtEmail.Text = row["email"].ToString();
             txtWebSite.Text = row["web_site"].ToString();
             pCompanyLogo.ImageLocation = "..\\..\\Image\\Logo\\" + txtName.Text + ".jpg";
        }

        public void getCountry()
        {
            try
            {
                CountryTableAdapter cta = new CountryTableAdapter();
                CountryControllar.CountryDataTable ut = cta.GetData();
                cbCountry.Items.Clear();
                foreach (DataRow row in ut.Rows)
                {
                    cbCountry.Items.Add(row["name"]);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.ShowDialog();
            txtImageFile.Text = openFileDialog1.FileName;
            pCompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pCompanyLogo.ImageLocation = txtImageFile.Text;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtStreet.Text = "";
            txtWebSite.Text = "";
            txtImageFile.Text = "";
            txtEmail.Text = "";
            txtCity.Text = "";
            cbCountry.Text = "";
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حفط معلومات الشركة ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                createDataBase();
                txtSql.LoadFile("..\\..\\Quary\\Table.sql",
                        RichTextBoxStreamType.PlainText);
                Connect c = new Connect();
                c.createTables(txtSql.Text,"");

                companyTableAdapter cta = new companyTableAdapter();
                int companyCount = Convert.ToInt32(cta.getCompanyCount());
                if (companyCount == 0 && txtName.Text != "")
                {
                    byte[] image;
                    FileStream fsr = new FileStream(txtImageFile.Text, FileMode.OpenOrCreate, FileAccess.Read);
                    image = new byte[fsr.Length];
                    fsr.Read(image, 0, image.Length);
                    fsr.Close();
                    //FileStream fsw = new FileStream("..\\..\\Image\\Logo\\" + txtName.Text + ".jpg", FileMode.OpenOrCreate, FileAccess.Write);

                    FileStream fsw = new FileStream("..\\..\\Image\\Logo\\" + txtName.Text + ".jpg", FileMode.OpenOrCreate, FileAccess.Write);
                    fsw.Write(image, 0, image.Length);
                    fsw.Close();

                    cta.Insert(txtName.Text, txtStreet.Text, txtCity.Text, cbCountry.Text, txtPhone.Text,
                    txtEmail.Text, txtWebSite.Text, image, "false", DateTime.Now.AddDays(30));
                    MessageBox.Show("لقد تمت العملية بنجاح", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NewCompany.ActiveForm.Close();
                }
                else
                {
                    MessageBox.Show("لقد تمت العملية بنجاح", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void createDataBase()
        {
            Connect c = new Connect();
            c.createDatabase("Company");
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل اسم الشركة فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void cbCountry_Validating(object sender, CancelEventArgs e)
        {
            if (cbCountry.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل بلد الشركة فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"\S+@\S+\.\S+");
            if(!regex.IsMatch(txtEmail.Text))
            {
                errorProvider1.SetError((Control)sender, "SomeOne@HostName.com");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
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


        private void updateToolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حفط معلومات الشركة ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {

                companyTableAdapter cta = new companyTableAdapter();
                CompanyControllar.companyDataTable cdt = cta.GetData();
                DataRow row = cdt.Rows[0];

                //this code to change the image
                if (txtImageFile.Text != "")
                {
                    File.Delete("..\\..\\Image\\Logo\\" + row["name"] + "jpg");

                    byte[] image;
                    FileStream fsr = new FileStream(txtImageFile.Text, FileMode.OpenOrCreate, FileAccess.Read);
                    image = new byte[fsr.Length];
                    fsr.Read(image, 0, image.Length);
                    fsr.Close();
                    FileStream fsw = new FileStream("..\\..\\Image\\Logo\\" + txtName.Text + ".jpg", FileMode.OpenOrCreate, FileAccess.Write);
                    fsw.Write(image, 0, image.Length);
                    fsw.Close();

                    row["logo"] = image;
                }

                //this code to change the company information
                row["name"] = txtName.Text;
                row["street"] = txtStreet.Text;
                row["city"] = txtCity.Text;
                row["country"] = cbCountry.Text;
                row["phone"] = txtPhone.Text;
                row["email"] = txtEmail.Text;
                row["web_site"] = txtWebSite.Text;

                cta.Update(row);
            }
        }

        private void bRestoe_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (MessageBox.Show("هل تريد إستعادة قاعدة البيانات؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                if (openFileDialog1.FileName != "")
                {
                    Connect c = new Connect();
                    c.RestoreDatabase(openFileDialog1.FileName);
                }
                else
                {
                    MessageBox.Show("قم بتحديد ملف الاستعادة", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }




    }
}
