using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Program.entity.controllar.CustomerControllarTableAdapters;
using Num2Wrd;
using System.Linq;

namespace Program.entityForm
{
    public partial class NewCustomer : Form
    {
        private DataRow customerRow;
        private static int id = 0;
        private int numberToCompute = 0;
        private int highestPercentageReached = 100;

        public NewCustomer()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                save_Click(this, new EventArgs());
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (!ValidateFormInputs())
            {
                MessageBox.Show("يرجى تصحيح الأخطاء المميزة والمحاولة مرة أخرى..", "خطئ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (customerRow == null)
            {
                if (MessageBox.Show("هل تريد حفظ الزبون ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    SaveCustomerImage();

                    customerTableAdapter cta = new customerTableAdapter();
                    cta.Insert(txtName.Text,
                        Convert.ToInt32(txtBalance.Text),
                        txtBalanceText.Text,
                        txtPlace.Text,
                        txtPhone.Text,
                        txtMobile.Text,
                        txtEmail.Text,
                        txtWebSite.Text,
                        dtpDate.Value,
                        txtCustomerDisc.Text,
                        "..\\..\\Image\\Customer\\" + txtName.Text + ".jpg");

                    MessageBox.Show("تم إضافة الزبون ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getCustomerNameAutocomplete();
                    NewCustomer_Load(sender, e);
                }
            }
            else
            {
                if (MessageBox.Show("هل تريد تعديل بيانات الزبون ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        customerTableAdapter cta = new customerTableAdapter();

                        customerRow["اسم_الربون"] = txtName.Text;
                        customerRow["عنوان_الربون"] = txtPlace.Text;
                        customerRow["هاتف"] = txtPhone.Text;
                        customerRow["الموبايل"] = txtMobile.Text;
                        customerRow["البريد_الالكتروني"] = txtEmail.Text;
                        customerRow["الموقع_الالكتروني"] = txtWebSite.Text;
                        customerRow["وصف_الربون"] = txtCustomerDisc.Text;
                        customerRow["تاريخ"] = dtpDate.Value;
                        customerRow["صورة"] = txtImageFile.Text;

                        cta.Update(customerRow);
                        MessageBox.Show("تم تعديل بيانات الزبون ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NewCustomer_Load(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("error : " + ex.Message);
                    }
                }
            }
        }

        private bool ValidateFormInputs()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "حقل اسم العميل فارغ");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtName, "");
            }

            if (!Regex.IsMatch(txtEmail.Text, @"\S+@\S+\.\S+"))
            {
                errorProvider1.SetError(txtEmail, "SomeOne@HostName.com");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }

            if (!Regex.IsMatch(txtWebSite.Text, @"www\.\S+\.\S+"))
            {
                errorProvider2.SetError(txtWebSite, "example : www.hostname.com");
                isValid = false;
            }
            else
            {
                errorProvider2.SetError(txtWebSite, "");
            }

            return isValid;
        }


        private void bBrowse_Click(object sender, EventArgs e)
        {
            if (txtImageFile.Text == "")
            {
                OpenFileAndDisplayImage();
            }
            else if (MessageBox.Show("هل تريد تغيير صورة الزبون ؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                ReplaceCustomerImage();
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void NewCustomer_Load(object sender, EventArgs e)
        {
            customerTableAdapter cta = new customerTableAdapter();
            dataGridView1.DataSource = cta.GetData();
            getCustomerNameAutocomplete();
        }

        public void getCustomerNameAutocomplete()
        {
            customerTableAdapter cta = new customerTableAdapter();
            var cdt = cta.getCustomerAutocomplete(txtName.Text);
            var array = cdt.Rows.OfType<DataRow>().Select(row => row["اسم_الربون"].ToString()).ToArray();

            txtNameSearch.Items.Clear();
            txtNameSearch.AutoCompleteCustomSource.AddRange(array);
            txtNameSearch.Items.AddRange(array);
        }

        private void setCustomerValue()
        {
            if (customerRow == null) return;

            id = Convert.ToInt32(customerRow["الرقم"]);
            txtName.Text = customerRow["اسم_الربون"].ToString();
            txtBalance.Text = customerRow["الرصيد"].ToString();
            txtBalanceText.Text = customerRow["الرصيد_كتابة"].ToString();
            txtPlace.Text = customerRow["عنوان_الربون"].ToString();
            txtPhone.Text = customerRow["هاتف"].ToString();
            txtMobile.Text = customerRow["الموبايل"].ToString();
            txtEmail.Text = customerRow["البريد_الالكتروني"].ToString();
            txtWebSite.Text = customerRow["الموقع_الالكتروني"].ToString();
            txtCustomerDisc.Text = customerRow["وصف_الربون"].ToString();
            dtpDate.Value = Convert.ToDateTime(customerRow["تاريخ"].ToString());
            txtImageFile.Text = customerRow["صورة"].ToString();
            pCustomerPicture.ImageLocation = txtImageFile.Text;
        }

       

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                customerTableAdapter cta = new customerTableAdapter();
                var cdt = cta.getCustomerById(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                customerRow = cdt.Rows[0];
                setCustomerValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error : " + ex.Message);
            }
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                customerTableAdapter cta = new customerTableAdapter();
                var cdt = cta.getCustomerAutocomplete(txtNameSearch.Text);
                dataGridView1.DataSource = cdt;
                if (cdt.Rows.Count > 0)
                {
                    customerRow = cdt.Rows[0];
                    setCustomerValue();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error : " + ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            e.Result = ComputeFibonacci((int)e.Argument, worker, e);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                resultLabel.Text = "Canceled";
            }
            else
            {
                resultLabel.Text = e.Result.ToString();
            }
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }

        long ComputeFibonacci(int n, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (n < 0 || n > 91) throw new ArgumentException("value must be >= 0 and <= 91", "n");

            long result = 0;
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                if (n < 2) result = 1;
                else result = ComputeFibonacci(n - 1, worker, e) + ComputeFibonacci(n - 2, worker, e);

                int percentComplete = (int)((float)n / (float)numberToCompute * 100);
                if (percentComplete > highestPercentageReached)
                {
                    highestPercentageReached = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
            }
            return result;
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            NewCustomer_Load(sender, e);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف الزبون؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    customerTableAdapter sta = new customerTableAdapter();
                    sta.DeleteQuery(id);
                    NewCustomer_Load(sender, e);
                    newToolStripButton_Click(sender, e);
                }
                catch (Exception)
                {
                    MessageBox.Show("لا يمكن حذف الزبون مربوط بسجلات مخزنة في قاعدة البيانات", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show("في حال الضرورة يجب إزالة الزبون من الجداول المرتبطة بالزبون", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void SaveCustomerImage()
        {
            if (!string.IsNullOrEmpty(txtImageFile.Text))
            {
                byte[] image;
                using (var fsr = new FileStream(txtImageFile.Text, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    image = new byte[fsr.Length];
                    fsr.Read(image, 0, image.Length);
                }

                using (var fsw = new FileStream($"..\\..\\Image\\Customer\\{txtName.Text}.jpg", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fsw.Write(image, 0, image.Length);
                }
            }
        }

        private void OpenFileAndDisplayImage()
        {
            openFileDialog1.ShowDialog();
            txtImageFile.Text = openFileDialog1.FileName;
            pCustomerPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pCustomerPicture.ImageLocation = txtImageFile.Text;
        }

        private void ReplaceCustomerImage()
        {
            openFileDialog1.ShowDialog();
            System.IO.File.Delete(txtImageFile.Text);
            byte[] image;
            using (var fsr = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                image = new byte[fsr.Length];
                fsr.Read(image, 0, image.Length);
            }

            using (var fsw = new FileStream($"..\\..\\Image\\Customer\\{txtName.Text}.jpg", FileMode.OpenOrCreate, FileAccess.Write))
            {
                fsw.Write(image, 0, image.Length);
            }
        }

        private void ResetForm()
        {
            customerRow = null;
            txtName.Text = "";
            txtBalance.Text = "0";
            txtBalanceText.Text = "صفر";
            txtPlace.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtWebSite.Text = "";
            txtCustomerDisc.Text = "";
            dtpDate.Value = DateTime.Now;
            txtImageFile.Text = "";
        }

       

      
    }
}
