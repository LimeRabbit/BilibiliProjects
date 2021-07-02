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
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
            UIColors.SetControlColors(this);
        }

        /// <summary>
        /// 设置进度和标题
        /// </summary>
        /// <param name="title"></param>
        /// <param name="progress"></param>
        public void SetTitleAndProgress(string title,double progress)
        {
            progressBar1.Value = (int)progress;
            label_tip.Text = title;
            label_process.Text = Math.Round(progress, 2) + "%";
            label_tip.Left = (Width - label_tip.Width) / 2;
            label_process.Left= (Width - label_process.Width) / 2;
        }
        /// <summary>
        /// 设置进度
        /// </summary>
        /// <param name="progress"></param>
        public void SetProgress(double progress)
        {
            progressBar1.Value = (int)progress;
            label_process.Text = Math.Round(progress, 2) + "%";
            label_process.Left = (Width - label_process.Width) / 2;
        }
    }
}
