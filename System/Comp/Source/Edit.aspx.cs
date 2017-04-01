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

public partial class System_Comp_source_edit : systempage
{
    public DataTable dt;
    public int id = Core.getID();
    public string Name = "";
    public string Components = "";
    public string Link = "";
    public int Active = 1;
    public string Param = "";
    public string Preview = "";
    public int Index = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Core.isPost())
        {
            Core.get(out Name, "Name");
            Core.get(out Components, "Components");
            Core.get(out Link, "Link");
            Core.get(out Active, "Active");
            Core.get(out Param, "Param");
            Core.get(out Preview, "Preview");
            Core.get(out Index, "Index");

            if (id > 0)
            {
                Data.Update("W_DataSource",
                    Data.Build("Name", Name) +
                    Data.Build("Components", Components) +
                    Data.Build("Link", Link) +
                    Data.Build("Active", Active) +
                    Data.Build("Param", Param) +
                    Data.Build("UppdataName", system.RNA_REALNAME) +
                    Data.Build("UppdataDate", DateTime.Now) +
                    Data.Build("Preview", Preview) +
                    Data.Build("Index", Index),
                    id
                    );
            }
            else
            {
                Data.Insert("W_DataSource",
                    Data.Build("Name", Name) +
                    Data.Build("Components", Components) +
                    Data.Build("Link", Link) +
                    Data.Build("Active", Active) +
                    Data.Build("Param", Param) + Data.Build("AddName", system.RNA_REALNAME) +
                    Data.Build("AddDate", DateTime.Now) +
                    Data.Build("Preview", Preview) +
                    Data.Build("Index", Index)
                    );
            }
            Response.Redirect(History);
        }

        if (id > 0)
        {
            DataTable dt = Data.Execute("SELECT top 1 * FROM [W_DataSource] where [id]=" + id);
            if (dt.Rows.Count > 0)
            {
                Data.getData(ref Name, dt.Rows[0]["Name"]);
                Data.getData(ref Components, dt.Rows[0]["Components"]);
                Data.getData(ref Link, dt.Rows[0]["Link"]);
                Data.getData(ref Active, dt.Rows[0]["Active"]);
                Data.getData(ref Param, dt.Rows[0]["Param"]);
                Data.getData(ref Preview, dt.Rows[0]["Preview"]);
                Data.getData(ref Index, dt.Rows[0]["Index"]);
            }
        }
    }
}
