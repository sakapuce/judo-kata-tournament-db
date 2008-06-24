using System;
using System.Data;
using System.Windows.Forms;

namespace JudoKataTournamentDB
{
    public partial class KatasUserControl : UserControl, IUserControl
    {
        
        public KatasUserControl()
        {
            InitializeComponent();
        }

        #region IUserControl Members

        public bool Save()
        {
            return true;
        }

        public string Title
        {
            get
            {
                return "Judo Katas";
            }
        }

        public bool Close()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsDirty()
        {
            return katasDataSet.HasChanges();
        }

        public void Activate()
        {
            katasDataSet.Clear();
            BindingData();
        }

        private void BindingData()
        {
            try
            {
                //katasTableAdapter.Fill(katasDataSet.Katas);
                //technicsTableAdapter.Fill(katasDataSet.Technics);
            }
            catch (ConstraintException)
            {
                MessageBox.Show("The DataSet cannot retrieve correctly data from the database. An exception while trying to enable constraint on keys has raised.","Cannot extract data from Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
