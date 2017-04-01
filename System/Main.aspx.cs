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

public partial class System_Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void Show(int id)
    {
        DataTable dt = Data.Execute("SELECT * FROM [V_SubMenu] WHERE [Link]=" + id + " order by [Index] Desc, [id]");
        
        for (int i = 0; i < dt.Rows.Count; i++)
        {

            if (dt.Rows[i]["Components"].ToString() == "1")
            {
                Response.Write("<div class=\"blank\">" + dt.Rows[i]["Name"] + "（" + dt.Rows[i]["CompName"] + "）");
                Show((int)dt.Rows[i]["ID"]);
                Response.Write("</div>");
            }
            else
            {
                Response.Write("<div class=\"block\">" + "<a  href=\"Comp/" + dt.Rows[i]["Path"].ToString() + "/Default.aspx?node=" 
                    + dt.Rows[i]["ID"].ToString() +"\"> "+ dt.Rows[i]["Name"] + "（" + dt.Rows[i]["CompName"] + "）</a>");
                Show((int)dt.Rows[i]["ID"]);
                Response.Write("</div>");
            }
        }
    }
}
