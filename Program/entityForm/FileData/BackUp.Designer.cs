namespace Program.entityForm.FileData
{
    partial class BackUp
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bBackUp = new System.Windows.Forms.ToolStripButton();
            this.bRestoe = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bBrowse = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.NumericUpDown();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFileSave = new System.Windows.Forms.TextBox();
            this.bBrowse1 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bBackUp,
            this.bRestoe});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(441, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bBackUp
            // 
            this.bBackUp.Image = global::Program.Properties.Resources.hp_folder_backup;
            this.bBackUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bBackUp.Name = "bBackUp";
            this.bBackUp.Size = new System.Drawing.Size(115, 22);
            this.bBackUp.Text = "إنشاء نقطة إستعادة";
            this.bBackUp.Click += new System.EventHandler(this.bBackUp_Click);
            // 
            // bRestoe
            // 
            this.bRestoe.Image = global::Program.Properties.Resources.database_3_32;
            this.bRestoe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRestoe.Name = "bRestoe";
            this.bRestoe.Size = new System.Drawing.Size(130, 22);
            this.bRestoe.Text = "استعادة قاعدة البيانات ";
            this.bRestoe.Click += new System.EventHandler(this.bRestoe_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 327);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // bBrowse
            // 
            this.bBrowse.Image = global::Program.Properties.Resources.folder_explore;
            this.bBrowse.Location = new System.Drawing.Point(51, 35);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(44, 40);
            this.bBrowse.TabIndex = 4;
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(219, 68);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(61, 27);
            this.txtNumber.TabIndex = 3;
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(101, 35);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(205, 27);
            this.txtFile.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "إنشاء نسخة كل";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "مكان الخزين";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "أيام";
            // 
            // button1
            // 
            this.button1.Image = global::Program.Properties.Resources.hp_folder_backup;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(51, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(255, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "إنشاء نقطة إستعادة";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.bBackUp_Click);
            // 
            // button2
            // 
            this.button2.Image = global::Program.Properties.Resources.database_3_32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(51, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(255, 40);
            this.button2.TabIndex = 7;
            this.button2.Text = "استعادة قاعدة البيانات ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.bRestoe_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtFile);
            this.groupBox2.Controls.Add(this.bBrowse);
            this.groupBox2.Controls.Add(this.txtNumber);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 155);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "إنشاء نقطة إستعادة";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtFileSave);
            this.groupBox3.Controls.Add(this.bBrowse1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(435, 146);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "استعادة قاعدة البيانات ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "مكان الحفظ";
            // 
            // txtFileSave
            // 
            this.txtFileSave.Enabled = false;
            this.txtFileSave.Location = new System.Drawing.Point(101, 38);
            this.txtFileSave.Name = "txtFileSave";
            this.txtFileSave.Size = new System.Drawing.Size(205, 27);
            this.txtFileSave.TabIndex = 9;
            // 
            // bBrowse1
            // 
            this.bBrowse1.Image = global::Program.Properties.Resources.folder_explore;
            this.bBrowse1.Location = new System.Drawing.Point(51, 38);
            this.bBrowse1.Name = "bBrowse1";
            this.bBrowse1.Size = new System.Drawing.Size(44, 40);
            this.bBrowse1.TabIndex = 10;
            this.bBrowse1.UseVisualStyleBackColor = true;
            this.bBrowse1.Click += new System.EventHandler(this.bBrowse1_Click);
            // 
            // BackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 352);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "BackUp";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "حفظ نسخة أحتياطية عن الملفات";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bBackUp;
        private System.Windows.Forms.ToolStripButton bRestoe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.NumericUpDown txtNumber;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFileSave;
        private System.Windows.Forms.Button bBrowse1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}