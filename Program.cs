using Course19DVLDProject.Applications.Driving_Licence_Services.New_Driving_Licence.Local_Driving_Licence;
using Course19DVLDProject.Applications.Manage_Applications.International_Driving_License_Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course19DVLDProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());

  
        }
    }
}
