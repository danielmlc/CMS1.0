using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class System_Comp_List_PictureEdit_Edit :systempage
{
    
    public int id = Core.getID();
    public string ItemTitle = string.Empty;
    public int IsMain = 0;
    public string ItemUrl = string.Empty;
    public string ItemDiscrab = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Core.isPost())
        {
            Core.get(out ItemTitle, "ItemTitle");
            Core.get(out IsMain, "IsMain");
            Core.get(out ItemUrl, "ItemUrl");
            Core.get(out ItemDiscrab, "ItemDiscrab");
            if (id > 0)
            {

                Data.Update("W_ImageAndtext",
                    Data.Build("ItemTitle", ItemTitle) +
                    Data.Build("IsMain", IsMain) +
                    Data.Build("ItemUrl", ItemUrl) +
                    Data.Build("ItemDiscrab", ItemDiscrab), id
                    );
            }
            else
            {  
                Data.Insert("W_ImageAndtext",
                    Data.Build("PID", ProjId) +
                    //Data.Build("Node", Node) +
                    Data.Build("ItemTitle", ItemTitle) +
                    Data.Build("IsMain", IsMain) +
                    Data.Build("ItemUrl", ItemUrl) +
                    Data.Build("ItemDiscrab", ItemDiscrab));
            }
            Response.Redirect(History);
        }

        if (id > 0)
        {
            DataTable dt = Data.Execute("SELECT top 1 * FROM [W_ImageAndtext] where [id]=" + id);
            if (dt.Rows.Count > 0)
            {

                Data.getData(ref ItemTitle, dt.Rows[0]["ItemTitle"]);
                Data.getData(ref IsMain, dt.Rows[0]["IsMain"]);
                Data.getData(ref ItemUrl, dt.Rows[0]["ItemUrl"]);
                Data.getData(ref ItemDiscrab, dt.Rows[0]["ItemDiscrab"]);               
            }
        }
    
    }
}