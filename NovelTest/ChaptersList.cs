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
        public ChaptersList(string novel)
        {
            InitializeComponent();
            this.novel = novel;
            label_novel.Text = novel;
            label_novel.Left = (Width - label_novel.Width) / 2;
            Thread t = new Thread(GetChapters);
            t.IsBackground = true;
            t.Start();
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
        void GetChapters()
        {
            chapters = new List<Chapter>();
            chapterItems = new List<ListViewItem>();
            Chapter chapter;
            ListViewItem item;
            //根据小说名和网站查找
            string sql = "select * from chapters where novel=@novel and webIndex=@index";
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("index", Tools.source.ID));
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
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count == 0)
                return;
            int index = listView2.SelectedIndices[0];
            Tools.InitSource(chapters[index].web);
            Close();
            ReadNovel read = (ReadNovel)Application.OpenForms["ReadNovel"];
            read.setSite(chapters[index].site);
        }
    }
}
