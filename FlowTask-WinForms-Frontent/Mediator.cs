using FlowTask_Backend;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontent
{
    public static class Mediator
    {
        public static User me;


        public static LoginForm login;
        public static RegistrationForm register;
        public static MainPage main;


        private static Form Caller;

        private static List<Form> subjects;

        public static void ShowForm(Form caller, Form subject)
        {
            if(subjects == null)
                subjects = new List<Form>();

            Caller = caller;
            caller.Hide();
            subject.Show();

            subjects.Add(subject);
        }

        public static void ShowCaller()
        {
            Caller.Show();

            foreach (var x in subjects)
                x.Hide();
        }


    }
}
