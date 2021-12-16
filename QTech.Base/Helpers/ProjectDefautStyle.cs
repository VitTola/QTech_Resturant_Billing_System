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
                        BackColor = ShareValue.CurrentTheme.DataGridHeader,
                        ForeColor = ShareValue.CurrentTheme.DataGridHeaderForeColor

                    };
                    d.RowsDefaultCellStyle = new DataGridViewCellStyle()
                    {
                        BackColor = ShareValue.CurrentTheme.DataGridBackGround,
                        ForeColor = ShareValue.CurrentTheme.DataGridHeaderForeColor

                    };
                    d.DefaultCellStyle = new DataGridViewCellStyle()
                    {
                        SelectionBackColor = ShareValue.CurrentTheme.DataGridViewSelectionBackColor,
                        ForeColor = ShareValue.CurrentTheme.DataGridHeaderForeColor

                    };

                    d.Font = new Font("Khmer OS Battambang", 8);
                }
                if (c is Button b)
                {
                    b.BackColor = ShareValue.CurrentTheme.ButtonBackGround;
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderColor = Color.Gray;
                    b.FlatAppearance.BorderSize = 1;
                    //b.FlatAppearance.MouseOverBackColor = Color.FromArgb(152, 203, 255);
                    b.ForeColor = ShareValue.CurrentTheme.ButtonText;
                }
                if (c is Panel p)
                {
                    if (p.Name != "container")
                    {
                        p.BackColor = ShareValue.CurrentTheme.PanelColor;
                    }
                    if (p.Name == "digheader")
                    {
                        p.BackColor = ShareValue.CurrentTheme.FormTopBar;
                    }
                    else
                    {
                        SetTheme(form, p.Controls, null);
                    }

                }
                if (c is GRAPanel gp)
                {
                    if (gp.Name == "digheader")
                    {
                        gp.Colors.Clear();
                        gp.Colors.Add(new ColorWithAlpha()
                        {
                            Color =
                            ShareValue.CurrentTheme.FormTopBar,
                            Alpha = 255,
                            Parent = gp
                        });
                        gp.Colors.Add(new ColorWithAlpha()
                        {
                            Color =
                           ShareValue.CurrentTheme.FormTopBar,
                            Alpha = 255,
                            Parent = gp
                        });
                        gp.Colors.Add(new ColorWithAlpha()
                        {
                            Color =
                           ShareValue.CurrentTheme.FormTopBar,
                            Alpha = 255,
                            Parent = gp
                        });
                    }
                    form.BackColor = ShareValue.CurrentTheme.FormBackGround;
                }
                if (c is ComboBox cb)
                {
                    cb.FlatStyle = FlatStyle.Standard;
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
                if (c is LinkLabel lk)
                {
                    lk.ForeColor = ShareValue.CurrentTheme.LabelColor;
                }
                if (c is GroupBox gb)
                {
                    gb.BackColor = ShareValue.CurrentTheme.FormBackGround;
                    gb.ForeColor = ShareValue.CurrentTheme.LabelColor;
                    SetTheme(form, gb.Controls, null);
                }
                if (c is TriStateTreeView t)
                {
                    t.BackColor = ShareValue.CurrentTheme.FormBackGround;
                    t.ForeColor = ShareValue.CurrentTheme.LabelColor;
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
            DataGridViewSelectionBackColor = Color.FromArgb(37, 48, 62),
            ComboboxColor = Color.FromArgb(37, 48, 62),
            ComboboxForeColor = Color.WhiteSmoke,
            MainFormBackColor = Color.FromArgb(15, 31, 46),
            MainFormSecondMenuePanel = Color.FromArgb(14, 22, 33),
            MainFormFirstMenuePanel = Color.FromArgb(23, 33, 43),
            MainFormLabel = Color.WhiteSmoke
        };

        public static Element Template2 = new Element()
        {
            FormTopBar = Color.FromArgb(247, 188, 199),
            FormBackGround = Color.FromArgb(243, 233, 232),
            ButtonBackGround = Color.FromArgb(243, 233, 232),
            ButtonText = Color.Black,
            LabelColor = Color.Black,
            PanelColor = Color.FromArgb(247, 188, 199),
            TabControl = Color.FromArgb(243, 233, 232),
            TabPage = Color.FromArgb(243, 233, 232),
            DataGridHeader = Color.FromArgb(247, 188, 199),
            DataGridBackGround = Color.FromArgb(243, 233, 232),
            DataGridAlternateRowColor = Color.WhiteSmoke,
            DataGridHeaderForeColor = Color.Black,
            DataGridViewSelectionBackColor = Color.FromArgb(178, 173, 178),
            ComboboxColor = Color.FromArgb(37, 48, 62),
            ComboboxForeColor = Color.WhiteSmoke,
            MainFormBackColor = Color.FromArgb(15, 31, 46),
            MainFormSecondMenuePanel = Color.FromArgb(242, 186, 203),
            MainFormFirstMenuePanel = Color.FromArgb(247, 142, 167),
            MainFormLabel = Color.WhiteSmoke

        };

        public static Element Template3 = new Element()
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
            ComboboxColor = Color.FromArgb(37, 48, 62),
            ComboboxForeColor = Color.WhiteSmoke,
            MainFormBackColor = Color.FromArgb(15, 31, 46),
            MainFormSecondMenuePanel = Color.FromArgb(247, 180, 223),
            MainFormFirstMenuePanel = Color.FromArgb(23, 33, 43),
            MainFormLabel = Color.WhiteSmoke
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
        public Color DataGridViewSelectionBackColor { get; set; }
        public Color ComboboxColor { get; set; }
        public Color ComboboxForeColor { get; set; }


        //MAIN FORM COMPONENT
        public Color MainFormFirstMenuePanel { get; set; }
        public Color MainFormSecondMenuePanel { get; set; }
        public Color MainFormBackColor { get; set; }
        public Color MainFormLabel { get; set; }
    }



}
