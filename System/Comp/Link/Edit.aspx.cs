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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public partial class System_Comp_List_Edit : systempage
{
    public string tit = "";
    public int id = Core.getID();
    public int node=Core.getNode();
    public string ItemTitle = "";
    public string KeyWords = string.Empty;
    public int Index;
    public int Active = 1;
    public string ItemUrl = "";
    public string ItemDiscrab = "";
    public string Link = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Core.isPost())
        {
            Core.get(out ItemTitle, "ItemTitle");
            Core.get(out Index, "Index");
            Core.get(out Active, "Active");
            Core.get(out Link, "Link");
            Core.get(out KeyWords, "KeyWords");
            Core.get(out ItemUrl, "ItemUrl");
            Core.get(out ItemDiscrab, "ItemDiscrab");
       
            if (id > 0)
            {  //修改
                Data.Update("W_ImageAndtext",
                 Data.Build("ItemTitle", ItemTitle) +
                 Data.Build("ItemUrl", ItemUrl) +
                 Data.Build("ItemDiscrab", ItemDiscrab), id);
                int listid = int.Parse(Data.Execute("select ID from W_CompList where WtID=" + id).Rows[0]["ID"].ToString());
                Data.Update("W_CompList",
                  Data.Build("Link", Link) +
                  Data.Build("KeyWords", KeyWords) +
                  Data.Build("Index", Index) +
                  Data.Build("UppdataName", system.RNA_REALNAME) +
                  Data.Build("UppdataDate", DateTime.Now) +
                  Data.Build("Active", Active), listid);
            }
            else
            {  //新增

                Data.Insert("W_ImageAndtext",
                    Data.Build("ItemTitle", ItemTitle) +
                    Data.Build("ItemUrl", ItemUrl) +
                    Data.Build("ItemDiscrab", ItemDiscrab));
                int listid = Data.ExecuteGetID("W_ImageAndtext");
                Data.Insert("W_CompList",
                  Data.Build("WtID", listid) +
                  Data.Build("Node", node) +
                  Data.Build("Link", Link) +
                  Data.Build("KeyWords", KeyWords) +
                  Data.Build("Index", Index) +
                  Data.Build("AddName", system.RNA_REALNAME) +
                  Data.Build("AddDate", DateTime.Now) +
                  Data.Build("Active", Active));
                  
            }
            Response.Redirect(History);
        }
        tit = Data.Execute("select top 1 [Name] from [W_DataSource] where ID=" + RNA.getNode()).Rows[0][0].ToString();
        if (id > 0)
        {
            DataTable dt = Data.Execute("SELECT top 1 * FROM [V_W_ImageAndText] where [id]=" + id);
            if (dt.Rows.Count > 0)
            {
                Data.getData(ref ItemTitle, dt.Rows[0]["ItemTitle"]);
                Data.getData(ref Link, dt.Rows[0]["Link"]);
                Data.getData(ref Index, dt.Rows[0]["Index"]);
                Data.getData(ref Active, dt.Rows[0]["Active"]);
                Data.getData(ref ItemUrl, dt.Rows[0]["ItemUrl"]);
                Data.getData(ref KeyWords, dt.Rows[0]["KeyWords"]);
                Data.getData(ref Link, dt.Rows[0]["Link"]);
                Data.getData(ref ItemDiscrab, dt.Rows[0]["ItemDiscrab"]);
            }
        }
    }
}
