using System;
using FlowTask_Backend;
using System.Windows.Forms;
using System.Drawing;

namespace FlowTask_WinForms_Frontent
{
    public partial class TaskCreate : Form
    {
        public TaskCreate()
        {
            InitializeComponent();
            dtDate.Value = DateTime.Now.AddDays(14);
            cbxCategory.SelectedIndex = 0;
        }

        private void btnEscape_Click(object sender, EventArgs e)
        {
            Mediator.ShowCaller();
        }

        private void btnCreateClick(object sender, EventArgs e)
        {
            bool invalid = false;
            string name = tbxName.Text;
            if (string.IsNullOrEmpty(name))
            {
                lblAssignmentName.ForeColor = Color.Red;
                invalid = true;
            }
            if(cbxCategory.SelectedIndex == -1)
            {
                lblCategory.ForeColor = Color.Red;
                invalid = true;
            }
            if(dtDate.Value == null)
            {
                lblDueDate.ForeColor = Color.Red;
                invalid = true;
            }

            if (invalid)
                return;

            string cat = cbxCategory.SelectedItem.ToString();
            DateTime date = dtDate.Value;

            Task newTask = new Task(name, date, cat, Mediator.Me.UserId);

            (bool result, string error, Task task_returned) = DatabaseController.dbController.WriteTask(newTask, Mediator.ac);

            

            if (result == false)
            {
                MessageBox.Show(error, "Task creation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                MessageBox.Show(string.Format("Your task {0} has been created!", name), "Task creation succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TaskCollection.ObservableTaskCollection.Add(new SelectableTaskDecorator(task_returned));
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            lblAssignmentName.ForeColor = Color.Black;
        }
    }
}
