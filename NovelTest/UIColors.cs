using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace BilibiliProjects
{
    public class UIColors
    {
        public static void SetNightMode(bool EnableNightMode)
        {
            IsNightMode = EnableNightMode;
            if (EnableNightMode)  //夜间模式颜色
            {
                BackColor = Color.FromArgb(30, 30, 30);
                ForeColor = Color.FromArgb(220, 220, 220);
                LinkColor = Color.LightSkyBlue;
            }
            else
            {
                BackColor = SystemColors.Control;
                ForeColor = Color.Black;
                LinkColor = Color.Blue;
            }
        }

        public static void SetControlColors(Form f)
        {
            f.BackColor = BackColor;
            f.ForeColor = ForeColor;
            foreach (Control control in f.Controls)
            {
                if (control is Button) continue;//按钮有默认样式，不设置颜色
                if (IsExcept(control)) continue;
                if (control is LinkLabel label)  //链接颜色
                {
                    label.LinkColor = LinkColor;
                }
                control.BackColor = BackColor;
                control.ForeColor = ForeColor;
                foreach (Control control1 in control.Controls)
                {
                    if (IsExcept(control1)) continue;
                    control1.BackColor = BackColor;
                    control1.ForeColor = ForeColor;
                }
            }
        }

        /// <summary>
        /// 例外的控件不需要改变颜色
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private static bool IsExcept(Control control)
        {
            if (control.Name == "label_forecolor" || control.Name == "label_backcolor" || control.Name == "label_linkcolor")
                return true;
            return false;
        }


        public static void SetContextMenuColor(ContextMenuStrip menu)
        {
            for (int i = 0; i < menu.Items.Count; i++)
            {
                menu.Items[i].BackColor = BackColor;
                menu.Items[i].ForeColor = ForeColor;
            }
        }

        public static void SetMenuStripColor(MenuStrip strip)
        {
            //for (int i = 0; i < strip.Items.Count; i++)
            //{
            //    strip.Items[i].BackColor = BackColor;
            //    strip.Items[i].ForeColor = ForeColor;
            //}
        }

        public static bool IsNightMode = false;
        public static bool IsUserMode = false;  //用户自定义颜色
        public static Color BackColor = SystemColors.Control;
        public static Color ForeColor = Color.Black;
        public static Color LinkColor = Color.Blue;
    }
}
