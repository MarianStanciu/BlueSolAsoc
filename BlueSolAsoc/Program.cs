using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace BlueSolAsoc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var culture = CultureInfo.GetCultureInfo("en-US");



            CultureInfo.DefaultThreadCurrentCulture = culture;
            //CultureInfo.DefaultThreadCurrentCulture.DateTimeFormat = CultureInfo.GetCultureInfo("de-DE").DateTimeFormat;
            CultureInfo cultureclone = (CultureInfo)culture.Clone();
            cultureclone.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            CultureInfo.DefaultThreadCurrentCulture = cultureclone;

            CultureInfo.DefaultThreadCurrentUICulture = culture;

           

            // setat format data tip european

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
