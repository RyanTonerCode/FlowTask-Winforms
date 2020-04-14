using System;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontent
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnRegistration_Click(object sender, EventArgs e) => 
            Mediator.ShowForm(this, Mediator.register);

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text;
            if (string.IsNullOrEmpty(username))
            {
                
                MessageBox.Show("Username cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string password = tbxPassword.Text;
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            var user = FlowTask_Backend.DatabaseController.dbController.GetUser(username, password);

            /*
            if (user == null)
            {
                MessageBox.Show("Please check your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Mediator.me = user;

            Mediator.ShowForm(this, Mediator.main);*/
        }



    }
}
