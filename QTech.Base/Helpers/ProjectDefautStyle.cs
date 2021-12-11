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
                    d.BackgroundColor =Color.FromArgb(203, 219, 247); 
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
            }
        }









    }
}
