using FlowTask_Backend;
using System;
using System.Windows.Forms;

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

        private void btnRegistration_Click(object sender, EventArgs e) => Mediator.ShowForm(this, Mediator.RegistrationForm);

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

            (User user, AuthorizationCookie? ac) = DatabaseController.dbController.GetUser(username, password);


            if (user == null || !ac.HasValue)
            {
                MessageBox.Show("Please check your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblPassword.ForeColor = System.Drawing.Color.Red;
                lblUsername.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Mediator.CurrentUser = user;

            Mediator.AuthCookie = ac.Value;

            Mediator.ShowForm(this, Mediator.MainForm);
        }

    }
}
