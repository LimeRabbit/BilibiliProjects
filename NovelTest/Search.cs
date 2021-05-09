using BilibiliProjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace BilibiliProjects
{
    public partial class Search : Form
    {
        List<Novel> novels;
        List<Chapter> chapters;
        string site = "http://m.31xs.com/";
        public Search()
        {
            InitializeComponent();
            Width = listView2.Left;
        }


        private void textBox_keyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchNovel();
            }
        }
        private void button_ok_Click(object sender, EventArgs e)
        {
            SearchNovel();

        }

        private void SearchNovel()
        {
            listView1.Items.Clear();
               novels = new List<Novel>();
            string keyword = textBox_keyword.Text.Trim();
            //搜索的链接和参数
            string url = site + "search.php?keyword=" + HttpUtility.UrlEncode(keyword);
            Stream stream = Tools.GetHtml(url);
            string s = Tools.streamToString(stream, Encoding.UTF8);
            //所有书名
            List<string> names = Tools.getAllBetweenText(s, "<dt>", "</dt>");
            //所有作者名
            List<string> authors = Tools.getAllBetweenText(s, "<p>作者：", "</p>");
            //所有最新章
            List<string> new1 = Tools.getAllBetweenText(s, "<p>最新：", "</a>");
            //所有最近更新日期
            List<string> dates = Tools.getAllBetweenText(s, "<p>更新：", "</p>");

            List<ListViewItem> items = new List<ListViewItem>();
            ListViewItem item;
            Novel novel;
            for (int i = 0; i < names.Count; i++)
            {
                novel = new Novel(names[i], authors[i], new1[i], dates[i]);
                novels.Add(novel);
                string[] subItem = { novel.name, novel.state, novel.author, novel.newChapter, novel.lastDate };
                item = new ListViewItem(subItem);
                //书名和作者中有关键字，则标红
                item.UseItemStyleForSubItems = false;
                if (novel.name.IndexOf(keyword) > -1)
                    item.SubItems[0].ForeColor = Color.Red;
                if (novel.author.IndexOf(keyword) > -1)
                    item.SubItems[2].ForeColor = Color.Red;
                //完本的用蓝色标注
                if (novel.state == "完本")
                    item.SubItems[1].ForeColor = Color.Blue;
                items.Add(item);
            }
            listView1.Items.AddRange(items.ToArray());
        }

        private void 章节列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetChapter(true);
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            GetChapter(true);
        }

        List<ListViewItem> chapterItems;
        void GetChapter(bool showItem)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            int index = listView1.SelectedIndices[0];
            chapters = new List<Chapter>();
            chapterItems = new List<ListViewItem>();
            Novel novel = novels[index];
            //章节列表
            string url = novel.indexUrl + "index.htm";
            Stream stream = Tools.GetHtml(url);
            string s = Tools.streamToString(stream, Encoding.UTF8);
            s = Tools.getBetweenText(s, "<ul class=\"am-list am-list-striped\">", "</ul>").Trim();
            Regex r_site = new Regex(@"/\d*/\d*/\d*\.html");
            //以 "> 开头、以 </a 结尾，但是不要包含这两个串，只取中间部分
            Regex r_chapter = new Regex("(?<=\">).*(?=</a)");
            MatchCollection matches = r_site.Matches(s);
            MatchCollection matches1 = r_chapter.Matches(s);
            for (int i = 0; i < matches.Count; i++)
            {
                string site = matches[i].Value;
                string name = matches1[i].Value;
                chapters.Add(new Chapter(name, site));
                if(showItem)
                    chapterItems.Add(new ListViewItem(new string[] { name, site }));
            }
            if (showItem)
            {
                AddChaptersList();
                Width = listView2.Right + 30;
            }
            else if (chapters.Count > 0)  //阅读第一章
                ReadChapter(chapters[0].site);
        }

        void ReadChapter(string address)
        {
            new Form1(address).Show();
            Hide();
        }

        string chapterKeyword = "";
        private void textBox_chapter_TextChanged(object sender, EventArgs e)
        {
            //搜索章节
            chapterKeyword = textBox_chapter.Text.Trim();
            AddChaptersList();
            //在List中寻找包含关键词的第一个项的索引
            int index=chapters.FindIndex(c => c.chapter.IndexOf(chapterKeyword) > -1);
            if(index>-1)
                listView2.EnsureVisible(index);
        }

        void AddChaptersList()
        {
            listView2.Items.Clear();
            if (chapterItems == null)
                return;

            listView2.VirtualListSize = chapterItems.Count;
            listView2.RetrieveVirtualItem += Listview2ItemAdded;
        }

        private void Listview2ItemAdded(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (chapterItems == null || chapterItems.Count == 0)
                return;
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
            ReadChapter(chapters[index].site);
        }

        private void 开始阅读ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetChapter(false);  //不需要显示
        }

        private void button_hideChapter_Click(object sender, EventArgs e)
        {
            Width = listView2.Left;
        }

        private void button_mybooks_Click(object sender, EventArgs e)
        {
            BookShelf book = new BookShelf(this);
            book.Show();
            Hide();
        }
    }

    
}
