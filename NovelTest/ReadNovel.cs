using System;
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

namespace BilibiliProjects
{
    public partial class ReadNovel : Form
    {
        string site = "m.31xs.com/";  //网站
        string preview_page, next_page, index_page; //上一页，下一页，索引页(目录页)
        string booktitle, readtitle;  //书名，章节名
        //需要传章节地址
        public ReadNovel(string address)
        {
            InitializeComponent();
            site = Tools.source.Site;
            textBox_page.Text = address;
            GetContent();
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
        /// <summary>
        /// 获取章节内容
        /// </summary>
        private void GetContent()
        {
            //章节页地址
            string page = textBox_page.Text.Trim();
            //非空判断
            if (string.IsNullOrEmpty(page))
                return;
            string url = site + page; //章节页面地址
            Stream stream = Tools.GetHtml(url); //获取内容流
            if (stream == null)
            {
                //获取失败，显示错误信息
                richTextBox1.Text = Tools.ErrMsg;
                return;
            }
            string s = Tools.streamToString(stream, Encoding.UTF8); //流转换为文本
            s = AnalyzeContent(s);

            richTextBox1.Text = s; //小说内容
            richTextBox1.Focus();
            richTextBox1.SelectionStart = 0;
            label_book.Text = "《" + booktitle + "》 " + readtitle;

            //将当期页的信息存入数据库
            Chapter chapter = new Chapter(booktitle, readtitle, page);
            UpdateData(chapter);
        }

        string GetContentPage(string page)
        {
            string url = "";
            switch(Tools.source.ID)
            {
                case 0:
                    url = site + page;
                    break;
                case 1:
                    url = site + page;
                    break;
            }
            return url;
        }

        private string AnalyzeContent(string s)
        {
            string tmp;
            List<string> tmp1;
            //取书名和章节名
            switch (Tools.source.ID)
            {
                case 0:
                    booktitle = Tools.getBetweenText(s, "booktitle = \"", "\"");
                    readtitle = Tools.getBetweenText(s, "readtitle = \"", "\"");
                    s = Regex.Replace(s, "\\s*", "");
                    //获取上一页、下一页、索引页的地址
                    preview_page = Tools.getBetweenText(s, "preview_page=\"", "\"");
                    next_page = Tools.getBetweenText(s, "next_page=\"", "\"");
                    index_page = Tools.getBetweenText(s, "index_page=\"", "\"");
                    //显示的上一页、下一页、索引页的页面
                    index_page = index_page.TrimStart('/');
                    //取正文
                    s = Tools.getBetweenText(s, "<p>", "<div");
                    //将p标签去除，并且每行的行首加上缩进
                    s = s.Replace("<p>", "").Replace("</p>", Environment.NewLine + "\t");
                    break;
                case 1:
                    tmp = Tools.getBetweenText(s, "lastread.set(", ")");
                    tmp1 = Tools.getAllBetweenText(tmp, "'", "'");
                    booktitle = tmp1[2];
                    readtitle = tmp1[3].Trim();
                    preview_page = Tools.getBetweenText(s, "pt_prev\" href = \"", "\"");
                    next_page = Tools.getBetweenText(s, "pt_next\" href = \"", "\"");
                    index_page = Tools.getBetweenText(s, "pt_mulu\" href = \"", "\"");
                    s = Tools.getBetweenText(s, "<div id=\"nr1\">", "</div>");
                    s= Regex.Replace(s, "\\s*", "");
                    s = Regex.Replace(s, "(<br/>)+", Environment.NewLine+"\t");
                    break;
            }

            int i;
            Regex r2 = new Regex("(PS：)|(ＰＳ：)",RegexOptions.IgnoreCase);
            Match match = r2.Match(s);
            i = s.IndexOf(match.Value);
            if (i > 100)  //去除作者写的PS之类的废话，如果在开头写PS之类的，就不要去掉
                s = s.Substring(0, i).Trim();
            s = "\t" + s;  //首行行首加缩进
            return s;
        }

        void UpdateData(Chapter chapter)
        {
            //先查询是否读过该小说
            string sql = "select count(*) from bookshelf where novel=@novel";
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("novel", booktitle));
            int c = MySqlite.GetCount(sql, parameters);
            if (c == 0)//没读过，新增
            {
                sql = "insert into bookshelf values(@novel,@chapter,@webIndex,@site,@date)";
            }
            else//读过，更新
            {
                sql = "update bookshelf set chapter=@chapter,webIndex=@webIndex,site=@site,date=@date where novel=@novel";
            }
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
