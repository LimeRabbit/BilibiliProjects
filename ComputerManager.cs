using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilibiliProjects
{
    public class ComputerManager
    {
        /// <summary>
        /// "视频"
        /// </summary>
        public static string VIDEO = "{35286a68-3c57-41a1-bbb1-0eae73d76c95}";
        /// <summary>
        /// "图片"
        /// </summary>
        public static string PICTURE = "{0ddd015d-b06c-45d5-8c4c-f59713854639}";
        /// <summary>
        /// "文档"
        /// </summary>
        public static string DOCUMENT = "{f42ee2d3-909f-4907-8871-4c22fc0bf756}";
        /// <summary>
        /// "下载"
        /// </summary>
        public static string DOWNLOAD = "{7d83ee9b-2244-4e70-b1f5-5393042af1e4}";
        /// <summary>
        /// "音乐"
        /// </summary>
        public static string MUSIC = "{a0c69a99-21c8-4671-8703-7934162fcf1d}";
        /// <summary>
        /// "桌面"
        /// </summary>
        public static string DESKTOP = "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}";
        /// <summary>
        /// "3D对象"
        /// </summary>
        public static string THREED = "{31c0dd25-9439-4f12-bf41-7ff4eda38722}";
        public ComputerManager(string key) 
        {
            Key = key;
            Init();
        }
        
        /// <summary>
        /// 注册表项
        /// </summary>
        public RegistryKey RKey;
        /// <summary>
        /// 注册表子项的字符串
        /// </summary>
        public string Key;
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Visible;
        /// <summary>
        /// 写注册表错误信息
        /// </summary>
        public string ErrorMsg;

        private void Init()
        {
            RegistryKey subkey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FolderDescriptions");
            RKey = subkey.OpenSubKey(Key);
            if(RKey!=null)
            {
                RKey= RKey.OpenSubKey("PropertyBag", true);
                if(RKey!=null)
                {
                    object obj=RKey.GetValue("ThisPCPolicy");
                    if (obj != null && obj.ToString().ToLower() == "show")
                        Visible = true;
                    else
                        Visible = false;
                }
                else
                {
                    Visible = false;
                    //没有子项，则创建子项，默认设置为隐藏
                    RKey = subkey.OpenSubKey(Key, true);
                    RKey.CreateSubKey("PropertyBag");
                    RKey = RKey.OpenSubKey("PropertyBag", true);
                    RKey.SetValue("ThisPCPolicy", "Hide");
                }
            }
        }

        public bool SetVisible(bool visible)
        {
            if (visible == Visible)
                return true;
            try
            {
                RKey.SetValue("ThisPCPolicy", visible ? "Show" : "Hide");
                return true;
            }
            catch(Exception e)
            {
                ErrorMsg = e.ToString();
                return false;
            }
        }
    }
}
