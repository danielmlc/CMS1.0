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
    public DataTable dt;
    public int page;
    MyDB db = new MyDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        db.Open();
        //table = db.Execute("select top " + (RNA.getPage() * 5) + " * from [Components]");
        dt = db.Execute("select * from [Components]");
        db.Close();
    }
}
