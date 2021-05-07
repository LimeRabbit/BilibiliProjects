using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace BilibiliProjects
{
    /// <summary>
    /// 用C#绘制验证码
    /// </summary>
    public partial class DrawVertifyCode : Form
    {
        Color color_string;  //绘制验证码字母的颜色
        Bitmap bitmap;  //验证码图片
        readonly int pic_width = 300;  //验证码图片宽
        readonly int pic_height = 60;  //验证码图片高
        Font font;  //绘制验证码的字体
        string[] fontFamily;
        readonly Random random;  //随机数，用于生成验证码、颜色、位置等
        string code;  //验证码
        int codeLength = 4;  //验证码长度
        public DrawVertifyCode()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(30, 30, 30);
            random = new Random(new Guid().GetHashCode());
            fontFamily = new string[] { "黑体", "楷体", "宋体", "仿宋" };
            font = new Font(fontFamily[0], 30);
            DrawImage();
        }

        /// <summary>
        /// 生成四位验证码
        /// </summary>
        /// <returns>验证码</returns>
        private string GetRandomCode()
        {
            string tmpCode = "";  //随机验证码
            codeLength = (int)numericUpDown1.Value;  //验证码长度
            //codeLength = random.Next(4, 8);
            for (int i = 0; i < codeLength; i++)
            {
                int tmp = random.Next('A', 'Z' + 1);  //A-Z 之间的字符
                tmpCode += (char)tmp;
            }
            return tmpCode;
        }

        /// <summary>
        /// 生成随机颜色
        /// </summary>
        /// <returns></returns>
        private Color GetRandomColor()
        {
            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);
            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// 画图
        /// </summary>
        private void DrawImage()
        {
            //随机类型验证码，演示用
            //int r = random.Next(3);
            //switch(r)
            //{
            //    case 0:
            //        code = GetRandomCodeKo();
            //        break;
            //    case 1:
            //        code = GetRandomCode();
            //        break;
            //    case 2:
            //        code = GetRandomCodeJp();
            //        break;
            //}
            code = GetRandomCodeKo();  //取得随机验证码
            bitmap = new Bitmap(pic_width, pic_height);  //新建对象
            Graphics graphics = Graphics.FromImage(bitmap);  //创建画笔
            graphics.SmoothingMode = SmoothingMode.HighQuality;//抗锯齿
            graphics.FillRectangle(Brushes.White, new RectangleF(0, 0, pic_width, pic_height)); //背景色白色
            for (int i = 0; i < code.Length; i++)
            {
                //X坐标取值范围
                int minX = pic_width / codeLength * i;
                int maxX = pic_width / codeLength * (i + 1);
                int x = random.Next(minX, maxX - 40);  //随机x坐标，不能让字母超出右侧太多
                int y = random.Next(0, pic_height - 40);  //随机Y坐标，不能让字母超出底部太多

                //随机颜色
                color_string = GetRandomColor();

                //随机旋转角度(±45度)
                Matrix matrix = graphics.Transform; //得到矩阵
                matrix.RotateAt(random.Next(-45, 45), new PointF(x, y));  //随机旋转
                graphics.Transform = matrix;  //随机旋转角度

                //随机字体和大小
                int fontSize = random.Next(15, 30);
                int familyIndex = random.Next(0, fontFamily.Length);
                font = new Font(fontFamily[familyIndex], fontSize);
                Console.WriteLine(fontFamily[familyIndex] + "," + fontSize);

                //绘制字母
                graphics.DrawString(code[i].ToString(), font, new SolidBrush(color_string), new Point(x, y));
                graphics.ResetTransform();  //矩阵复原
            }

            int bezierCount = (int)numericUpDown2.Value;
            //画 N 条贝塞尔曲线(干扰线)
            for (int i = 0; i < bezierCount; i++)
            {
                color_string = GetRandomColor();
                Point p1 = new Point(0, random.Next(0, pic_height));  //曲线起始点
                Point p2 = new Point(pic_width / 3, random.Next(-10, pic_height + 10));  //控制点1
                Point p3 = new Point(pic_width / 3 * 2, random.Next(-10, pic_height + 10));  //控制点2
                Point p4 = new Point(pic_width, random.Next(0, pic_height));  //曲线终点
                float lineWidth = (float)random.NextDouble() + 1;  //随机线条宽度(1-2)
                graphics.DrawBezier(new Pen(color_string, lineWidth), p1, p2, p3, p4);//绘制曲线
            }
            Invalidate();  //重新绘制窗体
        }

        private void button_change_Click(object sender, EventArgs e)
        {
            DrawImage();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (bitmap == null)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawImage(bitmap, new PointF(50, 50));  //把验证码绘制在窗体中
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Tools.SaveImage(bitmap);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawImage();
        }

        private void checkBox_autorefresh_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox_autorefresh.Checked;
        }


        /// <summary>
        /// 生成四位验证码
        /// </summary>
        /// <returns>验证码</returns>
        private string GetRandomCodeJp()
        {
            string tmpCode = "";  //随机验证码
            //codeLength = (int)numericUpDown1.Value;  //验证码长度
            codeLength = random.Next(4, 8);
            for (int i = 0; i < codeLength; i++)
            {
                int tmp = random.Next('あ', 'ん' + 1);  
                tmpCode += (char)tmp;
            }
            return tmpCode;
        }
        /// <summary>
        /// 生成四位验证码
        /// </summary>
        /// <returns>验证码</returns>
        private string GetRandomCodeKo()
        {
            string tmpCode = "";  //随机验证码
            //codeLength = (int)numericUpDown1.Value;  //验证码长度
            codeLength = random.Next(4, 8);
            for (int i = 0; i < codeLength; i++)
            {
                int tmp = random.Next('가', '항' + 1);  
                tmpCode += (char)tmp;
            }
            return tmpCode;
        }
    }
}
