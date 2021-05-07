using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilibiliProjects
{
    public partial class Pictures2 : Form
    {
        Bitmap image = new Bitmap("testPic\\pic002.png");
        DirectBitmap drawImg;
        public Pictures2()
        {
            InitializeComponent();
            drawImg = new DirectBitmap(image.Width, image.Height);
            SetDefault();
            myPanel1.Width = image.Width / 2;
            myPanel1.Height = image.Height / 2;
            Width = image.Width / 2 + 50;
            Height = image.Height / 2 + 200;
        }
        /// <summary>
        /// 将图像设置为初始值(原图)
        /// </summary>
        private void SetDefault()
        {
            Graphics g = Graphics.FromImage(drawImg.Bitmap);
            g.DrawImage(image, new PointF(0, 0));
        }

        private void button_pic_Click(object sender, EventArgs e)
        {
            SetDefault();
            myPanel1.Invalidate();
        }
        /// <summary>
        /// 把超过255或者小于0的值变为255和0
        /// </summary>
        private int SetValueToNormal(int a)
        {
            if (a > 255)
                a = 255;
            else if (a < 0)
                a = 0;
            return a;
        }

        private void myPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (drawImg == null) return;
            //把图片绘制到Panel，缩放0.5x
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.ScaleTransform(0.5f, 0.5f);
            g.DrawImage(drawImg.Bitmap, new PointF(0, 0));
            g.ResetTransform();
        }

        private void Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = label_color.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                label_color.BackColor = cd.Color;
            }
        }
        //变暗，取两个颜色中的较小值
        private void button_dark_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = Math.Min(color.R, color2.R);
                    g = Math.Min(color.G, color2.G);
                    b = Math.Min(color.B, color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        //变亮，和变暗相反，取颜色分量值大的
        private void button_lighter_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = Math.Max(color.R, color2.R);
                    g = Math.Max(color.G, color2.G);
                    b = Math.Max(color.B, color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }

        //正片叠底，两个颜色值相乘，再除以255
        private void button_zpdd_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = color.R * color2.R / 255;
                    g = color.G * color2.G / 255;
                    b = color.B * color2.B / 255;
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        //滤色，255-(255-混合色R)*(255-基色R)/255
        private void button_ls_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = GetLvse(color.R, color2.R);
                    g = GetLvse(color.G, color2.G);
                    b = GetLvse(color.B, color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        /// <summary>
        /// 滤色算法
        /// </summary>
        private int GetLvse(float a, float b)
        {
            float c = 255 - (255 - a) * (255 - b) / 255;
            return SetValueToNormal((int)c);
        }

        //颜色加深，基色是图片颜色，混合色是用户选择的颜色
        //基色-(255-混合色)*(255-基色)/混合色
        private void button_ysjs_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = GetDarker(color.R, color2.R);
                    g = GetDarker(color.G, color2.G);
                    b = GetDarker(color.B, color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        /// <summary>
        /// 颜色加深算法
        /// </summary>
        private int GetDarker(float a, float b)
        {
            float c = (255 - a) * (255 - b);
            if (b != 0)
                c /= b;
            c = a - c;
            return SetValueToNormal((int)c);
        }
        //颜色减淡，基色R+(基色R*混合色R)/(255-混合色R)
        private void button_ysjd_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = GetYsjd(color.R, color2.R);
                    g = GetYsjd(color.G, color2.G);
                    b = GetYsjd(color.B, color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        /// <summary>
        /// 颜色减淡算法
        /// </summary>
        private int GetYsjd(float a, float b)
        {
            float c = a;
            if (b != 255)
                c += (a * b) / (255 - b);
            else
                c += a * b;
            return SetValueToNormal((int)c);
        }

        //线性加深，两个颜色相加，再减去255
        private void button_xxjs_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = SetValueToNormal(color.R + color2.R - 255);
                    g = SetValueToNormal(color.G + color2.G - 255);
                    b = SetValueToNormal(color.B + color2.B - 255);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }

        //线性减淡，两个颜色值相加
        private void button_xxjd_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = SetValueToNormal(color.R + color2.R);
                    g = SetValueToNormal(color.G + color2.G);
                    b = SetValueToNormal(color.B + color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        //深色，把各自颜色的RGB加起来，取数字小的作为新颜色
        private void button_ss_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            int value2 = color2.R + color2.G + color2.B;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    int value1 = color.R + color.G + color.B;
                    if (value1 > value2)
                    {
                        r = color2.R;
                        g = color2.G;
                        b = color2.B;
                    }
                    else
                    {
                        r = color.R;
                        g = color.G;
                        b = color.B;
                    }
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        //浅色，把各自颜色的RGB加起来，取数字大的作为新颜色
        private void button_qs_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            int value2 = color2.R + color2.G + color2.B;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    int value1 = color.R + color.G + color.B;
                    if (value1 < value2)
                    {
                        r = color2.R;
                        g = color2.G;
                        b = color2.B;
                    }
                    else
                    {
                        r = color.R;
                        g = color.G;
                        b = color.B;
                    }
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        //叠加
        //基色<=128时，混合色R*基色R/128；
        //基色>128时，255-(255-混合色R)*(255-基色R)/128
        private void button_dj_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = GetDiejia(color.R, color2.R);
                    g = GetDiejia(color.G, color2.G);
                    b = GetDiejia(color.B, color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        /// <summary>
        /// 叠加算法
        /// </summary>
        private int GetDiejia(float a, float b)
        {
            float c;
            if (a <= 128)
                c = a * b / 128;
            else
                c = 255 - (255 - a) * (255 - b) / 128;
            return SetValueToNormal((int)c);
        }

        //点光
        private void button_dg_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = GetDianguang(color.R, color2.R);
                    g = GetDianguang(color.G, color2.G);
                    b = GetDianguang(color.B, color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        /// <summary>
        /// 点光算法
        /// 基色R<2*混合色R-255，则结果R=2*混合色R-255；
        /// 2*混合色R-255 < 基色R < 2*混合色R，则结果R=基色R；
        /// 基色R>2*混合色R，则结果R=2*混合色R。
        /// </summary>
        private int GetDianguang(int a, int b)
        {
            int c=a;
            if (a < 2 * b - 255)
                c = 2 * b - 255;
            else if (a > 2 * b)
                c = 2 * b;
            return SetValueToNormal(c);
        }
        //柔光
        private void button_rg_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = GetRouguang(color.R, color2.R);
                    g = GetRouguang(color.G, color2.G);
                    b = GetRouguang(color.B, color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        /// <summary>
        /// 柔光算法
        /// 当混合色R<=128，结果R=基色R+(2*混合色R-255)*(基色R-基色R*基色R/255)/255；
        /// 当混合色R>128，结果R=基色R+(2*混合色R-255)*(sqrt(基色R/255)*255-基色R)/255
        /// </summary>
        private int GetRouguang(float a, float b)
        {
            float c = a;
            if (b <= 128)
                c = a + (2 * b - 255) * (a - a * a / 255) / 255;
            else if (a > 2 * b)
                c = a + (2 * b - 255) * ((float)Math.Sqrt(a / 255) * 255 - a) / 255;
            return SetValueToNormal((int)c);
        }
        //强光
        private void button_qg_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = GetQiangguang(color.R, color2.R);
                    g = GetQiangguang(color.G, color2.G);
                    b = GetQiangguang(color.B, color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        /// <summary>
        /// 强光算法
        /// 当混合色<=128时，结果R=混合色R*基色R/128；
        /// 当混合色>128时，结果R=255-(255-混合色R)*(255-基色R)/128
        /// </summary>
        private int GetQiangguang(float a, float b)
        {
            float c = a;
            if (b <= 128)
                c = a * b / 128;
            else if (a > 2 * b)
                c = 255 - (255 - a) * (255 - b) / 128;
            return SetValueToNormal((int)c);
        }
        //亮光
        private void button_lg_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = GetLiangguang(color.R, color2.R);
                    g = GetLiangguang(color.G, color2.G);
                    b = GetLiangguang(color.B, color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        /// <summary>
        /// 亮光算法
        /// 当混合色R<=128，结果R=255-(255-基色R)/(2*混合色R)*255；
        /// 当混合色R>128，结果R=基色R/(2*(255-混合色R))*255。
        /// </summary>
        private int GetLiangguang(float a, float b)
        {
            float c = a;
            if (b <= 128)  //除数不能为零
                c = 255 - (255 - a) / (2 * (b == 0 ? 0.5f : b)) * 255;
            else if (a > 2 * b)
                c = a / (2 * (255 - (b == 0 ? 0.5f : b))) * 255;
            return SetValueToNormal((int)c);
        }
        //线性光
        private void button_xxg_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = GetXianxingguang(color.R, color2.R);
                    g = GetXianxingguang(color.G, color2.G);
                    b = GetXianxingguang(color.B, color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        /// <summary>
        /// 线性光算法
        /// 结果R=2*混合色R+基色R-255。如大于255，就取255。
        /// 当混合色R <= 127时，结果色R将线性变暗，否则将线性变亮
        /// </summary>
        private int GetXianxingguang(int a, int b)
        {
            int c = 2 * b + a - 255;
            return SetValueToNormal(c);
        }
        //实色混合
        private void button_sshh_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = GetSshh(color.R, color2.R);
                    g = GetSshh(color.G, color2.G);
                    b = GetSshh(color.B, color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        /// <summary>
        /// 实色混合算法
        /// 当混合色R+基色R<255，结果色R=0；否则结果色=255
        /// </summary>
        private int GetSshh(int a, int b)
        {
            int c;
            if (a + b < 255)
                c = 0;
            else
                c = 255;
            return c;
        }
        //差值，取两个颜色差的绝对值
        private void button_cz_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = Math.Abs(color.R - color2.R);
                    g = Math.Abs(color.G - color2.G);
                    b = Math.Abs(color.B - color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }

        //减去，与差值的区别是，这里没有绝对值
        private void button_jq_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = SetValueToNormal(color.R - color2.R);
                    g = SetValueToNormal(color.G - color2.G);
                    b = SetValueToNormal(color.B - color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        //排除
        private void button_pc_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = GetPaichu(color.R, color2.R);
                    g = GetPaichu(color.G, color2.G);
                    b = GetPaichu(color.B, color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        /// <summary>
        /// 排除算法
        /// 结果R=(混合色R+基色R)-混合色R*基色R/128
        /// </summary>
        private int GetPaichu(float a, float b)
        {
            float c = a + b - a * b / 128;
            return SetValueToNormal((int)c);
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Tools.SaveImage(drawImg.Bitmap);
        }
        //划分，
        private void button_hf_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            Color color2 = label_color.BackColor;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = GetHuafen(color.R, color2.R);
                    g = GetHuafen(color.G, color2.G);
                    b = GetHuafen(color.B, color2.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }
        /// <summary>
        /// 划分算法
        /// 两颜色值相除，再乘以255
        /// </summary>
        private int GetHuafen(float a, float b)
        {
            float c;
            if (b != 0)
                c = a / b * 255;
            else
                c = a * 255;
            return SetValueToNormal((int)c);
        }
    }
}
