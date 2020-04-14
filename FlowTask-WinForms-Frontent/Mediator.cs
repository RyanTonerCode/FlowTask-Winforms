using FlowTask_Backend;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontent
{
    public static class Mediator
    {
        public static User Me;


        public static LoginForm login;
        public static RegistrationForm register;
        public static MainPage main;

        public static AuthorizationCookie ac;

        private static Form Caller;

        private static List<Form> subjects;

        public static void ShowForm(Form caller, Form subject)
        {
            if(subjects == null)
                subjects = new List<Form>();

            Caller = caller;

            subject.Location = caller.Location;

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
