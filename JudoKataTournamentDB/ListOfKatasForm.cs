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
            }
        }

        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    if(_lbKatas.SelectedIndex>=0)
        //    {
        //        int kataId = (int)lbKatas.SelectedValue;
        //    }
        //}

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
            //Force the lost of focus beforer update the data
            ForceLostFocus();
            //Stop edition before update the datas
            EndBindingManagersEdition(this);
            if(_katasDataSet.HasChanges())
            {
                _persistor.Update();
            }
        }

        private void _btnNew_Click(object sender, EventArgs e)
        {
            KatasDataSet.TechnicsRow newRow = _katasDataSet.Technics.NewTechnicsRow();
            newRow.KataId = (int) _lbKatas.SelectedValue;
            _katasDataSet.Technics.AddTechnicsRow(newRow);
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
    }
}