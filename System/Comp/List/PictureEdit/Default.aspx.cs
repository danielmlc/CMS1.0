using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class System_Comp_List_PictureEdit_Default :systempage
{
    public DataTable dt;
    public int page;
    public int tid; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (RNA.getStr("act") == "del")
        {
          
          //  File.Delete(System.Web.HttpContext.Current.Server.MapPath(Data.Execute("SELECT top 1 * FROM [W_ImageAndText] where ID=" + RNA.getID()).Rows[0]["Itemurl"].ToString()));
            Data.Delete("W_ImageAndtext", RNA.getID());
            Response.Redirect(History);
        }
        WriHistory();//写历史cookie
       // tid = int.Parse(Data.Execute("select top 1  Comp_ProJ_ID from TRAV_COMP_LIST where id=" + ProjId).Rows[0]["Comp_ProJ_ID"].ToString());
       
        dt = Data.Execute("SELECT * FROM [W_ImageAndtext] where PID=" + ProjId + " order by [IsMain],[ID]");
    }
}