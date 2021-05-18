﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;                                                                                                    
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using BilibiliProjects;

namespace BilibiliProjects.NovelTest
{
    public partial class ReadNovel : Form
    {
        Tools tools;
        string site = "m.31xs.com/";  //网站
        string preview_page, next_page, index_page; //上一页，下一页，索引页(目录页)
        string novelName, readtitle;  //书名，章节名
        private const int GetContentCode = 0;
        List<string> words;  //直接替换的词语
        List<string> regexes;  //要替换的正则表达式
        //需要传章节地址
        public ReadNovel(string address,string novelName)
        {
            InitializeComponent();
            this.novelName = novelName;
            site = Tools.source.Site;
            label_source.Text = "当前来源："+site;
            textBox_page.Text = address;
            tools = new Tools();
            tools.HTMLGetCompleted += Tools_HTMLGetCompleted;
            GetBlackWords();
            GetContent();
        }

        /// <summary>
        /// 查询屏蔽词语
        /// </summary>
        void GetBlackWords()
        {
            words = new List<string>();
            regexes = new List<string>();
            string sql = "select words,type from blackWords";
            DataTable table = MySqlite.GetData(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string word = table.Rows[i][0].ToString().Trim();
                string type= table.Rows[i][1].ToString().Trim();
                if (type == "词语")
                    words.Add(word);
                else
                    regexes.Add(word);
            }
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
                richTextBox1.Text = errorMsg;
                label_book.Text = "";
            }
            else
            {
                switch (requestCode)
                {
                    case GetContentCode:
                        if (string.IsNullOrEmpty(s))
                        {
                            richTextBox1.Text = "（空内容）";
                            return;
                        }
                        s = AnalyzeContent(s);  //解析
                        if (string.IsNullOrEmpty(richTextBox1.Text))
                            richTextBox1.AppendText("\t");
                        richTextBox1.AppendText(s); //追加内容
                        if (hasNextPage)  //如果小说内容也分页的话
                        {
                            label_book.Text = "获取中：" + next_page;
                            string url = GetContentPage(next_page); //章节页面地址
                            tools.GetHtmlByThread(url, GetContentCode);
                        }
                        else  //本章获取完毕
                        {
                            label_book.Text = "《" + novelName + "》 " + readtitle;
                            richTextBox1.Focus();
                            richTextBox1.SelectionStart = 0;
                            //将当期页的信息存入数据库
                            Chapter chapter = new Chapter(novelName, readtitle, page);
                            UpdateData(chapter);
                        }
                        break;
                }
            }
            textBox_page.Enabled = true;
            button1.Enabled = true;
            button_next.Enabled = true;
            button_pre.Enabled = true;
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            GetContent();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Search search = (Search)Application.OpenForms["Search"];
            search.Show();
        }

        //下一页
        private void button_next_Click(object sender, EventArgs e)
        {
            textBox_page.Text = next_page;
            GetContent();
        }
        //上一页
        private void button_pre_Click(object sender, EventArgs e)
        {
            textBox_page.Text = preview_page;
            GetContent();
        }
        string page = "";  //小说地址，不含域名
        bool hasNextPage;  //每一章是否分页
        /// <summary>
        /// 获取章节内容
        /// </summary>
        private void GetContent()
        {
            //章节页地址
            page = textBox_page.Text.Trim();
            //非空判断
            if (string.IsNullOrEmpty(page))
                return;
            richTextBox1.Text = "";
            label_book.Text = "获取中……";
            textBox_page.Enabled = false;
            button1.Enabled = false;
            button_next.Enabled = false;
            button_pre.Enabled = false;
            string url = GetContentPage(page); //章节页面地址
            tools.GetHtmlByThread(url, GetContentCode);
        }

        private void button_chapters_Click(object sender, EventArgs e)
        {
            new ChaptersList(novelName).ShowDialog();
        }
        //从章节列表过来，需要传地址。跳章功能
        public void setSite(string site)
        {
            textBox_page.Text = site;
            GetContent();
        }
        //右键-添加到屏蔽词
        private void 屏蔽选中词语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = richTextBox1.SelectedText.Trim();
            txt = txt.Replace("'", "''"); //单引号转义
            string type = "词语";
            //添加到数据库
            string sql = "insert into blackWords values(@word,@type,@date)";
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("word", txt));
            parameters.Add(new SQLiteParameter("type", type));
            parameters.Add(new SQLiteParameter("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            MySqlite.ExecSql(sql, parameters);

            string s = richTextBox1.Text;
            s = s.Replace(txt, "");
            richTextBox1.Text = s;
            words.Add(txt);  //添加到屏蔽列表
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (richTextBox1.SelectionLength == 0)
                contextMenuStrip1.Items[0].Enabled = false;
            else
                contextMenuStrip1.Items[0].Enabled = true;
        }

        private void button_words_Click(object sender, EventArgs e)
        {
            new BlackWords().ShowDialog(); //屏蔽词管理
            GetBlackWords();
        }

        string GetContentPage(string page)
        {
            string url = "";  //章节页面的地址
            switch(Tools.source.ID)
            {
                case 0:
                case 1:
                case 2:
                    url = site.TrimEnd('/') + page;
                    break;
            }
            return url;
        }
        /// <summary>
        /// 解析内容
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string AnalyzeContent(string s)
        {
            string tmp;
            List<string> tmp1;
            //章节名，上一页，下一页
            switch (Tools.source.ID)
            {
                case 0:
                    readtitle = Tools.GetBetweenText(s, "readtitle = \"", "\"");
                    s = Regex.Replace(s, "\\s*", "");
                    //获取上一页、下一页、索引页的地址
                    preview_page = Tools.GetBetweenText(s, "preview_page=\"", "\"");
                    next_page = Tools.GetBetweenText(s, "next_page=\"", "\"");
                    index_page = Tools.GetBetweenText(s, "index_page=\"", "\"");
                    //显示的上一页、下一页、索引页的页面
                    index_page = index_page.TrimStart('/');
                    //取正文
                    s = Tools.GetBetweenText(s, "<p>", "<div");
                    //将p标签去除，并且每行的行首加上缩进
                    s = s.Replace("<p>", "").Replace("</p>", Environment.NewLine + "\t");
                    break;
                case 1:
                    tmp = Tools.GetBetweenText(s, "lastread.set(", ")");
                    tmp1 = Tools.GetAllBetweenText(tmp, "'", "'");
                    readtitle = tmp1[3].Trim();
                    s = s.Substring(s.IndexOf("<div id=\"nr1\">"));
                    preview_page = Tools.GetBetweenText(s, "pt_prev\" href=\"", "\"");
                    next_page = Tools.GetBetweenText(s, "pt_next\" href=\"", "\"");
                    index_page = Tools.GetBetweenText(s, "pt_mulu\" href=\"", "\"");
                    s = Tools.GetBetweenText(s, "<div id=\"nr1\">", "</div>");
                    s= Regex.Replace(s, "\\s*", "");
                    s = Regex.Replace(s, "(<br/>)+", Environment.NewLine+"\t");
                    break;
                case 2:
                    readtitle = Tools.GetBetweenText(s, "<h1 id=\"_bqgmb_h1\">", "</h1>");
                    tmp = Tools.GetBetweenText(s, "pt_prev", "pt_shouye"); //从上一页/上一章，取到下一页/下一章结束
                    if(tmp.Contains("下ー页"))  //网页显示的不是“下一页”三个字，一/ー不一样
                    {
                        hasNextPage = true;
                    }
                    else
                    {
                        hasNextPage = false;
                    }
                    if(tmp.Contains("上ー章"))  //不是“上一章”，是“上ー章”
                        preview_page = Tools.GetBetweenText(s, "pt_prev\" href=\"", "\"");
                    next_page = Tools.GetBetweenText(tmp, "pt_next\" href=\"", "\"");
                    index_page = Tools.GetBetweenText(s, "pt_mulu\" href=\"", "\"");
                    s = Tools.GetBetweenText(s, "<div id=\"nr1\">", "</div>"); //取主体
                    s = Tools.GetBetweenText(s, "</p>", "<p>");  //去掉“最新网址”之类的废话(如果有)
                    int index = s.IndexOf("（本章未完，");  //内容分页，把提示信息去掉
                    if (index > -1)
                        s = s.Substring(0, index);
                    s = Regex.Replace(s, "((\\s)|(&nbsp;))+", ""); //去除空白
                    //去掉网站的广告
                    s = Regex.Replace(s, "([\\(\\[（].*mhtxs.*[\\)\\]）])|(<strong>.*mhtxs.*</strong>)", "");  
                    s = Regex.Replace(s, "(<br\\s*/>)+", Environment.NewLine + "\t");//去掉网站的换行
                    break;
            }

            Regex r2 = new Regex("(PS：)|(ＰＳ：)|(PS:)|(ＰＳ:)", RegexOptions.IgnoreCase);
            Match match = r2.Match(s);
            int i = s.IndexOf(match.Value);
            if (i > 100)  //去除作者写的PS之类的废话，如果在开头写PS之类的，就不要去掉
                s = s.Substring(0, i).Trim();
            foreach (string w in words)
            {
                s = s.Replace(w, "");  //屏蔽词
            }
            foreach (string r in regexes)
            {
                s= Regex.Replace(s, r, "");  //屏蔽的正则表达式
            }
            return s.Trim();
        }

        /// <summary>
        /// 阅读记录存入数据库，在书架页面会查询
        /// </summary>
        /// <param name="chapter"></param>
        void UpdateData(Chapter chapter)
        {
            //删除原有的
            string sql = "delete from bookshelf where novel=@novel";
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("novel", novelName));
            MySqlite.ExecSql(sql, parameters);
            //添加新的记录
            sql = "insert into bookshelf values(@novel,@chapter,@webIndex,@site,@date)";
            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("novel", chapter.novel));
            parameters.Add(new SQLiteParameter("chapter", chapter.chapter));
            parameters.Add(new SQLiteParameter("webIndex", Tools.source.ID));
            parameters.Add(new SQLiteParameter("site", chapter.site));
            parameters.Add(new SQLiteParameter("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            MySqlite.ExecSql(sql, parameters);
        }
        
    }
}
