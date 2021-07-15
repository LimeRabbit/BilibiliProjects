using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace BilibiliProjects.NovelTest
{
    public partial class ModifyBlackWords : Form
    {
        string type;
        public ModifyBlackWords(string word,string instead,string type)
        {
            InitializeComponent();
            UIColors.SetControlColors(this);
            textBox_source.Text = word;
            textBox_sourceinstead.Text = instead;
            textBox_des.Text = word;
            textBox_desinstead.Text = instead;
            textBox_des.Focus();
            textBox_des.SelectAll();
            this.type = type;
            if (type == "正则表达式")
                radioButton2.Checked = true;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            string s1 = textBox_source.Text.Trim();  //原屏蔽词
            string s2 = textBox_des.Text.Trim();  //新屏蔽词
            string s4 = textBox_desinstead.Text.Trim();  //新替换词
            string type = "词语";
            if (radioButton2.Checked)
                type = "正则表达式";
            //if (s1 == s2 && type == this.type)
            //{
            //    MessageBox.Show("已存在相同词汇","提示");
            //    return;
            //}

            s1 = s1.Replace("'", "''");//单引号转义
            s2 = s2.Replace("'", "''");
            s4 = s4.Replace("'", "''");
            string sql = "select * from blackWords where words=@word and type=@type and insteadWords=@instead";  //查重
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("word", s2));
            parameters.Add(new SQLiteParameter("type", type));
            parameters.Add(new SQLiteParameter("instead", s4));
            DataTable table = MySqlite.GetData(sql, parameters);
            if(table.Rows.Count>0)
            {
                MessageBox.Show("已存在相同项");
                return;
            }

            sql = "update blackWords set words=@word,insteadWords=@instead,type=@type where words=@oldword"; 
            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("word", s2));
            parameters.Add(new SQLiteParameter("instead", s4));
            parameters.Add(new SQLiteParameter("type", type));
            parameters.Add(new SQLiteParameter("oldword", s1));
            MySqlite.ExecSql(sql, parameters);
            Close();
        }
    }
}
