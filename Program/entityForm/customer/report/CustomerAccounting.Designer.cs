using Program.entity.controllar.CustomerControllarTableAdapters;
using Program.CustomerDataSetTableAdapters;
namespace Program.entityForm.customer
{
    partial class CustomerAccounting
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
            this.customerReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerDataSet = new Program.CustomerDataSet();
            this.customerReport_creditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerReport_debitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyDataSet = new Program.CompanyDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbCustomerName = new System.Windows.Forms.ToolStripComboBox();
            this.bReferch = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.customerReportTableAdapter = new Program.CustomerDataSetTableAdapters.CustomerReportTableAdapter();
            this.customerReportcreditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerReport_creditTableAdapter = new Program.CustomerDataSetTableAdapters.customerReport_creditTableAdapter();
            this.customerReportdebitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerReport_debitTableAdapter = new Program.CustomerDataSetTableAdapters.customerReport_debitTableAdapter();
            this.companyReportTableAdapter = new Program.CompanyDataSetTableAdapters.companyReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.customerReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerReport_creditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerReport_debitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerReportcreditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerReportdebitBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // customerReportBindingSource
            // 
            this.customerReportBindingSource.DataMember = "CustomerReport";
            this.customerReportBindingSource.DataSource = this.customerDataSet;
            // 
            // customerDataSet
            // 
            this.customerDataSet.DataSetName = "CustomerDataSet";
            this.customerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customerReport_creditBindingSource
            // 
            this.customerReport_creditBindingSource.DataMember = "customerReport_credit";
            this.customerReport_creditBindingSource.DataSource = this.customerDataSet;
            // 
            // customerReport_debitBindingSource
            // 
            this.customerReport_debitBindingSource.DataMember = "customerReport_debit";
            this.customerReport_debitBindingSource.DataSource = this.customerDataSet;
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
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.customerReportBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.customerReport_creditBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.customerReport_debitBindingSource;
            reportDataSource4.Name = "Company";
            reportDataSource4.Value = this.companyReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Program.entityForm.customer.report.CustomerAccount.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportViewer1.Size = new System.Drawing.Size(984, 437);
            this.reportViewer1.TabIndex = 0;
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
            this.toolStrip1.TabIndex = 1;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 437);
            this.panel1.TabIndex = 2;
            // 
            // customerReportTableAdapter
            // 
            this.customerReportTableAdapter.ClearBeforeFill = true;
            // 
            // customerReportcreditBindingSource
            // 
            this.customerReportcreditBindingSource.DataMember = "customerReport_credit";
            this.customerReportcreditBindingSource.DataSource = this.customerDataSet;
            // 
            // customerReport_creditTableAdapter
            // 
            this.customerReport_creditTableAdapter.ClearBeforeFill = true;
            // 
            // customerReportdebitBindingSource
            // 
            this.customerReportdebitBindingSource.DataMember = "customerReport_debit";
            this.customerReportdebitBindingSource.DataSource = this.customerDataSet;
            // 
            // customerReport_debitTableAdapter
            // 
            this.customerReport_debitTableAdapter.ClearBeforeFill = true;
            // 
            // companyReportTableAdapter
            // 
            this.companyReportTableAdapter.ClearBeforeFill = true;
            // 
            // CustomerAccounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CustomerAccounting";
            this.Text = "CustomerAccounting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CustomerAccounting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerReport_creditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerReport_debitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customerReportcreditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerReportdebitBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bReferch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cbCustomerName;
        private System.Windows.Forms.BindingSource customerReportBindingSource;
        private CustomerDataSet customerDataSet;
        private System.Windows.Forms.BindingSource customerReportcreditBindingSource;
        private System.Windows.Forms.BindingSource customerReportdebitBindingSource;
        private CustomerReportTableAdapter customerReportTableAdapter;
        private customerReport_creditTableAdapter customerReport_creditTableAdapter;
        private customerReport_debitTableAdapter customerReport_debitTableAdapter;
        private System.Windows.Forms.BindingSource customerReport_creditBindingSource;
        private System.Windows.Forms.BindingSource customerReport_debitBindingSource;
        private CompanyDataSet companyDataSet;
        private System.Windows.Forms.BindingSource companyReportBindingSource;
        private CompanyDataSetTableAdapters.companyReportTableAdapter companyReportTableAdapter;

    }
}