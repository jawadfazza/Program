namespace Program.entityForm.Bonds
{
    partial class WritBonds
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WritBonds));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewBond = new System.Windows.Forms.DataGridView();
            this.dgvBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtBalanceBond = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.txtDibetBond = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.txtCreditBond = new System.Windows.Forms.ToolStripComboBox();
            this.txtBondsComment = new System.Windows.Forms.ToolStripTextBox();
            this.bAddBond = new System.Windows.Forms.ToolStripButton();
            this.bRemoveBonds = new System.Windows.Forms.ToolStripButton();
            this.bUpdateBonds = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBond)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.toolStrip3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(792, 597);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "قيد العملية";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewBond);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 49);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 544);
            this.panel2.TabIndex = 12;
            // 
            // dataGridViewBond
            // 
            this.dataGridViewBond.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewBond.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBond.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvBalance,
            this.dgvFrom,
            this.dgvTo,
            this.dgvComment});
            this.dataGridViewBond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBond.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBond.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewBond.Name = "dataGridViewBond";
            this.dataGridViewBond.ReadOnly = true;
            this.dataGridViewBond.Size = new System.Drawing.Size(784, 544);
            this.dataGridViewBond.TabIndex = 10;
            this.dataGridViewBond.Click += new System.EventHandler(this.dataGridViewBond_Click);
            this.dataGridViewBond.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewBond_KeyDown);
            // 
            // dgvBalance
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Format = "C1";
            dataGridViewCellStyle1.NullValue = "0";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvBalance.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBalance.HeaderText = "الرصيد";
            this.dgvBalance.Name = "dgvBalance";
            this.dgvBalance.ReadOnly = true;
            this.dgvBalance.Width = 150;
            // 
            // dgvFrom
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFrom.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFrom.HeaderText = "من";
            this.dgvFrom.Name = "dgvFrom";
            this.dgvFrom.ReadOnly = true;
            this.dgvFrom.Width = 150;
            // 
            // dgvTo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTo.HeaderText = "إلى";
            this.dgvTo.Name = "dgvTo";
            this.dgvTo.ReadOnly = true;
            this.dgvTo.Width = 150;
            // 
            // dgvComment
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComment.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvComment.HeaderText = "ملاحظة";
            this.dgvComment.Name = "dgvComment";
            this.dgvComment.ReadOnly = true;
            this.dgvComment.ToolTipText = "\"\"";
            this.dgvComment.Width = 200;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripSeparator2,
            this.txtBalanceBond,
            this.toolStripSeparator3,
            this.txtDibetBond,
            this.toolStripSeparator4,
            this.txtCreditBond,
            this.txtBondsComment,
            this.bAddBond,
            this.bRemoveBonds,
            this.bUpdateBonds});
            this.toolStrip3.Location = new System.Drawing.Point(4, 24);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip3.Size = new System.Drawing.Size(784, 25);
            this.toolStrip3.TabIndex = 11;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(22, 22);
            this.toolStripLabel2.Text = "|||||";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtBalanceBond
            // 
            this.txtBalanceBond.Name = "txtBalanceBond";
            this.txtBalanceBond.Size = new System.Drawing.Size(145, 25);
            this.txtBalanceBond.Text = "0";
            this.txtBalanceBond.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBalanceBond_KeyDown);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // txtDibetBond
            // 
            this.txtDibetBond.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDibetBond.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDibetBond.Name = "txtDibetBond";
            this.txtDibetBond.Size = new System.Drawing.Size(145, 25);
            this.txtDibetBond.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDibetBond_KeyDown);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // txtCreditBond
            // 
            this.txtCreditBond.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCreditBond.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCreditBond.Name = "txtCreditBond";
            this.txtCreditBond.Size = new System.Drawing.Size(145, 25);
            this.txtCreditBond.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCreditBond_KeyDown);
            // 
            // txtBondsComment
            // 
            this.txtBondsComment.Name = "txtBondsComment";
            this.txtBondsComment.Size = new System.Drawing.Size(200, 25);
            this.txtBondsComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBondsComment_KeyDown);
            // 
            // bAddBond
            // 
            this.bAddBond.Image = global::Program.Properties.Resources._1354871547_plus_64;
            this.bAddBond.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAddBond.Name = "bAddBond";
            this.bAddBond.Size = new System.Drawing.Size(70, 22);
            this.bAddBond.Text = "إضافة قيد";
            this.bAddBond.Click += new System.EventHandler(this.bAddBond_Click);
            // 
            // bRemoveBonds
            // 
            this.bRemoveBonds.Image = global::Program.Properties.Resources._1354887031_button_cancel;
            this.bRemoveBonds.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRemoveBonds.Name = "bRemoveBonds";
            this.bRemoveBonds.Size = new System.Drawing.Size(64, 20);
            this.bRemoveBonds.Text = "إزالة قيد";
            this.bRemoveBonds.Click += new System.EventHandler(this.bRemoveBonds_Click);
            // 
            // bUpdateBonds
            // 
            this.bUpdateBonds.Image = global::Program.Properties.Resources._1353000626_adept_update;
            this.bUpdateBonds.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bUpdateBonds.Name = "bUpdateBonds";
            this.bUpdateBonds.Size = new System.Drawing.Size(68, 20);
            this.bUpdateBonds.Text = "تعديل قيد";
            this.bUpdateBonds.Click += new System.EventHandler(this.bUpdateBonds_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 25);
            this.toolStrip1.TabIndex = 3;
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
            // saveToolStripButton
            // 
            this.saveToolStripButton.Image = global::Program.Properties.Resources.document_save;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(74, 22);
            this.saveToolStripButton.Text = "حفظ القيود";
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
            // WritBonds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 597);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WritBonds";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "إضافة القيود اليومية";
            this.Load += new System.EventHandler(this.WritBonds_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBond)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewBond;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvComment;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox txtBalanceBond;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox txtDibetBond;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripComboBox txtCreditBond;
        private System.Windows.Forms.ToolStripButton bAddBond;
        private System.Windows.Forms.ToolStripButton bRemoveBonds;
        private System.Windows.Forms.ToolStripTextBox txtBondsComment;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripButton bUpdateBonds;
    }
}