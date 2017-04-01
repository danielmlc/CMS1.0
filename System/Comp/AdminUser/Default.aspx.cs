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

public partial class System_Comp_comp_Default : systempage
{
    public DataTable dt;
    public int page;

    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (RNA.getStr("act") == "del")
        {
            Data.Delete("AdminUser", RNA.getID());
            Response.Redirect( History);
        }
        WriHistory();//写历史cookie
        dt = Data.Execute("SELECT * FROM [AdminUser] order by [AdminGroup],[RealName],[ID]");
    }
}
