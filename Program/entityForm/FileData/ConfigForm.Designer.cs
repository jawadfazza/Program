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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
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
            btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.Image = global::Program.Properties.Resources.document_save;
            btnSave.Name = "btnSave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDataSource
            // 
            resources.ApplyResources(this.lblDataSource, "lblDataSource");
            this.lblDataSource.Name = "lblDataSource";
            // 
            // lblInitialCatalog
            // 
            resources.ApplyResources(this.lblInitialCatalog, "lblInitialCatalog");
            this.lblInitialCatalog.Name = "lblInitialCatalog";
            // 
            // lblUserID
            // 
            resources.ApplyResources(this.lblUserID, "lblUserID");
            this.lblUserID.Name = "lblUserID";
            // 
            // lblPassword
            // 
            resources.ApplyResources(this.lblPassword, "lblPassword");
            this.lblPassword.Name = "lblPassword";
            // 
            // lblNickname
            // 
            resources.ApplyResources(this.lblNickname, "lblNickname");
            this.lblNickname.Name = "lblNickname";
            // 
            // txtDataSource
            // 
            resources.ApplyResources(this.txtDataSource, "txtDataSource");
            this.txtDataSource.Name = "txtDataSource";
            // 
            // txtInitialCatalog
            // 
            resources.ApplyResources(this.txtInitialCatalog, "txtInitialCatalog");
            this.txtInitialCatalog.Name = "txtInitialCatalog";
            // 
            // txtUserID
            // 
            resources.ApplyResources(this.txtUserID, "txtUserID");
            this.txtUserID.Name = "txtUserID";
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtNickname
            // 
            resources.ApplyResources(this.txtNickname, "txtNickname");
            this.txtNickname.Name = "txtNickname";
            // 
            // btnLoad
            // 
            resources.ApplyResources(this.btnLoad, "btnLoad");
            this.btnLoad.Image = global::Program.Properties.Resources._1352992224_system_software_update;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Image = global::Program.Properties.Resources._1354887031_button_cancel;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbConfigurations
            // 
            resources.ApplyResources(this.cmbConfigurations, "cmbConfigurations");
            this.cmbConfigurations.FormattingEnabled = true;
            this.cmbConfigurations.Name = "cmbConfigurations";
            this.cmbConfigurations.SelectedIndexChanged += new System.EventHandler(this.cmbConfigurations_SelectedIndexChanged);
            // 
            // chkEncrypt
            // 
            resources.ApplyResources(this.chkEncrypt, "chkEncrypt");
            this.chkEncrypt.Name = "chkEncrypt";
            this.chkEncrypt.UseVisualStyleBackColor = true;
            // 
            // chkTrustServerCertificate
            // 
            resources.ApplyResources(this.chkTrustServerCertificate, "chkTrustServerCertificate");
            this.chkTrustServerCertificate.Name = "chkTrustServerCertificate";
            this.chkTrustServerCertificate.UseVisualStyleBackColor = true;
            // 
            // btnTestConnection
            // 
            resources.ApplyResources(this.btnTestConnection, "btnTestConnection");
            this.btnTestConnection.Image = global::Program.Properties.Resources._1353000626_adept_update;
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // ConfigForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
