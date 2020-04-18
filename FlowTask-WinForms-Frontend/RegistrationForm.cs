using FlowTask_Backend;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontend
{
    public partial class RegistrationForm : Form
    {

        public RegistrationForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            tbxPassword.TextChanged += tbxTextChanged;
            tbxConfirmPassword.TextChanged += tbxTextChanged;
        }

        /// <summary>
        /// Get the label associated with a given textbox
        /// </summary>
        /// <param name="textboxName"></param>
        /// <returns></returns>
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
            bool valid_inputs = true;

            //check to make sure all text boxes have input
            foreach (Control c in pnlRegister.Controls)
            {
                if (c is TextBox)
                {
                    if (string.IsNullOrEmpty(c.Text))
                    {
                        Label l = getAssociatedLabel(c.Name);
                        if (l != null)
                        {
                            //show red text if they do not
                            l.ForeColor = Color.Red;
                            valid_inputs = false;
                        }
                        else
                            l.ForeColor = Color.Black;
                    }
                }
            }

            if (!valid_inputs)
                return;

            //retrieve all form data
            string username = tbxUsername.Text;
            string email = tbxEmail.Text;
            string pass = tbxPassword.Text;
            string confirm = tbxConfirmPassword.Text;
            string firstName = tbxFirstName.Text;
            string lastName = tbxLastName.Text;

            if (!string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(confirm) && !pass.Equals(confirm))
                return;

            //All fields are validated

            User temp_user = new User(pass, username, firstName, lastName, email);

            //write the user to the database
            (bool Succeeded, string ErrorMessage) = DatabaseController.GetDBController().WriteUser(temp_user);
            if (!Succeeded)
            {
                MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Format("Hi {0}, your FlowTask account has been created!", username), ErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);

            Mediator.LoginForm.UpdateUsername(username);

            Mediator.ShowCaller();
        }

        /// <summary>
        /// return to the login form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEscape_Click(object sender, EventArgs e) => Mediator.ShowCaller();

        /// <summary>
        /// Reset the label text to black after user has figured out how to type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxTextChanged(object sender, EventArgs e)
        {
            getAssociatedLabel(((TextBox)sender).Name).ForeColor = Color.Black;
        }

        /// <summary>
        /// Confirm that the password confirmation is correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            string pass = tbxPassword.Text;
            string confirm = tbxConfirmPassword.Text;

            if (!string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(confirm))
            {
                if (!pass.Equals(confirm))
                    tbxConfirmPassword.BackColor = Color.Red;
                else
                    tbxConfirmPassword.BackColor = Color.White;
            }
        }
    }
}
