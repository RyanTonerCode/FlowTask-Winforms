using FlowTask_Backend;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontent
{
    public partial class RegistrationForm : Form
    {

        public RegistrationForm()
        {
            InitializeComponent();

            tbxPassword.TextChanged += tbxTextChanged;
            tbxConfirmPassword.TextChanged += tbxTextChanged;
        }

        private Label getAssociatedLabel(string textboxName)
        {
            foreach (Control c in pnlRegister.Controls)
                if (c is Label)
                    if (c.Name.Contains("lbl") && c.Name.Substring(3).Equals(textboxName.Substring(3)))
                        return (Label)c;
            return null;
        }

        private void btnCreateClicked(object sender, EventArgs e)
        {
            bool valid = true;

            foreach (Control c in pnlRegister.Controls)
            {
                if (c is TextBox)
                {
                    if (string.IsNullOrEmpty(c.Text))
                    {
                        Label l = getAssociatedLabel(c.Name);
                        if(l != null)
                        {
                            l.ForeColor = Color.Red;
                            valid = false;
                        }
                        else
                            l.ForeColor = Color.Black;
                    }
                }
            }

            if (!valid)
                return;

            string username = tbxUsername.Text;
            string email = tbxEmail.Text;
            string pass = tbxPassword.Text;
            string confirm = tbxConfirmPassword.Text;
            string firstName = tbxFirstName.Text;
            string lastName = tbxLastName.Text;

            if (!string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(confirm) && !pass.Equals(confirm))
                    return;

            //if account create works, then show login

            User u = new User(username, firstName, lastName, email, pass);

           (bool b, string s) = DatabaseController.dbController.WriteUser(u);
            if (!b)
            {
                MessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Format("Hi {0}, your FlowTask account has been created!", username), s, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Mediator.ShowCaller();
        }

        private void btnEscape_Click(object sender, EventArgs e)
        {
            Mediator.ShowCaller();
        }

        private void tbxTextChanged(object sender, EventArgs e)
        {
            getAssociatedLabel(((TextBox)sender).Name).ForeColor = Color.Black;
        }

        private void tbxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            string pass = tbxPassword.Text;
            string confirm = tbxConfirmPassword.Text;

            if(!string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(confirm))
            {
                if (!pass.Equals(confirm))
                    tbxConfirmPassword.BackColor = Color.Red;
                else
                {
                    tbxConfirmPassword.BackColor = Color.White;
                }
            }
        }
    }
}
