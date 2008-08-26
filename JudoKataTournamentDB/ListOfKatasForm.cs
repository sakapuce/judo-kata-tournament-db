using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DALHelper;
using JudoKataTournamentDB.DataSets;

namespace JudoKataTournamentDB
{
    public partial class ListOfKatasForm : Form
    {
        private DataSetPersistor _persistor;

        public ListOfKatasForm()
        {
            InitializeComponent();
            DataBind();
            _dvTechnics.Sort(_dvTechnics.Columns["Position"], ListSortDirection.Ascending);
        }

        private void  DataBind()
        {
            _persistor = new DataSetPersistor(_katasDataSet);
            _persistor.Fill();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string kataName = InputBox.Show("Please insert the name of the new Kata to create", "Create new Kata");
            if (kataName != "")
            {
                KatasDataSet.KatasRow row = _katasDataSet.Katas.NewKatasRow();
                row.Name = kataName;
                _katasDataSet.Katas.Rows.Add(row);
                _lbKatas.SelectedIndex = _lbKatas.Items.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_lbKatas.SelectedIndex >= 0)
            {
                int kataId = (int)_lbKatas.SelectedValue;
                _katasDataSet.Katas.Select(string.Format("Id = {0}", kataId))[0].Delete();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsDataDirty) SaveChanges();
        }

        private void SaveChanges()
        {
            try
            {
                _persistor.Update();   
            }
            catch(Exception e)
            {
                Logger.Log(string.Format("An exception raised while trying to save changes to the database. {0}",e.Message),Logger.LogLevel.Error);
            }
        }

        public bool IsDataDirty
        {          
            get
            {
                return IsDirty(_katasDataSet);
            }
        }

        private void ListOfKatasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ForceEndEdit();
            if(!IsDataDirty) return; //if data has not changed, the form can continue to close

            switch(e.CloseReason)
            {
                //following cases are 'normal' closing... (asked by the user or by code)
                case CloseReason.ApplicationExitCall:
                case CloseReason.FormOwnerClosing:
                case CloseReason.UserClosing:
                    switch(MessageBox.Show(this,"Do you want to save the changes you made ?","Close",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2))
                    {
                         case System.Windows.Forms.DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                        case System.Windows.Forms.DialogResult.Yes:
                            SaveChanges();
                            break;
                        case System.Windows.Forms.DialogResult.No:
                            break;
                    }
                    break;

                //the following case are unexpected close, do not save changes and continue close.
                case CloseReason.WindowsShutDown:
                case CloseReason.MdiFormClosing:
                case CloseReason.None:
                    break;
            }
        }

        private void _btnNewTechnic_Click(object sender, EventArgs e)
        {
            //Retrieve the corresponding CurrencyManager and position the current record to the last row
            CurrencyManager cm = _dvTechnics.BindingContext[_dvTechnics.DataSource, _dvTechnics.DataMember] as CurrencyManager;
            if (cm == null) return;

            KatasDataSet.TechnicsRow newRow = _katasDataSet.Technics.NewTechnicsRow();
            newRow.KataId = (int)_lbKatas.SelectedValue;
            _katasDataSet.Technics.AddTechnicsRow(newRow);
            cm.Position = _katasDataSet.Technics.Rows.Count - 1;
            newRow.Position = cm.Position + 1;
        }

        private void ForceEndEdit()
        {
            _lbKatas.BindingContext[_lbKatas.DataSource].EndCurrentEdit();
            _dvTechnics.BindingContext[_dvTechnics.DataSource, _dvTechnics.DataMember].EndCurrentEdit();
        }

        private void _btnUp_Click(object sender, EventArgs e)
        {
            CurrencyManager cm = _dvTechnics.BindingContext[_dvTechnics.DataSource, _dvTechnics.DataMember] as CurrencyManager;
            if (cm == null) return;

            int currentPosition = cm.Position;

            //If the current position is the first row there is no need to move up the current row.
            if (currentPosition <= 0) return;

            //If we don't suspend the binding, all controls are still binded and as soon as we swap the Position 
            //of the current and next row, the values of the current row will overwrite the values linked with the next row.
            //To not lose the data corresponding to the next row, we need to suspend the databinding.
            cm.SuspendBinding();

            KatasDataSet.TechnicsRow currentRow = (KatasDataSet.TechnicsRow)((DataRowView)_dvTechnics.Rows[currentPosition].DataBoundItem).Row;
            KatasDataSet.TechnicsRow previousRow = (KatasDataSet.TechnicsRow)((DataRowView)_dvTechnics.Rows[currentPosition - 1].DataBoundItem).Row;

            /// SWAP positions
            int tmp = currentRow.Position;
            currentRow.Position = previousRow.Position;
            previousRow.Position = tmp;

            cm.ResumeBinding(); //see cm.SuspendBinding() for comments

            cm.Position = currentPosition - 1;

            _dvTechnics.CurrentCell = _dvTechnics.Rows[cm.Position].Cells[0];
            _dvTechnics.Rows[cm.Position].Selected = true;
        }

        private void _btnDown_Click(object sender, EventArgs e)
        {
            CurrencyManager cm = _dvTechnics.BindingContext[_dvTechnics.DataSource, _dvTechnics.DataMember] as CurrencyManager;
            
            if (cm == null) return;
            
            int currentPosition = cm.Position;
            
            //If the current position is the last row there is no need to move down the current row.
            if (currentPosition >= _dvTechnics.Rows.Count-1) return;

            //If we don't suspend the binding, all controls are still binded and as soon as we swap the Position 
            //of the current and next row, the values of the current row will overwrite the values linked with the next row.
            //To not lose the data corresponding to the next row, we need to suspend the databinding.
            cm.SuspendBinding();
            
            KatasDataSet.TechnicsRow currentRow = (KatasDataSet.TechnicsRow)((DataRowView)_dvTechnics.Rows[currentPosition].DataBoundItem).Row;
            KatasDataSet.TechnicsRow nextRow = (KatasDataSet.TechnicsRow)((DataRowView)_dvTechnics.Rows[currentPosition + 1].DataBoundItem).Row;

            /// SWAP positions
            int tmp = currentRow.Position;
            currentRow.Position = nextRow.Position;
            nextRow.Position = tmp;

            cm.ResumeBinding(); //see cm.SuspendBinding() for comments

            cm.Position = currentPosition + 1;

            _dvTechnics.CurrentCell = _dvTechnics.Rows[cm.Position].Cells[0];
            _dvTechnics.Rows[cm.Position].Selected = true;
        }

        private void _btnDeleteTechnic_Click(object sender, EventArgs e)
        {
            KatasDataSet.TechnicsRow row = (KatasDataSet.TechnicsRow)((DataRowView) _dvTechnics.BindingContext[_dvTechnics.DataSource, _dvTechnics.DataMember].Current).Row;
           
            foreach(DataGridViewRow aRow in _dvTechnics.Rows)
            {
                int pos = (Int32)aRow.Cells["Position"].Value;
                if (pos > row.Position) aRow.Cells["Position"].Value = pos - 1;
            }

           row.Delete();
        }

        private bool IsDirty(DataSet dataSet)
        {
            foreach (DataTable table in dataSet.Tables)
                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Deleted) return true;
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        if (!row[i, DataRowVersion.Original].Equals(row[i, DataRowVersion.Current]))
                            return true;
                    }
                }
            return false;
        }
    }
}