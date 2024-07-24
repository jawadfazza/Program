using System.Windows.Forms;

namespace ConfigUpdater
{
    partial class ConfigForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.Label lblInitialCatalog;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.TextBox txtInitialCatalog;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbConfigurations;
        private System.Windows.Forms.CheckBox chkEncrypt;
        private System.Windows.Forms.CheckBox chkTrustServerCertificate;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.PictureBox pictureBoxLogo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnSave;
            this.lblDataSource = new System.Windows.Forms.Label();
            this.lblInitialCatalog = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblNickname = new System.Windows.Forms.Label();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.txtInitialCatalog = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbConfigurations = new System.Windows.Forms.ComboBox();
            this.chkEncrypt = new System.Windows.Forms.CheckBox();
            this.chkTrustServerCertificate = new System.Windows.Forms.CheckBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataSource.Location = new System.Drawing.Point(359, 100);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(81, 18);
            this.lblDataSource.TabIndex = 0;
            this.lblDataSource.Text = "مصدر البيانات";
            // 
            // lblInitialCatalog
            // 
            this.lblInitialCatalog.AutoSize = true;
            this.lblInitialCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialCatalog.Location = new System.Drawing.Point(359, 126);
            this.lblInitialCatalog.Name = "lblInitialCatalog";
            this.lblInitialCatalog.Size = new System.Drawing.Size(76, 18);
            this.lblInitialCatalog.TabIndex = 2;
            this.lblInitialCatalog.Text = "قاعدة البيانات";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(359, 152);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(69, 18);
            this.lblUserID.TabIndex = 4;
            this.lblUserID.Text = "اسم المستخم";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(359, 178);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(66, 18);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "كلمة المرور";
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNickname.Location = new System.Drawing.Point(359, 204);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(96, 18);
            this.lblNickname.TabIndex = 8;
            this.lblNickname.Text = "الاسم البدل للرابط";
            this.lblNickname.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDataSource
            // 
            this.txtDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataSource.Location = new System.Drawing.Point(150, 97);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(200, 24);
            this.txtDataSource.TabIndex = 1;
            // 
            // txtInitialCatalog
            // 
            this.txtInitialCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInitialCatalog.Location = new System.Drawing.Point(150, 123);
            this.txtInitialCatalog.Name = "txtInitialCatalog";
            this.txtInitialCatalog.Size = new System.Drawing.Size(200, 24);
            this.txtInitialCatalog.TabIndex = 3;
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(150, 149);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(200, 24);
            this.txtUserID.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(150, 175);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 24);
            this.txtPassword.TabIndex = 7;
            // 
            // txtNickname
            // 
            this.txtNickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNickname.Location = new System.Drawing.Point(150, 201);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(200, 24);
            this.txtNickname.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnSave.Image = global::Program.Properties.Resources.document_save;
            btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnSave.Location = new System.Drawing.Point(256, 22);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(95, 37);
            btnSave.TabIndex = 12;
            btnSave.Text = "حفظ الرابط";
            btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Image = global::Program.Properties.Resources._1352992224_system_software_update;
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoad.Location = new System.Drawing.Point(150, 324);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(200, 38);
            this.btnLoad.TabIndex = 13;
            this.btnLoad.Text = "تحميل الرابط";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Image = global::Program.Properties.Resources._1354887031_button_cancel;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(150, 22);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 37);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "حذف الرابط";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbConfigurations
            // 
            this.cmbConfigurations.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConfigurations.FormattingEnabled = true;
            this.cmbConfigurations.Location = new System.Drawing.Point(150, 65);
            this.cmbConfigurations.Name = "cmbConfigurations";
            this.cmbConfigurations.Size = new System.Drawing.Size(200, 26);
            this.cmbConfigurations.TabIndex = 16;
            this.cmbConfigurations.SelectedIndexChanged += new System.EventHandler(this.cmbConfigurations_SelectedIndexChanged);
            // 
            // chkEncrypt
            // 
            this.chkEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEncrypt.AutoSize = true;
            this.chkEncrypt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEncrypt.Location = new System.Drawing.Point(250, 227);
            this.chkEncrypt.Name = "chkEncrypt";
            this.chkEncrypt.Size = new System.Drawing.Size(100, 22);
            this.chkEncrypt.TabIndex = 10;
            this.chkEncrypt.Text = "البيانات مشفرة";
            this.chkEncrypt.UseVisualStyleBackColor = true;
            // 
            // chkTrustServerCertificate
            // 
            this.chkTrustServerCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTrustServerCertificate.AutoSize = true;
            this.chkTrustServerCertificate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTrustServerCertificate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrustServerCertificate.Location = new System.Drawing.Point(268, 252);
            this.chkTrustServerCertificate.Name = "chkTrustServerCertificate";
            this.chkTrustServerCertificate.Size = new System.Drawing.Size(82, 22);
            this.chkTrustServerCertificate.TabIndex = 11;
            this.chkTrustServerCertificate.Text = "شهادة خادم";
            this.chkTrustServerCertificate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTrustServerCertificate.UseVisualStyleBackColor = true;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestConnection.Image = global::Program.Properties.Resources._1353000626_adept_update;
            this.btnTestConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTestConnection.Location = new System.Drawing.Point(150, 280);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(200, 38);
            this.btnTestConnection.TabIndex = 15;
            this.btnTestConnection.Text = "اختبار الاتصال";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(22, 22);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 17;
            this.pictureBoxLogo.TabStop = false;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 367);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.cmbConfigurations);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(btnSave);
            this.Controls.Add(this.chkTrustServerCertificate);
            this.Controls.Add(this.chkEncrypt);
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.lblNickname);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.txtInitialCatalog);
            this.Controls.Add(this.lblInitialCatalog);
            this.Controls.Add(this.txtDataSource);
            this.Controls.Add(this.lblDataSource);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الإتصال بقاعدة البيانات";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
