using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DALHelper;
using JudoKataTournamentDB.DataSets;

namespace JudoKataTournamentDB
{
    public partial class ListOfKatasForm : Form
    {
        private DataSetPersistor persistor;
        
        public ListOfKatasForm()
        {
            InitializeComponent();
            DataBind();
        }

        private void  DataBind()
        {
            persistor = new DataSetPersistor(katasDataSet);

            ConfigurePersistor();
             
            persistor.Fill();
        }

        private void ConfigurePersistor()
        {
            DataTableHelper katasHelper = new DataTableHelper(katasDataSet.Katas);
            DataTableHelper technicsHelper = new DataTableHelper(katasDataSet.Technics);
            
            List<DataTableHelper> sequenceForFill = new List<DataTableHelper>();
            sequenceForFill.Add(katasHelper);
            sequenceForFill.Add(technicsHelper);

            List<DataTableHelper> sequenceForUpdate = new List<DataTableHelper>();
            sequenceForUpdate.Add(katasHelper);
            sequenceForUpdate.Add(technicsHelper);

            List<DataTableHelper> sequenceForDelete = new List<DataTableHelper>();
            sequenceForDelete.Add(katasHelper);
            sequenceForDelete.Add(technicsHelper);

            persistor.SetSequenceForFill(sequenceForFill);
            persistor.SetSequenceForUpdate(sequenceForFill);
            persistor.SetSequenceForDelete(sequenceForDelete);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string kataName = InputBox.Show("Please insert the name of the new Kata to create", "Create new Kata");
            if (kataName != "")
            {
                KatasDataSet.KatasRow row = katasDataSet.Katas.NewKatasRow();
                row.Name = kataName;
                katasDataSet.Katas.Rows.Add(row);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(lbKatas.SelectedIndex>=0)
            {
                //int kataId = (int)lbKatas.SelectedValue;
                //TO DO: open an edit window to change the corresponding technics of the kata
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbKatas.SelectedIndex >= 0)
            {
                int kataId = (int)lbKatas.SelectedValue;
                katasDataSet.Katas.Select(string.Format("Id = {0}", kataId))[0].Delete();
            }
        }
    }
}