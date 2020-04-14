using System;
using System.Windows.Forms;
using FlowTask_Backend;

namespace FlowTask_WinForms_Frontent
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            dgTasks.Font = new System.Drawing.Font("Arial", 13);
            lblWelcome.Text = "Welcome to FlowTask " + Mediator.Me.Username + "!";
            lblTasks.Text = string.Format("You have {0} task{1}!", Mediator.Me.Tasks.Count, (Mediator.Me.Tasks.Count > 1 ? "s" : ""));

            foreach(Task t in Mediator.Me.Tasks)
            {
                dgTasks.Rows.Add(t.AssignmentName, t.Category, t.SubmissionDate);
            }
        }
    }
}
