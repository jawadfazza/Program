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
using ComponentFactory.Krypton.Toolkit;  //this for styling tool

namespace Program.entityForm
{
    public partial class NewMaterial : KryptonForm   //to apply the styling tool
    {
        public NewMaterial()
        {
            InitializeComponent();
            getgroupList();
            getProdectList();
            getWarehouseList();
            getMaterialNameAutocomplete();
        }

        private int pageSize = 10; // Number of records per page
        private int currentPage = 1;
        private DataTable originalDataTable;
        static DataRow materialRow;

        #region Form Events
        private void NewMaterial_Shown(object sender, EventArgs e)
        {
            LoadData();
        }

        private void bRefreshTable_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < GetTotalPages())
            {
                currentPage++;
                LoadData();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (ValidateInputFields())
            {
                if (materialRow == null)
                {
                    AddMaterial();
                }
                else
                {
                    UpdateMaterial();
                }
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            materialRow = null;
            txtName.Text = "";
            txtPleace.Text = "";
            txtUint.Text = "عدد";
            txtQuantity.Text = "0";
            txtPrice.Text = "0";
            txtPriceBuy.Text = "0";
            txtPriceSale.Text = "0";
            txtType.Text = "";
            cbWarehouse.Text = "";
            cbProduct.Text = "";
            cbGroup.Text = "";
            txtMaterialDiscr.Text = "";
            txtImageFile.Text = "";
            txtMaterialCode.Text = "";
            txtImageFile.Text = "";
        }

        private void dataGridViewMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                int globalIndex = (currentPage - 1) * pageSize + dataGridViewMaterial.CurrentRow.Index;
                materialRow = originalDataTable.Rows[globalIndex];
                setMaterialValue(materialRow);
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void dataGridViewMaterial_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int globalIndex = (currentPage - 1) * pageSize + dataGridViewMaterial.CurrentRow.Index;
                materialRow = originalDataTable.Rows[globalIndex];
                setMaterialValue(materialRow);
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                Console.WriteLine("Error: " + ex.Message);
            }
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
                // Handle exception
            }
        }

        private void txtSearchMaterial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<DataRow> filteredRows = null;

                if (cbSearchType.Text == "اسم المادة")
                {
                    filteredRows = originalDataTable.AsEnumerable()
                                                    .Where(row => row.Field<string>("اسم_المادة")
                                                    .Contains(txtSearchMaterial.Text));
                }
                else if (cbSearchType.Text == "كود المادة")
                {
                    filteredRows = originalDataTable.AsEnumerable()
                                                    .Where(row => row.Field<string>("كود_المادة")
                                                    .Contains(txtSearchMaterial.Text));
                }

                if (filteredRows != null)
                {
                    var filteredTable = filteredRows.CopyToDataTable();
                    dataGridViewMaterial.DataSource = filteredTable;
                    int count = dataGridViewMaterial.Rows.Count;
                    TableStyle(count);

                    if (count > 0)
                    {
                        setMaterialValue(filteredTable.Rows[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }
        #endregion

        #region Data Loading and Binding

        private void LoadData()
        {
            using (var context = new AccountingEntities())
            {

                var materials = (from material1 in context.material
                                 join group1 in context.material_group on material1.المجموعة equals group1.رقم_المجموعة
                                 join producer1 in context.producer on material1.الصانع equals producer1.رقم_الصانع
                                 join warehouse1 in context.WareHouse on material1.المستودع equals warehouse1.رقم_المستودع
                                 orderby material1.الرقم_الفني
                                 select new
                                 {
                                     الرقم_الفني = material1.الرقم_الفني,
                                     اسم_المادة = material1.اسم_المادة,
                                     تواجد_المادة = material1.تواجد_المادة,
                                     الوحدة = material1.الوحدة,
                                     كمية = material1.كمية,
                                     سعر = material1.سعر,
                                     رمز_الطراز = material1.رمز_الطراز,
                                     بالة = material1.بالة,
                                     اسم_المجموعة = group1.اسم_المجموعة,
                                     اسم_الصانع = producer1.اسم_الصانع,
                                     اسم_المستودع = warehouse1.اسم_المستودع,
                                     وصف_المادة = material1.وصف_المادة,
                                     صورة = material1.صورة,
                                     سعر_الشراء = material1.سعر_الشراء,
                                     سعر_البيع = material1.سعر_البيع,
                                     كود_المادة = material1.كود_المادة,
                                     طريقة_حساب_الكلفة = material1.طريقة_حساب_الكلفة,
                                     رقم_الصانع = producer1.رقم_الصانع,
                                     رقم_المجموعة = group1.رقم_المجموعة,
                                     رقم_المستودع = warehouse1.رقم_المستودع
                                 }).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

                // Convert to DataTable
                DataTable dataTable = ConvertToDataTable(materials);
                dataGridViewMaterial.DataSource = dataTable;
                TableStyle(dataTable.Rows.Count);
                UpdatePageLabel();
            }
        }

        private DataTable ConvertToDataTable<T>(List<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);

            // Get all the properties by using reflection
            var properties = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var prop in properties)
            {
                // Defining type of data column gives us advantage of type checking at compile time
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in items)
            {
                var values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    // Inserting property values to datatable rows
                    values[i] = properties[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

     
        private void UpdatePageLabel()
        {
            lblPage.Text = $"Page {currentPage} of {GetTotalPages()}";
        }

        private int GetTotalPages()
        {
            return (int)Math.Ceiling(originalDataTable.Rows.Count / (double)pageSize);
        }

        #endregion


        #region Table Styling
        private void TableStyle(int count)
        {
            try
            {
                var columnsToHide = new HashSet<string>
                {
                    "صورة", "فرق_السعر","المجموعة","الصانع","المستودع","صورة","وصف_المادة","رقم_المستودع","رقم_المجموعة","رقم_الصانع",
                    "فرق_الكمية", "DiscountPersent", "Discount", "Comment", "TotalValue","TotalCost","profit"
                };

                foreach (DataGridViewColumn column in dataGridViewMaterial.Columns)
                {
                    column.Visible = !columnsToHide.Contains(column.Name);
                }

                if (dataGridViewMaterial.Columns.Contains("اسم_المادة"))
                {
                    dataGridViewMaterial.Columns["اسم_المادة"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }

                var colorGreen = Color.Green;
                var colorGoldenrod = Color.Goldenrod;
                var colorRed = Color.Red;

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
                        row.DefaultCellStyle.ForeColor = colorRed;
                        row.ErrorText = "الكمية غير محددة أو غير صحيحة";
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }
        #endregion

        #region Data Retrieval Methods
        private void getgroupList()
        {
            try
            {
                material_groupTableAdapter mgta = new material_groupTableAdapter();
                MaterialControllar.material_groupDataTable mgdt = mgta.GetDataByASC();

                var groups = mgdt.AsEnumerable()
                                 .Select(row => $"{row["اسم_المجموعة"]}.{row["رقم_المجموعة"]}")
                                 .OrderBy(group => group)
                                 .ToArray();

                cbGroup.Items.Clear();
                cbGroup.AutoCompleteCustomSource.AddRange(groups);
                cbGroup.Items.AddRange(groups);
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }

        private void getProdectList()
        {
            try
            {
                producerTableAdapter pta = new producerTableAdapter();
                MaterialControllar.producerDataTable pdt = pta.GetDataByASC();

                var products = pdt.AsEnumerable()
                                  .Select(row => $"{row["اسم_الصانع"]}.{row["رقم_الصانع"]}")
                                  .OrderBy(product => product)
                                  .ToArray();

                cbProduct.Items.Clear();
                cbProduct.AutoCompleteCustomSource.AddRange(products);
                cbProduct.Items.AddRange(products);
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }

        private void getWarehouseList()
        {
            try
            {
                WareHouseTableAdapter wta = new WareHouseTableAdapter();
                MaterialControllar.WareHouseDataTable wdt = wta.GetDataByASC();

                var warehouses = wdt.AsEnumerable()
                                    .Select(row => $"{row["اسم_المستودع"]}.{row["رقم_المستودع"]}")
                                    .OrderBy(warehouse => warehouse)
                                    .ToArray();

                cbWarehouse.Items.Clear();
                cbWarehouse.AutoCompleteCustomSource.AddRange(warehouses);
                cbWarehouse.Items.AddRange(warehouses);
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }

        public void getMaterialNameAutocomplete()
        {
            try
            {
                materialTableAdapter mta = new materialTableAdapter();
                MaterialControllar.materialDataTable mdt = mta.GetData();

                var sortedNames = mdt.AsEnumerable()
                                     .Select(row => row.Field<string>("اسم_المادة"))
                                     .Where(name => !string.IsNullOrWhiteSpace(name))
                                     .Distinct()
                                     .OrderBy(name => name)
                                     .ToArray();

                txtName.AutoCompleteCustomSource.Clear();
                txtName.AutoCompleteCustomSource.AddRange(sortedNames);

                txtSearchMaterial.Items.Clear();
                txtSearchMaterial.AutoCompleteCustomSource.Clear();
                txtSearchMaterial.AutoCompleteCustomSource.AddRange(sortedNames);
                txtSearchMaterial.Items.AddRange(sortedNames);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void getMaterialCodeAutocomplete()
        {
            try
            {
                materialTableAdapter mta = new materialTableAdapter();
                MaterialControllar.materialDataTable mdt = mta.GetData();

                var sortedCodes = mdt.AsEnumerable()
                                     .Select(row => row.Field<string>("كود_المادة"))
                                     .Where(code => !string.IsNullOrWhiteSpace(code))
                                     .Distinct()
                                     .OrderBy(code => code)
                                     .ToArray();

                txtSearchMaterial.Items.Clear();
                txtSearchMaterial.AutoCompleteCustomSource.Clear();
                txtSearchMaterial.AutoCompleteCustomSource.AddRange(sortedCodes);
                txtSearchMaterial.Items.AddRange(sortedCodes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        #endregion

        #region Material Methods
        private void AddMaterial()
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
                        cbWayOut.Text, 0);

                    SaveImage();

                    MessageBox.Show("تم اضافة المادة", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshMaterialTable();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("هناك خطأ حيث لم يتم إضافة المجموعة أو الصانع أو المستودع", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void UpdateMaterial()
        {
            if (MessageBox.Show("هل تريد تعديل المادة؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    materialTableAdapter mta = new materialTableAdapter();
                    MaterialControllar.materialDataTable materialDataTable = mta.getMaterialTableById(Convert.ToInt32(materialRow["الرقم_الفني"].ToString()));
                    materialRow = materialDataTable.Rows[0];
                    materialRow["اسم_المادة"] = txtName.Text;
                    materialRow["تواجد_المادة"] = txtPleace.Text;
                    materialRow["الوحدة"] = txtUint.Text;
                    materialRow["كمية"] = txtQuantity.Text;
                    materialRow["سعر"] = txtPrice.Text;
                    materialRow["رمز_الطراز"] = txtType.Text;
                    if (cbGroup.Text.Split('.').Length > 1) { materialRow["المجموعة"] = Convert.ToInt32(cbGroup.Text.Split('.')[1]); }
                    if (cbProduct.Text.Split('.').Length > 1) { materialRow["الصانع"] = Convert.ToInt32(cbProduct.Text.Split('.')[1]); }
                    if (cbWarehouse.Text.Split('.').Length > 1) { materialRow["المستودع"] = Convert.ToInt32(cbWarehouse.Text.Split('.')[1]); }
                    materialRow["بالة"] = cbTrash.Checked;

                    materialRow["وصف_المادة"] = txtMaterialDiscr.Text;
                    materialRow["صورة"] = txtImageFile.Text;
                    materialRow["سعر_الشراء"] = txtPriceBuy.Text;
                    materialRow["سعر_البيع"] = txtPriceSale.Text;
                    materialRow["كود_المادة"] = txtMaterialCode.Text;
                    materialRow["طريقة_حساب_الكلفة"] = cbWayOut.Text;

                    mta.Update(materialRow);

                    foreach (DataRow row in originalDataTable.Rows)
                    {
                        if (Convert.ToInt32(row["الرقم_الفني"]) == Convert.ToInt32(materialRow["الرقم_الفني"]))
                        {
                            row["اسم_المادة"] = txtName.Text;
                            row["تواجد_المادة"] = txtPleace.Text;
                            row["الوحدة"] = txtUint.Text;
                            row["كمية"] = txtQuantity.Text;
                            row["سعر"] = txtPrice.Text;
                            row["رمز_الطراز"] = txtType.Text;
                            row["اسم_المجموعة"] = cbGroup.Text;
                            row["اسم_الصانع"] = cbProduct.Text;
                            row["اسم_المستودع"] = cbWarehouse.Text;
                            row["بالة"] = cbTrash.Checked;
                            row["وصف_المادة"] = txtMaterialDiscr.Text;
                            row["صورة"] = txtImageFile.Text;
                            row["سعر_الشراء"] = txtPriceBuy.Text;
                            row["سعر_البيع"] = txtPriceSale.Text;
                            row["كود_المادة"] = txtMaterialCode.Text;
                            row["طريقة_حساب_الكلفة"] = cbWayOut.Text;
                            break;
                        }
                    }

                    MessageBox.Show("تم تعديل المادة", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("erorr : " + ex.Message, "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void SaveImage()
        {
            if (!string.IsNullOrEmpty(txtImageFile.Text))
            {
                try
                {
                    byte[] image;
                    using (FileStream fsr = new FileStream(txtImageFile.Text, FileMode.OpenOrCreate, FileAccess.Read))
                    {
                        image = new byte[fsr.Length];
                        fsr.Read(image, 0, image.Length);
                    }
                    using (FileStream fsw = new FileStream("..\\..\\Image\\Material\\" + txtName.Text + ".jpg", FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        fsw.Write(image, 0, image.Length);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RefreshMaterialTable()
        {
            int count = dataGridViewMaterial.Rows.Count;
            TableStyle(count);
        }

        private void ResetForm()
        {
            getMaterialNameAutocomplete();
            newToolStripButton_Click(null, null);
            bRefreshTable_Click(null, null);
            txtName.Focus();
        }
        #endregion

        #region Validation Methods
        private bool ValidateInputFields()
        {
            var hasError = false;

            // Clear previous error messages
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();

            // Check txtName
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "حقل اسم المادة فارغ");
                hasError = true;
            }
            else
            {
                errorProvider3.SetError(txtName, "الحقل مقبول");
            }

            // Check txtPrice
            if (txtPrice.Text == "0")
            {
                errorProvider2.SetError(txtPrice, "حقل سعر المادة صفر");
                hasError = true;
            }
            else
            {
                errorProvider3.SetError(txtPrice, "الحقل مقبول");
            }

            // Check cbGroup
            if (string.IsNullOrWhiteSpace(cbGroup.Text))
            {
                errorProvider1.SetError(cbGroup, "حقل مجموعة المادة فارغ");
                hasError = true;
            }
            else
            {
                errorProvider3.SetError(cbGroup, "الحقل مقبول");
            }

            // Check cbProduct
            if (string.IsNullOrWhiteSpace(cbProduct.Text))
            {
                errorProvider1.SetError(cbProduct, "حقل صانع المادة فارغ");
                hasError = true;
            }
            else
            {
                errorProvider3.SetError(cbProduct, "الحقل مقبول");
            }

            // Check cbWarehouse
            if (string.IsNullOrWhiteSpace(cbWarehouse.Text))
            {
                errorProvider1.SetError(cbWarehouse, "حقل مستودع المادة فارغ");
                hasError = true;
            }
            else
            {
                errorProvider3.SetError(cbWarehouse, "الحقل مقبول");
            }

            if (hasError)
            {
                MessageBox.Show("يجب إضافة بعض المعلومات قبل حفظ البيانات!!", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            return true;
        }
        #endregion

        #region Data Mapping Methods
        private MaterialControllar.materialDataTable MapDataRowToMaterialDataTable(DataRow material)
        {
            var mdt = new MaterialControllar.materialDataTable();
            var newRow = mdt.NewRow();

            newRow["الرقم_الفني"] = material["الرقم_الفني"];
            newRow["اسم_المادة"] = material["اسم_المادة"];
            newRow["تواجد_المادة"] = material["تواجد_المادة"];
            newRow["الوحدة"] = material["الوحدة"];
            newRow["كمية"] = material["كمية"];
            newRow["سعر"] = material["سعر"];
            newRow["رمز_الطراز"] = material["رمز_الطراز"];
            newRow["المجموعة"] = material["رقم_المجموعة"];
            newRow["الصانع"] = material["رقم_الصانع"];
            newRow["بالة"] = material["بالة"];
            newRow["المستودع"] = material["رقم_المستودع"];
            newRow["وصف_المادة"] = material["وصف_المادة"];
            newRow["صورة"] = material["صورة"];
            newRow["فرق_السعر"] = material["فرق_السعر"];
            newRow["فرق_الكمية"] = material["فرق_الكمية"];
            newRow["سعر_الشراء"] = material["سعر_الشراء"];
            newRow["سعر_البيع"] = material["سعر_البيع"];
            newRow["كود_المادة"] = material["كود_المادة"];
            newRow["طريقة_حساب_الكلفة"] = material["طريقة_حساب_الكلفة"];

            mdt.Rows.Add(newRow);
            return mdt;
        }

        private void setMaterialValue(DataRow material)
        {
            lblPage.Text = material["الرقم_الفني"].ToString();
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

            var mdt = MapDataRowToMaterialDataTable(material);
            materialRow = mdt.Rows[0];
        }
        #endregion

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
