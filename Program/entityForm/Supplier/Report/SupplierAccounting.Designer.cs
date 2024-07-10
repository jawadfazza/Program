using Program.SupplierDataSetTableAdapters;
namespace Program.entityForm.Supplier.Report
{
    partial class SupplierAccounting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.supplierAccountingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supplierDataSet = new Program.SupplierDataSet();
            this.supplierAccountingdebitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supplierAccountingcreditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyDataSet = new Program.CompanyDataSet();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbSupplier = new System.Windows.Forms.ToolStripComboBox();
            this.bRefresh = new System.Windows.Forms.ToolStripButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.supplierAccountingTableAdapter = new Program.SupplierDataSetTableAdapters.supplierAccountingTableAdapter();
            this.supplierAccounting_debitTableAdapter = new Program.SupplierDataSetTableAdapters.supplierAccounting_debitTableAdapter();
            this.supplierAccounting_creditTableAdapter = new Program.SupplierDataSetTableAdapters.supplierAccounting_creditTableAdapter();
            this.companyReportTableAdapter = new Program.CompanyDataSetTableAdapters.companyReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.supplierAccountingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierAccountingdebitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierAccountingcreditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // supplierAccountingBindingSource
            // 
            this.supplierAccountingBindingSource.DataMember = "supplierAccounting";
            this.supplierAccountingBindingSource.DataSource = this.supplierDataSet;
            // 
            // supplierDataSet
            // 
            this.supplierDataSet.DataSetName = "SupplierDataSet";
            this.supplierDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // supplierAccountingdebitBindingSource
            // 
            this.supplierAccountingdebitBindingSource.DataMember = "supplierAccounting_debit";
            this.supplierAccountingdebitBindingSource.DataSource = this.supplierDataSet;
            // 
            // supplierAccountingcreditBindingSource
            // 
            this.supplierAccountingcreditBindingSource.DataMember = "supplierAccounting_credit";
            this.supplierAccountingcreditBindingSource.DataSource = this.supplierDataSet;
            // 
            // companyReportBindingSource
            // 
            this.companyReportBindingSource.DataMember = "companyReport";
            this.companyReportBindingSource.DataSource = this.companyDataSet;
            // 
            // companyDataSet
            // 
            this.companyDataSet.DataSetName = "CompanyDataSet";
            this.companyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cbSupplier,
            this.bRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(821, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "اسم الزبون";
            // 
            // cbSupplier
            // 
            this.cbSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(200, 25);
            this.cbSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbSupplier_KeyDown);
            // 
            // bRefresh
            // 
            this.bRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bRefresh.Image = global::Program.Properties.Resources._1353000626_adept_update;
            this.bRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(23, 22);
            this.bRefresh.Text = "toolStripButton1";
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.supplierAccountingBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.supplierAccountingdebitBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.supplierAccountingcreditBindingSource;
            reportDataSource4.Name = "Company";
            reportDataSource4.Value = this.companyReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Program.entityForm.Supplier.Report.SupplierAccounting.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 25);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(821, 404);
            this.reportViewer1.TabIndex = 1;
            // 
            // supplierAccountingTableAdapter
            // 
            this.supplierAccountingTableAdapter.ClearBeforeFill = true;
            // 
            // supplierAccounting_debitTableAdapter
            // 
            this.supplierAccounting_debitTableAdapter.ClearBeforeFill = true;
            // 
            // supplierAccounting_creditTableAdapter
            // 
            this.supplierAccounting_creditTableAdapter.ClearBeforeFill = true;
            // 
            // companyReportTableAdapter
            // 
            this.companyReportTableAdapter.ClearBeforeFill = true;
            // 
            // SupplierAccounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 429);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SupplierAccounting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "حساب الموردين";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SupplierAccounting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierAccountingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierAccountingdebitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierAccountingcreditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cbSupplier;
        private System.Windows.Forms.ToolStripButton bRefresh;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SupplierDataSet supplierDataSet;
        private System.Windows.Forms.BindingSource supplierAccountingBindingSource;
        private System.Windows.Forms.BindingSource supplierAccountingdebitBindingSource;
        private System.Windows.Forms.BindingSource supplierAccountingcreditBindingSource;
        private supplierAccountingTableAdapter supplierAccountingTableAdapter;
        private supplierAccounting_debitTableAdapter supplierAccounting_debitTableAdapter;
        private supplierAccounting_creditTableAdapter supplierAccounting_creditTableAdapter;
        private CompanyDataSet companyDataSet;
        private System.Windows.Forms.BindingSource companyReportBindingSource;
        private CompanyDataSetTableAdapters.companyReportTableAdapter companyReportTableAdapter;
    }
}