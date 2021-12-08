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

namespace QTech
{

    public partial class Form1 : Form
    {
        DDFormsExtentions.DDFormFader FF;

        public Form1()
        {
            InitializeComponent();
            InitEvent();


            //pass the class constructor the handle to the form
            FF = new DDFormsExtentions.DDFormFader(Handle);

            //set the form to a Layered Window Form
            FF.setTransparentLayeredWindow();

            //sets the length of time between fade steps in Milliseconds 
            FF.seekSpeed = 20;

            // sets the amount of steps to take to reach target opacity    
            FF.StepsToFade = 5;

            FF.updateOpacity((byte)0, false); // set the forms opacity to 0;
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
            //FF.seekTo((byte)255);

            //System.Drawing.Color color=Color.Red;
            //System.Windows.Media.Color newColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private void elementHost2_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            MessageBox.Show("Click for testing.....");
        }

        private void elementHost2_ChildChanged_1(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void elementHost3_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FF.seekTo((byte)255);

        }
    }
}
