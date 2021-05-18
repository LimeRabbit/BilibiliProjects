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
        public ModifyBlackWords(string word,string type)
        {
            InitializeComponent();
            textBox_source.Text = word;
            textBox_des.Text = word;
            textBox_des.Focus();
            textBox_des.SelectAll();
            if (type == "正则表达式")
                radioButton2.Checked = true;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            string s1 = textBox_source.Text.Trim();
            string s2 = textBox_des.Text.Trim();
            if (s1 == s2)
                return;

            s2 = s2.Replace("'", "''");//单引号转义
            s1 = s1.Replace("'", "''");
            string sql = "select from blackWords where words=@word";  //查重
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("word", s2));
            DataTable table = MySqlite.GetData(sql, parameters);
            if(table.Rows.Count>0)
            {
                MessageBox.Show("已存在相同项");
                return;
            }

            sql = "update blackWords set words=@word,date=@date where words=@oldword"; 
            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("word", s2));
            parameters.Add(new SQLiteParameter("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            parameters.Add(new SQLiteParameter("oldword", s1));
            MySqlite.ExecSql(sql, parameters);
            Close();
        }
    }
}
