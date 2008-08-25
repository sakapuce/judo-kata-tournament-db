using System;
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
            _persistor.Update();
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
            KatasDataSet.TechnicsRow newRow = _katasDataSet.Technics.NewTechnicsRow();
            newRow.KataId = (int) _lbKatas.SelectedValue;
            _katasDataSet.Technics.AddTechnicsRow(newRow);

            //Retrieve the corresponding CurrencyManager and position the current record to the last row
            CurrencyManager cm = _dvTechnics.BindingContext[_dvTechnics.DataSource, _dvTechnics.DataMember] as CurrencyManager;
            if(cm!=null) cm.Position = _katasDataSet.Technics.Rows.Count - 1;
        }

        private void ForceEndEdit()
        {
            _lbKatas.BindingContext[_lbKatas.DataSource].EndCurrentEdit();
            _dvTechnics.BindingContext[_dvTechnics.DataSource, _dvTechnics.DataMember].EndCurrentEdit();
        }

        private void _btnUp_Click(object sender, EventArgs e)
        {

        }

        private void _btnDown_Click(object sender, EventArgs e)
        {

            CurrencyManager cm = _dvTechnics.BindingContext[_dvTechnics.DataSource, _dvTechnics.DataMember] as CurrencyManager;
            if (cm == null) return;
            
            int currentPosition = cm.Position;
            
            //If the current position is the last row there is no need to move down the current row.
            if (currentPosition >= _dvTechnics.Rows.Count) return;


            KatasDataSet.TechnicsRow currentRow = ((DataRowView)_dvTechnics.Rows[currentPosition].DataBoundItem).Row as KatasDataSet.TechnicsRow;
            KatasDataSet.TechnicsRow nextRow = ((DataRowView)_dvTechnics.Rows[currentPosition+1].DataBoundItem).Row as KatasDataSet.TechnicsRow;
            

            
            //KatasDataSet.TechnicsRow currentRow = ((DataRowView)_dvTechnics.BindingContext[_dvTechnics.DataSource, _dvTechnics.DataMember].Current).Row as KatasDataSet.TechnicsRow;
            //int currentPosition = _dvTechnics.BindingContext[_dvTechnics.DataSource, _dvTechnics.DataMember].Position;
            //currentRow = (KatasDataSet.TechnicsRow) _dvTechnics.Rows[currentPosition];

            //// we'll just swap the order of the finding pointed to by the selected row and the previous one
            //DataView dv = (DataView)_recommendationCurrencyManager.List;
            //dv.Sort = string.Empty;
            //int currentPosition = _recommendationCurrencyManager.Position;
            //VisitWorkingSet.RecommendationsRow currentRow = (VisitWorkingSet.RecommendationsRow)dv[currentPosition].Row;
            //VisitWorkingSet.RecommendationsRow previousRow = (VisitWorkingSet.RecommendationsRow)dv[currentPosition - 1].Row;
            //int temp = previousRow.Order;
            //previousRow.Order = currentRow.Order;
            //currentRow.Order = temp;

            //// move selection along with row
            //_dgdRecommendations.UnSelect(currentPosition);
            //_dgdRecommendations.Select(currentPosition - 1);
            //_recommendationCurrencyManager.Position = currentPosition - 1;

            //dv.Sort = "Order";
        }

        private void _btnDeleteTechnic_Click(object sender, EventArgs e)
        {
            KatasDataSet.TechnicsRow row = ((DataRowView) _dvTechnics.BindingContext[_dvTechnics.DataSource, _dvTechnics.DataMember].Current).Row as KatasDataSet.TechnicsRow;
            if(row != null) row.Delete();
        }

        private bool IsDirty(DataSet dataSet)
        {
            foreach(DataTable table in dataSet.Tables)
                foreach(DataRow row in table.Rows)
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