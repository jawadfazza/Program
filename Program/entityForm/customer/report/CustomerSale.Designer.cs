using Program.CustomerDataSetTableAdapters;
namespace Program.entityForm.customer.report
{
    partial class CustomerSale
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
            this.customerSaleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerDataSet = new Program.CustomerDataSet();
            this.customerReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyDataSet = new Program.CompanyDataSet();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbCustomerName = new System.Windows.Forms.ToolStripComboBox();
            this.bReferch = new System.Windows.Forms.ToolStripButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.customerSaleTableAdapter = new Program.CustomerDataSetTableAdapters.CustomerSaleTableAdapter();
            this.customerReportTableAdapter = new Program.CustomerDataSetTableAdapters.CustomerReportTableAdapter();
            this.companyReportTableAdapter = new Program.CompanyDataSetTableAdapters.companyReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.customerSaleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerSaleBindingSource
            // 
            this.customerSaleBindingSource.DataMember = "CustomerSale";
            this.customerSaleBindingSource.DataSource = this.customerDataSet;
            // 
            // customerDataSet
            // 
            this.customerDataSet.DataSetName = "CustomerDataSet";
            this.customerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customerReportBindingSource
            // 
            this.customerReportBindingSource.DataMember = "CustomerReport";
            this.customerReportBindingSource.DataSource = this.customerDataSet;
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
            this.cbCustomerName,
            this.bReferch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "اسم الزبون";
            // 
            // cbCustomerName
            // 
            this.cbCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbCustomerName.Name = "cbCustomerName";
            this.cbCustomerName.Size = new System.Drawing.Size(200, 25);
            this.cbCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCustomerName_KeyDown);
            // 
            // bReferch
            // 
            this.bReferch.Image = global::Program.Properties.Resources._1353000626_adept_update;
            this.bReferch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bReferch.Name = "bReferch";
            this.bReferch.Size = new System.Drawing.Size(89, 22);
            this.bReferch.Text = "تحديث التقرير";
            this.bReferch.Click += new System.EventHandler(this.bReferch_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "CustomerSale";
            reportDataSource1.Value = this.customerSaleBindingSource;
            reportDataSource2.Name = "CustomerReport";
            reportDataSource2.Value = this.customerReportBindingSource;
            reportDataSource3.Name = "Company";
            reportDataSource3.Value = this.companyReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Program.entityForm.customer.report.CustomerSale.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 25);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportViewer1.Size = new System.Drawing.Size(984, 437);
            this.reportViewer1.TabIndex = 3;
            // 
            // customerSaleTableAdapter
            // 
            this.customerSaleTableAdapter.ClearBeforeFill = true;
            // 
            // customerReportTableAdapter
            // 
            this.customerReportTableAdapter.ClearBeforeFill = true;
            // 
            // companyReportTableAdapter
            // 
            this.companyReportTableAdapter.ClearBeforeFill = true;
            // 
            // CustomerSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CustomerSale";
            this.Text = "CustomerSale";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CustomerSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerSaleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerReportBindingSource)).EndInit();
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
        private System.Windows.Forms.ToolStripComboBox cbCustomerName;
        private System.Windows.Forms.ToolStripButton bReferch;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource customerSaleBindingSource;
        private CustomerDataSet customerDataSet;
        private System.Windows.Forms.BindingSource customerReportBindingSource;
        private CustomerDataSetTableAdapters.CustomerSaleTableAdapter customerSaleTableAdapter;
        private CustomerDataSetTableAdapters.CustomerReportTableAdapter customerReportTableAdapter;
        private CompanyDataSet companyDataSet;
        private System.Windows.Forms.BindingSource companyReportBindingSource;
        private CompanyDataSetTableAdapters.companyReportTableAdapter companyReportTableAdapter;

    }
}