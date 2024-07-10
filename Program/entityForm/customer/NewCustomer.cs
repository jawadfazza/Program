using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.CustomerControllarTableAdapters;
using Num2Wrd;
using System.Text.RegularExpressions;
using System.IO;

namespace Program.entityForm
{
    public partial class NewCustomer : Form
    {
        public NewCustomer()
        {
            InitializeComponent();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حفط الزبون ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (txtImageFile.Text != "")
                {
                    byte[] image;
                    FileStream fsr = new FileStream(txtImageFile.Text, FileMode.OpenOrCreate, FileAccess.Read);
                    image = new byte[fsr.Length];
                    fsr.Read(image, 0, image.Length);
                    fsr.Close();
                    FileStream fsw = new FileStream("..\\..\\Image\\Customer\\" + txtName.Text + ".jpg", FileMode.OpenOrCreate, FileAccess.Write);
                    fsw.Write(image, 0, image.Length);
                    fsw.Close();
                }

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

        private void bBrowse_Click(object sender, EventArgs e)
        {
            if (txtImageFile.Text == "")
            {
                openFileDialog1.ShowDialog();
                txtImageFile.Text = openFileDialog1.FileName;
                pCustomerPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                pCustomerPicture.ImageLocation = txtImageFile.Text;
            }
            else
            {
                if (MessageBox.Show("هل تريد تغير صورةالزبون ؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    openFileDialog1.ShowDialog();
                    System.IO.File.Delete(txtImageFile.Text);
                    byte[] image;
                    FileStream fsr = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                    image = new byte[fsr.Length];
                    fsr.Read(image, 0, image.Length);
                    fsr.Close();
                    FileStream fsw = new FileStream("..\\..\\Image\\Customer\\" + txtName.Text + ".jpg", FileMode.OpenOrCreate, FileAccess.Write);
                    fsw.Write(image, 0, image.Length);
                    fsw.Close();
                }
            }
            
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(numberToCompute);
            
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

        private void NewCustomer_Load(object sender, EventArgs e)
        {
            customerTableAdapter cta = new customerTableAdapter();
            dataGridView1.DataSource = cta.GetData();

            
            getCustomerNameAutocomplete();
            InitializeBackgroundWorker();

        }

        public void getCustomerNameAutocomplete()
        {
            customerTableAdapter cta = new customerTableAdapter();
            entity.controllar.CustomerControllar.customerDataTable cdt= cta.getCustomerAutocomplete(txtName.Text);
            string[] array = new string[cdt.Rows.Count];
            int count = 0;
            foreach (DataRow row in cdt.Rows)
            {
                array[count] = row["اسم_الربون"].ToString();
                count++;
            }
            txtNameSearch.Items.Clear();
            txtNameSearch.AutoCompleteCustomSource.AddRange(array);
            txtNameSearch.Items.AddRange(array);
        }

        

        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد تعديل بيانات الزبون ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    customerTableAdapter cta = new customerTableAdapter();
                    cta.Update(customerRow);
                    MessageBox.Show("تم تعديل بيانات الزبون ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NewCustomer_Load(sender, e);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("error : "+ex.Message );
            }
        }

        
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                customerRow["اسم_الربون"] = txtName.Text;
            }
            catch (Exception ex)
            {

            }
        }

        public DataRow customerRow;
        static int id = 0;
        private void setCustomerValue()
        {
            try
            {
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
            catch (Exception ex)
            {

            }
        }

        private void txtPlace_TextChanged(object sender, EventArgs e)
        {
            try
            {
                customerRow["عنوان_الربون"] = txtPlace.Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                customerRow["هاتف"] = txtPhone.Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            try
            {
                customerRow["الموبايل"] = txtMobile.Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                customerRow["البريد_الالكتروني"] = txtEmail.Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void txtWebSite_TextChanged(object sender, EventArgs e)
        {
            try
            {
                customerRow["الموقع_الالكتروني"] = txtWebSite.Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void txtCustomerDisc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                customerRow["وصف_الربون"] = txtCustomerDisc.Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                customerTableAdapter cta = new customerTableAdapter();
                entity.controllar.CustomerControllar.customerDataTable cdt = cta.getCustomerById(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                customerRow = cdt.Rows[0];
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
                customerTableAdapter cta = new customerTableAdapter();
                entity.controllar.CustomerControllar.customerDataTable cdt = cta.getCustomerAutocomplete(txtNameSearch.Text);
                dataGridView1.DataSource = cdt;

                customerRow = cdt.Rows[0];
            }
            catch (Exception ex)
            {
                
            }
            setCustomerValue();
        }


        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
            e.Result = ComputeFibonacci((int)e.Argument, worker, e);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                resultLabel.Text = "Canceled";
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                resultLabel.Text = e.Result.ToString();
            }
        }

        private void InitializeBackgroundWorker()
        {
            /*backgroundWorker1.DoWork +=
                new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker1_ProgressChanged);*/
        }

        private int numberToCompute = 0;
        private int highestPercentageReached = 100;
        long ComputeFibonacci(int n, BackgroundWorker worker, DoWorkEventArgs e)
        {
            // The parameter n must be >= 0 and <= 91.
            // Fib(n), with n > 91, overflows a long.
            if ((n < 0) || (n > 91))
            {
                throw new ArgumentException(
                    "value must be >= 0 and <= 91", "n");
            }

            long result = 0;

            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                if (n < 2)
                {
                    result = 1;
                }
                else
                {
                    result = ComputeFibonacci(n - 1, worker, e) +
                             ComputeFibonacci(n - 2, worker, e);
                }

                // Report progress as a percentage of the total task.
                int percentComplete =
                    (int)((float)n / (float)numberToCompute * 100);
                if (percentComplete > highestPercentageReached)
                {
                    highestPercentageReached = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
            }

            return result;
        }

        private void NewCustomer_Resize(object sender, EventArgs e)
        {

        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            NewCustomer_Load(sender, e);
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            saveToolStripButton_Click(sender, e);
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            editToolStripButton_Click(sender, e);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد حذف الزبون؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    customerTableAdapter sta = new customerTableAdapter();
                    sta.DeleteQuery(id);

                    NewCustomer_Load(sender, e);
                    newToolStripButton_Click(sender, e);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("لا يمكن حذف الزبون مربوط بسجلات مخزنة في قاعدة البيانات", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("في حال الضرورة يجب إزالة الزبون من الجداول المرتبطة بالزبون", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
