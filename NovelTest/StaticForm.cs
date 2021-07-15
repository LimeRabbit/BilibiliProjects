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
    public partial class StaticForm : Form
    {
        Form form;
        public StaticForm(Form form)
        {
            InitializeComponent();
            UIColors.SetControlColors(this);
            this.form = form;
            Getdata();
        }

        void Getdata()
        {
            //统计从周一到今天一共有几天
            DayOfWeek week = DateTime.Now.DayOfWeek;
            int offset;
            if (week == DayOfWeek.Sunday) offset = 6;
            else offset = (int)week - 1;
            //本周
            string sql = "select sum(wordCount),sum(regexCount),sum(readSeconds),sum(whyReason),sum(delPS) from record where date>='" + DateTime.Now.AddDays(-offset).ToString("yyyy-MM-dd")+"'";
            DataTable dt = MySqlite.GetData(sql);
            if (dt.Rows.Count > 0)
            {
                int word, regex, read, why,del;
                int.TryParse(dt.Rows[0][0] + "", out word);
                int.TryParse(dt.Rows[0][1] + "", out regex);
                int.TryParse(dt.Rows[0][2] + "", out read);
                int.TryParse(dt.Rows[0][3] + "", out why);
                int.TryParse(dt.Rows[0][4] + "", out del);
                Record record = new Record()
                {
                    seconds = read
                };
                label_week1.Text = "阅读时长：" + record.ReadTime;
                label_week2.Text = "词语替换次数：" + word;
                label_week3.Text = "正则表达式替换次数：" + regex;
                label_week4.Text = "病句修复次数：" + why;
                label_week5.Text = "去除作者的话次数：" + del;
            }
            //今天
            sql = "select wordCount,regexCount,readSeconds,whyReason,delPS from record where date='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            DataTable dt1 = MySqlite.GetData(sql);
            if (dt1.Rows.Count > 0)
            {
                int wordToday, regexToday, readToday, whyToday,delToday;
                int.TryParse(dt1.Rows[0][0] + "", out wordToday);
                int.TryParse(dt1.Rows[0][1] + "", out regexToday);
                int.TryParse(dt1.Rows[0][2] + "", out readToday);
                int.TryParse(dt1.Rows[0][3] + "", out whyToday);
                int.TryParse(dt1.Rows[0][4] + "", out delToday);
                Record record = new Record()
                {
                    seconds = readToday
                };
                label_today1.Text = "阅读时长：" + record.ReadTime;
                label_today2.Text = "词语替换次数：" + wordToday;
                label_today3.Text = "正则表达式替换次数：" + regexToday;
                label_today4.Text = "病句修复次数：" + whyToday;
                label_today5.Text = "去除作者的话次数：" + delToday;
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("该操作会清空统计数据，而且不可恢复，确定要清空吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr==DialogResult.Yes)
            {
                string sql = "delete from record";
                MySqlite.ExecSql(sql);
                label_week1.Text = "阅读时长：0秒";
                label_week2.Text = "词语替换次数：0";
                label_week3.Text = "正则表达式替换次数：0";
                label_today1.Text = "阅读时长：0秒";
                label_today2.Text = "词语替换次数：0";
                label_today3.Text = "正则表达式替换次数：0";
                if (form.Name == "ReadNovel")
                {
                    ((ReadNovel)form).ClearRecord();
                }
            }
        }
    }
}
