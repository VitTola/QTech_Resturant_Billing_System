using QTech.Component;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Base.Helpers
{
    public static class ProjectDefautStyle
    {
        public static void QTechResturantDefaultStyle(this Form form, Control.ControlCollection controls = null)
        {
            if (controls == null)
            {
                return;
            }
            form.Font = new Font("Khmer OS Battambang", 8);
            foreach (Control c in controls)
            {
                if (c is DataGridView d)
                {
                    d.BackgroundColor = Color.FromArgb(15, 31, 46);
                    d.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.FromArgb(157, 185, 240),
                        SelectionBackColor = Color.LightSkyBlue
                    };
                    d.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
                    {
                        BackColor = Color.FromArgb(222, 222, 250)
                    };
                    d.RowsDefaultCellStyle = new DataGridViewCellStyle()
                    {
                        SelectionBackColor = Color.FromArgb(157, 185, 240)
                    };
                    d.Font = new Font("Khmer OS Battambang", 8);
                }
                if (c is Button b)
                {
                    b.BackColor = Color.DodgerBlue;
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderColor = Color.Gray;
                    b.FlatAppearance.BorderSize = 1;
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(152, 203, 255);
                    b.ForeColor = Color.White;
                }
                if (c is Panel p)
                {
                    if (p.Name != "container")
                    {
                        p.BackColor = Color.FromArgb(222, 222, 250);
                    }
                    if (p.Name != "digheader")
                    {
                        QTechResturantDefaultStyle(form, p.Controls);
                    }
                }
                if (c is ComboBox cb)
                {
                    cb.BackColor = Color.FromArgb(222, 222, 250);
                    cb.FlatStyle = FlatStyle.Popup;
                }
                if (c is TabControl tc)
                {
                    tc.BackColor = Color.FromArgb(203, 219, 247);
                    QTechResturantDefaultStyle(form, tc.Controls);
                }
                if (c is TabPage tp)
                {
                    tp.BackColor = Color.FromArgb(203, 219, 247);
                    QTechResturantDefaultStyle(form, tp.Controls);
                }
                if (c is Label l)
                {
                    l.ForeColor = Color.WhiteSmoke;
                }
            }
        }


        public static void SetTheme(this Form form,
            Control.ControlCollection controls = null,
            Control.ControlCollection Ignores = null)
        {
            if (controls == null)
            {
                return;
            }
            foreach (Control c in controls)
            {
                if (c is DataGridView d)
                {
                    form.Font = new Font("Khmer OS Battambang", 8);
                      
                    d.BackgroundColor = ShareValue.CurrentTheme.DataGridBackGround;
                    d.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = ShareValue.CurrentTheme.DataGridHeader,
                        ForeColor = ShareValue.CurrentTheme.DataGridHeaderForeColor
                    };
                    d.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
                    {
                        BackColor = ShareValue.CurrentTheme.DataGridAlternateRowColor
                    };
                    d.RowsDefaultCellStyle = new DataGridViewCellStyle()
                    {
                        SelectionBackColor = ShareValue.CurrentTheme.DataGridBackGround
                    };
                    d.Font = new Font("Khmer OS Battambang", 8);
                }
                if (c is Button b)
                {
                    b.BackColor = ShareValue.CurrentTheme.ButtonBackGround;
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderColor = Color.Gray;
                    b.FlatAppearance.BorderSize = 1;
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(152, 203, 255);
                    b.ForeColor = ShareValue.CurrentTheme.ButtonText;
                }
                if (c is Panel p)
                {
                    if (p.Name != "container")
                    {
                        p.BackColor = ShareValue.CurrentTheme.PanelColor;
                    }
                    if (p.Name != "digheader")
                    {
                        SetTheme(form, p.Controls, null);
                    }
                }
                if (c is ComboBox cb)
                {
                    cb.BackColor = ShareValue.CurrentTheme.ComboboxColor;
                    cb.ForeColor = ShareValue.CurrentTheme.ComboboxColor;
                    cb.FlatStyle = FlatStyle.Popup;
                }
                if (c is TabControl tc)
                {
                    tc.BackColor = ShareValue.CurrentTheme.TabControl;
                    SetTheme(form, tc.Controls, null);
                }
                if (c is TabPage tp)
                {
                    tp.BackColor = ShareValue.CurrentTheme.TabPage;
                    SetTheme(form, tp.Controls, null);

                }
                if (c is Label l)
                {
                    l.ForeColor = ShareValue.CurrentTheme.LabelColor;
                }
                if (c is CheckBox chk)
                {
                    chk.ForeColor = ShareValue.CurrentTheme.LabelColor;
                }
            }
        }






    }

    public class Theme
    {
        public static Element Template1 = new Element()
        {
            FormTopBar = Color.FromArgb(36, 47, 61),
            FormBackGround = Color.FromArgb(15, 31, 46),
            ButtonBackGround = Color.FromArgb(37, 48, 62),
            ButtonText = Color.WhiteSmoke,
            LabelColor = Color.WhiteSmoke,
            PanelColor = Color.FromArgb(15, 31, 46),
            TabControl = Color.FromArgb(23, 33, 43),
            TabPage = Color.FromArgb(23, 33, 43),
            DataGridHeader = Color.FromArgb(23, 33, 43),
            DataGridBackGround = Color.FromArgb(15, 31, 46),
            DataGridAlternateRowColor = Color.WhiteSmoke,
            DataGridHeaderForeColor = Color.WhiteSmoke,
            ComboboxColor = Color.FromArgb(23, 33, 43),
            ComboboxForeColor = Color.WhiteSmoke

        };

        public static Element Template2 = new Element()
        {
            FormTopBar = Color.FromArgb(36, 47, 61),
            FormBackGround = Color.FromArgb(15, 31, 46),
            ButtonBackGround = Color.FromArgb(37, 48, 62),
            ButtonText = Color.WhiteSmoke,
            LabelColor = Color.WhiteSmoke,
            PanelColor = Color.FromArgb(14, 22, 33),
            TabControl = Color.FromArgb(23, 33, 43),
            TabPage = Color.FromArgb(23, 33, 43),
            DataGridHeader = Color.FromArgb(23, 33, 43),
            DataGridBackGround = Color.FromArgb(15, 31, 46),
            DataGridAlternateRowColor = Color.WhiteSmoke,

        };

        public static Element Template3 = new Element()
        {
            FormTopBar = Color.FromArgb(36, 47, 61),
            FormBackGround = Color.FromArgb(15, 31, 46),
            ButtonBackGround = Color.FromArgb(37, 48, 62),
            ButtonText = Color.WhiteSmoke,
            LabelColor = Color.WhiteSmoke,
            PanelColor = Color.FromArgb(14, 22, 33),
            TabControl = Color.FromArgb(23, 33, 43),
            TabPage = Color.FromArgb(23, 33, 43),
            DataGridHeader = Color.FromArgb(23, 33, 43),
            DataGridBackGround = Color.FromArgb(15, 31, 46),
            DataGridAlternateRowColor = Color.WhiteSmoke,
        };

    }
    public class Element
    {
        public Color FormTopBar { get; set; }
        public Color FormBackGround { get; set; }
        public Color ButtonBackGround { get; set; }
        public Color ButtonText { get; set; }
        public Color LabelColor { get; set; }
        public Color PanelColor { get; set; }
        public Color TabControl { get; set; }
        public Color TabPage { get; set; }
        public Color DataGridHeader { get; set; }
        public Color DataGridHeaderForeColor { get; set; }
        public Color DataGridBackGround { get; set; }
        public Color DataGridAlternateRowColor { get; set; }
        public Color ComboboxColor { get; set; }
        public Color ComboboxForeColor { get; set; }
    }



}
