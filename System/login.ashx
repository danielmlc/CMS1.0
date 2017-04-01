<%@ WebHandler Language="C#" Class="login" %>

using System;
using System.Web;
using System.Web.Security;
using System.Data;
using System.Web.SessionState;
public class login : IHttpHandler,IRequiresSessionState{
    public void ProcessRequest (HttpContext context) {
        string  Username = "",
                PassWord = "",
                Code = "";
        if (context.Request["User"] != null && context.Request["Pass"] != null&& context.Request["Code"] != null)
        {
            Username = context.Request["User"];
            PassWord = context.Request["Pass"];
            Code = context.Request["Code"];
        }
        if (Core.Cookies("CheckCode").Length != 4 || Core.Cookies("CheckCode").ToLower() != Code.ToLower())
        {
            context.Response.Write("{data:0}");  //验证码输入有误
        }
        else if (FormsAuthentication.HashPasswordForStoringInConfigFile(Username, "SHA1") == System.Configuration.ConfigurationManager.AppSettings["DNAU"].ToString())
        {
            //超级管理员
            if (FormsAuthentication.HashPasswordForStoringInConfigFile(PassWord, "SHA1") == System.Configuration.ConfigurationManager.AppSettings["DNAP"].ToString())
            {
                context.Response.Write("{data:1}");  //登录成功
                //超级管理员登陆成功
                Core.Session("UserID", "0");
                Core.Session("UserName", "超级管理员");
                Core.Session("UserCode", Username);
             
            }
            else
            {
                // 超级管理员密码错误
                context.Response.Write("{data:-1}");  //密码输入有误
            }
        }
        else 
        {
            //非超级管理员用户登陆
            DataTable dt = Data.Execute("SELECT * FROM [AdminUser] WHERE [AdminName]='" + Username + "' ");
            if (dt.Rows.Count > 0)
            {
                    PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PassWord, "SHA1");
                    dt = Data.Execute("SELECT * FROM [AdminUser] WHERE [AdminName]='" + Username + "' AND  [AdminPass]='" + PassWord + "' ");
                    if (dt.Rows.Count > 0)
                    {
                        HttpContext.Current.Session["UserID"] = dt.Rows[0]["ID"].ToString();//用户ID
                        HttpContext.Current.Session["UserName"] = dt.Rows[0]["RealName"].ToString(); //姓名
                        HttpContext.Current.Session["UserCode"] = dt.Rows[0]["AdminName"].ToString(); //用户名
                        Data.Update("AdminUser",
                        Data.Build("AdminLastTime", DateTime.Now) ,
                        Convert.ToInt32(dt.Rows[0]["ID"].ToString())
                        );
                        context.Response.Write("{data:1}");  //登录成功
                    }
                    else
                    {
                        context.Response.Write("{data:-1}");  //密码输入有误
                    }
               
              
            }
            else
            {
                context.Response.Write("{data:-2}");  //该用户不存在
            }
        }
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}