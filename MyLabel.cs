using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BilibiliProjects
{
    class MyLabel:Label
    {
        private Color borderColor = Color.Red; //描边颜色
        private Color shadowColor = Color.Gray;  //阴影颜色
        private Color projectionColor = Color.Gray;  //投影颜色
        private Effects effectMode=Effects.Border;  //文字特效
        private int borderWidth = 10;  //描边宽度
        private float shadowOffsetX = 5;  //阴影偏移量x
        private float shadowOffsetY = 5;  //阴影偏移量y
        private float shear_x = -1f;  //投影值，影响投影方向
        /// <summary>
        /// 特效
        /// </summary>
        public Effects EffectMode
        {
            get
            {
                return effectMode;
            }
            set
            {
                if(effectMode!=value)
                {
                    effectMode = value;
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// 描边的宽度
        /// </summary>
        public int BorderWidth
        {
            get
            {
                return borderWidth;
            }
            set
            {
                if(borderWidth!=value)
                {
                    borderWidth = value;
                    if (effectMode == Effects.Border)
                        Invalidate();
                }
            }
        }
        /// <summary>
        /// 描边颜色
        /// </summary>
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                if(borderColor!=value)
                {
                    borderColor = value;
                    if (effectMode == Effects.Border)
                        Invalidate();
                }
            }
        }
        /// <summary>
        /// 阴影横向偏移量
        /// </summary>
        public float ShadowOffsetX
        {
            get
            {
                return shadowOffsetX;
            }
            set
            {
                if (shadowOffsetX != value)
                {
                    shadowOffsetX = value;
                    if (effectMode == Effects.Shadow)
                        Invalidate();
                }
            }
        }
        /// <summary>
        /// 阴影纵向偏移量
        /// </summary>
        public float ShadowOffsetY
        {
            get
            {
                return shadowOffsetY;
            }
            set
            {
                if (shadowOffsetY != value)
                {
                    shadowOffsetY = value;
                    if (effectMode == Effects.Shadow)
                        Invalidate();
                }
            }
        }

        /// <summary>
        /// 阴影颜色
        /// </summary>
        public Color ShadowColor
        {
            get
            {
                return shadowColor;
            }
            set
            {
                if (shadowColor != value)
                {
                    shadowColor = value;
                    if (effectMode == Effects.Shadow)
                        Invalidate();
                }
            }
        }
        /// <summary>
        /// 投影颜色
        /// </summary>
        public Color ProjectionColor
        {
            get
            {
                return projectionColor;
            }
            set
            {
                if(projectionColor!=value)
                {
                    projectionColor = value;
                    if (effectMode == Effects.Projection)
                        Invalidate();
                }
            }
        }
        /// <summary>
        /// 横向投影值，小于0投影向右（底边左移），大于0投影向左（底边右移）
        /// </summary>
        public float ShearX
        {
            get
            {
                return shear_x;
            }
            set
            {
                if(shear_x!=value)
                {
                    shear_x = value;
                    if (effectMode == Effects.Projection)
                        Invalidate();
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)                                                                
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            if (string.IsNullOrEmpty(Text.Trim()))
            {
                return;
            }
            //计算文本的宽度和高度
            SizeF sizeF = g.MeasureString(Text, Font);
            //绘制的区域
            RectangleF rec = new RectangleF(0, 0, sizeF.Width, sizeF.Height);
            g.SmoothingMode = SmoothingMode.HighQuality;
            GraphicsPath path = null;
            //绘制文字时的颜色
            Brush brush = new SolidBrush(ForeColor);
            switch (effectMode)
            {
                case Effects.Shadow:
                    Brush b = new SolidBrush(shadowColor);  //阴影颜色
                    g.TranslateTransform(shadowOffsetX, shadowOffsetY); //平移
                    g.DrawString(Text, Font, b, new PointF(0, 0)); //先绘制阴影
                    g.ResetTransform();  //恢复
                    g.DrawString(Text, Font, brush, new PointF(0, 0));
                    break;
                case Effects.Border:
                    path = GetStringPath(g.DpiY, rec);
                    if (borderWidth > 0)
                    {
                        //描边
                        g.DrawPath(new Pen(borderColor, borderWidth), path);
                    }
                    //文字本体
                    g.FillPath(brush, path);
                    break;
                case Effects.Projection:
                    string[] ss = Text.Split('\n');
                    Matrix matrix = new Matrix();
                    matrix.Shear(shear_x, 0); //投射，底边向左移动一倍的高度
                    float y = 0;
                    //由于Shear方法的缘故，逐行绘制
                    for (int i = 0; i < ss.Length; i++)
                    { 
                        sizeF = g.MeasureString(ss[i].ToString(), Font); //每一行测一次
                        
                        float x1 = 0;//投影坐标X
                        float y1; //投影坐标Y
                        //0.18f和0.26f为修正值，因为文字和底边有一定距离，必须考虑到
                        Regex regex = new Regex("g|j|p|q|y");
                        if (regex.IsMatch(ss[i]))
                        {
                            //这几个字母的底边会比其他文字低一些
                            y1 = (i * 2 + 1 - 0.18f) * sizeF.Height;
                        }
                        else
                        {
                            y1 = (i * 2 + 1 - 0.26f) * sizeF.Height;
                        }
                        g.Transform = matrix;  //设置矩阵
                        g.TextRenderingHint = TextRenderingHint.AntiAlias;
                        g.SmoothingMode = SmoothingMode.HighQuality;

                        g.TranslateTransform((y1-sizeF.Height*i)*(-shear_x), 0); //平移
                        g.ScaleTransform(1, 0.5f); //缩放，纵向变为一半
                        Brush b_projection = new SolidBrush(ProjectionColor);
                        //先绘制投影部分
                        g.DrawString(ss[i], Font, b_projection, new PointF(x1, y1));
                        g.ResetTransform(); //恢复矩阵
                        g.DrawString(ss[i], Font, brush, new PointF(0, y));
                        y += sizeF.Height;  //记录纵向坐标
                    }
                    break;
            }
        }

        /// <summary>
        /// 获取Path
        /// </summary>
        /// <param name="dpi"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        GraphicsPath GetStringPath(float dpi, RectangleF rect)
        {
            StringFormat format = StringFormat.GenericTypographic;
            GraphicsPath path = new GraphicsPath();
            // Convert font size into appropriate coordinates
            float emSize = dpi * Font.SizeInPoints / 72;
            path.AddString(Text, Font.FontFamily, (int)Font.Style, emSize, rect, format);

            return path;
        }
    }
    public enum Effects
    {
        /// <summary>
        /// 描边
        /// </summary>
        Border,
        /// <summary>
        /// 阴影
        /// </summary>
        Shadow,
        /// <summary>
        /// 投影
        /// </summary>
        Projection
    }
}
