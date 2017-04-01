using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;

/// <summary>
///system 的摘要说明
/// </summary>
public class systempage : System.Web.UI.Page
{
	
    public system system;
    public string History;//上层页面的URL
    public int ProjId;
    public int Node;
    public systempage()
    {
        system = new system();
        this.Load += new EventHandler(systempage_Load);
    }
    void systempage_Load(object sender, EventArgs e)
    {
        ProjId = system.ProjID;
        Node = system.Node;
        History = system.Histroy;
        //判断管理员是否登录
        if (!IsPostBack)
        {
            if (IsAdminLogin())
            {
                Response.Write("<script>top.location.href='../../Login.aspx'</script>");
                Response.End();
            }
            else
            {
              // system = new system();
            }
         
        }
    }
   
          /// <summary>
          /// 写入项目ID
          /// </summary>
          /// <param name="id"></param>
     public void WriProjId(int id)
            {
                system.ProjID = id;
            }
    /// <summary>
    /// 写入项目node
    /// </summary>
    /// <param name="node"></param>
    public void WriNode(int node)
       {
           system.Node = node;
          
       }
    /// <summary>
    /// 写History Cookie
    /// </summary>
       public void WriHistory()
       {
           system.Histroy = Request.Url.ToString();
       }
    /// <summary>
    /// 判断管理员是否已经登录(解决Session超时问题)
    /// </summary>
       public bool IsAdminLogin()
       {
            if (Session["UserCode"] != null)
           {
               return false;
           }
           return true;
       }
   
}