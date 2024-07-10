namespace Program.entityForm.FileData
{
    partial class NewYear
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
            this.bStartNewYear = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSql = new System.Windows.Forms.RichTextBox();
            this.cbBillsOutReturn = new System.Windows.Forms.CheckBox();
            this.cbBillsInReturn = new System.Windows.Forms.CheckBox();
            this.cbBillsIn = new System.Windows.Forms.CheckBox();
            this.cbBillsOut = new System.Windows.Forms.CheckBox();
            this.cbAssets = new System.Windows.Forms.CheckBox();
            this.cbBox = new System.Windows.Forms.CheckBox();
            this.cbPaber = new System.Windows.Forms.CheckBox();
            this.cbCustomer = new System.Windows.Forms.CheckBox();
            this.cbSupllier = new System.Windows.Forms.CheckBox();
            this.cbMaterial = new System.Windows.Forms.CheckBox();
            this.cbAssetsTrush = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(315, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bStartNewYear
            // 
            this.bStartNewYear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bStartNewYear.Location = new System.Drawing.Point(3, 324);
            this.bStartNewYear.Margin = new System.Windows.Forms.Padding(4);
            this.bStartNewYear.Name = "bStartNewYear";
            this.bStartNewYear.Size = new System.Drawing.Size(309, 34);
            this.bStartNewYear.TabIndex = 1;
            this.bStartNewYear.Text = "بدء عملية الترحيل";
            this.bStartNewYear.UseVisualStyleBackColor = true;
            this.bStartNewYear.Click += new System.EventHandler(this.bStartNewYear_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.lStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 386);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(315, 29);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 23);
            // 
            // lStatus
            // 
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(42, 24);
            this.lStatus.Text = "-------";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbAssetsTrush);
            this.groupBox1.Controls.Add(this.txtSql);
            this.groupBox1.Controls.Add(this.cbBillsOutReturn);
            this.groupBox1.Controls.Add(this.cbBillsInReturn);
            this.groupBox1.Controls.Add(this.cbBillsIn);
            this.groupBox1.Controls.Add(this.cbBillsOut);
            this.groupBox1.Controls.Add(this.cbAssets);
            this.groupBox1.Controls.Add(this.cbBox);
            this.groupBox1.Controls.Add(this.cbPaber);
            this.groupBox1.Controls.Add(this.cbCustomer);
            this.groupBox1.Controls.Add(this.cbSupllier);
            this.groupBox1.Controls.Add(this.cbMaterial);
            this.groupBox1.Controls.Add(this.bStartNewYear);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(315, 361);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "خيارات بداية العام الجديد";
            // 
            // txtSql
            // 
            this.txtSql.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSql.Location = new System.Drawing.Point(3, 314);
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(309, 10);
            this.txtSql.TabIndex = 15;
            this.txtSql.Text = "";
            // 
            // cbBillsOutReturn
            // 
            this.cbBillsOutReturn.AutoSize = true;
            this.cbBillsOutReturn.Checked = true;
            this.cbBillsOutReturn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBillsOutReturn.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbBillsOutReturn.Location = new System.Drawing.Point(3, 230);
            this.cbBillsOutReturn.Name = "cbBillsOutReturn";
            this.cbBillsOutReturn.Size = new System.Drawing.Size(309, 23);
            this.cbBillsOutReturn.TabIndex = 14;
            this.cbBillsOutReturn.Text = "نسخ سندات ردّ المشتريات";
            this.cbBillsOutReturn.UseVisualStyleBackColor = true;
            // 
            // cbBillsInReturn
            // 
            this.cbBillsInReturn.AutoSize = true;
            this.cbBillsInReturn.Checked = true;
            this.cbBillsInReturn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBillsInReturn.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbBillsInReturn.Location = new System.Drawing.Point(3, 207);
            this.cbBillsInReturn.Name = "cbBillsInReturn";
            this.cbBillsInReturn.Size = new System.Drawing.Size(309, 23);
            this.cbBillsInReturn.TabIndex = 13;
            this.cbBillsInReturn.Text = "نسخ فواتير ردّ المبيعات";
            this.cbBillsInReturn.UseVisualStyleBackColor = true;
            // 
            // cbBillsIn
            // 
            this.cbBillsIn.AutoSize = true;
            this.cbBillsIn.Checked = true;
            this.cbBillsIn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBillsIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbBillsIn.Location = new System.Drawing.Point(3, 184);
            this.cbBillsIn.Name = "cbBillsIn";
            this.cbBillsIn.Size = new System.Drawing.Size(309, 23);
            this.cbBillsIn.TabIndex = 12;
            this.cbBillsIn.Text = "نسخ سندات الإدخال المشتريات";
            this.cbBillsIn.UseVisualStyleBackColor = true;
            // 
            // cbBillsOut
            // 
            this.cbBillsOut.AutoSize = true;
            this.cbBillsOut.Checked = true;
            this.cbBillsOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBillsOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbBillsOut.Location = new System.Drawing.Point(3, 161);
            this.cbBillsOut.Name = "cbBillsOut";
            this.cbBillsOut.Size = new System.Drawing.Size(309, 23);
            this.cbBillsOut.TabIndex = 11;
            this.cbBillsOut.Text = "نسخ فواتير البيع";
            this.cbBillsOut.UseVisualStyleBackColor = true;
            // 
            // cbAssets
            // 
            this.cbAssets.AutoSize = true;
            this.cbAssets.Checked = true;
            this.cbAssets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAssets.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbAssets.Location = new System.Drawing.Point(3, 138);
            this.cbAssets.Name = "cbAssets";
            this.cbAssets.Size = new System.Drawing.Size(309, 23);
            this.cbAssets.TabIndex = 10;
            this.cbAssets.Text = "ترحيل الأصول و الخصوم";
            this.cbAssets.UseVisualStyleBackColor = true;
            // 
            // cbBox
            // 
            this.cbBox.AutoSize = true;
            this.cbBox.Checked = true;
            this.cbBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbBox.Location = new System.Drawing.Point(3, 115);
            this.cbBox.Name = "cbBox";
            this.cbBox.Size = new System.Drawing.Size(309, 23);
            this.cbBox.TabIndex = 6;
            this.cbBox.Text = "ترحيل الصناديق و الحسابات البنكية";
            this.cbBox.UseVisualStyleBackColor = true;
            // 
            // cbPaber
            // 
            this.cbPaber.AutoSize = true;
            this.cbPaber.Checked = true;
            this.cbPaber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPaber.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbPaber.Location = new System.Drawing.Point(3, 92);
            this.cbPaber.Name = "cbPaber";
            this.cbPaber.Size = new System.Drawing.Size(309, 23);
            this.cbPaber.TabIndex = 5;
            this.cbPaber.Text = "ترحيل السندات";
            this.cbPaber.UseVisualStyleBackColor = true;
            // 
            // cbCustomer
            // 
            this.cbCustomer.AutoSize = true;
            this.cbCustomer.Checked = true;
            this.cbCustomer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbCustomer.Location = new System.Drawing.Point(3, 69);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(309, 23);
            this.cbCustomer.TabIndex = 4;
            this.cbCustomer.Text = "ترحيل الزبائن ";
            this.cbCustomer.UseVisualStyleBackColor = true;
            // 
            // cbSupllier
            // 
            this.cbSupllier.AutoSize = true;
            this.cbSupllier.Checked = true;
            this.cbSupllier.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSupllier.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbSupllier.Location = new System.Drawing.Point(3, 46);
            this.cbSupllier.Name = "cbSupllier";
            this.cbSupllier.Size = new System.Drawing.Size(309, 23);
            this.cbSupllier.TabIndex = 3;
            this.cbSupllier.Text = "ترحيل الموردين";
            this.cbSupllier.UseVisualStyleBackColor = true;
            // 
            // cbMaterial
            // 
            this.cbMaterial.AutoSize = true;
            this.cbMaterial.Checked = true;
            this.cbMaterial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbMaterial.Location = new System.Drawing.Point(3, 23);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(309, 23);
            this.cbMaterial.TabIndex = 2;
            this.cbMaterial.Text = "ترحيل المواد";
            this.cbMaterial.UseVisualStyleBackColor = true;
            // 
            // cbAssetsTrush
            // 
            this.cbAssetsTrush.AutoSize = true;
            this.cbAssetsTrush.Checked = true;
            this.cbAssetsTrush.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAssetsTrush.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbAssetsTrush.Location = new System.Drawing.Point(3, 253);
            this.cbAssetsTrush.Name = "cbAssetsTrush";
            this.cbAssetsTrush.Size = new System.Drawing.Size(309, 23);
            this.cbAssetsTrush.TabIndex = 16;
            this.cbAssetsTrush.Text = "خصم إهتلاك الأصول";
            this.cbAssetsTrush.UseVisualStyleBackColor = true;
            // 
            // NewYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 415);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NewYear";
            this.Text = "بداية سنة جديدة";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button bStartNewYear;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbBox;
        private System.Windows.Forms.CheckBox cbPaber;
        private System.Windows.Forms.CheckBox cbCustomer;
        private System.Windows.Forms.CheckBox cbSupllier;
        private System.Windows.Forms.CheckBox cbMaterial;
        private System.Windows.Forms.CheckBox cbBillsIn;
        private System.Windows.Forms.CheckBox cbBillsOut;
        private System.Windows.Forms.CheckBox cbAssets;
        private System.Windows.Forms.CheckBox cbBillsOutReturn;
        private System.Windows.Forms.CheckBox cbBillsInReturn;
        private System.Windows.Forms.ToolStripStatusLabel lStatus;
        private System.Windows.Forms.RichTextBox txtSql;
        private System.Windows.Forms.CheckBox cbAssetsTrush;
    }
}