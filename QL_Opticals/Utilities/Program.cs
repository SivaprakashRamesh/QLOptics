using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Opticals.Utilities
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if ( Utilities.clsApplication.FunCheckLicense() == true)
            {
                Utilities.clsApplication.FunDefaultStyle();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Presentation.FrmMdi());
            }
        }
    }
}
