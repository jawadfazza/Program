using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Program.entity.controllar.SupplierControllarTableAdapters;
using Num2Wrd;
using System.Text.RegularExpressions;
using Program.entity.controllar;
using Program.entityForm.Supplier.Report;

namespace Program.entityForm
{
    public partial class NewSupplier : Form
    {
        public NewSupplier()
        {
            InitializeComponent();
        }

        public DataRow supplierRow;
        static int id = 0;
        private void setCustomerValue()
        {
            try
            {
                id = Convert.ToInt32(supplierRow["الرقم"]);
                txtName.Text = supplierRow["اسم_المورد"].ToString();
                txtBalance.Text = supplierRow["الرصيد"].ToString();
                txtBalanceText.Text = supplierRow["الرصيد_كتابة"].ToString();
                txtPlace.Text = supplierRow["عنوان_المورد"].ToString();
                txtPhone.Text = supplierRow["هاتف"].ToString();
                txtMobile.Text = supplierRow["الموبايل"].ToString();
                txtEmail.Text = supplierRow["البريد_الالكتروني"].ToString();
                txtWebSite.Text = supplierRow["الموقع_الالكتروني"].ToString();
                txtSupplierDisc.Text = supplierRow["وصف_المورد"].ToString();
                dtpDate.Value = Convert.ToDateTime(supplierRow["تاريخ"].ToString());
                txtImageFile.Text = supplierRow["صورة"].ToString();
                pSupplierPicture.ImageLocation = txtImageFile.Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtBalance.Text = "0";
            txtBalanceText.Text = "صفر";
            txtPlace.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtWebSite.Text = "";
            txtSupplierDisc.Text = "";
            dtpDate.Value = DateTime.Now;
            txtImageFile.Text = "";
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("هناك بعض الحقول فارغة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("هل تريد حفط المورد ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (txtImageFile.Text != "")
                    {
                        byte[] image;
                        FileStream fsr = new FileStream(txtImageFile.Text, FileMode.OpenOrCreate, FileAccess.Read);
                        image = new byte[fsr.Length];
                        fsr.Read(image, 0, image.Length);
                        fsr.Close();
                        FileStream fsw = new FileStream("..\\..\\Image\\Supplier\\" + txtName.Text + ".jpg", FileMode.OpenOrCreate, FileAccess.Write);
                        fsw.Write(image, 0, image.Length);
                        fsw.Close();
                    }
                    supplierTableAdapter sta = new supplierTableAdapter();
                    sta.Insert(txtName.Text,
                        Convert.ToInt32(txtBalance.Text),
                        txtBalanceText.Text,
                        txtPlace.Text,
                        txtPhone.Text,
                        txtMobile.Text,
                        txtEmail.Text,
                        txtWebSite.Text,
                        dtpDate.Value,
                        txtSupplierDisc.Text,
                        "..\\..\\Image\\Supplier\\" + txtName.Text + ".jpg");
                    MessageBox.Show("تم إضافة الزبون ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getSupplierNameAutocomplete();
                }
            }

        }

        private void getSupplierNameAutocomplete()
        {
            supplierTableAdapter sta = new supplierTableAdapter();
            entity.controllar.SupplierControllar.supplierDataTable sdt = sta.getAutoCompleteSupplierName(txtName.Text);
            string[] array = new string[sdt.Rows.Count];
            int count = 0;
            foreach (DataRow row in sdt.Rows)
            {
                array[count] = row["اسم_المورد"].ToString();
                count++;
            }
            txtNameSearch.Items.Clear();
            txtNameSearch.AutoCompleteCustomSource.AddRange(array);
            txtNameSearch.Items.AddRange(array);
        }

        private void NewSupplier_Load(object sender, EventArgs e)
        {
            supplierTableAdapter sta = new supplierTableAdapter();
            dataGridViewSpplier.DataSource = sta.GetData();
            //supplierRow = new DataRow();
            getSupplierNameAutocomplete();
           // splitContainer2.SplitterDistance = 400;
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

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NumberToEnglish nte = new NumberToEnglish();
                txtBalanceText.Text = nte.changeNumericToWords(Convert.ToInt64(txtBalance.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("error : " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                supplierRow["هاتف"] = txtPhone.Text;
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
            supplierRow["الموبايل"] = txtMobile.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            try{
            supplierRow["البريد_الالكتروني"] = txtEmail.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        private void txtWebSite_TextChanged(object sender, EventArgs e)
        {
            try{
            supplierRow["الموقع_الالكتروني"] = txtWebSite.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        private void txtSupplierDisc_TextChanged(object sender, EventArgs e)
        {
            try{
            supplierRow["وصف_الزبون"] = txtSupplierDisc.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            if (txtImageFile.Text == "")
            {
                openFileDialog1.ShowDialog();
                txtImageFile.Text = openFileDialog1.FileName;
                pSupplierPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                pSupplierPicture.ImageLocation = txtImageFile.Text;
            }
            else
            {
                if (MessageBox.Show("هل تريد تغير صورةالمورد ؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    openFileDialog1.ShowDialog();
                    System.IO.File.Delete(txtImageFile.Text);
                    byte[] image;
                    FileStream fsr = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                    image = new byte[fsr.Length];
                    fsr.Read(image, 0, image.Length);
                    fsr.Close();
                    FileStream fsw = new FileStream("..\\..\\Image\\Supplier\\" + txtName.Text + ".jpg", FileMode.OpenOrCreate, FileAccess.Write);
                    fsw.Write(image, 0, image.Length);
                    fsw.Close();
                }
            }
        }

        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد تعديل بيانات المورد ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    supplierTableAdapter sta = new supplierTableAdapter();
                    sta.Update(supplierRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error : " + ex.Message);
            }
        }

        private void dataGridViewSpplier_Click(object sender, EventArgs e)
        {
            try
            {
                supplierTableAdapter sta = new supplierTableAdapter();
                entity.controllar.SupplierControllar.supplierDataTable cdt = sta.getSupplierById(Convert.ToInt32(dataGridViewSpplier.Rows[dataGridViewSpplier.CurrentRow.Index].Cells[0].Value));
                supplierRow = cdt.Rows[0];
                setCustomerValue();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                supplierTableAdapter cta = new supplierTableAdapter();
                SupplierControllar.supplierDataTable sdt = cta.getAutoCompleteSupplierName(txtNameSearch.Text);
                dataGridViewSpplier.DataSource = sdt;

                supplierRow = sdt.Rows[0];
            }
            catch (Exception ex)
            {

            }
            setCustomerValue();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"\S+@\S+\.\S+");
            if (!regex.IsMatch(txtEmail.Text))
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

        private void txtPlace_TextChanged(object sender, EventArgs e)
        {
            try
            {
                supplierRow["عنوان_المورد"] = txtPlace.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        private void NewSupplier_Resize(object sender, EventArgs e)
        {
            //splitContainer2.SplitterDistance = 400;

        }

        private void miReportSupplierAccounting_Click(object sender, EventArgs e)
        {
            SupplierAccounting sa = new SupplierAccounting();
            sa.ShowDialog();
        }

        private void miMaterialBuy_Click(object sender, EventArgs e)
        {
            SupplierBuy sb = new SupplierBuy();
            sb.ShowDialog();
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            NewSupplier_Load(sender, e);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                supplierRow["اسم_المورد"] = txtName.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد حذف المورد؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    supplierTableAdapter sta = new supplierTableAdapter();
                    sta.DeleteQuery(id);

                    NewSupplier_Load(sender, e);
                    newToolStripButton_Click(sender, e);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("لا يمكن حذف المورد مربوط بسجلات مخزنة في قاعدة البيانات", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("في حال الضرورة يجب إزالة المورد من الجداول المرتبطة بالمورد", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       
    }
}
