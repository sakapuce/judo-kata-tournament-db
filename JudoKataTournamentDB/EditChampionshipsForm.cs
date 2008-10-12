using System.Data;
using System.Windows.Forms;
using DALHelper;
using JudoKataTournamentDB.DataSets;

namespace JudoKataTournamentDB
{
    public partial class EditChampionshipsForm : Form
    {
        private DataSetPersistor _persistor;

        public EditChampionshipsForm()
        {
            InitializeComponent();
            DataBind();
        }

        private void DataBind()
        {
            _persistor = new DataSetPersistor(_championshipsDataSet);
            _persistor.Fill();
        }

        private void _btnNewChampionship_Click(object sender, System.EventArgs e)
        {
            string championshipName = InputBox.Show("Please insert the name of the new Championship", "Create new Championship");
            if (championshipName == "") return;
            ChampionshipsDataSet.ChampionshipsRow row = _championshipsDataSet.Championships.NewChampionshipsRow();
            row.Name = championshipName;
            _championshipsDataSet.Championships.Rows.Add(row);

            //Retrieve the corresponding CurrencyManager and position the current record to the last row
            CurrencyManager cm = _dvChampionships.BindingContext[_dvChampionships.DataSource, _dvChampionships.DataMember] as CurrencyManager;
            if (cm == null) return;

            cm.Position = _championshipsDataSet.Championships.Rows.Count - 1;
        }

        private void _btnNewDocument_Click(object sender, System.EventArgs e)
        {
            string documentTitle = InputBox.Show("Please insert the title of the new docuent", "Create new Document");
            if (documentTitle == string.Empty) return;
            ChampionshipsDataSet.DocumentsRow documentsRow = _championshipsDataSet.Documents.NewDocumentsRow();
            documentsRow.Title = documentTitle;

            //Get the current ChampionShip row, to retrieve the Championship Id
            ChampionshipsDataSet.ChampionshipsRow championshipsRow = ((DataRowView)_dvChampionships.BindingContext[_dvChampionships.DataSource, _dvChampionships.DataMember].Current).Row as ChampionshipsDataSet.ChampionshipsRow;
            if (championshipsRow == null) throw new ConstraintException("Can't retrieve the current Championship's Id while trying to add a new DocumentsRow");
            documentsRow.IdChampionship = championshipsRow.Id;

            _championshipsDataSet.Documents.Rows.Add(documentsRow);

            //Retrieve the corresponding CurrencyManager and position the current record to the last row
            CurrencyManager cm = _dvDocuments.BindingContext[_dvDocuments.DataSource, _dvDocuments.DataMember] as CurrencyManager;
            if (cm == null) return;

            cm.Position = _championshipsDataSet.Documents.Rows.Count - 1;
        }

        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ForceEndEdit();
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
                return IsDirty(_championshipsDataSet);
            }
        }

        //End the edition of any record
        private void ForceEndEdit()
        {
            _dvDocuments.BindingContext[_dvDocuments.DataSource, _dvDocuments.DataMember].EndCurrentEdit();
            _dvChampionships.BindingContext[_dvChampionships.DataSource, _dvChampionships.DataMember].EndCurrentEdit();
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

        private void EditChampionshipsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ForceEndEdit();
            if (!IsDataDirty) return; //if data has not changed, the form can continue to close

            switch (e.CloseReason)
            {
                //following cases are 'normal' closing... (asked by the user or by code)
                case CloseReason.ApplicationExitCall:
                case CloseReason.FormOwnerClosing:
                case CloseReason.UserClosing:
                    switch (MessageBox.Show(this, "Do you want to save the changes you made ?", "Close", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
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

        private void _btnDeleteChampionship_Click(object sender, System.EventArgs e)
        {
            ChampionshipsDataSet.ChampionshipsRow championshipsRow = ((DataRowView)_dvChampionships.BindingContext[_dvChampionships.DataSource, _dvChampionships.DataMember].Current).Row as ChampionshipsDataSet.ChampionshipsRow;
            if (championshipsRow != null) championshipsRow.Delete();
        }

        private void _btnDeleteDocuments_Click(object sender, System.EventArgs e)
        {
            ChampionshipsDataSet.DocumentsRow documentsRow = ((DataRowView) _dvDocuments.BindingContext[_dvDocuments.DataSource, _dvDocuments.DataMember].Current).Row as ChampionshipsDataSet.DocumentsRow;
            if(documentsRow != null) documentsRow.Delete();
        }
    }
}