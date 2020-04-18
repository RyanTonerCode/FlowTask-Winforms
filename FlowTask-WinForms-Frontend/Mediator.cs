using FlowTask_Backend;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontent
{
    /// <summary>
    /// A mediator between all the forms in the application
    /// </summary>
    public static class Mediator
    {
        /// <summary>
        /// Close the application
        /// </summary>
        public static void Logout()
        {
            Application.Exit();
        }

        /// <summary>
        /// The currently logged-in user
        /// </summary>
        public static User CurrentUser;

        /// <summary>
        /// The authorization cookie associated with the user
        /// </summary>
        public static AuthorizationCookie AuthCookie;

        //private fields for all forms
        private static LoginForm loginForm;
        private static RegistrationForm registrationForm;
        private static MainForm mainForm;
        private static TaskCreationForm taskCreationForm;
        private static ViewTaskForm viewTaskForm;

        //properties to ensure the forms are alwyas available in blank template when needed
        public static LoginForm LoginForm { 
            get {
                return loginForm == null || loginForm.IsDisposed ? new LoginForm() : loginForm;
            }
            set => loginForm = value; 
        }
        public static RegistrationForm RegistrationForm
        {
            get
            {
                return registrationForm == null || registrationForm.IsDisposed ? new RegistrationForm() : registrationForm;
            }
            set => registrationForm = value;
        }
        public static MainForm MainForm
        {
            get
            {
                return mainForm == null || mainForm.IsDisposed ? new MainForm() : mainForm;
            }
            set => mainForm = value;
        }
        public static TaskCreationForm TaskCreationForm
        {
            get
            {
                return taskCreationForm == null || taskCreationForm.IsDisposed ? new TaskCreationForm(null) : taskCreationForm;
            }
            set => taskCreationForm = value;
        }
        public static ViewTaskForm ViewTaskForm
        {
            get
            {
                return viewTaskForm == null || viewTaskForm.IsDisposed ? new ViewTaskForm(null) : viewTaskForm;
            }
            set => viewTaskForm = value;
        }

        /// <summary>
        /// The form that asked to display the subject
        /// </summary>
        private static Form caller;
        private static Form subject;

        public static void ShowForm(Form Caller, Form Subject)
        {
            caller = Caller;
            subject = Subject;

            subject.Location = caller.Location;

            subject.Disposed += (object o, EventArgs e) => {
                if (!caller.IsDisposed)
                    caller.Show();
            };

            caller.Hide();
            subject.Show();
        }

        /// <summary>
        /// Shows the caller and hides the subject
        /// </summary>
        public static void ShowCaller()
        {
            subject.Hide();
            caller.Show();
        }

        /// <summary>
        /// Shows the task creation form with the given time
        /// </summary>
        /// <param name="defaultTime"></param>
        public static void ShowTaskCreation(DateTime? defaultTime)
        {
            if (taskCreationForm == null || taskCreationForm.IsDisposed)
                taskCreationForm = new TaskCreationForm(defaultTime);
            taskCreationForm.Show();
        }

        /// <summary>
        /// Shows the view task form with the given task
        /// </summary>
        /// <param name="defaultTask"></param>
        public static void ShowViewTask(Task defaultTask)
        {
            //always make a new form here
            viewTaskForm = new ViewTaskForm(defaultTask);
            viewTaskForm.Show();
        }

        /// <summary>
        /// Returns an s for plural numbers.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string IsPlural(int value)
        {
            if (value == 1)
                return "";
            return "s";
        }

    }
}
