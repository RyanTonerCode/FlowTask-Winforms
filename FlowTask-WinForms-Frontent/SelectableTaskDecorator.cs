using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowTask_Backend;

namespace FlowTask_WinForms_Frontent
{
    public class SelectableTaskDecorator : Task
    {
        public SelectableTaskDecorator(int taskID, string assignmentName, int graphID, string submissionDate, string category, int userID) : base(taskID, assignmentName, graphID, submissionDate, category, userID)
        {
        }

        public SelectableTaskDecorator(Task t) : base(t.TaskID, t.AssignmentName, t.GraphID, t.SubmissionDate, t.Category, t.UserID)
        {

        }

        public bool Selected { get; set; }
    }
}
