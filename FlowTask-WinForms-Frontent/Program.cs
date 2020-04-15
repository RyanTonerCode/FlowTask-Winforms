using Syncfusion.Licensing;
using System;
using System.Collections.Generic;
using System.IO;
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
            SyncfusionLicenseProvider.RegisterLicense(DemoCommon.FindLicenseKey());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm entry = new LoginForm();

            entry.Location = new System.Drawing.Point(100, 100);

            Mediator.login = entry;
            Mediator.register = new RegistrationForm();
            Mediator.main = new MainPage();
            Mediator.taskCreate = new TaskCreate();
            Mediator.viewTask = new ViewTask();

            Application.Run(entry);
        }

        /// <summary>
        /// Represents a class that is used to find the licensing file for Syncfusion controls.
        /// </summary>
        public class DemoCommon
        {

            /// <summary>
            /// Finds the license key from the Common folder.
            /// </summary>
            /// <returns>Returns the license key.</returns>
            public static string FindLicenseKey()
            {
                string licenseKeyFile = @"C:\Users\Public\Documents\Syncfusion\Windows\18.1.0.42\Common\SyncfusionLicense.txt";
                for (int n = 0; n < 20; n++)
                {
                    if (!File.Exists(licenseKeyFile))
                    {
                        licenseKeyFile = @"..\" + licenseKeyFile;
                        continue;
                    }
                    return File.ReadAllText(licenseKeyFile);
                }
                return string.Empty;
            }
        }

    }
}
