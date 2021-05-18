using BilibiliProjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace BilibiliProjects.NovelTest
{
    public partial class Search : Form
    {
        List<Novel> novels;  //搜索页的小说列表
        List<Chapter> chapters;  //章节列表
        //用于网络请求，获取返回值需要判断
        private const int SearchCode = 0;
        private const int ChapterCode = 1;
        Tools webTools;

        public Search()
        {
            InitializeComponent();
            Width = listView2.Left;
            comboBox_Source.SelectedIndex = 0;
            MySqlite.InitDB();
            if (!File.Exists(MySqlite.path))
            {
                Tools.CreateTable();  //不存在数据库，创建新表
            }

            webTools = new Tools();
            //网络请求结束的事件
            webTools.HTMLGetCompleted += Tools_HTMLGetCompleted;
        }

        private void Tools_HTMLGetCompleted(string result, string errorMsg, int requestCode)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(delegate  //跨线程操作控件，需要Invoke
                {
                    AnalyzeResult(result, errorMsg, requestCode);
                }));
            }
            else
            {
                AnalyzeResult(result, errorMsg, requestCode);
            }
        }
        /// <summary>
        /// 解析返回结果
        /// </summary>
        /// <param name="s"></param>
        /// <param name="errorMsg"></param>
        /// <param name="requestCode"></param>
        void AnalyzeResult(string s, string errorMsg, int requestCode)
        {
            if (errorMsg != null)
            {
                MessageBox.Show(errorMsg);
                label_state.Text = "";
            }
            else
            {
                switch (requestCode)
                {
                    case SearchCode: //搜索
                        GetSearchResult(s);
                        label_state.Text = "";
                        break;
                    case ChapterCode:  //获取章节列表
                        GetChapterResult(s);
                        break;
                }
            }
            textBox_keyword.Enabled = true;
            comboBox_Source.Enabled = true;
            button_ok.Enabled = true;
            button_mybooks.Enabled = true;
        }

        //按下回车键，搜索
        private void textBox_keyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchNovel();
            }
        }
        //按搜索按钮
        private void button_ok_Click(object sender, EventArgs e)
        {
            SearchNovel();
        }

        /// <summary>
        /// 搜索
        /// </summary>
        private void SearchNovel()
        {
            string keyword = textBox_keyword.Text.Trim();
            if (keyword.Length == 0)
                return;
            label_state.Text = "搜索中……";
            textBox_keyword.Enabled = false;
            comboBox_Source.Enabled = false;
            button_ok.Enabled = false;
            button_mybooks.Enabled = false;
            listView1.Items.Clear();
            novels = new List<Novel>();
            //搜索的链接和参数
            string url = GetSearchUrl(keyword);
            webTools.GetHtmlByThread(url, SearchCode);
        }

        /// <summary>
        /// 把搜索结果添加到列表
        /// </summary>
        /// <param name="s"></param>
        private void GetSearchResult(string s)
        {
            string keyword = textBox_keyword.Text.Trim();
            List<string> names = new List<string>();
            List<string> authors = new List<string>();
            List<string> new1 = new List<string>();
            List<string> dates = new List<string>();
            //解析
            AnalyzeSearchResult(s, ref names, ref authors, ref new1, ref dates);
            List<ListViewItem> items = new List<ListViewItem>();
            ListViewItem item;
            Novel novel;
            for (int i = 0; i < names.Count; i++)
            {
                novel = new Novel(names[i], authors[i], new1[i], dates[i]);
                novels.Add(novel);
                string[] subItem = { novel.name, novel.state, novel.author,
                    novel.newChapter, novel.lastDate };
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

        /// <summary>
        /// 获取搜索页面和参数
        /// </summary>
        string GetSearchUrl(string keyword)
        {
            string url = "";
            switch (Tools.source.ID)
            {
                case 0:
                case 1:
                case 2:
                    url= Tools.source.Site + Tools.source.SearchPage + "?" + Tools.source.SearchKeyword + "=" + HttpUtility.UrlEncode(keyword);
                    break;
            }
            return url;
        }

        /// <summary>
        /// 搜索结果解析
        /// </summary>
        void AnalyzeSearchResult(string s, ref List<string> names, ref List<string> authors, ref List<string> new1, ref List<string> dates)
        {
            switch (Tools.source.ID)
            {
                case 0:
                    //所有书名
                    names = Tools.GetAllBetweenText(s, "<dt>", "</dt>");
                    //所有作者名
                    authors = Tools.GetAllBetweenText(s, "<p>作者：", "</p>");
                    //所有最新章
                    new1 = Tools.GetAllBetweenText(s, "<p>最新：", "</a>");
                    //所有最近更新日期
                    dates = Tools.GetAllBetweenText(s, "<p>更新：", "</p>");
                    break;
                case 1:
                    names = Tools.GetAllBetweenText(s, "<h4 class=\"bookname\">", "</h4>");
                    authors = Tools.GetAllBetweenText(s, ">作者：", "</div>");
                    new1 = Tools.GetAllBetweenText(s, "<span>更新至：</span>", "</div>");
                    for (int i = 0; i < names.Count; i++)
                    {
                        dates.Add("");
                    }
                    break;
                case 2:
                    //所有书名
                    names = Tools.GetAllBetweenText(s, "block_txt\">", "</h2>");
                    //所有作者名
                    authors = Tools.GetAllBetweenText(s, ">作者：", "</p>");
                    //所有最新章
                    new1 = Tools.GetAllBetweenText(s, "最新章节：", "</a>");
                    //所有最近更新日期
                    for (int i = 0; i < names.Count; i++)
                    {
                        dates.Add("");
                    }
                    break;
            }
        }

        bool showItem = false;  //是否显示章节列表
        private void 章节列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showItem = true;
            GetChapter();
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            showItem = true;
            GetChapter();
        }

        List<ListViewItem> chapterItems;
        string tmpNovelName = "";
        /// <summary>
        /// 获取章节列表
        /// </summary>
        void GetChapter()
        {
            if (listView1.SelectedIndices.Count == 0)
                return;
            listView2.Items.Clear();
            label_state.Text = "获取中……";
            textBox_keyword.Enabled = false;
            comboBox_Source.Enabled = false;
            button_ok.Enabled = false;
            button_mybooks.Enabled = false;
            allUrls = new List<string>();
            int index = listView1.SelectedIndices[0];
            tmpNovelName = listView1.Items[index].SubItems[0].Text;
            chapters = new List<Chapter>();
            chapterItems = new List<ListViewItem>();
            Novel novel = novels[index];
            //章节列表
            string url = GetChapterLink(novel);
            webTools.GetHtmlByThread(url, ChapterCode);
        }

        List<string> allUrls;  //对于章节列表分页的网站，该变量储存每一页的页面链接
        int allUrlIndex = 1;  //当期访问的 allUrls 的索引
        private void GetChapterResult(string s)
        {
            AnalyzeChapters(s);
            if (showItem)
            {
                AddChaptersList();
                Width = listView2.Right + 30;
            }
            else if (chapters.Count > 0)  //阅读第一章
                ReadChapter(chapters[0].site,chapters[0].novel);
            if(Tools.source.ID==2) //章节列表分页，需要获取每一页
            {
                if (allUrlIndex < allUrls.Count)
                {
                    label_state.Text = "获取中："+allUrls[allUrlIndex];
                    webTools.GetHtmlByThread(Tools.source.Site+ allUrls[allUrlIndex], ChapterCode);
                    allUrlIndex++;
                }
                else  //所有页都获取了，存入数据库
                {
                    label_state.Text = "";
                    Thread t = new Thread(InsertDB);
                    t.Start();
                }
            }
            else  //存数据库
            {
                Thread t = new Thread(InsertDB);
                t.Start();
            }
        }

        /// <summary>
        /// 解析章节信息
        /// </summary>
        /// <param name="s"></param>
        private void AnalyzeChapters(string s)
        {
            string tmpStr;
            Regex r_site = new Regex("");  //章节地址
            Regex r_chapter = new Regex("");  //章节名
            switch (Tools.source.ID)
            {
                case 0:
                    s = Tools.GetBetweenText(s, "<ul class=\"am-list am-list-striped\">", "</ul>").Trim();
                    r_site = new Regex(@"/\d*/\d*/\d*\.html");
                    //以 "> 开头、以 </a 结尾，但是不要包含这两个串，只取中间部分
                    r_chapter = new Regex("(?<=\">).*(?=</a)");
                    break;
                case 1:
                    s = Tools.GetBetweenText(s, "<ul class=\"chapter\">", "</ul>").Trim();
                    r_site = new Regex(@"/book/\d*/\d*/\d*\.html");
                    //以 "> 开头、以 </a 结尾，但是不要包含这两个串，只取中间部分
                    r_chapter = new Regex("(?<=\">).*(?=</a)");
                    break;
                case 2:
                    if(allUrls==null||allUrls.Count==0)
                    {
                        tmpStr = Tools.GetBetweenText(s, "<select", "</select>"); //页数列表
                        allUrls = Tools.GetAllBetweenText(tmpStr, "value=\"", "\"");
                    }
                    s= Tools.GetBetweenText(s, "<dl><dt></dt>", "</dl>").Trim();
                    r_site = new Regex(@"/\d*/\d*\.html");
                    //以 "> 开头、以 </a 结尾，但是不要包含这两个串，只取中间部分
                    r_chapter = new Regex("(?<=\">).*(?=</a)");
                    break;
            }
            MatchCollection matches_site = r_site.Matches(s);
            MatchCollection matches_chapter = r_chapter.Matches(s);
            for (int i = 0; i < matches_site.Count; i++)
            {
                string site = matches_site[i].Value;
                string name = matches_chapter[i].Value;
                chapters.Add(new Chapter(tmpNovelName,name, site));
                if (showItem)
                    chapterItems.Add(new ListViewItem(new string[] { name, site }));
            }
        }
        /// <summary>
        /// 获取章节列表的url
        /// </summary>
        string GetChapterLink(Novel novel)
        {
            string link = "";
            switch(Tools.source.ID)
            {
                case 0:
                    link= novel.indexUrl + "index.htm";
                    break;
                case 1:
                    string tmp = novel.indexUrl.TrimEnd('/');
                    int index = tmp.LastIndexOf("/");
                    link = Tools.source.Site + "booklist" + tmp.Substring(index)+".html";
                    break;
                case 2:
                    link =Tools.source.Site+ novel.indexUrl + "page-1.html";
                    break;
            }
            return link;
        }

        /// <summary>
        /// 把章节列表存入数据库，以便在阅读界面调用
        /// </summary>
        void InsertDB()
        {
            //删除原有的
            string sql = "delete from chapters where webIndex=@ID and novel=@novel";
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("ID", Tools.source.ID));
            parameters.Add(new SQLiteParameter("novel", tmpNovelName));
            MySqlite.ExecSql(sql, parameters);
            //插入新的
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < chapters.Count; i++)
            {
                sb.Append("insert into chapters values('");
                sb.Append(tmpNovelName).Append("','");  //小说名
                sb.Append(chapters[i].chapter).Append("',"); //章节名
                sb.Append(Tools.source.ID).Append(",'");  //网站索引
                sb.Append(chapters[i].site).Append("');");  //小说地址
                if (i % 200 == 0 || i == chapters.Count - 1)
                {
                    MySqlite.ExecSql(sb.ToString());
                    sb = new StringBuilder();
                }
            }
        }

        void ReadChapter(string address,string novelName)
        {
            new ReadNovel(address,novelName).Show();//阅读界面
            Hide();
        }

        string chapterKeyword = "";  //搜索章节的关键词
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
        /// <summary>
        /// 虚拟模式添加数据
        /// </summary>
        void AddChaptersList()
        {
            if (chapterItems == null || chapterItems.Count == 0)
                return;

            listView2.VirtualListSize = chapterItems.Count;
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
            ReadChapter(chapters[index].site,chapters[index].novel);
        }

        private void 开始阅读ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            showItem = false;
            GetChapter();  //不需要显示，直接阅读
        }

        private void button_hideChapter_Click(object sender, EventArgs e)
        {
            Width = listView2.Left;
        }

        private void button_mybooks_Click(object sender, EventArgs e)
        {
            BookShelf book = new BookShelf(this);  //书架
            book.Show();
            Hide();
        }

        private void comboBox_Source_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox_Source.SelectedIndex;
            Tools.InitSource(index);
            SearchNovel();
        }
    }
}
