using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//将文本生成为png图片
namespace BilibiliProjects
{
    public partial class Subtitle : Form
    {
        Bitmap previewBmp;
        List<Item> items;
        List<ListViewItem> listViewItems;
        Preference preference;
        public Subtitle()
        {
            InitializeComponent();
            Init();
        }

        //初始化变量
        void Init()
        {
            previewBmp = new Bitmap(panel.Width, panel.Height);
            preference = new Preference(); 
            preference.Font = new Font("宋体", 50);
            preference.StrokeWidth = 2;
        }


        private void button_scan_Click(object sender, EventArgs e)
        {
            //选择文件
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Application.StartupPath;
            open.Title = "选择文本文件";
            if(open.ShowDialog()==DialogResult.OK)
            {
                textBox_filename.Text = open.FileName;
                GetFileContent(open.FileName);
            }
        }

        private void TextBox_filename_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                string s = textBox_filename.Text.Trim();
                if (!File.Exists(s))
                    return;
                GetFileContent(s);
            }
        }
        /// <summary>
        /// 获取文件内容
        /// </summary>
        /// <param name="filename">文件名</param>
        void GetFileContent(string filename)
        {
            Encoding encoding = Tools.GetFileEncodeType(filename); //判断编码
            string[] ss = File.ReadAllLines(filename, encoding); //提取内容
            if(ss.Length==1&&string.IsNullOrEmpty(ss[0].Trim()))
            {
                MessageBox.Show("空文件");
                return;
            }
            listView1.Items.Clear();
            items = new List<Item>();
            listViewItems = new List<ListViewItem>();
            Item item;
            ListViewItem listViewItem;
            for (int i = 0; i < ss.Length; i++)
            {
                item = new Item(i + 1, ss[i]);
                items.Add(item);
                string[] s = { (i + 1).ToString(), ss[i] };
                listViewItem = new ListViewItem(s);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItems.Add(listViewItem);
            }
            listView1.Items.AddRange(listViewItems.ToArray());
            listView1.Focus();
            listView1.Items[0].Selected = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawBitmap(true);
        }
        /// <summary>
        /// 绘图
        /// </summary>
        /// <param name="show">是否显示在界面上</param>
        void DrawBitmap(bool show)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;
            int index = listView1.SelectedIndices[0];
            Item item = items[index];
            Graphics g = Graphics.FromImage(previewBmp);
            g.Clear(Color.White);
            //计算文本的宽度和高度
            SizeF sizeF = g.MeasureString(item.Text, preference.Font);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Brush brush = new SolidBrush(preference.TextColor); //文字颜色
            Pen pen = new Pen(preference.StrokeColor, preference.StrokeWidth);
            float x = (previewBmp.Width - sizeF.Width) / 2;
            //绘制的区域
            RectangleF rec = new RectangleF(x, 0, sizeF.Width, sizeF.Height);
            GraphicsPath path = GetStringPath(g.DpiY, rec,item);
            if (preference.StrokeWidth > 0)
            {
                //描边
                g.DrawPath(pen, path);
            }
            //文字本体
            g.FillPath(brush, path);
            if(show)
                panel.Invalidate();
        }
        GraphicsPath GetStringPath(float dpi, RectangleF rect,Item item)
        {
            StringFormat format = StringFormat.GenericTypographic;
            GraphicsPath path = new GraphicsPath();
            // Convert font size into appropriate coordinates
            float emSize = dpi * preference.Font.SizeInPoints / 72;
            path.AddString(item.Text, preference.Font.FontFamily, (int)preference.Font.Style, emSize, rect, format);

            return path;
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(previewBmp, new PointF(0, 0));
        }
    }

    class Item
    {
        public Item() { }
        public Item(int id,string s)
        {
            ID = id;
            Text = s;
        }
        public int ID;//序号
        public string Text; //内容
    }
    class Preference
    {
        public Preference() { }
        public bool Global=true;  //使用全局样式，备用
        public bool DualLanguage = false;  //是否为双语
        public Font Font;  //字体
        public Color TextColor = Color.Red; //文字颜色
        public Color StrokeColor = Color.Blue; //描边颜色
        public Color SecondTextColor = Color.Red; //第二行文字颜色
        public Color SecondStrokeColor = Color.Blue; //第二行描边颜色
        public float StrokeWidth = 2;  //描边粗细
        public float OffsetX;  //文字横坐标偏移
        public float OffsetY;  //文字纵坐标偏移
        public int AlignX=1;  //文字横向对齐方式(在整体的左-0，中-1，右-2)
        public int AlignY=2;  //文字纵向对齐方式(在整体的上-0，中-1，下-2)
        public Size CanvasSize;  //整个画布大小
        public Color BackColor = Color.Transparent;  //画布的背景颜色，透明，备用
        public Color StringBgColor;  //文字的背景颜色
        public ImageFormat Format;  //保存图片的格式
    }
}
