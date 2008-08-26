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

            Logger.Log("Application Started", Logger.LogLevel.Info);
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            //TODO: invoke a method to check if the database connection is available
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