using Syncfusion.Licensing;
using System;
using System.IO;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontent
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            SyncfusionLicenseProvider.RegisterLicense(DemoCommon.FindLicenseKey());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm entry_loginForm = new LoginForm();
            Mediator.LoginForm = entry_loginForm;
            Mediator.RegistrationForm = new RegistrationForm();
            Mediator.MainForm = new MainForm();

            Application.Run(entry_loginForm);
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
                return "MDAxQDMxMzgyZTMxMmUzMFZBc0pXbU9QVDMwbkFSUHlXMGs4RFVXZk43dERTYzZhK1E3N1dUQ05uR3M9";
                /*
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
                */
            }
        }

    }
}
