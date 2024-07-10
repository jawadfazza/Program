namespace Program.entityForm.Material.report
{
    partial class MaterialCard
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.materialCardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materialDataSet = new Program.MaterialDataSet();
            this.materialDebitCradBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materialCreditCardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyDataSet = new Program.CompanyDataSet();
            this.materialDebitCradReturnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materialCreditCardReturnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtMaterialName = new System.Windows.Forms.ToolStripComboBox();
            this.bRefresh = new System.Windows.Forms.ToolStripButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.materialCardTableAdapter = new Program.MaterialDataSetTableAdapters.MaterialCardTableAdapter();
            this.materialDebitCradTableAdapter = new Program.MaterialDataSetTableAdapters.MaterialDebitCradTableAdapter();
            this.materialCreditCardTableAdapter = new Program.MaterialDataSetTableAdapters.MaterialCreditCardTableAdapter();
            this.companyReportTableAdapter = new Program.CompanyDataSetTableAdapters.companyReportTableAdapter();
            this.materialDebitCradReturnTableAdapter = new Program.MaterialDataSetTableAdapters.MaterialDebitCradReturnTableAdapter();
            this.materialCreditCardReturnTableAdapter = new Program.MaterialDataSetTableAdapters.MaterialCreditCardReturnTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.materialCardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialDebitCradBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialCreditCardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialDebitCradReturnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialCreditCardReturnBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCardBindingSource
            // 
            this.materialCardBindingSource.DataMember = "MaterialCard";
            this.materialCardBindingSource.DataSource = this.materialDataSet;
            // 
            // materialDataSet
            // 
            this.materialDataSet.DataSetName = "MaterialDataSet";
            this.materialDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // materialDebitCradBindingSource
            // 
            this.materialDebitCradBindingSource.DataMember = "MaterialDebitCrad";
            this.materialDebitCradBindingSource.DataSource = this.materialDataSet;
            // 
            // materialCreditCardBindingSource
            // 
            this.materialCreditCardBindingSource.DataMember = "MaterialCreditCard";
            this.materialCreditCardBindingSource.DataSource = this.materialDataSet;
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
            // materialDebitCradReturnBindingSource
            // 
            this.materialDebitCradReturnBindingSource.DataMember = "MaterialDebitCradReturn";
            this.materialDebitCradReturnBindingSource.DataSource = this.materialDataSet;
            // 
            // materialCreditCardReturnBindingSource
            // 
            this.materialCreditCardReturnBindingSource.DataMember = "MaterialCreditCardReturn";
            this.materialCreditCardReturnBindingSource.DataSource = this.materialDataSet;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtMaterialName,
            this.bRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel1.Text = "اسم المادة";
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMaterialName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(200, 25);
            this.txtMaterialName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterialName_KeyDown);
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
            reportDataSource1.Name = "DataSetMaterialCard";
            reportDataSource1.Value = this.materialCardBindingSource;
            reportDataSource2.Name = "DataSetMaterialDebitCrad";
            reportDataSource2.Value = this.materialDebitCradBindingSource;
            reportDataSource3.Name = "DataSetMaterialCreditCrad";
            reportDataSource3.Value = this.materialCreditCardBindingSource;
            reportDataSource4.Name = "Company";
            reportDataSource4.Value = this.companyReportBindingSource;
            reportDataSource5.Name = "MaterialDebitCradReturn";
            reportDataSource5.Value = this.materialDebitCradReturnBindingSource;
            reportDataSource6.Name = "MaterialCreditCardReturn";
            reportDataSource6.Value = this.materialCreditCardReturnBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Program.entityForm.Material.report.MaterialCard.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 25);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(984, 437);
            this.reportViewer1.TabIndex = 1;
            // 
            // materialCardTableAdapter
            // 
            this.materialCardTableAdapter.ClearBeforeFill = true;
            // 
            // materialDebitCradTableAdapter
            // 
            this.materialDebitCradTableAdapter.ClearBeforeFill = true;
            // 
            // materialCreditCardTableAdapter
            // 
            this.materialCreditCardTableAdapter.ClearBeforeFill = true;
            // 
            // companyReportTableAdapter
            // 
            this.companyReportTableAdapter.ClearBeforeFill = true;
            // 
            // materialDebitCradReturnTableAdapter
            // 
            this.materialDebitCradReturnTableAdapter.ClearBeforeFill = true;
            // 
            // materialCreditCardReturnTableAdapter
            // 
            this.materialCreditCardReturnTableAdapter.ClearBeforeFill = true;
            // 
            // MaterialCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MaterialCard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "بطاقة مادة";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MaterialCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.materialCardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialDebitCradBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialCreditCardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialDebitCradReturnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialCreditCardReturnBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox txtMaterialName;
        private System.Windows.Forms.ToolStripButton bRefresh;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource materialCardBindingSource;
        private MaterialDataSet materialDataSet;
        private System.Windows.Forms.BindingSource materialDebitCradBindingSource;
        private System.Windows.Forms.BindingSource materialCreditCardBindingSource;
        private MaterialDataSetTableAdapters.MaterialCardTableAdapter materialCardTableAdapter;
        private MaterialDataSetTableAdapters.MaterialDebitCradTableAdapter materialDebitCradTableAdapter;
        private MaterialDataSetTableAdapters.MaterialCreditCardTableAdapter materialCreditCardTableAdapter;
        private CompanyDataSet companyDataSet;
        private System.Windows.Forms.BindingSource companyReportBindingSource;
        private CompanyDataSetTableAdapters.companyReportTableAdapter companyReportTableAdapter;
        private System.Windows.Forms.BindingSource materialDebitCradReturnBindingSource;
        private System.Windows.Forms.BindingSource materialCreditCardReturnBindingSource;
        private MaterialDataSetTableAdapters.MaterialDebitCradReturnTableAdapter materialDebitCradReturnTableAdapter;
        private MaterialDataSetTableAdapters.MaterialCreditCardReturnTableAdapter materialCreditCardReturnTableAdapter;
    }
}