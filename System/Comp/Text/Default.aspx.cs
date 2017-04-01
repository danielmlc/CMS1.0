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
    public string title;
    public int node = Core.getInt("node");
    public string Title = "";
    public string Text = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        title = Data.Execute("SELECT top 1 [Name] FROM [W_DataSource] where [id]=" + node).Rows[0][0].ToString();
        if (Core.isPost())
        {
            Core.get(out Title, "S_str1");
            Core.get(out Text, "L_str1");
            DataTable dt1 = Data.Execute("SELECT top 1 * FROM  [V_W_SuperModel] where [Node]=" + node);
            if (dt1.Rows.Count > 0)
            {
                int ID = Convert.ToInt32(dt1.Rows[0]["ID"]);
                Data.Update("W_SuperModel",
                    Data.Build("S_str1", Title) +
                    Data.Build("L_str1", Text),
                    ID);
                int listid = int.Parse(Data.Execute("select ID from W_CompList where CompID=" + ID).Rows[0]["ID"].ToString());
                Data.Update("W_CompList",
                  Data.Build("UppdataName", system.RNA_REALNAME) +
                  Data.Build("UppdataDate", DateTime.Now), listid);
            }
            else 
            {
                Data.Insert("W_SuperModel",
                    Data.Build("S_str1", Title) +
                    Data.Build("L_str1", Text)
                    );
                int listid = Data.ExecuteGetID("W_SuperModel");
                Data.Insert("W_CompList",
                  Data.Build("CompID", listid) +
                  Data.Build("Index", 0) +
                  Data.Build("Active", 1) +
                  Data.Build("Node", node) +
                  Data.Build("AddName", system.RNA_REALNAME) +
                  Data.Build("AddDate", DateTime.Now));
            }
            Response.Redirect(History);
        }
        WriHistory();
        DataTable dt = Data.Execute("SELECT top 1 * FROM [V_W_SuperModel] where [Node]=" + node);
        if (dt.Rows.Count > 0)
        {
            Data.getData(ref Title, dt.Rows[0]["S_str1"]);
            Data.getData(ref Text, dt.Rows[0]["L_str1"]);
        }
    }
}
