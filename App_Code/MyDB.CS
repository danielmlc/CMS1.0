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
public class MyDB
{
    /// 数据库连接
    public OleDbConnection CONN;
    public string dbType;
    /// <summary>
    /// 连接数据库
    /// </summary>
    /// <returns></returns>
    /// 

    public void Connection()
    {
        dbType = System.Configuration.ConfigurationManager.AppSettings["dbType"].ToString();
        if (dbType.ToUpper() == "ACCESS")
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.ConnectionStrings[dbType].ConnectionString);
            CONN = new OleDbConnection(strConn);
            if (CONN.State.Equals(ConnectionState.Closed))
            {
				try{
                	CONN.Open();
				}catch{}
            }
        }
        if (dbType.ToUpper() == "SQL")
        {
            string strConn = System.Configuration.ConfigurationManager.ConnectionStrings[dbType].ConnectionString;
            CONN = new OleDbConnection(strConn);
            if (CONN.State.Equals(ConnectionState.Closed))
            {
                CONN.Open();
            }
        }
    }

    public void Open()
    {
        Connection();
    }

    /// <summary>
    /// 执行sql并返回数据集
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    /// 
    public DataTable Execute(string sql)
    {
        OleDbCommand cmd = new OleDbCommand(sql, CONN);
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            da.Fill(dt);
        }
        catch 
        {
            HttpContext.Current.Response.Write("Error SQL Line = " + sql);
            HttpContext.Current.Response.End();
        }
        return dt;
    }

    /// <summary>
    /// 执行sql并返回数据集的第一行
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    /// 
    public Object ExecuteScalar(string sql)
    {
        OleDbCommand Command = new OleDbCommand(sql, CONN);
        return Command.ExecuteScalar();
    }


    /// <summary>
    /// 执行sql并返回影响的行数
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    /// 
    public int ExecuteNonQuery(string sql)
    {
        OleDbCommand Command = new OleDbCommand(sql, CONN);
        return Command.ExecuteNonQuery();
    }

    public void Close()
    {
        CONN.Close();
    }

    public void Dispose()
    {
        CONN.Dispose();
    }
}
