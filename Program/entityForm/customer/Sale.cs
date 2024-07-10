using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using Num2Wrd;
using Program.entity.controllar;
using Program.entity.controllar.BankControllarTableAdapters;
using Program.entity.controllar.CompanyControllarTableAdapters;
using Program.entity.controllar.CustomerControllarTableAdapters;
using Program.entity.controllar.MaterialControllarTableAdapters;
using Program.entity.controllar.PaperReceiveControllarTableAdapters;
using Program.entityForm.customer.report;

namespace Program.entityForm.customer
{
    public partial class Sale : Form
    {
        private static int countMaterial = 0;

        private static int idPaperReceived = 0;

        private static string[] IsBondTrested = new string[2];

        private static bool isSaveBonds = true;

        private static List<DataRow> materialList = new List<DataRow>();

        private static DataRow rowMaterialdCredit;

        private static double totalCostValue = 0;

        private static double totalDiscountValue = 0;

        private static double totalPenfitValue = 0;

        private static double totalPriceValue = 0;

        private SerialPort _serialPort;

        private BondControllar bc;

        private List<BondControllar> bcList = new List<BondControllar>();

        private int indexMaterialCredit = 0;

        private NumberToEnglish nte = new NumberToEnglish();

        private bool SaveBuy = true;

        public Sale()
        {
            InitializeComponent();
        }

        // delegate is used to write to a UI control from a non-UI thread
        private delegate void SetTextDeleg(string text);

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
                        ///////////////////////////////////////////////////////
                        DataRow dr = materialList.Find(
                        delegate(DataRow row)
                        {
                            return dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[0].Value.ToString().Trim() == row["الرقم_الفني"].ToString().Trim();
                        });

                        // calculate cost of material
                        double PriceValue_buy = 0;//(quantity * price_buy);
                        material_costTableAdapter mcta_cost = new material_costTableAdapter();
                        if (dr["طريقة_حساب_الكلفة"].ToString() == "FIFO")
                        {
                            MaterialControllar.material_costDataTable mcdt_cost = mcta_cost.GetDataById_Quintity_Ascending(Convert.ToInt32(dr["الرقم_الفني"]));
                            int quantity_stay = quantity;
                            foreach (DataRow row1 in mcdt_cost)
                            {
                                if (quantity_stay <= Convert.ToInt32(row1["كمية"]) && quantity_stay != 0)
                                {
                                    PriceValue_buy += quantity_stay * Convert.ToDouble(row1["سعر_الشراء"]);
                                    quantity_stay = 0;
                                }
                                if (quantity_stay > Convert.ToInt32(row1["كمية"]))
                                {
                                    PriceValue_buy += Convert.ToInt32(row1["كمية"]) * Convert.ToDouble(row1["سعر_الشراء"]);
                                    quantity_stay = quantity_stay - Convert.ToInt32(row1["كمية"]);
                                }
                            }
                        }
                        if (dr["طريقة_حساب_الكلفة"].ToString() == "LIFO")
                        {
                            MaterialControllar.material_costDataTable mcdt_cost = mcta_cost.GetDataById_quintity_Descending(Convert.ToInt32(dr["الرقم_الفني"]));
                            int quantity_stay = quantity;
                            foreach (DataRow row1 in mcdt_cost)
                            {
                                if (quantity_stay <= Convert.ToInt32(row1["كمية"]) && quantity_stay != 0)
                                {
                                    PriceValue_buy += quantity_stay * Convert.ToDouble(row1["سعر_الشراء"]);
                                    quantity_stay = 0;
                                }
                                if (quantity_stay > Convert.ToInt32(row1["كمية"]))
                                {
                                    PriceValue_buy += Convert.ToInt32(row1["كمية"]) * Convert.ToDouble(row1["سعر_الشراء"]);
                                    quantity_stay = quantity_stay - Convert.ToInt32(row1["كمية"]);
                                }
                            }
                        }
                        if (dr["طريقة_حساب_الكلفة"].ToString() == "AVG")
                        {
                            dr["سعر_الشراء"] = mcta_cost.GetAVG_Price(Convert.ToInt32(dr["الرقم_الفني"]));
                            PriceValue_buy = quantity * Convert.ToDouble(dr["سعر_الشراء"]);
                        }
                        ///////////////////////////////////////////
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[5].Value = discount;
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[6].Value = PriceValue;
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[9].Value = PriceValue_buy;
                        dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[10].Value = (PriceValue - PriceValue_buy);

                        dr["كمية"] = quantity;
                        dr["DiscountPersent"] = DiscountPersent;
                        dr["Discount"] = discount;
                        dr["Comment"] = dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentCell.RowIndex].Cells[7].Value.ToString();
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
            catch (Exception ex)
            {
                Console.WriteLine("Exception2 :: " + ex.Message);
            }/**/
        }

        public bool CheckBondsError(string dir, int index)
        {
            bool ok = true;
            string[] message = bc.CheckBonds(dir);
            if (message[0] != "")
            {
                dataGridViewBond.Rows[index].ErrorText = message[0];
                dataGridViewBond.Rows[index].Cells[1].ErrorText = message[0];
                dataGridViewBond.Rows[index].DefaultCellStyle.BackColor = Color.Gold;
                dataGridViewBond.Rows[index].DefaultCellStyle.ForeColor = Color.Green;
                ok = false;
            }
            if (message[1] != "")
            {
                dataGridViewBond.Rows[index].ErrorText += "\n" + message[1];
                dataGridViewBond.Rows[index].Cells[2].ErrorText = message[1];
                dataGridViewBond.Rows[index].DefaultCellStyle.BackColor = Color.Gold;
                dataGridViewBond.Rows[index].DefaultCellStyle.ForeColor = Color.Green;
                ok = false;
            }
            //if there are no error
            if (message[0] == "" && message[1] == "")
            {
                dataGridViewBond.Rows[index].ErrorText = "";
                dataGridViewBond.Rows[index].Cells[1].ErrorText = message[0];
                dataGridViewBond.Rows[index].Cells[2].ErrorText = message[1];
                dataGridViewBond.Rows[index].DefaultCellStyle.BackColor = Color.White;
                dataGridViewBond.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
                ok = true;
            }
            return ok;
        }

        public void getCustomerNameAutocomplete()
        {
            customerTableAdapter cta = new customerTableAdapter();
            entity.controllar.CustomerControllar.customerDataTable cdt = cta.getCustomerAutocomplete(txtCustomer.Text);
            string[] array = new string[cdt.Rows.Count];
            int count = 0;
            foreach (DataRow row in cdt.Rows)
            {
                array[count] = row["اسم_الربون"].ToString() + "." + row["الرقم"].ToString();
                count++;
            }
            txtCustomer.AutoCompleteCustomSource.AddRange(array);
            txtCustomer.Items.AddRange(array);
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
                    array.Add(row["اسم_المادة"].ToString() + "." + row["الرقم_الفني"].ToString());
                }
            }
            array.Sort();
            txtSearchMaterial.Items.Clear();
            txtSearchMaterial.AutoCompleteCustomSource.AddRange((string[])array.ToArray(typeof(string)));
            txtSearchMaterial.Items.AddRange(array.ToArray());
        }

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

        private void bAddBond_Click(object sender, EventArgs e)
        {
            setBond1();
            setBond2();
            setBond3();
            setBond4();
            setBond5();
            setBond6();
            setBond7();
        }

        private void bAddMaterial_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                materialTableAdapter mta = new materialTableAdapter();
                MaterialControllar.materialDataTable mdt = mta.getMaterialById(Convert.ToInt32(txtSearchMaterial.Text.Split('.')[1]));
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
                    dr["كمية"] = Convert.ToInt32(txtQuintity.Text);
                    materialList.Add(dr);
                    addMaterial(dr);
                }
            }
            catch (Exception)
            {
            }
            txtQuintity.Text = "0";
            calculateReportValue();
        }

        private void bDeleteBills_Click(object sender, EventArgs e)
        {
            if (isSaveBonds)
            {
                MessageBox.Show("لا يمكن حذف قسيمة الإدخال تم تثبيت القيود", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("هل تريد حذف التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    materialTableAdapter mta = new materialTableAdapter();
                    foreach (DataRow row in materialList)
                    {
                        materialTableAdapter mta1 = new materialTableAdapter();
                        MaterialControllar.materialDataTable material = mta1.getMaterialById(Convert.ToInt32(row["الرقم_الفني"]));

                        mta.UpdateMaterialQuantity((Convert.ToInt32(material.Rows[0]["كمية"]) + Convert.ToInt32(row["كمية"])),
                        Convert.ToInt32(row["الرقم_الفني"]));
                    }
                    int id = Convert.ToInt32(rowMaterialdCredit["الرقم"]);
                    //change
                    if (rbAfter.Checked)
                    {
                        material_credit_penfit_paymentTableAdapter mcppta = new material_credit_penfit_paymentTableAdapter();
                        mcppta.DeletePenfitPayment(id);
                    }
                    //
                    material_creditTableAdapter mdta = new material_creditTableAdapter();
                    material_credit_listTableAdapter mdlta = new material_credit_listTableAdapter();
                    mdlta.DeleteMaterialCreditList(id);
                    mdta.DeleteMaterialCredit(id);
                    newToolStripButton_Click(sender, e);
                    MessageBox.Show("تم حذف تقرير شراء البضاعة", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bFirst_Click(object sender, EventArgs e)
        {
            getReport(cbIds.Items.Count - 1);
        }

        private void bHide_Click(object sender, EventArgs e)
        {
            gbBonds.Hide();
        }

        private void bLast_Click(object sender, EventArgs e)
        {
            getReport(0);
        }

        private void bMaterialCard_Click(object sender, EventArgs e)
        {
            NewMaterial nm = new NewMaterial();
            nm.MdiParent = Main.ActiveForm;
            nm.LayoutMdi(MdiLayout.ArrangeIcons);
            nm.Show();
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                indexMaterialCredit++;
            }
            getReport(indexMaterialCredit);
            if (indexMaterialCredit == (cbIds.Items.Count - 1))
            {
                bNext.Enabled = false;
                bPrevious.Enabled = true;
            }
            else
            {
                bPrevious.Enabled = true;
            }
        }

        private void bPrevious_Click(object sender, EventArgs e)
        {
            indexMaterialCredit--;
            getReport(indexMaterialCredit);
            if (indexMaterialCredit == 0)
            {
                bPrevious.Enabled = false;
                bNext.Enabled = true;
            }
            else
            {
                bNext.Enabled = true;
            }
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            getReport(Convert.ToInt16(cbIds.SelectedIndex));
        }

        private void bRemoveMaterial_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("إزالة المادة ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                DataRow dr = materialList.Find(
                    delegate(DataRow row)
                    {
                        return dataGridViewMaterial.Rows[dataGridViewMaterial.CurrentRow.Index].Cells[0].Value.ToString().Trim() == row["الرقم_الفني"].ToString().Trim();
                    });
                removeMaterial(dr);
            }
        }

        private void bSaveAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbPaperReceived.Checked && (dtpPaperRecieved.Value.Date <= DateTime.Now.Date))
                {
                    MessageBox.Show("تاريخ إستحقاق ورقة القبض يجب أن لا يكون أصغر أو يساوي التاريخ اليوم", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (SaveBuy)
                    {
                        if (MessageBox.Show("هل تريد حفط التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            //change
                            double price = totalPriceValue + totalPenfitValue - totalDiscountValue;
                            if (cbMoreBillsOption.Text == "على الزبون")
                            {
                                price = price + Convert.ToDouble(txtMoreBills.Text);
                            }
                            material_creditTableAdapter mcta = new material_creditTableAdapter();

                            mcta.Insert(DateTime.Now,
                            dtpReciveDate.Value,
                            price,
                            nte.changeNumericToWords(price),
                            "زبون." + txtCustomer.Text,
                            "",
                            cbTypeOperation.Text,
                            Convert.ToInt32(txtCustomer.Text.Split('.')[1]),
                            "",
                            "",
                            getType(),
                            Convert.ToDouble(totalDiscountValue),
                            Convert.ToDouble(txtMoreBills.Text),
                            cbMoreBillsOption.Text,
                            true.ToString(),
                            cbBankAccounting.Text,
                            idPaperReceived,
                            totalCostValue);

                            int id = Convert.ToInt32(mcta.getMaxMaterialCredit());
                            material_credit_listTableAdapter mclta = new material_credit_listTableAdapter();
                            materialTableAdapter mta = new materialTableAdapter();

                            if (rbPaperReceived.Checked)
                            {
                                companyTableAdapter cta = new companyTableAdapter();
                                CompanyControllar.companyDataTable cdt = cta.GetData();
                                DataRow company = cdt.Rows[0];
                                paper_receiveTableAdapter prta = new paper_receiveTableAdapter();
                                prta.Insert(0, "", DateTime.Now, dtpPaperRecieved.Value, company["name"].ToString(), txtCustomer.Text);
                            }
                            if (rbAfter.Checked)
                            {
                                int payCount = Convert.ToInt32(txtPayCount.Text);
                                int payTime = Convert.ToInt32(txtPayTime.Text);
                                int payValue = Convert.ToInt32((totalPriceValue + totalPenfitValue - totalDiscountValue - Convert.ToInt32(txtFiestCashPaymant.Text))) / payCount;

                                material_credit_penfit_paymentTableAdapter mcppta = new material_credit_penfit_paymentTableAdapter();
                                mcppta.Insert(id,
                                    Convert.ToInt32(totalPenfitValue),
                                    Convert.ToInt32(txtPenfitPresent.Text),
                                    payTime,
                                    payCount,
                                    Convert.ToInt32(txtFiestCashPaymant.Text));

                                customer_ReveiveTimeTableAdapter crtta = new customer_ReveiveTimeTableAdapter();
                                for (int i = 1; i <= payCount; i++)
                                {
                                    crtta.Insert(payValue,
                                        nte.changeNumericToWords(payValue),
                                        "قسط مبيعات الزبون " + txtCustomer.Text.Split('.')[0],
                                        DateTime.Now.AddDays(i * payTime),
                                        Convert.ToInt32(txtCustomer.Text.Split('.')[1]),
                                        "false");
                                }
                            }

                            foreach (DataRow row in materialList)
                            {
                                try
                                {
                                    double totalvalue = Convert.ToDouble(row["TotalValue"]);
                                    double discount = Convert.ToDouble(row["Discount"]);

                                    mclta.Insert(Convert.ToInt32(row["الرقم_الفني"]),
                                        id,
                                        row["اسم_المادة"].ToString(),
                                        row["الوحدة"].ToString(),
                                        Convert.ToInt32(row["كمية"].ToString()),
                                        Convert.ToInt32(row["سعر_البيع"].ToString()),
                                        totalvalue + discount,
                                        row["Comment"].ToString(),
                                        0,
                                        nte.changeNumericToWords(Convert.ToInt32(row["كمية"].ToString())),
                                        "",
                                        discount,
                                        Convert.ToInt32(row["سعر_الشراء"].ToString()),
                                        Convert.ToDouble(row["TotalCost"].ToString()));

                                    int quantity = Convert.ToInt32(mta.getMaterialById(Convert.ToInt32(row["الرقم_الفني"]))[0]["كمية"]);

                                    mta.UpdateMaterialQuantity((quantity - Convert.ToInt32(row["كمية"])),
                                        Convert.ToInt32(row["الرقم_الفني"]));

                                    //DETELE MATERIAL QUAINTITY  FROM MATERIAL COST TABLE
                                    //////////////////////////////////////////////////////
                                    material_costTableAdapter mcta_cost = new material_costTableAdapter();
                                    if (row["طريقة_حساب_الكلفة"].ToString() == "FIFO")
                                    {
                                        MaterialControllar.material_costDataTable mcdt_cost = mcta_cost.GetDataById_Quintity_Ascending(Convert.ToInt32(row["الرقم_الفني"]));
                                        int quantity_stay = Convert.ToInt32(row["كمية"]);
                                        foreach (DataRow row1 in mcdt_cost)
                                        {
                                            if (quantity_stay <= Convert.ToInt32(row1["كمية"]) && quantity_stay != 0)
                                            {
                                                row1["كمية"] = Convert.ToInt32(row1["كمية"]) - quantity_stay;
                                                quantity_stay = 0;
                                                mcta_cost.UpdateQuintity(Convert.ToInt32(row1["كمية"]), Convert.ToInt32(row1["رقم_فاتورة_الشراء"]));
                                            }
                                            if (quantity_stay > Convert.ToInt32(row1["كمية"]))
                                            {
                                                quantity_stay = quantity_stay - Convert.ToInt32(row1["كمية"]);
                                                row1["كمية"] = 0;
                                                mcta_cost.UpdateQuintity(Convert.ToInt32(row1["كمية"]), Convert.ToInt32(row1["رقم_فاتورة_الشراء"]));
                                            }
                                        }
                                    }
                                    if (row["طريقة_حساب_الكلفة"].ToString() == "LIFO")
                                    {
                                        MaterialControllar.material_costDataTable mcdt_cost = mcta_cost.GetDataById_quintity_Descending(Convert.ToInt32(row["الرقم_الفني"]));
                                        int quantity_stay = Convert.ToInt32(row["كمية"]);
                                        foreach (DataRow row1 in mcdt_cost)
                                        {
                                            if (quantity_stay <= Convert.ToInt32(row1["كمية"]) && quantity_stay != 0)
                                            {
                                                row1["كمية"] = Convert.ToInt32(row1["كمية"]) - quantity_stay;
                                                quantity_stay = 0;
                                                mcta_cost.UpdateQuintity(Convert.ToInt32(row1["كمية"]), Convert.ToInt32(row1["رقم_فاتورة_الشراء"]));
                                            }
                                            if (quantity_stay > Convert.ToInt32(row1["كمية"]))
                                            {
                                                row1["كمية"] = 0;
                                                quantity_stay = quantity_stay - Convert.ToInt32(row1["كمية"]);
                                                mcta_cost.UpdateQuintity(Convert.ToInt32(row1["كمية"]), Convert.ToInt32(row1["رقم_فاتورة_الشراء"]));
                                            }
                                        }
                                    }
                                    if (row["طريقة_حساب_الكلفة"].ToString() == "AVG")
                                    {
                                        MaterialControllar.material_costDataTable mcdt_cost = mcta_cost.GetDataById_Quintity_Ascending(Convert.ToInt32(row["الرقم_الفني"]));
                                        int quantity_stay = Convert.ToInt32(row["كمية"]);
                                        foreach (DataRow row1 in mcdt_cost)
                                        {
                                            if (quantity_stay <= Convert.ToInt32(row1["كمية"]) && quantity_stay != 0)
                                            {
                                                row1["كمية"] = Convert.ToInt32(row1["كمية"]) - quantity_stay;
                                                quantity_stay = 0;
                                                mcta_cost.UpdateQuintity(Convert.ToInt32(row1["كمية"]), Convert.ToInt32(row1["رقم_فاتورة_الشراء"]));
                                            }
                                            if (quantity_stay > Convert.ToInt32(row1["كمية"]))
                                            {
                                                row1["كمية"] = 0;
                                                quantity_stay = quantity_stay - Convert.ToInt32(row1["كمية"]);
                                                mcta_cost.UpdateQuintity(Convert.ToInt32(row1["كمية"]), Convert.ToInt32(row1["رقم_فاتورة_الشراء"]));
                                            }
                                        }
                                    }

                                    /////////////////////////////////////////////////////
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("لم يتم إضافة " + row["اسم_المادة"].ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            setBond1().SaveBonds();
                            setBond2().SaveBonds();
                            setBond3().SaveBonds();
                            setBond4().SaveBonds();
                            setBond5().SaveBonds();
                            setBond6().SaveBonds();
                            setBond7().SaveBonds();

                            getReportId();
                            if (MessageBox.Show("هل ترغب بستعراض الفاتورة ؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                SaleBills sb = new SaleBills();
                                sb.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("هناك خطأ في الأرصدة لا يمكن إتمام العملية", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("بعض العناصر مفقودة من بطاقة المادة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bSaveBonds_Click(object sender, EventArgs e)
        {
            try
            {
                if (isSaveBonds)
                {
                    MessageBox.Show("لقد تم ترحيل القيود مسبقاً! ", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (SaveBuy)
                    {
                        if (MessageBox.Show("هل تريد ترحيل قيود الإدخال ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            if (rbPaperReceived.Checked)
                            {
                                companyTableAdapter cta = new companyTableAdapter();
                                CompanyControllar.companyDataTable cdt = cta.GetData();
                                DataRow company = cdt.Rows[0];
                                paper_receiveTableAdapter prta = new paper_receiveTableAdapter();
                                prta.Insert(0, "", DateTime.Now, dtpPaperRecieved.Value, company["name"].ToString(), txtCustomer.Text);
                            }
                            if (rbAfter.Checked)
                            {
                                int payCount = Convert.ToInt32(txtPayCount.Text);
                                int payTime = Convert.ToInt32(txtPayTime.Text);
                                int payValue = Convert.ToInt32((totalPriceValue + totalPenfitValue - totalDiscountValue - Convert.ToInt32(txtFiestCashPaymant.Text))) / payCount;

                                customer_ReveiveTimeTableAdapter crtta = new customer_ReveiveTimeTableAdapter();
                                for (int i = 1; i <= payCount; i++)
                                {
                                    crtta.Insert(payValue,
                                        nte.changeNumericToWords(payValue),
                                        "قسط مبيعات الزبون " + txtCustomer.Text.Split('.')[0],
                                        DateTime.Now.AddDays(i * payTime),
                                        Convert.ToInt32(txtCustomer.Text.Split('.')[1])
                                        , "false");
                                }
                            }

                            foreach (DataRow row in materialList)
                            {
                                //DETELE MATERIAL QUAINTITY  FROM MATERIAL COST TABLE
                                //////////////////////////////////////////////////////
                                material_costTableAdapter mcta_cost = new material_costTableAdapter();
                                if (row["طريقة_حساب_الكلفة"].ToString() == "FIFO")
                                {
                                    MaterialControllar.material_costDataTable mcdt_cost = mcta_cost.GetDataById_Quintity_Ascending(Convert.ToInt32(row["الرقم_الفني"]));
                                    int quantity_stay = Convert.ToInt32(row["كمية"]);
                                    foreach (DataRow row1 in mcdt_cost)
                                    {
                                        if (quantity_stay <= Convert.ToInt32(row1["كمية"]) && quantity_stay != 0)
                                        {
                                            row1["كمية"] = Convert.ToInt32(row1["كمية"]) - quantity_stay;
                                            quantity_stay = 0;
                                            mcta_cost.UpdateQuintity(Convert.ToInt32(row1["كمية"]), Convert.ToInt32(row1["رقم_فاتورة_الشراء"]));
                                        }
                                        if (quantity_stay > Convert.ToInt32(row1["كمية"]))
                                        {
                                            quantity_stay = quantity_stay - Convert.ToInt32(row1["كمية"]);
                                            row1["كمية"] = 0;
                                            mcta_cost.UpdateQuintity(Convert.ToInt32(row1["كمية"]), Convert.ToInt32(row1["رقم_فاتورة_الشراء"]));
                                        }
                                    }
                                }
                                if (row["طريقة_حساب_الكلفة"].ToString() == "LIFO")
                                {
                                    MaterialControllar.material_costDataTable mcdt_cost = mcta_cost.GetDataById_quintity_Descending(Convert.ToInt32(row["الرقم_الفني"]));
                                    int quantity_stay = Convert.ToInt32(row["كمية"]);
                                    foreach (DataRow row1 in mcdt_cost)
                                    {
                                        if (quantity_stay <= Convert.ToInt32(row1["كمية"]) && quantity_stay != 0)
                                        {
                                            row1["كمية"] = Convert.ToInt32(row1["كمية"]) - quantity_stay;
                                            quantity_stay = 0;
                                            mcta_cost.UpdateQuintity(Convert.ToInt32(row1["كمية"]), Convert.ToInt32(row1["رقم_فاتورة_الشراء"]));
                                        }
                                        if (quantity_stay > Convert.ToInt32(row1["كمية"]))
                                        {
                                            row1["كمية"] = 0;
                                            quantity_stay = quantity_stay - Convert.ToInt32(row1["كمية"]);
                                            mcta_cost.UpdateQuintity(Convert.ToInt32(row1["كمية"]), Convert.ToInt32(row1["رقم_فاتورة_الشراء"]));
                                        }
                                    }
                                }
                                if (row["طريقة_حساب_الكلفة"].ToString() == "AVG")
                                {
                                    MaterialControllar.material_costDataTable mcdt_cost = mcta_cost.GetDataById_Quintity_Ascending(Convert.ToInt32(row["الرقم_الفني"]));
                                    int quantity_stay = Convert.ToInt32(row["كمية"]);
                                    foreach (DataRow row1 in mcdt_cost)
                                    {
                                        if (quantity_stay <= Convert.ToInt32(row1["كمية"]) && quantity_stay != 0)
                                        {
                                            row1["كمية"] = Convert.ToInt32(row1["كمية"]) - quantity_stay;
                                            quantity_stay = 0;
                                            mcta_cost.UpdateQuintity(Convert.ToInt32(row1["كمية"]), Convert.ToInt32(row1["رقم_فاتورة_الشراء"]));
                                        }
                                        if (quantity_stay > Convert.ToInt32(row1["كمية"]))
                                        {
                                            row1["كمية"] = 0;
                                            quantity_stay = quantity_stay - Convert.ToInt32(row1["كمية"]);
                                            mcta_cost.UpdateQuintity(Convert.ToInt32(row1["كمية"]), Convert.ToInt32(row1["رقم_فاتورة_الشراء"]));
                                        }
                                    }
                                }

                                /////////////////////////////////////////////////////
                            }

                            setBond1().SaveBonds();
                            setBond2().SaveBonds();
                            setBond3().SaveBonds();
                            setBond4().SaveBonds();
                            setBond5().SaveBonds();
                            setBond6().SaveBonds();
                            setBond7().SaveBonds();

                            rowMaterialdCredit["مرحل"] = true.ToString();
                            material_creditTableAdapter mcta = new material_creditTableAdapter();
                            mcta.Update(rowMaterialdCredit);
                            MessageBox.Show("لقد تم ترحيل القيود ! ", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("بعض العناصر مفقودة من بطاقة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bSaveCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbPaperReceived.Checked && (dtpPaperRecieved.Value.Date <= DateTime.Now.Date))
                {
                    MessageBox.Show("تاريخ إستحقاق ورقة القبض يجب أن لا يكون أصغر أو يساوي التاريخ اليوم", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (SaveBuy)
                    {
                        if (MessageBox.Show("هل تريد حفط التقرير ؟", "رسالة تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            double price = totalPriceValue + totalPenfitValue - totalDiscountValue;
                            if (cbMoreBillsOption.Text == "على الزبون")
                            {
                                price = price + Convert.ToDouble(txtMoreBills.Text);
                            }
                            material_creditTableAdapter mcta = new material_creditTableAdapter();

                            mcta.Insert(DateTime.Now,
                            dtpReciveDate.Value,
                            price,
                            nte.changeNumericToWords(price),
                            "زبون." + txtCustomer.Text,
                            "",
                            cbTypeOperation.Text,
                            Convert.ToInt32(txtCustomer.Text.Split('.')[1]),
                            "",
                            "",
                            getType(),
                            Convert.ToDouble(totalDiscountValue),
                            Convert.ToDouble(txtMoreBills.Text),
                            cbMoreBillsOption.Text,
                            false.ToString(),
                            cbBankAccounting.Text,
                            idPaperReceived,
                            totalCostValue);

                            int id = Convert.ToInt32(mcta.getMaxMaterialCredit());
                            material_credit_listTableAdapter mclta = new material_credit_listTableAdapter();
                            materialTableAdapter mta = new materialTableAdapter();

                            if (rbAfter.Checked)
                            {
                                int payCount = Convert.ToInt32(txtPayCount.Text);
                                int payTime = Convert.ToInt32(txtPayTime.Text);
                                //int payValue = Convert.ToInt32((totalPriceValue + totalPenfitValue - totalDiscountValue - Convert.ToInt32(txtFiestCashPaymant.Text))) / payCount;

                                material_credit_penfit_paymentTableAdapter mcppta = new material_credit_penfit_paymentTableAdapter();
                                mcppta.Insert(id,
                                    Convert.ToInt32(totalPenfitValue),
                                    Convert.ToInt32(txtPenfitPresent.Text),
                                    payTime,
                                    payCount,
                                    Convert.ToInt32(txtFiestCashPaymant.Text));
                            }
                            foreach (DataRow row in materialList)
                            {
                                try
                                {
                                    double totalvalue = Convert.ToDouble(row["TotalValue"]);
                                    double discount = Convert.ToDouble(row["Discount"]);

                                    mclta.Insert(Convert.ToInt32(row["الرقم_الفني"]),
                                        id,
                                        row["اسم_المادة"].ToString(),
                                        row["الوحدة"].ToString(),
                                        Convert.ToInt32(row["كمية"].ToString()),
                                        Convert.ToInt32(row["سعر_البيع"].ToString()),
                                        totalvalue + discount,
                                        row["Comment"].ToString(),
                                        0,
                                        nte.changeNumericToWords(Convert.ToInt32(row["كمية"].ToString())),
                                        "",
                                        discount,
                                        Convert.ToInt32(row["سعر_الشراء"].ToString()),
                                        Convert.ToDouble(row["TotalCost"].ToString()));

                                    int quantity = Convert.ToInt32(mta.getMaterialById(Convert.ToInt32(row["الرقم_الفني"]))[0]["كمية"]);

                                    mta.UpdateMaterialQuantity((quantity - Convert.ToInt32(row["كمية"])),
                                        Convert.ToInt32(row["الرقم_الفني"]));
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("لم يتم إضافة " + row["اسم_المادة"].ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            getReportId();
                            if (MessageBox.Show("هل ترغب بستعراض الفاتورة ؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                SaleBills sb = new SaleBills();
                                sb.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("هناك خطأ في الأرصدة لا يمكن إتمام العملية", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("بعض العناصر مفقودة من بطاقة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bShow_Click(object sender, EventArgs e)
        {
            gbBonds.Show();
        }

        private void cbBankAccounting_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void cbMoreBillsOption_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception)
            {
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
                    // Makes sure serial port is open before trying to write
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

        private void cbTypeOperation_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbTypeOperation.Text == "شيك")
            {
                cbBankAccounting.Enabled = true;
                bAddBond_Click(sender, e);
            }
            else
            {
                cbBankAccounting.Enabled = false;
                bAddBond_Click(sender, e);
            }
        }

        private void dataGridViewMaterial_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            calculateReportValue();
        }

        private void dataGridViewMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                bRemoveMaterial_Click(sender, e);
            }
        }

        private void dtpPaperRecieved_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
                //lDatePayment.Text=" الإستحقاق في: "+dtpReciveDate.Value.;
            }
            catch (Exception)
            {
            }
        }

        private void getBankAccounting()
        {
            bank_accountTableAdapter bata = new bank_accountTableAdapter();
            BankControllar.bank_accountDataTable badt = bata.GetData();
            foreach (DataRow dr in badt.Rows)
            {
                cbBankAccounting.Items.Add(dr["اسم_الحساب"] + "." + dr["الرقم"]);
            }
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

        private void getReport(int indexValue)
        {
            try
            {
                txtId.Text = cbIds.Items[indexValue].ToString();
                int id = Convert.ToInt32(txtId.Text);
                material_creditTableAdapter mcta = new material_creditTableAdapter();
                MaterialControllar.material_creditDataTable mcdt = mcta.getMaterialCreditById(id);
                rowMaterialdCredit = mcdt.Rows[0];

                txtCustomer.Text = rowMaterialdCredit["إلى"].ToString().Split('.')[1] + "." + rowMaterialdCredit["إلى"].ToString().Split('.')[2];
                totalPriceValue = Convert.ToDouble(rowMaterialdCredit["الرصيد"].ToString());
                txtTotalPrice.Text = rowMaterialdCredit["الرصيد"].ToString();
                totalDiscountValue = Convert.ToDouble(rowMaterialdCredit["حسم_ممنوح"].ToString());
                txtDiscount.Text = rowMaterialdCredit["حسم_ممنوح"].ToString();
                txtTotalCost.Text = rowMaterialdCredit["الكلفة"].ToString();

                if (rowMaterialdCredit["نوع_العملية"].ToString() == "نقداً")
                {
                    rbCash.Checked = true;
                }
                if (rowMaterialdCredit["نوع_العملية"].ToString() == "لأجل")
                {
                    rbAfter.Checked = true;
                }
                if (rowMaterialdCredit["نوع_العملية"].ToString() == "سند قبض لأجل")
                {
                    rbPaperReceived.Checked = true;
                }
                cbTypeOperation.Text = rowMaterialdCredit["طريقة_الدفع"].ToString();
                cbBankAccounting.Text = rowMaterialdCredit["اسم_الحساب"].ToString();
                //dtpSaleDate.Value = Convert.ToDateTime(rowMaterialdCredit["تاريخ_البيع"]);
                dtpReciveDate.Value = Convert.ToDateTime(rowMaterialdCredit["تاريخ_التسليم"]);
                txtMoreBills.Text = rowMaterialdCredit["مصاريف_مضافة"].ToString();
                cbMoreBillsOption.Text = rowMaterialdCredit["مصاريف_على_حساب"].ToString();
                isSaveBonds = Convert.ToBoolean(rowMaterialdCredit["مرحل"]);
                //idPaperReceived = 0;
                idPaperReceived = Convert.ToInt32(rowMaterialdCredit["سند_القبض"]);
                //change here
                if (rbAfter.Checked)
                {
                    material_credit_penfit_paymentTableAdapter mcppta = new material_credit_penfit_paymentTableAdapter();
                    MaterialControllar.material_credit_penfit_paymentDataTable mcppdt = mcppta.getPenfitPaymentById(id);
                    DataRow mcppr = mcppdt.Rows[0];
                    txtFiestCashPaymant.Text = mcppr["الرعبون"].ToString();
                    txtPenfitValue.Text = mcppr["الفائدة"].ToString();
                    txtPenfitPresent.Text = mcppr["نسبة_الفائدة"].ToString();
                    txtPayTime.Value = Convert.ToInt32(mcppr["الدفع_كل"].ToString());
                    txtPayCount.Text = mcppr["عدد_الأقساط"].ToString();
                }
                txtTotalProfit.Text = (totalPriceValue - totalDiscountValue + Convert.ToInt32(txtPenfitValue.Text) - Convert.ToInt32(rowMaterialdCredit["الكلفة"].ToString())).ToString();

                if (isSaveBonds)
                {
                    gbBonds.Text = "تم ترحيل قيد العملية";
                    gbBonds.ForeColor = Color.Green;
                }
                if (!isSaveBonds)
                {
                    gbBonds.Text = "لم يتم ترحيل قيد العملية";
                    gbBonds.ForeColor = Color.Red;
                }
                material_credit_listTableAdapter mclta = new material_credit_listTableAdapter();
                MaterialControllar.material_credit_listDataTable mcldt = mclta.getMaterialCreditReport(id);

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

                int count = 0;
                materialList.Clear();
                //change
                double price = 0;

                double material_cost = 0;
                foreach (DataRow dr in mcldt)
                {
                    materialTableAdapter mta1 = new materialTableAdapter();
                    MaterialControllar.materialDataTable material = mta1.getMaterialById(Convert.ToInt32(dr["رقم_المادة"]));

                    dataGridViewMaterial.Rows[count].Cells[0].Value = dr["رقم_المادة"];
                    dataGridViewMaterial.Rows[count].Cells[1].Value = dr["اسم_المادة"];
                    dataGridViewMaterial.Rows[count].Cells[2].Value = dr["الكمية"];
                    dataGridViewMaterial.Rows[count].Cells[3].Value = dr["السعر"];
                    dataGridViewMaterial.Rows[count].Cells[4].Value = Convert.ToInt32((Convert.ToDouble(dr["حسم_ممنوح"]) / Convert.ToDouble(dr["السعر_الجمالي"])) * 100);
                    dataGridViewMaterial.Rows[count].Cells[5].Value = dr["حسم_ممنوح"];
                    dataGridViewMaterial.Rows[count].Cells[6].Value = dr["السعر_الجمالي"];
                    dataGridViewMaterial.Rows[count].Cells[7].Value = dr["ملاحظات"];
                    material_cost = Convert.ToDouble(dr["الكلفة"]) / Convert.ToDouble(dr["الكمية"]);

                    dataGridViewMaterial.Rows[count].Cells[8].Value = Convert.ToInt32(Convert.ToDouble(dr["الكلفة"]) / Convert.ToDouble(dr["الكمية"])).ToString();
                    dataGridViewMaterial.Rows[count].Cells[9].Value = (material_cost * Convert.ToDouble(dr["الكمية"])).ToString();
                    dataGridViewMaterial.Rows[count].Cells[10].Value = ((Convert.ToDouble(dr["السعر"]) * Convert.ToDouble(dr["الكمية"])) - (material_cost * Convert.ToDouble(dr["الكمية"]))).ToString();

                    //change
                    price = price + Convert.ToDouble(dr["السعر_الجمالي"]);
                    //
                    count++;
                    material.Rows[0]["كمية"] = dr["الكمية"];
                    materialList.Add(material.Rows[0]);
                }
                //change
                txtTotalPrice.Text = price.ToString();
                //
            }
            catch (Exception)
            {
            }
        }

        private void getReportId()
        {
            material_creditTableAdapter mcta = new material_creditTableAdapter();
            MaterialControllar.material_creditDataTable mcdt = mcta.GetData();
            cbIds.Items.Clear();
            foreach (DataRow dr in mcdt.Rows)
            {
                cbIds.Items.Add(dr["الرقم"]);
            }
        }

        private string getType()
        {
            string value = "";
            if (rbCash.Checked)
            {
                value = "نقداً";
            }
            if (rbAfter.Checked)
            {
                value = "لأجل";
            }
            if (rbPaperReceived.Checked)
            {
                value = "سند قبض لأجل";
            }
            return value;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            getReportId();
            txtCustomer.Text = "";
            txtTotalPrice.Text = "0";
            txtDiscount.Text = "0";

            //dtpSaleDate.Value = DateTime.Now;
            dtpReciveDate.Value = DateTime.Now;
            totalPriceValue = 0;
            totalDiscountValue = 0;
            txtMoreBills.Text = "0";
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
            gbBonds.Text = "قيد العملية";
            gbBonds.ForeColor = Color.Black;

            for (int i = 0; i < 9; i++)
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";
                bc.comment = "";

                //bcList.Add(bc);
                dataGridViewBond.Rows[i].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[i].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[i].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[i].Cells[3].Value = "";
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            SaleBills sb = new SaleBills();
            sb.ShowDialog();
        }

        private void rbAfter_CheckedChanged(object sender, EventArgs e)
        {
            pPayAfter.Show();
            dtpPaperRecieved.Enabled = false;
            cbTypeOperation.Enabled = true;
            cbBankAccounting.Enabled = false;
            dtpPaperRecieved.Enabled = false;
            cbTypeOperation.Text = "كاش";
            cbBankAccounting.Text = "";
            bAddBond_Click(sender, e);
            if (rbAfter.Checked)
            {
                epInformation.SetError((Control)sender, "البيع من خلال عملية تقسيط المبيعات");
            }
            else
            {
                epInformation.SetError((Control)sender, "");
            }
        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            pPayAfter.Hide();
            cbTypeOperation.Enabled = true;
            cbBankAccounting.Enabled = false;
            dtpPaperRecieved.Enabled = false;
            cbTypeOperation.Text = "كاش";

            bAddBond_Click(sender, e);
            if (rbCash.Checked)
            {
                epInformation.SetError((Control)sender, "الدفع نقداً عن طريق الصندوق");
            }
            else
            {
                epInformation.SetError((Control)sender, "");
            }
        }

        private void rbPaperReceived_CheckedChanged(object sender, EventArgs e)
        {
            pPayAfter.Hide();
            dtpPaperRecieved.Enabled = true;
            //dtpPayTime.Enabled = false;
            cbTypeOperation.Enabled = false;
            cbBankAccounting.Enabled = false;
            cbTypeOperation.Text = "";
            cbBankAccounting.Text = "";
            paper_receiveTableAdapter prta = new paper_receiveTableAdapter();
            idPaperReceived = Convert.ToInt32(prta.getMaxPaperRecieved()) + 1;
            bAddBond_Click(sender, e);
            if (rbPaperReceived.Checked)
            {
                epInformation.SetError((Control)sender, "الدفع عن طريق كمبيالة قبض بتاريخ إستحقاق ");
            }
            else
            {
                epInformation.SetError((Control)sender, "");
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
            catch (Exception)
            {
            }
        }

        private void Sale_FormClosed(object sender, FormClosedEventArgs e)
        {
            materialList.Clear();
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            dataGridViewMaterial.RowCount = 20;
            dataGridViewBond.RowCount = 9;
            getCustomerNameAutocomplete();
            getMaterialNameAutocomplete();
            getBankAccounting();
            getReportId();
            pPayAfter.Hide();
            newToolStripButton_Click(sender, e);

        }
        private void Sale_Resize(object sender, EventArgs e)
        {
        }

        private BondControllar setBond1()
        {
            material_creditTableAdapter mcta = new material_creditTableAdapter();
            if (totalPriceValue > 0)
            {
                bc = new BondControllar();

                bc.balance = totalPriceValue + totalDiscountValue;
                bc.balanceText = nte.changeNumericToWords(totalPriceValue + totalDiscountValue);
                bc.bondFrom = "زبون." + txtCustomer.Text;
                bc.bondTo = "مبيعات." + (Convert.ToInt32(mcta.getMaxMaterialCredit()));
                bc.comment = "بيع يضاعة للزبون " + txtCustomer.Text;

                //bcList.Add(bc);
                dataGridViewBond.Rows[0].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[0].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[0].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[0].Cells[3].Value = bc.comment;
            }

            return bc;
        }

        private BondControllar setBond2()
        {
            if (totalDiscountValue > 0)
            {
                bc = new BondControllar();

                bc.balance = totalDiscountValue;
                bc.balanceText = nte.changeNumericToWords(totalDiscountValue);
                bc.bondFrom = "حسم ممنوح";
                bc.bondTo = "زبون." + txtCustomer.Text;
                bc.comment = "تقديم حسم ممنوح للزبو " + txtCustomer.Text + " لقاء بضاعة ";

                //bcList.Add(bc);
                dataGridViewBond.Rows[1].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[1].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[1].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[1].Cells[3].Value = bc.comment;
            }
            else
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";
                bc.comment = "";

                //bcList.Add(bc);
                dataGridViewBond.Rows[1].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[1].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[1].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[1].Cells[3].Value = bc.comment;
            }

            return bc;
        }

        private BondControllar setBond3()
        {
            material_creditTableAdapter mcta = new material_creditTableAdapter();
            if (Convert.ToInt32(txtMoreBills.Text) > 0)
            {
                if (cbMoreBillsOption.Text == "على الزبون")
                {
                    bc = new BondControllar();

                    bc.balance = Convert.ToDouble(txtMoreBills.Text);
                    bc.balanceText = nte.changeNumericToWords(Convert.ToDouble(txtMoreBills.Text));
                    bc.bondFrom = "زبون." + txtCustomer.Text;
                    bc.bondTo = "مصاريف البيع." + (Convert.ToInt32(mcta.getMaxMaterialCredit()));
                    bc.comment = "مصاريف البيع يضاعة للزبون " + txtCustomer.Text + " على حساب الزبون";

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[2].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[2].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[2].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[2].Cells[3].Value = bc.comment;
                }
                if (cbMoreBillsOption.Text == "على الشركة")
                {
                    bc = new BondControllar();
                    bc.balance = Convert.ToDouble(txtMoreBills.Text);
                    bc.balanceText = nte.changeNumericToWords(Convert.ToDouble(txtMoreBills.Text));
                    bc.bondFrom = "مصاريف البيع." + (Convert.ToInt32(mcta.getMaxMaterialCredit()) + 1);
                    bc.bondTo = "صندوق.صندوق.1";
                    bc.comment = "مصاريف البيع يضاعة للزبون " + txtCustomer.Text + " على حساب الشركة";

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[2].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[2].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[2].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[2].Cells[3].Value = bc.comment;
                }
            }
            else
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";
                bc.comment = "";

                //bcList.Add(bc);
                dataGridViewBond.Rows[2].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[2].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[2].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[2].Cells[3].Value = "";
            }
            return bc;
        }

        private BondControllar setBond4()
        {
            if (rbCash.Checked)
            {
                if (totalPriceValue > 0 && cbTypeOperation.Text == "كاش")
                {
                    bc = new BondControllar();

                    if (cbMoreBillsOption.Text == "على الشركة")
                    {
                        bc.balance = totalPriceValue;
                        bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    }
                    else
                    {
                        bc.balance = totalPriceValue + Convert.ToDouble(txtMoreBills.Text);
                        bc.balanceText = nte.changeNumericToWords(totalPriceValue + Convert.ToDouble(txtMoreBills.Text));
                    }
                    bc.bondFrom = "صندوق.صندوق اليومية.1";
                    bc.bondTo = "زبون." + txtCustomer.Text;
                    bc.comment = "تسديد الزبون " + txtCustomer.Text + " نقداً لقاء بضاعة";

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[4].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[4].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[4].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[4].Cells[3].Value = bc.comment;
                }
                if (totalPriceValue > 0 && cbTypeOperation.Text == "شيك")
                {
                    bc = new BondControllar();

                    if (cbMoreBillsOption.Text == "على الشركة")
                    {
                        bc.balance = totalPriceValue;
                        bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    }
                    else
                    {
                        bc.balance = totalPriceValue + Convert.ToDouble(txtMoreBills.Text);
                        bc.balanceText = nte.changeNumericToWords(totalPriceValue + Convert.ToDouble(txtMoreBills.Text));
                    }
                    bc.bondFrom = "مصرف." + cbBankAccounting.Text;
                    bc.bondTo = "زبون." + txtCustomer.Text;
                    bc.comment = "تسديد الزبون " + txtCustomer.Text + " بشيك لقاء بضاعة";

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[4].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[4].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[4].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[4].Cells[3].Value = bc.comment;
                }
            }
            else
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";
                bc.comment = "";

                //bcList.Add(bc);
                dataGridViewBond.Rows[4].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[4].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[4].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[4].Cells[3].Value = bc.comment;
            }
            return bc;
        }

        private BondControllar setBond5()
        {
            if (rbPaperReceived.Checked)
            {
                if (totalPriceValue > 0)
                {
                    bc = new BondControllar();

                    if (cbMoreBillsOption.Text == "على الشركة")
                    {
                        bc.balance = totalPriceValue;
                        bc.balanceText = nte.changeNumericToWords(totalPriceValue);
                    }
                    else
                    {
                        bc.balance = totalPriceValue + Convert.ToDouble(txtMoreBills.Text);
                        bc.balanceText = nte.changeNumericToWords(totalPriceValue + Convert.ToDouble(txtMoreBills.Text));
                    }
                    paper_receiveTableAdapter prta = new paper_receiveTableAdapter();
                    bc.bondFrom = "سند قبض." + txtCustomer.Text.Split('.')[0] + "." + (idPaperReceived);
                    bc.bondTo = "زبون." + txtCustomer.Text;
                    bc.comment = "إستلام من الزبون " + txtCustomer.Text + " كمبيالة (سند قبض) يستحق بتاريخ " + dtpPaperRecieved.Value;

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[5].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[5].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[5].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[5].Cells[3].Value = bc.comment;
                }
            }
            else
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";
                bc.comment = "";

                //bcList.Add(bc);
                dataGridViewBond.Rows[5].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[5].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[5].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[5].Cells[3].Value = bc.comment;
            }
            return bc;
        }

        private BondControllar setBond6()
        {
            if (rbAfter.Checked)
            {
                double penfitPersent = Convert.ToInt32(txtPenfitPresent.Text);
                if (txtPenfitPresent.Text == "")
                {
                    txtPenfitPresent.Text = "0";
                }
                {
                }
                if (penfitPersent >= 0 && penfitPersent <= 100)
                {
                    txtPenfitValue.Text = (Convert.ToInt32(txtTotalPrice.Text) * (penfitPersent / 100)).ToString();
                    totalPenfitValue = Convert.ToDouble(txtPenfitValue.Text);
                }
                else
                {
                    txtPenfitPresent.Text = "0";
                    MessageBox.Show("الفائدة بين 0 و 100", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (totalPenfitValue > 0)
                {
                    bc = new BondControllar();

                    bc.balance = totalPenfitValue;
                    bc.balanceText = nte.changeNumericToWords(totalPenfitValue);
                    bc.bondFrom = "زبون." + txtCustomer.Text;
                    bc.bondTo = "فائدة مبيعات التقسيط";
                    bc.comment = "الحصول على فائدة مبيعات التقسيط من الربون" + txtCustomer.Text + " لقاء بضاعة ";

                    //bcList.Add(bc);
                    dataGridViewBond.Rows[6].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[6].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[6].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[6].Cells[3].Value = bc.comment;
                }
            }
            else
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";
                bc.comment = "";

                //bcList.Add(bc);
                dataGridViewBond.Rows[6].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[6].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[6].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[6].Cells[3].Value = bc.comment;
            }

            return bc;
        }

        private BondControllar setBond7()
        {
            if (rbAfter.Checked)
            {
                if (txtFiestCashPaymant.Text != "0" && cbTypeOperation.Text == "كاش")
                {
                    bc = new BondControllar();

                    bc.balance = Convert.ToDouble(txtFiestCashPaymant.Text);
                    bc.balanceText = nte.changeNumericToWords(Convert.ToDouble(txtFiestCashPaymant.Text));
                    bc.bondFrom = "صندوق.صندوق اليومية.1";
                    bc.bondTo = "زبون." + txtCustomer.Text;
                    //change
                    bc.comment = "تسديد الزبون " + txtCustomer.Text + " نقداً رعبون بضاعة تقسيط";
                    //
                    //bcList.Add(bc);
                    dataGridViewBond.Rows[7].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[7].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[7].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[7].Cells[3].Value = bc.comment;
                }
                if (txtFiestCashPaymant.Text != "0" && cbTypeOperation.Text == "شيك")
                {
                    bc = new BondControllar();

                    bc.balance = Convert.ToDouble(txtFiestCashPaymant.Text); ;
                    bc.balanceText = nte.changeNumericToWords(Convert.ToDouble(txtFiestCashPaymant.Text));
                    bc.bondFrom = "مصرف." + cbBankAccounting.Text;
                    bc.bondTo = "زبون." + txtCustomer.Text;
                    //change
                    bc.comment = "تسديد الزبون " + txtCustomer.Text + " بشيك لقاء رعبون بضاعة تقسيط";
                    //
                    //bcList.Add(bc);
                    dataGridViewBond.Rows[7].Cells[0].Value = bc.balance;
                    dataGridViewBond.Rows[7].Cells[1].Value = bc.bondFrom;
                    dataGridViewBond.Rows[7].Cells[2].Value = bc.bondTo;
                    dataGridViewBond.Rows[7].Cells[3].Value = bc.comment;
                }
            }
            else
            {
                bc = new BondControllar();

                bc.balance = 0;
                bc.balanceText = "";
                bc.bondFrom = "";
                bc.bondTo = "";
                bc.comment = "";

                //bcList.Add(bc);
                dataGridViewBond.Rows[7].Cells[0].Value = bc.balance;
                dataGridViewBond.Rows[7].Cells[1].Value = bc.bondFrom;
                dataGridViewBond.Rows[7].Cells[2].Value = bc.bondTo;
                dataGridViewBond.Rows[7].Cells[3].Value = bc.comment;
            }

            return bc;
        }

        private void si_DataReceived(string data)
        {
            txtSearchMaterial.Text = data.Trim();
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
            string data = _serialPort.ReadLine();
            this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Console.WriteLine("id: " + txtCustomer.Text.Split('.')[1]);
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void txtCustomer_Validating(object sender, CancelEventArgs e)
        {
            if (txtCustomer.Text == "")
            {
                errorProvider1.SetError((Control)sender, "حقل اسم العميل فارغ");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }
        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void txtFiestCashPa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiestCashPaymant.Text == "")
                {
                    txtFiestCashPaymant.Text = "0";
                }
                bAddBond_Click(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void txtMaterialSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bAddMaterial_Click(sender, e);
            }
        }
        private void txtMoreBills_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMoreBills.Text == "")
                {
                    txtMoreBills.Text = "0";
                }
                bAddBond_Click(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void txtPayPersent_TextChanged(object sender, EventArgs e)
        {
            if (txtPenfitValue.Text != "0")
            {
                epInformation2.SetError((Control)sender, "عدد الأقساط التي يجب أن يدفعها الزبون");
            }
            else
            {
                epInformation2.SetError((Control)sender, "");
            }
        }

        private void txtPenfitPresent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception)
            {
                txtPenfitPresent.Text = "0";
            }
        }

        private void txtPenfitValue_TextChanged(object sender, EventArgs e)
        {
            if (txtPenfitValue.Text != "0")
            {
                epInformation2.SetError((Control)sender, "الفائدة المدفوعة على المبيعات");
            }
            else
            {
                epInformation2.SetError((Control)sender, "");
            }
        }

        private void txtQuintity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bAddMaterial_Click(sender, e);
            }
        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bAddBond_Click(sender, e);
            }
            catch (Exception)
            {
            }
        }
    }
}