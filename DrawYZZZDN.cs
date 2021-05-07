using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BilibiliProjects
{
    public partial class DrawYZZZDN : Form
    {
        Computer computer;
        Bitmap bitmap;
        int picWidth = 450;
        int picHeight = 560;
        Font font;
        string[] keys;
        public DrawYZZZDN()
        {
            InitializeComponent();
            computer = new Computer();
            bitmap = new Bitmap(picWidth, picHeight);
            font = new Font("黑体", 15);
            keys = new string[]{ "型号",
                    "处理器",
                    "内存",
                    "机械硬盘",
                    "固态硬盘",
                    "核显",
                    "独显",
                    "屏幕",
                    "散热器",
                    "机身重量",
                    "电源",
                    "电池",
                    "无线网卡",
                    "价格"};
            DrawImage(computer);
        }

        private void DrawImage(Computer c)
        {
            int width1 = picWidth / 3;  //竖线的X坐标，左侧占 1/3，右侧占 2/3
            int height1 = picHeight / 14;  //每一行的高度
            Graphics graphics = Graphics.FromImage(bitmap); //创建画笔
            //左侧背景
            graphics.FillRectangle(Brushes.Yellow, new RectangleF(0, 0, width1, picHeight));
            //右侧计算机型号背景
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(235, 241, 222)), new RectangleF(width1, 0, picWidth, height1));
            //右侧其他参数背景 白色
            graphics.FillRectangle(Brushes.White, new RectangleF(width1, height1, picWidth, picHeight));
            graphics.DrawLine(Pens.Black, new Point(width1, 0), new Point(width1, picHeight));  //竖线
            //画13条横线
            for (int i = 1; i <= 13; i++)
            {
                graphics.DrawLine(Pens.Black, new Point(0, height1 * i), new Point(picWidth, height1 * i));
            }
            DrawKeys(graphics, keys, width1, height1);  //绘制左侧文字
            int lines = 0;  //第几行，用于计算Y坐标
            SizeF size = graphics.MeasureString("测试文本", font);
            float paddingTop = (height1 - size.Height) / 2;  //文字和顶端的距离

            #region 绘制各种参数
            graphics.DrawString(computer.Model, font, Brushes.Red, new PointF(width1 + 10, paddingTop + height1 * lines));
            lines++;
            graphics.DrawString(computer.Cpu, font, Brushes.Black, new PointF(width1 + 10, paddingTop + height1 * lines));
            float paddingLeft = graphics.MeasureString(computer.Cpu, font).Width;  //记录文字宽度
            graphics.DrawString(computer.Cores + "核" + computer.Threads + "线程", font, Brushes.Blue, //CPU核心线程
                new PointF(width1 + 10 + paddingLeft, paddingTop + height1 * lines));
            lines++;
            string tmpString = computer.Memory;
            if (computer.MemoryChannels == 2)  //判断通道数
                tmpString += "双通道";
            graphics.DrawString(tmpString, font, Brushes.Black, new PointF(width1 + 10, paddingTop + height1 * lines));
            paddingLeft = graphics.MeasureString(tmpString, font).Width;
            graphics.DrawString(computer.MemoryBrand, font, Brushes.Blue, 
                new PointF(width1 + 10 + paddingLeft, paddingTop + height1 * lines));
            lines++;
            if (computer.HDDCapacity == 0) //没有机械硬盘
                graphics.DrawString("/", font, Brushes.Black, new PointF(width1 + 10, paddingTop + height1 * lines));
            else  //有机械硬盘
            {
                graphics.DrawString(computer.HDDCapacity + "G", font, Brushes.Black, 
                    new PointF(width1 + 10, paddingTop + height1 * lines));
                paddingLeft = graphics.MeasureString(computer.HDDCapacity + "G", font).Width;
                graphics.DrawString(computer.HDDBrand, font, Brushes.Blue, 
                    new PointF(width1 + 10 + paddingLeft, paddingTop + height1 * lines));
            }
            lines++;
            if (computer.SSDCapacity == 0)  //没有固态硬盘
                graphics.DrawString("/", font, Brushes.Black, new PointF(width1 + 10, paddingTop + height1 * lines));
            else  //有固态硬盘
            {
                graphics.DrawString(computer.SSDCapacity + "G", font, Brushes.Black, 
                    new PointF(width1 + 10, paddingTop + height1 * lines));
                paddingLeft = graphics.MeasureString(computer.SSDCapacity + "G", font).Width;
                graphics.DrawString(computer.SSDBrand, font, Brushes.Blue, 
                    new PointF(width1 + 10 + paddingLeft, paddingTop + height1 * lines));
            }
            lines++;
            graphics.DrawString(computer.Integrated, font, Brushes.Blue, new PointF(width1 + 10, paddingTop + height1 * lines));
            lines++;
            graphics.DrawString(computer.External, font, Brushes.Red, new PointF(width1 + 10, paddingTop + height1 * lines));
            lines++;
            graphics.DrawString(computer.ScreenSize + "寸", font, Brushes.Black, new PointF(width1 + 10, paddingTop + height1 * lines));
            paddingLeft = graphics.MeasureString(computer.ScreenSize + "寸", font).Width;
            graphics.DrawString(computer.ScreenFps + "赫兹", font, Brushes.Blue, 
                new PointF(width1 + 10 + paddingLeft, paddingTop + height1 * lines));
            paddingLeft += graphics.MeasureString(computer.ScreenFps + "赫兹", font).Width; //累加距离
            graphics.DrawString(computer.ScreenGamut + "色域", font, Brushes.Blue, 
                new PointF(width1 + 10 + paddingLeft, paddingTop + height1 * lines));
            paddingLeft += graphics.MeasureString(computer.ScreenGamut + "色域", font).Width; //累加距离
            graphics.DrawString(computer.ScreenBrand, font, Brushes.Blue, 
                new PointF(width1 + 10 + paddingLeft, paddingTop + height1 * lines));
            lines++;
            graphics.DrawString(computer.HeatPipe + "热管 " + computer.Fans + "风扇 " + computer.AirOutlet + "出风口", font, 
                Brushes.Black, new PointF(width1 + 10, paddingTop + height1 * lines));
            lines++;
            graphics.DrawString(computer.ComputerWeight + "克", font, Brushes.Black, 
                new PointF(width1 + 10, paddingTop + height1 * lines));
            lines++;
            graphics.DrawString(computer.Power + "瓦 " + computer.PowerWeight + "克", font, Brushes.Black, 
                new PointF(width1 + 10, paddingTop + height1 * lines));
            lines++;
            graphics.DrawString(computer.Battery + "瓦·时", font, Brushes.Black, 
                new PointF(width1 + 10, paddingTop + height1 * lines));
            lines++;
            graphics.DrawString(computer.WebCard, font, Brushes.Black, new PointF(width1 + 10, paddingTop + height1 * lines));
            lines++;
            graphics.DrawString(computer.Price + "元", font, Brushes.Red, new PointF(width1 + 10, paddingTop + height1 * lines));
            #endregion

            Invalidate();
        }

        /// <summary>
        /// 将左侧画出来
        /// </summary>
        /// <param name="g"></param>
        /// <param name="keys"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void DrawKeys(Graphics g, string[] keys, int width, int height)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                SizeF size = g.MeasureString(keys[i], font);
                float x = (width - size.Width) / 2;
                float y = (height - size.Height) / 2 + i * height;
                g.DrawString(keys[i], font, Brushes.Black, new PointF(x, y));
            }
        }

        /// <summary>
        /// 为computer对象赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetComputer(object sender, EventArgs e)
        {
            computer.Model = hintTextBox_model.Text.Trim();
            computer.Cpu = hintTextBox_cpu.Text.Trim();
            short.TryParse(hintTextBox_core.Text, out computer.Cores);
            short.TryParse(hintTextBox_thread.Text, out computer.Threads);
            computer.Memory = hintTextBox_memory.Text.Trim();
            computer.MemoryBrand = hintTextBox_memory1.Text.Trim();
            int.TryParse(hintTextBox_hdd1.Text, out computer.HDDCapacity);
            computer.HDDBrand = hintTextBox_hdd2.Text.Trim();
            int.TryParse(hintTextBox_ssd1.Text, out computer.SSDCapacity);
            computer.SSDBrand = hintTextBox_ssd2.Text.Trim();
            computer.Integrated = hintTextBox_gpu1.Text.Trim();
            computer.External = hintTextBox_gpu2.Text.Trim();
            float.TryParse(hintTextBox_scr1.Text, out computer.ScreenSize);
            int.TryParse(hintTextBox_hz.Text, out computer.ScreenFps);
            int.TryParse(hintTextBox_seyu.Text, out computer.ScreenGamut);
            computer.ScreenBrand = hintTextBox_scr2.Text.Trim();
            short.TryParse(hintTextBox_reguan.Text, out computer.HeatPipe);
            short.TryParse(hintTextBox_fengshan.Text, out computer.Fans);
            short.TryParse(hintTextBox_chufengkou.Text, out computer.AirOutlet);
            int.TryParse(hintTextBox_weight.Text, out computer.ComputerWeight);
            int.TryParse(hintTextBox_power.Text, out computer.Power);
            int.TryParse(hintTextBox_powerWeight.Text, out computer.PowerWeight);
            float.TryParse(hintTextBox_battery.Text, out computer.Battery);
            computer.WebCard = hintTextBox_wlan.Text.Trim();
            float.TryParse(hintTextBox_price.Text, out computer.Price);

            DrawImage(computer);
        }

        private void checkBox_daul_CheckedChanged(object sender, EventArgs e)
        {
            computer.MemoryChannels =
                checkBox_daul.Checked ? (byte)2 : (byte)1;
            DrawImage(computer);
        }

        private void DrawYZZZDN_Paint(object sender, PaintEventArgs e)
        {
            if (bitmap == null)
                return;

            Graphics g = e.Graphics;
            g.DrawImage(bitmap, new PointF(300, 5));
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Tools.SaveImage(bitmap);
        }
    }

    class Computer
    {
        /// <summary>
        /// 笔记本型号
        /// </summary>
        public string Model;
        /// <summary>
        /// 处理器型号
        /// </summary>
        public string Cpu;
        /// <summary>
        /// 处理器核心数
        /// </summary>
        public short Cores;
        /// <summary>
        /// 处理器线程数
        /// </summary>
        public short Threads;
        /// <summary>
        /// 内存容量频率等信息
        /// </summary>
        public string Memory;
        /// <summary>
        /// 内存品牌
        /// </summary>
        public string MemoryBrand;
        /// <summary>
        /// 内存通道
        /// </summary>
        public byte MemoryChannels = 1;
        /// <summary>
        /// 机械硬盘容量
        /// </summary>
        public int HDDCapacity;
        /// <summary>
        /// 机械硬盘品牌
        /// </summary>
        public string HDDBrand;
        /// <summary>
        /// 固态硬盘容量
        /// </summary>
        public int SSDCapacity;
        /// <summary>
        /// 固态硬盘品牌
        /// </summary>
        public string SSDBrand;
        /// <summary>
        /// 核显
        /// </summary>
        public string Integrated;
        /// <summary>
        /// 独显
        /// </summary>
        public string External;
        /// <summary>
        /// 显示器尺寸
        /// </summary>
        public float ScreenSize;
        /// <summary>
        /// 显示器刷新率
        /// </summary>
        public int ScreenFps;
        /// <summary>
        /// 显示器色域
        /// </summary>
        public int ScreenGamut;
        /// <summary>
        /// 显示器品牌
        /// </summary>
        public string ScreenBrand;
        /// <summary>
        /// 热管数
        /// </summary>
        public short HeatPipe;
        /// <summary>
        /// 风扇数
        /// </summary>
        public short Fans;
        /// <summary>
        /// 出风口数
        /// </summary>
        public short AirOutlet;
        /// <summary>
        /// 电脑重量
        /// </summary>
        public int ComputerWeight;
        /// <summary>
        /// 电源功率
        /// </summary>
        public int Power;
        /// <summary>
        /// 电源重量
        /// </summary>
        public int PowerWeight;
        /// <summary>
        /// 电池
        /// </summary>
        public float Battery;
        /// <summary>
        /// 网卡
        /// </summary>
        public string WebCard;
        /// <summary>
        /// 电脑价格
        /// </summary>
        public float Price;
    }
}
