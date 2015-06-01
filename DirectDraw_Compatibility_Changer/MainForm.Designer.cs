namespace DirectDraw_Colourfix
{
    partial class MainForm
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
            this.lstCurrentFixes = new System.Windows.Forms.ListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtKeyName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtFlags = new System.Windows.Forms.TextBox();
            this.btnSaveValues = new System.Windows.Forms.Button();
            this.btnLoadLastPlayed = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.grpEdit = new System.Windows.Forms.GroupBox();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpEdit.SuspendLayout();
            this.grpList.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCurrentFixes
            // 
            this.lstCurrentFixes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCurrentFixes.FormattingEnabled = true;
            this.lstCurrentFixes.ItemHeight = 20;
            this.lstCurrentFixes.Location = new System.Drawing.Point(4, 5);
            this.lstCurrentFixes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstCurrentFixes.Name = "lstCurrentFixes";
            this.lstCurrentFixes.Size = new System.Drawing.Size(388, 474);
            this.lstCurrentFixes.TabIndex = 0;
            this.lstCurrentFixes.SelectedIndexChanged += new System.EventHandler(this.lstCurrentFixes_SelectedIndexChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(254, 102);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(292, 26);
            this.txtName.TabIndex = 3;
            // 
            // txtKeyName
            // 
            this.txtKeyName.Location = new System.Drawing.Point(254, 62);
            this.txtKeyName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtKeyName.Name = "txtKeyName";
            this.txtKeyName.Size = new System.Drawing.Size(292, 26);
            this.txtKeyName.TabIndex = 4;
            // 
            // txtID
            // 
            this.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Location = new System.Drawing.Point(254, 137);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtID.MaxLength = 8;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(292, 26);
            this.txtID.TabIndex = 5;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // txtFlags
            // 
            this.txtFlags.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFlags.Location = new System.Drawing.Point(254, 177);
            this.txtFlags.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFlags.MaxLength = 8;
            this.txtFlags.Name = "txtFlags";
            this.txtFlags.Size = new System.Drawing.Size(292, 26);
            this.txtFlags.TabIndex = 6;
            this.txtFlags.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFlags_KeyPress);
            // 
            // btnSaveValues
            // 
            this.btnSaveValues.Location = new System.Drawing.Point(408, 217);
            this.btnSaveValues.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveValues.Name = "btnSaveValues";
            this.btnSaveValues.Size = new System.Drawing.Size(140, 37);
            this.btnSaveValues.TabIndex = 7;
            this.btnSaveValues.Text = "Save/Create";
            this.btnSaveValues.UseVisualStyleBackColor = true;
            this.btnSaveValues.Click += new System.EventHandler(this.btnSaveValues_Click);
            // 
            // btnLoadLastPlayed
            // 
            this.btnLoadLastPlayed.Location = new System.Drawing.Point(254, 217);
            this.btnLoadLastPlayed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoadLastPlayed.Name = "btnLoadLastPlayed";
            this.btnLoadLastPlayed.Size = new System.Drawing.Size(146, 37);
            this.btnLoadLastPlayed.TabIndex = 8;
            this.btnLoadLastPlayed.Text = "Load Last Played";
            this.btnLoadLastPlayed.UseVisualStyleBackColor = true;
            this.btnLoadLastPlayed.Click += new System.EventHandler(this.btnLoadLastPlayed_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Key Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Executable Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Executable ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 182);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "DirectDraw Flags:";
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(4, 489);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(388, 60);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete Selected Key";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(22, 217);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(122, 37);
            this.btnClearAll.TabIndex = 14;
            this.btnClearAll.Text = "Clear Inputs";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // grpEdit
            // 
            this.grpEdit.Controls.Add(this.btnClearAll);
            this.grpEdit.Controls.Add(this.label4);
            this.grpEdit.Controls.Add(this.label3);
            this.grpEdit.Controls.Add(this.label2);
            this.grpEdit.Controls.Add(this.label1);
            this.grpEdit.Controls.Add(this.btnLoadLastPlayed);
            this.grpEdit.Controls.Add(this.btnSaveValues);
            this.grpEdit.Controls.Add(this.txtFlags);
            this.grpEdit.Controls.Add(this.txtID);
            this.grpEdit.Controls.Add(this.txtKeyName);
            this.grpEdit.Controls.Add(this.txtName);
            this.grpEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEdit.Location = new System.Drawing.Point(4, 5);
            this.grpEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEdit.Size = new System.Drawing.Size(592, 583);
            this.grpEdit.TabIndex = 15;
            this.grpEdit.TabStop = false;
            this.grpEdit.Text = "Edit Key";
            // 
            // grpList
            // 
            this.grpList.Controls.Add(this.tableLayoutPanel2);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Location = new System.Drawing.Point(604, 5);
            this.grpList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpList.Name = "grpList";
            this.grpList.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpList.Size = new System.Drawing.Size(404, 583);
            this.grpList.TabIndex = 16;
            this.grpList.TabStop = false;
            this.grpList.Text = "Current Compatibility Keys";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lstCurrentFixes, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.43546F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.56454F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(396, 554);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grpEdit, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpList, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1012, 593);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 593);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "DirectDraw Compatibility Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpEdit.ResumeLayout(false);
            this.grpEdit.PerformLayout();
            this.grpList.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCurrentFixes;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtKeyName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtFlags;
        private System.Windows.Forms.Button btnSaveValues;
        private System.Windows.Forms.Button btnLoadLastPlayed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.GroupBox grpEdit;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

