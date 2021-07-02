using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilibiliProjects.NovelTest
{
    public partial class Settings : Form
    {
        Form parentForm;
        public Settings(Form form)
        {
            InitializeComponent();
            UIColors.SetControlColors(this);
            parentForm = form;
            InitControls();
        }

        private void InitControls()
        {
            List<string> fonts = Tools.GetFonts();
            comboBox_font.Items.AddRange(fonts.ToArray());
            int i = fonts.IndexOf(Setting.FontFamily);
            if (i > -1)
                comboBox_font.SelectedIndex = i;
            trackBar_fontsize.Value = (int)Setting.FontSize;

            //if (UIColors.IsUserMode)
            {
                label_backcolor.BackColor = UIColors.BackColor;
                label_forecolor.BackColor = UIColors.ForeColor;
                label_linkcolor.BackColor = UIColors.LinkColor;
            }
            checkBox_mycolor.Checked = UIColors.IsUserMode;
            checkBox_nightmode.Checked = UIColors.IsNightMode;
            checkBox_autosave.Checked = Setting.AutoSave;
            checkBox_compress.Checked = Setting.IsCompress;
        }

        private void checkBox_mycolor_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_nightmode.Enabled = !checkBox_mycolor.Checked;
            label_backcolor.Enabled = checkBox_mycolor.Checked;
            label_forecolor.Enabled = checkBox_mycolor.Checked;
            label_linkcolor.Enabled = checkBox_mycolor.Checked;
            UIColors.IsUserMode = checkBox_mycolor.Checked;
            if (checkBox_mycolor.Checked)  //自定义颜色
            {
                label_backcolor.Cursor = Cursors.Hand;
                label_forecolor.Cursor = Cursors.Hand;
                label_linkcolor.Cursor = Cursors.Hand;
                SetColors();  //设置颜色
            }
            else  //非自定义
            {
                label_backcolor.Cursor = Cursors.Default;
                label_forecolor.Cursor = Cursors.Default;
                label_linkcolor.Cursor = Cursors.Default;
                checkBox_nightmode_CheckedChanged(null, null);
            }
        }

        private void checkBox_nightmode_CheckedChanged(object sender, EventArgs e)
        {
            UIColors.SetNightMode(checkBox_nightmode.Checked);
            UIColors.SetControlColors(this);
            if(parentForm != null)
            {
                UIColors.SetControlColors(parentForm);
            }
        }

        void SetColors()
        {
            UIColors.ForeColor = label_forecolor.BackColor;
            UIColors.BackColor = label_backcolor.BackColor;
            UIColors.LinkColor = label_linkcolor.BackColor;
            UIColors.SetControlColors(this);
            if (parentForm != null)
            {
                UIColors.SetControlColors(parentForm);
            }
        }

        private void UI_Color_Changed(object sender, EventArgs e)
        {
            Label label = sender as Label;
            ColorDialog dialog = new ColorDialog();
            dialog.Color = label.BackColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                label.BackColor = dialog.Color;
                SetColors();
            }
        }

        private void checkBox_autosave_CheckedChanged(object sender, EventArgs e)
        {
            Setting.AutoSave = checkBox_autosave.Checked;
        }

        private void checkBox_compress_CheckedChanged(object sender, EventArgs e)
        {
            Setting.IsCompress = checkBox_compress.Checked;
        }

        private void comboBox_font_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting.FontFamily = comboBox_font.SelectedItem.ToString();
            SetPreviewFont();
        }

        private void trackBar_fontsize_Scroll(object sender, EventArgs e)
        {
            label_scale.Text = "字号：" + trackBar_fontsize.Value;
            Setting.FontSize = trackBar_fontsize.Value;
            SetPreviewFont();
        }

        void SetPreviewFont()
        {
            label_preview.Font = Setting.Font;
            label_preview.Left = (groupBox3.Width - label_preview.Width) / 2;
            label_preview.Top = (groupBox3.Height - label_preview.Height - label5.Bottom) / 2 + label5.Top;
        }
    }
}
