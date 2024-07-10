using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Program.entity.controllar.BankControllarTableAdapters;
using Program.entity.controllar;
using Program.entity.controllar.CompanyControllarTableAdapters;
using Program.entity.controllar.CustomerControllarTableAdapters;
using Program.entity.controllar.LiabilityControllarTableAdapters;
using Program.entity.controllar.AssetControllarTableAdapters;
using Program.entity.controllar.MaterialControllarTableAdapters;
using Program.entity.controllar.PaperPayControllarTableAdapters;
using Program.entity.controllar.PaperReceiveControllarTableAdapters;
using Program.entity.controllar.SupplierControllarTableAdapters;
using Program.Connection;
using System.Threading;
using Program.entity.controllar.OldReportControllarTableAdapters;
using Num2Wrd;

namespace Program.entityForm.FileData
{
    public partial class NewYear : Form
    {
        public NewYear()
        {
            InitializeComponent();
        }

        private void bStartNewYear_Click(object sender, EventArgs e)
        {
            MessageBox.Show("إن هذالخيار سوف يزيل بعض المعلومات", "", MessageBoxButtons.OK,MessageBoxIcon.Information);
            if (MessageBox.Show("هل أنت متأكد من بدأ عام جديد ؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lStatus.Text = "Copy Data";
                copyData();
                toolStripProgressBar1.Value = 0;
                lStatus.Text = "Save old data";
                saveOldData();
                lStatus.Text = "Set Asset Trash";
                discountAssetsTrash();
                lStatus.Text = "Reset Tables";
                Connect c = new Connect();
                c.resetTable();
                lStatus.Text = "Opeartion Complete";
            }
        }

        private void discountAssetsTrash()
        {
            assetTableAdapter ata = new assetTableAdapter();
            AssetControllar.assetDataTable adt = ata.GetData();
            foreach (DataRow assetRow in adt.Rows)
            {
                double trushValue = (Convert.ToInt32(assetRow["الرصيد"]) - Convert.ToInt32(assetRow["قيمة_النفاية"])) * Convert.ToInt32(assetRow["نسبة_الأهتلاك"]);
                setBond1(trushValue, assetRow["اسم_الأصل"].ToString(), Convert.ToInt32(assetRow["الرقم"])).SaveBonds();
            }
        }

        BondControllar bc;
        NumberToEnglish nte = new NumberToEnglish();
        private BondControllar setBond1(double blance, string AssetName,int AssetId)
        {
            assetTableAdapter ata = new assetTableAdapter();
           
                bc = new BondControllar();

                bc.balance = blance;
                bc.balanceText = nte.changeNumericToWords(blance);
                bc.bondFrom = "إهتلاك "+AssetName;
                bc.bondTo = "أصل." + AssetName+ "." + (AssetId).ToString();
                bc.comment = " ترحيل إهتلاك " + AssetName;

            return bc;
        }

        private void saveOldData()
        {
            material_credit_oldTableAdapter mcota = new material_credit_oldTableAdapter();
            material_creditTableAdapter mcta = new material_creditTableAdapter();
            material_credit_list_oldTableAdapter mclota = new material_credit_list_oldTableAdapter();
            material_credit_listTableAdapter mclta = new material_credit_listTableAdapter();
            material_credit_penfit_paymentTableAdapter mcppta = new material_credit_penfit_paymentTableAdapter();
            string year = (DateTime.Now.Year - 1).ToString();
            if (cbBillsOut.Checked)
            {
                foreach (DataRow row in materialCreditRow)
                {
                    mcota.Insert(row["الرقم"].ToString() + "." + year,
                        Convert.ToDateTime(row["تاريخ_البيع"]),
                        Convert.ToDateTime(row["تاريخ_التسليم"]),
                        Convert.ToDouble(row["الرصيد"]),
                        row["الرصيد_كتابة"].ToString(),
                        row["إلى"].ToString(),
                        row["طريقة_الدفع"].ToString(),
                        row["المستودع"].ToString(),
                        Convert.ToInt32(row["العميل"].ToString()),
                        row["حذفة"].ToString(),
                        row["بالة"].ToString(),
                        row["نوع_العملية"].ToString(),
                        Convert.ToDouble(row["حسم_ممنوح"].ToString()),
                        Convert.ToDouble(row["مصاريف_مضافة"].ToString()),
                        row["مصاريف_على_حساب"].ToString(),
                        row["مرحل"].ToString(),
                        row["اسم_الحساب"].ToString(),
                        0,
                        0,
                        0,
                        0,
                        Convert.ToDouble(row["الكلفة"].ToString()));

                }
                foreach (DataRow row in materialCreditListRow)
                {
                    mclota.Insert(Convert.ToInt32(row["رقم_المادة"]),
                        row["رقم_التقرير"].ToString() + "." + year,
                        row["اسم_المادة"].ToString(),
                        row["الوحدة"].ToString(),
                        Convert.ToInt32(row["الكمية"]),
                        Convert.ToInt32(row["السعر"]),
                        Convert.ToDouble(row["السعر_الجمالي"]),
                        row["ملاحظات"].ToString(),
                        Convert.ToInt32(row["المستودع"]),
                        row["الكمية_كتابة"].ToString(),
                        row["حذفة"].ToString(),
                        Convert.ToDouble(row["حسم_ممنوح"]),
                        Convert.ToInt32(row["سعر_الشراء"]),
                        Convert.ToDouble(row["الكلفة"]));
                }
            }
             mclta.DeleteAll();
             mcppta.DeleteAll();
             mcta.DeleteAll();
             toolStripProgressBar1.Value = 25;
            //
            material_debit_oldTableAdapter mdota = new material_debit_oldTableAdapter();
            material_debitTableAdapter mdta = new material_debitTableAdapter();
            material_debit_list_oldTableAdapter mdlota = new material_debit_list_oldTableAdapter();
            material_debit_listTableAdapter mdlta = new material_debit_listTableAdapter();
            material_debit_penfit_paymentTableAdapter mdppta = new material_debit_penfit_paymentTableAdapter();
            if (cbBillsIn.Checked)
            {
                foreach (DataRow row in materialDebitRow)
                {
                    mdota.Insert(row["الرقم"].ToString() + "." + year,
                        Convert.ToDateTime(row["تاريخ"].ToString()),
                        Convert.ToDouble(row["الرصيد"].ToString()),
                        row["من"].ToString(),
                        row["الرصيد_كتابة"].ToString(),
                        Convert.ToInt32(row["رقم_فاتورة_المصدر"].ToString()),
                        Convert.ToDateTime(row["تاريخ_فاتورة_المصدر"].ToString()),
                        row["المصدر"].ToString(),
                        row["المستودع"].ToString(),
                        Convert.ToInt32(row["المورد"].ToString()),
                        row["حذفة"].ToString(),
                        row["نوع_العملية"].ToString(),
                        Convert.ToDouble(row["حسم_مكتسب"].ToString()),
                        Convert.ToDouble(row["مصاريف_مضافة"].ToString()),
                        row["مصاريف_على_حساب"].ToString(),
                        row["مرحل"].ToString(),
                        row["طريقة_الدفع"].ToString(),
                        row["اسم_الحساب"].ToString(),
                        Convert.ToInt32(row["سند_الدفع"].ToString()));
                }
                foreach (DataRow row in materialDebitListRow)
                {
                    mdlota.Insert(Convert.ToInt32(row["رقم_المادة"]),
                        row["رقم_التقرير"].ToString() + "." + year,
                        row["اسم_المادة"].ToString(),
                        row["الوحدة"].ToString(),
                        Convert.ToInt32(row["الكمية"]),
                        Convert.ToInt32(row["السعر"]),
                        Convert.ToDouble(row["السعر_الجمالي"]),
                        row["ملاحظات"].ToString(),
                        Convert.ToInt32(row["المستودع"]),
                        row["الكمية_كتابة"].ToString(),
                        row["حذفة"].ToString(),
                        Convert.ToDouble(row["حسم_مكتسب"]));
                }
            }
            mdppta.DeleteAll();
            mdlta.DeleteAll();
            mdta.DeleteAll();
            toolStripProgressBar1.Value = 50;

            //
            material_credit_return_oldTableAdapter mcrota = new material_credit_return_oldTableAdapter();
            material_credit_returnTableAdapter mcrta = new material_credit_returnTableAdapter();
            material_credit_list_return_oldTableAdapter mclrota = new material_credit_list_return_oldTableAdapter();
            material_credit_list_returnTableAdapter mclrta = new material_credit_list_returnTableAdapter();
            if (cbBillsOutReturn.Checked)
            {
                foreach (DataRow row in materialCreditReturnRow)
                {
                    mcrota.Insert(row["الرقم"].ToString() + "." + year,
                        Convert.ToDateTime(row["تاريخ_البيع"]),
                        Convert.ToDateTime(row["تاريخ_التسليم"]),
                        Convert.ToDouble(row["الرصيد"]),
                        row["الرصيد_كتابة"].ToString(),
                        row["إلى"].ToString(),
                        row["طريقة_الدفع"].ToString(),
                        row["المستودع"].ToString(),
                        Convert.ToInt32(row["المورد"].ToString()),
                        row["حذفة"].ToString(),
                        row["بالة"].ToString(),
                        row["نوع_العملية"].ToString(),
                        Convert.ToDouble(row["حسم_ممنوح"].ToString()),
                        Convert.ToDouble(row["مصاريف_مضافة"].ToString()),
                        row["مصاريف_على_حساب"].ToString(),
                        row["مرحل"].ToString(),
                        row["اسم_الحساب"].ToString());
                }
                foreach (DataRow row in materialCreditReturnListRow)
                {
                    mclrota.Insert(Convert.ToInt32(row["رقم_المادة"]),
                        row["رقم_التقرير"].ToString() + "." + year,
                        row["اسم_المادة"].ToString(),
                        row["الوحدة"].ToString(),
                        Convert.ToInt32(row["الكمية"]),
                        Convert.ToInt32(row["السعر"]),
                        Convert.ToDouble(row["السعر_الجمالي"]),
                        row["ملاحظات"].ToString(),
                        Convert.ToInt32(row["المستودع"]),
                        row["الكمية_كتابة"].ToString(),
                        row["حذفة"].ToString(),
                        Convert.ToDouble(row["حسم_مكتسب"]));
                }
            }
            mclrta.DeleteAll();
            mcrta.DeleteAll();
            toolStripProgressBar1.Value = 75;
            //
            material_debit_return_oldTableAdapter mdrota = new material_debit_return_oldTableAdapter();
            material_debit_returnTableAdapter mdrta = new material_debit_returnTableAdapter();
            material_debit_list_return_oldTableAdapter mdlrota = new material_debit_list_return_oldTableAdapter();
            material_debit_list_returnTableAdapter mdlrta = new material_debit_list_returnTableAdapter();
            if (cbBillsInReturn.Checked)
            {
                foreach (DataRow row in materialDebitReturnRow)
                {
                    mdrota.Insert(row["الرقم"].ToString() + "." + year,
                        Convert.ToDateTime(row["تاريخ"].ToString()),
                        Convert.ToDouble(row["الرصيد"].ToString()),
                        row["من"].ToString(),
                        row["الرصيد_كتابة"].ToString(),
                        Convert.ToInt32(row["رقم_فاتورة_المصدر"].ToString()),
                        Convert.ToDateTime(row["تاريخ_فاتورة_المصدر"].ToString()),
                        row["المصدر"].ToString(),
                        row["المستودع"].ToString(),
                        Convert.ToInt32(row["العميل"].ToString()),
                        row["حذفة"].ToString(),
                        row["نوع_العملية"].ToString(),
                        Convert.ToDouble(row["حسم_مكتسب"].ToString()),
                        Convert.ToDouble(row["مصاريف_مضافة"].ToString()),
                        row["مصاريف_على_حساب"].ToString(),
                        row["مرحل"].ToString(),
                        row["طريقة_الدفع"].ToString(),
                        row["اسم_الحساب"].ToString());
                }
                foreach (DataRow row in materialDebitReturnListRow)
                {
                    mdlrota.Insert(Convert.ToInt32(row["رقم_المادة"]),
                        row["رقم_التقرير"].ToString() + "." + year,
                        row["اسم_المادة"].ToString(),
                        row["الوحدة"].ToString(),
                        Convert.ToInt32(row["الكمية"]),
                        Convert.ToInt32(row["السعر"]),
                        Convert.ToDouble(row["السعر_الجمالي"]),
                        row["ملاحظات"].ToString(),
                        Convert.ToInt32(row["المستودع"]),
                        row["الكمية_كتابة"].ToString(),
                        row["حذفة"].ToString(),
                        Convert.ToDouble(row["حسم_مكتسب"]));
                }
            }
            mdlrta.DeleteAll();
            mdrta.DeleteAll();
            toolStripProgressBar1.Value = 100;
        }


        private void execDatabase()
        {
            Connect c = new Connect();
            c.createDatabase("Company" + (DateTime.Now.Year - 1).ToString());
            txtSql.LoadFile("..\\..\\Quary\\Table.sql",
                        RichTextBoxStreamType.PlainText);

            c.createTables(txtSql.Text, (DateTime.Now.Year - 1).ToString() );
        }

        static DataRowCollection assetsRow;
        static DataRowCollection bankRow;
        static DataRowCollection bankAccountRow;
        static DataRowCollection companytRow;
        static DataRowCollection customerRow;
        static DataRowCollection customerPayTimeRow;
        static DataRowCollection liabilityRow;
        static DataRowCollection materialRow;

        static DataRowCollection materialCreditRow;
        static DataRowCollection materialCreditListRow;
        static DataRowCollection materialDebitRow;
        static DataRowCollection materialDebitListRow;
        static DataRowCollection materialCreditReturnRow;
        static DataRowCollection materialCreditReturnListRow;
        static DataRowCollection materialDebitReturnRow;
        static DataRowCollection materialDebitReturnListRow;
        static DataRowCollection paperPayRow;
        static DataRowCollection paperReciveRow;
        static DataRowCollection supplierRow;
        private void copyData()
        {
            //copy assets data
            assetTableAdapter ata = new assetTableAdapter();
            AssetControllar.assetDataTable adt = ata.GetData();
            assetsRow = adt.Rows;
            toolStripProgressBar1.Value = 10;
            //copy bank information
            bank_detailsTableAdapter bdta = new bank_detailsTableAdapter();
            BankControllar.bank_detailsDataTable bddt = bdta.GetData();
            bankRow = bddt.Rows;

            bank_accountTableAdapter bata = new bank_accountTableAdapter();
            BankControllar.bank_accountDataTable badt = bata.GetData();
            bankAccountRow = badt.Rows;
            toolStripProgressBar1.Value = 20;
            //copy company information
            companyTableAdapter cta = new companyTableAdapter();
            CompanyControllar.companyDataTable cdt = cta.GetData();
            companytRow = cdt.Rows;
            toolStripProgressBar1.Value = 30;
            //copy customer information
            customerTableAdapter cus_ta = new customerTableAdapter();
            CustomerControllar.customerDataTable cus_dt = cus_ta.GetData();
            customerRow = cus_dt.Rows;

            customer_ReveiveTimeTableAdapter crtta = new customer_ReveiveTimeTableAdapter();
            CustomerControllar.customer_ReveiveTimeDataTable crtdt = crtta.GetData();
            customerPayTimeRow = crtdt.Rows;
            toolStripProgressBar1.Value = 40;

            //copy liability information
            liabilityTableAdapter lta = new liabilityTableAdapter();
            LiabilityControllar.liabilityDataTable ldt = lta.GetData();
            liabilityRow = ldt.Rows;
            toolStripProgressBar1.Value = 50;

            //copy material information
            materialTableAdapter mta = new materialTableAdapter();
            MaterialControllar.materialDataTable mdt = mta.GetData();
            materialRow = mdt.Rows;
            toolStripProgressBar1.Value = 60;
            //credit
            material_creditTableAdapter mcta = new material_creditTableAdapter();
            MaterialControllar.material_creditDataTable mcdt = mcta.GetData();
            materialCreditRow = mcdt.Rows;

            material_credit_listTableAdapter mclta = new material_credit_listTableAdapter();
            MaterialControllar.material_credit_listDataTable mcldt = mclta.GetData();
            materialCreditListRow = mcldt.Rows;

            //debit
            material_debitTableAdapter mdta = new material_debitTableAdapter();
            MaterialControllar.material_debitDataTable mddt = mdta.GetData();
            materialDebitRow = mddt.Rows;

            material_debit_listTableAdapter mdlta = new material_debit_listTableAdapter();
            MaterialControllar.material_debit_listDataTable mdldt = mdlta.GetData();
            materialDebitListRow = mdldt.Rows;

            //credit return
            material_credit_returnTableAdapter mcrta = new material_credit_returnTableAdapter();
            MaterialControllar.material_credit_returnDataTable mcrdt = mcrta.GetData();
            materialCreditReturnRow = mcrdt.Rows;

            material_credit_list_returnTableAdapter mclrta = new material_credit_list_returnTableAdapter();
            MaterialControllar.material_credit_list_returnDataTable mclrdt = mclrta.GetData();
            materialCreditReturnListRow = mclrdt.Rows;

            //debit return
            material_debit_returnTableAdapter mdrta = new material_debit_returnTableAdapter();
            MaterialControllar.material_debit_returnDataTable mdrdt = mdrta.GetData();
            materialDebitReturnRow = mdrdt.Rows;

            material_debit_list_returnTableAdapter mdlrta = new material_debit_list_returnTableAdapter();
            MaterialControllar.material_debit_list_returnDataTable mdlrdt = mdlrta.GetData();
            materialDebitReturnListRow = mdlrdt.Rows;
            toolStripProgressBar1.Value = 70;

            //copy pay paper information
            paper_payTableAdapter ppta = new paper_payTableAdapter();
            PaperPayControllar.paper_payDataTable ppdt = ppta.GetData();
            paperPayRow = ppdt.Rows;
            toolStripProgressBar1.Value = 80;

            //copy receive paper information
            paper_receiveTableAdapter prta = new paper_receiveTableAdapter();
            PaperReceiveControllar.paper_receiveDataTable prdt = prta.GetData();
            paperReciveRow = prdt.Rows;
            toolStripProgressBar1.Value = 90;


            //copy supplier information
            supplierTableAdapter sta = new supplierTableAdapter();
            SupplierControllar.supplierDataTable sdt = sta.GetData();
            supplierRow = sdt.Rows;
            toolStripProgressBar1.Value = 100;

        }
    }
}
