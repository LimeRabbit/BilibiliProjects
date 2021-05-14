using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilibiliProjects
{
    public class Tools
    {
        public static NovelSource source;
        public static void InitSource(int index)
        {
            Tools.source = new NovelSource();
            Tools.source.ID = index;
            switch (index)
            {
                case 0:
                    Tools.source.Site = "http://m.31xs.com/";
                    Tools.source.SearchPage = "search.php";
                    Tools.source.SearchKeyword = "keyword";
                    break;
                case 1:
                    Tools.source.Site = "https://m.uutxt.com/";
                    Tools.source.SearchPage = "SearchBook.php";
                    Tools.source.SearchKeyword = "submit=&keyword";
                    break;
            }
        }
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="bmp"></param>
        public static void SaveImage(Bitmap bmp)
        {
            if (bmp == null)
                return;

            SaveFileDialog save = new SaveFileDialog();  //保存文件对话框
            save.InitialDirectory = Directory.GetCurrentDirectory();  //初始目录
            save.Filter = "BMP图片|*.bmp";
            if (save.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(save.FileName, ImageFormat.Bmp);  //保存
                MessageBox.Show("保存完成", "提示");
            }
        }

        /// <summary>
        /// 获取所有字体
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFonts()
        {
            //获取字体
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            FontFamily[] fontFamilies = installedFontCollection.Families;
            List<string> fonts = new List<string>();
            //转为string数组
            foreach (FontFamily family in fontFamilies)
            {
                if (family.Name.StartsWith("Adobe")|| family.Name.StartsWith("Kozuka")|| family.Name.StartsWith("Bahn")|| family.Name.StartsWith("Franklin"))
                    continue;
                fonts.Add(family.Name);
            }
            return fonts;
        }
        //创建表，用于存储阅读进度
        public static void CreateTable()
        {
            string sql = "create table bookshelf(novel text,chapter text,webIndex text,site text,date text)";
            MySqlite.ExecSql(sql);
        }
        /// <summary>  
        /// 取文本中间内容  
        /// </summary>  
        /// <param name="str">原文本</param>  
        /// <param name="leftstr">左边文本</param>  
        /// <param name="rightstr">右边文本</param>  
        /// <returns>返回中间文本内容</returns>  
        public static string getBetweenText(string str, string leftstr, string rightstr)
        {
            int i = str.IndexOf(leftstr);
            if (i == -1)
                return "";
            i += leftstr.Length;

            int i2 = str.IndexOf(rightstr, i);
            string temp;
            if (i2 == -1)  //取后面所有
                temp = str.Substring(i);
            else
                temp = str.Substring(i, i2 - i);
            return temp;
        }

        /// <summary>  
        /// 批量取文本中间内容  
        /// </summary>  
        /// <param name="str">原文本</param>  
        /// <param name="leftstr">左边文本</param>  
        /// <param name="rightstr">右边文本</param>  
        /// <returns>返回中间文本内容</returns>  
        public static List<string> getAllBetweenText(string str, string leftstr, string rightstr, bool deleteHtmlTag = false)
        {
            List<string> result = new List<string>();
            int left = str.IndexOf(leftstr);
            if (left == -1) return result;
            int right = str.IndexOf(rightstr);
            if (right == -1) return result;

            while (str.IndexOf(leftstr) > -1)
            {
                int i = str.IndexOf(leftstr) + leftstr.Length;
                int i2 = str.IndexOf(rightstr, i);
                if (i2 == -1) break;
                string tmp = str.Substring(i, i2 - i).Trim();
                if(deleteHtmlTag)
                {
                    tmp = RemoveHtmlTag(tmp);
                }
                result.Add(tmp);
                str = str.Substring(i2 + rightstr.Length);
            }
            return result;
        }

        public static string ErrMsg = "";//错误信息
        /// <summary>
        /// 获取网页内容
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>网页Stream</returns>
        public static Stream GetHtml(string url)
        {
            ErrMsg = "";
            HttpWebRequest myRequest;
            if (!url.StartsWith("http")) url = "http://" + url;
            //创建 HttpWebRequest 对象
            myRequest = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                //取得response
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                //取网页流
                Stream stream = myResponse.GetResponseStream();
                return stream;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message; //出错，将错误信息存下来
                return null;
            }
        }

        /// <summary>
        /// 将Stream转为String
        /// </summary>
        /// <param name="stream">网页流</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static string streamToString(Stream stream, Encoding encoding)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;
            try
            {
                StreamReader reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                return e.ToString(); //转换失败，返回错误信息
            }
        }

        /// <summary>
        /// 去掉html标签
        /// </summary>
        /// <param name="html"></param>
        /// <param name="length">需要返回的固定长度，传入0返回所有</param>
        /// <returns></returns>
        public static string RemoveHtmlTag(string html, int length = 0)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }
    }

    /// <summary>
    /// 小说来源
    /// </summary>
    public class NovelSource
    {
        public int ID;
        public string Site;
        public string SearchPage;
        public string SearchKeyword;
    }

    class Novel
    {
        public Novel(string name, string author, string new1, string date)
        {
            this.author = Tools.RemoveHtmlTag(author);
            lastDate = date;
            indexUrl = Tools.getBetweenText(name, "href=\"", "\"");
            if (name.IndexOf("完本") > -1 || name.IndexOf("连载") > -1)
            {
                state = Tools.getBetweenText(name, "[", "]");
                //去掉“完本”“连载”
                this.name = Tools.RemoveHtmlTag(name).Substring(state.Length + 2);
            }
            else
            {
                state = "";
                this.name = Tools.RemoveHtmlTag(name);
            }
            newUrl = Tools.getBetweenText(new1, "href=\"", "\"");
            newChapter = Tools.RemoveHtmlTag(new1);
        }
        public string name;  //书名
        public string state;  //状态
        public string indexUrl;  //章节目录链接，包含域名
        public string author;  //作者
        public string newChapter;  //最新章
        public string newUrl;  //最新章链接
        public string lastDate;  //最近更新日期
    }

    public class Chapter
    {
        public Chapter()
        {}
        public Chapter(string chapter, string site)
        {
            this.chapter = chapter;
            this.site = site;
        }
        public Chapter(string novel, string chapter, string site)
        {
            this.novel = novel;
            this.chapter = chapter;
            this.site = site;
        }
        public string novel;  //小说名
        public string chapter;  //章节名
        public string site;  //地址，不包含域名
        public int web;  //地址，不包含域名
        public string lastDate;  //最后阅读时间
    }
}
