using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.UserControllarTableAdapters;
using Program.entity.controllar;

namespace Program.entityForm.FileData
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            getUserList();
        }

        private void getUserList()
        {
            user_logeTableAdapter ulta = new user_logeTableAdapter();
            UserControllar.user_logeDataTable uldt= ulta.GetData();
            string[] array = new string[uldt.Rows.Count];
            int count = 0;
            foreach (DataRow row in uldt.Rows)
            {
                array[count] = row["username"].ToString();
                //txtUsername.Items.Add(row[""]);
            }
            txtUsername.Items.Clear();
            txtUsername.AutoCompleteCustomSource.AddRange(array);
            txtUsername.Items.AddRange(array);
        }

        private void panel1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (txtUsername.Text == "")
            {
                errorProvider1.SetError((Control)sender, "اسم المستخدم فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text == "")
            {
                errorProvider1.SetError((Control)sender, "كلمة المرور فارغة");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (user_id == 0)
            {
                MessageBox.Show("!!لم يتم إختيار المستخدم", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("هل تريد تعديل مهام المستخدم؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    user_taskTableAdapter utta = new user_taskTableAdapter();
                    utta.DeleteUserTask(user_id);

                    for (int i = 0; i < cbTask.CheckedItems.Count; i++)
                    {
                        utta.Insert(cbTask.CheckedItems[i].ToString(), "true", user_id);
                    }
                    MessageBox.Show("تم إضافة المستخدم", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show(" يجب إضافة بعض المعلومات قبل حفظ المستخدم!!", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (MessageBox.Show("هل تريد اضافة المستخدم؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    user_logeTableAdapter ulta = new user_logeTableAdapter();
                    if (ulta.FindUser(txtUsername.Text) == 0)
                    {
                        ulta.Insert(txtUsername.Text,
                            txtPassword.Text,
                            "user",
                            "true",
                            "false");
                        user_taskTableAdapter utta = new user_taskTableAdapter();
                        Guid id = Convert.ToInt32(ulta.getMaxUserId());
                        for (int i = 0; i < cbTask.CheckedItems.Count; i++)
                        {
                            utta.Insert(cbTask.CheckedItems[i].ToString(), "true", id);
                        }
                        MessageBox.Show("تم إضافة المستخدم", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("إن اسم المستخدم موجود في قاعدة البيانات", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
       
        private void User_Load(object sender, EventArgs e)
        {
            taskTableAdapter tta = new taskTableAdapter();
            if (tta.GetCount() == 0)
            {
                string[] task = new string[] { "بيانات الشركة", "إستيراد البيانات", "ترحيل بيانات العام الحالي", "بداية عام جديد", "المستخدمين" ,
            "إضافة زبون","إضافة طلبية بيع بضاعة","نافذة البيع السريع","تلقي دفعات الزبائن","ردّ بضاعة مباعة","حساب الزبون","بطاقة مبيعات الزبون","فاتورة بيع مواد","تقرير إعادة بضاعة مباعة","تقرير المبيعات",
            "إضافة مورد","إضافة طلبية شراء بضاعة","نافذة الشراء السريع","دفع مبلغ للموردين","ردّ بضاعة مشترات","حساب المورد","بطاقة مشتريات المورد","وثيقة إدخال مواد","تقرير إعادة بضاعة مشترات","تقرير المشتريات",
            "سندات القبض المستحقة","سندات الدفع المستحقة","كمبيالات القبض","كمبيالات الدفع",
            "إضافة صندوق نقدية","دفع أو قبض مبلغ نقدي","حساب الصندوق","أمر دفع نقدي","وصل أستلام نقدية",
            "إضافة بنك","إضافة حساب بنكي","سحب أو يداع مبلغ","حساب الحساب المصرفي","أمر صرف مبلغ","إيداع مبلغ بحساب مصرفي",
            "السلع و الخدمات الجديدة","جردّ بضاعة المستودعات","كلفة المواد الباقية","بطاقة مادة","تقرير جردّ بضاعة المستودع",
            "إضافة أصول أخرى","إضافة إلتزامات أخرى","جدول أهتلاك الأصول الثابتة",
            "إضافة القيود اليومية","جدول القيود المختلفة المرحلة","قائمة الدخل","قائمة التدفقات النقدية","الميزانية العمومية","ميزان المراجعة"};

                for (int i = 0; i <= task.Length; i++)
                {
                    tta.Insert(task[i]);
                }
            }
            miAll_Click(sender, e);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {

        }

        private void miFile_Click(object sender, EventArgs e)
        {
            cbTask.Items.Clear();
            cbTask.Items.Add("بيانات الشركة", CheckState.Unchecked);
            cbTask.Items.Add("إستيراد البيانات", CheckState.Unchecked);
            cbTask.Items.Add("ترحيل بيانات العام الحالي", CheckState.Unchecked);
            cbTask.Items.Add("بداية عام جديد", CheckState.Unchecked);
            cbTask.Items.Add("المستخدمين", CheckState.Unchecked);
        }

        private void miCustomer_Click(object sender, EventArgs e)
        {
            cbTask.Items.Clear();
            cbTask.Items.Add("إضافة زبون", CheckState.Unchecked);
            cbTask.Items.Add("إضافة طلبية بيع بضاعة", CheckState.Unchecked);
            cbTask.Items.Add("نافذة البيع السريع", CheckState.Unchecked);
            cbTask.Items.Add("تلقي دفعات الزبائن", CheckState.Unchecked);
            cbTask.Items.Add("ردّ بضاعة مباعة", CheckState.Unchecked);
            cbTask.Items.Add("حساب الزبون", CheckState.Unchecked);
            cbTask.Items.Add("بطاقة مبيعات الزبون", CheckState.Unchecked);
            cbTask.Items.Add("فاتورة بيع مواد", CheckState.Unchecked);
            cbTask.Items.Add("تقرير إعادة بضاعة مباعة", CheckState.Unchecked);
            cbTask.Items.Add("تقرير المبيعات", CheckState.Unchecked);

        }

        private void miSupplier_Click(object sender, EventArgs e)
        {
            cbTask.Items.Clear();

            cbTask.Items.Add("إضافة مورد", CheckState.Unchecked);
            cbTask.Items.Add("إضافة طلبية شراء بضاعة", CheckState.Unchecked);
            cbTask.Items.Add("نافذة الشراء السريع", CheckState.Unchecked);
            cbTask.Items.Add("دفع مبلغ للموردين", CheckState.Unchecked);
            cbTask.Items.Add("ردّ بضاعة مشترات", CheckState.Unchecked);
            cbTask.Items.Add("حساب المورد", CheckState.Unchecked);
            cbTask.Items.Add("بطاقة مشتريات المورد", CheckState.Unchecked);
            cbTask.Items.Add("وثيقة إدخال مواد", CheckState.Unchecked);
            cbTask.Items.Add("تقرير إعادة بضاعة مشترات", CheckState.Unchecked);
            cbTask.Items.Add("تقرير المشتريات", CheckState.Unchecked);
        }

        private void miPaper_Click(object sender, EventArgs e)
        {
            cbTask.Items.Clear();
            cbTask.Items.Add("سندات القبض المستحقة", CheckState.Unchecked);
            cbTask.Items.Add("سندات الدفع المستحقة", CheckState.Unchecked);
            cbTask.Items.Add("كمبيالات القبض", CheckState.Unchecked);
            cbTask.Items.Add("كمبيالات الدفع", CheckState.Unchecked);

        }

        private void miBox_Click(object sender, EventArgs e)
        {
            cbTask.Items.Clear();

            cbTask.Items.Add("إضافة صندوق نقدية", CheckState.Unchecked);
            cbTask.Items.Add("دفع أو قبض مبلغ نقدي", CheckState.Unchecked);
            cbTask.Items.Add("حساب الصندوق", CheckState.Unchecked);
            cbTask.Items.Add("أمر دفع نقدي", CheckState.Unchecked);
            cbTask.Items.Add("وصل أستلام نقدية", CheckState.Unchecked);
        }

        private void miBank_Click(object sender, EventArgs e)
        {
            cbTask.Items.Clear();

            cbTask.Items.Add("إضافة بنك", CheckState.Unchecked);
            cbTask.Items.Add("إضافة حساب بنكي", CheckState.Unchecked);
            cbTask.Items.Add("سحب أو يداع مبلغ", CheckState.Unchecked);
            cbTask.Items.Add("حساب الحساب المصرفي", CheckState.Unchecked);
            cbTask.Items.Add("أمر صرف مبلغ", CheckState.Unchecked);
            cbTask.Items.Add("إيداع مبلغ بحساب مصرفي", CheckState.Unchecked);
        }

        private void miMaterial_Click(object sender, EventArgs e)
        {
            cbTask.Items.Clear();

            cbTask.Items.Add("السلع و الخدمات الجديدة", CheckState.Unchecked);
            cbTask.Items.Add("جردّ بضاعة المستودعات", CheckState.Unchecked);
            cbTask.Items.Add("كلفة المواد الباقية", CheckState.Unchecked);
            cbTask.Items.Add("بطاقة مادة", CheckState.Unchecked);
            cbTask.Items.Add("تقرير جردّ بضاعة المستودع", CheckState.Unchecked);

        }

        private void miAssets_Click(object sender, EventArgs e)
        {
            cbTask.Items.Clear();
            cbTask.Items.Add("إضافة أصول أخرى", CheckState.Unchecked);
            cbTask.Items.Add("إضافة إلتزامات أخرى", CheckState.Unchecked);
            cbTask.Items.Add("جدول أهتلاك الأصول الثابتة", CheckState.Unchecked);
        }

        private void miAccount_Click(object sender, EventArgs e)
        {
            cbTask.Items.Clear();
            cbTask.Items.Add("إضافة القيود اليومية", CheckState.Unchecked);
            cbTask.Items.Add("جدول القيود المختلفة المرحلة", CheckState.Unchecked);
            cbTask.Items.Add("قائمة الدخل", CheckState.Unchecked);
            cbTask.Items.Add("قائمة التدفقات النقدية", CheckState.Unchecked);
            cbTask.Items.Add("الميزانية العمومية", CheckState.Unchecked);
            cbTask.Items.Add("ميزان المراجعة", CheckState.Unchecked);
        }

        private void miAll_Click(object sender, EventArgs e)
        {
            cbTask.Items.Clear();
            taskTableAdapter utta = new taskTableAdapter();
            UserControllar.taskDataTable utdt= utta.GetData();

            foreach (DataRow row in utdt.Rows)
            {
                cbTask.Items.Add(row["opreation"], CheckState.Unchecked);
            }

        }

        private void txtUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            getUser();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getUser();
            }
        }

        static int user_id=0;
        public void getUser()
        {
            try
            {
                user_logeTableAdapter ulta = new user_logeTableAdapter();
                UserControllar.user_logeDataTable uldt = ulta.GetDataByUsername(txtUsername.Text);
                Guid id = Convert.ToInt32(uldt.Rows[0]["id"]);
                user_id = id;

                user_taskTableAdapter utta = new user_taskTableAdapter();
                UserControllar.user_taskDataTable utdt = utta.GetDataByUserId(id);
                cbTask.Items.Clear();

                taskTableAdapter tta = new taskTableAdapter();
                UserControllar.taskDataTable tdt = tta.GetData();
                bool cheched = false;
                foreach (DataRow rowOpera in tdt.Rows)
                {
                    cheched = false;
                    foreach (DataRow row in utdt.Rows)
                    {
                        if (row["opreation"].ToString() == rowOpera["opreation"].ToString())
                        {
                            cheched = true;
                            break;
                        }
                    }
                    if (cheched)
                    {
                        cbTask.Items.Add(rowOpera["opreation"], CheckState.Checked);
                    }
                    else
                    {
                        cbTask.Items.Add(rowOpera["opreation"], CheckState.Unchecked);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            saveToolStripButton_Click(sender, e);
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            openToolStripButton_Click(sender, e);
        }

        private void bDeleteUser_Click(object sender, EventArgs e)
        {
            if (user_id == 0)
            {
                MessageBox.Show("!!لم يتم إختيار المستخدم", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("هل تريد حذف المستخدم؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    user_taskTableAdapter utta = new user_taskTableAdapter();
                    utta.DeleteUserTask(user_id);
                    user_logeTableAdapter ulta = new user_logeTableAdapter();
                    ulta.DeleteUserById(user_id);

                    user_id = 0;
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    cbTask.Items.Clear();
                    MessageBox.Show("تمت العملية بنجاح", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
