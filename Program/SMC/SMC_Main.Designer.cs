namespace Program.SMC
{
    partial class SMC_Main
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
            this.b_System = new System.Windows.Forms.Button();
            this.b_Groub = new System.Windows.Forms.Button();
            this.b_User = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_System
            // 
            this.b_System.Dock = System.Windows.Forms.DockStyle.Top;
            this.b_System.Font = new System.Drawing.Font("Andalus", 12F);
            this.b_System.Location = new System.Drawing.Point(0, 0);
            this.b_System.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.b_System.Name = "b_System";
            this.b_System.Size = new System.Drawing.Size(237, 44);
            this.b_System.TabIndex = 0;
            this.b_System.Text = "أدارة الأنظمة";
            this.b_System.UseVisualStyleBackColor = true;
            this.b_System.Click += new System.EventHandler(this.b_System_Click);
            // 
            // b_Groub
            // 
            this.b_Groub.Dock = System.Windows.Forms.DockStyle.Top;
            this.b_Groub.Font = new System.Drawing.Font("Andalus", 12F);
            this.b_Groub.Location = new System.Drawing.Point(0, 44);
            this.b_Groub.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.b_Groub.Name = "b_Groub";
            this.b_Groub.Size = new System.Drawing.Size(237, 44);
            this.b_Groub.TabIndex = 1;
            this.b_Groub.Text = "أدارة المجموعات";
            this.b_Groub.UseVisualStyleBackColor = true;
            // 
            // b_User
            // 
            this.b_User.Dock = System.Windows.Forms.DockStyle.Top;
            this.b_User.Font = new System.Drawing.Font("Andalus", 12F);
            this.b_User.Location = new System.Drawing.Point(0, 88);
            this.b_User.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.b_User.Name = "b_User";
            this.b_User.Size = new System.Drawing.Size(237, 44);
            this.b_User.TabIndex = 2;
            this.b_User.Text = "أدارة المستخدمين";
            this.b_User.UseVisualStyleBackColor = true;
            // 
            // SMC_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 131);
            this.Controls.Add(this.b_User);
            this.Controls.Add(this.b_Groub);
            this.Controls.Add(this.b_System);
            this.Font = new System.Drawing.Font("Bradley Hand ITC", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "SMC_Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نظام أدارة المحتوى";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_System;
        private System.Windows.Forms.Button b_Groub;
        private System.Windows.Forms.Button b_User;
    }
}