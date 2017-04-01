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
    public string AdminName = "";
    public string RealName = "";
    public string AdminPass = "";
    public string AdminPass1 = "";
    public int id = Core.getID();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Core.isPost())
        {
            Core.get(out AdminName, "AdminName");
            Core.get(out RealName, "RealName");
            Core.get(out AdminPass, "AdminPass");
            Core.get(out AdminPass1, "AdminPass1");

            if (id > 0)
            {
                if (AdminPass == "")
                {
                    Data.Update("AdminUser",
                     Data.Build("RealName", RealName),
                     id
                     );
                }
                else
                {
                    AdminPass = FormsAuthentication.HashPasswordForStoringInConfigFile(AdminPass, "SHA1");
                    Data.Update("AdminUser",
                          Data.Build("RealName", RealName) +
                          Data.Build("AdminPass", AdminPass),
                          id
                          );
                }
            }
            else
            {
                AdminPass = FormsAuthentication.HashPasswordForStoringInConfigFile(AdminPass, "SHA1");
                Data.Insert("AdminUser",
                    Data.Build("AdminName", AdminName) +
                    Data.Build("RealName", RealName) +
                    Data.Build("AdminPass", AdminPass)
                    );
            }
            Response.Redirect(History);
        }

        if (id > 0)
        {
            DataTable dt = Data.Execute("SELECT top 1 * FROM [AdminUser] where [id]=" + id);
            if (dt.Rows.Count > 0)
            {
                Data.getData(ref AdminName, dt.Rows[0]["AdminName"]);
                Data.getData(ref RealName, dt.Rows[0]["RealName"]);
            }
        }
    }
}
