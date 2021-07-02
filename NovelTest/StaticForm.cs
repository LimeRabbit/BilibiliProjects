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
        public StaticForm()
        {
            InitializeComponent();
            Getdata();
        }

        void Getdata()
        {
            //本周
            string sql = "select sum(wordCount),sum(regexCount),sum(readSeconds) from record where date>='" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")+"'";
            DataTable dt = MySqlite.GetData(sql);
            if (dt.Rows.Count > 0)
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

            sql = "select wordCount,regexCount,readSeconds from record where date='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            DataTable dt1 = MySqlite.GetData(sql);
            if (dt1.Rows.Count > 0)
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
    }
}
