namespace Program.entityForm.Bonds
{
    partial class BondList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BondList));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bondListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bondDataSet = new Program.BondDataSet();
            this.companyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyDataSet = new Program.CompanyDataSet();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbSearch = new System.Windows.Forms.ToolStripComboBox();
            this.bRefresh = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewBondList = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtTotleDebit = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.txtTotlaCredit = new System.Windows.Forms.ToolStripTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bondListTableAdapter = new Program.BondDataSetTableAdapters.bondListTableAdapter();
            this.companyReportTableAdapter = new Program.CompanyDataSetTableAdapters.companyReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bondListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bondDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBondList)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bondListBindingSource
            // 
            this.bondListBindingSource.DataMember = "bondList";
            this.bondListBindingSource.DataSource = this.bondDataSet;
            // 
            // bondDataSet
            // 
            this.bondDataSet.DataSetName = "BondDataSet";
            this.bondDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.cbSearch,
            this.bRefresh,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel1.Text = "بحث عن";
            // 
            // cbSearch
            // 
            this.cbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(200, 25);
            this.cbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbSearch_KeyDown);
            // 
            // bRefresh
            // 
            this.bRefresh.Image = global::Program.Properties.Resources._1353000626_adept_update;
            this.bRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(46, 22);
            this.bRefresh.Text = "بحث";
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(55, 22);
            this.printToolStripButton.Text = "طباعة";
            this.printToolStripButton.Click += new System.EventHandler(this.printToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(799, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(185, 537);
            this.groupBox1.TabIndex = 2;
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
            this.groupBox4.Location = new System.Drawing.Point(5, 25);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(175, 269);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // rbDaySelected
            // 
            this.rbDaySelected.AutoSize = true;
            this.rbDaySelected.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbDaySelected.Location = new System.Drawing.Point(4, 85);
            this.rbDaySelected.Name = "rbDaySelected";
            this.rbDaySelected.Size = new System.Drawing.Size(167, 17);
            this.rbDaySelected.TabIndex = 8;
            this.rbDaySelected.Text = "خلال يوم معين";
            this.rbDaySelected.UseVisualStyleBackColor = true;
            this.rbDaySelected.CheckedChanged += new System.EventHandler(this.rbDaySelected_CheckedChanged);
            // 
            // rbOtherDate
            // 
            this.rbOtherDate.AutoSize = true;
            this.rbOtherDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbOtherDate.Location = new System.Drawing.Point(4, 68);
            this.rbOtherDate.Margin = new System.Windows.Forms.Padding(4);
            this.rbOtherDate.Name = "rbOtherDate";
            this.rbOtherDate.Size = new System.Drawing.Size(167, 17);
            this.rbOtherDate.TabIndex = 6;
            this.rbOtherDate.TabStop = true;
            this.rbOtherDate.Text = "تاريخ اخر";
            this.rbOtherDate.UseVisualStyleBackColor = true;
            this.rbOtherDate.CheckedChanged += new System.EventHandler(this.rbOtherDate_CheckedChanged);
            // 
            // rbYear
            // 
            this.rbYear.AutoSize = true;
            this.rbYear.Checked = true;
            this.rbYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbYear.Location = new System.Drawing.Point(4, 51);
            this.rbYear.Margin = new System.Windows.Forms.Padding(4);
            this.rbYear.Name = "rbYear";
            this.rbYear.Size = new System.Drawing.Size(167, 17);
            this.rbYear.TabIndex = 5;
            this.rbYear.TabStop = true;
            this.rbYear.Text = "السنة الحالية";
            this.rbYear.UseVisualStyleBackColor = true;
            this.rbYear.CheckedChanged += new System.EventHandler(this.rbYear_CheckedChanged);
            // 
            // rbMonth
            // 
            this.rbMonth.AutoSize = true;
            this.rbMonth.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbMonth.Location = new System.Drawing.Point(4, 34);
            this.rbMonth.Margin = new System.Windows.Forms.Padding(4);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(167, 17);
            this.rbMonth.TabIndex = 4;
            this.rbMonth.TabStop = true;
            this.rbMonth.Text = "الشهر الحالي";
            this.rbMonth.UseVisualStyleBackColor = true;
            this.rbMonth.CheckedChanged += new System.EventHandler(this.rbMonth_CheckedChanged);
            // 
            // rbDay
            // 
            this.rbDay.AutoSize = true;
            this.rbDay.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbDay.Location = new System.Drawing.Point(4, 17);
            this.rbDay.Margin = new System.Windows.Forms.Padding(4);
            this.rbDay.Name = "rbDay";
            this.rbDay.Size = new System.Drawing.Size(167, 17);
            this.rbDay.TabIndex = 3;
            this.rbDay.Text = "خلال اليوم";
            this.rbDay.UseVisualStyleBackColor = true;
            this.rbDay.CheckedChanged += new System.EventHandler(this.rbDay_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mcFrom);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 146);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(167, 60);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "من تاريخ";
            // 
            // mcFrom
            // 
            this.mcFrom.Location = new System.Drawing.Point(5, 25);
            this.mcFrom.Margin = new System.Windows.Forms.Padding(5);
            this.mcFrom.Name = "mcFrom";
            this.mcFrom.Size = new System.Drawing.Size(157, 22);
            this.mcFrom.TabIndex = 1;
            this.mcFrom.ValueChanged += new System.EventHandler(this.mcFrom_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mcTo);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(4, 206);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(167, 59);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "إلى تاريخ";
            // 
            // mcTo
            // 
            this.mcTo.Location = new System.Drawing.Point(5, 25);
            this.mcTo.Margin = new System.Windows.Forms.Padding(5);
            this.mcTo.Name = "mcTo";
            this.mcTo.Size = new System.Drawing.Size(157, 22);
            this.mcTo.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(799, 537);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(791, 508);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "جدول القيود المرحلة";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewBondList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 477);
            this.panel1.TabIndex = 2;
            // 
            // dataGridViewBondList
            // 
            this.dataGridViewBondList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBondList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBondList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBondList.Name = "dataGridViewBondList";
            this.dataGridViewBondList.Size = new System.Drawing.Size(785, 477);
            this.dataGridViewBondList.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.txtTotleDebit,
            this.toolStripLabel3,
            this.txtTotlaCredit});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(785, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel2.Text = "|||||||";
            // 
            // txtTotleDebit
            // 
            this.txtTotleDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotleDebit.Enabled = false;
            this.txtTotleDebit.Name = "txtTotleDebit";
            this.txtTotleDebit.Size = new System.Drawing.Size(85, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(14, 22);
            this.toolStripLabel3.Text = "|";
            // 
            // txtTotlaCredit
            // 
            this.txtTotlaCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotlaCredit.Enabled = false;
            this.txtTotlaCredit.Name = "txtTotlaCredit";
            this.txtTotlaCredit.Size = new System.Drawing.Size(85, 25);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(791, 508);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "طباعة الجدول";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "BondList";
            reportDataSource1.Value = this.bondListBindingSource;
            reportDataSource2.Name = "Company";
            reportDataSource2.Value = this.companyReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Program.entityForm.Bonds.report.BondList.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(785, 502);
            this.reportViewer1.TabIndex = 0;
            // 
            // bondListTableAdapter
            // 
            this.bondListTableAdapter.ClearBeforeFill = true;
            // 
            // companyReportTableAdapter
            // 
            this.companyReportTableAdapter.ClearBeforeFill = true;
            // 
            // BondList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BondList";
            this.Text = "جدول القيود المختلفة المرحلة";
            this.Load += new System.EventHandler(this.BondList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bondListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bondDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBondList)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cbSearch;
        private System.Windows.Forms.ToolStripButton bRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbOtherDate;
        private System.Windows.Forms.RadioButton rbYear;
        private System.Windows.Forms.RadioButton rbMonth;
        private System.Windows.Forms.RadioButton rbDay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker mcFrom;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker mcTo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewBondList;
        private System.Windows.Forms.TabPage tabPage2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private BondDataSet bondDataSet;
        private System.Windows.Forms.BindingSource bondListBindingSource;
        private BondDataSetTableAdapters.bondListTableAdapter bondListTableAdapter;
        private CompanyDataSet companyDataSet;
        private System.Windows.Forms.BindingSource companyReportBindingSource;
        private CompanyDataSetTableAdapters.companyReportTableAdapter companyReportTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtTotleDebit;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox txtTotlaCredit;
        private System.Windows.Forms.RadioButton rbDaySelected;
    }
}