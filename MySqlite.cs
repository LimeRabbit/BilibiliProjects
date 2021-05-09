using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BilibiliProjects
{
    public static class MySqlite
    {
        public static SQLiteConnection con;
        public static string path = Application.StartupPath + "\\novel.db";
        public static void InitDB()
        {
            con = new SQLiteConnection("Data Source=" + MySqlite.path);
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sql">语句</param>
        /// <returns></returns>
        public static List<Chapter> GetData(string sql)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<Chapter> chapters = new List<Chapter>();
            while (reader.Read())
            {
                chapters.Add(new Chapter(reader["novel"].ToString(), 
                    reader["chapter"].ToString(), reader["site"].ToString(),reader["date"].ToString()));
            }
            reader.Close();
            return chapters;
        }

        //执行count函数，获得结果数量
        public static int GetCount(string sql, List<SQLiteParameter> pars)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            SQLiteCommand com = new SQLiteCommand(sql, con);
            com.Parameters.AddRange(pars.ToArray());
            int lines = Convert.ToInt32(com.ExecuteScalar());
            con.Close();
            return lines;
        }

        public static int ExecSql(string sql)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            SQLiteCommand com = new SQLiteCommand(sql, con);
            int lines=com.ExecuteNonQuery();
            con.Close();
            return lines;
        }

        public static int ExecSql(string sql,List<SQLiteParameter> pars)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            SQLiteCommand com = new SQLiteCommand(sql, con);
            
            com.Parameters.AddRange(pars.ToArray());
            int lines = com.ExecuteNonQuery();
            con.Close();
            return lines;
        }

    }
}
