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

using System.Windows.Forms;
using System.Data.SQLite;
using BilibiliProjects;

namespace BilibiliProjects.NovelTest
{
    public partial class ReadNovel : BaseForm
    {
        Tools tools;
        string site = "m.31xs.com/";  //网站
        string preview_page, next_page, index_page; //上一页，下一页，索引页(目录页)
        string novelName, readtitle;  //书名，章节名
        private const int GetContentCode = 0;
        List<BlackWord> blackWords;  //要屏蔽和替换的词
        List<Chapter> chapters;  //当前阅读小说的所有本地章节
        Record record;  //阅读记录，屏蔽词语记录
        DateTime time_start;
        //需要传章节地址
        public ReadNovel(string address,string novelName)
        {
            InitializeComponent();
            this.novelName = novelName;
            page = address;
            Init();
        }
        private void ReadNovel_Load(object sender, EventArgs e)
        {
            //这句话一定要放在窗体Load方法中才有效，不知道为什么
            //防止自动选词，导致想选的内容选不上
            richTextBox1.AutoWordSelection = false;
        }
        void Init()
        {
            time_start = DateTime.Now;
            site = Tools.source.Site;
            label_pagesite.Text = GetCurrentSite();
            linkLabel_copy.Left = label_pagesite.Right + 5;
            richTextBox1.Font = Setting.Font;
            tools = new Tools();
            tools.HTMLGetCompleted += Tools_HTMLGetCompleted;
            GetRecord();
            GetChapters(Tools.source.ID, novelName);
            GetBlackWords();
            GetContent();
        }
        string GetCurrentSite()
        {
            return site.TrimEnd('/') + "/" + page.TrimStart('/');
        }

        /// <summary>
        /// 查询屏蔽词语
        /// </summary>
        void GetBlackWords()
        {
            blackWords = new List<BlackWord>();
            string sql = "select words,insteadWords,type from blackWords order by length(words) desc";
            DataTable table = MySqlite.GetData(sql);
            BlackWord word1;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                word1 = new BlackWord();
                string word = table.Rows[i][0].ToString().Trim();
                string instead = table.Rows[i][1].ToString().Trim();
                string type = table.Rows[i][2].ToString().Trim();
                word1.word = word;
                word1.type = type;
                word1.replacement = instead;
                blackWords.Add(word1);
            }
        }

        private void Tools_HTMLGetCompleted(WebResponseInfo responseInfo, int requestCode)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(delegate  //跨线程操作控件，需要Invoke
                {
                    AnalyzeResult(responseInfo.ResponseText, responseInfo.ErrorMessage, requestCode);
                }));
            }
            else
            {
                AnalyzeResult(responseInfo.ResponseText, responseInfo.ErrorMessage, requestCode);
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
                            string url = GetContentPage(next_page); //章节页面地址
                            tools.GetHtmlByThread(url, GetContentCode);
                        }
                        else  //本章获取完毕
                        {
                            label_pagesite.Text = GetCurrentSite();
                            Text = "《" + novelName + "》 " + readtitle;
                            richTextBox1.Focus();
                            richTextBox1.SelectionStart = 0;
                            //将当期页的信息存入数据库
                            Chapter chapter = new Chapter(novelName, readtitle, page);
                            UpdateData(chapter);
                            if(Setting.AutoSave)  //自动保存到本地
                            {
                                Button_save_Click(null, null);
                            }
                        }
                        break;
                }
            }
            button1.Enabled = true;
            button_next.Enabled = true;
            button_pre.Enabled = true;
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            GetContent(true);  //true：强制刷新，从网络获取内容
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DateTime time_end = DateTime.Now;
            record.seconds += (int)(time_end - time_start).TotalSeconds;
            SetRecordToDB();
            Search search = (Search)Application.OpenForms["Search"];
            search.Show();
        }

        //下一页
        private void button_next_Click(object sender, EventArgs e)
        {
            page = next_page;
            GetContent();
        }
        //上一页
        private void button_pre_Click(object sender, EventArgs e)
        {
            page = preview_page;
            GetContent();
        }
        string page = "";  //小说地址，不含域名
        bool hasNextPage;  //每一章是否分页
        /// <summary>
        /// 获取章节内容
        /// </summary>
        private void GetContent(bool forceRefresh=false)
        {
            //不是强制刷新，如果本地有文件，则读取
            if (!forceRefresh)
            {
                List<Chapter> tmpList = chapters.Where(c => c.site == page).ToList();
                if (tmpList.Count > 0)  //寻找一样的章节，根据网址寻找
                {
                    string chapter1 = tmpList[0].chapter;
                    string path = tmpList[0].filename;
                    if (File.Exists(path))  //读取本地内容
                    {
                        label_pagesite.Text = GetCurrentSite();
                        Text = "《" + novelName + "》 " + chapter1 + " [本地]";
                        richTextBox1.Focus();
                        richTextBox1.SelectionStart = 0;
                        //将当期页的信息存入数据库
                        Chapter chapter = new Chapter(novelName, chapter1, page);
                        UpdateData(chapter);
                        int index = chapters.IndexOf(tmpList[0]);
                        if (index < chapters.Count - 1) //下一章地址
                        {
                            next_page = chapters[index + 1].site;
                        }
                        if (index > 0)  //上一章地址
                        {
                            preview_page = chapters[index - 1].site;
                        }
                        byte[] bytes = File.ReadAllBytes(path);
                        string text;
                        if (tmpList[0].compressed)  //压缩
                        {
                            text = Compress.DecompressString(bytes);
                        }
                        else  //没有压缩
                        {
                            text = Encoding.UTF8.GetString(bytes);
                        }
                        richTextBox1.Text = text;
                        return;
                    }
                }
            }

            Text = "章节内容获取中……";
            richTextBox1.Text = "";
            button1.Enabled = false;
            button_next.Enabled = false;
            button_pre.Enabled = false;
            string url = GetContentPage(page); //章节页面地址
            tools.GetHtmlByThread(url, GetContentCode);
        }

        private void button_chapters_Click(object sender, EventArgs e)
        {
            new ChaptersList(novelName,false).ShowDialog();
        }
        //从章节列表过来，需要传地址。跳章功能
        public void setSite(string site)
        {
            page = site;
            this.site = Tools.source.Site;
            label_pagesite.Text = GetCurrentSite();
            linkLabel_copy.Left = label_pagesite.Right + 5;
            GetContent();
        }
        //右键--屏蔽
        private void 屏蔽选中词语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = richTextBox1.SelectedText.Trim();
            txt = txt.Replace("'", "''"); //单引号转义
            string type = "词语";
            //添加到数据库
            string sql = "insert into blackWords values(@word,'',@type,@date)";
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("word", txt));
            parameters.Add(new SQLiteParameter("type", type));
            parameters.Add(new SQLiteParameter("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            MySqlite.ExecSql(sql, parameters);

            string s = richTextBox1.Text;
            s = s.Replace(txt, "");
            richTextBox1.Text = s.TrimEnd();
            BlackWord word = new BlackWord();
            word.word = txt;
            word.type = type;
            word.replacement = "";
            blackWords.Add(word);
        }
        //右键--替换为
        private void 替换为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = richTextBox1.SelectedText.Trim();
            txt = txt.Replace("'", "''"); //单引号转义
            new AddBlackWord(txt).ShowDialog();
            GetBlackWords();
            string s = richTextBox1.Text;
            richTextBox1.Text = ReplaceWords(s);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (richTextBox1.SelectionLength == 0)
            {
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = false;
            }
            else
            {
                contextMenuStrip1.Items[0].Enabled = true;
                contextMenuStrip1.Items[1].Enabled = true;
            }
                UIColors.SetContextMenuColor(contextMenuStrip1);
        }

        private void button_words_Click(object sender, EventArgs e)
        {
            new BlackWords().ShowDialog(); //屏蔽词管理
            GetBlackWords();
        }

        string GetContentPage(string page)
        {
            string url;  //章节页面的地址
            switch(Tools.source.ID)
            {
                default:
                    url = site.TrimEnd('/') + page;
                    break;
                case 4:
                    url = site.TrimEnd('/') + "/files/article/html/" + page;
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
            string tmpStr;
            List<string> tmpList;
            int tmpInt;
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
                    tmpStr = Tools.GetBetweenText(s, "lastread.set(", ")");
                    tmpList = Tools.GetAllBetweenText(tmpStr, "'", "'");
                    readtitle = tmpList[3].Trim();
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
                    tmpStr = Tools.GetBetweenText(s, "pt_prev", "pt_shouye"); //从上一页/上一章，取到下一页/下一章结束
                    if(tmpStr.Contains("下ー页"))  //网页显示的不是“下一页”三个字，一/ー不一样
                    {
                        hasNextPage = true;
                    }
                    else
                    {
                        hasNextPage = false;
                    }
                    if(tmpStr.Contains("上ー章"))  //不是“上一章”，是“上ー章”
                        preview_page = Tools.GetBetweenText(s, "pt_prev\" href=\"", "\"");
                    next_page = Tools.GetBetweenText(tmpStr, "pt_next\" href=\"", "\"");
                    index_page = Tools.GetBetweenText(s, "pt_mulu\" href=\"", "\"");
                    s = Tools.GetBetweenText(s, "<div id=\"nr1\">", "</div>"); //取主体
                    s = Tools.GetBetweenText(s, "</p>", "<p>");  //去掉“最新网址”之类的废话(如果有)
                    tmpInt = s.IndexOf("（本章未完，");  //内容分页，把提示信息去掉
                    if (tmpInt > -1)
                        s = s.Substring(0, tmpInt);
                    s = Regex.Replace(s, "((\\s)|(&nbsp;))+", ""); //去除空白
                    //去掉网站的广告
                    s = Regex.Replace(s, "([\\(\\[（].*mhtxs.*[\\)\\]）])|(<strong>.*mhtxs.*</strong>)", "");  
                    s = Regex.Replace(s, "(<br\\s*/>)+", Environment.NewLine + "\t");//去掉网站的换行
                    break;
                case 3:
                    readtitle = Tools.GetBetweenText(s, "<h1>", "</h1>").Trim();
                    s = Regex.Replace(s, "\\s*", "");
                    preview_page = Tools.GetBetweenText(s, "preview_page=\"", "\"");
                    next_page = Tools.GetBetweenText(s, "next_page=\"", "\"");
                    index_page = Tools.GetBetweenText(s, "index_page=\"", "\"");
                    //取正文
                    s = Tools.GetBetweenText(s, "<divid=\"content\">", "<div");
                    s = Regex.Replace(s, "((\\s)|(&nbsp;))+", ""); //去除空白
                    s = Regex.Replace(s, "(<br\\s*/>)+", Environment.NewLine + "\t");
                    tmpInt = s.IndexOf("(未完待续。");
                    if (tmpInt > -1)
                        s = s.Substring(0, tmpInt);
                    break;
                case 4:
                    readtitle = Tools.GetBetweenText(s.ToLower(), "<h1>", "</h1>").Trim();
                    //上一章
                    tmpStr = Tools.GetBetweenText(s, "<div id=\"thumb\">", "</div>");
                    tmpList = Tools.GetAllBetweenText(tmpStr, "\"", "\"");
                    preview_page = tmpList[0].TrimStart('.');
                    next_page = tmpList[2].TrimStart('.');
                    index_page = tmpList[1];
                    s = Regex.Replace(s, "\\s*", "");
                    //取正文
                    s = Tools.GetBetweenText(s.ToLower(), "<p>", "</p>");
                    s = Regex.Replace(s, "((\\s)|(&nbsp;))+", ""); //去除空白
                    s = Regex.Replace(s, "(<br\\s*/>)+", Environment.NewLine + "\t");
                    break;
            }
            tmpInt = s.IndexOf("(本章完)");
            if (tmpInt > -1)
                s = s.Substring(0, tmpInt);

            Regex r2 = new Regex("(PS：)|(ＰＳ：)|(PS:)|(ＰＳ:)", RegexOptions.IgnoreCase);
            Match match = r2.Match(s);
            int i = s.IndexOf(match.Value);
            if (i > 100)  //去除作者写的PS之类的废话，如果在开头写PS之类的，就不要去掉
                s = s.Substring(0, i).Trim();
            //避免有形如 &#dddd; &#xdddd; 之类的字符串出现
            s = System.Web.HttpUtility.HtmlDecode(s);
            s = ReplaceWords(s);
            return s.Trim();
        }

        /// <summary>
        /// 使用已保存的规则替换词语
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        string ReplaceWords(string s)
        {
            foreach (BlackWord word in blackWords)
            {
                if (word.type == "词语" && s.Contains(word.word))
                {
                    s = s.Replace(word.word, word.replacement);  //屏蔽词
                    record.wordCount++;
                }
                else if (word.type == "正则表达式" && Regex.IsMatch(s, word.word))
                {
                    s = Regex.Replace(s, word.word, word.replacement);  //屏蔽的正则表达式
                    record.regexCount++;
                }
            }
            return s;
        }
        //打开统计页面和设置页面的时候，不需要累计阅读时间
        //所以在打开之前停止计时，关闭之后继续计时
        public override void BeforeSetting()
        {
            DateTime time_end = DateTime.Now;
            record.seconds += (int)(time_end - time_start).TotalSeconds;
            SetRecordToDB();
        }
        /// <summary>
        /// 重写父类的方法，设置窗体关闭之后的动作
        /// </summary>
        public override void AfterSetting()
        {
            richTextBox1.Font = Setting.Font;
            time_start = DateTime.Now;
        }

        public override void BeforeStatistics()
        {
            //打开统计页面之前，把时间统计一下
            DateTime time_end = DateTime.Now;
            record.seconds += (int)(time_end - time_start).TotalSeconds;
            SetRecordToDB();
        }
        public override void AfterStatistics()
        {
            //统计页面关闭之后，重新开始计时
            time_start = DateTime.Now;
        }

        private void linkLabel_copy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = label_pagesite.Text;
            Clipboard.SetText(s);
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

        private void Button_save_Click(object sender, EventArgs e)
        {
            string s = richTextBox1.Text;
            byte[] bytes;
            if(Setting.IsCompress)
            {
                bytes = Compress.CompressString(s); //压缩
            }
            else
            {
                bytes = Encoding.UTF8.GetBytes(s);  //不压缩
            }
            string path = "SavedNovels\\" + novelName;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //文件名中不能含有以下字符： \/:*?"<>|
            string filename = Regex.Replace(readtitle, "[\\\\|\\/|\\:|\\*|\\?|\"|\\<|\\>|\\|]", "");
            path += "\\" + filename + ".novel";
            try
            {
                File.WriteAllBytes(path, bytes);
                string sql = "update chapters set filename=@path,compressed=@compress where site=@site";
                List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                parameters.Add(new SQLiteParameter("path", path));
                parameters.Add(new SQLiteParameter("compress", Setting.IsCompress));
                parameters.Add(new SQLiteParameter("site", page));
                MySqlite.ExecSql(sql,parameters);
                List<Chapter> tmpList = chapters.Where(c => c.site == page).ToList();
                if(tmpList.Count>0)
                {
                    tmpList[0].filename = path;
                    tmpList[0].compressed= Setting.IsCompress;
                }
                Text = "《" + novelName + "》 " + readtitle + " [已保存]";
                if (sender != null)
                {
                    MessageBox.Show("已保存至\n" + path, "提示");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 从本地数据库获取章节，该方法是从ChaptersList中拷贝来的
        /// </summary>
        void GetChapters(int sourceID, string novel)
        {
            chapters = new List<Chapter>();
            Chapter chapter;
            //根据小说名和网站查找
            string sql = "select * from chapters where novel=@novel and webIndex=@index";
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("index", sourceID));
            parameters.Add(new SQLiteParameter("novel", novel));
            DataTable table = MySqlite.GetData(sql, parameters);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                chapter = new Chapter();
                chapter.novel = table.Rows[i][0].ToString();
                chapter.chapter = table.Rows[i][1].ToString();
                chapter.web = Convert.ToInt32(table.Rows[i][2].ToString());
                chapter.site = table.Rows[i][3].ToString();
                chapter.filename = table.Rows[i][4].ToString();
                chapter.compressed = table.Rows[i][5].ToString() != "0";
                chapters.Add(chapter);
            }
        }
        bool hasToday = true;  //record表中是否有今天的记录
        /// <summary>
        /// 获取记录
        /// </summary>
        void GetRecord()
        {
            record = new Record();
            string sql = "select * from record where date='"+DateTime.Now.ToString("yyyy-MM-dd")+"'";
            DataTable dt = MySqlite.GetData(sql);
            record.date = DateTime.Now.ToString("yyyy-MM-dd");
            if (dt.Rows.Count==0)
            {
                hasToday = false;
                record.wordCount = 0;
                record.regexCount = 0;
                record.seconds = 0;
            }
            else
            {
                hasToday = true;
                record.wordCount = Convert.ToInt32(dt.Rows[0][1]);
                record.regexCount = Convert.ToInt32(dt.Rows[0][2]);
                record.seconds = Convert.ToInt32(dt.Rows[0][3]);
            }
            
        }
        /// <summary>
        /// 写数据库
        /// </summary>
        void SetRecordToDB()
        {
            string sql;
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            if(hasToday)
            {
                sql = "update record set wordCount=@word,regexCount=@regex,readSeconds=@read where date=@date";
            }
            else
            {
                sql = "insert into record values(@date,@word,@regex,@read)";
            }
            parameters.Add(new SQLiteParameter("date", DateTime.Now.ToString("yyyy-MM-dd")));
            parameters.Add(new SQLiteParameter("word", record.wordCount));
            parameters.Add(new SQLiteParameter("regex", record.regexCount));
            parameters.Add(new SQLiteParameter("read", record.seconds));
            MySqlite.ExecSql(sql, parameters);
        }

        /// <summary>
        /// 在统计界面点击清空记录，会执行该方法
        /// </summary>
        public void ClearRecord()
        {
            time_start = DateTime.Now;
            record.wordCount = 0;
            record.regexCount = 0;
            record.seconds = 0;
        }
    }
    class BlackWord
    {
        public BlackWord() { }
        public string word;
        public string replacement;
        public string type;
        public string date;
    }
    
}
