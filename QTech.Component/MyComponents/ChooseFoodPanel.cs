using EasyServer.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Component.MyComponents
{
    public partial class ChooseFoodPanel : UserControl
    {
        public ChooseFoodPanel()
        {
            InitializeComponent();
            InitEvent();
            InitializeFormTransparency();
        }

        private void InitEvent()
        {
            txtAmount.RegisterInputNumberOnly();
        }

        DDFormsExtentions.DDFormFader FF;
        private void InitializeFormTransparency()
        {
            //pass the class constructor the handle to the form
            FF = new DDFormsExtentions.DDFormFader(Handle);

            //set the form to a Layered Window Form
            FF.setTransparentLayeredWindow();

            //sets the length of time between fade steps in Milliseconds 
            FF.seekSpeed = 2;

            // sets the amount of steps to take to reach target opacity    
            FF.StepsToFade = 2;

            FF.updateOpacity((byte)0, false); // set the forms opacity to 0;

        }

        private int _quantity;
        private string _foodName;
        private bool _isHideImage;
        public bool HideImage
        {
            get { return _isHideImage; }
            set {
                FF.seekTo((byte)255);

                if (value)
                {
                    pic.Visibility = System.Windows.Visibility.Hidden;
                    this.Height = 100;
                }
                else
                {
                    pic.Visibility = System.Windows.Visibility.Visible;
                    this.Height = 260;
                }
                _isHideImage = value;
            } }
        public string ImagePath { set {
                pic.ImagePath = value;
            }}

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TextBoxBackColor { set {
                txtName.BackColor = txtAmount.BackColor = this.BackColor = value;
            } }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string FoodName { get { return _foodName; } set {
                    _foodName = value;
                    txtName.Text = value?.ToString();
                } }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int OrderQuantity { 
            get {

                if (int.TryParse(txtAmount.Text,out _quantity))
                {
                    return Parse.ToInt(txtAmount.Text);
                }
                return 0;
            } set {
                _quantity = value;
                txtAmount.Text = value.ToString();
            } }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            var _quantity = Parse.ToInt(txtAmount.Text);
            txtAmount.Text = (_quantity + 1).ToString();
            OrderQuantity = _quantity + 1;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            var _quantity = Parse.ToInt(txtAmount.Text);
            txtAmount.Text = _quantity > 0 ? (_quantity - 1).ToString() : 0.ToString(); ;
            OrderQuantity = Parse.ToInt(txtAmount.Text);
        }

    }
}
