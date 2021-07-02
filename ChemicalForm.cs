using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilibiliProjects
{
    //MnO(4)(-)+5Fe(2+)+8H(+)=5Fe(3+)+Mn(2+)+4H(2)O
    public partial class ChemicalForm : Form
    {
        float fontsize = 10;
        string fontfamily;
        public ChemicalForm()
        {
            InitializeComponent();
            //设置初始属性
            chemicalEquation1.FontColor = label_color.BackColor;
            chemicalEquation1.SubColor = label_subcolor.BackColor;
            chemicalEquation1.SupColor = label_supcolor.BackColor;
            chemicalEquation1.ConditionColor = label_conditioncolor.BackColor;
            chemicalEquation1.EqualColor = label_equalcolor.BackColor;
            GetFonts();  //加载本机字体
        }

        /// <summary>
        /// 获取本机所有字体
        /// </summary>
        private void GetFonts()
        {
            //获取字体
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            FontFamily[] fontFamilies = installedFontCollection.Families;
            List<string> fonts = new List<string>();
            //转为string数组
            foreach (FontFamily family in fontFamilies)
            {
                fonts.Add(family.Name);
            }
            comboBox_fontfamily.Items.AddRange(fonts.ToArray());
            //默认选中 Times New Roman
            if (fonts.Contains("Times New Roman"))
                comboBox_fontfamily.SelectedItem = "Times New Roman";
        }

        //comboBox选择字体
        private void comboBox_fontfamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            fontfamily = comboBox_fontfamily.SelectedItem.ToString();
            //设置字体
            chemicalEquation1.Font = new Font(fontfamily, fontsize);
        }

        //trackBar 设置字号
        private void trackBar_fontsize_Scroll(object sender, EventArgs e)
        {
            //选择字号
            //Value取值范围：100-400
            fontsize = trackBar_fontsize.Value / 10f;
            //设置字体
            chemicalEquation1.Font = new Font(fontfamily, fontsize);
            label_fontsize.Text = fontsize.ToString();
        }

        //输入方程式
        private void hintTextBox_equal_TextChanged(object sender, EventArgs e)
        {
            //解析化学方程式
            string[] tmp = hintTextBox_equal.Text.Trim().Split('=');
            chemicalEquation1.Reactant = tmp[0];  //反应物
            if (tmp.Length > 1)
                chemicalEquation1.Products = tmp[1];  //生成物
            else
                chemicalEquation1.Products = "";  //清空文本框时，这句必须有
        }

        //输入反应条件
        private void hintTextBox_condition_TextChanged(object sender, EventArgs e)
        {
            //设置反应条件
            chemicalEquation1.Condition = hintTextBox_condition.Text.Trim();
        }

        private void Color_Clicked(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label == null)
                return;

            //弹出颜色选择窗体
            ColorDialog dialog = new ColorDialog();
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                Color color = dialog.Color;
                label.BackColor = color;  //首先把显示的颜色改了
                if (label == label_color)  //文字颜色
                    chemicalEquation1.FontColor = color;
                else if (label == label_conditioncolor)  //反应条件颜色
                    chemicalEquation1.ConditionColor = color;
                else if (label == label_equalcolor)  //等于号颜色
                    chemicalEquation1.EqualColor = color;
                else if (label == label_subcolor)  //下标颜色
                    chemicalEquation1.SubColor = color;
                else if (label == label_supcolor)  //上标颜色
                    chemicalEquation1.SupColor = color;
            }
        }
    }
}
