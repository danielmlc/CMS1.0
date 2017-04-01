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

public partial class System_Left : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    public void showMenu(int id)
    {
        DataTable SubMenu;
        MyDB db = new MyDB();
        db.Open();
        SubMenu = db.Execute("select * from [V_SubMenu] where [Active]=1 and [Link]=" + id + " order by [Index] Desc, ID ");
        if (SubMenu.Rows.Count > 0)
        {
            Response.Write("<ul id=\"c_" + id + "\">");
            for (int i = 0; i < SubMenu.Rows.Count; i++)
            {
                if (SubMenu.Rows[i]["type"].ToString() == "1")
                {
                    Response.Write("<li id=\"f_" + SubMenu.Rows[i]["ID"].ToString() + "\">" + SubMenu.Rows[i]["Name"].ToString() + "</li>");
                }
                else
                {
                    Response.Write("<li id=\"f_" + SubMenu.Rows[i]["ID"].ToString() + "\"><a href=\"Comp/" + SubMenu.Rows[i]["Path"].ToString()
                        + "/Default.aspx?node=" + SubMenu.Rows[i]["ID"].ToString() + "\" target=\"mainFrame\">" + SubMenu.Rows[i]["Name"].ToString() + "</a>");
                    Response.Write("</li>");
                }
                showMenu((int)SubMenu.Rows[i]["ID"]);
            }
            Response.Write("</ul>");
        }
        db.Close();
    }
  
}
