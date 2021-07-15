using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilibiliProjects.NovelTest
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            UIColors.SetControlColors(this);
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            DialogResult dr= MessageBox.Show("是否打开浏览器？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                LinkLabel link = sender as LinkLabel;
                string url = link.Tag.ToString();
                Process.Start(url);
            }
        }
    }
}
