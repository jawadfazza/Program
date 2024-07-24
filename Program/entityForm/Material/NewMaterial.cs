using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.MaterialControllarTableAdapters;
using Program.entity.controllar;
using System.IO;
using Program.entity;
using Program.entityForm.Material.report;
using System.Collections;
using System.IO.Ports;
using System.Threading;

namespace Program.entityForm
{
    public partial class NewMaterial : Form
    {
        public NewMaterial()
        {
           
                InitializeComponent();
                getgroupList();
                getProdectList();
                getWarehouseList();

                getMaterialNameAutocomplete();

                materialTableAdapter mta = new materialTableAdapter();
                MaterialControllar.materialDataTable mdt = mta.GetData();
                dataGridViewMaterial.DataSource = mdt;
                int count = dataGridViewMaterial.Rows.Count;
                getMaterialTable(count);
           
        }


        private void getMaterialTable(int count)
        {
            try
            {
                // Use a HashSet for O(1) lookup times when hiding columns
                var columnsToHide = new HashSet<string>
        {
            "المجموعة", "الصانع", "بالة", "المستودع", "صورة", "فرق_السعر",
            "فرق_الكمية", "DiscountPersent", "Discount", "Comment", "TotalValue",
            "رمز_الطراز", "وصف_المادة"
        };

                // Hide unnecessary columns
                foreach (DataGridViewColumn column in dataGridViewMaterial.Columns)
                {
                    column.Visible = !columnsToHide.Contains(column.Name);
                }

                // Adjust specific column properties
                if (dataGridViewMaterial.Columns.Contains("اسم_المادة"))
                {
                    dataGridViewMaterial.Columns["اسم_المادة"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }

                // Prepare colors outside of the loop
                var colorGreen = Color.Green;
                var colorGoldenrod = Color.Goldenrod;
                var colorRed = Color.Red;

                // Loop through each row and apply formatting based on quantity
                for (int i = 0; i < count; i++)
                {
                    var row = dataGridViewMaterial.Rows[i];
                    var cell = row.Cells["كمية"];

                    if (cell?.Value != null && int.TryParse(cell.Value.ToString(), out int quantity))
                    {
                        if (quantity != 0)
                        {
                            row.DefaultCellStyle.ForeColor = colorGreen;
                            row.ErrorText = string.Empty;
                        }
                        else
                        {
                            row.DefaultCellStyle.ForeColor = colorGoldenrod;
                            row.ErrorText = "إن كمية المادة المحددة صفر";
                        }
                    }
                    else
                    {
                        // Handle the case where the "كمية" cell does not contain a valid value
                        row.DefaultCellStyle.ForeColor = colorRed;
                        row.ErrorText = "الكمية غير محددة أو غير صحيحة";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while setting up the material table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void getProdectList()
        {
            cbProduct.Items.Clear();
            producerTableAdapter mgta = new producerTableAdapter();
            MaterialControllar.producerDataTable mgdt = mgta.GetDataByASC();
            ArrayList array = new ArrayList();

            foreach (DataRow row in mgdt.Rows)
            {
                cbProduct.Items.Add(row["اسم_الصانع"].ToString() + "." + row["رقم_الصانع"].ToString());
                array.Add(row["اسم_الصانع"].ToString() + "." + row["رقم_الصانع"].ToString());

            }

            //array.Sort();
            cbProduct.Items.Clear();
            cbProduct.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            cbProduct.Items.AddRange(array.ToArray());
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

                        mgta.Insert(cbGroup.Items.Count + 1, cbGroup.Text);
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

        private void bProduct_Click(object sender, EventArgs e)
        {
            producerTableAdapter pta = new producerTableAdapter();
            if (cbProduct.Text.Trim() != "")
            {
                if (cbProduct.Items.Contains(cbProduct.Text))
                {
                    MessageBox.Show("المسمى موجودة سابقا!!", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("هل تريد اضافة الصانع؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        pta.Insert(cbProduct.Items.Count + 1, cbProduct.Text, "");
                        getProdectList();
                        cbProduct.Text = "";
                        MessageBox.Show("تم اضافة الصانع", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbProduct.Text = cbProduct.Items[(cbProduct.Items.Count - 1)].ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("!!!حقل الصانع فارغ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                        pta.Insert(cbWarehouse.Items.Count + 1, cbWarehouse.Text);
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
            materialTableAdapter mta = new materialTableAdapter();
            dataGridViewMaterial.DataSource = mta.GetData();
            int count = dataGridViewMaterial.Rows.Count;
            getMaterialTable(count);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            //material m = new material();

            if (txtName.Text == "" || txtPrice.Text == "0" || cbGroup.Text == "" || cbProduct.Text == "" || cbWarehouse.Text == "")
            {
                MessageBox.Show(" يجب إضافة بعض المعلومات قبل حفظ البيانات!!", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (materialRow == null)
                {
                    if (MessageBox.Show("هل تريد اضافة المادة الى المستودع؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            materialTableAdapter mta = new materialTableAdapter();
                            mta.Insert(txtName.Text,
                                txtPleace.Text,
                                txtUint.Text,
                                Convert.ToInt32(txtQuantity.Text),
                                Convert.ToDouble(txtPrice.Text),
                                txtType.Text,
                                Convert.ToInt32(cbGroup.Text.Split('.')[1]),
                                Convert.ToInt32(cbProduct.Text.Split('.')[1]),
                                cbTrash.Checked.ToString(),
                                Convert.ToInt32(cbWarehouse.Text.Split('.')[1]),
                                 txtMaterialDiscr.Text,
                                 "..\\..\\Image\\Material\\" + txtName.Text + ".jpg",
                                 0,
                                 0,
                                Convert.ToInt32(txtPriceBuy.Text),
                                Convert.ToInt32(txtPriceSale.Text),
                                 txtMaterialCode.Text,
                                 cbWayOut.Text);


                            if (txtImageFile.Text != "")
                            {
                                //File.Delete(txtImageFile.Text);
                                byte[] image;
                                FileStream fsr = new FileStream(txtImageFile.Text, FileMode.OpenOrCreate, FileAccess.Read);
                                image = new byte[fsr.Length];
                                fsr.Read(image, 0, image.Length);
                                fsr.Close();
                                FileStream fsw = new FileStream("..\\..\\Image\\Material\\" + txtName.Text + ".jpg", FileMode.OpenOrCreate, FileAccess.Write);
                                fsw.Write(image, 0, image.Length);
                                fsw.Close();
                            }

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
                            MessageBox.Show("هناك خطأ حيث لم يتم إضافة المجموعة أو الصانع أو المستودع", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                }
                else
                {
                    if (txtName.Text == "" || txtPrice.Text == "0")
                    {
                        MessageBox.Show(" يجب إضافة بعض المعلومات قبل تعديل البيانات!!", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        if (MessageBox.Show("هل تريد تعديل المادة؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                materialTableAdapter mta = new materialTableAdapter();
                                mta.Update(materialRow);

                                MessageBox.Show("تم تعديل المادة", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try
            {
                if (txtImageFile.Text == "")
                {
                    openFileDialog1.ShowDialog();
                    txtImageFile.Text = openFileDialog1.FileName;
                    pMaterialPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    pMaterialPicture.ImageLocation = txtImageFile.Text;
                }
                else
                {
                    if (MessageBox.Show("هل تريد إضافة للمادة ؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        openFileDialog1.ShowDialog();
                        materialTableAdapter mta = new materialTableAdapter();
                        //int id = Convert.ToInt32(mta.getMaxId());
                        System.IO.File.Delete(txtName.Text);
                        byte[] image;
                        FileStream fsr = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                        image = new byte[fsr.Length];
                        fsr.Read(image, 0, image.Length);
                        fsr.Close();
                        FileStream fsw = new FileStream("..\\..\\Image\\Material\\" + txtName.Text + ".jpg", FileMode.OpenOrCreate, FileAccess.Write);
                        fsw.Write(image, 0, image.Length);
                        fsw.Close();
                        pMaterialPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                        pMaterialPicture.ImageLocation = "..\\..\\Image\\Material\\" + txtName.Text + ".jpg";

                        materialRow["صورة"] = "..\\..\\Image\\Material\\" + txtName.Text + ".jpg";
                        mta.Update(materialRow);
                        MessageBox.Show("تم إضافة الصورة", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {

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
                    materialTableAdapter mta = new materialTableAdapter();
                    MaterialControllar.materialDataTable mdt = mta.getMaterialByName(txtSearchMaterial.Text);
                    
                    dataGridViewMaterial.DataSource = mdt;
                    int count = dataGridViewMaterial.Rows.Count;
                    getMaterialTable(count);
                    setMaterialValue(mdt.Rows[0]);
                }
                if (cbSearchType.Text == "كود المادة")
                {
                    materialTableAdapter mta = new materialTableAdapter();
                    MaterialControllar.materialDataTable mdt = mta.getMaterialByCode(txtSearchMaterial.Text);
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
            txtId.Text = material["الرقم_الفني"].ToString();
            txtName.Text = material["اسم_المادة"].ToString();
            txtPleace.Text = material["تواجد_المادة"].ToString();
            txtUint.Text = material["الوحدة"].ToString();
            txtQuantity.Text = material["كمية"].ToString();
            txtPrice.Text = material["سعر"].ToString();
            txtPriceBuy.Text = material["سعر_الشراء"].ToString();
            txtPriceSale.Text = material["سعر_البيع"].ToString();
            txtType.Text = material["رمز_الطراز"].ToString();
            cbWarehouse.Text = material["اسم_المستودع"].ToString();
            cbProduct.Text = material["اسم_الصانع"].ToString();
            cbGroup.Text = material["اسم_المجموعة"].ToString();
            txtMaterialDiscr.Text = material["وصف_المادة"].ToString();
            cbTrash.Checked = Convert.ToBoolean(material["بالة"]);
            cbWayOut.Text = material["طريقة_حساب_الكلفة"].ToString();

            if (material["صورة"].ToString() != "")
            {
                txtImageFile.Text = material["صورة"].ToString();
            }
            else
            {
                txtImageFile.Text = "قم بإضافة صورة للمادة";
            }
            pMaterialPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pMaterialPicture.ImageLocation = txtImageFile.Text;
            txtMaterialCode.Text = material["كود_المادة"].ToString();

           materialTableAdapter mta = new materialTableAdapter();
            MaterialControllar.materialDataTable mdt = mta.getMaterialTableById(Convert.ToInt32(material["الرقم_الفني"]));
            materialRow = mdt.Rows[0];            

        }

        private void dataGridViewMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                materialTableAdapter mta = new materialTableAdapter();
                MaterialControllar.materialDataTable mdt = mta.getMaterialById(Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[0].Value));
                setMaterialValue(mdt.Rows[0]);
            }
            catch (Exception ex)
            {

            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPleace.Text = "";
            txtUint.Text = "عدد";
            txtQuantity.Text = "0";
            txtPrice.Text = "0";
            txtPriceBuy.Text = "0";
            txtPriceSale.Text = "0";
            txtType.Text = "";
            //cbWarehouse.Text = "";
            cbProduct.Text = "";
            cbGroup.Text = "";
            txtMaterialDiscr.Text = "";
            txtImageFile.Text = "";
            txtMaterialCode.Text = "";
            //txtImageFile.Text = ""; 
        }

        static int index_dataGridViewMain = 0;
        private void bNext_Click(object sender, EventArgs e)
        {
            try
            {
                index_dataGridViewMain++;
                dataGridViewMaterial.Rows[index_dataGridViewMain].Selected = true;

                materialTableAdapter mta = new materialTableAdapter();
                MaterialControllar.materialDataTable mdt = mta.getMaterialById(Convert.ToInt32(dataGridViewMaterial.Rows[index_dataGridViewMain].Cells[0].Value));
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

                materialTableAdapter mta = new materialTableAdapter();
                MaterialControllar.materialDataTable mdt = mta.getMaterialById(Convert.ToInt32(dataGridViewMaterial.Rows[index_dataGridViewMain].Cells[0].Value));
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

       

        private void bRefreshTable_Click(object sender, EventArgs e)
        {
            materialTableAdapter mta = new materialTableAdapter();
            MaterialControllar.materialDataTable mdt = mta.GetData();
            dataGridViewMaterial.DataSource = mdt;
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
            /*try
            {*/
                materialTableAdapter mta = new materialTableAdapter();
                MaterialControllar.materialDataTable mdt = mta.GetData();
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
                
            /*}
            catch (Exception ex)
            {

            }*/
        }


        public void getMaterialCodeAutocomplete()
        {
            materialTableAdapter mta = new materialTableAdapter();
            MaterialControllar.materialDataTable mdt = mta.GetData();
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
            if (cbProduct.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل صانع المادة فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
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

      

        private void dataGridViewMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void dataGridViewMaterial_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                materialTableAdapter mta = new materialTableAdapter();
                MaterialControllar.materialDataTable mdt = mta.getMaterialById(Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[0].Value));
                materialRow = mdt.Rows[0];
                setMaterialValue(materialRow);
            }
            catch (Exception ex)
            {

            }

        }

        private void bGetCode_Click(object sender, EventArgs e)
        {
            //// bar code Start
            StartBarCode();
          
        }

        SerialPort _serialPort;

        // delegate is used to write to a UI control from a non-UI thread
        private delegate void SetTextDeleg(string text);
        public void StartBarCode()
        {
            try
            {
                // all of the options for a serial device
                // can be sent through the constructor of the SerialPort class
                // PortName = "COM1", Baud Rate = 19200, Parity = None, 
                // Data Bits = 8, Stop Bits = One, Handshake = None
                _serialPort = new SerialPort("COM1", 19200, Parity.None, 8, StopBits.One);
                _serialPort.Handshake = Handshake.None;
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;
                _serialPort.Open();

            }
            catch (Exception)
            {

            }
        }

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
            string data = _serialPort.ReadLine();
            this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
        }

        private void si_DataReceived(string data)
        {
            txtMaterialCode.Text = data.Trim();
        }
    }
}
