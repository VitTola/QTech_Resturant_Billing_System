using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Forms
{
    public partial class ReloadMainForm : Form
    {
        MainForm MainForm = new MainForm();
        public ReloadMainForm(MainForm mainForm)
        {
            InitializeComponent();
            mainForm = MainForm;
            
        }

        private void ReloadMainForm_Load(object sender, EventArgs e)
        {
            MainForm.Close();
            this.Close();
            var mainForm = new MainForm();
            mainForm.isReload = false;
            mainForm.Show();
        }
    }
}
