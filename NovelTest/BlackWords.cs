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
    public partial class BlackWords : Form
    {
        public BlackWords()
        {
            InitializeComponent();
            UIColors.SetControlColors(this);
            GetData();
        }

        /// <summary>
        /// 查询所有屏蔽关键词
        /// </summary>
        void GetData()
        {
            listView1.Items.Clear();
            string sql = "select * from blackWords order by date desc";
            DataTable table = MySqlite.GetData(sql);
            ListViewItem[] items = new ListViewItem[table.Rows.Count];
            for (int i = 0; i < items.Length; i++)
            {
                string[] ss = { table.Rows[i][0].ToString(), table.Rows[i][1].ToString(), table.Rows[i][2].ToString(), table.Rows[i][3].ToString() };
                items[i] = new ListViewItem(ss);
            }
            listView1.Items.AddRange(items);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                button_del.Enabled = true;
                button_upd.Enabled = true;
            }
            else
            {
                button_del.Enabled = false;
                button_upd.Enabled = false;
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            new AddBlackWord().ShowDialog();
            GetData();
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.OKCancel);
            if(dr==DialogResult.OK)
            {
                string word = listView1.SelectedItems[0].SubItems[0].Text;
                word = word.Replace("'", "''");  //单引号转义
                string date = listView1.SelectedItems[0].SubItems[3].Text;
                string sql = "delete from blackWords where words=@word and date=@date";
                List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                parameters.Add(new SQLiteParameter("word", word));
                parameters.Add(new SQLiteParameter("date", date));
                MySqlite.ExecSql(sql, parameters);
                listView1_SelectedIndexChanged(null, null);
                GetData();
            }
        }

        private void button_upd_Click(object sender, EventArgs e)
        {
            string word = listView1.SelectedItems[0].SubItems[0].Text;
            string instead = listView1.SelectedItems[0].SubItems[1].Text;
            string type = listView1.SelectedItems[0].SubItems[2].Text;
            new ModifyBlackWords(word, instead, type).ShowDialog();
            GetData();
        }

        private void button_clr_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("将会清空所有要屏蔽的词语，确认吗？","提示",MessageBoxButtons.OKCancel);
            if(dr==DialogResult.OK)
            {
                string sql = "delete from blackWords";
                MySqlite.ExecSql(sql);
                listView1.Items.Clear();
            }
        }
    }
}
