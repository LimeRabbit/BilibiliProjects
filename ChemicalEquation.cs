using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilibiliProjects
{
    public partial class ChemicalEquation : Panel
    {
        Brush b_font;  //字体刷子
        Brush b_sub;  //下标
        Brush b_sup;  //上标
        Brush b_equal;  //等于号
        Brush b_condition;  //反应条件
        Font font;
        Font font_sub;  //上标、下标的字体
        Font font_condition;  //反应条件的字体
        float fontsize = 20;  //默认字体要大一点，因为要绘制下标等小字
        public ChemicalEquation()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);

            BackColor = Color.White;  //背景色默认白色
            font = new Font("Times New Roman", fontsize);  
            font_sub = new Font("Times New Roman", fontsize / 2);
            font_condition = new Font("Times New Roman", fontsize * 0.6f);
            b_condition = new SolidBrush(conditionColor);
            b_equal = new SolidBrush(equalColor);
            b_font = new SolidBrush(fontColor);
            b_sub = new SolidBrush(subColor);
            b_sup = new SolidBrush(supColor);
        }

        private string reactant;
        /// <summary>
        /// 反应物
        /// </summary>
        public string Reactant
        {
            get
            {
                return reactant;
            }
            set
            {
                if(reactant!=value)
                {
                    reactant = value;
                    Invalidate();
                }
            }
        }
        private string condition;
        /// <summary>
        /// 反应条件
        /// </summary>
        public string Condition
        {
            get
            {
                return condition;
            }
            set
            {
                if (condition != value)
                {
                    condition = value;
                    Invalidate();
                }
            }
        }
        private string products;
        /// <summary>
        /// 生成物
        /// </summary>
        public string Products
        {
            get
            {
                return products;
            }
            set
            {
                if (products != value)
                {
                    products = value;
                    Invalidate();
                }
            }
        }
        private Color fontColor = Color.Black;
        /// <summary>
        /// 化学方程式字体颜色
        /// </summary>
        public Color FontColor
        {
            get
            {
                return fontColor;
            }
            set
            {
                if (fontColor != value)
                {
                    fontColor = value;
                    b_font = new SolidBrush(value);
                    Invalidate();
                }
            }
        }
        private Color supColor = Color.Black;
        /// <summary>
        /// 上标的颜色
        /// </summary>
        public Color SupColor
        {
            get
            {
                return supColor;
            }
            set
            {
                if (supColor != value)
                {
                    supColor = value;
                    b_sup = new SolidBrush(value);
                    Invalidate();
                }
            }
        }
        private Color subColor = Color.Black;
        /// <summary>
        /// 下标的颜色
        /// </summary>
        public Color SubColor
        {
            get
            {
                return subColor;
            }
            set
            {
                if (subColor != value)
                {
                    subColor = value;
                    b_sub = new SolidBrush(value);
                    Invalidate();
                }
            }
        }
        private Color equalColor = Color.Black;
        /// <summary>
        /// 等于号的颜色
        /// </summary>
        public Color EqualColor
        {
            get
            {
                return equalColor;
            }
            set
            {
                if (equalColor != value)
                {
                    equalColor = value;
                    b_equal = new SolidBrush(value);
                    Invalidate();
                }
            }
        }
        private Color conditionColor = Color.Black;
        /// <summary>
        /// 反应条件的颜色
        /// </summary>
        public Color ConditionColor
        {
            get
            {
                return conditionColor;
            }
            set
            {
                if (conditionColor != value)
                {
                    conditionColor = value;
                    b_condition = new SolidBrush(value);
                    Invalidate();
                }
            }
        }

        public override Font Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
                fontsize = value.Size;
                //上标下标字号  0.5x
                font_sub = new Font(value.FontFamily, fontsize / 2);
                //反应条件字号  0.6x
                font_condition = new Font(value.FontFamily, fontsize * 0.6f);
                Invalidate();
            }
        }

        Graphics graphics;
        protected override void OnPaint(PaintEventArgs e)
        {
            graphics = e.Graphics;
            float x = 0;
            float y = 10;
            //用固定的字母测量化学式的高度，避免括号之前没有字母导致没法测量
            float height = graphics.MeasureString("Ag", font).Height;
            //绘制反应物
            DrawReactant(graphics, reactant,ref x, y,height);

            float equalWidth = 20f;  //等号宽度
            //绘制等于号和反应条件
            if(!string.IsNullOrEmpty(condition))
            {
                equalWidth = graphics.MeasureString(condition, font_condition).Width;
                graphics.DrawString(condition, font_condition, b_condition, new PointF(x + 5, y - 10));
            }
            graphics.DrawLine(new Pen(b_equal), new PointF(x, y + height / 2 - 2), 
                new PointF(x + equalWidth+5, y + height / 2 - 2));
            graphics.DrawLine(new Pen(b_equal), new PointF(x, y + height / 2 + 2), 
                new PointF(x + equalWidth+5, y + height / 2 + 2));
            x += equalWidth+5;

            //绘制生成物
            DrawReactant(graphics, products,ref x, y,height);
        }
        /// <summary>
        /// 绘制反应物和生成物
        /// </summary>
        private void DrawReactant(Graphics graphics,string s,ref float x,float y,float height)
        {
            int iStart = 0;  //左括号索引
            int iEnd = -1;  //右括号索引
            bool finish = false;  //循环是否应该结束
            //先绘制反应物
            while (true)
            {
                if (string.IsNullOrEmpty(s))
                    break;
                iStart = s.IndexOf("(", iStart + 1);  //左括号之前的，直接绘制
                string tmp;
                if (iStart == -1)  //没有找到左括号，直接截取至最后，finish置为true
                {
                    tmp = s.Substring(iEnd + 1);
                    finish = true;
                }
                else  //截取上一个右括号至当前左括号之间的内容
                {
                    tmp = s.Substring(iEnd + 1, iStart - iEnd - 1);
                }
                graphics.DrawString(tmp, font, b_font, new PointF(x, y));
                x += graphics.MeasureString(tmp, font).Width;  //X坐标，累加
                if (finish)
                    break;  //结束循环
                iEnd = s.IndexOf(")", iEnd + 1); 
                if (iEnd > iStart)
                {
                    //截取括号里面的内容
                    tmp = s.Substring(iStart + 1, iEnd - iStart - 1);
                    if (tmp.Contains("+") || tmp.Contains("-"))  //有正负号，代表是上标（离子）
                        graphics.DrawString(tmp, font_sub, b_sup, 
                            new PointF(x - fontsize / 4, y));
                    else  //没有正负号，是下标
                        graphics.DrawString(tmp, font_sub, b_sub, 
                            new PointF(x - fontsize / 4, y + height / 2));
                    x += graphics.MeasureString(tmp, font_sub).Width- fontsize / 2;
                }
                if (iEnd == s.Length - 1)  //如果右括号是最后一位，循环完毕
                    break;
            }
        }
    }
}
