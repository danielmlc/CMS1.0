using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Exit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            Session["UserID"] = "";
            Session["UserName"] = "";
            Session["UserCode"] = "";
			HttpContext.Current.Response.Buffer = true;
			HttpContext.Current.Response.Expires = 0;
			HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
			HttpContext.Current.Response.AddHeader("pragma", "no-cache");
			HttpContext.Current.Response.AddHeader("cache-control", "private");
			HttpContext.Current.Response.CacheControl = "no-cache";
			Response.Write(1);
			Response.End();
    }
}
