using StartupHelper;
using System;
using System.Windows.Forms;

namespace KeysHelper
{
    internal static class Program
    {
        private static string startupName = Application.ProductName
#if DEBUG
            + "_DEBUG"
#endif
        ;

        public static StartupManager StartupController = new StartupManager(startupName, RegistrationScope.Local);


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Interceptor.Start();
            try
            {
                Application.Run(new Form1());
            }
            finally
            {
                Interceptor.Stop();
            }
        }
    }
}
