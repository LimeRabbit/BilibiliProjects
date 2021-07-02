using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliProjects.NovelTest
{
    public class Setting
    {
        /// <summary>
        /// 自动保存
        /// </summary>
        public static bool AutoSave;
        /// <summary>
        /// 保存时压缩，默认true
        /// </summary>
        public static bool IsCompress=true;
        /// <summary>
        /// 字形
        /// </summary>
        public static string FontFamily = "宋体";
        /// <summary>
        /// 字号
        /// </summary>
        public static float FontSize = 20;
        /// <summary>
        /// 字体，默认宋体、20号字
        /// </summary>
        public static Font Font
        {
            get
            {
                return new Font(FontFamily, FontSize);
            }
        }
    }
}
