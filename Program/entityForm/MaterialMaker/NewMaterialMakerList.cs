using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.CustomerControllarTableAdapters;
using Program.entity.controllar.MaterialControllarTableAdapters;
using Program.entity.controllar;
using Program.entity.controllar.BankControllarTableAdapters;
using Num2Wrd;
using Program.entityForm.customer.report;
using System.Collections;
using Program.entity.controllar.PaperReceiveControllarTableAdapters;
using Program.entity.controllar.CompanyControllarTableAdapters;
using System.IO.Ports;
using System.Threading;
using Program.entity.controllar.MaterialMakerControllarTableAdapters;

namespace Program.entityForm.customer
{
    public partial class NewMaterialMakerList : Form
    {
        public NewMaterialMakerList()
        {
            InitializeComponent();
        }
        SerialPort _serialPort;

        // delegate is used to write to a UI control from a non-UI thread
        private delegate void SetTextDeleg(string text);
        private void Sale_Load(object sender, EventArgs e)
        {
            dataGridViewMaterial.RowCount = 20;
            getMaterialMakerNameAutocomplete();
            getMaterialNameAutocomplete();
            getgroupList();
            newToolStripButton_Click(sender, e);
            

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
            cbGroup.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            cbGroup.Items.AddRange(array.ToArray());
        }

        public void getMaterialMakerNameAutocomplete()
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
                        array.Add(row["اسم_المادة"].ToString() + "." + row["الرقم"].ToString());
                    }
                }
                array.Sort();
                txtMaterialMaker.Items.Clear();
                txtMaterialMaker.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
                txtMaterialMaker.Items.AddRange(array.ToArray());
            }
            catch (Exception ex)
            {

            }
        }

        public void getMaterialNameAutocomplete()
        {
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
            txtSearchMaterial.Items.Clear();
            txtSearchMaterial.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtSearchMaterial.Items.AddRange(array.ToArray());
        }

        private void getMaterialCodeAutocomplete()
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

        private void Sale_Resize(object sender, EventArgs e)
        {
        }

        private void txtCustomer_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaterialMaker.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل اسم العميل فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void bAddMaterial_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                materialTableAdapter mta = new materialTableAdapter();
                MaterialControllar.materialDataTable mdt = mta.getMaterialByName(txtSearchMaterial.Text);
                DataRow dr = mdt.Rows[0];
                foreach (DataRow row in materialList)
                {
                    if (row["الرقم_الفني"].ToString() == dr["الرقم_الفني"].ToString())
                    {
                        found = true;
                    }
                }

                if (found)
                {
                    MessageBox.Show("تم إضافة المادة سابقاً", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dr["كمية"] = txtQuintity.Text;
                    materialList.Add(dr);
                    addMaterial(dr);
                }
            }
            catch (Exception ex)
            {

            }
            txtQuintity.Text = "0";
            txtQuintity1.Text = "0";
            calculateReportValue();
        }

        static List<DataRow> materialList = new List<DataRow>();
        static int countMaterial = 0;
        private void addMaterial(DataRow dr)
        {
            dataGridViewMaterial.Rows[countMaterial].Cells[0].Value = dr["الرقم_الفني"];
            dataGridViewMaterial.Rows[countMaterial].Cells[1].Value = dr["اسم_المادة"];
            dataGridViewMaterial.Rows[countMaterial].Cells[2].Value = dr["كمية"];
            dataGridViewMaterial.Rows[countMaterial].Cells[3].Value = dr["سعر_البيع"];
            dataGridViewMaterial.Rows[countMaterial].Cells[4].Value = dr["DiscountPersent"];
            dataGridViewMaterial.Rows[countMaterial].Cells[5].Value = dr["Discount"];
            dataGridViewMaterial.Rows[countMaterial].Cells[6].Value = dr["TotalValue"];
            dataGridViewMaterial.Rows[countMaterial].Cells[7].Value = dr["Comment"];
            dataGridViewMaterial.Rows[countMaterial].Cells[8].Value = dr["سعر_الشراء"];
            dataGridViewMaterial.Rows[countMaterial].Cells[9].Value = dr["TotalCost"];
            dataGridViewMaterial.Rows[countMaterial].Cells[10].Value = dr["profit"];
            txtSearchMaterial.Focus();
            countMaterial++;
        }

        private void txtMaterialSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bAddMaterial_Click(sender, e);
            }
        }

        private void bRemoveMaterial_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("إزالة المادة ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information,MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                DataRow dr = materialList.Find(
                    delegate(DataRow row)
                    {
                        return dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[0].Value.ToString().Trim() == row["الرقم_الفني"].ToString().Trim();
                    });
                removeMaterial(dr);
            }
        }

        private void removeMaterial(DataRow dr)
        {
            try
            {
                for (int i = 0; i < materialList.Count; i++)
                {
                    dataGridViewMaterial.Rows[i].Cells[0].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[1].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[2].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[3].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[4].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[5].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[6].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[7].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[8].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[9].Value = "";
                    dataGridViewMaterial.Rows[i].Cells[10].Value = "";
                }
                materialList.Remove(dr);
                countMaterial = 0;
                foreach (DataRow row in materialList)
                {
                    addMaterial(row);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridViewMaterial_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            calculateReportValue();
        }

        static double totalPriceValue = 0;
        static double totalCostValue = 0;
        static double totalDiscountValue = 0;
        static double totalPenfitValue = 0;
        public void calculateReportValue()
        {
            try
            {
                if (dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[0].Value == null)
                {

                }
                else
                {
                    materialTableAdapter mta = new materialTableAdapter();
                    int quantity = Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[2].Value.ToString());

                    if (quantity > Convert.ToInt32(mta.getMaterialById(Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[0].Value.ToString()))[0]["كمية"]))
                    {
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[2].Value = 0;
                        MessageBox.Show("إن الكمية المطلوبة أكبر من الموجودة ب المستودع", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        quantity = Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[2].Value.ToString());
                        int price = Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[3].Value.ToString());
                        int price_buy = Convert.ToInt32(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[8].Value.ToString());

                        double DiscountPersent = Convert.ToDouble(dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[4].Value.ToString());
                        double discount = quantity * price * (DiscountPersent / 100);
                        double PriceValue = (quantity * price) - discount;
                        double PriceValue_buy = (quantity * price_buy);

                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[5].Value = discount;
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[6].Value = PriceValue;
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[9].Value = PriceValue_buy;
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[10].Value = (PriceValue-PriceValue_buy);

                        DataRow dr = materialList.Find(
                        delegate(DataRow row)
                        {
                            return dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[0].Value.ToString().Trim() == row["الرقم_الفني"].ToString().Trim();
                        });

                        dr["كمية"] = quantity;
                        dr["DiscountPersent"] = DiscountPersent;
                        dr["Discount"] = discount;
                        dr["Comment"] = dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[7].Value.ToString();
                        dr["TotalValue"] = PriceValue;
                        dr["TotalCost"] = PriceValue_buy;
                        dr["profit"] = PriceValue-PriceValue_buy;
                        if (price != Convert.ToInt32(dr["سعر_البيع"]))
                        {
                            if (MessageBox.Show("هل ترغب بتغير سعر بيع  " + dr["اسم_المادة"] + " ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                mta.UpdateSalePrice( price,Convert.ToInt32(dr["الرقم_الفني"] ));
                                dr["سعر_البيع"] = price;
                            }
                            else
                            {
                                dr["سعر_البيع"] = price;
                            }
                        }
                        else
                        {
                            dr["سعر_البيع"] = price;
                        }
                        totalPriceValue = 0;
                        totalCostValue = 0;
                        totalDiscountValue = 0;
                        foreach (DataRow row in materialList)
                        {
                            try
                            {
                                totalPriceValue += Convert.ToDouble(row["TotalValue"]);
                                totalCostValue += Convert.ToDouble(row["TotalCost"]);
                                totalDiscountValue += Convert.ToDouble(row["Discount"]);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Exception1 :: " + ex.Message);
                            }
                        }
                        txtTotalPrice.Text = totalPriceValue.ToString();
                        txtDiscount.Text = totalDiscountValue.ToString();
                        txtTotalCost.Text = totalCostValue.ToString();
                        txtTotalProfit.Text = (totalPriceValue-totalDiscountValue-totalCostValue+totalPenfitValue).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception2 :: " + ex.Message);
            }

        }

        public void calculateReportValue1()
        {
            try
            {
                for (int i = 0; i < materialList.Count; i++)
                {
                    dataGridViewMaterial.Rows[i].Selected = true;
                    if (dataGridViewMaterial.Rows[i].Cells[0].Value == null)
                    {

                    }
                    else
                    {
                        materialTableAdapter mta = new materialTableAdapter();
                        int quantity = Convert.ToInt32(dataGridViewMaterial.Rows[i].Cells[2].Value.ToString());

                        if (quantity > Convert.ToInt32(mta.getMaterialById(Convert.ToInt32(dataGridViewMaterial.Rows[i].Cells[0].Value.ToString()))[0]["كمية"]))
                        {
                            dataGridViewMaterial.Rows[i].Cells[2].Value = 0;
                            MessageBox.Show("إن الكمية المطلوبة أكبر من الموجودة ب المستودع", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            quantity = Convert.ToInt32(dataGridViewMaterial.Rows[i].Cells[2].Value.ToString());
                            int price = Convert.ToInt32(dataGridViewMaterial.Rows[i].Cells[3].Value.ToString());
                            int price_buy = Convert.ToInt32(dataGridViewMaterial.Rows[i].Cells[8].Value.ToString());

                            double DiscountPersent = Convert.ToDouble(dataGridViewMaterial.Rows[i].Cells[4].Value.ToString());
                            double discount = quantity * price * (DiscountPersent / 100);
                            double PriceValue = (quantity * price) - discount;
                            double PriceValue_buy = (quantity * price_buy);

                            dataGridViewMaterial.Rows[i].Cells[5].Value = discount;
                            dataGridViewMaterial.Rows[i].Cells[6].Value = PriceValue;
                            dataGridViewMaterial.Rows[i].Cells[9].Value = PriceValue_buy;
                            dataGridViewMaterial.Rows[i].Cells[10].Value = (PriceValue - PriceValue_buy);

                            DataRow dr = materialList.Find(
                            delegate(DataRow row)
                            {
                                return dataGridViewMaterial.Rows[i].Cells[0].Value.ToString().Trim() == row["الرقم_الفني"].ToString().Trim();
                            });

                            dr["كمية"] = quantity;
                            dr["DiscountPersent"] = DiscountPersent;
                            dr["Discount"] = discount;
                            dr["Comment"] = dataGridViewMaterial.Rows[i].Cells[7].Value.ToString();
                            dr["TotalValue"] = PriceValue;
                            dr["TotalCost"] = PriceValue_buy;
                            dr["profit"] = PriceValue - PriceValue_buy;
                            if (price != Convert.ToInt32(dr["سعر_البيع"]))
                            {
                                if (MessageBox.Show("هل ترغب بتغير سعر بيع  " + dr["اسم_المادة"] + " ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                                {
                                    mta.UpdateBuyPrice(price, Convert.ToInt32(dr["الرقم_الفني"]));
                                    dr["سعر_البيع"] = price;
                                }
                                else
                                {
                                    dr["سعر_البيع"] = price;
                                }
                            }
                            else
                            {
                                dr["سعر_البيع"] = price;
                            }
                            totalPriceValue = 0;
                            totalCostValue = 0;
                            totalDiscountValue = 0;
                            foreach (DataRow row in materialList)
                            {
                                try
                                {
                                    totalPriceValue += Convert.ToDouble(row["TotalValue"]);
                                    totalCostValue += Convert.ToDouble(row["TotalCost"]);
                                    totalDiscountValue += Convert.ToDouble(row["Discount"]);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Exception1 :: " + ex.Message);
                                }
                            }
                            txtTotalPrice.Text = totalPriceValue.ToString();
                            txtDiscount.Text = totalDiscountValue.ToString();
                            txtTotalCost.Text = totalCostValue.ToString();
                            txtTotalProfit.Text = (totalPriceValue - totalDiscountValue - totalCostValue + totalPenfitValue).ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception2 :: " + ex.Message);
            }/**/
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            materialList.Clear();
            countMaterial = 0;
           // indexMaterialdebit = 0;
            for (int i = 0; i < 20; i++)
            {
                dataGridViewMaterial.Rows[i].Cells[0].Value = "";
                dataGridViewMaterial.Rows[i].Cells[1].Value = "";
                dataGridViewMaterial.Rows[i].Cells[2].Value = "";
                dataGridViewMaterial.Rows[i].Cells[3].Value = "";
                dataGridViewMaterial.Rows[i].Cells[4].Value = "";
                dataGridViewMaterial.Rows[i].Cells[5].Value = "";
                dataGridViewMaterial.Rows[i].Cells[6].Value = "";
                dataGridViewMaterial.Rows[i].Cells[7].Value = "";
                dataGridViewMaterial.Rows[i].Cells[8].Value = "";
                dataGridViewMaterial.Rows[i].Cells[9].Value = "";
                dataGridViewMaterial.Rows[i].Cells[10].Value = "";

            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            SaleBills sb = new SaleBills();
            sb.ShowDialog();
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
                    // Makes sure serial port is open before trying to write
                    try
                    {
                        if (!_serialPort.IsOpen)
                            _serialPort.Open();

                        _serialPort.Write("SI\r\n");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
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
            txtSearchMaterial.Text = data.Trim();
        }
        private void bSaveAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حفط المادة؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                int id = Convert.ToInt32(txtMaterialMaker.Text.Split('.')[1]);
                material_maker_listTableAdapter mclta = new material_maker_listTableAdapter();
                
                foreach (DataRow row in materialList)
                {
                    try
                    {
                        mclta.Insert(Convert.ToInt32(row["الرقم_الفني"]),
                            id,
                            row["اسم_المادة"].ToString(),
                            row["الوحدة"].ToString(),
                            Convert.ToInt32(row["كمية"]),
                            Convert.ToDouble(row["سعر_الشراء"]),
                            Convert.ToDouble(row["Discount"]),
                            Convert.ToDouble(Convert.ToInt32(row["كمية"]) * Convert.ToInt32(row["سعر_الشراء"])),
                            row["Comment"].ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("لم يتم إضافة " + row["اسم_المادة"].ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show("تم إنجاز المهمة بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }

        private void cbMoreBillsOption_TextChanged(object sender, EventArgs e)
        {
        }

        private void Sale_FormClosed(object sender, FormClosedEventArgs e)
        {
            materialList.Clear();
        }



        private void dataGridViewMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                bRemoveMaterial_Click(sender, e);
            }
        }

        private void bAddCustomer_Click(object sender, EventArgs e)
        {
            NewMaterialMaker nmm = new NewMaterialMaker();
            nmm.MdiParent = Main.ActiveForm;
            nmm.LayoutMdi(MdiLayout.ArrangeIcons);
            nmm.Show();
        }

        private void bMaterialCard_Click(object sender, EventArgs e)
        {
            NewMaterial nm = new NewMaterial();
            nm.MdiParent = Main.ActiveForm;
            nm.LayoutMdi(MdiLayout.ArrangeIcons);
            nm.Show();
        }

        static int Quintity = 0;
        private void bAddMaterial1_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                materialTableAdapter mta = new materialTableAdapter();
                MaterialControllar.materialDataTable mdt = mta.getMaterialByName(txtSearchMaterial.Text);
                DataRow dr = mdt.Rows[0];
                foreach (DataRow row in materialList)
                {
                    if (row["الرقم_الفني"].ToString() == dr["الرقم_الفني"].ToString())
                    {
                        found = true;
                    }
                }

                if (found)
                {
                    MessageBox.Show("تم إضافة المادة سابقاً", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dr["كمية"] = Quintity;
                    materialList.Add(dr);
                    addMaterial(dr);
                }
            }
            catch (Exception ex)
            {

            }
            txtQuintity.Text = "0";
            txtQuintity1.Text = "0";
            calculateReportValue1();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "1";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);
        }

        private void b2_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "2";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);
        }

        private void b3_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "3";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);
        }

        private void b4_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "4";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);
        }

        private void b5_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "5";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);
        }

        private void b6_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "6";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);
        }

        private void b7_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "7";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);
        }

        private void b8_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "8";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);
        }

        private void b9_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "9";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);
        }

        private void b0_Click(object sender, EventArgs e)
        {
            txtQuintity.Text += "0";
            txtQuintity1.Text = txtQuintity.Text;
            Quintity = Convert.ToInt32(txtQuintity.Text);
        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            materialTableAdapter mta = new materialTableAdapter();
            MaterialControllar.materialDataTable mdt = mta.GetDataByGroub(Convert.ToInt32(cbGroup.Text.Split('.')[1]));
            dataGridViewMaterilList.DataSource = mdt;

            dataGridViewMaterilList.Columns["الرقم_الفني"].HeaderText = "تسلسل";
            dataGridViewMaterilList.Columns["سعر_البيع"].HeaderText = "السعر";
            dataGridViewMaterilList.Columns["اسم_المادة"].HeaderText = "المادة";


            dataGridViewMaterilList.Columns["تواجد_المادة"].Visible = false;
            dataGridViewMaterilList.Columns["الوحدة"].Visible = false;
            dataGridViewMaterilList.Columns["سعر"].Visible = false;
            dataGridViewMaterilList.Columns["رمز_الطراز"].Visible = false;
            dataGridViewMaterilList.Columns["المجموعة"].Visible = false;
            dataGridViewMaterilList.Columns["الصانع"].Visible = false;
            dataGridViewMaterilList.Columns["المستودع"].Visible = false;
            dataGridViewMaterilList.Columns["بالة"].Visible = false;
            dataGridViewMaterilList.Columns["وصف_المادة"].Visible = false;
            dataGridViewMaterilList.Columns["صورة"].Visible = false;
            dataGridViewMaterilList.Columns["فرق_السعر"].Visible = false;
            dataGridViewMaterilList.Columns["فرق_الكمية"].Visible = false;
            dataGridViewMaterilList.Columns["سعر_الشراء"].Visible = false;
            //dataGridViewMaterilList.Columns["سعر_البيع"].Visible = false;
            dataGridViewMaterilList.Columns["كود_المادة"].Visible = false;
            dataGridViewMaterilList.Columns["DiscountPersent"].Visible = false;
            dataGridViewMaterilList.Columns["Discount"].Visible = false;
            dataGridViewMaterilList.Columns["Comment"].Visible = false;
            dataGridViewMaterilList.Columns["TotalValue"].Visible = false;
            dataGridViewMaterilList.Columns["TotalCost"].Visible = false;
            dataGridViewMaterilList.Columns["profit"].Visible = false;
            dataGridViewMaterilList.Columns["طريقة_حساب_الكلفة"].Visible = false;

            dataGridViewMaterilList.Columns["الرقم_الفني"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewMaterilList.Columns["اسم_المادة"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewMaterilList.Columns["كمية"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewMaterilList.Columns["سعر_البيع"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void dataGridViewMaterilList_Click(object sender, EventArgs e)
        {
            txtSearchMaterial.Text = dataGridViewMaterilList.Rows[dataGridViewMaterilList.CurrentRow.Index].Cells["اسم_المادة"].Value.ToString();
        }

        private void bAC_Click(object sender, EventArgs e)
        {
            txtQuintity.Text = "0";
            txtQuintity1.Text = txtQuintity.Text;

        }

        private void txtQuintity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bAddMaterial_Click(sender, e);
            }
        }

        private void dataGridViewMaterilList_KeyUp(object sender, KeyEventArgs e)
        {
            txtSearchMaterial.Text = dataGridViewMaterilList.Rows[dataGridViewMaterilList.CurrentRow.Index].Cells["اسم_المادة"].Value.ToString();
        }

        private void bMaterialList_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtMaterialMaker.Text.Split('.')[1]);
            material_maker_listTableAdapter mclta = new material_maker_listTableAdapter();
            MaterialMakerControllar.material_maker_listDataTable mcldt = mclta.getMaterialMakerList(id);

            for (int i = 0; i < 20; i++)
            {
                dataGridViewMaterial.Rows[i].Cells[0].Value = "";
                dataGridViewMaterial.Rows[i].Cells[1].Value = "";
                dataGridViewMaterial.Rows[i].Cells[2].Value = "";
                dataGridViewMaterial.Rows[i].Cells[3].Value = "";
                dataGridViewMaterial.Rows[i].Cells[4].Value = "";
                dataGridViewMaterial.Rows[i].Cells[5].Value = "";
                dataGridViewMaterial.Rows[i].Cells[6].Value = "";
                dataGridViewMaterial.Rows[i].Cells[7].Value = "";
            }

            int count = 0;
            materialList.Clear();
            //change
            double price = 0;
            //
            foreach (DataRow dr in mcldt)
            {
                materialTableAdapter mta1 = new materialTableAdapter();
                MaterialControllar.materialDataTable material = mta1.getMaterialById(Convert.ToInt32(dr["رقم_المادة"]));

                dataGridViewMaterial.Rows[count].Cells[0].Value = dr["رقم_المادة"];
                dataGridViewMaterial.Rows[count].Cells[1].Value = dr["اسم_المادة"];
                dataGridViewMaterial.Rows[count].Cells[2].Value = dr["كمية"];
                dataGridViewMaterial.Rows[count].Cells[3].Value = dr["سعر_الشراء"];
                //dataGridViewMaterial.Rows[count].Cells[4].Value = Convert.ToInt32((Convert.ToDouble(dr["نسبة_الهدر"]) / Convert.ToDouble(dr["السعر_الجمالي"])) * 100);
                dataGridViewMaterial.Rows[count].Cells[5].Value = dr["نسبة_الهدر"];
                dataGridViewMaterial.Rows[count].Cells[6].Value = dr["كلفة_المادة"];
                dataGridViewMaterial.Rows[count].Cells[7].Value = dr["ملاحظات"];
                //change
                //price = price + Convert.ToDouble(dr["السعر_الجمالي"]);
                //
                count++;
                //material.Rows[0]["كمية"] = dr["الكمية"];
                materialList.Add(material.Rows[0]);
            }

        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            getMaterialMakerNameAutocomplete();
        }

        private void txtMaterialMaker_SelectedIndexChanged(object sender, EventArgs e)
        {
            bMaterialList_Click(sender, e);
        }

        private void txtMaterialMaker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bMaterialList_Click(sender, e);

            }
        }
        
    }
}
