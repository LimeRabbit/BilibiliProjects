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
    public partial class NomalTools : Form
    {
        public NomalTools()
        {
            InitializeComponent();
            GetComputer1();
        }

        int exponential = 3; //指数
        private void RadioStorageChecked(object sender, EventArgs e)
        {
            if (!(sender is RadioButton radio)) return;
            exponential = Convert.ToInt32(radio.Tag);  //tag是写好的
            if (radio == radioG)
            {
                label1.Text = "GB =";
                label2.Text = "GiB";
            }
            else if (radio == radioK)
            {
                label1.Text = "KB =";
                label2.Text = "KiB";
            }
            else if (radio == radioM)
            {
                label1.Text = "MB =";
                label2.Text = "MiB";
            }
            else if (radio == radioT)
            {
                label1.Text = "TB =";
                label2.Text = "TiB";
            }
        }

        private void InputTextChanged(object sender, EventArgs e)
        {
            if (!(sender is HintTextBox textBox) || !textBox.Focused) return;
            double d1, d2;
            int wei = (int)numericUpDown1.Value;  //保留小数位数
            if(textBox==input1)  //GB-->GiB
            {
                double.TryParse(input1.Text, out d1);
                d2 = d1 * Math.Pow(1000/1024d, exponential);
                input2.Text = Math.Round(d2, wei).ToString();
            }
            else  //GiB-->GB
            {
                double.TryParse(input2.Text, out d2);
                d1 = d2 / Math.Pow(1000 / 1024d, exponential);
                input1.Text = Math.Round(d1, wei).ToString();
            }
        }

        ComputerManager video, picture, document, download, music, desktop, threeD;


        /// <summary>
        /// 获取“计算机管理”里面的功能开启情况
        /// </summary>
        void GetComputer1()
        {
            video = new ComputerManager(ComputerManager.VIDEO);
            picture = new ComputerManager(ComputerManager.PICTURE);
            document = new ComputerManager(ComputerManager.DOCUMENT);
            download = new ComputerManager(ComputerManager.DOWNLOAD);
            music = new ComputerManager(ComputerManager.MUSIC);
            desktop = new ComputerManager(ComputerManager.DESKTOP);
            threeD = new ComputerManager(ComputerManager.THREED);
            check_video.Checked = video.Visible;
            check_picture.Checked = picture.Visible;
            check_doc.Checked = document.Visible;
            check_download.Checked = download.Visible;
            check_music.Checked = music.Visible;
            check_desktop.Checked = desktop.Visible;
            check_3D.Checked = threeD.Visible;
        }
        private void button_ok1_Click(object sender, EventArgs e)
        {
            //写注册表
            video.SetVisible(check_video.Checked);
            picture.SetVisible(check_picture.Checked);
            document.SetVisible(check_doc.Checked);
            download.SetVisible(check_download.Checked);
            music.SetVisible(check_music.Checked);
            desktop.SetVisible(check_desktop.Checked);
            threeD.SetVisible(check_3D.Checked);
        }
    }
}
