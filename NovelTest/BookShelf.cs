using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilibiliProjects
{
    public partial class BookShelf : Form
    {
        Form form;
        bool userClose = true; //是否点击右上角的关闭按钮
        public BookShelf(Form form)
        {
            InitializeComponent();
            MySqlite.InitDB();
            this.form = form;
            if (!File.Exists(MySqlite.path))
            {
                Tools.CreateTable();  //不存在数据库，创建新表
            }
            else
            {
                GetData();  //存在数据库，查询
            }
        }

        List<Chapter> chapters;
        void GetData()
        {
            string sql = "select * from bookshelf order by date desc";
            chapters = MySqlite.GetData(sql);
            AddList();
        }

        private void AddList()
        {
            listView1.Items.Clear();
            List<ListViewItem> items = new List<ListViewItem>();
            for (int i = 0; i < chapters.Count; i++)
            {
                string[] ss = { (i + 1).ToString(), chapters[i].novel, chapters[i].chapter,chapters[i].lastDate };
                ListViewItem item = new ListViewItem(ss);
                item.UseItemStyleForSubItems = false;
                //搜索章节，标红
                if (keyword != "" && chapters[i].novel.IndexOf(keyword) > -1)
                {
                    item.SubItems[1].ForeColor = Color.Red;
                }
                items.Add(item);
            }
            listView1.Items.AddRange(items.ToArray());
        }

        string keyword = "";
        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            keyword = textBox_search.Text.Trim();
            int index = chapters.FindIndex(c => c.chapter.IndexOf(keyword) > -1);
            AddList();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;
            int index = listView1.SelectedIndices[0];
            ReadChapter(chapters[index].site);
        }
        void ReadChapter(string address)
        {
            userClose = false; //不是用户主动关闭
            new Form1(address).Show();
            Close();
        }

        void DeleteRecord(int index)
        {
            string novel = chapters[index].novel;
            string sql = "delete from bookshelf where novel=@novel";
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("novel", novel));
            MySqlite.ExecSql(sql, parameters);
            GetData();
        }

        private void 删除记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;
            int index = listView1.SelectedIndices[0];
            DeleteRecord(index);
        }

        private void BookShelf_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(userClose)
            {
                form.Show();
            }
        }
    }
}
