using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontent
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {  
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm entry = new LoginForm();

            entry.Location = new System.Drawing.Point(100, 100);

            Mediator.login = entry;
            Mediator.register = new RegistrationForm();
            Mediator.main = new MainPage();

            Application.Run(entry);
        }
    }
}
