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
    public partial class Pictures : Form
    {
        Bitmap image = new Bitmap("testPic\\pic002.png");
        DirectBitmap drawImg;
        public Pictures()
        {
            InitializeComponent();
            drawImg = new DirectBitmap(image.Width, image.Height);
            SetDefault();
            myPanel1.Width = image.Width / 2;
            myPanel1.Height = image.Height / 2;
            Width = image.Width / 2 + 50;
            Height = image.Height / 2 + 200;

            groupBox1.Left = button_mosaic.Right + 10;
            groupBox2.Left = button_mosaic.Right + 10;
            groupBox3.Left = button_mosaic.Right + 10;
            groupBox4.Left = button_mosaic.Right + 10;

            groupBox1.Top = button_mosaic.Top;
            groupBox2.Top = button_mosaic.Top;
            groupBox3.Top = button_mosaic.Top;
            groupBox4.Top = button_mosaic.Top;
        }

        /// <summary>
        /// 将图像设置为初始值(原图)
        /// </summary>
        private void SetDefault()
        {
            Graphics g = Graphics.FromImage(drawImg.Bitmap);
            g.DrawImage(image, new PointF(0, 0));
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

        private void button_pic_Click(object sender, EventArgs e)
        {
            //显示原图
            SetDefault();
            myPanel1.Invalidate();
        }

        private void button_bright_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            trackBar_bright_Scroll(null, null);
        }
        //亮度调节：颜色分量乘以系数
        private void trackBar_bright_Scroll(object sender, EventArgs e)
        {
            SetDefault();
            float value = trackBar_bright.Value / 10f;
            label_current_bright.Text = "当前亮度：" + value * 100 + "%";
            Color color;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = (int)(color.R * value);
                    g = (int)(color.G * value);
                    b = (int)(color.B * value);
                    if (r > 255) r = 255;
                    if (g > 255) g = 255;
                    if (b > 255) b = 255;
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }


        //反色，颜色值=255-颜色值
        private void button_reverse_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = 255-color.R;
                    g = 255-color.G;
                    b = 255-color.B;
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }

        private void Button_mosaic_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Show();
            groupBox3.Hide();
            groupBox4.Hide();
            trackBar_mosaic_Scroll(null, null);
        }

        //马赛克，取一个区域的颜色平均值
        private void trackBar_mosaic_Scroll(object sender, EventArgs e)
        {
            SetDefault();
            int value = trackBar_mosaic.Value;
            label_mosaic_size.Text = "方格大小：" + value;
            int i, j, m, n;
            for (i = 0; i < drawImg.Width; i+=value)
            {
                for (j = 0; j < drawImg.Height; j+=value)
                {
                    Color c;
                    int r, g, b;
                    int tr=0, tg=0, tb=0;
                    int count = 0;  //一共多少像素
                    //把一个区域的颜色值相加
                    for (m = 0; m < value; m++)
                    {
                        for (n = 0; n < value; n++)
                        {
                            if (i + m >= drawImg.Width || j + n >= drawImg.Height)
                                break;
                            c = drawImg.GetPixel(i + m, j + n);
                            tr += c.R;
                            tg += c.G;
                            tb += c.B;
                            count++;
                        }
                    }
                    //取颜色平均数
                    r = tr / count;
                    g = tg / count;
                    b = tb / count;
                    c = Color.FromArgb(r, g, b);
                    //把平均值赋值给这一块的所有像素
                    for (m = 0; m < value; m++)
                    {
                        for (n = 0; n < value; n++)
                        {
                            if (i + m >= drawImg.Width || j + n >= drawImg.Height)
                                break;
                            drawImg.SetPixel(i + m, j + n,c);
                        }
                    }
                }
            }
            myPanel1.Invalidate();
        }

        private void button_color_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Show();
            groupBox4.Hide();
            Lvjing_checked(null, null);
        }
        //滤镜
        private void Lvjing_checked(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if(rb==null)  //点击按钮时，这个参数是null
            {
                //把已经选中的radio赋值给rb
                foreach (Control control in groupBox3.Controls)
                {
                    if(((RadioButton)control).Checked)
                    {
                        rb = (RadioButton)control;
                        break;
                    }
                }
            }
            SetDefault();
            if (rb == radioButton_red) //红色滤镜
            {
                SetLvjing(1, 0, 0);
            }
            else if (rb == radioButton_green)  //绿色滤镜
            {
                SetLvjing(0, 1, 0);
            }
            else if (rb == radioButton_blue)  //蓝色滤镜
            {
                SetLvjing(0, 0, 1);
            }
            else if (rb == radioButton_yellow) //红+绿=黄
            {
                SetLvjing(1, 1, 0);
            }
            else if (rb == radioButton_purple) //红+蓝=紫
            {
                SetLvjing(1, 0, 1);
            }
            else if (rb == radioButton_cyan)  //绿+蓝=青
            {
                SetLvjing(0, 1, 1);
            }
        }

        /// <summary>
        /// 设置颜色分量值
        /// 如果传入的值是1，则颜色值不变；
        /// 如果传入的是0，则颜色值为0
        /// </summary>
        /// <param name="r1">1或0</param>
        /// <param name="g1">1或0</param>
        /// <param name="b1">1或0</param>
        private void SetLvjing(int r1,int g1,int b1)
        {
            Color color;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = (r1 == 0 ? 0 : color.R);
                    g = (g1 == 0 ? 0 : color.G);
                    b = (b1 == 0 ? 0 : color.B);
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Tools.SaveImage(drawImg.Bitmap);
        }
        //浮雕效果，与右下角的像素颜色值相减，再加上128
        private void button_relief_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color1,color2;
            int r, g, b;
            for (int i = 0; i < drawImg.Width-1; i++)
            {
                for (int j = 0; j < drawImg.Height-1; j++)
                {
                    color1 = drawImg.GetPixel(i, j);
                    color2 = drawImg.GetPixel(i+1, j+1);
                    r = Math.Abs(color1.R - color2.R + 128);
                    g = Math.Abs(color1.G - color2.G + 128);
                    b = Math.Abs(color1.B - color2.B + 128);
                    if (r > 255) r = 255;
                    else if (r < 0) r = 0;
                    if (g > 255) g = 255;
                    else if (g < 0) g = 0;
                    if (b > 255) b = 255;
                    else if (b < 0) b = 0;
                    drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }

        //将图像灰度化
        private void button_gray_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Show();
            Gray_power_changed(null, null);
        }
        //灰度，颜色分量乘以权重，再相加，作为新的颜色分量
        //三种分量的权重加起来应该等于1
        private void Gray_power_changed(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            float power_r = trackBar_power_r.Value / 10f;
            float power_g = trackBar_power_g.Value / 10f;
            float power_b = trackBar_power_b.Value / 10f;
            label_power_r.Text = "R：" + power_r;
            label_power_g.Text = "G：" + power_g;
            label_power_b.Text = "B：" + power_b;
            float r, g, b;
            int gray;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    r = color.R * power_r;
                    g = color.G * power_g;
                    b = color.B * power_b;
                    gray = (int)(r + g + b);
                    if (gray > 255) gray = 255;
                    drawImg.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            myPanel1.Invalidate();
        }
    }
}
