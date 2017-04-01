using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

/// <summary>
///system 的摘要说明
/// </summary>
///   

public class system: System.Web.UI.Page
{
    public system()
    { 

    }
    public static void SaveUserInfo(DataTable DT)
    {

        HttpContext.Current.Session["UserID"] = DT.Rows[0]["UserID"].ToString();//用户ID
        HttpContext.Current.Session["UserName"] = DT.Rows[0]["UserName"].ToString(); //姓名
        HttpContext.Current.Session["UserCode"] = DT.Rows[0]["UserCode"].ToString(); //用户名
    }
	/// <summary>
	/// 管理员编号
	/// </summary>
    public string RNA_ADMINUSER
    {
        get { if (HttpContext.Current.Session["UserID"] != null) return HttpContext.Current.Session["UserID"].ToString(); else return ""; }
        set {  HttpContext.Current.Session["UserID"] = value; }
    }
   
    /// <summary>
   /// 管理员名称
   /// </summary>
    public string RNA_REALNAME
    {
        get { if (HttpContext.Current.Session["UserName"] != null) return HttpContext.Current.Session["UserName"].ToString(); else return ""; }
        set { HttpContext.Current.Session["UserName"] = value; }
    }
    /// <summary>
    /// 管理员账号
    /// </summary>
    public string  RNA_ADMINCODE
    {
        get { if (HttpContext.Current.Session["UserCode"] != null) return HttpContext.Current.Session["UserCode"].ToString(); else return ""; }
        set { HttpContext.Current.Session["UserCode"] = value; }
    }
  
   /// <summary>
   /// 上层页面的URL
   /// </summary>
    public string Histroy
    {
        get { return Core.Cookies("History"); }
        set { Core.Cookies("History", value); }
    }

    /// <summary>
    /// 项目ID
    /// </summary>
    public int ProjID
    {
        get { return Core.Cookies("ProjID") == "" ? 0 : int.Parse(Core.Cookies("ProjID")); }
        set { Core.Cookies("ProjID", value.ToString()); }
    }
    /// <summary>
    /// 节点
    /// </summary>
    public int Node
    {
        get { return Core.Cookies("Node") == "" ? 0 : int.Parse(Core.Cookies("Node")); }
        set { Core.Cookies("Node", value.ToString()); }
    }
}