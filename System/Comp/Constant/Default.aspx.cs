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

public partial class System_Comp_Text_Default : systempage
{
    public DataTable dt;
    public int page = 1;
    public int node = RNA.getNode();

    protected void Page_Load(object sender, EventArgs e)
    {
        string act = Core.get("act");
        if (act == "del")
        {
            Data.Delete("W_Constant", Core.getID());
            Response.Redirect(Core.Cookies("History"));
        }
        WriHistory();//写历史cookie
        dt = Data.Execute("SELECT * FROM [W_Constant] ORDER BY [ID] DESC");
    }
}
