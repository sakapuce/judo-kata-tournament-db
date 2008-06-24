namespace JudoKataTournamentDB
{
    partial class KatasUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridView dgKatas;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.katasDataSet = new DALHelper.KatasDataSet();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Katas = new System.Windows.Forms.GroupBox();
            this.Technics = new System.Windows.Forms.GroupBox();
            this.dgTechnics = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kataIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scoreMaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgKatas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dgKatas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.katasDataSet)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Katas.SuspendLayout();
            this.Technics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTechnics)).BeginInit();
            this.SuspendLayout();
            // 
            // dgKatas
            // 
            dgKatas.AutoGenerateColumns = false;
            dgKatas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgKatas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgKatas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgKatas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            dgKatas.DataMember = "Katas";
            dgKatas.DataSource = this.katasDataSet;
            dgKatas.Dock = System.Windows.Forms.DockStyle.Fill;
            dgKatas.Location = new System.Drawing.Point(3, 16);
            dgKatas.Name = "dgKatas";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgKatas.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgKatas.Size = new System.Drawing.Size(885, 140);
            dgKatas.TabIndex = 3;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // katasDataSet
            // 
            this.katasDataSet.DataSetName = "KatasDataSet";
            this.katasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Katas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Technics);
            this.splitContainer1.Size = new System.Drawing.Size(891, 609);
            this.splitContainer1.SplitterDistance = 159;
            this.splitContainer1.TabIndex = 0;
            // 
            // Katas
            // 
            this.Katas.Controls.Add(dgKatas);
            this.Katas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Katas.Location = new System.Drawing.Point(0, 0);
            this.Katas.Name = "Katas";
            this.Katas.Size = new System.Drawing.Size(891, 159);
            this.Katas.TabIndex = 0;
            this.Katas.TabStop = false;
            this.Katas.Text = "groupBox1";
            // 
            // Technics
            // 
            this.Technics.Controls.Add(this.dgTechnics);
            this.Technics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Technics.Location = new System.Drawing.Point(0, 0);
            this.Technics.Name = "Technics";
            this.Technics.Size = new System.Drawing.Size(891, 446);
            this.Technics.TabIndex = 0;
            this.Technics.TabStop = false;
            this.Technics.Text = "groupBox2";
            // 
            // dgTechnics
            // 
            this.dgTechnics.AutoGenerateColumns = false;
            this.dgTechnics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTechnics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.kataIdDataGridViewTextBoxColumn,
            this.scoreMaxDataGridViewTextBoxColumn,
            this.positionDataGridViewTextBoxColumn});
            this.dgTechnics.DataMember = "Katas.FK_Technics_Katas";
            this.dgTechnics.DataSource = this.katasDataSet;
            this.dgTechnics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTechnics.Location = new System.Drawing.Point(3, 16);
            this.dgTechnics.Name = "dgTechnics";
            this.dgTechnics.Size = new System.Drawing.Size(885, 427);
            this.dgTechnics.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // kataIdDataGridViewTextBoxColumn
            // 
            this.kataIdDataGridViewTextBoxColumn.DataPropertyName = "KataId";
            this.kataIdDataGridViewTextBoxColumn.HeaderText = "KataId";
            this.kataIdDataGridViewTextBoxColumn.Name = "kataIdDataGridViewTextBoxColumn";
            // 
            // scoreMaxDataGridViewTextBoxColumn
            // 
            this.scoreMaxDataGridViewTextBoxColumn.DataPropertyName = "ScoreMax";
            this.scoreMaxDataGridViewTextBoxColumn.HeaderText = "ScoreMax";
            this.scoreMaxDataGridViewTextBoxColumn.Name = "scoreMaxDataGridViewTextBoxColumn";
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "Position";
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            // 
            // KatasUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "KatasUserControl";
            this.Size = new System.Drawing.Size(891, 609);
            ((System.ComponentModel.ISupportInitialize)(dgKatas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.katasDataSet)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.Katas.ResumeLayout(false);
            this.Technics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTechnics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DALHelper.KatasDataSet katasDataSet;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox Katas;
        private System.Windows.Forms.GroupBox Technics;
        private System.Windows.Forms.DataGridView dgTechnics;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn kataIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scoreMaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
    }
}
