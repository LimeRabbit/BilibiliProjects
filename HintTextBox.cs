using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace BilibiliProjects
{
    public partial class HintTextBox : TextBox 
    {
        //系统参数
        int WM_PAINT = 0xF;
        int WM_CTLCOLOREDIT = 0x133;
        public HintTextBox()
        {
            // TextBox由系统绘制，不能设置 ControlStyles.UserPaint样式
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();

            this.GotFocus += HintTextBox_GotFocus;
            this.TextChanged += HintTextBox_TextChanged;
        }

        private void HintTextBox_TextChanged(object sender, EventArgs e)
        {
            if(Text.Length==0)  //文本为空时，绘制提示文本
            {
                Message m = new Message();
                WndProc(ref m);
            }
        }

        private void HintTextBox_GotFocus(object sender, EventArgs e)
        {
            //获取焦点时重新绘制
            Message m=new Message();
            WndProc(ref m);
        }

        //当Text属性为空时编辑框内出现的提示文本
        private string _hintText;

        [Description("当Text属性为空时编辑框内出现的提示文本")]
        public String HintText
        {
            get { return _hintText; }
            set
            {
                if (_hintText != value)
                {
                    _hintText = value;
                    Invalidate();
                }
            }
        }

        //提示文本的颜色
        private Color _hintColor = Color.Gray;
        [Description("提示文本的颜色")]
        public Color HintColor
        {
            get { return _hintColor; }
            set
            {
                if (_hintColor != value)
                {
                    _hintColor = value;
                    Invalidate();
                }
            }
        }

        //文本框的输入类型
        private HintInputType _inputType = HintInputType.All;
        [Description("文本框的输入类型")]
        public HintInputType InputType
        {
            get { return _inputType; }
            set
            {
                if (_inputType != value)
                {
                    _inputType = value;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            //TextBox是由系统进程绘制，重载OnPaint方法将不起作用
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT || m.Msg == WM_CTLCOLOREDIT)
            {
                WmPaint(ref m);
            }
        }

        private void WmPaint(ref Message m)
        {
            if (Text.Length == 0 && !string.IsNullOrEmpty(_hintText))
            {
                Graphics g = Graphics.FromHwnd(base.Handle);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                //绘制提示文本
                TextRenderer.DrawText(g, _hintText, Font, new Point(0, 1), _hintColor);
            }
        }


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //在这里 根据输入类型限制输入的文本
            char c = e.KeyChar;  //用户输入的字符
            if (c == '\b')  //退格键
            {
                e.Handled = false;
                return;
            }
            switch(_inputType)
            {
                case HintInputType.Number:  //仅允许输入数字，不包含小数点
                    if (c < '0' || c > '9') 
                        e.Handled = true;
                    break;
                case HintInputType.Decimal:  //允许输入小数
                    if ((c < '0' || c > '9') && c != '.')
                        e.Handled = true;
                    else if (c == '.' && Text.Contains("."))  //已经有小数点时，禁止再次输入
                        e.Handled = true;
                    break;
                case HintInputType.Letter:  //仅允许输入字母
                    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                        e.Handled = false;
                    else
                        e.Handled = true;
                    break;
                case HintInputType.LetterAndNumber:  //允许输入数字和字母
                    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'))
                        e.Handled = false;
                    else
                        e.Handled = true;
                    break;
            }
        }

    }

    public enum HintInputType
    {
        /// <summary>
        /// 任何类型
        /// </summary>
        All,
        /// <summary>
        /// 数字类型
        /// </summary>
        Number,
        /// <summary>
        /// 数字（含小数点）
        /// </summary>
        Decimal,
        /// <summary>
        /// 字母
        /// </summary>
        Letter,
        /// <summary>
        /// 字母和数字（不含小数点）
        /// </summary>
        LetterAndNumber
    }
}
