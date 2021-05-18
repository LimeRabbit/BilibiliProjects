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
        public static DataTable GetData(string sql)
        {
            return GetData(sql, null);
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sql">语句</param>
        /// <returns></returns>
        public static DataTable GetData(string sql, List<SQLiteParameter> parameters)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            if (parameters != null && parameters.Count > 0)
                cmd.Parameters.AddRange(parameters.ToArray());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            con.Close();
            return table;
        }

        //获得结果的第一行第一列
        public static string GetFirstResult(string sql, List<SQLiteParameter> pars)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            SQLiteCommand com = new SQLiteCommand(sql, con);
            com.Parameters.AddRange(pars.ToArray());
            SQLiteDataReader reader = com.ExecuteReader();
            string res = "";
            if (reader.Read())
            {
                res = reader[0].ToString();
            }
            reader.Close();
            con.Close();
            return res;
        }
        /// <summary>
        /// 执行语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecSql(string sql)
        {
            return ExecSql(sql, null);
        }

        /// <summary>
        /// 执行语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static int ExecSql(string sql, List<SQLiteParameter> pars)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            SQLiteCommand com = new SQLiteCommand(sql, con);
            if (pars != null && pars.Count > 0)
                com.Parameters.AddRange(pars.ToArray());
            int lines = com.ExecuteNonQuery();
            con.Close();
            return lines;
        }

    }
}
