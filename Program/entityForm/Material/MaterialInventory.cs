using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar;
using Program.entity.controllar.MaterialControllarTableAdapters;

namespace Program.entityForm.Material
{
    public partial class MaterialInventory : Form
    {
        public MaterialInventory()
        {
            InitializeComponent();
            bSave.Enabled = false;

        }

        private void MaterialInventory_Resize(object sender, EventArgs e)
        {
            //splitContainer1.SplitterDistance = 850;
        }

        private void MaterialInventory_Load(object sender, EventArgs e)
        {
            getWarehouseList();
        }

        private void getWarehouseList()
        {
            WareHouseTableAdapter wta = new WareHouseTableAdapter();
            MaterialControllar.WareHouseDataTable wdt = wta.GetData();
            foreach (DataRow dr in wdt.Rows)
            {
                comboBoxWarehouse.Items.Add(dr["اسم_المستودع"] + "." + dr["رقم_المستودع"]);
            }
        }



        List<DataRow> materialList = null;
        private void bRefresh_Click(object sender, EventArgs e)
        {
           refreshTable();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حفط البيانات؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                materialTableAdapter mta = new materialTableAdapter();
                foreach (DataRow row in materialList)
                {
                    mta.Update(row);
                }
                MessageBox.Show("تم الحفط","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        public void refreshTable()
        {
            bSave.Enabled = false;
            materialList = new List<DataRow>();
            materialList.Clear();
            materialTableAdapter mta = new materialTableAdapter();
            MaterialControllar.materialDataTable mdt = mta.getMaterialByWarehouse(Convert.ToInt32(comboBoxWarehouse.Text.Split('.')[1]));

            dataGridViewMaterial.RowCount = (mdt.Rows.Count);
            int rowCount = 0;
            foreach (DataRow m in mdt.Rows)
            {
                dataGridViewMaterial.Rows[rowCount].Cells[0].Value = m["الرقم_الفني"];
                dataGridViewMaterial.Rows[rowCount].Cells[1].Value = m["اسم_المادة"];
                dataGridViewMaterial.Rows[rowCount].Cells[2].Value = "0";
                dataGridViewMaterial.Rows[rowCount].Cells[3].Value = "0";
                dataGridViewMaterial.Rows[rowCount].Cells[4].Value = "0";
                dataGridViewMaterial.Rows[rowCount].Cells[5].Value = "0";
                //dataGridViewMaterial.Rows[rowCount].Cells[6].Value = "";
                materialList.Add(m);
                rowCount++;
            }

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridViewMaterial_KeyUp(object sender, KeyEventArgs e)
        {
            getSelectedMaterial();
        }

        static DataRow MaterialSelected;
        private void getSelectedMaterial()
        {
            try
            {
                MaterialSelected = materialList.Find(
                           delegate(DataRow row)
                           {
                               return dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[0].Value.ToString().Trim() == row["الرقم_الفني"].ToString().Trim();
                           });
                txtId.Text = MaterialSelected["الرقم_الفني"].ToString();
                txtName.Text = MaterialSelected["اسم_المادة"].ToString();
                txtPlace.Text = MaterialSelected["تواجد_المادة"].ToString();
                txtQuantity.Text = MaterialSelected["كمية"].ToString();
                txtPrice.Text = MaterialSelected["سعر"].ToString();
                txtUnit.Text = MaterialSelected["الوحدة"].ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridViewMaterial_Click(object sender, EventArgs e)
        {
            getSelectedMaterial();
        }

        private void dataGridViewMaterial_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            bSave.Enabled = true;
            try
            {
                MaterialSelected = materialList.Find(
                delegate(DataRow row)
                {
                    return dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[0].Value.ToString().Trim() == row["الرقم_الفني"].ToString().Trim();
                });

                int quantity = Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[2].Value.ToString());
                int price = Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[3].Value.ToString());
                if (quantity != 0)
                {
                    quantity = quantity - Convert.ToInt32(MaterialSelected["كمية"]);
                    MaterialSelected["فرق_الكمية"] = quantity;
                    dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[4].Value = MaterialSelected["فرق_الكمية"];


                } if (price != 0)
                {
                    price = price - Convert.ToInt32(MaterialSelected["سعر"]);
                    MaterialSelected["فرق_السعر"] = price;
                    dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[5].Value = MaterialSelected["فرق_السعر"];
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void comboBoxWarehouse_TextChanged(object sender, EventArgs e)
        {
            refreshTable();
        }
           
    }
}
