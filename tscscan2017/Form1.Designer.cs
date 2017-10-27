namespace tscscan2017
{
    partial class Form1
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
            this.btn_readTscscan = new System.Windows.Forms.Button();
            this.dataGridViewTscscan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChar = new System.Windows.Forms.TextBox();
            this.txtScancode = new System.Windows.Forms.TextBox();
            this.btn_ReadTscShift = new System.Windows.Forms.Button();
            this.dataGridViewShiftList = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCharIn = new System.Windows.Forms.TextBox();
            this.txtCharOut = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShifted = new System.Windows.Forms.TextBox();
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapKeysForRDMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTscscan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShiftList)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_readTscscan
            // 
            this.btn_readTscscan.Location = new System.Drawing.Point(337, 35);
            this.btn_readTscscan.Name = "btn_readTscscan";
            this.btn_readTscscan.Size = new System.Drawing.Size(96, 24);
            this.btn_readTscscan.TabIndex = 0;
            this.btn_readTscscan.Text = "Read tscscan";
            this.btn_readTscscan.UseVisualStyleBackColor = true;
            this.btn_readTscscan.Click += new System.EventHandler(this.btn_readTscscan_Click);
            // 
            // dataGridViewTscscan
            // 
            this.dataGridViewTscscan.AllowUserToAddRows = false;
            this.dataGridViewTscscan.AllowUserToDeleteRows = false;
            this.dataGridViewTscscan.AllowUserToOrderColumns = true;
            this.dataGridViewTscscan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTscscan.Location = new System.Drawing.Point(339, 77);
            this.dataGridViewTscscan.Name = "dataGridViewTscscan";
            this.dataGridViewTscscan.ReadOnly = true;
            this.dataGridViewTscscan.RowHeadersVisible = false;
            this.dataGridViewTscscan.Size = new System.Drawing.Size(428, 147);
            this.dataGridViewTscscan.TabIndex = 1;
            this.dataGridViewTscscan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewTscscan_CellFormatting);
            this.dataGridViewTscscan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTscscan_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Char:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Scancode:";
            // 
            // txtChar
            // 
            this.txtChar.Location = new System.Drawing.Point(420, 346);
            this.txtChar.Name = "txtChar";
            this.txtChar.ReadOnly = true;
            this.txtChar.Size = new System.Drawing.Size(164, 20);
            this.txtChar.TabIndex = 3;
            // 
            // txtScancode
            // 
            this.txtScancode.Location = new System.Drawing.Point(420, 372);
            this.txtScancode.Name = "txtScancode";
            this.txtScancode.ReadOnly = true;
            this.txtScancode.Size = new System.Drawing.Size(164, 20);
            this.txtScancode.TabIndex = 3;
            // 
            // btn_ReadTscShift
            // 
            this.btn_ReadTscShift.Location = new System.Drawing.Point(12, 35);
            this.btn_ReadTscShift.Name = "btn_ReadTscShift";
            this.btn_ReadTscShift.Size = new System.Drawing.Size(96, 24);
            this.btn_ReadTscShift.TabIndex = 0;
            this.btn_ReadTscShift.Text = "Read tscshift";
            this.btn_ReadTscShift.UseVisualStyleBackColor = true;
            this.btn_ReadTscShift.Click += new System.EventHandler(this.btn_ReadTscShift_Click);
            // 
            // dataGridViewShiftList
            // 
            this.dataGridViewShiftList.AllowUserToAddRows = false;
            this.dataGridViewShiftList.AllowUserToDeleteRows = false;
            this.dataGridViewShiftList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShiftList.Location = new System.Drawing.Point(13, 77);
            this.dataGridViewShiftList.Name = "dataGridViewShiftList";
            this.dataGridViewShiftList.ReadOnly = true;
            this.dataGridViewShiftList.RowHeadersVisible = false;
            this.dataGridViewShiftList.Size = new System.Drawing.Size(308, 147);
            this.dataGridViewShiftList.TabIndex = 4;
            this.dataGridViewShiftList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewShiftList_CellFormatting);
            this.dataGridViewShiftList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewShiftList_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Char In:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 379);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Char Out:";
            // 
            // txtCharIn
            // 
            this.txtCharIn.Location = new System.Drawing.Point(96, 346);
            this.txtCharIn.Name = "txtCharIn";
            this.txtCharIn.ReadOnly = true;
            this.txtCharIn.Size = new System.Drawing.Size(164, 20);
            this.txtCharIn.TabIndex = 3;
            // 
            // txtCharOut
            // 
            this.txtCharOut.Location = new System.Drawing.Point(96, 372);
            this.txtCharOut.Name = "txtCharOut";
            this.txtCharOut.ReadOnly = true;
            this.txtCharOut.Size = new System.Drawing.Size(164, 20);
            this.txtCharOut.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Shifted:";
            // 
            // txtShifted
            // 
            this.txtShifted.Location = new System.Drawing.Point(96, 398);
            this.txtShifted.Name = "txtShifted";
            this.txtShifted.ReadOnly = true;
            this.txtShifted.Size = new System.Drawing.Size(164, 20);
            this.txtShifted.TabIndex = 3;
            // 
            // txtFunction
            // 
            this.txtFunction.Location = new System.Drawing.Point(14, 432);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.ReadOnly = true;
            this.txtFunction.Size = new System.Drawing.Size(752, 20);
            this.txtFunction.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(779, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fToolStripMenuItem
            // 
            this.fToolStripMenuItem.Name = "fToolStripMenuItem";
            this.fToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapKeysForRDMToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // mapKeysForRDMToolStripMenuItem
            // 
            this.mapKeysForRDMToolStripMenuItem.Name = "mapKeysForRDMToolStripMenuItem";
            this.mapKeysForRDMToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.mapKeysForRDMToolStripMenuItem.Text = "Map Keys for RDM";
            this.mapKeysForRDMToolStripMenuItem.Click += new System.EventHandler(this.mapKeysForRDMToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 468);
            this.Controls.Add(this.txtFunction);
            this.Controls.Add(this.dataGridViewShiftList);
            this.Controls.Add(this.txtShifted);
            this.Controls.Add(this.txtCharOut);
            this.Controls.Add(this.txtScancode);
            this.Controls.Add(this.txtCharIn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtChar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewTscscan);
            this.Controls.Add(this.btn_ReadTscShift);
            this.Controls.Add(this.btn_readTscscan);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "tscscan 2017";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTscscan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShiftList)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_readTscscan;
        private System.Windows.Forms.DataGridView dataGridViewTscscan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChar;
        private System.Windows.Forms.TextBox txtScancode;
        private System.Windows.Forms.Button btn_ReadTscShift;
        private System.Windows.Forms.DataGridView dataGridViewShiftList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCharIn;
        private System.Windows.Forms.TextBox txtCharOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtShifted;
        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapKeysForRDMToolStripMenuItem;
    }
}

