namespace Program.SMC
{
    partial class SMC_System
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMC_System));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_New = new System.Windows.Forms.ToolStripButton();
            this.tsb_Save = new System.Windows.Forms.ToolStripButton();
            this.tsb_Edit = new System.Windows.Forms.ToolStripButton();
            this.tsb_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tc_Contant = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_System = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_Sys_Note = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_Sys_Active = new System.Windows.Forms.CheckBox();
            this.txt_Sys_Number = new System.Windows.Forms.NumericUpDown();
            this.txt_Sys_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgv_Tab = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_Tab_Script_Local = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_Tab_Script_Net = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_Sys_Id_Table = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Tab_Sequence = new System.Windows.Forms.NumericUpDown();
            this.txt_Tab_Name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cb_Sys_Id_Screen = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Scrn_Name = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgv_ = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Scrn_Image_Icon = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Scrn_Image = new System.Windows.Forms.TextBox();
            this.b_Scrn_Image = new System.Windows.Forms.Button();
            this.cb_Groub = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.bD_SMCDataSet = new Program.SMC.EntityControllar.BD_SMCDataSet();
            this.gASystemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gA_SystemTableAdapter = new Program.SMC.EntityControllar.BD_SMCDataSetTableAdapters.GA_SystemTableAdapter();
            this.gAGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gA_GroupTableAdapter = new Program.SMC.EntityControllar.BD_SMCDataSetTableAdapters.GA_GroupTableAdapter();
            this.b_Groub = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.tc_Contant.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_System)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sys_Number)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tab)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Tab_Sequence)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bD_SMCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gASystemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAGroupBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_New,
            this.tsb_Save,
            this.tsb_Edit,
            this.tsb_Delete,
            this.toolStripSeparator,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 26);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_New
            // 
            this.tsb_New.Image = ((System.Drawing.Image)(resources.GetObject("tsb_New.Image")));
            this.tsb_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_New.Name = "tsb_New";
            this.tsb_New.Size = new System.Drawing.Size(51, 23);
            this.tsb_New.Text = "جديد";
            this.tsb_New.Click += new System.EventHandler(this.tsb_New_Click);
            // 
            // tsb_Save
            // 
            this.tsb_Save.Image = global::Program.Properties.Resources.document_save;
            this.tsb_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Save.Name = "tsb_Save";
            this.tsb_Save.Size = new System.Drawing.Size(50, 23);
            this.tsb_Save.Text = "حفظ";
            this.tsb_Save.Click += new System.EventHandler(this.tsb_Save_Click);
            // 
            // tsb_Edit
            // 
            this.tsb_Edit.Image = global::Program.Properties.Resources.edit;
            this.tsb_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Edit.Name = "tsb_Edit";
            this.tsb_Edit.Size = new System.Drawing.Size(56, 23);
            this.tsb_Edit.Text = "تعديل";
            this.tsb_Edit.Click += new System.EventHandler(this.tsb_Edit_Click);
            // 
            // tsb_Delete
            // 
            this.tsb_Delete.Image = global::Program.Properties.Resources.delete;
            this.tsb_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Delete.Name = "tsb_Delete";
            this.tsb_Delete.Size = new System.Drawing.Size(55, 23);
            this.tsb_Delete.Text = "حذف";
            this.tsb_Delete.Click += new System.EventHandler(this.tsb_Delete_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 26);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 23);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // tc_Contant
            // 
            this.tc_Contant.Controls.Add(this.tabPage1);
            this.tc_Contant.Controls.Add(this.tabPage2);
            this.tc_Contant.Controls.Add(this.tabPage3);
            this.tc_Contant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Contant.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tc_Contant.Location = new System.Drawing.Point(0, 26);
            this.tc_Contant.Name = "tc_Contant";
            this.tc_Contant.RightToLeftLayout = true;
            this.tc_Contant.SelectedIndex = 0;
            this.tc_Contant.Size = new System.Drawing.Size(584, 468);
            this.tc_Contant.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 437);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "الأنظمة";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_System);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 304);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "قائمة الأنظمة";
            // 
            // dgv_System
            // 
            this.dgv_System.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_System.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_System.Location = new System.Drawing.Point(3, 21);
            this.dgv_System.Name = "dgv_System";
            this.dgv_System.Size = new System.Drawing.Size(564, 280);
            this.dgv_System.TabIndex = 0;
            this.dgv_System.Click += new System.EventHandler(this.dgv_System_Click);
            this.dgv_System.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_System_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "أدارة الأنظمة";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_Sys_Note);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 103);
            this.panel2.TabIndex = 1;
            // 
            // txt_Sys_Note
            // 
            this.txt_Sys_Note.Location = new System.Drawing.Point(42, 8);
            this.txt_Sys_Note.Multiline = true;
            this.txt_Sys_Note.Name = "txt_Sys_Note";
            this.txt_Sys_Note.Size = new System.Drawing.Size(166, 80);
            this.txt_Sys_Note.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "ملاحظة";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cb_Sys_Active);
            this.panel1.Controls.Add(this.txt_Sys_Number);
            this.panel1.Controls.Add(this.txt_Sys_Name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(280, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 103);
            this.panel1.TabIndex = 0;
            // 
            // cb_Sys_Active
            // 
            this.cb_Sys_Active.AutoSize = true;
            this.cb_Sys_Active.Location = new System.Drawing.Point(178, 71);
            this.cb_Sys_Active.Name = "cb_Sys_Active";
            this.cb_Sys_Active.Size = new System.Drawing.Size(15, 14);
            this.cb_Sys_Active.TabIndex = 5;
            this.cb_Sys_Active.UseVisualStyleBackColor = true;
            // 
            // txt_Sys_Number
            // 
            this.txt_Sys_Number.Location = new System.Drawing.Point(144, 39);
            this.txt_Sys_Number.Name = "txt_Sys_Number";
            this.txt_Sys_Number.Size = new System.Drawing.Size(49, 25);
            this.txt_Sys_Number.TabIndex = 4;
            // 
            // txt_Sys_Name
            // 
            this.txt_Sys_Name.Location = new System.Drawing.Point(27, 11);
            this.txt_Sys_Name.Name = "txt_Sys_Name";
            this.txt_Sys_Name.Size = new System.Drawing.Size(166, 25);
            this.txt_Sys_Name.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "فعالية النظام";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "رقم النظام";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم النظام";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(576, 437);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "جداول الأنظمة";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgv_Tab);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 253);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(570, 181);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "قائمة الجداول";
            // 
            // dgv_Tab
            // 
            this.dgv_Tab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Tab.Location = new System.Drawing.Point(3, 21);
            this.dgv_Tab.Name = "dgv_Tab";
            this.dgv_Tab.Size = new System.Drawing.Size(564, 157);
            this.dgv_Tab.TabIndex = 0;
            this.dgv_Tab.Click += new System.EventHandler(this.dgv_Tab_Click);
            this.dgv_Tab.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_Tab_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(570, 250);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "أدارة الأنظمة";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_Tab_Script_Local);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(277, 226);
            this.panel3.TabIndex = 1;
            // 
            // txt_Tab_Script_Local
            // 
            this.txt_Tab_Script_Local.Location = new System.Drawing.Point(14, 130);
            this.txt_Tab_Script_Local.Name = "txt_Tab_Script_Local";
            this.txt_Tab_Script_Local.Size = new System.Drawing.Size(257, 85);
            this.txt_Tab_Script_Local.TabIndex = 10;
            this.txt_Tab_Script_Local.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "الجدول الشبكي";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txt_Tab_Script_Net);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.cb_Sys_Id_Table);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txt_Tab_Sequence);
            this.panel4.Controls.Add(this.txt_Tab_Name);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(280, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(287, 226);
            this.panel4.TabIndex = 0;
            // 
            // txt_Tab_Script_Net
            // 
            this.txt_Tab_Script_Net.Location = new System.Drawing.Point(13, 130);
            this.txt_Tab_Script_Net.Name = "txt_Tab_Script_Net";
            this.txt_Tab_Script_Net.Size = new System.Drawing.Size(257, 85);
            this.txt_Tab_Script_Net.TabIndex = 9;
            this.txt_Tab_Script_Net.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "الجدول المحلي";
            // 
            // cb_Sys_Id_Table
            // 
            this.cb_Sys_Id_Table.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.gASystemBindingSource, "Sys_Id", true));
            this.cb_Sys_Id_Table.DataSource = this.gASystemBindingSource;
            this.cb_Sys_Id_Table.DisplayMember = "Sys_Name";
            this.cb_Sys_Id_Table.FormattingEnabled = true;
            this.cb_Sys_Id_Table.Location = new System.Drawing.Point(13, 36);
            this.cb_Sys_Id_Table.Name = "cb_Sys_Id_Table";
            this.cb_Sys_Id_Table.Size = new System.Drawing.Size(156, 26);
            this.cb_Sys_Id_Table.TabIndex = 7;
            this.cb_Sys_Id_Table.ValueMember = "Sys_Id";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(175, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 18);
            this.label9.TabIndex = 6;
            this.label9.Text = "اسم الجدول";
            // 
            // txt_Tab_Sequence
            // 
            this.txt_Tab_Sequence.Location = new System.Drawing.Point(120, 68);
            this.txt_Tab_Sequence.Name = "txt_Tab_Sequence";
            this.txt_Tab_Sequence.Size = new System.Drawing.Size(49, 25);
            this.txt_Tab_Sequence.TabIndex = 4;
            // 
            // txt_Tab_Name
            // 
            this.txt_Tab_Name.Location = new System.Drawing.Point(13, 8);
            this.txt_Tab_Name.Name = "txt_Tab_Name";
            this.txt_Tab_Name.Size = new System.Drawing.Size(156, 25);
            this.txt_Tab_Name.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "ترتيب الجدول";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(175, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "اسم النظام";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(576, 437);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "شاشات النظام";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panel6);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(570, 187);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "أدارة الشاشات";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.b_Groub);
            this.panel6.Controls.Add(this.cb_Groub);
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.b_Scrn_Image);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.txt_Scrn_Image);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.txt_Scrn_Image_Icon);
            this.panel6.Controls.Add(this.cb_Sys_Id_Screen);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.txt_Scrn_Name);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(259, 21);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(308, 163);
            this.panel6.TabIndex = 0;
            // 
            // cb_Sys_Id_Screen
            // 
            this.cb_Sys_Id_Screen.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.gASystemBindingSource, "Sys_Id", true));
            this.cb_Sys_Id_Screen.DataSource = this.gASystemBindingSource;
            this.cb_Sys_Id_Screen.DisplayMember = "Sys_Name";
            this.cb_Sys_Id_Screen.FormattingEnabled = true;
            this.cb_Sys_Id_Screen.Location = new System.Drawing.Point(24, 37);
            this.cb_Sys_Id_Screen.Name = "cb_Sys_Id_Screen";
            this.cb_Sys_Id_Screen.Size = new System.Drawing.Size(156, 26);
            this.cb_Sys_Id_Screen.TabIndex = 7;
            this.cb_Sys_Id_Screen.ValueMember = "Sys_Id";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(186, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 18);
            this.label12.TabIndex = 6;
            this.label12.Text = "اسم الشاشة";
            // 
            // txt_Scrn_Name
            // 
            this.txt_Scrn_Name.Location = new System.Drawing.Point(24, 9);
            this.txt_Scrn_Name.Name = "txt_Scrn_Name";
            this.txt_Scrn_Name.Size = new System.Drawing.Size(156, 25);
            this.txt_Scrn_Name.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(186, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 18);
            this.label14.TabIndex = 0;
            this.label14.Text = "اسم النظام";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgv_);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 190);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(570, 244);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "قائمة الشاشات";
            // 
            // dgv_
            // 
            this.dgv_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_.Location = new System.Drawing.Point(3, 21);
            this.dgv_.Name = "dgv_";
            this.dgv_.Size = new System.Drawing.Size(564, 220);
            this.dgv_.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(186, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 18);
            this.label10.TabIndex = 9;
            this.label10.Text = "رقم الصورة";
            // 
            // txt_Scrn_Image_Icon
            // 
            this.txt_Scrn_Image_Icon.Location = new System.Drawing.Point(24, 97);
            this.txt_Scrn_Image_Icon.Name = "txt_Scrn_Image_Icon";
            this.txt_Scrn_Image_Icon.Size = new System.Drawing.Size(156, 25);
            this.txt_Scrn_Image_Icon.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(186, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 18);
            this.label11.TabIndex = 11;
            this.label11.Text = "رابط الصورة";
            // 
            // txt_Scrn_Image
            // 
            this.txt_Scrn_Image.Location = new System.Drawing.Point(60, 128);
            this.txt_Scrn_Image.Name = "txt_Scrn_Image";
            this.txt_Scrn_Image.Size = new System.Drawing.Size(120, 25);
            this.txt_Scrn_Image.TabIndex = 10;
            // 
            // b_Scrn_Image
            // 
            this.b_Scrn_Image.Image = global::Program.Properties.Resources.folder_explore;
            this.b_Scrn_Image.Location = new System.Drawing.Point(24, 122);
            this.b_Scrn_Image.Name = "b_Scrn_Image";
            this.b_Scrn_Image.Size = new System.Drawing.Size(30, 30);
            this.b_Scrn_Image.TabIndex = 12;
            this.b_Scrn_Image.UseVisualStyleBackColor = true;
            this.b_Scrn_Image.Click += new System.EventHandler(this.b_Scrn_Image_Click);
            // 
            // cb_Groub
            // 
            this.cb_Groub.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.gAGroupBindingSource, "Grp_Id", true));
            this.cb_Groub.DataSource = this.gAGroupBindingSource;
            this.cb_Groub.DisplayMember = "Grp_Name";
            this.cb_Groub.FormattingEnabled = true;
            this.cb_Groub.Location = new System.Drawing.Point(60, 66);
            this.cb_Groub.Name = "cb_Groub";
            this.cb_Groub.Size = new System.Drawing.Size(120, 26);
            this.cb_Groub.TabIndex = 14;
            this.cb_Groub.ValueMember = "Grp_Id";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(186, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 18);
            this.label13.TabIndex = 13;
            this.label13.Text = "المجموعة التابعة";
            // 
            // bD_SMCDataSet
            // 
            this.bD_SMCDataSet.DataSetName = "BD_SMCDataSet";
            this.bD_SMCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gASystemBindingSource
            // 
            this.gASystemBindingSource.DataMember = "GA_System";
            this.gASystemBindingSource.DataSource = this.bD_SMCDataSet;
            // 
            // gA_SystemTableAdapter
            // 
            this.gA_SystemTableAdapter.ClearBeforeFill = true;
            // 
            // gAGroupBindingSource
            // 
            this.gAGroupBindingSource.DataMember = "GA_Group";
            this.gAGroupBindingSource.DataSource = this.bD_SMCDataSet;
            // 
            // gA_GroupTableAdapter
            // 
            this.gA_GroupTableAdapter.ClearBeforeFill = true;
            // 
            // b_Groub
            // 
            this.b_Groub.Image = global::Program.Properties.Resources._1353695237_appointment_new;
            this.b_Groub.Location = new System.Drawing.Point(24, 66);
            this.b_Groub.Name = "b_Groub";
            this.b_Groub.Size = new System.Drawing.Size(30, 30);
            this.b_Groub.TabIndex = 15;
            this.b_Groub.UseVisualStyleBackColor = true;
            this.b_Groub.Click += new System.EventHandler(this.b_Groub_Click);
            // 
            // SMC_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 494);
            this.Controls.Add(this.tc_Contant);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SMC_System";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "أدارة الأنظمة";
            this.Load += new System.EventHandler(this.SMC_System_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tc_Contant.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_System)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sys_Number)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tab)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Tab_Sequence)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bD_SMCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gASystemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAGroupBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_New;
        private System.Windows.Forms.ToolStripButton tsb_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripButton tsb_Save;
        private System.Windows.Forms.ToolStripButton tsb_Edit;
        private System.Windows.Forms.TabControl tc_Contant;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Sys_Note;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txt_Sys_Number;
        private System.Windows.Forms.TextBox txt_Sys_Name;
        private System.Windows.Forms.CheckBox cb_Sys_Active;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_System;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txt_Tab_Name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown txt_Tab_Sequence;
        private System.Windows.Forms.RichTextBox txt_Tab_Script_Local;
        private System.Windows.Forms.RichTextBox txt_Tab_Script_Net;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_Sys_Id_Table;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgv_Tab;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cb_Sys_Id_Screen;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Scrn_Name;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgv_;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_Scrn_Image;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Scrn_Image_Icon;
        private System.Windows.Forms.Button b_Scrn_Image;
        private System.Windows.Forms.ComboBox cb_Groub;
        private System.Windows.Forms.Label label13;
        private EntityControllar.BD_SMCDataSet bD_SMCDataSet;
        private System.Windows.Forms.BindingSource gASystemBindingSource;
        private EntityControllar.BD_SMCDataSetTableAdapters.GA_SystemTableAdapter gA_SystemTableAdapter;
        private System.Windows.Forms.BindingSource gAGroupBindingSource;
        private EntityControllar.BD_SMCDataSetTableAdapters.GA_GroupTableAdapter gA_GroupTableAdapter;
        private System.Windows.Forms.Button b_Groub;

    }
}