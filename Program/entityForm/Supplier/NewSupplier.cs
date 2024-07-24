using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Program.entity.controllar.SupplierControllarTableAdapters;
using Num2Wrd;
using System.Linq;

namespace Program.entityForm
{
    public partial class NewSupplier: Form
    {
        private DataRow SupplierRow;
        private static int id = 0;
        private int numberToCompute = 0;
        private int highestPercentageReached = 100;

        public NewSupplier()
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
                MessageBox.Show("يرجى تصحيح الأخطاء المميزة والمحاولة مرة أخرى.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SupplierRow == null)
            {
                if (MessageBox.Show("هل تريد حفظ المورد؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    SaveSupplier();
                }
            }
            else
            {
                if (MessageBox.Show("هل تريد تعديل بيانات المورد؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    UpdateSupplier();
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
                errorProvider2.SetError(txtWebSite, "example: www.hostname.com");
                isValid = false;
            }
            else
            {
                errorProvider2.SetError(txtWebSite, "");
            }

            return isValid;
        }

        private void SaveSupplier()
        {
            try
            {
                supplierTableAdapter cta = new supplierTableAdapter();
                cta.Insert(txtName.Text,
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

                MessageBox.Show("تم إضافة المورد", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getSupplierNameAutocomplete();
                NewSupplier_Load(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSupplier()
        {
            try
            {
                supplierTableAdapter cta = new supplierTableAdapter();
                SupplierRow["اسم_المورد"] = txtName.Text;
                SupplierRow["عنوان_المورد"] = txtPlace.Text;
                SupplierRow["هاتف"] = txtPhone.Text;
                SupplierRow["الموبايل"] = txtMobile.Text;
                SupplierRow["البريد_الالكتروني"] = txtEmail.Text;
                SupplierRow["الموقع_الالكتروني"] = txtWebSite.Text;
                SupplierRow["وصف_المورد"] = txtSupplierDisc.Text;
                SupplierRow["تاريخ"] = dtpDate.Value;
                //SupplierRow["صورة"] = txtImageFile.Text;

                cta.Update(SupplierRow);

                MessageBox.Show("تم تعديل بيانات المورد", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewSupplier_Load(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void NewSupplier_Load(object sender, EventArgs e)
        {
            LoadSupplierData();
            getSupplierNameAutocomplete();
        }

        private void LoadSupplierData()
        {
            supplierTableAdapter cta = new supplierTableAdapter();
            dataGridView1.DataSource = cta.GetData();
            dataGridView1.Columns["البريد_الالكتروني"].Visible = false;
            dataGridView1.Columns["الموقع_الالكتروني"].Visible = false;

            dataGridView1.Columns["وصف_المورد"].Visible = false;
            dataGridView1.Columns["صورة"].Visible = false;

        }

        private void getSupplierNameAutocomplete()
        {
            supplierTableAdapter cta = new supplierTableAdapter();
            var cdt = cta.getAutoCompleteSupplierName(txtName.Text);
            var array = cdt.Rows.OfType<DataRow>().Select(row => row["اسم_المورد"].ToString()).ToArray();

            txtNameSearch.Items.Clear();
            txtNameSearch.AutoCompleteCustomSource.AddRange(array);
            txtNameSearch.Items.AddRange(array);
        }

        private void setSupplierValue()
        {
            if (SupplierRow == null) return;

            id = Convert.ToInt32(SupplierRow["الرقم"]);
            txtName.Text = SupplierRow["اسم_المورد"].ToString();
            txtBalance.Text = SupplierRow["الرصيد"].ToString();
            txtBalanceText.Text = SupplierRow["الرصيد_كتابة"].ToString();
            txtPlace.Text = SupplierRow["عنوان_المورد"].ToString();
            txtPhone.Text = SupplierRow["هاتف"].ToString();
            txtMobile.Text = SupplierRow["الموبايل"].ToString();
            txtEmail.Text = SupplierRow["البريد_الالكتروني"].ToString();
            txtWebSite.Text = SupplierRow["الموقع_الالكتروني"].ToString();
            txtSupplierDisc.Text = SupplierRow["وصف_المورد"].ToString();
            dtpDate.Value = Convert.ToDateTime(SupplierRow["تاريخ"].ToString());
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                supplierTableAdapter cta = new supplierTableAdapter();
                var cdt = cta.getSupplierById(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                SupplierRow = cdt.Rows[0];
                setSupplierValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                supplierTableAdapter cta = new supplierTableAdapter();
                var cdt = cta.getAutoCompleteSupplierName(txtNameSearch.Text);
                dataGridView1.DataSource = cdt;

                if (cdt.Rows.Count > 0)
                {
                    SupplierRow = cdt.Rows[0];
                    setSupplierValue();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private long ComputeFibonacci(int n, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (n < 0 || n > 91) throw new ArgumentException("Value must be >= 0 and <= 91", nameof(n));

            long result = 0;

            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                if (n < 2) result = 1;
                else result = ComputeFibonacci(n - 1, worker, e) + ComputeFibonacci(n - 2, worker, e);

                int percentComplete = (int)((float)n / numberToCompute * 100);
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
            NewSupplier_Load(sender, e);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف المورد؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    supplierTableAdapter sta = new supplierTableAdapter();
                    sta.DeleteQuery(id);
                    NewSupplier_Load(sender, e);
                    newToolStripButton_Click(sender, e);
                }
                catch (Exception)
                {
                    MessageBox.Show("لا يمكن حذف المورد مربوط بسجلات مخزنة في قاعدة البيانات", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show("في حال الضرورة يجب إزالة المورد من الجداول المرتبطة بالمورد", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ResetForm()
        {
            SupplierRow = null;
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
        }
    }
}
