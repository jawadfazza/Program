namespace Program.entityForm.Material
{
    partial class MaterialTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialTree));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbGroup = new System.Windows.Forms.ListBox();
            this.gbOption = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbMaterialList = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bAddGroub = new System.Windows.Forms.ToolStripButton();
            this.bEditGroub = new System.Windows.Forms.ToolStripButton();
            this.bDeleteGroub = new System.Windows.Forms.ToolStripButton();
            this.gbGroubAdd = new System.Windows.Forms.GroupBox();
            this.txtGroub = new System.Windows.Forms.TextBox();
            this.bSaveGroub = new System.Windows.Forms.Button();
            this.gbGroubEdit = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbOption.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gbGroubAdd.SuspendLayout();
            this.gbGroubEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(280, 467);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.gbOption);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(272, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "دليل المواد العام";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbGroup);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 171);
            this.panel2.TabIndex = 2;
            // 
            // cbGroup
            // 
            this.cbGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbGroup.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.ItemHeight = 18;
            this.cbGroup.Location = new System.Drawing.Point(0, 0);
            this.cbGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(266, 171);
            this.cbGroup.TabIndex = 0;
            this.cbGroup.SelectedIndexChanged += new System.EventHandler(this.cbGroup_SelectedIndexChanged);
            this.cbGroup.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbGroup_MouseDoubleClick);
            // 
            // gbOption
            // 
            this.gbOption.Controls.Add(this.gbGroubEdit);
            this.gbOption.Controls.Add(this.gbGroubAdd);
            this.gbOption.Controls.Add(this.toolStrip1);
            this.gbOption.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbOption.Location = new System.Drawing.Point(3, 175);
            this.gbOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbOption.Name = "gbOption";
            this.gbOption.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbOption.Size = new System.Drawing.Size(266, 252);
            this.gbOption.TabIndex = 1;
            this.gbOption.TabStop = false;
            this.gbOption.Text = "خيارات دليل المواد العام";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbMaterialList);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(272, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "دليل المواد الفرعي";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbMaterialList
            // 
            this.lbMaterialList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMaterialList.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaterialList.FormattingEnabled = true;
            this.lbMaterialList.ItemHeight = 18;
            this.lbMaterialList.Location = new System.Drawing.Point(3, 4);
            this.lbMaterialList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbMaterialList.Name = "lbMaterialList";
            this.lbMaterialList.Size = new System.Drawing.Size(266, 319);
            this.lbMaterialList.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 323);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(266, 104);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 467);
            this.panel1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bAddGroub,
            this.bEditGroub,
            this.bDeleteGroub});
            this.toolStrip1.Location = new System.Drawing.Point(3, 223);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(260, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bAddGroub
            // 
            this.bAddGroub.Image = global::Program.Properties.Resources._1354871547_plus_64;
            this.bAddGroub.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAddGroub.Name = "bAddGroub";
            this.bAddGroub.Size = new System.Drawing.Size(54, 22);
            this.bAddGroub.Text = "إضافة";
            this.bAddGroub.Click += new System.EventHandler(this.bAddGroub_Click);
            // 
            // bEditGroub
            // 
            this.bEditGroub.Image = global::Program.Properties.Resources.data_transfer;
            this.bEditGroub.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bEditGroub.Name = "bEditGroub";
            this.bEditGroub.Size = new System.Drawing.Size(52, 22);
            this.bEditGroub.Text = "تعديل";
            this.bEditGroub.Click += new System.EventHandler(this.bEditGroub_Click);
            // 
            // bDeleteGroub
            // 
            this.bDeleteGroub.Image = global::Program.Properties.Resources._1354887031_button_cancel;
            this.bDeleteGroub.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDeleteGroub.Name = "bDeleteGroub";
            this.bDeleteGroub.Size = new System.Drawing.Size(48, 22);
            this.bDeleteGroub.Text = "حذف";
            // 
            // gbGroubAdd
            // 
            this.gbGroubAdd.Controls.Add(this.bSaveGroub);
            this.gbGroubAdd.Controls.Add(this.txtGroub);
            this.gbGroubAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbGroubAdd.Location = new System.Drawing.Point(3, 123);
            this.gbGroubAdd.Name = "gbGroubAdd";
            this.gbGroubAdd.Size = new System.Drawing.Size(260, 100);
            this.gbGroubAdd.TabIndex = 1;
            this.gbGroubAdd.TabStop = false;
            this.gbGroubAdd.Text = "إضافة مجموعة لدليل المواد العام";
            // 
            // txtGroub
            // 
            this.txtGroub.Location = new System.Drawing.Point(109, 42);
            this.txtGroub.Name = "txtGroub";
            this.txtGroub.Size = new System.Drawing.Size(136, 30);
            this.txtGroub.TabIndex = 0;
            // 
            // bSaveGroub
            // 
            this.bSaveGroub.Image = global::Program.Properties.Resources.document_save;
            this.bSaveGroub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSaveGroub.Location = new System.Drawing.Point(6, 42);
            this.bSaveGroub.Name = "bSaveGroub";
            this.bSaveGroub.Size = new System.Drawing.Size(97, 30);
            this.bSaveGroub.TabIndex = 1;
            this.bSaveGroub.Text = "حفظ";
            this.bSaveGroub.UseVisualStyleBackColor = true;
            this.bSaveGroub.Click += new System.EventHandler(this.bSaveGroub_Click);
            // 
            // gbGroubEdit
            // 
            this.gbGroubEdit.Controls.Add(this.button1);
            this.gbGroubEdit.Controls.Add(this.textBox1);
            this.gbGroubEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbGroubEdit.Location = new System.Drawing.Point(3, 23);
            this.gbGroubEdit.Name = "gbGroubEdit";
            this.gbGroubEdit.Size = new System.Drawing.Size(260, 100);
            this.gbGroubEdit.TabIndex = 2;
            this.gbGroubEdit.TabStop = false;
            this.gbGroubEdit.Text = "تعديل مجموعة لدليل المواد العام";
            this.gbGroubEdit.Enter += new System.EventHandler(this.gbGroubEdit_Enter);
            // 
            // button1
            // 
            this.button1.Image = global::Program.Properties.Resources.document_save;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(6, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "تعديل";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 30);
            this.textBox1.TabIndex = 0;
            // 
            // MaterialTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 467);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Traditional Arabic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MaterialTree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "شجرت المواد";
            this.Load += new System.EventHandler(this.MaterialTree_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gbOption.ResumeLayout(false);
            this.gbOption.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbGroubAdd.ResumeLayout(false);
            this.gbGroubAdd.PerformLayout();
            this.gbGroubEdit.ResumeLayout(false);
            this.gbGroubEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox cbGroup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbOption;
        private System.Windows.Forms.ListBox lbMaterialList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bAddGroub;
        private System.Windows.Forms.ToolStripButton bEditGroub;
        private System.Windows.Forms.ToolStripButton bDeleteGroub;
        private System.Windows.Forms.GroupBox gbGroubAdd;
        private System.Windows.Forms.TextBox txtGroub;
        private System.Windows.Forms.Button bSaveGroub;
        private System.Windows.Forms.GroupBox gbGroubEdit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}