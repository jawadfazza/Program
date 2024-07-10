namespace Program.entityForm.Supplier.Report
{
    partial class ReturnBuyBills
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
            this.materialBills_creditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerDataSet = new Program.CustomerDataSet();
            this.materialBills_credit_listBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyDataSet = new Program.CompanyDataSet();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bNext = new System.Windows.Forms.ToolStripButton();
            this.txtId = new System.Windows.Forms.ToolStripTextBox();
            this.bPrevious = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cbIds = new System.Windows.Forms.ToolStripComboBox();
            this.bRefresh = new System.Windows.Forms.ToolStripButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.materialBillscreditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materialBills_creditTableAdapter = new Program.CustomerDataSetTableAdapters.materialBills_creditTableAdapter();
            this.materialBillscreditlistBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materialBills_credit_listTableAdapter = new Program.CustomerDataSetTableAdapters.materialBills_credit_listTableAdapter();
            this.companyReportTableAdapter = new Program.CompanyDataSetTableAdapters.companyReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.materialBills_creditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialBills_credit_listBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialBillscreditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialBillscreditlistBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // materialBills_creditBindingSource
            // 
            this.materialBills_creditBindingSource.DataMember = "materialBills_credit";
            this.materialBills_creditBindingSource.DataSource = this.customerDataSet;
            // 
            // customerDataSet
            // 
            this.customerDataSet.DataSetName = "CustomerDataSet";
            this.customerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // materialBills_credit_listBindingSource
            // 
            this.materialBills_credit_listBindingSource.DataMember = "materialBills_credit_list";
            this.materialBills_credit_listBindingSource.DataSource = this.customerDataSet;
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
            this.bNext,
            this.txtId,
            this.bPrevious,
            this.toolStripSeparator1,
            this.cbIds,
            this.bRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bNext
            // 
            this.bNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bNext.Image = global::Program.Properties.Resources._1354380474_resultset_last;
            this.bNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(23, 22);
            this.bNext.Text = "toolStripButton1";
            this.bNext.Click += new System.EventHandler(this.bNext_Click);
            // 
            // txtId
            // 
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(75, 25);
            // 
            // bPrevious
            // 
            this.bPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bPrevious.Image = global::Program.Properties.Resources._1354380473_resultset_first;
            this.bPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bPrevious.Name = "bPrevious";
            this.bPrevious.Size = new System.Drawing.Size(23, 22);
            this.bPrevious.Text = "toolStripButton2";
            this.bPrevious.Click += new System.EventHandler(this.bPrevious_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cbIds
            // 
            this.cbIds.Name = "cbIds";
            this.cbIds.Size = new System.Drawing.Size(121, 25);
            // 
            // bRefresh
            // 
            this.bRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bRefresh.Image = global::Program.Properties.Resources._1353000626_adept_update;
            this.bRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(23, 22);
            this.bRefresh.Text = "toolStripButton3";
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetMaterialBills";
            reportDataSource1.Value = this.materialBills_creditBindingSource;
            reportDataSource2.Name = "DataSetMaterialBillsList";
            reportDataSource2.Value = this.materialBills_credit_listBindingSource;
            reportDataSource3.Name = "Company";
            reportDataSource3.Value = this.companyReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Program.entityForm.Supplier.Report.ReturnBuyBills.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 25);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(984, 437);
            this.reportViewer1.TabIndex = 2;
            // 
            // materialBillscreditBindingSource
            // 
            this.materialBillscreditBindingSource.DataMember = "materialBills_credit";
            this.materialBillscreditBindingSource.DataSource = this.customerDataSet;
            // 
            // materialBills_creditTableAdapter
            // 
            this.materialBills_creditTableAdapter.ClearBeforeFill = true;
            // 
            // materialBillscreditlistBindingSource
            // 
            this.materialBillscreditlistBindingSource.DataMember = "materialBills_credit_list";
            this.materialBillscreditlistBindingSource.DataSource = this.customerDataSet;
            // 
            // materialBills_credit_listTableAdapter
            // 
            this.materialBills_credit_listTableAdapter.ClearBeforeFill = true;
            // 
            // companyReportTableAdapter
            // 
            this.companyReportTableAdapter.ClearBeforeFill = true;
            // 
            // ReturnBuyBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ReturnBuyBills";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "ردّ بضاعة مشترات ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReturnBuyBills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.materialBills_creditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialBills_credit_listBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialBillscreditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialBillscreditlistBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bNext;
        private System.Windows.Forms.ToolStripTextBox txtId;
        private System.Windows.Forms.ToolStripButton bPrevious;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox cbIds;
        private System.Windows.Forms.ToolStripButton bRefresh;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource materialBills_creditBindingSource;
        private CustomerDataSet customerDataSet;
        private System.Windows.Forms.BindingSource materialBills_credit_listBindingSource;
        private System.Windows.Forms.BindingSource materialBillscreditBindingSource;
        private CustomerDataSetTableAdapters.materialBills_creditTableAdapter materialBills_creditTableAdapter;
        private System.Windows.Forms.BindingSource materialBillscreditlistBindingSource;
        private CustomerDataSetTableAdapters.materialBills_credit_listTableAdapter materialBills_credit_listTableAdapter;
        private CompanyDataSet companyDataSet;
        private System.Windows.Forms.BindingSource companyReportBindingSource;
        private CompanyDataSetTableAdapters.companyReportTableAdapter companyReportTableAdapter;
    }
}