using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class System_Comp_List_PictureEdit_Edit :systempage
{
    
    public int id = Core.getID();
    public string Title = string.Empty;
    public string NutShell = string.Empty;
    public string Content = string.Empty;
    public string Remark = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Core.isPost())
        {
            Core.get(out Title, "Title");
            Core.get(out NutShell, "NutShell");
            Core.get(out Content, "Content");
            Core.get(out Remark, "Remark");
            if (id > 0)
            {

                Data.Update("W_SuperAttch",
                    Data.Build("Title", Title) +
                    Data.Build("NutShell", NutShell) +
                    Data.Build("Content", Content) +
                    Data.Build("Remark", Remark), id
                    );
            }
            else
            {  
                Data.Insert("W_SuperAttch",
                    Data.Build("PID", ProjId) +
                    Data.Build("Node", Node) +
                    Data.Build("Title", Title) +
                    Data.Build("NutShell", NutShell) +
                    Data.Build("Content", Content) +
                    Data.Build("Remark", Remark));
            }
            Response.Redirect(History);
        }

        if (id > 0)
        {
            DataTable dt = Data.Execute("SELECT top 1 * FROM [W_SuperAttch] where [id]=" + id);
            if (dt.Rows.Count > 0)
            {
                Data.getData(ref Title, dt.Rows[0]["Title"]);
                Data.getData(ref NutShell, dt.Rows[0]["NutShell"]);
                Data.getData(ref Remark, dt.Rows[0]["Remark"]);
                Data.getData(ref Content, dt.Rows[0]["Content"]);               
            }
        }
    
    }
}