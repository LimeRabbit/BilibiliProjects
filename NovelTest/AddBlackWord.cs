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
    public partial class AddBlackWord : Form
    {
        public AddBlackWord()
        {
            InitializeComponent();
        }
        public AddBlackWord(string word)
        {
            InitializeComponent();
            textBox1.Text = word;
            textBox2.Focus();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text.Trim();
            if(string.IsNullOrEmpty(txt))
            {
                return;
            }
            txt = txt.Replace("'", "''"); //单引号转义
            string sql = "select * from blackWords where words=@word";  //查重
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("word", txt));
            DataTable table = MySqlite.GetData(sql, parameters);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("已存在相同项");
                return;
            }

            string txt1=textBox2.Text.Trim().Replace("'", "''");
            string type = "词语";
            if (radioButton2.Checked)
                type = "正则表达式";
            sql = "insert into blackWords values(@word,@instead,@type,@date)"; 
            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("word", txt));
            parameters.Add(new SQLiteParameter("instead", txt1));
            parameters.Add(new SQLiteParameter("type", type));
            parameters.Add(new SQLiteParameter("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            MySqlite.ExecSql(sql, parameters);
            Close();
        }
    }
}
