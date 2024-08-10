using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entityForm;
using Program.entityForm.customer;
using Program.entityForm.Supplier;
using Program.entityForm.Box;
using Program.entityForm.Bonds;
using Program.entityForm.File;
using Program.entityForm.Material;
using Program.entityForm.customer.report;
using Program.entityForm.Supplier.Report;
using Program.entityForm.Box.report;
using Program.entityForm.Customer.Report;
using Program.entityForm.Material.report;
using Program.entityForm.Bank.report;
using Program.entityForm.Assets;
using Program.entity.controllar.CompanyControllarTableAdapters;
using Program.entityForm.FileData;
using Program.entity.controllar.PaperPayControllarTableAdapters;
using Program.entity.controllar;
using Program.entity.controllar.PaperReceiveControllarTableAdapters;
using Program.entity.controllar.MaterialControllarTableAdapters;
using Program.entity.controllar.CustomerControllarTableAdapters;
using System.Diagnostics;
using Program.Connection;
using ConfigUpdater;
using ConfigForm = ConfigUpdater.ConfigForm;
using System.Globalization;
using System.Threading;

//WIN-IS6T0MAU3LS
namespace Program
{
    public partial class Main : Form
    {
        public Main()
        {
            ApplyLanguage("en");
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            bFolder_Click(sender, e);
            start();

        }

        private void ApplyLanguage(string cultureCode)
        {
            // Set the current culture and UI culture
            CultureInfo culture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

           
        }

        public void start()
        {
            try
            {
                if (!Connect.TestConnection())
                {
                    ConfigForm nc = new ConfigForm();
                    nc.ShowDialog();
                }
               
            }
            catch (Exception ex)
            {
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void miCompanyInfo_Click(object sender, EventArgs e)
        {
            NewCompany nc = new NewCompany();
            nc.StartPosition = FormStartPosition.CenterScreen;
            nc.ShowDialog();
        }

        private void miNewCustumer_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("NewCustomer");
            NewCustomer nc = new NewCustomer();
            nc.StartPosition = FormStartPosition.Manual;
            nc.MdiParent = this;
            nc.Show();
        }

        private void miNewMaterial_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("NewMaterial");
            NewMaterial nm = new NewMaterial();
            nm.StartPosition = FormStartPosition.Manual;
            nm.MdiParent = this;
            nm.LayoutMdi(MdiLayout.ArrangeIcons);
            nm.Show();
        }

        private void miVendor_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("NewSupplier");
            NewSupplier ns = new NewSupplier();
            ns.StartPosition = FormStartPosition.Manual;
            ns.MdiParent = this;
            ns.LayoutMdi(MdiLayout.ArrangeIcons);
            ns.Show();
        }


        private void lvFormOption_Click(object sender, EventArgs e)
        {
            
            string text = lvFormOption.Items[lvFormOption.FocusedItem.Index].Text;
            
            switch (text)
            {
                case "إضافة زبون":
                    miNewCustumer_Click(sender, e);
                    break;
                case "السلع و الخدمات الجديدة":
                    miNewMaterial_Click(sender, e);
                    break;
                case "إضافة مورد":
                    miVendor_Click(sender, e);
                    break;
                case "إضافة بنك":
                    miNewBank_Click(sender, e);
                    break;
                case "إضافة حساب بنكي":
                    miBankAccounting_Click(sender, e);
                    break;
                case "إضافة طلبية بيع بضاعة":
                    miSaleCash_Click(sender, e);
                    break;
                case "إضافة طلبية شراء بضاعة":
                    miBuy_Click(sender, e);
                    break;
                case "تلقي دفعات الزبائن":
                    miCustomerPayment_Click(sender, e);
                    break;
                case "دفع مبلغ للموردين":
                    miSupplierPayment_Click(sender, e);
                    break;
                case "سحب أو يداع مبلغ":
                    miBankTransfare_Click(sender, e);
                    break;
                case "إضافة صندوق":
                    miNewBox_Click(sender, e);
                    break;
                case "دفع أو قبض مبلغ":
                    miBoxTransfare_Click(sender, e);
                    break;
                case "ردّ بضاعة مباعة":
                    miReturnSales_Click(sender, e);
                    break;
                case "ردّ بضاعة مشترات":
                    miReturnBuy_Click(sender, e);
                    break;
                case "إضافة القيود اليومية":
                    miAddBonds_Click(sender, e);
                    break;
                case "جردّ بضاعة المستودعات":
                    miMaterialInventory_Click(sender, e);
                    break;
                case "حساب الزبون":
                    miReportCustomerAccounting_Click(sender, e);
                    break;
                case "بطاقة مبيعات الزبون":
                    miMaterialSale_Click(sender, e);
                    break;
                case "حساب المورد":
                    miReportSupplierAccounting_Click(sender, e);
                    break;
                case "بطاقة مشتريات المورد":
                    miMaterialBuy_Click(sender, e);
                    break;
                case "حساب الصندوق":
                    miBoxAccounting_Click(sender, e);
                    break;
                case "فاتورة بيع مواد":
                    miSaleBills_Click(sender, e);
                    break;
                case "وثيقة إدخال مواد":
                    miBuyList_Click(sender, e);
                    break;
                case "تقرير إعادة بضاعة مباعة":
                    miReturnSaleBills_Click(sender, e);
                    break;
                case "تقرير إعادة بضاعة مشترات":
                    miReturnBuyBills_Click(sender, e);
                    break;
                case "بطاقة مادة":
                    miMaterialCard_Click(sender, e);
                    break;
                case "حساب الحساب المصرفي":
                    miBankAccount_Click(sender, e);
                    break;
                case "إضافة أصول أخرى":
                    miAddAsset_Click(sender, e);
                    break;
                case "أمر دفع نقدي":
                    miPayBills_Click(sender, e);
                    break;
                case "وصل أستلام  نقدية":
                    miReciveBills_Click(sender, e);
                    break;
                case "بيانات الشركة":
                    miCompanyInfo_Click(sender, e);
                    break;
                case "إستيراد البيانات":
                    miImportData_Click(sender, e);
                    break;
                case "أمر صرف مبلغ":
                    miPayCheck_Click(sender, e);
                    break;
                case "إيداع مبلغ بحساب مصرفي":
                    bReceiveCheck_Click(sender, e);
                    break;
                case "جدول القيود المختلفة المرحلة":
                    miBondList_Click(sender, e);
                    break;
                case "تقرير المبيعات":
                    miSaleReport_Click(sender, e);
                    break;
                case "تقرير المشتريات":
                    miBuyReport_Click(sender, e);
                    break;
                case "إضافة إلتزامات أخرى":
                    miAddLiability_Click(sender, e);
                    break;
                case "سندات القبض المستحقة":
                    miPaperReceived_Click(sender, e);
                    break;
                case "سندات الدفع المستحقة":
                    miPaperPay_Click(sender, e);
                    break;
                //سندات القبض المستحقة  
            }
        }

        private void lvFormOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lvFormOption.Items[e]
        }

        private void bFolder_Click(object sender, EventArgs e)
        {
            lvFormOption.Items.Clear();
            ListViewGroup lvg1 = new ListViewGroup("1", "عمليات");
            ListViewGroup lvg2 = new ListViewGroup("2", "تقارير");
            lvFormOption.Items.Add(new ListViewItem("بيانات الشركة", 20, lvg1));
            lvFormOption.Items.Add(new ListViewItem("إستيراد البيانات", 21, lvg1));
            lvFormOption.Items.Add(new ListViewItem("ترحيل بيانات العام الحالي", 18, lvg1));
            lvFormOption.Items.Add(new ListViewItem("بداية عام جديد", 19, lvg1));
            lvFormOption.Items.Add(new ListViewItem("المستخدمين", 22, lvg1));

        }

        private void bAssets_Click(object sender, EventArgs e)
        {
            lvFormOption.Items.Clear();
            ListViewGroup lvg1 = new ListViewGroup("1", "عمليات");
            ListViewGroup lvg2 = new ListViewGroup("2", "تقارير");
            lvFormOption.Groups.Add(lvg1);
            lvFormOption.Groups.Add(lvg2);
            lvFormOption.Items.Add(new ListViewItem("إضافة أصول أخرى", 7, lvg1));
            lvFormOption.Items.Add(new ListViewItem("إضافة إلتزامات أخرى", 23, lvg1));
            lvFormOption.Items.Add(new ListViewItem("جدول أهتلاك الأصول الثابتة", 23, lvg2));

        }

        private void bCustomer_Click(object sender, EventArgs e)
        {
            lvFormOption.Items.Clear();
            ListViewGroup lvg1 = new ListViewGroup("1", "عمليات");
            ListViewGroup lvg2 = new ListViewGroup("2", "تقارير");
            lvFormOption.Groups.Add(lvg1);
            lvFormOption.Groups.Add(lvg2);

            lvFormOption.Items.Add(new ListViewItem("إضافة زبون", 2, lvg1));
            lvFormOption.Items.Add(new ListViewItem("السلع و الخدمات الجديدة", 1, lvg1));
            lvFormOption.Items.Add(new ListViewItem("إضافة طلبية بيع بضاعة", 5, lvg1));
            lvFormOption.Items.Add(new ListViewItem("تلقي دفعات الزبائن", 6, lvg1));
            lvFormOption.Items.Add(new ListViewItem("ردّ بضاعة مباعة", 10, lvg1));


            lvFormOption.Items.Add(new ListViewItem("حساب الزبون", 2, lvg2));
            lvFormOption.Items.Add(new ListViewItem("بطاقة مبيعات الزبون", 10, lvg2));
            lvFormOption.Items.Add(new ListViewItem("فاتورة بيع مواد", 14, lvg2));
            lvFormOption.Items.Add(new ListViewItem("تقرير إعادة بضاعة مباعة", 14, lvg2));
            lvFormOption.Items.Add(new ListViewItem("تقرير المبيعات", 14, lvg2));

            //تقرير المبيعات 
        }

        private void bMaterial_Click(object sender, EventArgs e)
        {
            lvFormOption.Items.Clear();
            ListViewGroup lvg1 = new ListViewGroup("1", "عمليات");
            ListViewGroup lvg2 = new ListViewGroup("2", "تقارير");
            lvFormOption.Groups.Add(lvg1);
            lvFormOption.Groups.Add(lvg2);
            lvFormOption.Items.Add(new ListViewItem("السلع و الخدمات الجديدة", 1, lvg1));
            lvFormOption.Items.Add(new ListViewItem("جردّ بضاعة المستودعات", 15, lvg1));

            lvFormOption.Items.Add(new ListViewItem("بطاقة مادة", 14, lvg2));


        }

        private void bVendors_Click(object sender, EventArgs e)
        {
            lvFormOption.Items.Clear();
            ListViewGroup lvg1 = new ListViewGroup("1", "عمليات");
            ListViewGroup lvg2 = new ListViewGroup("2", "تقارير");
            lvFormOption.Groups.Add(lvg1);
            lvFormOption.Groups.Add(lvg2);
            lvFormOption.Items.Add(new ListViewItem("إضافة مورد", 2, lvg1));
            lvFormOption.Items.Add(new ListViewItem("السلع و الخدمات الجديدة", 1, lvg1));
            lvFormOption.Items.Add(new ListViewItem("إضافة طلبية شراء بضاعة", 7, lvg1));
            lvFormOption.Items.Add(new ListViewItem("دفع مبلغ للموردين", 6, lvg1));
            lvFormOption.Items.Add(new ListViewItem("ردّ بضاعة مشترات", 12, lvg1));


            lvFormOption.Items.Add(new ListViewItem("حساب المورد", 2, lvg2));
            lvFormOption.Items.Add(new ListViewItem("بطاقة مشتريات المورد", 7, lvg2));
            lvFormOption.Items.Add(new ListViewItem("وثيقة إدخال مواد", 14, lvg2));
            lvFormOption.Items.Add(new ListViewItem("تقرير إعادة بضاعة مشترات", 14, lvg2));
            lvFormOption.Items.Add(new ListViewItem("تقرير المشتريات", 14, lvg2));

            //تقرير المشتريات
        }

        private void bPaper_Click(object sender, EventArgs e)
        {
            lvFormOption.Items.Clear();
            ListViewGroup lvg1 = new ListViewGroup("1", "عمليات");
            ListViewGroup lvg2 = new ListViewGroup("2", "تقارير");
            lvFormOption.Groups.Add(lvg1);
            lvFormOption.Groups.Add(lvg2);

            lvFormOption.Items.Add(new ListViewItem("سندات القبض المستحقة", 24, lvg1));
            lvFormOption.Items.Add(new ListViewItem("سندات الدفع المستحقة", 24, lvg1));

            lvFormOption.Items.Add(new ListViewItem("كمبيالات القبض", 14, lvg2));
            lvFormOption.Items.Add(new ListViewItem("كمبيالات الدفع", 14, lvg2));
        }

        private void bMoneyBox_Click(object sender, EventArgs e)
        {
            lvFormOption.Items.Clear();
            ListViewGroup lvg1 = new ListViewGroup("1", "عمليات");
            ListViewGroup lvg2 = new ListViewGroup("2", "تقارير");
            lvFormOption.Groups.Add(lvg1);
            lvFormOption.Groups.Add(lvg2);
            lvFormOption.Items.Add(new ListViewItem("إضافة صندوق", 9, lvg1));
            lvFormOption.Items.Add(new ListViewItem("دفع أو قبض مبلغ", 8, lvg1));

            lvFormOption.Items.Add(new ListViewItem("حساب الصندوق", 9, lvg2));
            lvFormOption.Items.Add(new ListViewItem("أمر دفع نقدي", 14, lvg2));
            lvFormOption.Items.Add(new ListViewItem("وصل أستلام  نقدية", 14, lvg2));

            //أمر دفع نقدي
        }

        private void bBank_Click(object sender, EventArgs e)
        {
            lvFormOption.Items.Clear();
            ListViewGroup lvg1 = new ListViewGroup("1", "عمليات");
            ListViewGroup lvg2 = new ListViewGroup("2", "تقارير");
            lvFormOption.Groups.Add(lvg1);
            lvFormOption.Groups.Add(lvg2);

            lvFormOption.Items.Add(new ListViewItem("إضافة بنك", 3, lvg1));
            lvFormOption.Items.Add(new ListViewItem("إضافة حساب بنكي", 4, lvg1));
            lvFormOption.Items.Add(new ListViewItem("سحب أو يداع مبلغ", 8, lvg1));


            lvFormOption.Items.Add(new ListViewItem("حساب الحساب المصرفي", 4, lvg2));
            lvFormOption.Items.Add(new ListViewItem("أمر صرف مبلغ", 14, lvg2));
            lvFormOption.Items.Add(new ListViewItem("إيداع مبلغ بحساب مصرفي", 14, lvg2));


        }

        private void bBalance_Click(object sender, EventArgs e)
        {
            lvFormOption.Items.Clear();
            ListViewGroup lvg1 = new ListViewGroup("1", "عمليات");
            ListViewGroup lvg2 = new ListViewGroup("2", "تقارير");
            lvFormOption.Groups.Add(lvg1);
            lvFormOption.Groups.Add(lvg2);

            lvFormOption.Items.Add(new ListViewItem("إضافة القيود اليومية", 13, lvg1));
            lvFormOption.Items.Add(new ListViewItem("جدول القيود المختلفة المرحلة", 15, lvg1));
            //
        }

        private void bReport_Click(object sender, EventArgs e)
        {
            lvFormOption.Items.Clear();
            ListViewGroup lvg1 = new ListViewGroup("1", "الزبائن");
            ListViewGroup lvg2 = new ListViewGroup("2", "موردين");
            ListViewGroup lvg3 = new ListViewGroup("3", "بنك");
            ListViewGroup lvg4 = new ListViewGroup("4", "صندوق");
            ListViewGroup lvg5 = new ListViewGroup("5", "السلع و خدمات");
            ListViewGroup lvg6 = new ListViewGroup("6", "محاسبة");

            lvFormOption.Groups.Add(lvg1);
            lvFormOption.Groups.Add(lvg2);
            lvFormOption.Groups.Add(lvg3);
            lvFormOption.Groups.Add(lvg4);
            lvFormOption.Groups.Add(lvg5);
            lvFormOption.Groups.Add(lvg6);

            //customer 
            lvFormOption.Items.Add(new ListViewItem("حساب الزبون", 2, lvg1));
            lvFormOption.Items.Add(new ListViewItem("بطاقة مبيعات الزبون", 10, lvg1));
            lvFormOption.Items.Add(new ListViewItem("فاتورة بيع مواد", 14, lvg1));
            lvFormOption.Items.Add(new ListViewItem("تقرير إعادة بضاعة مباعة", 14, lvg1));

            //supllier
            lvFormOption.Items.Add(new ListViewItem("حساب المورد", 2, lvg2));
            lvFormOption.Items.Add(new ListViewItem("بطاقة مشتريات المورد", 7, lvg2));
            lvFormOption.Items.Add(new ListViewItem("وثيقة إدخال مواد", 14, lvg2));
            lvFormOption.Items.Add(new ListViewItem("تقرير إعادة بضاعة مشترات", 14, lvg2));

            //bank
            lvFormOption.Items.Add(new ListViewItem("حساب الحساب المصرفي", 4, lvg3));

            //box
            lvFormOption.Items.Add(new ListViewItem("حساب الصندوق", 9, lvg4));
            lvFormOption.Items.Add(new ListViewItem("وصل أستلام  نقدية", 14, lvg4));
            lvFormOption.Items.Add(new ListViewItem("أمر دفع نقدي", 14, lvg2));

            //material
            lvFormOption.Items.Add(new ListViewItem("بطاقة مادة", 14, lvg5));
        }

        private void miNewBank_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("NewBank");
            NewBank nb = new NewBank();
            nb.StartPosition = FormStartPosition.Manual;
            nb.MdiParent = this;
            nb.LayoutMdi(MdiLayout.ArrangeIcons);
            nb.Show();
        }

        private void miBankAccounting_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("NewBankAccounting");
            NewBankAccounting nb = new NewBankAccounting();
            nb.StartPosition = FormStartPosition.Manual;
            nb.MdiParent = this;
            nb.LayoutMdi(MdiLayout.ArrangeIcons);
            nb.Show();
        }

        private void miSaleCash_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("Sale");
            Sale cs = new Sale();
            cs.StartPosition = FormStartPosition.Manual;
            cs.MdiParent = this;
            cs.LayoutMdi(MdiLayout.ArrangeIcons);
            cs.Show();
        }

        private void miBuy_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("Buy");
            Buy b = new Buy();
            b.StartPosition = FormStartPosition.Manual;
            b.MdiParent = this;
            b.LayoutMdi(MdiLayout.ArrangeIcons);
            b.Show();
        }

        private void miCustomerPayment_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("CustomerPayment");
            CustomerPayment cs = new CustomerPayment();
            cs.StartPosition = FormStartPosition.Manual;
            cs.MdiParent = this;
            cs.LayoutMdi(MdiLayout.ArrangeIcons);
            cs.Show();
        }

        private void miSupplierPayment_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("SupplierPayment");
            SupplierPayment cs = new SupplierPayment();
            cs.StartPosition = FormStartPosition.Manual;
            cs.MdiParent = this;
            cs.LayoutMdi(MdiLayout.ArrangeIcons);
            cs.Show();
        }

        private void miBankTransfare_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("BankTransfare");
            BankTransfare cs = new BankTransfare();
            cs.StartPosition = FormStartPosition.Manual;
            cs.MdiParent = this;
            cs.LayoutMdi(MdiLayout.ArrangeIcons);
            cs.Show();
        }

        private void miNewBox_Click(object sender, EventArgs e)
        {
            NewBox nb = new NewBox();
            nb.StartPosition = FormStartPosition.CenterScreen;
            nb.ShowDialog();
        }

        private void miBoxTransfare_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("BoxTransfare");
            BoxTransfare bt = new BoxTransfare();
            bt.MdiParent = this;
            bt.LayoutMdi(MdiLayout.ArrangeIcons);
            bt.Show();
        }

        private void miReturnSales_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("ReturnSale");
            ReturnSale rs = new ReturnSale();
            rs.StartPosition = FormStartPosition.Manual;
            rs.MdiParent = this;
            rs.LayoutMdi(MdiLayout.ArrangeIcons);
            rs.Show();
        }

        private void miReturnBuy_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("ReturnBuy");
            ReturnBuy rs = new ReturnBuy();
            rs.StartPosition = FormStartPosition.Manual;
            rs.MdiParent = this;
            rs.LayoutMdi(MdiLayout.ArrangeIcons);
            rs.Show();
        }

        private void miAddBonds_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("WritBonds");
            WritBonds wb = new WritBonds();
            wb.StartPosition = FormStartPosition.Manual;
            wb.MdiParent = this;
            wb.LayoutMdi(MdiLayout.ArrangeIcons);
            wb.Show();
        }

        private void miImportData_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("ImportData");
            ImportData md = new ImportData();
            md.StartPosition = FormStartPosition.Manual;
            md.MdiParent = this;
            md.LayoutMdi(MdiLayout.ArrangeIcons);
            md.Show();
        }

        private void miMaterialInventory_Click(object sender, EventArgs e)
        {
            MaterialInventory mi = new MaterialInventory();
           //mi.MdiParent = this;
            //mi.LayoutMdi(MdiLayout.ArrangeIcons);
            mi.Show();
        }

        private void miReportCustomerAccounting_Click(object sender, EventArgs e)
        {
            CustomerAccounting ca = new CustomerAccounting();
            ca.ShowDialog();
        }

        private void miMaterialSale_Click(object sender, EventArgs e)
        {

            CustomerSale cs = new CustomerSale();
            cs.ShowDialog();
        }

        private void miReportSupplierAccounting_Click(object sender, EventArgs e)
        {
            SupplierAccounting sa = new SupplierAccounting();
            sa.ShowDialog();
        }

        private void miMaterialBuy_Click(object sender, EventArgs e)
        {
            SupplierBuy sb = new SupplierBuy();
            sb.ShowDialog();
        }

        private void miAddAsset_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("NewAssets");
            NewAssets na = new NewAssets();
            na.StartPosition = FormStartPosition.Manual;
            na.MdiParent = this;
            na.LayoutMdi(MdiLayout.ArrangeIcons);
            na.Show();
        }

        private void miBoxAccounting_Click(object sender, EventArgs e)
        {
            BoxAccounting ba = new BoxAccounting();
            ba.ShowDialog();
        }

        private void miReciveMoney_Click(object sender, EventArgs e)
        {

        }

        private void miSaleBills_Click(object sender, EventArgs e)
        {
            SaleBills sb = new SaleBills();
            sb.ShowDialog();
        }

        private void miBuyList_Click(object sender, EventArgs e)
        {
            BuyBills bb = new BuyBills();
            bb.ShowDialog();
        }

        private void miReturnBuyBills_Click(object sender, EventArgs e)
        {
            ReturnBuyBills rbb = new ReturnBuyBills();
            rbb.ShowDialog();
        }

        private void miReturnSaleBills_Click(object sender, EventArgs e)
        {
            ReturnSaleBills rsb = new ReturnSaleBills();
            rsb.ShowDialog();
        }

        private void miMaterialCard_Click(object sender, EventArgs e)
        {
            MaterialCard mc = new MaterialCard();
            mc.ShowDialog();
        }

        private void miBankAccount_Click(object sender, EventArgs e)
        {
            BankAccounting ba = new BankAccounting();
            ba.ShowDialog();
        }

        private void miPayBills_Click(object sender, EventArgs e)
        {
            PayBills pb = new PayBills();
            pb.ShowDialog();
        }

        private void miReciveBills_Click(object sender, EventArgs e)
        {
            ReceiveBills rb = new ReceiveBills();
            rb.ShowDialog();
        }

        private void miBuyReport_Click(object sender, EventArgs e)
        {
            BuyReport br = new BuyReport();
            br.ShowDialog();
        }

        private void miSaleReport_Click(object sender, EventArgs e)
        {
            SaleReport sr = new SaleReport();
            sr.ShowDialog();
        }

        private void miPayCheck_Click(object sender, EventArgs e)
        {
            PayCheck pc = new PayCheck();
            pc.ShowDialog();
        }

        private void bReceiveCheck_Click(object sender, EventArgs e)
        {
            ReciveCheck rc = new ReciveCheck();
            rc.ShowDialog();
        }

        private void miUser_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("User");
            User u = new User();
            u.StartPosition = FormStartPosition.Manual;
            u.MdiParent = this;
            u.LayoutMdi(MdiLayout.ArrangeIcons);
            u.Show();
        }

        private void miBondList_Click(object sender, EventArgs e)
        {
            BondList bl = new BondList();

            bl.ShowDialog();
        }

        private void miSaleAssets_Click(object sender, EventArgs e)
        {

        }

        private void miPaperReceived_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("PaperReceivesPayment");
            PaperReceivesPayment prp = new PaperReceivesPayment();
            prp.StartPosition = FormStartPosition.Manual;
            prp.MdiParent = this;
            prp.LayoutMdi(MdiLayout.ArrangeIcons);
            prp.Show();
        }

        private void miAddLiability_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("NewLiability");
            NewLiability nl = new NewLiability();
            nl.StartPosition = FormStartPosition.Manual;
            nl.MdiParent = this;
            nl.LayoutMdi(MdiLayout.Cascade);
            nl.Show();
        }

        private void miPaperPay_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("PaperPayPayment");
            PaperPayPayment ppp = new PaperPayPayment();
            ppp.StartPosition = FormStartPosition.Manual;
            ppp.MdiParent = this;
            ppp.LayoutMdi(MdiLayout.ArrangeIcons);
            ppp.Show();
        }

        private void miPaperRecieveReport_Click(object sender, EventArgs e)
        {
            PaperReceivesReport prr = new PaperReceivesReport();
            prr.ShowDialog();
        }

        private void miPaperPayReport_Click(object sender, EventArgs e)
        {
            PaperPayReport prr = new PaperPayReport();
            prr.ShowDialog();
        }

        private void bNotification_Click(object sender, EventArgs e)
        {
            lvFormOption.Items.Clear();

            getPaperPayNot();
            getPaperReceiveNot();
            getSaleBondNot();
            getBuyBondNot();
            getSalePaymentTime();
        }

        private void getSalePaymentTime()
        {
            ListViewGroup lvg2 = new ListViewGroup("2", "إستحاق الدفعات من زبائن");
            lvFormOption.Groups.Add(lvg2);

            customer_ReveiveTimeTableAdapter crtta = new customer_ReveiveTimeTableAdapter();
            CustomerControllar.customer_ReveiveTimeDataTable crdt = crtta.GetData();

            int count = crdt.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                DateTime date = Convert.ToDateTime(crdt.Rows[i]["تاريخ"]);
                int balance = Convert.ToInt32(crdt.Rows[i]["الرصيد"]);
                if (balance == 0)
                {

                }
                if (balance != 0)
                {
                    if (date > DateTime.Now)
                    {
                    }
                    if (date < DateTime.Now)
                    {
                        if (crdt.Rows[i]["تم_الدفع"].ToString() == "false")
                        {
                            lvFormOption.Items.Add(new ListViewItem("-" + crdt.Rows[i]["ملاحطات"] + " المبلغ :" + crdt.Rows[i]["الرصيد"] + " المستحق بتاريخ :" + date, 24, lvg2));
                        }
                    }
                }

            }
        }

        private void getPaperReceiveNot()
        {
            ListViewGroup lvg2 = new ListViewGroup("2", "أوراق قبض مستحقةالقبص");
            lvFormOption.Groups.Add(lvg2);

            paper_receiveTableAdapter prta = new paper_receiveTableAdapter();
            PaperReceiveControllar.paper_receiveDataTable ppdt = prta.GetData();

            int count = ppdt.Rows.Count;


            for (int i = 0; i < count; i++)
            {
                int balance = Convert.ToInt32(ppdt.Rows[i]["الرصيد"]);
                DateTime date = Convert.ToDateTime(ppdt.Rows[i]["تاريخ_الإستحقاق"]);
                if (balance == 0)
                {

                }
                if (balance != 0)
                {
                    if (date > DateTime.Now)
                    {
                    }
                    if (date < DateTime.Now)
                    {
                        lvFormOption.Items.Add(new ListViewItem("-" + "ورقة قبص رقم :" + ppdt.Rows[i]["الرقم"] + " المبلغ :" + ppdt.Rows[i]["الرصيد"], 24, lvg2));
                    }

                }

            }
        }

        private void getPaperPayNot()
        {
            ListViewGroup lvg1 = new ListViewGroup("2", " أوراق الدفع مستحقة الدفع");
            lvFormOption.Groups.Add(lvg1);

            paper_payTableAdapter prta = new paper_payTableAdapter();
            PaperPayControllar.paper_payDataTable ppdt = prta.GetData();

            int count = ppdt.Rows.Count;


            for (int i = 0; i < count; i++)
            {
                int balance = Convert.ToInt32(ppdt.Rows[i]["الرصيد"]);
                DateTime date = Convert.ToDateTime(ppdt.Rows[i]["تاريخ_الإستحقاق"]);
                if (balance == 0)
                {

                }
                if (balance != 0)
                {
                    if (date > DateTime.Now)
                    {
                    }
                    if (date < DateTime.Now)
                    {
                        lvFormOption.Items.Add(new ListViewItem("-" + "ورقة دفع رقم :" + ppdt.Rows[i]["الرقم"] + " المبلغ :" + ppdt.Rows[i]["الرصيد"], 24, lvg1));
                    }

                }

            }
        }

        private void getSaleBondNot()
        {
            ListViewGroup lvg3 = new ListViewGroup("3", "فواتير المبيعات غير المرحلة");
            lvFormOption.Groups.Add(lvg3);

            material_creditTableAdapter mcta = new material_creditTableAdapter();
            MaterialControllar.material_creditDataTable mcdt = mcta.GetData();

            int count = mcdt.Rows.Count;


            for (int i = 0; i < count; i++)
            {
                bool trasfare = Convert.ToBoolean(mcdt.Rows[i]["مرحل"]);

                if (!trasfare)
                {
                    lvFormOption.Items.Add(new ListViewItem("-" + "فاتورة بيع رقم :" + mcdt.Rows[i]["الرقم"] + " المبلغ :" + mcdt.Rows[i]["الرصيد"], 24, lvg3));
                }
            }
        }

        private void getBuyBondNot()
        {
            ListViewGroup lvg3 = new ListViewGroup("4", "فواتير المشتريات غير المرحلة");
            lvFormOption.Groups.Add(lvg3);

            material_debitTableAdapter mcta = new material_debitTableAdapter();
            MaterialControllar.material_debitDataTable mcdt = mcta.GetData();

            int count = mcdt.Rows.Count;


            for (int i = 0; i < count; i++)
            {
                bool trasfare = Convert.ToBoolean(mcdt.Rows[i]["مرحل"]);

                if (!trasfare)
                {
                    lvFormOption.Items.Add(new ListViewItem("-" + "قسيمة إدخال رقم :" + mcdt.Rows[i]["الرقم"] + " المبلغ :" + mcdt.Rows[i]["الرصيد"], 24, lvg3));
                }
            }
        }

        private void bCalculator_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
          
        }

        private void miTradeAccount_Click(object sender, EventArgs e)
        {
            TradeAccount ta = new TradeAccount();
            ta.ShowDialog();
        }

        private void miFastSale_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("FastSale");
            FastSale fcs = new FastSale();
            fcs.StartPosition = FormStartPosition.Manual;
            fcs.MdiParent = this;
            fcs.LayoutMdi(MdiLayout.ArrangeIcons);
            fcs.Show();
        }

        private void الميزانيةالعموميةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlanceSheet bs = new BlanceSheet();
            bs.ShowDialog();
        }

        private void miFastBuy_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("BuyFast");
            BuyFast fcs = new BuyFast();
            fcs.StartPosition = FormStartPosition.Manual;
            fcs.MdiParent = this;
            fcs.LayoutMdi(MdiLayout.ArrangeIcons);
            fcs.Show();
        }

        private void miNewYear_Click(object sender, EventArgs e)
        {
            NewYear ny = new NewYear();
            ny.StartPosition = FormStartPosition.CenterScreen;
            ny.ShowDialog();
        }

        private void miMaterialMakerList_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("NewMaterialMaker");
            NewMaterialMaker nmm = new NewMaterialMaker();
            nmm.StartPosition = FormStartPosition.Manual;
            nmm.MdiParent = this;
            nmm.LayoutMdi(MdiLayout.ArrangeIcons);
            nmm.Show();
        }

        private void miMaterialMakerList_Click_1(object sender, EventArgs e)
        {
            closeOpenRepetWindows("NewMaterialMakerList");
            NewMaterialMakerList nmm = new NewMaterialMakerList();
            nmm.StartPosition = FormStartPosition.Manual;
            nmm.MdiParent = this;
            nmm.LayoutMdi(MdiLayout.ArrangeIcons);
            nmm.Show();
        }

        private void miMaterialMaker1_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("MaterialMaker");
            MaterialMaker nmm = new MaterialMaker();
            nmm.StartPosition = FormStartPosition.Manual;
            nmm.MdiParent = this;
            nmm.LayoutMdi(MdiLayout.ArrangeIcons);
            nmm.Show();
        }

        private void miBackUp_Click(object sender, EventArgs e)
        {
            BackUp bu = new BackUp();
            bu.StartPosition = FormStartPosition.CenterScreen;
            bu.ShowDialog();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void miReportMaterialInventory_Click(object sender, EventArgs e)
        {

        }

        private void miSalesBillsTable_Click(object sender, EventArgs e)
        {
            SaleReport.index = 0;
            closeOpenRepetWindows("SallesReportDateTime");
            SallesReportDateTime srd = new SallesReportDateTime();
            srd.MdiParent = this;
            srd.LayoutMdi(MdiLayout.ArrangeIcons);
            srd.Show();
        }

        private void miSalesBillsTableDetails_Click(object sender, EventArgs e)
        {
            SaleReport.index = 1;
            closeOpenRepetWindows("SallesReportDateTime");
            SallesReportDateTime srd = new SallesReportDateTime();
            srd.MdiParent = this;
            srd.LayoutMdi(MdiLayout.ArrangeIcons);
            srd.Show();
        }

        private void miSalesChartReport_Click(object sender, EventArgs e)
        {
            SaleReport.index = 2;
            closeOpenRepetWindows("SallesReportDateTime");
            SallesReportDateTime srd = new SallesReportDateTime();
            srd.MdiParent = this;
            srd.LayoutMdi(MdiLayout.ArrangeIcons);
            srd.Show();
        }

        private void miMaterilaTree_Click(object sender, EventArgs e)
        {
            closeOpenRepetWindows("MaterialTree");
            MaterialTree mt = new MaterialTree();
            mt.StartPosition = FormStartPosition.Manual;
            mt.MdiParent = this;
            mt.LayoutMdi(MdiLayout.TileVertical);
            mt.Show();
        }

        public void closeOpenRepetWindows(string form)
        {
            Main m = new Main();
            foreach (Form f in Main.ActiveForm.MdiChildren)
            {
                if (f.Name == form)
                {
                    f.Close();
                }
            }
        }

        private void miDB_Connection_Click(object sender, EventArgs e)
        {
            ConfigForm nc = new ConfigForm();
            nc.ShowDialog();
        }
    }
}
