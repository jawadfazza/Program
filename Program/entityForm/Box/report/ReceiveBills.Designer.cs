namespace Program.entityForm.Supplier.Report
{
    partial class ReceiveBills
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
            this.companyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyDataSet = new Program.CompanyDataSet();
            this.receiveBillsBoxDebitByIdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boxDataSet = new Program.BoxDataSet();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bNext = new System.Windows.Forms.ToolStripButton();
            this.txtId = new System.Windows.Forms.ToolStripTextBox();
            this.bPrevious = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cbIds = new System.Windows.Forms.ToolStripComboBox();
            this.bRefresh = new System.Windows.Forms.ToolStripButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.companyReportTableAdapter = new Program.CompanyDataSetTableAdapters.companyReportTableAdapter();
            this.receiveBillsBoxDebitByIdTableAdapter = new Program.BoxDataSetTableAdapters.ReceiveBillsBoxDebitByIdTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiveBillsBoxDebitByIdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // receiveBillsBoxDebitByIdBindingSource
            // 
            this.receiveBillsBoxDebitByIdBindingSource.DataMember = "ReceiveBillsBoxDebitById";
            this.receiveBillsBoxDebitByIdBindingSource.DataSource = this.boxDataSet;
            // 
            // boxDataSet
            // 
            this.boxDataSet.DataSetName = "BoxDataSet";
            this.boxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.toolStrip1.TabIndex = 2;
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
            this.bRefresh.Image = global::Program.Properties.Resources._1353000626_adept_update;
            this.bRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(55, 22);
            this.bRefresh.Text = "تحديث";
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Company";
            reportDataSource1.Value = this.companyReportBindingSource;
            reportDataSource2.Name = "ReceiveBillBoxDebitById";
            reportDataSource2.Value = this.receiveBillsBoxDebitByIdBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Program.entityForm.Box.report.ReceiveBills.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 25);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(984, 537);
            this.reportViewer1.TabIndex = 3;
            // 
            // companyReportTableAdapter
            // 
            this.companyReportTableAdapter.ClearBeforeFill = true;
            // 
            // receiveBillsBoxDebitByIdTableAdapter
            // 
            this.receiveBillsBoxDebitByIdTableAdapter.ClearBeforeFill = true;
            // 
            // ReceiveBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ReceiveBills";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "مدفوعات نقدية";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReceiveBills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiveBillsBoxDebitByIdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private CompanyDataSet companyDataSet;
        private System.Windows.Forms.BindingSource companyReportBindingSource;
        private CompanyDataSetTableAdapters.companyReportTableAdapter companyReportTableAdapter;
        private BoxDataSet boxDataSet;
        private System.Windows.Forms.BindingSource receiveBillsBoxDebitByIdBindingSource;
        private BoxDataSetTableAdapters.ReceiveBillsBoxDebitByIdTableAdapter receiveBillsBoxDebitByIdTableAdapter;

    }
}