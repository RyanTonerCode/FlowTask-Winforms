using System;
using FlowTask_Backend;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontent
{
    public partial class TaskCreate : Form
    {
        public TaskCreate()
        {
            InitializeComponent();
            dtDate.Value = DateTime.Now;
            cbxCategory.SelectedIndex = 0;
        }

        private void btnEscape_Click(object sender, EventArgs e)
        {
            Mediator.ShowCaller();
        }

        private void btnCreateClick(object sender, EventArgs e)
        {
            string name = tbxName.Text;
            string cat = cbxCategory.SelectedItem.ToString();
            DateTime date = dtDate.Value;

            Task newTask = new Task(name, date, cat, Mediator.Me.UserId);

            (bool result, string error, int id) = DatabaseController.dbController.WriteTask(newTask, Mediator.ac);

            if (result == false)
            {
                MessageBox.Show(error, "Task creation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                MessageBox.Show(string.Format("Your task {0} has been created!", name), "Task creation succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

            newTask.TaskID = id;

            TaskCollection.ObservableTaskCollection.Add(new SelectableTaskDecorator(newTask));
        }
    }
}
