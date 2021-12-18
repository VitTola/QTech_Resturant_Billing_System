
using QTech.Base.Helpers;
using QTech.Component;
using QTech.Db;
using QTech.Forms;
using SaleInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using WpfCustomControlLibrary;

namespace QTech
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
            DataBaseSetting.ReadSetting();

            //Read the last theme of user
            var currentTheme = DataBaseSetting.config.Theme;
            ShareValue.CurrentTheme = currentTheme == QTech.Base.Enums.Theme.Template1 ?
                Theme.Template1 :
                (currentTheme == QTech.Base.Enums.Theme.Template2 ?
                Theme.Template2 : Theme.Template3);

            //Application.Run(new MainForm());
            Application.Run(new LoginDialog());

            
        }
    }
}
