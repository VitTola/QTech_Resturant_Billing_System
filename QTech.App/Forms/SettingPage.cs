using QTech.Base.Helpers;
using QTech.Component;
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
    public partial class SettingPage : ExPage,IPage
    {
        public SettingPage()
        {
            InitializeComponent();
            this.SetTheme(this.Controls, null);
            this.Shown += SettingPage_Load;
        }

        public void AddNew()
        {
            
        }

        public void EditAsync()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public Task Search()
        {
            throw new NotImplementedException();
        }

        public void View()
        {
            throw new NotImplementedException();
        }

        private void SettingPage_Load(object sender, EventArgs e)
        {
            new frmSetting().ShowDialog();
        }
    }
}
