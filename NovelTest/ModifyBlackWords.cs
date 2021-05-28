using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilibiliProjects.NovelTest
{
    public partial class ModifyBlackWords : Form
    {
        public ModifyBlackWords(string word,string instead,string type)
        {
            InitializeComponent();
            textBox_source.Text = word;
            textBox_sourceinstead.Text = instead;
            textBox_des.Text = word;
            textBox_desinstead.Text = instead;
            textBox_des.Focus();
            textBox_des.SelectAll();
            if (type == "正则表达式")
                radioButton2.Checked = true;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            string s1 = textBox_source.Text.Trim();  //原屏蔽词
            string s2 = textBox_des.Text.Trim();  //新屏蔽词
            string s4 = textBox_desinstead.Text.Trim();  //新替换词
            if (s1 == s2)
                return;

            s1 = s1.Replace("'", "''");//单引号转义
            s2 = s2.Replace("'", "''");
            s4 = s4.Replace("'", "''");
            string sql = "select * from blackWords where words=@word";  //查重
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("word", s2));
            DataTable table = MySqlite.GetData(sql, parameters);
            if(table.Rows.Count>0)
            {
                MessageBox.Show("已存在相同项");
                return;
            }

            sql = "update blackWords set words=@word,@instead=instead,date=@date where words=@oldword"; 
            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("word", s2));
            parameters.Add(new SQLiteParameter("instead", s4));
            parameters.Add(new SQLiteParameter("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            parameters.Add(new SQLiteParameter("oldword", s1));
            MySqlite.ExecSql(sql, parameters);
            Close();
        }
    }
}
