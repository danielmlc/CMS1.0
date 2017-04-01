using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///htmlpage 的摘要说明
/// </summary>
public class htmlpage:System.Web.UI.Page
{
    public html html;
    public string Islogin="Nonlogin";//上层页面的URL
    public htmlpage()
    {
        html = new html();
        this.Load += new EventHandler(htmlpage_load);
    }
    private void htmlpage_load(object sender, EventArgs e)
    {
        //判断管理员是否登录
        if (Core.Cookies("USER_USERNAME")=="")
        {
            Response.Write("<script>top.location.href='Default.aspx'</script>");
            Response.End();
        }
        else
        {
            html = new html();
        }
    }
       
   
   
   
}