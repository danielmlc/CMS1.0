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
    public int page;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Core.get("act") == "del")
        {
            int t = RNA.getID();
            Data.Delete("W_DataSource", RNA.getID());
            Response.Redirect(History);
        }
        WriHistory();
    }

    public void showSource(int id, string lv)
    {
        DataTable dt;
        dt = Data.Execute("SELECT * FROM [V_SubMenu] WHERE [Link]=" + id + " order by [Index] Desc,[id]");
        if (lv=="" && dt.Rows.Count == 0)
        {
            Response.Write("<tr><td class=\"nodata\" colspan=\"8\"><div align=\"center\">暂无数据</div></td></tr>");
        }
        else
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Response.Write("<tr>");
                Response.Write("<td><div align=\"center\">");
                Response.Write("<input type=\"checkbox\" class=\"checkbox\" name=\"C_Mark\" value=\"" + dt.Rows[i]["ID"] + "\" />");
                Response.Write("</div></td>");
                Response.Write("<td><div align=\"center\">" + dt.Rows[i]["ID"] + "</div></td>");
                Response.Write("<td><div class=\"left\">" + lv + dt.Rows[i]["Name"].ToString() + "</div></td>");
                Response.Write("<td><div align=\"center\">" + dt.Rows[i]["CompName"] + "</div></td>");
                Response.Write("<td><div align=\"center\">" + dt.Rows[i]["Index"] + "</div></td>");
                Response.Write("<td><div align=\"center\"><a href=\"#\"onclick=\"active1(this," + dt.Rows[i]["ID"] + ")\">");
                if (dt.Rows[i]["Active"].ToString() == "0")
                {
                    Response.Write("<img src=\"../../images/active_0.gif\" alt=\"未启用\" border=\"0\" />");
                }
                else
                {
                    Response.Write("<img src=\"../../images/active_1.gif\" alt=\"已启用\" border=\"0\" />");
                }
                Response.Write("</a></div></td>");
                Response.Write("<td><div align=\"center\">");
                Response.Write("<a href=\"#\" onclick=\"del(" + dt.Rows[i]["ID"] + ")\">删除</a> ");
                Response.Write("<a href=\"edit.aspx?id=" + dt.Rows[i]["ID"] + "\">修改</a> </div></td>");
                Response.Write("</tr>");
                showSource(int.Parse(dt.Rows[i]["ID"].ToString()), lv + "　　　　");
            }
        }
    }
}
