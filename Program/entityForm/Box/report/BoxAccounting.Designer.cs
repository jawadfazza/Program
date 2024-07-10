using Program.BoxDataSetTableAdapters;
namespace Program.entityForm.Box.report
{
    partial class BoxAccounting
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.boxAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boxDataSet = new Program.BoxDataSet();
            this.boxAccount_debitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boxAccount_creditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyDataSet = new Program.CompanyDataSet();
            this.dataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbBox = new System.Windows.Forms.ToolStripComboBox();
            this.bRefresh = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbDaySelected = new System.Windows.Forms.RadioButton();
            this.rbOtherDate = new System.Windows.Forms.RadioButton();
            this.rbYear = new System.Windows.Forms.RadioButton();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            this.rbDay = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mcFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.mcTo = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.boxAccountTableAdapter = new Program.BoxDataSetTableAdapters.boxAccountTableAdapter();
            this.boxAccountdebitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boxAccount_debitTableAdapter = new Program.BoxDataSetTableAdapters.boxAccount_debitTableAdapter();
            this.boxAccountcreditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boxAccount_creditTableAdapter = new Program.BoxDataSetTableAdapters.boxAccount_creditTableAdapter();
            this.dataTable1TableAdapter = new Program.BoxDataSetTableAdapters.DataTable1TableAdapter();
            this.companyReportTableAdapter = new Program.CompanyDataSetTableAdapters.companyReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.boxAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxAccount_debitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxAccount_creditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxAccountdebitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxAccountcreditBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // boxAccountBindingSource
            // 
            this.boxAccountBindingSource.DataMember = "boxAccount";
            this.boxAccountBindingSource.DataSource = this.boxDataSet;
            // 
            // boxDataSet
            // 
            this.boxDataSet.DataSetName = "BoxDataSet";
            this.boxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // boxAccount_debitBindingSource
            // 
            this.boxAccount_debitBindingSource.DataMember = "boxAccount_debit";
            this.boxAccount_debitBindingSource.DataSource = this.boxDataSet;
            // 
            // boxAccount_creditBindingSource
            // 
            this.boxAccount_creditBindingSource.DataMember = "boxAccount_credit";
            this.boxAccount_creditBindingSource.DataSource = this.boxDataSet;
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
            // dataTable1BindingSource
            // 
            this.dataTable1BindingSource.DataMember = "DataTable1";
            this.dataTable1BindingSource.DataSource = this.boxDataSet;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cbBox,
            this.bRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(64, 22);
            this.toolStripLabel1.Text = "اسم الصندوق";
            // 
            // cbBox
            // 
            this.cbBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbBox.Name = "cbBox";
            this.cbBox.Size = new System.Drawing.Size(200, 25);
            this.cbBox.Text = "صندوق اليومية.1";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(763, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(221, 437);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الفترة الزمنية";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbDaySelected);
            this.groupBox4.Controls.Add(this.rbOtherDate);
            this.groupBox4.Controls.Add(this.rbYear);
            this.groupBox4.Controls.Add(this.rbMonth);
            this.groupBox4.Controls.Add(this.rbDay);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(4, 24);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 320);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // rbDaySelected
            // 
            this.rbDaySelected.AutoSize = true;
            this.rbDaySelected.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbDaySelected.Location = new System.Drawing.Point(3, 84);
            this.rbDaySelected.Name = "rbDaySelected";
            this.rbDaySelected.Size = new System.Drawing.Size(207, 17);
            this.rbDaySelected.TabIndex = 7;
            this.rbDaySelected.Text = "خلال يوم معين";
            this.rbDaySelected.UseVisualStyleBackColor = true;
            this.rbDaySelected.CheckedChanged += new System.EventHandler(this.rbDaySelected_CheckedChanged);
            // 
            // rbOtherDate
            // 
            this.rbOtherDate.AutoSize = true;
            this.rbOtherDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbOtherDate.Location = new System.Drawing.Point(3, 67);
            this.rbOtherDate.Name = "rbOtherDate";
            this.rbOtherDate.Size = new System.Drawing.Size(207, 17);
            this.rbOtherDate.TabIndex = 6;
            this.rbOtherDate.Text = "تاريخ اخر";
            this.rbOtherDate.UseVisualStyleBackColor = true;
            this.rbOtherDate.CheckedChanged += new System.EventHandler(this.rbOtherDate_CheckedChanged);
            // 
            // rbYear
            // 
            this.rbYear.AutoSize = true;
            this.rbYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbYear.Location = new System.Drawing.Point(3, 50);
            this.rbYear.Name = "rbYear";
            this.rbYear.Size = new System.Drawing.Size(207, 17);
            this.rbYear.TabIndex = 5;
            this.rbYear.Text = "السنة الحالية";
            this.rbYear.UseVisualStyleBackColor = true;
            this.rbYear.CheckedChanged += new System.EventHandler(this.rbYear_CheckedChanged);
            // 
            // rbMonth
            // 
            this.rbMonth.AutoSize = true;
            this.rbMonth.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbMonth.Location = new System.Drawing.Point(3, 33);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(207, 17);
            this.rbMonth.TabIndex = 4;
            this.rbMonth.Text = "الشهر الحالي";
            this.rbMonth.UseVisualStyleBackColor = true;
            this.rbMonth.CheckedChanged += new System.EventHandler(this.rbMonth_CheckedChanged);
            // 
            // rbDay
            // 
            this.rbDay.AutoSize = true;
            this.rbDay.Checked = true;
            this.rbDay.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbDay.Location = new System.Drawing.Point(3, 16);
            this.rbDay.Name = "rbDay";
            this.rbDay.Size = new System.Drawing.Size(207, 17);
            this.rbDay.TabIndex = 3;
            this.rbDay.TabStop = true;
            this.rbDay.Text = "خلال اليوم";
            this.rbDay.UseVisualStyleBackColor = true;
            this.rbDay.CheckedChanged += new System.EventHandler(this.rbDay_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mcFrom);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 171);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(207, 69);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "من تاريخ";
            // 
            // mcFrom
            // 
            this.mcFrom.Location = new System.Drawing.Point(15, 28);
            this.mcFrom.Margin = new System.Windows.Forms.Padding(4);
            this.mcFrom.Name = "mcFrom";
            this.mcFrom.Size = new System.Drawing.Size(189, 27);
            this.mcFrom.TabIndex = 1;
            this.mcFrom.ValueChanged += new System.EventHandler(this.mcFrom_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mcTo);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 240);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(207, 77);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "إلى تاريخ";
            // 
            // mcTo
            // 
            this.mcTo.Location = new System.Drawing.Point(15, 28);
            this.mcTo.Margin = new System.Windows.Forms.Padding(4);
            this.mcTo.Name = "mcTo";
            this.mcTo.Size = new System.Drawing.Size(189, 27);
            this.mcTo.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(763, 437);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(755, 405);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "حساب الصندوق";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetInfo";
            reportDataSource1.Value = this.boxAccountBindingSource;
            reportDataSource2.Name = "DataSetDebit";
            reportDataSource2.Value = this.boxAccount_debitBindingSource;
            reportDataSource3.Name = "DataSetCredit";
            reportDataSource3.Value = this.boxAccount_creditBindingSource;
            reportDataSource4.Name = "Company";
            reportDataSource4.Value = this.companyReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Program.entityForm.Box.report.BoxAccounting.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(4, 4);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(747, 397);
            this.reportViewer1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(755, 405);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "حساب الصندوق مفصلاً";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource5.Name = "DataSetInfo";
            reportDataSource5.Value = this.boxAccountBindingSource;
            reportDataSource6.Name = "DataSetDebit";
            reportDataSource6.Value = this.boxAccount_debitBindingSource;
            reportDataSource7.Name = "DataSetCredit";
            reportDataSource7.Value = this.boxAccount_creditBindingSource;
            reportDataSource8.Name = "Company";
            reportDataSource8.Value = this.companyReportBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Program.entityForm.Box.report.BoxAccounting2.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(4, 4);
            this.reportViewer2.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(747, 397);
            this.reportViewer2.TabIndex = 0;
            // 
            // boxAccountTableAdapter
            // 
            this.boxAccountTableAdapter.ClearBeforeFill = true;
            // 
            // boxAccountdebitBindingSource
            // 
            this.boxAccountdebitBindingSource.DataMember = "boxAccount_debit";
            this.boxAccountdebitBindingSource.DataSource = this.boxDataSet;
            // 
            // boxAccount_debitTableAdapter
            // 
            this.boxAccount_debitTableAdapter.ClearBeforeFill = true;
            // 
            // boxAccountcreditBindingSource
            // 
            this.boxAccountcreditBindingSource.DataMember = "boxAccount_credit";
            this.boxAccountcreditBindingSource.DataSource = this.boxDataSet;
            // 
            // boxAccount_creditTableAdapter
            // 
            this.boxAccount_creditTableAdapter.ClearBeforeFill = true;
            // 
            // dataTable1TableAdapter
            // 
            this.dataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // companyReportTableAdapter
            // 
            this.companyReportTableAdapter.ClearBeforeFill = true;
            // 
            // BoxAccounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BoxAccounting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "حساب الصندوق";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BoxAccounting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boxAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxAccount_debitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxAccount_creditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.boxAccountdebitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxAccountcreditBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cbBox;
        private System.Windows.Forms.ToolStripButton bRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TabPage tabPage2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource boxAccountBindingSource;
        private BoxDataSet boxDataSet;
        private System.Windows.Forms.BindingSource boxAccountdebitBindingSource;
        private System.Windows.Forms.BindingSource boxAccountcreditBindingSource;
        private BoxDataSetTableAdapters.boxAccountTableAdapter boxAccountTableAdapter;
        private BoxDataSetTableAdapters.boxAccount_debitTableAdapter boxAccount_debitTableAdapter;
        private BoxDataSetTableAdapters.boxAccount_creditTableAdapter boxAccount_creditTableAdapter;
        private System.Windows.Forms.BindingSource boxAccount_debitBindingSource;
        private System.Windows.Forms.BindingSource boxAccount_creditBindingSource;
        private System.Windows.Forms.BindingSource dataTable1BindingSource;
        private DataTable1TableAdapter dataTable1TableAdapter;
        private System.Windows.Forms.DateTimePicker mcTo;
        private System.Windows.Forms.DateTimePicker mcFrom;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbOtherDate;
        private System.Windows.Forms.RadioButton rbYear;
        private System.Windows.Forms.RadioButton rbMonth;
        private System.Windows.Forms.RadioButton rbDay;
        private CompanyDataSet companyDataSet;
        private System.Windows.Forms.BindingSource companyReportBindingSource;
        private CompanyDataSetTableAdapters.companyReportTableAdapter companyReportTableAdapter;
        private System.Windows.Forms.RadioButton rbDaySelected;
    }
}