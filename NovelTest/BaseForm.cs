using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilibiliProjects.NovelTest
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            MySqlite.InitDB();
            if (!File.Exists(MySqlite.path))
            {
                Tools.CreateTable();  //不存在数据库，创建新表
            }
            ReadSetting();
            UIColors.SetControlColors(this);
            UIColors.SetMenuStripColor(menuStrip1);
        }

        private void BaseForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                UIColors.SetControlColors(this);
                UIColors.SetMenuStripColor(menuStrip1);
            }
        }

        /// <summary>
        /// 从数据库读取设置
        /// </summary>
        void ReadSetting()
        {
            string sql = "select * from settings";
            DataTable dt = MySqlite.GetData(sql);
            foreach (DataRow row in dt.Rows)
            {
                string key = row[0].ToString();
                string value = row[1].ToString();
                switch (key)
                {
                    case "NightMode":
                        UIColors.IsNightMode = value != "0";
                        break;
                    case "UserMode":
                        UIColors.IsUserMode = value != "0";
                        break;
                    case "BackColor":
                        UIColors.BackColor = Color.FromArgb(Convert.ToInt32(value));
                        break;
                    case "ForeColor":
                        UIColors.ForeColor = Color.FromArgb(Convert.ToInt32(value));
                        break;
                    case "LinkColor":
                        UIColors.LinkColor = Color.FromArgb(Convert.ToInt32(value));
                        break;
                    case "AutoSave":
                        Setting.AutoSave = value != "0";
                        break;
                    case "Compress":
                        Setting.IsCompress = value != "0";
                        break;
                    case "WhyReason":
                        Setting.WhyReason = value != "0";
                        break;
                    case "DeletePS":
                        Setting.DeletePS = value != "0";
                        break;
                    case "FontFamily":
                        Setting.FontFamily = value;
                        break;
                    case "FontSize":
                        Setting.FontSize = Convert.ToSingle(value); //float
                        break;
                }
            }
        }

        private void ToolStrip_setting_Click(object sender, EventArgs e)
        {
            BeforeSetting();
            new Settings(this).ShowDialog();
            WriteSetting();
            AfterSetting();
        }

        /// <summary>
        /// 将设置写入数据库
        /// </summary>
        void WriteSetting()
        {
            string sql = "delete from settings";
            MySqlite.ExecSql(sql);
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();

            sql = "insert into settings values(@key,@value)";
            parameters.Add(new SQLiteParameter("key", "NightMode")); //夜间模式
            parameters.Add(new SQLiteParameter("value", UIColors.IsNightMode));
            MySqlite.ExecSql(sql, parameters);

            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("key", "UserMode"));  //自定义颜色
            parameters.Add(new SQLiteParameter("value", UIColors.IsUserMode));
            MySqlite.ExecSql(sql, parameters);

            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("key", "BackColor"));  //背景色
            parameters.Add(new SQLiteParameter("value", UIColors.BackColor.ToArgb()));
            MySqlite.ExecSql(sql, parameters);

            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("key", "ForeColor"));  //前景色
            parameters.Add(new SQLiteParameter("value", UIColors.ForeColor.ToArgb()));
            MySqlite.ExecSql(sql, parameters);

            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("key", "LinkColor"));  //链接文字颜色
            parameters.Add(new SQLiteParameter("value", UIColors.LinkColor.ToArgb()));
            MySqlite.ExecSql(sql, parameters);

            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("key", "AutoSave"));  //自动保存
            parameters.Add(new SQLiteParameter("value", Setting.AutoSave));
            MySqlite.ExecSql(sql, parameters);

            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("key", "Compress"));  //压缩
            parameters.Add(new SQLiteParameter("value", Setting.IsCompress));
            MySqlite.ExecSql(sql, parameters);

            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("key", "WhyReason"));  //实验性功能1
            parameters.Add(new SQLiteParameter("value", Setting.WhyReason));
            MySqlite.ExecSql(sql, parameters);

            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("key", "DeletePS"));  //实验性功能2
            parameters.Add(new SQLiteParameter("value", Setting.DeletePS));
            MySqlite.ExecSql(sql, parameters);

            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("key", "FontFamily"));  //字体
            parameters.Add(new SQLiteParameter("value", Setting.FontFamily));
            MySqlite.ExecSql(sql, parameters);

            parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("key", "FontSize"));  //字号
            parameters.Add(new SQLiteParameter("value", Setting.FontSize));
            MySqlite.ExecSql(sql, parameters);

        }

        public virtual void BeforeSetting()
        {
            //设置页面打开之前调用该方法，如有需要请用 override 重写
        }
        public virtual void AfterSetting()
        {
            //设置页面关闭之后调用该方法，如有需要请用 override 重写
        }

        private void ToolStrip_about_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void ToolStrip_statistics_Click(object sender, EventArgs e)
        {
            BeforeStatistics();
            new StaticForm(this).ShowDialog();//打开统计页面
            AfterStatistics();
        }
        
        public virtual void BeforeStatistics()
        {
            //打开统计页面之前要做的事情，如有需要请重写
        }
        
        public virtual void AfterStatistics()
        {
            //关闭统计页面之后要做的事情，如有需要请重写
        }
    }
}
