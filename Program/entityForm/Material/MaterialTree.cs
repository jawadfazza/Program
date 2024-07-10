using Program.entity.controllar;
using Program.entity.controllar.MaterialControllarTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program.entityForm.Material
{
    public partial class MaterialTree : Form
    {
        public MaterialTree()
        {
            InitializeComponent();
        }

        private void MaterialTree_Load(object sender, EventArgs e)
        {
            this.Height = 600;
            getgroupList();
            gbGroubAdd.Hide();
            gbOption.Height = 50;

        }

        private void getgroupList()
        {
            cbGroup.Items.Clear();
            material_groupTableAdapter mgta = new material_groupTableAdapter();
            MaterialControllar.material_groupDataTable mgdt = mgta.GetDataByASC();
            ArrayList array = new ArrayList();
            foreach (DataRow row in mgdt.Rows)
            {
                cbGroup.Items.Add(row["اسم_المجموعة"].ToString() + "." + row["رقم_المجموعة"].ToString());
                array.Add(row["اسم_المجموعة"].ToString() + "." + row["رقم_المجموعة"].ToString());
            }

            //array.Sort();
            cbGroup.Items.Clear();
           // cbGroup.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            cbGroup.Items.AddRange(array.ToArray());
        }

        private void cbGroup_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            materialTableAdapter mta = new materialTableAdapter();
            MaterialControllar.materialDataTable mdt = mta.GetDataByGroub(Convert.ToInt32(cbGroup.Text.Split('.')[1]));
            lbMaterialList.Items.Clear();
            foreach (DataRow row in mdt.Rows)
            {
                lbMaterialList.Items.Add(row["اسم_المادة"].ToString() + "." + row["الرقم_الفني"].ToString());
            }
        }

        private void bAddGroub_Click(object sender, EventArgs e)
        {
            gbGroubAdd.Show();
            gbOption.Height = 150;

        }

        private void bSaveGroub_Click(object sender, EventArgs e)
        {
            material_groupTableAdapter mgta = new material_groupTableAdapter();
            if (txtGroub.Text.Trim() != "")
            {
                if (cbGroup.Items.Contains(txtGroub.Text))
                {
                    MessageBox.Show("المسمى موجودة سابقا!!", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("هل تريد اضافة المجموعة؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        mgta.Insert(cbGroup.Items.Count + 1, txtGroub.Text);
                        getgroupList();

                        MessageBox.Show("تم اضافة المجموعة", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gbGroubAdd.Hide();
                        gbOption.Height = 50;
                    }
                }
            }
            else
            {
                MessageBox.Show("!!!حقل المجموعة فارغ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gbGroubEdit_Enter(object sender, EventArgs e)
        {

        }

        private void bEditGroub_Click(object sender, EventArgs e)
        {
            gbGroubEdit.Show();
            gbGroubAdd.Hide();
            gbOption.Height = 150;
        }

        
    }
}
