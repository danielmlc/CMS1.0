using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Comp_Bankup_Default : systempage
{
    public string[] files;

    protected void Page_Load(object sender, EventArgs e)
    {
        string act = Core.get("act");
        if (act == "bak")
        {
            System.IO.File.Copy(
                System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.ConnectionStrings["ACCESS"].ConnectionString),
                System.Web.HttpContext.Current.Server.MapPath("/App_Data/" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak")
                );

            Response.Redirect("Default.aspx");
        }
        if (act == "del")
        {
            string file = Core.get("id");
            if (file.EndsWith(".bak") && (file.Length == 18)) 
            {
                System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath("/App_Data/" + file));
            }

            Response.Redirect("Default.aspx");
        }

        files = System.IO.Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath("/App_Data"));
    }
}