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

namespace BilibiliProjects.NovelTest
{
    public partial class BookShelf : Form
    {
        Form form;
        bool userClose = true; //是否点击右上角的关闭按钮
        public BookShelf(Form form)
        {
            InitializeComponent();
            this.form = form;
            GetData();
        }

        List<Chapter> chapters;
        void GetData()
        {
            string sql = "select * from bookshelf order by date desc";
            DataTable table= MySqlite.GetData(sql);
            chapters = new List<Chapter>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Chapter chapter = new Chapter();
                chapter.novel = table.Rows[i][0].ToString();
                chapter.chapter = table.Rows[i][1].ToString();
                chapter.web = Convert.ToInt32(table.Rows[i][2].ToString());
                chapter.site = table.Rows[i][3].ToString();
                chapter.lastDate = table.Rows[i][4].ToString();
                chapters.Add(chapter);
            }
            AddList();
        }

        private void AddList()
        {
            listView1.Items.Clear();
            List<ListViewItem> items = new List<ListViewItem>();
            for (int i = 0; i < chapters.Count; i++)
            {
                string[] ss = { (i + 1).ToString(), chapters[i].novel, 
                    chapters[i].chapter,chapters[i].lastDate };
                ListViewItem item = new ListViewItem(ss);
                item.UseItemStyleForSubItems = false;
                //搜索书名，标红
                if (keyword != "" && chapters[i].novel.IndexOf(keyword) > -1)
                {
                    item.SubItems[1].ForeColor = Color.Red;
                }
                //搜索章节，标红
                if (keyword != "" && chapters[i].chapter.IndexOf(keyword) > -1)
                {
                    item.SubItems[2].ForeColor = Color.Red;
                }
                items.Add(item);
            }
            listView1.Items.AddRange(items.ToArray());
        }

        string keyword = ""; //搜索关键词
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
            Tools.InitSource(chapters[index].web);
            ReadChapter(chapters[index].site, chapters[index].novel);
        }
        void ReadChapter(string address,string novelName)
        {
            userClose = false; //不是用户主动关闭，而是点击列表之后的关闭
            new ReadNovel(address, novelName).Show();
            Close();
        }

        void DeleteRecord(int index)
        {
            string novel = chapters[index].novel;
            string sql = "delete from bookshelf where novel=@novel";
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
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
            if(userClose)  //如果用户点击右上角关闭，则回到主界面
            {
                form.Show();
            }
        }
    }
}
