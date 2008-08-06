using System;
using System.Collections;
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
            SaveChanges();
        }

        private void SaveChanges()
        {
            if (IsDataDirty)
            {
                //Force the lost of focus beforer update the data
                ForceLostFocus();
                //Stop edition before update the datas
                EndBindingManagersEdition(this);
                if (_katasDataSet.HasChanges())
                {
                    _persistor.Update();
                }
            }
        }

        public bool IsDataDirty
        {
            get
            {
                return _katasDataSet.HasChanges();
            }
        }

        private void ListOfKatasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private static void EndBindingManagersEdition(Control rootControl)
        {
            BindingManagerBase bindingManager;
            foreach (Control nodeControl in rootControl.Controls)
            {
                EndBindingManagersEdition(nodeControl);
                foreach (DictionaryEntry entry in nodeControl.BindingContext)
                {
                    WeakReference weakRef = (WeakReference)entry.Value;
                    if (weakRef.IsAlive)
                    {
                        bindingManager = (BindingManagerBase)weakRef.Target;
                        if (bindingManager.Position >= 0)
                            bindingManager.EndCurrentEdit();
                    }
                }
            }
        }

        private void ForceLostFocus()
        {
            Control currentControl = ActiveControl;
            _mnStrip.Focus();
            currentControl.Focus();
            
        }

        private void _btnUp_Click(object sender, EventArgs e)
        {

        }

        private void _btnDown_Click(object sender, EventArgs e)
        {

        }

        private void _btnDeleteTechnic_Click(object sender, EventArgs e)
        {

        }
    }
}