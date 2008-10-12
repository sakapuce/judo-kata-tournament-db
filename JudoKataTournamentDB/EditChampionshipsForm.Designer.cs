namespace JudoKataTournamentDB
{
    partial class EditChampionshipsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditChampionshipsForm));
            this._mnStrip = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._dvChampionships = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._championshipsDataSet = new JudoKataTournamentDB.DataSets.ChampionshipsDataSet();
            this._btnDeleteChampionship = new System.Windows.Forms.Button();
            this._btnNewChampionship = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._btnDeleteDocuments = new System.Windows.Forms.Button();
            this._btnNewDocument = new System.Windows.Forms.Button();
            this._dvDocuments = new System.Windows.Forms.DataGridView();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._rtbDocument = new System.Windows.Forms.RichTextBox();
            this._mnStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dvChampionships)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._championshipsDataSet)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dvDocuments)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mnStrip
            // 
            this._mnStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this._mnStrip.Location = new System.Drawing.Point(0, 0);
            this._mnStrip.Name = "_mnStrip";
            this._mnStrip.Size = new System.Drawing.Size(784, 24);
            this._mnStrip.TabIndex = 8;
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(784, 550);
            this.splitContainer1.SplitterDistance = 182;
            this.splitContainer1.TabIndex = 10;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(784, 182);
            this.splitContainer2.SplitterDistance = 237;
            this.splitContainer2.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._dvChampionships);
            this.groupBox1.Controls.Add(this._btnDeleteChampionship);
            this.groupBox1.Controls.Add(this._btnNewChampionship);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 182);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Championships";
            // 
            // _dvChampionships
            // 
            this._dvChampionships.AllowUserToAddRows = false;
            this._dvChampionships.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._dvChampionships.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dvChampionships.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dvChampionships.AutoGenerateColumns = false;
            this._dvChampionships.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dvChampionships.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dvChampionships.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this._dvChampionships.DataMember = "Championships";
            this._dvChampionships.DataSource = this._championshipsDataSet;
            this._dvChampionships.Location = new System.Drawing.Point(6, 15);
            this._dvChampionships.MaximumSize = new System.Drawing.Size(500, 500);
            this._dvChampionships.MultiSelect = false;
            this._dvChampionships.Name = "_dvChampionships";
            this._dvChampionships.ReadOnly = true;
            this._dvChampionships.RowHeadersVisible = false;
            this._dvChampionships.Size = new System.Drawing.Size(144, 161);
            this._dvChampionships.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _championshipsDataSet
            // 
            this._championshipsDataSet.DataSetName = "ChampionshipsDataSet";
            this._championshipsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // _btnDeleteChampionship
            // 
            this._btnDeleteChampionship.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDeleteChampionship.Image = global::JudoKataTournamentDB.Properties.Resources.edit_remove_16x16;
            this._btnDeleteChampionship.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnDeleteChampionship.Location = new System.Drawing.Point(156, 48);
            this._btnDeleteChampionship.Name = "_btnDeleteChampionship";
            this._btnDeleteChampionship.Size = new System.Drawing.Size(75, 23);
            this._btnDeleteChampionship.TabIndex = 2;
            this._btnDeleteChampionship.Text = "Delete";
            this._btnDeleteChampionship.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnDeleteChampionship.UseVisualStyleBackColor = true;
            this._btnDeleteChampionship.Click += new System.EventHandler(this._btnDeleteChampionship_Click);
            // 
            // _btnNewChampionship
            // 
            this._btnNewChampionship.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnNewChampionship.Image = global::JudoKataTournamentDB.Properties.Resources.edit_add_16x16;
            this._btnNewChampionship.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnNewChampionship.Location = new System.Drawing.Point(156, 19);
            this._btnNewChampionship.Name = "_btnNewChampionship";
            this._btnNewChampionship.Size = new System.Drawing.Size(75, 23);
            this._btnNewChampionship.TabIndex = 1;
            this._btnNewChampionship.Text = "New";
            this._btnNewChampionship.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnNewChampionship.UseVisualStyleBackColor = true;
            this._btnNewChampionship.Click += new System.EventHandler(this._btnNewChampionship_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer3.Size = new System.Drawing.Size(543, 182);
            this.splitContainer3.SplitterDistance = 79;
            this.splitContainer3.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dateTimePicker1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.dateTimePicker2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(543, 79);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dates";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this._championshipsDataSet, "Championships.StartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.dateTimePicker1.Location = new System.Drawing.Point(79, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Date:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this._championshipsDataSet, "Championships.EndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.dateTimePicker2.Location = new System.Drawing.Point(79, 51);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._btnDeleteDocuments);
            this.groupBox2.Controls.Add(this._btnNewDocument);
            this.groupBox2.Controls.Add(this._dvDocuments);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(543, 99);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Documents";
            // 
            // _btnDeleteDocuments
            // 
            this._btnDeleteDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDeleteDocuments.Image = global::JudoKataTournamentDB.Properties.Resources.edit_remove_16x16;
            this._btnDeleteDocuments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnDeleteDocuments.Location = new System.Drawing.Point(462, 44);
            this._btnDeleteDocuments.Name = "_btnDeleteDocuments";
            this._btnDeleteDocuments.Size = new System.Drawing.Size(75, 23);
            this._btnDeleteDocuments.TabIndex = 7;
            this._btnDeleteDocuments.Text = "Delete";
            this._btnDeleteDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnDeleteDocuments.UseVisualStyleBackColor = true;
            this._btnDeleteDocuments.Click += new System.EventHandler(this._btnDeleteDocuments_Click);
            // 
            // _btnNewDocument
            // 
            this._btnNewDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnNewDocument.Image = global::JudoKataTournamentDB.Properties.Resources.edit_add_16x16;
            this._btnNewDocument.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnNewDocument.Location = new System.Drawing.Point(462, 15);
            this._btnNewDocument.Name = "_btnNewDocument";
            this._btnNewDocument.Size = new System.Drawing.Size(75, 23);
            this._btnNewDocument.TabIndex = 6;
            this._btnNewDocument.Text = "New";
            this._btnNewDocument.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnNewDocument.UseVisualStyleBackColor = true;
            this._btnNewDocument.Click += new System.EventHandler(this._btnNewDocument_Click);
            // 
            // _dvDocuments
            // 
            this._dvDocuments.AllowUserToAddRows = false;
            this._dvDocuments.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._dvDocuments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this._dvDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dvDocuments.AutoGenerateColumns = false;
            this._dvDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dvDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dvDocuments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.titleDataGridViewTextBoxColumn});
            this._dvDocuments.DataMember = "Championships.Championships_Documents";
            this._dvDocuments.DataSource = this._championshipsDataSet;
            this._dvDocuments.Location = new System.Drawing.Point(6, 15);
            this._dvDocuments.MaximumSize = new System.Drawing.Size(500, 500);
            this._dvDocuments.MultiSelect = false;
            this._dvDocuments.Name = "_dvDocuments";
            this._dvDocuments.ReadOnly = true;
            this._dvDocuments.RowHeadersVisible = false;
            this._dvDocuments.Size = new System.Drawing.Size(428, 78);
            this._dvDocuments.TabIndex = 5;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._rtbDocument);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(784, 364);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Document Viewer";
            // 
            // _rtbDocument
            // 
            this._rtbDocument.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._championshipsDataSet, "Championships.Championships_Documents.Text", true));
            this._rtbDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtbDocument.Location = new System.Drawing.Point(3, 16);
            this._rtbDocument.Name = "_rtbDocument";
            this._rtbDocument.Size = new System.Drawing.Size(778, 345);
            this._rtbDocument.TabIndex = 8;
            this._rtbDocument.Text = "";
            this._rtbDocument.WordWrap = false;
            // 
            // EditChampionshipsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 574);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._mnStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(707, 610);
            this.Name = "EditChampionshipsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Championships";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditChampionshipsForm_FormClosing);
            this._mnStrip.ResumeLayout(false);
            this._mnStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dvChampionships)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._championshipsDataSet)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dvDocuments)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _mnStrip;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btnDeleteChampionship;
        private System.Windows.Forms.Button _btnNewChampionship;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView _dvChampionships;
        private System.Windows.Forms.Button _btnDeleteDocuments;
        private System.Windows.Forms.Button _btnNewDocument;
        private System.Windows.Forms.DataGridView _dvDocuments;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox _rtbDocument;
        private JudoKataTournamentDB.DataSets.ChampionshipsDataSet _championshipsDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}