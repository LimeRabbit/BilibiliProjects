using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace BilibiliProjects
{
    public partial class Pictures3 : Form
    {
        Bitmap image = new Bitmap("testPic\\pic002.png");
        DirectBitmap drawImg;
        public Pictures3()
        {
            InitializeComponent(); 
            drawImg = new DirectBitmap(image.Width, image.Height);
            SetDefault();
            myPanel1.Width = image.Width / 2;
            myPanel1.Height = image.Height / 2;
            Width = image.Width / 2 + 50;
            Height = image.Height / 2 + 200;
        }
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

        private void button_save_Click(object sender, EventArgs e)
        {
            Tools.SaveImage(drawImg.Bitmap);
        }

        private void button_red_Click(object sender, EventArgs e)
        {
            SetDefault();
            Color color;
            int r, g, b;
            for (int i = 0; i < drawImg.Width; i++)
            {
                for (int j = 0; j < drawImg.Height; j++)
                {
                    color = drawImg.GetPixel(i, j);
                    float hue = color.GetHue();
                    float sat = color.GetSaturation();
                    float bri = color.GetBrightness();
                    //drawImg.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            myPanel1.Invalidate();
        }

        public Color HSB2RGB(double hue, double sat, double bri)
        {
            double r = 0;
            double g = 0;
            double b = 0;

            if (sat == 0)
            {
                r = g = b = bri;
            }
            else
            {
                // the color wheel consists of 6 sectors. Figure out which sector you're in.
                double sectorPos = hue / 60.0;
                int sectorNumber = (int)(Math.Floor(sectorPos));
                // get the fractional part of the sector
                double fractionalSector = sectorPos - sectorNumber;

                // calculate values for the three axes of the color. 
                double p = bri * (1.0 - sat);
                double q = bri * (1.0 - (sat * fractionalSector));
                double t = bri * (1.0 - (sat * (1 - fractionalSector)));

                // assign the fractional colors to r, g, and b based on the sector the angle is in.
                switch (sectorNumber)
                {
                    case 0:
                        r = bri;
                        g = t;
                        b = p;
                        break;
                    case 1:
                        r = q;
                        g = bri;
                        b = p;
                        break;
                    case 2:
                        r = p;
                        g = bri;
                        b = t;
                        break;
                    case 3:
                        r = p;
                        g = q;
                        b = bri;
                        break;
                    case 4:
                        r = t;
                        g = p;
                        b = bri;
                        break;
                    case 5:
                        r = bri;
                        g = p;
                        b = q;
                        break;
                }
            }
            int red = Convert.ToInt32(r * 255);
            int green = Convert.ToInt32(g * 255);
            int blue = Convert.ToInt32(b * 255);
            return Color.FromArgb(red, green, blue);
        }
    }
}
