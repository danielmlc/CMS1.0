using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class System_Comp_Constant_Edit : systempage
{
    public int id = Core.getID();

    public string Name = "";
    public string Value = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Core.isPost())
        {
            Core.get(out Name, "Name");
            Core.get(out Value, "Value");

            if (id > 0)
            {
                    Data.Update("W_Constant",
                    Data.Build("Name", Name) +Data.Build("Value", Value) +
                    Data.Build("UpdateTime", DateTime.Now) +
                    Data.Build("UpdateUser", system.RNA_REALNAME),
                    id
                    );
            }
            else
            {
                Data.Insert("W_Constant",
                    Data.Build("Name", Name) +
                    Data.Build("Value", Value)+
                     Data.Build("AddUser", system.RNA_REALNAME) +
                    Data.Build("AddTime", DateTime.Now)
                    );
            }
            Response.Redirect(History);
        }

        if (id > 0)
        {
            DataTable dt = Data.Execute("SELECT top 1 * FROM [W_Constant] where [id]=" + id);
            if (dt.Rows.Count > 0)
            {
                Data.getData(ref Name, dt.Rows[0]["Name"]);
                Data.getData(ref Value, dt.Rows[0]["Value"]);
            }
        }
    }
}