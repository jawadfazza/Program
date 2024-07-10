namespace Program.entityForm.Bank.report
{
    partial class BankAccounting
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
            this.bankAccount_accountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankDataSet = new Program.BankDataSet();
            this.bankAccount_debitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankAccount_creditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbBankAccount = new System.Windows.Forms.ToolStripComboBox();
            this.bRefresh = new System.Windows.Forms.ToolStripButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bankAccountaccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankAccount_accountTableAdapter = new Program.BankDataSetTableAdapters.bankAccount_accountTableAdapter();
            this.bankAccountdebitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankAccount_debitTableAdapter = new Program.BankDataSetTableAdapters.bankAccount_debitTableAdapter();
            this.bankAccountcreditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankAccount_creditTableAdapter = new Program.BankDataSetTableAdapters.bankAccount_creditTableAdapter();
            this.companyDataSet = new Program.CompanyDataSet();
            this.companyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyReportTableAdapter = new Program.CompanyDataSetTableAdapters.companyReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccount_accountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccount_debitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccount_creditBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountaccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountdebitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountcreditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bankAccount_accountBindingSource
            // 
            this.bankAccount_accountBindingSource.DataMember = "bankAccount_account";
            this.bankAccount_accountBindingSource.DataSource = this.bankDataSet;
            // 
            // bankDataSet
            // 
            this.bankDataSet.DataSetName = "BankDataSet";
            this.bankDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bankAccount_debitBindingSource
            // 
            this.bankAccount_debitBindingSource.DataMember = "bankAccount_debit";
            this.bankAccount_debitBindingSource.DataSource = this.bankDataSet;
            // 
            // bankAccount_creditBindingSource
            // 
            this.bankAccount_creditBindingSource.DataMember = "bankAccount_credit";
            this.bankAccount_creditBindingSource.DataSource = this.bankDataSet;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cbBankAccount,
            this.bRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(61, 22);
            this.toolStripLabel1.Text = "اسم الحساب";
            // 
            // cbBankAccount
            // 
            this.cbBankAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbBankAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbBankAccount.Name = "cbBankAccount";
            this.cbBankAccount.Size = new System.Drawing.Size(200, 25);
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
            reportDataSource1.Name = "DataSetAccount";
            reportDataSource1.Value = this.bankAccount_accountBindingSource;
            reportDataSource2.Name = "DataSetAccountDebit";
            reportDataSource2.Value = this.bankAccount_debitBindingSource;
            reportDataSource3.Name = "DataSetAccountCredit";
            reportDataSource3.Value = this.bankAccount_creditBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Program.entityForm.Bank.report.BankAccounting.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 25);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(984, 437);
            this.reportViewer1.TabIndex = 2;
            // 
            // bankAccountaccountBindingSource
            // 
            this.bankAccountaccountBindingSource.DataMember = "bankAccount_account";
            this.bankAccountaccountBindingSource.DataSource = this.bankDataSet;
            // 
            // bankAccount_accountTableAdapter
            // 
            this.bankAccount_accountTableAdapter.ClearBeforeFill = true;
            // 
            // bankAccountdebitBindingSource
            // 
            this.bankAccountdebitBindingSource.DataMember = "bankAccount_debit";
            this.bankAccountdebitBindingSource.DataSource = this.bankDataSet;
            // 
            // bankAccount_debitTableAdapter
            // 
            this.bankAccount_debitTableAdapter.ClearBeforeFill = true;
            // 
            // bankAccountcreditBindingSource
            // 
            this.bankAccountcreditBindingSource.DataMember = "bankAccount_credit";
            this.bankAccountcreditBindingSource.DataSource = this.bankDataSet;
            // 
            // bankAccount_creditTableAdapter
            // 
            this.bankAccount_creditTableAdapter.ClearBeforeFill = true;
            // 
            // companyDataSet
            // 
            this.companyDataSet.DataSetName = "CompanyDataSet";
            this.companyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // companyReportBindingSource
            // 
            this.companyReportBindingSource.DataMember = "companyReport";
            this.companyReportBindingSource.DataSource = this.companyDataSet;
            // 
            // companyReportTableAdapter
            // 
            this.companyReportTableAdapter.ClearBeforeFill = true;
            // 
            // BankAccounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BankAccounting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "الحساب البنكي";
            this.Load += new System.EventHandler(this.BankAccounting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bankAccount_accountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccount_debitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccount_creditBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountaccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountdebitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountcreditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cbBankAccount;
        private System.Windows.Forms.ToolStripButton bRefresh;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource bankAccount_accountBindingSource;
        private BankDataSet bankDataSet;
        private System.Windows.Forms.BindingSource bankAccount_debitBindingSource;
        private System.Windows.Forms.BindingSource bankAccount_creditBindingSource;
        private System.Windows.Forms.BindingSource bankAccountaccountBindingSource;
        private BankDataSetTableAdapters.bankAccount_accountTableAdapter bankAccount_accountTableAdapter;
        private System.Windows.Forms.BindingSource bankAccountdebitBindingSource;
        private BankDataSetTableAdapters.bankAccount_debitTableAdapter bankAccount_debitTableAdapter;
        private System.Windows.Forms.BindingSource bankAccountcreditBindingSource;
        private BankDataSetTableAdapters.bankAccount_creditTableAdapter bankAccount_creditTableAdapter;
        private CompanyDataSet companyDataSet;
        private System.Windows.Forms.BindingSource companyReportBindingSource;
        private CompanyDataSetTableAdapters.companyReportTableAdapter companyReportTableAdapter;
    }
}