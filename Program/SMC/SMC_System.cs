using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.SMC.EntityControllar.BD_SMCDataSetTableAdapters;
using Program.SMC.EntityControllar;

namespace Program.SMC
{
    public partial class SMC_System : Form
    {
        public SMC_System()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            GetSystemData();
            GetTableData();
        }

        /// <summary>
        /// جلب بيانات جدول الجداول
        /// </summary>
        private void GetTableData()
        {
            GA_TableTableAdapter sta = new GA_TableTableAdapter();
            dgv_Tab.DataSource = sta.GetData();
        }

        /// <summary>
        /// جلب بيانات الأنظمة
        /// </summary>
        private void GetSystemData()
        {
            GA_SystemTableAdapter sta = new GA_SystemTableAdapter();
            dgv_System.DataSource = sta.GetData();
        }

        private void tsb_New_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// الحفظ المتعدد للبيانات
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_Save_Click(object sender, EventArgs e)
        {
            int index = tc_Contant.SelectedIndex;
            
            if (index == 0)
            {
                if (MessageBox.Show("هل تريد حفظ النظام؟", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    saveSystem();
                }
            }
            if (index == 1)
            {
                if (MessageBox.Show("هل تريد حفظ الجدول؟", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    saveTable();
                }
            }
            if (MessageBox.Show("هل تريد حفظ الشاشة؟", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                SaveScreen();
            }
        }

        /// <summary>
        /// حفظ الشاشات الجديدة
        /// </summary>
        private void SaveScreen()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// حفظ جداول النظام بترتيب معين
        /// 
        /// </summary>
        private void saveTable()
        {
            try
            {
                GA_TableTableAdapter tta = new GA_TableTableAdapter();
                BD_SMCDataSet.GA_TableDataTable tda = tta.GetData();
                int index=1;
                foreach (DataRow row in tda.Rows)
                {
                    if (Convert.ToInt32(txt_Tab_Sequence.Value) == index)
                    {
                        tta.Insert(txt_Tab_Name.Text,
                    Convert.ToInt32(cb_Sys_Id_Table.SelectedValue),
                    Convert.ToInt32(txt_Tab_Sequence.Value),
                    txt_Tab_Script_Local.Text,
                    txt_Tab_Script_Net.Text);
                    }
                    if (Convert.ToInt32(txt_Tab_Sequence.Value) > index)
                    {
                        row["Tab_Sequence"] = Convert.ToInt32(row["Tab_Sequence"]) + 1;
                        tta.Update(row);
                    }
                    index++;
                }
                
                MessageBox.Show("نجاح عملية الحفظ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("فشل عملية الحفظ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        ///  حفظ معلومات نظام جديد
        /// </summary>
        private void saveSystem()
        {
            int active=0;
            try
            {
                //التحقق من فعالية النظام
                if (cb_Sys_Active.Checked)
                {
                    active = 1;
                }
                else
                {
                    active = 0;
                }
                GA_SystemTableAdapter sta = new GA_SystemTableAdapter();
                sta.Insert(Convert.ToInt32(txt_Sys_Number.Value), txt_Sys_Name.Text, txt_Sys_Note.Text,active );
                GetSystemData();
                MessageBox.Show("نجاح عملية الحفظ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) {
                MessageBox.Show("فشل عملية الحفظ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsb_Edit_Click(object sender, EventArgs e)
        {
            int index = tc_Contant.SelectedIndex;
            if (index == 0)
            {
                if (MessageBox.Show("هل تريد تعديل النظام؟", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    EditSystem();
                }
            }
            if (index == 1)
            {
                if (MessageBox.Show("هل تريد تعديل الجدول؟", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    EditTable();
                }
            }
        }

        /// <summary>
        /// التعديل على الجداول
        /// </summary>
        private void EditTable()
        {
            try
            {
                GA_TableTableAdapter tta = new GA_TableTableAdapter();
                BD_SMCDataSet.GA_TableDataTable tdt = tta.GetData();
                int index = 1;

                TableRow["Tab_Name"] = txt_Tab_Name.Text;
                TableRow["Sys_Id"] = cb_Sys_Id_Table.SelectedValue;
                 TableRow["Tab_Script_Net"] = txt_Tab_Script_Net.Text;
                 TableRow["Tab_Script_Local"] = txt_Tab_Script_Local.Text;
                if (Convert.ToInt32(txt_Tab_Sequence.Value) != Convert.ToInt32(TableRow["Tab_Sequence"]))
                {
                    TableRow["Tab_Sequence"] = txt_Tab_Sequence.Value;
                }
                else
                {
                    foreach (DataRow row in tdt.Rows)
                    {
                        if (Convert.ToInt32(txt_Tab_Sequence.Value) > index)
                        {
                            row["Tab_Sequence"] = Convert.ToInt32(row["Tab_Sequence"]) + 1;
                            tta.Update(row);
                        }
                        index++;
                    }
                }
                tta.Update(TableRow);

                MessageBox.Show("نجاح عملية الحفظ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("فشل عملية الحفظ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        /// <summary>
        /// التعديل على النظام
        /// </summary>
        private void EditSystem()
        {
            int active = 0;
            try
            {
                //التحقق من فعالية النظام
                if (cb_Sys_Active.Checked)
                {
                    active = 1;
                }
                else
                {
                    active = 0;
                }
                GA_SystemTableAdapter sta = new GA_SystemTableAdapter();
                SystemRow["Sys_Name"] = txt_Sys_Name.Text;
                SystemRow["Sys_Num"] = Convert.ToInt32(txt_Sys_Number.Value);
                SystemRow["Sys_NOTe"] = txt_Sys_Note.Text;
                SystemRow["Sys_Active"] = active;

                sta.Update(SystemRow);

                GetSystemData();
                MessageBox.Show("نجاح عملية التعديل", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("فشل عملية التعديل", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsb_Delete_Click(object sender, EventArgs e)
        {
            int index = tc_Contant.SelectedIndex;
            if (index == 0)
            {
                if (MessageBox.Show("هل تريد حذف النظام؟", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    DeleteSystem();
                }
            }
            if (index == 1)
            {
                if (MessageBox.Show("هل تريد حذف الجدول؟", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    DeleteTable();
                }
            }
        }

        private void DeleteTable()
        {
            GA_TableTableAdapter tta = new GA_TableTableAdapter();
            tta.Delete(Convert.ToInt32(dgv_Tab.Rows[dgv_Tab.CurrentRow.Index].Cells[0].Value));
        }

        private void DeleteSystem()
        {
            GA_SystemTableAdapter sta = new GA_SystemTableAdapter();
            sta.DeleteBySys_Id(Convert.ToInt32(dgv_System.Rows[dgv_System.CurrentRow.Index].Cells[0].Value));
        }

        private void dgv_System_KeyPress(object sender, KeyPressEventArgs e)
        {
            GetSystemRow();
        }
        private void dgv_System_Click(object sender, EventArgs e)
        {
            GetSystemRow();
        }

        static DataRow SystemRow = null;
        /// <summary>
        /// جلب معلومات سطر النظام
        /// </summary>
        private void GetSystemRow()
        {
            try
            {
                int ID = Convert.ToInt32(dgv_System.Rows[dgv_System.CurrentRow.Index].Cells[0].Value);
                GA_SystemTableAdapter sta = new GA_SystemTableAdapter();
                BD_SMCDataSet.GA_SystemDataTable sdt = sta.GetDataBySys_Id(ID);
                SystemRow = sdt[0];

                txt_Sys_Name.Text = SystemRow["Sys_Name"].ToString();
                txt_Sys_Number.Value = Convert.ToInt32(SystemRow["Sys_Num"]); 
                txt_Sys_Note.Text = SystemRow["Sys_NOTe"].ToString()  ;
                if (Convert.ToInt32(SystemRow["Sys_Active"]) == 1)
                {
                    cb_Sys_Active.Checked = true;
                }
                else
                {
                    cb_Sys_Active.Checked = false;
                }
            }
            catch (Exception) { }

        }

        private void dgv_Tab_KeyPress(object sender, KeyPressEventArgs e)
        {
            GetTableValue();
        }

        private void dgv_Tab_Click(object sender, EventArgs e)
        {
            GetTableValue();
        }

        static DataRow TableRow = null;
        /// <summary>
        /// جلب معلومات سطر الجدول 
        /// </summary>
        private void GetTableValue()
        {
            try
            {
                int ID = Convert.ToInt32(dgv_Tab.Rows[dgv_Tab.CurrentRow.Index].Cells[0].Value);
                GA_TableTableAdapter tta = new GA_TableTableAdapter();
                BD_SMCDataSet.GA_TableDataTable tdt = tta.GetDataByTab_Id(ID);
                TableRow = tdt[0];

                txt_Tab_Name.Text = TableRow["Tab_Name"].ToString();
                cb_Sys_Id_Table.SelectedValue = TableRow["Sys_Id"].ToString();
                txt_Tab_Sequence.Value = Convert.ToInt32(TableRow["Tab_Sequence"]);
                txt_Tab_Script_Net.Text = TableRow["Tab_Script_Net"].ToString();
                txt_Tab_Script_Local.Text = TableRow["Tab_Script_Local"].ToString();
               
            }
            catch (Exception) { }
        }

        private void SMC_System_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bD_SMCDataSet.GA_Group' table. You can move, or remove it, as needed.
            this.gA_GroupTableAdapter.Fill(this.bD_SMCDataSet.GA_Group);
            // TODO: This line of code loads data into the 'bD_SMCDataSet.GA_System' table. You can move, or remove it, as needed.
            this.gA_SystemTableAdapter.Fill(this.bD_SMCDataSet.GA_System);

        }

        private void b_Groub_Click(object sender, EventArgs e)
        {

        }

        private void b_Scrn_Image_Click(object sender, EventArgs e)
        {

        }

       
    }
        
}
