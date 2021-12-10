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
using WpfCustomControlLibrary;

namespace QTech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            for (int i = 1; i < 100; i++)
            {
                Table table = new Table()
                {
                    TableName = "តុលេខ " + i,
                    TableColor = Color.LightGreen,
                    Detail = "មិនទាន់មាន",
                    Width = 400,
                    Height = 300
                };
                table.TableClick += Table_TableClick;
                wpfFlowLayout1.AddChildren(table);
            }
        }

        private void Table_TableClick(object sender, EventArgs e)
        {

        }
    }
}