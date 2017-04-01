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
    public DataTable table;
    public DataTable dt;
    public int page = 1;
    public int node = RNA.getNode();

    protected void Page_Load(object sender, EventArgs e)
    {
        table = Data.Execute("SELECT * FROM [V_SubMenu] WHERE [id]=" + node);
        dt = Data.Execute("SELECT * FROM [V_W_SuperModel] WHERE [Node]="+ node + " ORDER BY [INDEX] DESC,[ID] DESC");
        string act = Core.get("act");
       // WriProjId(dt.Rows[0])
       ////单项删除
        if (act == "del")
        {
            Data.Delete("W_SuperModel", Core.getID());
            Data.Delete("W_CompList", "CompID", Core.getID());
            Data.Delete("W_ImageAndtext", "PID", Core.getID());
            Data.Delete("W_SuperAttch", "PID", Core.getID());
            Response.Redirect(History);
        }
        WriHistory();
       
    }
}
