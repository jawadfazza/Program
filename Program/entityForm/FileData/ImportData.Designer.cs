namespace Program.entityForm.File
{
    partial class ImportData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportData));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bTestConnection = new System.Windows.Forms.ToolStripButton();
            this.txtDatabaseName = new System.Windows.Forms.ToolStripTextBox();
            this.ComboBoxConnectionType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ComboBoxTable = new System.Windows.Forms.ToolStripComboBox();
            this.bTableRefresh = new System.Windows.Forms.ToolStripButton();
            this.bTransfareData = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxId = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxPriceBuy = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxPriceSale = new System.Windows.Forms.ComboBox();
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxProducer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.comboBoxPlace = new System.Windows.Forms.ComboBox();
            this.comboBoxQuantity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPrice = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.bTransfareData1 = new System.Windows.Forms.Button();
            this.bTableRefresh1 = new System.Windows.Forms.Button();
            this.bTestConnection1 = new System.Windows.Forms.Button();
            this.bTransfare = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            this.openFileDialogAccess = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bTestConnection,
            this.txtDatabaseName,
            this.ComboBoxConnectionType,
            this.toolStripLabel1,
            this.ComboBoxTable,
            this.bTableRefresh,
            this.bTransfareData});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bTestConnection
            // 
            this.bTestConnection.Image = global::Program.Properties.Resources.folder_explore;
            this.bTestConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bTestConnection.Name = "bTestConnection";
            this.bTestConnection.Size = new System.Drawing.Size(130, 22);
            this.bTestConnection.Text = "جلب ملف قاعدة البيانات";
            this.bTestConnection.Click += new System.EventHandler(this.bTestConnection_Click);
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(200, 25);
            // 
            // ComboBoxConnectionType
            // 
            this.ComboBoxConnectionType.AutoCompleteCustomSource.AddRange(new string[] {
            "ODBC",
            "LINK"});
            this.ComboBoxConnectionType.Enabled = false;
            this.ComboBoxConnectionType.Items.AddRange(new object[] {
            "ODBC",
            "LINK"});
            this.ComboBoxConnectionType.Name = "ComboBoxConnectionType";
            this.ComboBoxConnectionType.Size = new System.Drawing.Size(121, 25);
            this.ComboBoxConnectionType.Text = "LINK";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel1.Text = "الجداول";
            // 
            // ComboBoxTable
            // 
            this.ComboBoxTable.Name = "ComboBoxTable";
            this.ComboBoxTable.Size = new System.Drawing.Size(121, 25);
            this.ComboBoxTable.Text = "Table";
            // 
            // bTableRefresh
            // 
            this.bTableRefresh.Image = global::Program.Properties.Resources._1353000626_adept_update;
            this.bTableRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bTableRefresh.Name = "bTableRefresh";
            this.bTableRefresh.Size = new System.Drawing.Size(125, 22);
            this.bTableRefresh.Text = "اظهار محتويات الجدول";
            this.bTableRefresh.Click += new System.EventHandler(this.bTableRefresh_Click);
            // 
            // bTransfareData
            // 
            this.bTransfareData.Image = global::Program.Properties.Resources.import;
            this.bTransfareData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bTransfareData.Name = "bTransfareData";
            this.bTransfareData.Size = new System.Drawing.Size(141, 22);
            this.bTransfareData.Text = "جلب أعمدة الجدول المختار";
            this.bTransfareData.Click += new System.EventHandler(this.bTransfareData_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(984, 331);
            this.splitContainer1.SplitterDistance = 459;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(459, 331);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(451, 299);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ترحيل المواد";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.comboBoxId);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.comboBoxPriceBuy);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.comboBoxPriceSale);
            this.groupBox2.Controls.Add(this.comboBoxWarehouse);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBoxProducer);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboBoxGroup);
            this.groupBox2.Controls.Add(this.comboBoxPlace);
            this.groupBox2.Controls.Add(this.comboBoxQuantity);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBoxName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comboBoxUnit);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboBoxPrice);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(-5, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 293);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "قم بختيار العمود  ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(377, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 16);
            this.label11.TabIndex = 114;
            this.label11.Text = "كورد المادة";
            // 
            // comboBoxId
            // 
            this.comboBoxId.FormattingEnabled = true;
            this.comboBoxId.Location = new System.Drawing.Point(50, 18);
            this.comboBoxId.Name = "comboBoxId";
            this.comboBoxId.Size = new System.Drawing.Size(321, 24);
            this.comboBoxId.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(132, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 16);
            this.label10.TabIndex = 112;
            this.label10.Text = "بيع";
            // 
            // comboBoxPriceBuy
            // 
            this.comboBoxPriceBuy.FormattingEnabled = true;
            this.comboBoxPriceBuy.Location = new System.Drawing.Point(50, 131);
            this.comboBoxPriceBuy.Name = "comboBoxPriceBuy";
            this.comboBoxPriceBuy.Size = new System.Drawing.Size(85, 24);
            this.comboBoxPriceBuy.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 16);
            this.label9.TabIndex = 110;
            this.label9.Text = "شراء";
            // 
            // comboBoxPriceSale
            // 
            this.comboBoxPriceSale.FormattingEnabled = true;
            this.comboBoxPriceSale.Location = new System.Drawing.Point(163, 131);
            this.comboBoxPriceSale.Name = "comboBoxPriceSale";
            this.comboBoxPriceSale.Size = new System.Drawing.Size(81, 24);
            this.comboBoxPriceSale.TabIndex = 5;
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.Enabled = false;
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(50, 254);
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(321, 24);
            this.comboBoxWarehouse.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(377, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 106;
            this.label1.Text = "المجموعة";
            // 
            // comboBoxProducer
            // 
            this.comboBoxProducer.Enabled = false;
            this.comboBoxProducer.FormattingEnabled = true;
            this.comboBoxProducer.Location = new System.Drawing.Point(50, 199);
            this.comboBoxProducer.Name = "comboBoxProducer";
            this.comboBoxProducer.Size = new System.Drawing.Size(321, 24);
            this.comboBoxProducer.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(377, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 105;
            this.label7.Text = "المستودع";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(377, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 104;
            this.label8.Text = "الصانع";
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.Enabled = false;
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(50, 227);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(321, 24);
            this.comboBoxGroup.TabIndex = 9;
            // 
            // comboBoxPlace
            // 
            this.comboBoxPlace.FormattingEnabled = true;
            this.comboBoxPlace.Location = new System.Drawing.Point(50, 75);
            this.comboBoxPlace.Name = "comboBoxPlace";
            this.comboBoxPlace.Size = new System.Drawing.Size(321, 24);
            this.comboBoxPlace.TabIndex = 2;
            // 
            // comboBoxQuantity
            // 
            this.comboBoxQuantity.FormattingEnabled = true;
            this.comboBoxQuantity.Location = new System.Drawing.Point(50, 170);
            this.comboBoxQuantity.Name = "comboBoxQuantity";
            this.comboBoxQuantity.Size = new System.Drawing.Size(321, 24);
            this.comboBoxQuantity.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 94;
            this.label2.Text = " اسم المادة";
            // 
            // comboBoxName
            // 
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(50, 48);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(321, 24);
            this.comboBoxName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 95;
            this.label3.Text = " تواجد المادة";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(377, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 98;
            this.label6.Text = "سعر وسطي";
            // 
            // comboBoxUnit
            // 
            this.comboBoxUnit.FormattingEnabled = true;
            this.comboBoxUnit.Location = new System.Drawing.Point(50, 103);
            this.comboBoxUnit.Name = "comboBoxUnit";
            this.comboBoxUnit.Size = new System.Drawing.Size(321, 24);
            this.comboBoxUnit.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 97;
            this.label5.Text = " كمية";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 96;
            this.label4.Text = " الوحدة";
            // 
            // comboBoxPrice
            // 
            this.comboBoxPrice.FormattingEnabled = true;
            this.comboBoxPrice.Location = new System.Drawing.Point(290, 131);
            this.comboBoxPrice.Name = "comboBoxPrice";
            this.comboBoxPrice.Size = new System.Drawing.Size(81, 24);
            this.comboBoxPrice.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(451, 305);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(521, 331);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.bTransfareData1);
            this.groupBox1.Controls.Add(this.bTableRefresh1);
            this.groupBox1.Controls.Add(this.bTestConnection1);
            this.groupBox1.Controls.Add(this.bTransfare);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 331);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "حالة ترحيل البيانات";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.richTextBoxStatus);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(3, 149);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(515, 179);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " حالة الترحيل ";
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxStatus.Location = new System.Drawing.Point(3, 23);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(509, 153);
            this.richTextBoxStatus.TabIndex = 3;
            this.richTextBoxStatus.Text = "";
            // 
            // bTransfareData1
            // 
            this.bTransfareData1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bTransfareData1.Location = new System.Drawing.Point(3, 113);
            this.bTransfareData1.Name = "bTransfareData1";
            this.bTransfareData1.Size = new System.Drawing.Size(515, 30);
            this.bTransfareData1.TabIndex = 2;
            this.bTransfareData1.Text = "جلب أعمدة الجدول المختار";
            this.bTransfareData1.UseVisualStyleBackColor = true;
            this.bTransfareData1.Click += new System.EventHandler(this.bTransfareData_Click);
            // 
            // bTableRefresh1
            // 
            this.bTableRefresh1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bTableRefresh1.Location = new System.Drawing.Point(3, 83);
            this.bTableRefresh1.Name = "bTableRefresh1";
            this.bTableRefresh1.Size = new System.Drawing.Size(515, 30);
            this.bTableRefresh1.TabIndex = 1;
            this.bTableRefresh1.Text = "اظهار محتويات الجدول";
            this.bTableRefresh1.UseVisualStyleBackColor = true;
            // 
            // bTestConnection1
            // 
            this.bTestConnection1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bTestConnection1.Location = new System.Drawing.Point(3, 53);
            this.bTestConnection1.Name = "bTestConnection1";
            this.bTestConnection1.Size = new System.Drawing.Size(515, 30);
            this.bTestConnection1.TabIndex = 0;
            this.bTestConnection1.Text = "جلب ملف قاعدة البيانات";
            this.bTestConnection1.UseVisualStyleBackColor = true;
            // 
            // bTransfare
            // 
            this.bTransfare.Dock = System.Windows.Forms.DockStyle.Top;
            this.bTransfare.Location = new System.Drawing.Point(3, 23);
            this.bTransfare.Name = "bTransfare";
            this.bTransfare.Size = new System.Drawing.Size(515, 30);
            this.bTransfare.TabIndex = 89;
            this.bTransfare.Text = "رحل البيانات";
            this.bTransfare.UseVisualStyleBackColor = true;
            this.bTransfare.Click += new System.EventHandler(this.bTransfare_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 25);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridViewTable);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer2.Size = new System.Drawing.Size(984, 567);
            this.splitContainer2.SplitterDistance = 331;
            this.splitContainer2.TabIndex = 3;
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTable.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.Size = new System.Drawing.Size(984, 232);
            this.dataGridViewTable.TabIndex = 0;
            // 
            // openFileDialogAccess
            // 
            this.openFileDialogAccess.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // ImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 592);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ImportData";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "ImportData";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bTestConnection;
        private System.Windows.Forms.ToolStripTextBox txtDatabaseName;
        private System.Windows.Forms.ToolStripComboBox ComboBoxConnectionType;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox ComboBoxTable;
        private System.Windows.Forms.ToolStripButton bTableRefresh;
        private System.Windows.Forms.ToolStripButton bTransfareData;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bTransfare;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridViewTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.Button bTransfareData1;
        private System.Windows.Forms.Button bTableRefresh1;
        private System.Windows.Forms.Button bTestConnection1;
        private System.Windows.Forms.OpenFileDialog openFileDialogAccess;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxProducer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.ComboBox comboBoxPlace;
        private System.Windows.Forms.ComboBox comboBoxQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxPriceBuy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxPriceSale;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxId;
    }
}