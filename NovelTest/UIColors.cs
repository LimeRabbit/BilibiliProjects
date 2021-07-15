using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using static System.Windows.Forms.Control;

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

        /// <summary>
        /// 把某个窗体的所有控件更改颜色
        /// </summary>
        /// <param name="f"></param>
        public static void SetControlColors(Form f)
        {
            f.BackColor = BackColor;
            f.ForeColor = ForeColor;
            SetViewColor(f.Controls);
        }
        //递归设置控件颜色
        static void SetViewColor(ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button) continue;//按钮有默认样式，不设置颜色
                if (IsExcept(control)) continue;//有些控件不需要改颜色
                if (control is LinkLabel label)  //链接颜色
                {
                    label.LinkColor = LinkColor;
                }
                control.BackColor = BackColor;
                control.ForeColor = ForeColor;
                SetViewColor(control.Controls);
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
