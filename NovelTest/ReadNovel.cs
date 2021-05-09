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
    public partial class Form1 : Form
    {
        string site = "m.31xs.com/";  //网站
        readonly string file = "novel.ini"; //配置文件，储存网站、页面
        string preview_page, next_page, index_page; //上一页，下一页，索引页(目录页)
        string booktitle, readtitle;  //书名，章节名
        //直接启动该窗体，不需要传参数
        public Form1()
        {
            InitializeComponent();
            if (File.Exists(file)) //判断配置文件
            {
                string[] content = File.ReadAllLines(file, Encoding.UTF8);
                textBox_page.Text = content[0];  //章节页
                GetContent();
            }
        }
        //由搜索页调用该窗体，需要传章节地址
        public Form1(string address)
        {
            InitializeComponent();
            MySqlite.InitDB();
            if (!File.Exists(MySqlite.path))
            {
                Tools.CreateTable();  //不存在数据库，创建新表
            }
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
            if (string.IsNullOrEmpty(page) )
                return;
            string url = site + page; //章节页面地址
            Stream stream = Tools.GetHtml(url); //获取内容流
            if (stream == null)
            {
                //获取失败，显示错误信息
                richTextBox1.Text = Tools.ErrMsg;
                return;
            }
            string s = Tools.streamToString(stream,Encoding.UTF8); //流转换为文本
            //取书名和章节名
            booktitle = Tools.getBetweenText(s, "booktitle = \"", "\"");
            readtitle = Tools.getBetweenText(s, "readtitle = \"", "\"");

            Regex regex = new Regex("\\s*");  //将所有空白去除
            s = regex.Replace(s, "");
            //获取上一页、下一页、索引页的地址
            preview_page = Tools.getBetweenText(s, "preview_page=\"", "\"");
            next_page = Tools.getBetweenText(s, "next_page=\"", "\"");
            index_page = Tools.getBetweenText(s, "index_page=\"", "\"");
            //显示的上一页、下一页、索引页的页面
            index_page = index_page.TrimStart('/');

            //取正文
            s = Tools.getBetweenText(s, "<p>", "<div");
            //将p标签去除，并且每行的行首加上缩进
            s = s.Replace("<p>", "").Replace("</p>", Environment.NewLine+"\t");
            int i;
            if ((i = s.IndexOf("PS：")) > -1)  //去除作者写的PS之类的废话
                s = s.Substring(0, i).Trim();
            s = "\t" + s;  //首行行首加缩进

            richTextBox1.Text = s; //小说内容
            label_book.Text = "《" + booktitle + "》 "+readtitle;

            //将当期页的信息存入数据库
            Chapter chapter = new Chapter(booktitle, readtitle,page);
            UpdateData(chapter);
            
        }

        void UpdateData(Chapter chapter)
        {
            string sql = "select count(*) from bookshelf where novel=@novel";
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("novel", booktitle));
            int c = MySqlite.GetCount(sql, parameters);
            if (c == 0)//新增
            {
                sql = "insert into bookshelf values(@novel,@chapter,@site,@date)";
            }
            else//更新
            {
                sql = "update bookshelf set chapter=@chapter,site=@site,date=@date where novel=@novel";
            }
            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("novel", chapter.novel));
            parameters.Add(new SQLiteParameter("chapter", chapter.chapter));
            parameters.Add(new SQLiteParameter("site", chapter.site));
            parameters.Add(new SQLiteParameter("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            MySqlite.ExecSql(sql, parameters);
        }
        
    }
}
