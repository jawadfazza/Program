namespace Program.entityForm.FileData
{
    partial class User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.bDelete = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbTask = new System.Windows.Forms.CheckedListBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.miAll = new System.Windows.Forms.ToolStripMenuItem();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.miSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.miPaper = new System.Windows.Forms.ToolStripMenuItem();
            this.miBox = new System.Windows.Forms.ToolStripMenuItem();
            this.miBank = new System.Windows.Forms.ToolStripMenuItem();
            this.miMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.miAssets = new System.Windows.Forms.ToolStripMenuItem();
            this.miAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bEdit = new System.Windows.Forms.Button();
            this.bDeleteUser = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.bDelete,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(48, 22);
            this.newToolStripButton.Text = "جديد";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.Image = global::Program.Properties.Resources._1352992224_system_software_update;
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(80, 22);
            this.openToolStripButton.Text = "تعديل المهام";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // bDelete
            // 
            this.bDelete.Image = global::Program.Properties.Resources._1354887031_button_cancel;
            this.bDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(92, 22);
            this.bDelete.Text = "حذف المستخدم";
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.Image = global::Program.Properties.Resources.document_save;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(93, 22);
            this.saveToolStripButton.Text = "حفظ المستخدم ";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 437);
            this.panel1.TabIndex = 1;
            this.panel1.Validating += new System.ComponentModel.CancelEventHandler(this.panel1_Validating);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.toolStrip2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(612, 437);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "قائمة المهام";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbTask);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(606, 386);
            this.panel2.TabIndex = 2;
            // 
            // cbTask
            // 
            this.cbTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTask.FormattingEnabled = true;
            this.cbTask.Location = new System.Drawing.Point(0, 0);
            this.cbTask.Name = "cbTask";
            this.cbTask.Size = new System.Drawing.Size(606, 386);
            this.cbTask.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip2.Location = new System.Drawing.Point(3, 23);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(606, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAll,
            this.miFile,
            this.miCustomer,
            this.miSupplier,
            this.miPaper,
            this.miBox,
            this.miBank,
            this.miMaterial,
            this.miAssets,
            this.miAccount});
            this.toolStripDropDownButton1.Enabled = false;
            this.toolStripDropDownButton1.Image = global::Program.Properties.Resources._1352240457_company;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(85, 22);
            this.toolStripDropDownButton1.Text = "قوائم المهام";
            // 
            // miAll
            // 
            this.miAll.Image = global::Program.Properties.Resources._1352142251_home;
            this.miAll.Name = "miAll";
            this.miAll.Size = new System.Drawing.Size(160, 22);
            this.miAll.Text = "كل القوائم";
            this.miAll.Click += new System.EventHandler(this.miAll_Click);
            // 
            // miFile
            // 
            this.miFile.Image = global::Program.Properties.Resources.generic_folder_alt;
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(160, 22);
            this.miFile.Text = "ملف";
            this.miFile.Click += new System.EventHandler(this.miFile_Click);
            // 
            // miCustomer
            // 
            this.miCustomer.Image = global::Program.Properties.Resources._1353172927_Users_Group;
            this.miCustomer.Name = "miCustomer";
            this.miCustomer.Size = new System.Drawing.Size(160, 22);
            this.miCustomer.Text = "الزبائن";
            this.miCustomer.Click += new System.EventHandler(this.miCustomer_Click);
            // 
            // miSupplier
            // 
            this.miSupplier.Image = global::Program.Properties.Resources._1353173427_Customer_Male_Light1;
            this.miSupplier.Name = "miSupplier";
            this.miSupplier.Size = new System.Drawing.Size(160, 22);
            this.miSupplier.Text = "الموردين";
            this.miSupplier.Click += new System.EventHandler(this.miSupplier_Click);
            // 
            // miPaper
            // 
            this.miPaper.Image = global::Program.Properties.Resources._1353174954_document;
            this.miPaper.Name = "miPaper";
            this.miPaper.Size = new System.Drawing.Size(160, 22);
            this.miPaper.Text = "سندات";
            this.miPaper.Click += new System.EventHandler(this.miPaper_Click);
            // 
            // miBox
            // 
            this.miBox.Image = global::Program.Properties.Resources._1353174121_piggy_bank;
            this.miBox.Name = "miBox";
            this.miBox.Size = new System.Drawing.Size(160, 22);
            this.miBox.Text = "الصندوق";
            this.miBox.Click += new System.EventHandler(this.miBox_Click);
            // 
            // miBank
            // 
            this.miBank.Image = global::Program.Properties.Resources.add_Bank;
            this.miBank.Name = "miBank";
            this.miBank.Size = new System.Drawing.Size(160, 22);
            this.miBank.Text = "البنك";
            this.miBank.Click += new System.EventHandler(this.miBank_Click);
            // 
            // miMaterial
            // 
            this.miMaterial.Image = global::Program.Properties.Resources._1353174596_materials;
            this.miMaterial.Name = "miMaterial";
            this.miMaterial.Size = new System.Drawing.Size(160, 22);
            this.miMaterial.Text = "المواد و الخدمات";
            this.miMaterial.Click += new System.EventHandler(this.miMaterial_Click);
            // 
            // miAssets
            // 
            this.miAssets.Image = global::Program.Properties.Resources.asset_green;
            this.miAssets.Name = "miAssets";
            this.miAssets.Size = new System.Drawing.Size(160, 22);
            this.miAssets.Text = "الأصول و الإلتزامات";
            this.miAssets.Click += new System.EventHandler(this.miAssets_Click);
            // 
            // miAccount
            // 
            this.miAccount.Image = global::Program.Properties.Resources.emblem_money;
            this.miAccount.Name = "miAccount";
            this.miAccount.Size = new System.Drawing.Size(160, 22);
            this.miAccount.Text = "المحاسبة";
            this.miAccount.Click += new System.EventHandler(this.miAccount_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bEdit);
            this.groupBox1.Controls.Add(this.bDeleteUser);
            this.groupBox1.Controls.Add(this.bSave);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(612, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(372, 437);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "المستخدمين";
            // 
            // bEdit
            // 
            this.bEdit.Image = global::Program.Properties.Resources._1352992224_system_software_update;
            this.bEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEdit.Location = new System.Drawing.Point(24, 164);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(215, 35);
            this.bEdit.TabIndex = 7;
            this.bEdit.Text = "تعديل المهام";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bDeleteUser
            // 
            this.bDeleteUser.Image = global::Program.Properties.Resources._1354887031_button_cancel;
            this.bDeleteUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bDeleteUser.Location = new System.Drawing.Point(24, 127);
            this.bDeleteUser.Name = "bDeleteUser";
            this.bDeleteUser.Size = new System.Drawing.Size(215, 35);
            this.bDeleteUser.TabIndex = 6;
            this.bDeleteUser.Text = "حذف المستخدم";
            this.bDeleteUser.UseVisualStyleBackColor = true;
            this.bDeleteUser.Click += new System.EventHandler(this.bDeleteUser_Click);
            // 
            // bSave
            // 
            this.bSave.Image = global::Program.Properties.Resources.document_save;
            this.bSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSave.Location = new System.Drawing.Point(24, 90);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(215, 35);
            this.bSave.TabIndex = 5;
            this.bSave.Text = "حفظ المستخدم";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtUsername.FormattingEnabled = true;
            this.txtUsername.Location = new System.Drawing.Point(24, 26);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(215, 27);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.SelectedIndexChanged += new System.EventHandler(this.txtUsername_SelectedIndexChanged);
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "كلمة المرور";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "اسم المستخدم";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(24, 57);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(215, 27);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "User";
            this.RightToLeftLayout = true;
            this.Text = "إدارة المستخدمين";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.User_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox txtUsername;
        private System.Windows.Forms.CheckedListBox cbTask;
        private System.Windows.Forms.ToolStripButton bDelete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miCustomer;
        private System.Windows.Forms.ToolStripMenuItem miSupplier;
        private System.Windows.Forms.ToolStripMenuItem miBox;
        private System.Windows.Forms.ToolStripMenuItem miBank;
        private System.Windows.Forms.ToolStripMenuItem miMaterial;
        private System.Windows.Forms.ToolStripMenuItem miAssets;
        private System.Windows.Forms.ToolStripMenuItem miAccount;
        private System.Windows.Forms.ToolStripMenuItem miPaper;
        private System.Windows.Forms.ToolStripMenuItem miAll;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bDeleteUser;
        private System.Windows.Forms.Button bSave;
    }
}