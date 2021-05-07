using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilibiliProjects
{
    public partial class MyLabelTest : Form
    {
        List<String> fonts;
        string fontfamily;
        float fontsize=50;
        public MyLabelTest()
        {
            InitializeComponent();
            //初始设定
            myLabel1.Text = richTextBox1.Text;
            myLabel1.EffectMode = Effects.Border;
            myLabel1.BorderWidth = trackBar_border_width.Value;
            myLabel1.BorderColor = label_border_color.BackColor;
            fonts = Tools.GetFonts();
            comboBox_fontfamily.Items.AddRange(fonts.ToArray());
            comboBox_fontfamily.SelectedIndex = 0;
            myLabel1.ShadowColor = label_shadow_color.BackColor;
            myLabel1.ShadowOffsetX = (trackBar_offsetx.Value - 100) / 10f;
            myLabel1.ShadowOffsetY = (trackBar_offsety.Value - 100) / 10f;
            myLabel1.ProjectionColor = label_projection_color.BackColor;
            myLabel1.ShearX= trackBar_projection_value.Value / 100f - 1;
        }

        private void ModeChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                myLabel1.EffectMode = Effects.Border;
            }
            else if (radioButton2.Checked)
            {
                myLabel1.EffectMode = Effects.Shadow;
            }
            else
            {
                myLabel1.EffectMode = Effects.Projection;
            }
        }

        private void label_fontcolor_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;
            ColorDialog dialog = new ColorDialog();
            dialog.Color = l.BackColor;
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                l.BackColor = dialog.Color;
                if (l == label_fontcolor)
                    myLabel1.ForeColor = dialog.Color;
                else if (l == label_border_color)
                    myLabel1.BorderColor = dialog.Color;
                else if (l == label_shadow_color)
                    myLabel1.ShadowColor = dialog.Color;
                else if (l == label_projection_color)
                    myLabel1.ProjectionColor = dialog.Color;
            }
        }

        private void comboBox_fontfamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            fontfamily = comboBox_fontfamily.SelectedItem.ToString();
            //设置字体
            myLabel1.Font = new Font(fontfamily, fontsize);
        }

        private void trackBar_fontsize_Scroll(object sender, EventArgs e)
        {
            //Value取值范围：100-400
            fontsize = trackBar_fontsize.Value / 10f;
            //设置字体
            myLabel1.Font = new Font(fontfamily, fontsize);
            label_fontsize.Text = fontsize.ToString();
        }

        private void trackBar_border_width_Scroll(object sender, EventArgs e)
        {
            myLabel1.BorderWidth = trackBar_border_width.Value;
            label_border_width.Text = trackBar_border_width.Value.ToString();
        }

        private void ShadowOffsetChanged(object sender, EventArgs e)
        {
            float x = (trackBar_offsetx.Value - 100) / 10f;
            float y = (trackBar_offsety.Value - 100) / 10f;
            myLabel1.ShadowOffsetX = x;
            myLabel1.ShadowOffsetY = y;
            label_offsetx.Text = "x=" + x;
            label_offsety.Text = "y=" + y;
        }

        private void trackBar_projection_value_Scroll(object sender, EventArgs e)
        {
            float value = trackBar_projection_value.Value / 100f-1;
            label_projection_value.Text = value.ToString();
            myLabel1.ShearX = value;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            myLabel1.Text = richTextBox1.Text;
        }
    }
}
