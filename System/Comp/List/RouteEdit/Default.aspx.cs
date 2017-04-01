using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class System_Comp_List_PictureEdit_Default :systempage
{
    public DataTable dt;
    public int page;
    public int tid; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (RNA.getStr("act") == "del")
        {
            Data.Delete("W_SuperAttch", RNA.getID());
            Response.Redirect(History);
        }
        WriHistory();//写历史cookie
      //  tid = int.Parse(Data.Execute("select top 1  Comp_ProJ_ID from TRAV_COMP_LIST where id=" + ProjId).Rows[0]["Comp_ProJ_ID"].ToString());
        dt = Data.Execute("SELECT * FROM [W_SuperAttch] where PID=" + ProjId + " order by [ID]");
    }
}