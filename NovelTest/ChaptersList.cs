using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilibiliProjects.NovelTest
{
    public partial class ChaptersList : Form
    {
        string novel;//小说名
        bool all; //是否显示所有小说的章节
        public ChaptersList(string novel,bool all)
        {
            InitializeComponent();
            this.all = all;
            label_novel.Text = novel;
            this.novel = novel;
            GetChapterCount();
            if (all)
            {
                label_novel.Text = itemsLv1[0].SubItems[0].Text;
                this.novel = itemsLv1[0].SubItems[0].Text;
            }
            label_novel.Left = (Width - label_novel.Width) / 2;
            Thread t = new Thread(delegate()
            {
                if (all)  //显示第一个小说的章节
                {
                    GetChapters(sourceIndex[0], itemsLv1[0].SubItems[0].Text);
                }
                else  //显示指定小说的章节
                {
                    GetChapters(Tools.source.ID, novel);
                }
            });
            t.IsBackground = true;
            t.Start();
        }
        List<ListViewItem> itemsLv1;
        List<int> sourceIndex;
        /// <summary>
        /// 获得每个小说、每个来源的章节数目统计
        /// </summary>
        void GetChapterCount()
        {
            string sql;
            DataTable table;
            if (!all)  //只显示当前小说
            {
                sql = "select webIndex,count(*) from chapters where novel=@novel GROUP BY webIndex";
                List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                parameters.Add(new SQLiteParameter("novel", novel));
                table = MySqlite.GetData(sql, parameters);
            }
            else  //显示所有小说
            {
                sql = "select webIndex,count(*),novel from chapters GROUP BY webIndex,novel ORDER BY novel,webIndex";
                table = MySqlite.GetData(sql);
                if (listView1.Columns.Count == 2)
                {
                    ColumnHeader header = new ColumnHeader();
                    header.Text = "小说名";
                    header.Width = 100;
                    listView1.Columns.Insert(0, header);
                }
            }
            itemsLv1 = new List<ListViewItem>();
            sourceIndex = new List<int>();
            listView1.Items.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int index = Convert.ToInt32(table.Rows[i][0]);
                string website = Tools.InitSource(index, false);
                string[] ss = new string[]{ website, table.Rows[i][1].ToString() };
                if (all)
                    ss = new string[] { table.Rows[i][2].ToString(), website, table.Rows[i][1].ToString() };
                ListViewItem item = new ListViewItem(ss);
                itemsLv1.Add(item);
                sourceIndex.Add(index);
            }
            listView1.Items.AddRange(itemsLv1.ToArray());
        }
        List<Chapter> chapters;
        List<ListViewItem> chapterItems;
        string chapterKeyword = "";
        private void textBox_chapter_TextChanged(object sender, EventArgs e)
        {
            //搜索章节
            chapterKeyword = textBox_chapter.Text.Trim();
            AddChaptersList();
            //在List中寻找包含关键词的第一个项的索引
            int index = chapters.FindIndex(c => c.chapter.IndexOf(chapterKeyword) > -1);
            if (index > -1)
                listView2.EnsureVisible(index);
        }
        /// <summary>
        /// 从本地数据库获取章节
        /// </summary>
        void GetChapters(int sourceID,string novel)
        {
            chapters = new List<Chapter>();
            chapterItems = new List<ListViewItem>();
            Chapter chapter;
            ListViewItem item;
            //根据小说名和网站查找
            string sql = "select * from chapters where novel=@novel and webIndex=@index";
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("index", sourceID));
            parameters.Add(new SQLiteParameter("novel", novel));
            DataTable table = MySqlite.GetData(sql,parameters);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                chapter = new Chapter();
                chapter.novel= table.Rows[i][0].ToString();
                chapter.chapter = table.Rows[i][1].ToString();
                chapter.web = Convert.ToInt32(table.Rows[i][2].ToString());
                chapter.site = table.Rows[i][3].ToString();
                chapters.Add(chapter);
                string[] ss = { chapter.chapter, chapter.site };
                item = new ListViewItem(ss);
                chapterItems.Add(item);
            }
            Invoke(new Action(delegate
            {
                AddChaptersList();
            }));
        }

        void AddChaptersList()
        {
            if (chapters == null || chapters.Count == 0)
                return;

            listView2.VirtualListSize = chapters.Count;
            listView2.RetrieveVirtualItem += Listview2ItemAdded;
        }

        private void Listview2ItemAdded(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = chapterItems[e.ItemIndex];
            e.Item.UseItemStyleForSubItems = false;
            //搜索章节，标红
            if (chapterKeyword != "" && chapters[e.ItemIndex].chapter.IndexOf(chapterKeyword) > -1)
            {
                e.Item.SubItems[0].ForeColor = Color.Red;
            }
            else
            {
                e.Item.SubItems[0].ForeColor = Color.Black;
            }
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count == 0)
                return;
            int index = listView2.SelectedIndices[0];
            Tools.InitSource(chapters[index].web);
            Close();
            Search search = (Search)Application.OpenForms["Search"];
            if (search != null)  //隐藏主界面
                search.Hide();
            ReadNovel read = (ReadNovel)Application.OpenForms["ReadNovel"];
            if (read == null)
            {
                read = new ReadNovel(chapters[index].site, novel);
                read.Show();
            }
            else
            {
                read.setSite(chapters[index].site);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;
            int index = listView1.SelectedIndices[0];
            if(all)
            {
                novel = itemsLv1[index].SubItems[0].Text;
                label_novel.Text = novel;
                label_novel.Left = (Width - label_novel.Width) / 2;
            }
            GetChapters(sourceIndex[index], novel);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定清空所有章节记录吗？", "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                //书架上面的不删
                string sql = "delete from chapters where novel not in (select distinct novel from bookshelf) or webindex not in(select distinct webindex from bookshelf) ";
                MySqlite.ExecSql(sql);
                listView1.Items.Clear();  //不是虚拟模式，直接clear就好
                listView2.VirtualListSize = 0;  //虚拟模式下，需要设置size才能清空
                GetChapterCount();//重新获取
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                button_delete.Enabled = false;
            else
            {
                int index = listView1.SelectedIndices[0];
                if (all)
                {
                    novel = itemsLv1[index].SubItems[0].Text;
                    label_novel.Text = novel;
                    label_novel.Left = (Width - label_novel.Width) / 2;
                }
                button_delete.Enabled = true;
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                int index = listView1.SelectedIndices[0];
                string sql = "delete from chapters where novel=@novel and webIndex=@web and novel not in (select distinct novel from bookshelf) or webindex not in(select distinct webindex from bookshelf) ";
                List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                parameters.Add(new SQLiteParameter("novel", novel));
                parameters.Add(new SQLiteParameter("web", sourceIndex[index]));
                MySqlite.ExecSql(sql,parameters);
                label_novel.Text = "章节管理";
                label_novel.Left = (Width - label_novel.Width) / 2;
                listView1_SelectedIndexChanged(null, null);
                GetChapterCount();
            }
        }
    }
}
