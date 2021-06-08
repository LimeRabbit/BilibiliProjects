using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilibiliProjects
{
    public class Tools
    {
        public static NovelSource source;
        /// <summary>
        /// 初始化NovelSource，公共变量
        /// </summary>
        /// <param name="index">首页下拉框索引</param>
        public static string InitSource(int index, bool instead = true)
        {
            NovelSource source1 = new NovelSource();
            source1.ID = index;
            switch (index)
            {
                case 0:  //31小说网
                    source1.Site = "http://m.31xs.com/";
                    source1.SearchPage = "search.php";
                    source1.SearchKeyword = "keyword";
                    break;
                case 1:  //悠悠书盟
                    source1.Site = "https://m.uutxt.com/";
                    source1.SearchPage = "SearchBook.php";
                    source1.SearchKeyword = "submit=&keyword";
                    break;
                case 2:   //棉花糖小说
                    source1.Site = "http://m.mhtxs.la/";
                    source1.SearchPage = "search.php";
                    source1.SearchKeyword = "submit=&searchkey";
                    break;
                case 3:   //天域
                    source1.Site = "http://www.tycqxs.com/";
                    source1.SearchPage = "search.php";
                    source1.SearchKeyword = "searchkey";
                    break;
                case 4:  //56书库
                    source1.Site = "http://www.liuxs.la/";
                    source1.SearchPage = "search.php";
                    source1.SearchKeyword = "searchkey";
                    break;
            }
            if (instead)
                source = source1;
            return source1.Site;
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
        //初始化时创建表
        public static void CreateTable()
        {
            //阅读记录
            string sql = "create table bookshelf(novel text,chapter text,webIndex text,site text,date text);";
            //章节列表
            sql += "create table chapters(novel text,chapter text,webIndex text,site text);";
            //关键字黑名单，如果章节中出现这些词，将会替换成空。词语，类型(词语/正则表达式)，添加时间
            sql += "create table blackWords(words text,insteadWords text,type text,date text);";
            MySqlite.ExecSql(sql);
        }
        /// <summary>  
        /// 取文本中间内容  
        /// </summary>  
        /// <param name="str">原文本</param>  
        /// <param name="leftstr">左边文本</param>  
        /// <param name="rightstr">右边文本</param>  
        /// <returns>返回中间文本内容</returns>  
        public static string GetBetweenText(string str, string leftstr, string rightstr)
        {
            int i = str.IndexOf(leftstr);
            if (i == -1)
                return str;
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
        public static List<string> GetAllBetweenText(string str, string leftstr, string rightstr, bool deleteHtmlTag = false)
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

        //定义委托方法
        public delegate void HTMLGet(WebResponseInfo responseInfo, int requestCode);
        //定义事件，触发该事件时，会执行上面的委托方法
        public event HTMLGet HTMLGetCompleted;
        /// <summary>
        /// 获取网页内容，请调用该方法
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="requestCode">请求代码</param>
        public void GetHtmlByThread(string url,int requestCode)
        {
            Thread t = new Thread(new ThreadStart(delegate
              {
                  GetHtml(url, requestCode);
              }));
            t.IsBackground = true;
            t.Start();
        }
        
        /// <summary>
        /// 获取网页内容（文本形式）
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>网页Stream</returns>
        void GetHtml(string url,int requestCode)
        {
            string responseText;
            HttpWebRequest myRequest;
            if (!url.StartsWith("http")) url = "http://" + url;
            //创建 HttpWebRequest 对象
            myRequest = (HttpWebRequest)WebRequest.Create(url);
            WebResponseInfo webResponseInfo = new WebResponseInfo();
            webResponseInfo.URL = url;
            try
            {
                //取得response
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                webResponseInfo.ResponseCode = myResponse.StatusCode;
                webResponseInfo.ResponseHeader = myResponse.Headers;
                //取网页流
                Stream stream = myResponse.GetResponseStream();
                //返回数据的类型
                string rType = myResponse.Headers["Content-Type"];
                if (rType.Contains("text"))  //返回的是文本
                {
                    string encode = myResponse.ContentEncoding.ToLower();//返回文本格式
                    if (encode.Contains("gzip")) //解压缩gzip
                    {
                        using (GZipStream gstream = new GZipStream(stream, CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(gstream))
                            {
                                responseText = reader.ReadToEnd();
                            }
                        }
                    }
                    else if (encode.Contains("deflate")) //解压缩deflate，该压缩方式已过时
                    {
                        using (DeflateStream dstream = new DeflateStream(stream, CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(dstream, Encoding.UTF8))
                            {
                                responseText = reader.ReadToEnd();
                            }
                        }
                    }
                    else
                    {
                        //string encoding = myResponse.CharacterSet; //返回内容的字符集编码
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            responseText = reader.ReadToEnd();
                        }
                    }
                    webResponseInfo.DataType = "text";
                    webResponseInfo.ResponseText = responseText;
                }
                else if(rType.Contains("image"))  //如果返回的是图像
                {
                    Image img = Image.FromStream(stream);
                    webResponseInfo.ResponseImage = img;
                    webResponseInfo.DataType = "image";
                    //图形格式
                    string type = rType.Substring(6);
                    switch(type.ToLower())
                    {
                        case "png":
                            webResponseInfo.ResponseImageType = ImageFormat.Png;
                            break;
                        case "jpg":
                        case "jpeg":
                            webResponseInfo.ResponseImageType = ImageFormat.Jpeg;
                            break;
                        case "gif":
                            webResponseInfo.ResponseImageType = ImageFormat.Gif;
                            break;
                        case "bmp":
                            webResponseInfo.ResponseImageType = ImageFormat.Bmp;
                            break;
                        case "x-icon":
                            webResponseInfo.ResponseImageType = ImageFormat.Icon;
                            break;
                    }
                }
                HTMLGetCompleted(webResponseInfo, requestCode);
            }
            catch (Exception ex)
            {
                webResponseInfo.ErrorMessage = ex.ToString();
                HTMLGetCompleted(webResponseInfo, requestCode);
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
            string strText = Regex.Replace(html, "<[^>]+>", "");
            strText = Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }

        /// <summary>
        /// 判断文本文件的编码
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>编码</returns>
        public static Encoding GetFileEncodeType(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            int.TryParse(fs.Length.ToString(), out int i);
            byte[] buffer = br.ReadBytes(i);
            if (IsUTF8Bytes(buffer) || (buffer[0] == 0xEF && buffer[1] == 0xBB))
            {
                return Encoding.UTF8;
            }
            else if (buffer[0] == 0xFE && buffer[1] == 0xFF)
            {
                return Encoding.BigEndianUnicode;
            }
            else if (buffer[0] == 0xFF && buffer[1] == 0xFE)
            {
                return Encoding.Unicode;
            }
            else
            {
                return Encoding.Default;
            }
        }

        /// <summary>
        /// 判断是否为不带 BOM 的 UTF8 格式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool IsUTF8Bytes(byte[] data)
        {
            int charByteCounter = 1; //计算当前正分析的字符应还有的字节数
            byte curByte; //当前分析的字节.
            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];
                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {
                        //判断当前
                        while (((curByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }
                        //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //若是UTF-8 此时第一位必须为1
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            if (charByteCounter > 1)
            {
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// 网络访问的返回信息，包含协议头、重定向地址、状态码、cookie等等
    /// </summary>
    public class WebResponseInfo
    {
        public WebResponseInfo() { }
        /// <summary>
        /// 当前访问的链接
        /// </summary>
        public string URL;
        /// <summary>
        /// 返回数据类型 text image
        /// </summary>
        public string DataType;
        /// <summary>
        /// 状态码
        /// </summary>
        public HttpStatusCode ResponseCode;
        /// <summary>
        /// 返回协议头，包含cookie、重定向链接、数据类型等
        /// </summary>
        public WebHeaderCollection ResponseHeader;
        /// <summary>
        /// 网络访问错误时的信息
        /// </summary>
        public string ErrorMessage;
        /// <summary>
        /// 返回文本（仅DataType="text"时有效）
        /// </summary>
        public string ResponseText;
        /// <summary>
        /// 返回的图像（仅DataType="image"时有效）
        /// </summary>
        public Image ResponseImage;
        /// <summary>
        /// 返回的图像格式（仅DataType="image"时有效）
        /// </summary>
        public ImageFormat ResponseImageType;
    }

    /// <summary>
    /// 小说来源
    /// </summary>
    public class NovelSource
    {
        public int ID;  //网站索引，就是首页下拉框索引
        public string Site;  //网站域名
        public string SearchPage;  //搜索页面名
        public string SearchKeyword;  //搜索页面提交的关键词key，可以理解为postdata
    }

    /// <summary>
    /// 小说类
    /// </summary>
    public class Novel
    {
        public Novel(string name, string author, string new1, string date)
        {
            this.author = Tools.RemoveHtmlTag(author);
            lastDate = date;
            indexUrl = Tools.GetBetweenText(name, "href=\"", "\"");
            if (name.IndexOf("完本") > -1 || name.IndexOf("连载") > -1 || name.IndexOf("完结") > -1)
            {
                state = Tools.GetBetweenText(name, "[", "]");
                int index = name.LastIndexOf("]");
                if (index >= 1)
                    name = name.Substring(index + 1).Trim();
                //去掉“完本”“连载”
                this.name = Tools.RemoveHtmlTag(name);
            }
            else
            {
                state = "";
                this.name = Tools.RemoveHtmlTag(name);
            }
            if(new1.Contains("href="))
                newUrl = Tools.GetBetweenText(new1, "href=\"", "\"");
            newChapter = Tools.RemoveHtmlTag(new1);
        }
        public string name;  //书名
        public string state;  //状态
        public string indexUrl;  //章节目录链接
        public string author;  //作者
        public string newChapter;  //最新章
        public string newUrl;  //最新章链接
        public string lastDate;  //最近更新日期
    }

    /// <summary>
    /// 章节类
    /// </summary>
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
        public int web;  //网站索引，这个是首页下拉框的索引
        public string lastDate;  //最后阅读时间
    }
}
