using FlowTask_Backend;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontend
{
    public partial class TaskCreationForm : Form
    {
        public TaskCreationForm(DateTime? selectedDate)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            //default date value to two weeks from now if none is provided.
            dtDate.Value = selectedDate ?? DateTime.Now.AddDays(14);
            //default the seledcted index
            cbxCategory.SelectedIndex = 0;
        }

        private void btnCreateClick(object sender, EventArgs e)
        {
            //inpute validation
            bool invalid = false;
            string name = tbxName.Text;
            if (string.IsNullOrEmpty(name))
            {
                lblAssignmentName.ForeColor = Color.Red;
                invalid = true;
            }
            if (cbxCategory.SelectedIndex == -1)
            {
                lblCategory.ForeColor = Color.Red;
                invalid = true;
            }
            if (dtDate.Value == null)
            {
                lblDueDate.ForeColor = Color.Red;
                invalid = true;
            }

            if (invalid)
                return;

            string cat = cbxCategory.SelectedItem.ToString();
            DateTime date = dtDate.Value;

            Task newTask = new Task(name.Trim(), date, cat, Mediator.CurrentUser.UserID);

            //create the task in the database
            (bool result, string error, Task task_returned) = DatabaseController.GetDBController().WriteTask(newTask, Mediator.AuthCookie);

            if (result == false)
            {
                MessageBox.Show(error, "Task creation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show(string.Format("Your task {0} has been created!", name), "Task creation succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //add the task to the observable collection
                ObservableCollections.ObservableTaskCollection.Add(new SelectableTaskDecorator(task_returned));

                Hide();
            }
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            lblAssignmentName.ForeColor = Color.Black;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
