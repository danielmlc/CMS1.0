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

public partial class System_Comp_List_Edit : systempage
{

    public int  id=Core.getID();
    public string tit = string.Empty;
    //public int PROJ_TYPE;
    public string S_str1=string.Empty;
    public string S_str2 = string.Empty;
    public string S_str3 = string.Empty;
    public string S_str4 = string.Empty;
    public string S_str5 = string.Empty;
    public string S_str6 = string.Empty;
    public string M_str1 = string.Empty;
    public string M_str2 = string.Empty;
    public string M_str3 = string.Empty;
    public string L_str1 = string.Empty;
    public string L_str2 = string.Empty;
    public string L_str3 = string.Empty;
    public string L_str4 = string.Empty;
    public float Float1;
    public float Float2;
    public int Int1;
    public int Int2;
    public DateTime Datetime1=DateTime.Now;
    public DateTime Datetime2= DateTime.Now;
    public int Index;
    public string KeyWords = string.Empty;
    public int Active = 1;
    public string Link=string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        WriNode(Core.getInt("node"));
        if (Core.isPost())
        {
            //Core.get(out PROJ_TYPE,  "PROJ_TYPE" );
            Core.get(out S_str1, "S_str1");
            Core.get(out S_str2, "S_str2");
            Core.get(out S_str3, "S_str3");
            Core.get(out S_str4, "S_str4");
            Core.get(out S_str5, "S_str5");
            Core.get(out S_str6, "S_str6");
            Core.get(out M_str1, "M_str1");
            Core.get(out M_str2, "M_str2");
            Core.get(out M_str3, "M_str3");
            Core.get(out L_str1, "L_str1");
            Core.get(out L_str2, "L_str2");
            Core.get(out L_str3, "L_str3");
            Core.get(out L_str4, "L_str4");
            Core.get(out Float1, "Float1");
            Core.get(out Float2, "Float1");
            Core.get(out Int1, "Int1");
            Core.get(out Int2, "Int2");
            Core.get(out Datetime1, "Datetime1");
            Core.get(out Datetime2, "Datetime2");
            Core.get(out Index, "Index");
            Core.get(out KeyWords, "KeyWords");
            Core.get(out Active, "Active");
            Core.get(out Link, "Link");
            if (id > 0)
            {
                //修改
                DataTable dt = Data.Execute("SELECT top 1 ID  FROM [V_W_SuperModel] where [id]=" + id);
                Data.Update("W_SuperModel",
                    Data.Build("S_str1", S_str1) +
                    Data.Build("S_str2", S_str2) +
                    Data.Build("S_str3", S_str3) +
                    Data.Build("S_str4", S_str4) +
                    Data.Build("S_str5", S_str5) +
                    Data.Build("S_str6", S_str6) +
                    Data.Build("M_str1", M_str1) +
                    Data.Build("M_str2", M_str2) +
                    Data.Build("M_str3", M_str3) +
                    Data.Build("L_str1", L_str1) +
                    Data.Build("L_str2", L_str2) +
                    Data.Build("L_str3", L_str3) +
                    Data.Build("L_str4", L_str4) +
                     Data.Build("Float1", Float1) +
                    Data.Build("Float2", Float2) +
                    Data.Build("Int1", Int1) +
                    Data.Build("Int2", Int2) +
                    Data.Build("Datetime1", Datetime1) +
                    Data.Build("Datetime2", Datetime2), int.Parse(dt.Rows[0]["ID"].ToString()));
                Data.Update("W_CompList",
                  Data.Build("Index", Index) +
                  Data.Build("KeyWords", KeyWords) +
                  Data.Build("Link", Link) +
                  Data.Build("Active", Active) +
                  Data.Build("UppdataName", system.RNA_REALNAME) +
                  Data.Build("UppdataDate", DateTime.Now),"CompID",ProjId);
                  WriProjId(Core.getID());
            }
            else 
            {
                //新建
                Data.Insert("W_SuperModel",
                    Data.Build("S_str1", S_str1) +
                    Data.Build("S_str2", S_str2) +
                    Data.Build("S_str3", S_str3) +
                    Data.Build("S_str4", S_str4) +
                    Data.Build("S_str5", S_str5) +
                    Data.Build("S_str6", S_str6) +
                    Data.Build("M_str1", M_str1) +
                    Data.Build("M_str2", M_str2) +
                    Data.Build("M_str3", M_str3) +
                    Data.Build("L_str1", L_str1) +
                    Data.Build("L_str2", L_str2) +
                    Data.Build("L_str3", L_str3) +
                    Data.Build("L_str4", L_str4) +
                     Data.Build("Float1", Float1) +
                    Data.Build("Float2", Float2) +
                    Data.Build("Int1", Int1) +
                    Data.Build("Int2", Int2) +
                    Data.Build("Datetime1", Datetime1) +
                    Data.Build("Datetime2", Datetime2));
                    int PROJ_ID = Data.ExecuteGetID("W_SuperModel");
                    Data.Insert("W_CompList",
                    Data.Build("CompID", PROJ_ID) +
                    Data.Build("Index", Index) +
                    Data.Build("Link", Link) +
                    Data.Build("KeyWords", KeyWords) +
                    Data.Build("Active", Active) +
                    Data.Build("Node", Node) +
                    Data.Build("AddName", system.RNA_REALNAME) +
                    Data.Build("AddDate", DateTime.Now));
                    WriProjId(PROJ_ID);
            }
            Response.Redirect("Nextpage.aspx");
        }
        tit = Data.Execute("select top 1 [Name] from [W_DataSource] where ID=" + RNA.getNode()).Rows[0][0].ToString();
        //赋值
        if (id > 0)
        {
            DataTable dt = Data.Execute("SELECT top 1 * FROM [V_W_SuperModel] where [id]=" + id);
            if (dt.Rows.Count > 0) 
            {
                Data.getData(ref S_str1, dt.Rows[0]["S_str1"]);
                Data.getData(ref S_str2, dt.Rows[0]["S_str2"]);
                Data.getData(ref S_str3, dt.Rows[0]["S_str3"]);
                Data.getData(ref S_str4, dt.Rows[0]["S_str4"]);
                Data.getData(ref S_str5, dt.Rows[0]["S_str5"]);
                Data.getData(ref S_str6, dt.Rows[0]["S_str6"]);
                Data.getData(ref M_str1, dt.Rows[0]["M_str1"]);
                Data.getData(ref M_str2, dt.Rows[0]["M_str2"]);
                Data.getData(ref M_str3, dt.Rows[0]["M_str3"]);
                Data.getData(ref L_str1, dt.Rows[0]["L_str1"]);
                Data.getData(ref L_str2, dt.Rows[0]["L_str2"]);
                Data.getData(ref L_str3, dt.Rows[0]["L_str3"]); 
                Data.getData(ref L_str4, dt.Rows[0]["L_str4"]);
                Data.getData(ref Float1, dt.Rows[0]["Float1"]);
                Data.getData(ref Float2, dt.Rows[0]["Float2"]);
                Data.getData(ref Int1, dt.Rows[0]["Int1"]);
                Data.getData(ref Int2, dt.Rows[0]["Int2"]);
                Data.getData(ref Datetime1, dt.Rows[0]["Datetime1"]);
                Data.getData(ref Datetime2, dt.Rows[0]["Datetime2"]);
                Data.getData(ref Index, dt.Rows[0]["Index"]);
                Data.getData(ref KeyWords, dt.Rows[0]["KeyWords"]);
                Data.getData(ref Active, dt.Rows[0]["Active"]);
                Data.getData(ref Link, dt.Rows[0]["Link"]);

            }
        }
    }
}
