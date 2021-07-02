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
    public partial class StaticForm : BaseForm
    {
        Form form;
        public StaticForm(Form form)
        {
            InitializeComponent();
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
            string sql = "select sum(wordCount),sum(regexCount),sum(readSeconds) from record where date>='" + DateTime.Now.AddDays(-offset).ToString("yyyy-MM-dd")+"'";
            DataTable dt = MySqlite.GetData(sql);
            if (dt.Rows.Count > 0&& dt.Rows[0][0]!=DBNull.Value)
            {
                int word = Convert.ToInt32(dt.Rows[0][0]);
                int regex = Convert.ToInt32(dt.Rows[0][1]);
                int read = Convert.ToInt32(dt.Rows[0][2]);
                Record record = new Record()
                {
                    seconds = read
                };
                label_week1.Text = "阅读时长：" + record.ReadTime;
                label_week2.Text = "词语替换次数：" + word;
                label_week3.Text = "正则表达式替换次数：" + regex;
            }
            //今天
            sql = "select wordCount,regexCount,readSeconds from record where date='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            DataTable dt1 = MySqlite.GetData(sql);
            if (dt1.Rows.Count > 0 && dt1.Rows[0][0] != DBNull.Value)
            {
                int wordToday = Convert.ToInt32(dt1.Rows[0][0]);
                int regexToday = Convert.ToInt32(dt1.Rows[0][1]);
                int readToday = Convert.ToInt32(dt1.Rows[0][2]);
                Record record = new Record()
                {
                    seconds = readToday
                };
                label_today1.Text = "阅读时长：" + record.ReadTime;
                label_today2.Text = "词语替换次数：" + wordToday;
                label_today3.Text = "正则表达式替换次数：" + regexToday;
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
