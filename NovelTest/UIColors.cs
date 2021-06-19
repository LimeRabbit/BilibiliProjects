using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilibiliProjects
{
    public class UIColors
    {
        public static void SetNightMode(bool EnableNightMode)
        {
            IsNightMode = EnableNightMode;
            if (EnableNightMode)
            {
                BackColor = Color.FromArgb(30, 30, 30);
                ForeColor = Color.FromArgb(220, 220, 220);
            }
            else
            {
                BackColor = SystemColors.Control;
                ForeColor = Color.Black;
            }
        }

        public static void SetControlColors(Form f)
        {
            f.BackColor = BackColor;
            f.ForeColor = ForeColor;
            foreach (Control control in f.Controls)
            {
                if (control is Button) continue;
                control.BackColor = BackColor;
                control.ForeColor = ForeColor;
            }
        }


        public static bool IsNightMode = false;
        public static Color BackColor = SystemColors.Control;
        public static Color ForeColor = Color.Black;
    }
}
