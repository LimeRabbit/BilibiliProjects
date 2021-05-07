using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilibiliProjects
{
    public class Tools
    {
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="bmp"></param>
        public static void SaveImage(Bitmap bmp)
        {
            if (bmp == null)
                return;

            SaveFileDialog save = new SaveFileDialog();  //保存文件对话框
            save.InitialDirectory = Directory.GetCurrentDirectory();  //初始目录
            save.Filter = "BMP图片|*.bmp";
            if (save.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(save.FileName, ImageFormat.Bmp);  //保存
                MessageBox.Show("保存完成", "提示");
            }
        }

        /// <summary>
        /// 获取所有字体
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFonts()
        {
            //获取字体
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            FontFamily[] fontFamilies = installedFontCollection.Families;
            List<string> fonts = new List<string>();
            //转为string数组
            foreach (FontFamily family in fontFamilies)
            {
                if (family.Name.StartsWith("Adobe")|| family.Name.StartsWith("Kozuka")|| family.Name.StartsWith("Bahn")|| family.Name.StartsWith("Franklin"))
                    continue;
                fonts.Add(family.Name);
            }
            return fonts;
        }
    }
}
