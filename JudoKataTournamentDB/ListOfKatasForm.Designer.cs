using JudoKataTournamentDB.DataSets;

namespace JudoKataTournamentDB
{
    partial class ListOfKatasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListOfKatasForm));
            this._lbKatas = new System.Windows.Forms.ListBox();
            this._katasDataSet = new JudoKataTournamentDB.DataSets.KatasDataSet();
            this._btnNewKata = new System.Windows.Forms.Button();
            this._btnDeleteKata = new System.Windows.Forms.Button();
            this.groupBoxKata = new System.Windows.Forms.GroupBox();
            this.groupBoxTechnics = new System.Windows.Forms.GroupBox();
            this._btnDeleteTechnic = new System.Windows.Forms.Button();
            this._btnNewTechnic = new System.Windows.Forms.Button();
            this._btnDown = new System.Windows.Forms.Button();
            this._btnUp = new System.Windows.Forms.Button();
            this._dvTechnics = new System.Windows.Forms.DataGridView();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxTechnicDetails = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this._richTextBoxNotes = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._textBoxId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._mnStrip = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this._katasDataSet)).BeginInit();
            this.groupBoxKata.SuspendLayout();
            this.groupBoxTechnics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dvTechnics)).BeginInit();
            this.groupBoxTechnicDetails.SuspendLayout();
            this._mnStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lbKatas
            // 
            this._lbKatas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._lbKatas.DataSource = this._katasDataSet;
            this._lbKatas.DisplayMember = "Katas.Name";
            this._lbKatas.FormattingEnabled = true;
            this._lbKatas.Location = new System.Drawing.Point(6, 19);
            this._lbKatas.Name = "_lbKatas";
            this._lbKatas.Size = new System.Drawing.Size(549, 121);
            this._lbKatas.TabIndex = 0;
            this._lbKatas.ValueMember = "Katas.Id";
            // 
            // _katasDataSet
            // 
            this._katasDataSet.DataSetName = "KatasDataSet";
            this._katasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // _btnNewKata
            // 
            this._btnNewKata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnNewKata.Image = global::JudoKataTournamentDB.Properties.Resources.edit_add_16x16;
            this._btnNewKata.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnNewKata.Location = new System.Drawing.Point(561, 19);
            this._btnNewKata.Name = "_btnNewKata";
            this._btnNewKata.Size = new System.Drawing.Size(75, 23);
            this._btnNewKata.TabIndex = 1;
            this._btnNewKata.Text = "New";
            this._btnNewKata.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnNewKata.UseVisualStyleBackColor = true;
            this._btnNewKata.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // _btnDeleteKata
            // 
            this._btnDeleteKata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDeleteKata.Image = global::JudoKataTournamentDB.Properties.Resources.edit_remove_16x16;
            this._btnDeleteKata.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnDeleteKata.Location = new System.Drawing.Point(561, 48);
            this._btnDeleteKata.Name = "_btnDeleteKata";
            this._btnDeleteKata.Size = new System.Drawing.Size(75, 23);
            this._btnDeleteKata.TabIndex = 3;
            this._btnDeleteKata.Text = "Delete";
            this._btnDeleteKata.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnDeleteKata.UseVisualStyleBackColor = true;
            this._btnDeleteKata.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBoxKata
            // 
            this.groupBoxKata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxKata.Controls.Add(this._lbKatas);
            this.groupBoxKata.Controls.Add(this._btnDeleteKata);
            this.groupBoxKata.Controls.Add(this._btnNewKata);
            this.groupBoxKata.Location = new System.Drawing.Point(12, 27);
            this.groupBoxKata.Name = "groupBoxKata";
            this.groupBoxKata.Size = new System.Drawing.Size(642, 158);
            this.groupBoxKata.TabIndex = 4;
            this.groupBoxKata.TabStop = false;
            this.groupBoxKata.Text = "Katas";
            // 
            // groupBoxTechnics
            // 
            this.groupBoxTechnics.Controls.Add(this._btnDeleteTechnic);
            this.groupBoxTechnics.Controls.Add(this._btnNewTechnic);
            this.groupBoxTechnics.Controls.Add(this._btnDown);
            this.groupBoxTechnics.Controls.Add(this._btnUp);
            this.groupBoxTechnics.Controls.Add(this._dvTechnics);
            this.groupBoxTechnics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTechnics.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTechnics.MinimumSize = new System.Drawing.Size(290, 0);
            this.groupBoxTechnics.Name = "groupBoxTechnics";
            this.groupBoxTechnics.Size = new System.Drawing.Size(290, 294);
            this.groupBoxTechnics.TabIndex = 5;
            this.groupBoxTechnics.TabStop = false;
            this.groupBoxTechnics.Text = "Technics";
            // 
            // _btnDeleteTechnic
            // 
            this._btnDeleteTechnic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDeleteTechnic.Image = global::JudoKataTournamentDB.Properties.Resources.edit_remove_16x16;
            this._btnDeleteTechnic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnDeleteTechnic.Location = new System.Drawing.Point(204, 103);
            this._btnDeleteTechnic.Name = "_btnDeleteTechnic";
            this._btnDeleteTechnic.Size = new System.Drawing.Size(75, 23);
            this._btnDeleteTechnic.TabIndex = 4;
            this._btnDeleteTechnic.Text = "Delete";
            this._btnDeleteTechnic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnDeleteTechnic.UseVisualStyleBackColor = true;
            this._btnDeleteTechnic.Click += new System.EventHandler(this._btnDeleteTechnic_Click);
            // 
            // _btnNewTechnic
            // 
            this._btnNewTechnic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnNewTechnic.Image = global::JudoKataTournamentDB.Properties.Resources.edit_add_16x16;
            this._btnNewTechnic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnNewTechnic.Location = new System.Drawing.Point(204, 75);
            this._btnNewTechnic.Name = "_btnNewTechnic";
            this._btnNewTechnic.Size = new System.Drawing.Size(75, 23);
            this._btnNewTechnic.TabIndex = 3;
            this._btnNewTechnic.Text = "New";
            this._btnNewTechnic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnNewTechnic.UseVisualStyleBackColor = true;
            this._btnNewTechnic.Click += new System.EventHandler(this._btnNewTechnic_Click);
            // 
            // _btnDown
            // 
            this._btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDown.Image = global::JudoKataTournamentDB.Properties.Resources.down_16x16;
            this._btnDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnDown.Location = new System.Drawing.Point(204, 46);
            this._btnDown.Name = "_btnDown";
            this._btnDown.Size = new System.Drawing.Size(75, 23);
            this._btnDown.TabIndex = 2;
            this._btnDown.Text = "Down";
            this._btnDown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnDown.UseVisualStyleBackColor = true;
            this._btnDown.Click += new System.EventHandler(this._btnDown_Click);
            // 
            // _btnUp
            // 
            this._btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnUp.Image = global::JudoKataTournamentDB.Properties.Resources.up_16x16;
            this._btnUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnUp.Location = new System.Drawing.Point(204, 18);
            this._btnUp.Name = "_btnUp";
            this._btnUp.Size = new System.Drawing.Size(75, 23);
            this._btnUp.TabIndex = 1;
            this._btnUp.Text = "Up";
            this._btnUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnUp.UseVisualStyleBackColor = true;
            this._btnUp.Click += new System.EventHandler(this._btnUp_Click);
            // 
            // _dvTechnics
            // 
            this._dvTechnics.AllowUserToAddRows = false;
            this._dvTechnics.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._dvTechnics.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dvTechnics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dvTechnics.AutoGenerateColumns = false;
            this._dvTechnics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dvTechnics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dvTechnics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Position,
            this.nameDataGridViewTextBoxColumn});
            this._dvTechnics.DataMember = "Katas.FK_Technics_Katas";
            this._dvTechnics.DataSource = this._katasDataSet;
            this._dvTechnics.Location = new System.Drawing.Point(6, 19);
            this._dvTechnics.MultiSelect = false;
            this._dvTechnics.Name = "_dvTechnics";
            this._dvTechnics.ReadOnly = true;
            this._dvTechnics.RowHeadersVisible = false;
            this._dvTechnics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dvTechnics.Size = new System.Drawing.Size(192, 267);
            this._dvTechnics.TabIndex = 0;
            // 
            // Position
            // 
            this.Position.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Position.DataPropertyName = "Position";
            this.Position.HeaderText = "Position";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            this.Position.Width = 69;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupBoxTechnicDetails
            // 
            this.groupBoxTechnicDetails.Controls.Add(this.label4);
            this.groupBoxTechnicDetails.Controls.Add(this._richTextBoxNotes);
            this.groupBoxTechnicDetails.Controls.Add(this.textBox2);
            this.groupBoxTechnicDetails.Controls.Add(this.label3);
            this.groupBoxTechnicDetails.Controls.Add(this.textBox1);
            this.groupBoxTechnicDetails.Controls.Add(this.label2);
            this.groupBoxTechnicDetails.Controls.Add(this._textBoxId);
            this.groupBoxTechnicDetails.Controls.Add(this.label1);
            this.groupBoxTechnicDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTechnicDetails.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTechnicDetails.MinimumSize = new System.Drawing.Size(253, 0);
            this.groupBoxTechnicDetails.Name = "groupBoxTechnicDetails";
            this.groupBoxTechnicDetails.Size = new System.Drawing.Size(348, 294);
            this.groupBoxTechnicDetails.TabIndex = 6;
            this.groupBoxTechnicDetails.TabStop = false;
            this.groupBoxTechnicDetails.Text = "Technic Details";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Notes";
            // 
            // _richTextBoxNotes
            // 
            this._richTextBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._richTextBoxNotes.DataBindings.Add(new System.Windows.Forms.Binding("Rtf", this._katasDataSet, "Katas.FK_Technics_Katas.Notes", true));
            this._richTextBoxNotes.Location = new System.Drawing.Point(6, 132);
            this._richTextBoxNotes.Name = "_richTextBoxNotes";
            this._richTextBoxNotes.Size = new System.Drawing.Size(336, 146);
            this._richTextBoxNotes.TabIndex = 6;
            this._richTextBoxNotes.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._katasDataSet, "Katas.FK_Technics_Katas.ScoreMax", true));
            this.textBox2.Location = new System.Drawing.Point(71, 83);
            this.textBox2.MaximumSize = new System.Drawing.Size(60, 20);
            this.textBox2.MinimumSize = new System.Drawing.Size(36, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(36, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Score Max";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._katasDataSet, "Katas.FK_Technics_Katas.Name", true));
            this.textBox1.Location = new System.Drawing.Point(97, 49);
            this.textBox1.MinimumSize = new System.Drawing.Size(103, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Technic\'s Name";
            // 
            // _textBoxId
            // 
            this._textBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._katasDataSet, "Katas.FK_Technics_Katas.Id", true));
            this._textBoxId.Enabled = false;
            this._textBoxId.Location = new System.Drawing.Point(29, 17);
            this._textBoxId.MaximumSize = new System.Drawing.Size(60, 20);
            this._textBoxId.MinimumSize = new System.Drawing.Size(46, 20);
            this._textBoxId.Name = "_textBoxId";
            this._textBoxId.ReadOnly = true;
            this._textBoxId.Size = new System.Drawing.Size(46, 20);
            this._textBoxId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id";
            // 
            // _mnStrip
            // 
            this._mnStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveToXMLToolStripMenuItem});
            this._mnStrip.Location = new System.Drawing.Point(0, 0);
            this._mnStrip.Name = "_mnStrip";
            this._mnStrip.Size = new System.Drawing.Size(668, 24);
            this._mnStrip.TabIndex = 7;
            this._mnStrip.Text = "Save";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.AutoToolTip = true;
            this.saveToolStripMenuItem.Image = global::JudoKataTournamentDB.Properties.Resources.filesave_16x16;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.ToolTipText = "Save changes";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveToXMLToolStripMenuItem
            // 
            this.saveToXMLToolStripMenuItem.Image = global::JudoKataTournamentDB.Properties.Resources.file_doc;
            this.saveToXMLToolStripMenuItem.Name = "saveToXMLToolStripMenuItem";
            this.saveToXMLToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.saveToXMLToolStripMenuItem.Text = "Save To XML";
            this.saveToXMLToolStripMenuItem.Click += new System.EventHandler(this.saveToXMLToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 191);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxTechnics);
            this.splitContainer1.Panel1MinSize = 290;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxTechnicDetails);
            this.splitContainer1.Size = new System.Drawing.Size(642, 294);
            this.splitContainer1.SplitterDistance = 290;
            this.splitContainer1.TabIndex = 8;
            // 
            // ListOfKatasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 497);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBoxKata);
            this.Controls.Add(this._mnStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._mnStrip;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "ListOfKatasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Katas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListOfKatasForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._katasDataSet)).EndInit();
            this.groupBoxKata.ResumeLayout(false);
            this.groupBoxTechnics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dvTechnics)).EndInit();
            this.groupBoxTechnicDetails.ResumeLayout(false);
            this.groupBoxTechnicDetails.PerformLayout();
            this._mnStrip.ResumeLayout(false);
            this._mnStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _lbKatas;
        private System.Windows.Forms.Button _btnNewKata;
        private System.Windows.Forms.Button _btnDeleteKata;
        private KatasDataSet _katasDataSet;
        private System.Windows.Forms.GroupBox groupBoxKata;
        private System.Windows.Forms.GroupBox groupBoxTechnics;
        private System.Windows.Forms.DataGridView _dvTechnics;
        private System.Windows.Forms.Button _btnUp;
        private System.Windows.Forms.Button _btnDown;
        private System.Windows.Forms.GroupBox groupBoxTechnicDetails;
        private System.Windows.Forms.TextBox _textBoxId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox _richTextBoxNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip _mnStrip;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button _btnNewTechnic;
        private System.Windows.Forms.Button _btnDeleteTechnic;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem saveToXMLToolStripMenuItem;
    }
}