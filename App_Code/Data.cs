using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OleDb;
using System.Data.SqlClient;

/// <summary>
///MyDB 的摘要说明
/// </summary>
public class Data
{
    /// 数据库连接
    /// <summary>
    /// 连接数据库
    /// </summary>
    /// <returns></returns>
    public static string strConn;
    public static string Connection()
    {
        string dbType = System.Configuration.ConfigurationManager.AppSettings["dbType"].ToString();
        if (dbType.ToUpper() == "ACCESS")
        {
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.ConnectionStrings[dbType].ConnectionString);
            
        }
        if (dbType.ToUpper() == "SQL")
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings[dbType].ConnectionString;
        }
        return strConn;
    }

    /// <summary>
    /// 执行sql并返回数据集
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    /// 
    public static DataTable Execute(string sql)
    {
        OleDbConnection conn = new OleDbConnection(Connection());
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        catch(Exception ex)
        {
            conn.Close();
            HttpContext.Current.Response.Write(ex.Message + " Error SQL Line = " + sql);
            HttpContext.Current.Response.End();
        }
        return null;
    }

    /// <summary>
    /// 执行sql返回当前新增ID
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    /// 
    public static int ExecuteGetID(string tablename)
    {
        OleDbConnection conn = new OleDbConnection(Connection());
        conn.Open();
        OleDbCommand cmd = new OleDbCommand("SELECT  IDENT_CURRENT('" + tablename + "')", conn);
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            da.Fill(dt);
            conn.Close();
            return int.Parse(dt.Rows[0][0].ToString());
        }
        catch (Exception ex)
        {
            conn.Close();
            HttpContext.Current.Response.Write(ex.Message + " Error SQL Line = " + "");
            HttpContext.Current.Response.End();
        }
        return -1;
    }

    public static int Update(string table, string value, int id)
    {
        return Update(table, value, "ID", id);
    }

    public static int Update(string table, string value, string line, int id)
    {
        string[] valuegroup = value.Trim(',').Split(',');

        string str = "[" + valuegroup[0].Split('=')[0] + "]=" + valuegroup[0].Split('=')[1];

        for (int i = 1; i < valuegroup.Length; i++)
        {
            str += ",[" + valuegroup[i].Split('=')[0] + "]=" + valuegroup[i].Split('=')[1];
        }
        string sql = "update [" + table + "] set " + str + " where [" + line + "]=" + id;
        sql = sql.Replace("&sbquo;", ",").Replace("&equal;", "=");

        try
        {
            return ExecuteNonQuery(sql);
        }
        catch (Exception e)
        {
            HttpContext.Current.Response.Write(sql + "<br />" + e.Message.ToString());
            HttpContext.Current.Response.End();
        }
        return 0;
    }

    public static int Insert(string table, string value)
    {
        string[] valuegroup = value.Trim(',').Split(',');

        string str1 = "";
        string str2 = "";

        for (int i = 0; i < valuegroup.Length; i++)
        {
            str1 += ",[" + valuegroup[i].Split('=')[0] + "]";
            str2 += "," + valuegroup[i].Split('=')[1];
        }
        string sql = "insert into [" + table + "] (" + str1.Trim(',') + ") values (" + str2.Trim(',') + ")";
        sql = sql.Replace("&sbquo;", ",").Replace("&equal;", "=");

        try
        {
            return ExecuteNonQuery(sql);
        }
        catch (Exception e)
        {
            HttpContext.Current.Response.Write(sql + "<br />" + e.Message.ToString());
            HttpContext.Current.Response.End();
        }
        return 0;
    }

    public static int Delete(string table, string user, int userid, string value, int id)
    {
        string sql = "delete from [" + table + "] where [" + user + "]=" + userid + " and [" + value + "]=" + id;

        try
        {
            return ExecuteNonQuery(sql);
        }
        catch (Exception e)
        {
            HttpContext.Current.Response.Write(e.Message.ToString());
            HttpContext.Current.Response.End();
        }
        return 0;
    }

    public static int Delete(string table, string value, int id)
    {
        string sql = "delete from [" + table + "] where [" + value + "]=" + id;

        try
        {
            return ExecuteNonQuery(sql);
        }
        catch (Exception e)
        {
            HttpContext.Current.Response.Write(e.Message.ToString());
            HttpContext.Current.Response.End();
        }
        return 0;
    }


    public static int DeleteAll(string table, string id)
    {
        if (id.Trim() != "")
        {
            string sql = "delete from [" + table + "] where [ID] in (" + id + ")";
            try
            {
                return ExecuteNonQuery(sql);
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write(e.Message.ToString());
                HttpContext.Current.Response.End();
            }
        }
        return 0;
    }

    public static int Delete(string table, int id)
    {
        string sql = "delete from [" + table + "] where [ID]=" + id;

        try
        {
            return ExecuteNonQuery(sql);
        }
        catch (Exception e)
        {
            HttpContext.Current.Response.Write(e.Message.ToString());
            HttpContext.Current.Response.End();
        }
        return 0;
    }

    public static string Build(string str1, string str2)
    {
        return str1 + "='" + str2.Replace(",", "&sbquo;").Replace("=", "&equal;") + "'" + ",";
    }
    public static string Build(string str1, DateTime str2)
    {
        return str1 + "='" + str2.ToString("yyyy-MM-dd HH:mm:ss") + "'" + ",";
    }
    public static string Build(string str1, int str2)
    {
        return str1 + "=" + str2 + "" + ",";
    }
    public static string Build(string str1, float str2)
    {
        return str1 + "=" + str2 + "" + ",";
    }
    public static string Build(string str1, decimal str2)
    {
        return str1 + "=" + str2 + "" + ",";
    }
    public static string Build(string str1, double str2)
    {
        return str1 + "=" + str2 + "" + ",";
    }
    public static string Build(string str1, int str2, string act)
    {
        if (act == "+")
        {
            return str1 + "=" + str1 + "+" + str2 + ",";
        }
        else
        {
            return str1 + "=" + str1 + "-" + str2 + ",";
        }
    }
    public static string Build(string str1, float str2, string act)
    {
        if (act == "+")
        {
            return str1 + "=" + str1 + "+" + str2 + ",";
        }
        else
        {
            return str1 + "=" + str1 + "-" + str2 + ",";
        }
    }
    public static string Build(string str1, decimal str2, string act)
    {
        if (act == "+")
        {
            return str1 + "=" + str1 + "+" + str2 + ",";
        }
        else
        {
            return str1 + "=" + str1 + "-" + str2 + ",";
        }
    }
    public static string Build(string str1, double str2, string act)
    {
        if (act == "+")
        {
            return str1 + "=" + str1 + "+" + str2 + ",";
        }
        else
        {
            return str1 + "=" + str1 + "-" + str2 + ",";
        }
    }
	
	/// <summary>
    /// 执行sql并返回数据集的第一行
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    /// 
    public static Object ExecuteScalar(string sql)
    {
        OleDbConnection conn = new OleDbConnection(Connection());
        conn.Open();
        OleDbCommand Command = new OleDbCommand(sql, conn);
        conn.Close();
        return Command.ExecuteScalar();
    }
	
	/// <summary>
    /// 执行sql并返回影响的行数
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    /// 
    public static int ExecuteNonQuery(string sql)
    {
        OleDbConnection conn = new OleDbConnection(Connection());
        conn.Open();
        try
        {
            OleDbCommand Command = new OleDbCommand(sql, conn);
            int req = Command.ExecuteNonQuery();
            conn.Close();
            return req;
        }
        catch (SqlException e)
        {
            HttpContext.Current.Response.Write("Error SQL Line = " + sql);
            HttpContext.Current.Response.End();
        }
        conn.Close();
        return 0;
    }
    
	
	static public int getData(ref int var, object obj)
    {
        try
        {
            var = int.Parse(obj.ToString());
            return 0;
        }
        catch
        {
            return 1;
        }
    }

    static public int getData(ref double var, object obj)
    {
        try
        {
            var = double.Parse(obj.ToString());
            return 0;
        }
        catch
        {
            return 1;
        }
    }
    static public int getData(ref float var, object obj)
    {
        try
        {
            var = float.Parse(obj.ToString());
            return 0;
        }
        catch
        {
            return 1;
        }
    }
    static public int getData(ref decimal var, object obj)
    {
        try
        {
            var = decimal.Parse(obj.ToString());
            return 0;
        }
        catch
        {
            return 1;
        }
    }


    static public int getData(ref string var, object obj)
    {
        try
        {
            var = obj.ToString();
            return 0;
        }
        catch
        {
            return 1;
        }
    }

    static public int getData(ref DateTime var, object obj)
    {
        try
        {
            var = DateTime.Parse(obj.ToString());
            return 0;
        }
        catch
        {
            return 1;
        }
    }



    /// <summary>
    /// 直接获取配合Select格式的数据源，格式“select 名称,编号 where 条件”
    /// </summary>
    /// <param name="sql">数据源查询</param>
    /// <returns>HTML</returns>
    static public string SelectData(string sql)
    {
        string temp = "";
        DataTable dt = Execute(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            temp += dt.Rows[i][0] + "," + dt.Rows[i][1] + "|";
        }
        return temp.Trim('|');
    }

    static public string SelectData(string sql, int id, string deep, int lv)
    {
        string temp = "";
        if (lv > deep.Length)
        {
            DataTable dt = Execute(sql.Replace("@", id.ToString()));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == dt.Rows.Count - 1)
                {
                    temp += deep.Replace("└", "&nbsp;&nbsp;").Replace("├", "│") + "└" + dt.Rows[i][0] + "," + dt.Rows[i][1] + "|";
                    temp += SelectData(sql, (int)dt.Rows[i][1], deep + "└", lv);
                }
                else
                {
                    temp += deep.Replace("└", "&nbsp;&nbsp;").Replace("├", "│") + "├" + dt.Rows[i][0] + "," + dt.Rows[i][1] + "|";
                    temp += SelectData(sql, (int)dt.Rows[i][1], deep + "├", lv);
                }
            }
        }
        return temp;
    }

    static public string SelectData(string sql, int id, string deep)
    {
        string temp = "";
        if (sql.IndexOf('@') != -1)
        {
            DataTable dt = Execute(sql.Replace("@", id.ToString()));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == dt.Rows.Count - 1)
                {
                    temp += deep.Replace("└", "&nbsp;&nbsp;").Replace("├", "│") + "└" + dt.Rows[i][0] + "," + dt.Rows[i][1] + "|";
                    temp += SelectData(sql, (int)dt.Rows[i][1], deep + "└");
                }
                else
                {
                    temp += deep.Replace("└", "&nbsp;&nbsp;").Replace("├", "│") + "├" + dt.Rows[i][0] + "," + dt.Rows[i][1] + "|";
                    temp += SelectData(sql, (int)dt.Rows[i][1], deep + "├");
                }
            }
        }
        return temp;
    }
    static public string SelectData(string sql,string fields)
    {
        string option="";
        DataTable dt = Execute(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            option += dt.Rows[i][fields].ToString() + "," + dt.Rows[i]["id"].ToString() + "|";
        }
        return option;
    }

    /// <summary>
    /// 直接获取配合Select格式的数据源，格式“名称,编号”
    /// </summary>
    /// <param name="sql">数据源查询</param>
    /// <param name="name">名称字段名</param>
    /// <param name="id">编号字段名</param>
    /// <returns>HTML</returns>
    static public string SelectData(string sql, string name, string id)
    {
        string temp = "";
        DataTable dt = Execute(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            temp += dt.Rows[i][name] + "," + dt.Rows[i][id] + "|";
        }
        return temp.Trim('|');
    }

    /// <summary>
    /// 直接获取配合Select格式的数据源，格式“名称(别名),编号”
    /// </summary>
    /// <param name="sql">数据源查询</param>
    /// <param name="name1">名称1字段名</param>
    /// <param name="name2">名称2字段名</param>
    /// <param name="id">编号字段名</param>
    /// <returns>HTML</returns>
    static public string SelectData(string sql, string name1, string name2, string id)
    {
        string temp = "";
        DataTable dt = Execute(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            temp += dt.Rows[i][name1] + "(" + dt.Rows[i][name2] + ")," + dt.Rows[i][id] + "|";
        }
        return temp.Trim('|');
    }
}
