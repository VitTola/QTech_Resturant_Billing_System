
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

            Application.Run(new MainForm());
            //Application.Run(new LoginDialog());
            //Application.Run(new Form1());

            //ExWindow form = new ExWindow();
            //WindowInteropHelper wih = new WindowInteropHelper(this);
            //wih.Owner = form.Handle;
            ////form.ShowDialog();

        }
    }
}
