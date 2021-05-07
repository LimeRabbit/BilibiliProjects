using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilibiliProjects
{
    //空格子周围有三个细胞时，空格子生成一个细胞(死细胞复活)
    //细胞周围的细胞数量为2-3时，该细胞不变，否则死亡(变成空格子)
    public partial class LifeGame : Form
    {
        int turns = 0;  //演化第几轮
        byte[,] data;  //细胞记录，1是有细胞，0没有细胞
        byte[,] count;  //每个细胞周围有多少细胞
        int unitWidth = 20;   //格子宽度
        int wCount, hCount;  //横向、纵向的格子数量
        Pen linePen;  //画线的笔
        Brush brush;  //填充格子的颜色
        public LifeGame()
        {
            InitializeComponent();
            unitWidth = trackBar2.Value;
            wCount = myPanel1.Width / unitWidth;
            hCount = myPanel1.Height / unitWidth;
            Console.WriteLine(wCount + "," + hCount);
            data = new byte[1000, 1000];
            count = new byte[1000, 1000];
            linePen = new Pen(Color.LightGray);
            brush = new SolidBrush(label_bg.BackColor);
        }

        //开始按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                turns = 0;  //开始时，从0计数
                myPanel2.Invalidate();
                button1.Text = "停止";
                if (checkBox1.Checked)  //随机生成
                {
                    Random r = new Random(Guid.NewGuid().GetHashCode());
                    for (int i = 0; i < wCount; i++)
                    {
                        for (int j = 0; j < hCount; j++)
                        {
                            data[i, j] = (byte)r.Next(2);
                        }
                    }
                }
                myPanel1.Invalidate();
                timer1.Start();
            }
            else  //停止
            {
                button1.Text = "开始";
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region 计算每个细胞旁边有多少个细胞
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    byte c = 0;
                    if(i==0)  //第一列
                    {
                        if(j==0)  //第一行
                        {
                            c += data[i + 1, j];
                            c += data[i + 1, j + 1];
                            c += data[i, j + 1];
                        }
                        else if(j== 1000 - 1)  //最后一行
                        {
                            c += data[i + 1, j];
                            c += data[i + 1, j - 1];
                            c += data[i, j - 1];
                        }
                        else
                        {
                            c += data[i + 1, j];
                            c += data[i + 1, j - 1];
                            c += data[i, j - 1];
                            c += data[i, j + 1];
                            c += data[i + 1, j + 1];
                        }
                    }
                    else if(i== 1000 - 1)  //最后一列
                    {
                        if (j == 0) //第一行
                        {
                            c += data[i - 1, j];
                            c += data[i - 1, j + 1];
                            c += data[i, j + 1];
                        }
                        else if (j == 1000 - 1)  //最后一行
                        {
                            c += data[i - 1, j];
                            c += data[i - 1, j - 1];
                            c += data[i, j - 1];
                        }
                        else
                        {
                            c += data[i - 1, j];
                            c += data[i - 1, j - 1];
                            c += data[i, j - 1];
                            c += data[i, j + 1];
                            c += data[i - 1, j + 1];
                        }
                    }
                    else
                    {
                        if (j == 0) //第一行
                        {
                            c += data[i + 1, j];
                            c += data[i + 1, j + 1];
                            c += data[i, j + 1];
                            c += data[i - 1, j];
                            c += data[i - 1, j + 1];
                        }
                        else if (j == 1000 - 1)  //最后一行
                        {
                            c += data[i + 1, j];
                            c += data[i + 1, j - 1];
                            c += data[i, j - 1];
                            c += data[i - 1, j];
                            c += data[i - 1, j - 1];
                        }
                        else
                        {
                            c += data[i + 1, j];
                            c += data[i + 1, j - 1];
                            c += data[i, j - 1];
                            c += data[i, j + 1];
                            c += data[i + 1, j + 1];
                            c += data[i - 1, j];
                            c += data[i - 1, j - 1];
                            c += data[i - 1, j + 1];
                        }
                    }
                    count[i, j] = c;
                }
            }
            #endregion
            
            byte[,] tmpCopy = (byte[,])data.Clone(); //临时数组
            #region 根据细胞周围的数量，判断细胞的生死
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (data[i, j] == 0)
                    {
                        if (count[i, j] == 3)
                        {
                            tmpCopy[i, j] = 1;
                        }
                    }
                    else
                    {
                        if (count[i, j] < 2 || count[i, j] > 3)
                        {
                            tmpCopy[i, j] = 0;
                        }
                    }
                }
            }
            #endregion

            turns++;  //演化次数
            myPanel2.Invalidate();
            data = (byte[,])tmpCopy.Clone(); //临时数组转正
            myPanel1.Invalidate();
        }

        //演化速度变化
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = (trackBar1.Maximum - trackBar1.Value + 1) * 10;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            //改变格子尺寸
            unitWidth = trackBar2.Value;
            wCount = myPanel1.Width / unitWidth;
            hCount = myPanel1.Height / unitWidth;
            myPanel1.Invalidate();
        }

        //选择颜色
        private void label_bg_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = label_bg.BackColor;
            if(cd.ShowDialog()==DialogResult.OK)
            {
                label_bg.BackColor = cd.Color;
                brush = new SolidBrush(cd.Color);
            }
        }

        private void myPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled && e.Button == MouseButtons.Left)
            {
                //点击格子时，将点击的格子变为“细胞”
                int w = e.X / unitWidth;
                int h = e.Y / unitWidth;

                if (w >= wCount || h >= hCount)
                    return;
                if (w < 0 || h < 0)
                    return;

                data[w, h] = 1;
                myPanel1.Invalidate();
            }
        }

        private void myPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled && e.Button == MouseButtons.Left)
            {
                //用鼠标左键滑过，将滑过的格子变成“细胞”
                int w = e.X / unitWidth;
                int h = e.Y / unitWidth;
                if (w >= wCount || h >= hCount)
                    return;
                if (w < 0 || h < 0)
                    return;
                data[w, h] = 1;
                myPanel1.Invalidate();
            }
        }

        private void LifeGame_Resize(object sender, EventArgs e)
        {
            //窗体大小变化时，重新计算格子数量并自动停止
            timer1.Stop();
            button1.Text = "开始";
            wCount = myPanel1.Width / unitWidth;
            hCount = myPanel1.Height / unitWidth;
            Console.WriteLine(wCount + "," + hCount);
            myPanel1.Invalidate();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            //清屏，自动停止，并把数组清空
            timer1.Stop();
            button1.Text = "开始";
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    data[i, j] = 0;
                }
            }
            myPanel1.Invalidate();
        }


        private void myPanel2_Paint(object sender, PaintEventArgs e)
        {
            //把演化次数绘制出来，如果此处用Label，可能会卡
            int x = 10;
            int y = 10;
            Graphics g = e.Graphics;
            g.DrawString("演化次数："+turns.ToString(), Font, Brushes.DarkRed, new Point(x, y));
        }

        private void myPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (linePen == null)
                return;
            Graphics g = e.Graphics;
            //绘制纵横的线
            for (int i = 0; i < wCount; i++)
            {
                g.DrawLine(linePen, new Point(i * unitWidth, 0), new Point(i * unitWidth, myPanel1.Height));
            }
            for (int i = 0; i < hCount; i++)
            {
                g.DrawLine(linePen, new Point(0, i * unitWidth), new Point(myPanel1.Width, i * unitWidth));
            }

            //绘制所有“细胞”
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if(data[i,j]==1)
                    {
                        g.FillRectangle(brush, new RectangleF(i* unitWidth,j* unitWidth, unitWidth, unitWidth));
                    }
                }
            }
        }
    }
}
