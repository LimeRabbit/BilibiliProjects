using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilibiliProjects
{
    //自定义Panel，提升绘制效率
    class MyPanel:Panel
    {
        public MyPanel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }
    }
}
