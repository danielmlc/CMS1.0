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
using System.IO;

public partial class System_Comp_comp_Default : systempage
{
    public DataTable dt;
    public int page = 1;
    public int node = RNA.getNode();
    public string tit = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string act = Core.get("act");
        tit = Data.Execute("SELECT top 1 [Name] FROM [V_SubMenu] WHERE [id]=" + node).Rows[0][0].ToString();
        dt = Data.Execute("SELECT * FROM [V_W_ImageAndText] where node=" + node + " ORDER BY [Index] DESC,[ID] DESC");
        if (act == "del")
        {
         //   File.Delete(System.Web.HttpContext.Current.Server.MapPath(Data.Execute("SELECT top 1 * FROM [V_W_ImageAndText] where ID=" + Core.getID()).Rows[0]["Itemurl"].ToString()));
            Data.Delete("W_CompList", "WtID", Core.getID());
            Data.Delete("W_ImageAndText", Core.getID());
            Response.Redirect(History);
            
        }
        WriHistory();
       
    }
}
