using System;
using System.Windows.Forms;
using FlowTask_Backend;

namespace FlowTask_WinForms_Frontent
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            tbxUsername.Text = "Default User";
            tbxPassword.Text = "password";
        }

        private void btnRegistration_Click(object sender, EventArgs e) => 
            Mediator.ShowForm(this, Mediator.register);

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text;
            if (string.IsNullOrEmpty(username))
            {
                lblUsername.ForeColor = System.Drawing.Color.Magenta;
                MessageBox.Show("Username cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string password = tbxPassword.Text;
            if (string.IsNullOrEmpty(password))
            {
                lblPassword.ForeColor = System.Drawing.Color.Magenta;
                MessageBox.Show("Password cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = DatabaseController.dbController.GetUser(username, password);

            
            if (user.user == null)
            {
                MessageBox.Show("Please check your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblPassword.ForeColor = System.Drawing.Color.Red;
                lblUsername.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Mediator.Me = user.user;
            Mediator.ac = user.ac;

            Mediator.ShowForm(this, Mediator.main);
        }

    }
}
