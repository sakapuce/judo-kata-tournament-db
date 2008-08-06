using System;
using System.Windows.Forms;

namespace JudoKataTournamentDB
{

    public partial class MainForm : Form
    {

        private readonly UserControl currentUserControl;
        
        public MainForm()
        {
            InitializeComponent();
            currentUserControl = null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //User asks to quit the application
            if (currentUserControl != null)
            {
                ((IUserControl)currentUserControl).Close();
            }
            Close();
        }

        private void katasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //User asks to display the interface for the katas
            ListOfKatasForm listOfKatasForm = new ListOfKatasForm();
            listOfKatasForm.ShowDialog();
        }

        //private void LoadUserControl(UserControl uc)
        //{
        //    uc.Dock = DockStyle.Fill;
        //    Controls.Add(uc);
        //    uc.Visible = true;
        //    uc.BringToFront();
        //    uc.Focus();
        //}
    }
}