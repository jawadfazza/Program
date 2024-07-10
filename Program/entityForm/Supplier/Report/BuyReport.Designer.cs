namespace Program.entityForm.customer.report
{
    partial class BuyReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuyReport));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.companyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyDataSet = new Program.CompanyDataSet();
            this.buyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materialDataSet = new Program.MaterialDataSet();
            this.materialBillsdebitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supplierDataSet = new Program.SupplierDataSet();
            this.materialBillsdebitlistBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bRefreshTable = new System.Windows.Forms.ToolStripButton();
            this.bPrintTable = new System.Windows.Forms.ToolStripButton();
            this.bShowBills = new System.Windows.Forms.ToolStripButton();
            this.bShowReportChart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbOtherDate = new System.Windows.Forms.RadioButton();
            this.rbYear = new System.Windows.Forms.RadioButton();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            this.rbDay = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mcFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.mcTo = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewBuy = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.companyReportTableAdapter = new Program.CompanyDataSetTableAdapters.companyReportTableAdapter();
            this.buyReportTableAdapter = new Program.MaterialDataSetTableAdapters.BuyReportTableAdapter();
            this.materialBills_debitTableAdapter = new Program.SupplierDataSetTableAdapters.materialBills_debitTableAdapter();
            this.materialBills_debit_listTableAdapter = new Program.SupplierDataSetTableAdapters.materialBills_debit_listTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buyReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialBillsdebitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialBillsdebitlistBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuy)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            // buyReportBindingSource
            // 
            this.buyReportBindingSource.DataMember = "BuyReport";
            this.buyReportBindingSource.DataSource = this.materialDataSet;
            // 
            // materialDataSet
            // 
            this.materialDataSet.DataSetName = "MaterialDataSet";
            this.materialDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // materialBillsdebitBindingSource
            // 
            this.materialBillsdebitBindingSource.DataMember = "materialBills_debit";
            this.materialBillsdebitBindingSource.DataSource = this.supplierDataSet;
            // 
            // supplierDataSet
            // 
            this.supplierDataSet.DataSetName = "SupplierDataSet";
            this.supplierDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // materialBillsdebitlistBindingSource
            // 
            this.materialBillsdebitlistBindingSource.DataMember = "materialBills_debit_list";
            this.materialBillsdebitlistBindingSource.DataSource = this.supplierDataSet;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bRefreshTable,
            this.bPrintTable,
            this.bShowBills,
            this.bShowReportChart,
            this.toolStripSeparator,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bRefreshTable
            // 
            this.bRefreshTable.Image = global::Program.Properties.Resources._1353000626_adept_update;
            this.bRefreshTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRefreshTable.Name = "bRefreshTable";
            this.bRefreshTable.Size = new System.Drawing.Size(131, 22);
            this.bRefreshTable.Text = "تحديث جدول المشتريات";
            this.bRefreshTable.Click += new System.EventHandler(this.bRefreshTable_Click);
            // 
            // bPrintTable
            // 
            this.bPrintTable.Image = ((System.Drawing.Image)(resources.GetObject("bPrintTable.Image")));
            this.bPrintTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bPrintTable.Name = "bPrintTable";
            this.bPrintTable.Size = new System.Drawing.Size(88, 22);
            this.bPrintTable.Text = "طباعة الجدول";
            this.bPrintTable.Click += new System.EventHandler(this.bPrintTable_Click);
            // 
            // bShowBills
            // 
            this.bShowBills.Image = global::Program.Properties.Resources._1353174954_document;
            this.bShowBills.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bShowBills.Name = "bShowBills";
            this.bShowBills.Size = new System.Drawing.Size(119, 22);
            this.bShowBills.Text = "إظهار قسيمة الإدخال";
            this.bShowBills.Click += new System.EventHandler(this.bShowBills_Click);
            // 
            // bShowReportChart
            // 
            this.bShowReportChart.Image = global::Program.Properties.Resources.colorful_chart;
            this.bShowReportChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bShowReportChart.Name = "bShowReportChart";
            this.bShowReportChart.Size = new System.Drawing.Size(143, 22);
            this.bShowReportChart.Text = "المخطط البياني للمشتريات";
            this.bShowReportChart.Click += new System.EventHandler(this.bShowReportChart_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(763, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(221, 437);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الفترة الزمنية";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbOtherDate);
            this.groupBox4.Controls.Add(this.rbYear);
            this.groupBox4.Controls.Add(this.rbMonth);
            this.groupBox4.Controls.Add(this.rbDay);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(4, 24);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 286);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // rbOtherDate
            // 
            this.rbOtherDate.AutoSize = true;
            this.rbOtherDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbOtherDate.Location = new System.Drawing.Point(3, 92);
            this.rbOtherDate.Name = "rbOtherDate";
            this.rbOtherDate.Size = new System.Drawing.Size(207, 23);
            this.rbOtherDate.TabIndex = 6;
            this.rbOtherDate.TabStop = true;
            this.rbOtherDate.Text = "تاريخ اخر";
            this.rbOtherDate.UseVisualStyleBackColor = true;
            this.rbOtherDate.CheckedChanged += new System.EventHandler(this.rbOtherDate_CheckedChanged);
            // 
            // rbYear
            // 
            this.rbYear.AutoSize = true;
            this.rbYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbYear.Location = new System.Drawing.Point(3, 69);
            this.rbYear.Name = "rbYear";
            this.rbYear.Size = new System.Drawing.Size(207, 23);
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
            this.rbMonth.Location = new System.Drawing.Point(3, 46);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(207, 23);
            this.rbMonth.TabIndex = 4;
            this.rbMonth.TabStop = true;
            this.rbMonth.Text = "الشهر الحالي";
            this.rbMonth.UseVisualStyleBackColor = true;
            this.rbMonth.CheckedChanged += new System.EventHandler(this.rbMonth_CheckedChanged);
            // 
            // rbDay
            // 
            this.rbDay.AutoSize = true;
            this.rbDay.Checked = true;
            this.rbDay.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbDay.Location = new System.Drawing.Point(3, 23);
            this.rbDay.Name = "rbDay";
            this.rbDay.Size = new System.Drawing.Size(207, 23);
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
            this.groupBox2.Location = new System.Drawing.Point(3, 137);
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
            this.mcFrom.Enabled = false;
            this.mcFrom.Location = new System.Drawing.Point(15, 28);
            this.mcFrom.Margin = new System.Windows.Forms.Padding(4);
            this.mcFrom.Name = "mcFrom";
            this.mcFrom.Size = new System.Drawing.Size(189, 27);
            this.mcFrom.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mcTo);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 206);
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
            this.mcTo.Enabled = false;
            this.mcTo.Location = new System.Drawing.Point(15, 28);
            this.mcTo.Margin = new System.Windows.Forms.Padding(4);
            this.mcTo.Name = "mcTo";
            this.mcTo.Size = new System.Drawing.Size(189, 27);
            this.mcTo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(763, 437);
            this.panel1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(763, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(755, 405);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "جدول المشتريات السابقة ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewBuy);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(749, 399);
            this.panel2.TabIndex = 0;
            // 
            // dataGridViewBuy
            // 
            this.dataGridViewBuy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBuy.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBuy.Name = "dataGridViewBuy";
            this.dataGridViewBuy.Size = new System.Drawing.Size(749, 399);
            this.dataGridViewBuy.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(755, 405);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "طباعة الجدول";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Company";
            reportDataSource1.Value = this.companyReportBindingSource;
            reportDataSource2.Name = "BuyReport";
            reportDataSource2.Value = this.buyReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Program.entityForm.Supplier.Report.BuyReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(749, 399);
            this.reportViewer1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.reportViewer2);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(755, 405);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "قسيمة الإدخال المحددة";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSetMaterialBills";
            reportDataSource3.Value = this.materialBillsdebitBindingSource;
            reportDataSource4.Name = "DataSetMaterialBillsList";
            reportDataSource4.Value = this.materialBillsdebitlistBindingSource;
            reportDataSource5.Name = "Company";
            reportDataSource5.Value = this.companyReportBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Program.entityForm.customer.report.SaleBills.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(3, 3);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(749, 399);
            this.reportViewer2.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.reportViewer3);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(755, 405);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "المخطط البياني للمشتريات";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // reportViewer3
            // 
            this.reportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource6.Name = "buyReport";
            reportDataSource6.Value = this.buyReportBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "Program.entityForm.Supplier.Report.BuyReportChart.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(3, 3);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(749, 399);
            this.reportViewer3.TabIndex = 0;
            // 
            // companyReportTableAdapter
            // 
            this.companyReportTableAdapter.ClearBeforeFill = true;
            // 
            // buyReportTableAdapter
            // 
            this.buyReportTableAdapter.ClearBeforeFill = true;
            // 
            // materialBills_debitTableAdapter
            // 
            this.materialBills_debitTableAdapter.ClearBeforeFill = true;
            // 
            // materialBills_debit_listTableAdapter
            // 
            this.materialBills_debit_listTableAdapter.ClearBeforeFill = true;
            // 
            // BuyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BuyReport";
            this.RightToLeftLayout = true;
            this.Text = "تقرير المبيعات ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BuyReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.companyReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buyReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialBillsdebitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialBillsdebitlistBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuy)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewBuy;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TabPage tabPage3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ToolStripButton bRefreshTable;
        private System.Windows.Forms.ToolStripButton bPrintTable;
        private System.Windows.Forms.ToolStripButton bShowBills;
        private System.Windows.Forms.ToolStripButton bShowReportChart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private CompanyDataSet companyDataSet;
        private System.Windows.Forms.BindingSource companyReportBindingSource;
        private CompanyDataSetTableAdapters.companyReportTableAdapter companyReportTableAdapter;
        private System.Windows.Forms.BindingSource buyReportBindingSource;
        private MaterialDataSet materialDataSet;
        private MaterialDataSetTableAdapters.BuyReportTableAdapter buyReportTableAdapter;
        private System.Windows.Forms.BindingSource materialBillsdebitBindingSource;
        private SupplierDataSet supplierDataSet;
        private System.Windows.Forms.BindingSource materialBillsdebitlistBindingSource;
        private SupplierDataSetTableAdapters.materialBills_debitTableAdapter materialBills_debitTableAdapter;
        private SupplierDataSetTableAdapters.materialBills_debit_listTableAdapter materialBills_debit_listTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
    }
}