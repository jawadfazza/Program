using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar;
using System.IO;
using Program.entity;
using Program.entityForm.Material.report;
using System.Collections;
using Program.entity.controllar.MaterialMakerControllarTableAdapters;
using Program.entity.controllar.MaterialControllarTableAdapters;

namespace Program.entityForm
{
    public partial class NewMaterialMaker : Form
    {
        public NewMaterialMaker()
        {
           
                InitializeComponent();
                getgroupList();
                getWarehouseList();

                getMaterialNameAutocomplete();

                material_makerTableAdapter mta = new material_makerTableAdapter();
                MaterialMakerControllar.material_makerDataTable mdt = mta.GetData();
                dataGridViewMaterial.DataSource = mdt;
                int count = dataGridViewMaterial.Rows.Count;
                getMaterialTable(count);
           
        }


        private void getMaterialTable(int count)
        {
            

            dataGridViewMaterial.Columns["المجموعة"].Visible = false;
            dataGridViewMaterial.Columns["المستودع"].Visible = false;
            dataGridViewMaterial.Columns["اسم_المادة"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


            for (int i = 0; i < count; i++)
            {
                int quantity=Convert.ToInt32(dataGridViewMaterial.Rows[i].Cells["كمية"].Value);
                if (quantity != 0)
                {
                    dataGridViewMaterial.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                    dataGridViewMaterial.Rows[i].ErrorText = "";

                }
                if (quantity == 0)
                {
                    dataGridViewMaterial.Rows[i].DefaultCellStyle.ForeColor = Color.Goldenrod;
                    dataGridViewMaterial.Rows[i].ErrorText = "إن كمية المادة المحددة صفر";
                }

            }
        }

        private void getgroupList()
        {
            cbGroup.Items.Clear();
            material_groupTableAdapter mgta = new material_groupTableAdapter();
            MaterialControllar.material_groupDataTable mgdt= mgta.GetDataByASC();
            ArrayList array = new ArrayList();
            foreach (DataRow row in mgdt.Rows)
            {
                cbGroup.Items.Add(row["اسم_المجموعة"].ToString() + "." + row["رقم_المجموعة"].ToString());
                array.Add(row["اسم_المجموعة"].ToString() + "." + row["رقم_المجموعة"].ToString());
            }
            
            //array.Sort();
            cbGroup.Items.Clear();
            cbGroup.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            cbGroup.Items.AddRange(array.ToArray());
        }



        private void getWarehouseList()
        {
            cbWarehouse.Items.Clear();
            WareHouseTableAdapter mgta = new WareHouseTableAdapter();
            MaterialControllar.WareHouseDataTable mgdt = mgta.GetDataByASC();
            foreach (DataRow row in mgdt.Rows)
            {
                cbWarehouse.Items.Add(row["اسم_المستودع"].ToString() + "." + row["رقم_المستودع"].ToString());

            }
        }

        private void bGroup_Click(object sender, EventArgs e)
        {
            material_groupTableAdapter mgta = new material_groupTableAdapter();
            if (cbGroup.Text.Trim() != "")
            {
                if (cbGroup.Items.Contains(cbGroup.Text))
                {
                    MessageBox.Show("المسمى موجودة سابقا!!", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("هل تريد اضافة المجموعة؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        mgta.Insert(Guid.NewGuid(), cbGroup.Text);
                        getgroupList();

                        MessageBox.Show("تم اضافة المجموعة", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbGroup.Text = cbGroup.Items[(cbGroup.Items.Count - 1)].ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("!!!حقل المجموعة فارغ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        

        private void bWarehouse_Click(object sender, EventArgs e)
        {
            WareHouseTableAdapter pta = new WareHouseTableAdapter();
            if (cbWarehouse.Text.Trim() != "")
            {
                if (cbWarehouse.Items.Contains(cbWarehouse.Text))
                {
                    MessageBox.Show("المسمى موجودة سابقا!!", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("هل تريد اضافة المستودع؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        pta.Insert(Guid.NewGuid(), cbWarehouse.Text);
                        getWarehouseList();
                        cbWarehouse.Text = "";
                        MessageBox.Show("تم اضافة المستودع", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbWarehouse.Text = cbWarehouse.Items[(cbWarehouse.Items.Count - 1)].ToString();

                    }
                }
            }
            else
            {
                MessageBox.Show("!!!حقل المستودع فارغ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        

        private void NewMaterial_Load(object sender, EventArgs e)
        {
            material_makerTableAdapter mta = new material_makerTableAdapter();
            dataGridViewMaterial.DataSource = mta.GetData();
            int count = dataGridViewMaterial.Rows.Count;
            getMaterialTable(count);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            //material m = new material();
            
            if (txtName.Text == "" || cbGroup.Text=="" || cbWarehouse.Text=="")
            {
                MessageBox.Show(" يجب إضافة بعض المعلومات قبل حفظ البيانات!!", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (MessageBox.Show("هل تريد اضافة المادة الى المستودع؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        material_makerTableAdapter mta = new material_makerTableAdapter();
                        mta.Insert(txtName.Text,
                            txtUint.Text,
                            Convert.ToInt32(txtQuantity.Text),
                            Convert.ToInt32(txtPriceBuy.Text),
                            Convert.ToInt32(txtPriceSale.Text),
                            Convert.ToInt32(cbGroup.Text.Split('.')[1]),
                            Convert.ToInt32(cbWarehouse.Text.Split('.')[1]),
                            txtMaterialCode.Text);

                        MessageBox.Show("تم اضافة المادة", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int count = dataGridViewMaterial.Rows.Count;
                        getMaterialTable(count);

                        getMaterialNameAutocomplete();
                        newToolStripButton_Click(sender, e);
                        bRefreshTable_Click(sender, e);
                        txtName.Focus();
                   }
                    catch (Exception ex)
                    {
                        MessageBox.Show("erorr : " + ex.Message, "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }


        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == "0")
            {
                errorProvider2.SetError((Control)sender, "المادة سعرها صفر");
            }
            else
            {
                errorProvider2.SetError((Control)sender, "");
            }
        }

        static DataRow materialRow;
        private void txtSearchMaterial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSearchType.Text == "اسم المادة")
                {
                    material_makerTableAdapter mta = new material_makerTableAdapter();
                    MaterialMakerControllar.material_makerDataTable mdt = mta.getMaterialByName(txtSearchMaterial.Text);
                    
                    dataGridViewMaterial.DataSource = mdt;
                    int count = dataGridViewMaterial.Rows.Count;
                    getMaterialTable(count);
                    setMaterialValue(mdt.Rows[0]);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : "+ex.Message);
            }
            
        }

        private void setMaterialValue(DataRow material)
        {
            txtId.Text = material["الرقم"].ToString();
            txtName.Text = material["اسم_المادة"].ToString();
            txtUint.Text = material["الوحدة"].ToString();
            txtQuantity.Text = material["كمية"].ToString();
            txtMaterialCode.Text = material["كود_المادة"].ToString();
            txtPriceBuy.Text = material["الكلفة"].ToString();
            txtPriceSale.Text = material["سعر_البيع"].ToString();
            cbWarehouse.Text = cbWarehouse.Items[(Convert.ToInt32(material["المستودع"]))-1].ToString();
            cbGroup.Text = cbGroup.Items[(Convert.ToInt32(material["المجموعة"]))-1].ToString();
            

           /* material_makerTableAdapter mta = new material_makerTableAdapter();
            MaterialMakerControllar.material_makerDataTable mdt = mta.getMaterialTableById(Convert.ToInt32(material["الرقم_الفني"]));
            materialRow = mdt.Rows[0]; */          
        }

        private void dataGridViewMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                material_makerTableAdapter mta = new material_makerTableAdapter();
                MaterialMakerControllar.material_makerDataTable mdt = mta.getMaterialById(Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[0].Value));
                setMaterialValue(mdt.Rows[0]);
            }
            catch (Exception ex)
            {

            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtUint.Text = "عدد";
            txtQuantity.Text = "0";
            txtPriceBuy.Text = "0";
            txtPriceSale.Text = "0";
            cbGroup.Text = "";
            txtMaterialDiscr.Text = "";
            txtMaterialCode.Text = "";
        }

        static int index_dataGridViewMain = 0;
        private void bNext_Click(object sender, EventArgs e)
        {
            try
            {
                index_dataGridViewMain++;
                dataGridViewMaterial.Rows[index_dataGridViewMain].Selected = true;

                material_makerTableAdapter mta = new material_makerTableAdapter();
                MaterialMakerControllar.material_makerDataTable mdt = mta.getMaterialById(Convert.ToInt32(dataGridViewMaterial.Rows[index_dataGridViewMain].Cells[0].Value));
               // txtId.Text = dataGridViewMaterial.Rows[index_dataGridViewMain].Cells[0].Value.ToString();
                setMaterialValue(mdt.Rows[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error  :  " + ex.Message);
                index_dataGridViewMain = -1;
            }
        }

        private void pPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                index_dataGridViewMain--;
                dataGridViewMaterial.Rows[index_dataGridViewMain].Selected = true;

                material_makerTableAdapter mta = new material_makerTableAdapter();
                MaterialMakerControllar.material_makerDataTable mdt = mta.getMaterialById(Convert.ToInt32(dataGridViewMaterial.Rows[index_dataGridViewMain].Cells[0].Value));
               // txtId.Text = dataGridViewMaterial.Rows[index_dataGridViewMain].Cells[0].Value.ToString();
                setMaterialValue(mdt.Rows[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error  :  " + ex.Message);
                index_dataGridViewMain = 0;
            }
        }

        private void NewMaterial_Resize(object sender, EventArgs e)
        {

        }

        private void miMaterialCard_Click(object sender, EventArgs e)
        {
            MaterialCard mc = new MaterialCard();
            mc.ShowDialog();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                materialRow["اسم_المادة"] = txtName.Text;
                if (txtName.Text == "")
                {
                    errorProvider1.SetError((Control)sender, "حقل اسم العميل فارغ");
                }
                else
                {
                    errorProvider1.SetError((Control)sender, "");
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtPleace_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtUint_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                materialRow["الوحدة"] = txtUint.Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPriceBuy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                materialRow["سعر_الشراء"] = txtPriceBuy.Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void txtPriceSale_TextChanged(object sender, EventArgs e)
        {
            try
            {
                materialRow["سعر_البيع"] = txtPriceSale.Text;
            }
            catch (Exception)
            {

            }
        }

        private void txtMaterialCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                materialRow["كود_المادة"] = txtMaterialCode.Text;
            }
            catch (Exception)
            {

            }
        }

        private void cbProduct_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMaterialDiscr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                materialRow["وصف_المادة"] = txtMaterialDiscr.Text;
            }
            catch (Exception)
            {

            }
        }

        private void cbTrash_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show(" يجب إضافة بعض المعلومات قبل تعديل البيانات!!", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (MessageBox.Show("هل تريد تعديل المادة؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        material_makerTableAdapter mta = new material_makerTableAdapter();
                        mta.Update(materialRow);

                        MessageBox.Show("تم تعديل المادة", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewMaterial_Click(sender, e);
                        int count = dataGridViewMaterial.Rows.Count;
                        getMaterialTable(count);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("erorr : " + ex.Message, "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }

        }

        private void bRefreshTable_Click(object sender, EventArgs e)
        {
            material_makerTableAdapter mmta = new material_makerTableAdapter();
            MaterialMakerControllar.material_makerDataTable mmdt = mmta.GetData();
            dataGridViewMaterial.DataSource = mmdt;
            int count = dataGridViewMaterial.Rows.Count;
            getMaterialTable(count);

        }

        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSearchType.Text == "اسم المادة")
                {
                    getMaterialNameAutocomplete();
                }
                if (cbSearchType.Text == "كود المادة")
                {
                    getMaterialCodeAutocomplete();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }

        }

        public void getMaterialNameAutocomplete()
        {
            try
            {
                material_makerTableAdapter mta = new material_makerTableAdapter();
                MaterialMakerControllar.material_makerDataTable mdt = mta.GetData();
                ArrayList array = new ArrayList();
                foreach (DataRow row in mdt.Rows)
                {
                    if (row["اسم_المادة"].ToString() != "")
                    {
                        array.Add(row["اسم_المادة"].ToString());
                    }
                }
                array.Sort();
                txtName.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));

                txtSearchMaterial.Items.Clear();
                txtSearchMaterial.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
                txtSearchMaterial.Items.AddRange(array.ToArray());
                
            }
            catch (Exception ex)
            {

            }
        }


        public void getMaterialCodeAutocomplete()
        {
            material_makerTableAdapter mta = new material_makerTableAdapter();
            MaterialMakerControllar.material_makerDataTable mdt = mta.GetData();
            ArrayList array = new ArrayList();
            foreach (DataRow row in mdt.Rows)
            {
                if (row["كود_المادة"].ToString() != "")
                {
                    array.Add(row["كود_المادة"].ToString());
                }
            }
            array.Sort();
            txtSearchMaterial.Items.Clear();
            txtSearchMaterial.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtSearchMaterial.Items.AddRange(array.ToArray());
        }

        private void cbGroup_Validating(object sender, CancelEventArgs e)
        {
            if (cbGroup.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل مجموعة المادة فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void cbProduct_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void cbWarehouse_Validating(object sender, CancelEventArgs e)
        {
            if (cbWarehouse.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل مستودع المادة فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            saveToolStripButton_Click(sender, e);
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            openToolStripButton_Click(sender, e);
        }

        private void dataGridViewMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void dataGridViewMaterial_KeyUp(object sender, KeyEventArgs e)
        { 
            try
            {
                material_makerTableAdapter mta = new material_makerTableAdapter();
                MaterialMakerControllar.material_makerDataTable mdt = mta.getMaterialById(Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[0].Value));
                materialRow = mdt.Rows[0];
                setMaterialValue(materialRow);
            }
            catch (Exception ex)
            {

            }

        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                materialRow["المجموعة"] = cbGroup.Text.Split('.')[1];
            }
            catch (Exception)
            {

            }
        }

        private void cbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                materialRow["المستودع"] = cbWarehouse.Text.Split('.')[1];
            }
            catch (Exception)
            {

            }
        }

        
    }
}
