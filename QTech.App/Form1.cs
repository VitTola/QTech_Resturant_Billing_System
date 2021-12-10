using QTech.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using WpfCustomControlLibrary;

namespace QTech
{

    public partial class Form1 : Form
    {
        DDFormsExtentions.DDFormFader FF;

        public Form1()
        {
            InitializeComponent();
            InitEvent();


        }
        private void InitEvent()
        {
            this.SizeChanged += Form1_Resize;
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //SetOpacity();
            //FF.seekTo((byte)255);

        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }





            //System.Drawing.Color color=Color.Red;
            //System.Windows.Media.Color newColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        

    }
}
