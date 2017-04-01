using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Management;
using System.Xml;

/// <summary>
///rna 的摘要说明
/// </summary>
public class RNA
{

    public RNA()
	{
        
	}

    static public string GetMCODE() 
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(GetMAC() + "RNA" + GetCPUID(), "SHA1");
    }

    static public string GetMAC()
    {
        string MAC = "";
        ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        ManagementObjectCollection moc = mc.GetInstances();
        foreach (ManagementObject mo in moc)
        {
            if ((bool)mo["IPEnabled"] == true)
                MAC = mo["MacAddress"].ToString();
            mo.Dispose();
        }
        return MAC;
    }

    static public string GetCPUID()
    {
        string CPUID = "";
        ManagementClass mc = new ManagementClass("Win32_Processor");
        ManagementObjectCollection moc = mc.GetInstances();
        foreach (ManagementObject mo in moc)
        {
            CPUID = mo.Properties["ProcessorId"].Value.ToString();
            mo.Dispose();
        }
        return CPUID;
    }

    static public bool chkRegKey()
    {
        try
        {
            string LIC = "";
            LIC = FormsAuthentication.HashPasswordForStoringInConfigFile(GetMAC() + GetMCODE() + GetCPUID(), "SHA1");

            XmlDocument xml = new XmlDocument();
            xml.Load(System.Web.HttpContext.Current.Server.MapPath("/system/lic.xml"));
            if (xml.SelectSingleNode("/lic").InnerText.ToString() == LIC)
            {
                return true;
            }
        }
        catch
        { 

        }
        return false;
    }


    static public void chkAdmin() 
    {
        try
        {
            string RNA_ADMINUSER = HttpContext.Current.Request.Cookies["RNA_ADMINUSER"].Value;
            string RNA_REALNAME = HttpContext.Current.Request.Cookies["RNA_REALNAME"].Value;
            string RNA_ADMINGROUP = HttpContext.Current.Request.Cookies["RNA_ADMINGROUP"].Value;
            string RNA_TOKEN = HttpContext.Current.Request.Cookies["RNA_TOKEN"].Value;
            string RNA_SESSION = HttpContext.Current.Request.Cookies["RNA_SESSION"].Value;
            string token = RNA_ADMINUSER + RNA_ADMINGROUP + RNA_SESSION + System.Configuration.ConfigurationManager.AppSettings["Token"].ToString();

            token = FormsAuthentication.HashPasswordForStoringInConfigFile(token, "SHA1");

            if (token != RNA_TOKEN)
            {
                Error("没有权限1！");
            }
        }
        catch
        {
            Error("没有权限2！");
        }
    }

    static public void Error(string str)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write("<html>");
        HttpContext.Current.Response.Write("<script type=\"text/javascript\">");
        HttpContext.Current.Response.Write("alert(\""+str+"\");");
        HttpContext.Current.Response.Write("history.go(-1);return false;");
        HttpContext.Current.Response.Write("</script>");
        HttpContext.Current.Response.Write("</html>");
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.End();
    }
    static public void Messagetag(string str)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write("<html>");
        HttpContext.Current.Response.Write("<script type=\"text/javascript\">");
        HttpContext.Current.Response.Write("alert(\"" + str + "\");");
        HttpContext.Current.Response.Write("</script>");
        HttpContext.Current.Response.Write("</html>");
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.End();
    }
    static public int startIndex()
    {
        int nowpage = getPage();
        int pageNum = int.Parse(System.Configuration.ConfigurationManager.AppSettings["tableLineNumber"].ToString());
        return (nowpage - 1) * pageNum;
    }


    static public string getExt(string filename)
    {
        switch (filename.Split('.')[filename.Split('.').Length - 1].ToLower()) 
        { 
            case "jpg":
            case "gif":
            case "png":
                return "jpg.gif";
                break;
            case "rar":
            case "zip":
            case "7z":
            case "jar":
                return "zip.gif";
                break;
            case "exe":
                return "exe.gif";
                break;
            case "pdf":
                return "pdf.gif";
                break;
            case "htm":
                return "htm.gif";
                break;
            case "txt":
                return "txt.gif";
                break;
            case "doc":
            case "docx":
                return "doc.gif";
                break;
            case "ppt":
            case "pptx":
                return "ppt.gif";
                break;
            case "wps":
                return "wps.gif";
                break;
            default:
                return "___.gif";
                break;
        }
    }

    static public bool chkFormNull(string attr)
    {
        string[] attr1 = attr.Split(',');

        for (int i = 1; i < attr1.Length; i++)
        {
            try
            {
                string str = HttpContext.Current.Request.Form[attr1[i]].ToString();
                if (str == "")
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        return true;
    }

    static public int getFormInt(string attr)
    {
        int num;
        try
        {
            num = int.Parse(HttpContext.Current.Request.Form[attr].ToString());
        }
        catch
        {
            num = 0;
        }
        return num;
    }

    static public string getFormStr(string attr)
    {
        string str;
        try
        {  

            str = HttpContext.Current.Request.Form[attr].ToString();
            str = str.Replace("\'", "\'\'");
        }
        catch
        {
            str = "";
        }
        return str;
    }

    static public string getStr(string attr)
    {
        string str;
        try
        {
            str = HttpContext.Current.Request[attr].ToString();
            str = str.Replace("\'", "\'\'");
        }
        catch
        {
            str = "";
        }
        return str;
    }

    static public int endIndex(int allCount)
    {
        int nowpage = getPage();
        int pageNum = int.Parse(System.Configuration.ConfigurationManager.AppSettings["tableLineNumber"].ToString());
        if (allCount > nowpage * pageNum)
        {
            return nowpage * pageNum;
        }
        else
        {
            return allCount;
        }
         
    }

    static public int getPage() 
    {
        int nowpage;
        string page;
        try
        {
            page = HttpContext.Current.Request["page"].ToString();
        }
        catch 
        {
            page = "";
        }
        if ((page == null) || (page == ""))
        {
            nowpage = 1;
        }else
        {
            nowpage = int.Parse(page);
        }

        return nowpage;
    }

    static public int getID()
    {
        int id;
        try
        {
            id = int.Parse(HttpContext.Current.Request["id"].ToString());
        }
        catch
        {
            id = 0;
        }

        return id;
    }
    static public int getNode()
    {
        int node;
        try
        {
            node = int.Parse(HttpContext.Current.Request["node"].ToString());
        }
        catch
        {
            node = 0;
        }

        return node;
    }

    static public int getClass()
    {
        int cls;
        try
        {
            cls = int.Parse(HttpContext.Current.Request["class"].ToString());
        }
        catch
        {
            cls = 0;
        }

        return cls;
    }


    static public int getGroup()
    {
        int group;
        try
        {
            group = int.Parse(HttpContext.Current.Request["group"].ToString());
        }
        catch
        {
            group = 0;
        }

        return group;
    }

    static public int getVT()
    {
        int vt;
        try
        {
            vt = int.Parse(HttpContext.Current.Request["vt"].ToString());
        }
        catch
        {
            vt = 0;
        }

        return vt;
    }

    static public int allPage(int num) 
    {
        int pageNum = int.Parse(System.Configuration.ConfigurationManager.AppSettings["tableLineNumber"].ToString());
        return (int)((num - 1) / pageNum) + 1;
    }


    static public string page(int num)
    {
        int maxpage = allPage(num);
        int node = getNode();
        int nowpage = RNA.getPage();
        string str = "<div id=\"page\">";
        if (nowpage<10) {
            if (maxpage>1) {
                if (nowpage>1) {
                    str += "<a href=\"?node="+node+"&page=1\">首页</a> ";
                    str += "<a href=\"?node="+node+"&page=" + (nowpage - 1) + "\">上一页</a> ";
                } else {
                    str += "<span class=\"gray\">首页</span> ";
                    str += "<span class=\"gray\">上一页</span> ";
                }
                if (maxpage<11) {
                    for (int i=1;i<maxpage+1;i++) {
                        if (nowpage==i) {
                            str += "<span class=\"red\">" + i + "</span> ";
                        } else {
                            str += "<a href=\"?node="+node+"&page=" + i + "\">" + i + "</a> ";
                        }
                    }
                }else{
                    for (int i=1;i<11;i++) {
                        if (nowpage==i) {
                            str += "<span class=\"red\">" + i + "</span> ";
                        } else {
                            str += "<a href=\"?node="+node+"&page=" + i + "\">" + i + "</a> ";
                        }
                    }
                }
                if (nowpage<maxpage) {
                    str += "<a href=\"?node="+node+"&page=" + (nowpage + 1) + "\">下一页</a> ";
                    str += "<a href=\"?node="+node+"&page=" + maxpage + "\">尾页</a>";
                } else {
                    str += "<span class=\"gray\">下一页</span> ";
                    str += "<span class=\"gray\">尾页</span>";
                }
            }
        }else{
            if (maxpage-nowpage>=9){
                if (maxpage>1) {
                    if (nowpage>1) {
                        str += "<a href=\"?node="+node+"&page=1\">首页</a> ";
                        str += "<a href=\"?node="+node+"&page=" + (nowpage - 1) + "\">上一页</a> ";
                    } else {
                        str += "<span class=\"gray\">首页</span> ";
                        str += "<span class=\"gray\">上一页</span> ";
                    }
                    for (int i=nowpage-4;i<nowpage+5;i++) {
                        if (nowpage==i) {
                            str += "<span class=\"red\">" + i + "</span> ";
                        } else {
                            str += "<a href=\"?node="+node+"&page=" + i + "\">" + i + "</a> ";
                        }
                    }
                    if (nowpage<maxpage) {
                        str += "<a href=\"?node="+node+"&page=" + (nowpage + 1) + "\">下一页</a> ";
                        str += "<a href=\"?node="+node+"&page=" + maxpage + "\">尾页</a>";
                    } else {
                        str += "<span class=\"gray\">下一页</span> ";
                        str += "<span class=\"gray\">尾页</span>";
                    }
                }
            }else{
                if (maxpage>1) {
                    if (nowpage>1) {
                        str += "<a href=\"?node="+node+"&page=1\">首页</a> ";
                        str += "<a href=\"?node="+node+"&page=" + (nowpage - 1) + "\">上一页</a> ";
                    } else {
                        str += "<span class=\"gray\">首页</span> ";
                        str += "<span class=\"gray\">上一页</span> ";
                    }
                    for (int i=maxpage-9;i<maxpage+1;i++) {
                        if (nowpage==i) {
                            str += "<span class=\"red\">" + i + "</span> ";
                        } else {
                            str += "<a href=\"?node="+node+"&page=" + i + "\">" + i + "</a> ";
                        }
                    }
                    if (nowpage<maxpage) {
                        str += "<a href=\"?node="+node+"&page=" + (nowpage + 1) + "\">下一页</a> ";
                        str += "<a href=\"?node="+node+"&page=" + (maxpage - 1) + "\">尾页</a>";
                    } else {
                        str += "<span class=\"gray\">下一页</span> ";
                        str += "<span class=\"gray\">尾页</span>";
                    }
                }
            }
        }
        str += "</div>";
        return str;
    }

    static public string actBar(string value)
    {
        string str = "";
        for (int i = 0; i < value.Length; i++)
        {
            switch (value.Substring(i, 1))
            {
                case "n":
                    str += "<a href=\"edit.aspx\"><img src=\"../../images/new.gif\" border=\"0\" /></a>";
                    break;
                case "a":
                    if (getGroup() == 0)
                    {
                        if (getVT() == 0)
                        {
                            str += "<a href=\"edit.aspx?node=" + getNode() + "\"><img src=\"../../images/new.gif\" border=\"0\" /></a>";
                        }
                        else 
                        {
                            str += "<a href=\"edit.aspx?node=" + getNode() + "&vt=" + getVT() + "\"><img src=\"../../images/new.gif\" border=\"0\" /></a>";
                        }
                    }
                    else
                    {
                        if (getVT() == 0)
                        {
                            str += "<a href=\"edit.aspx?node=" + getNode() + "&group=" + getGroup() + "\"><img src=\"../../images/new.gif\" border=\"0\" /></a>";
                        }
                        else
                        {
                            str += "<a href=\"edit.aspx?node=" + getNode() + "&group=" + getGroup() + "&vt=" + getVT() + "\"><img src=\"../../images/new.gif\" border=\"0\" /></a>";
                        }
                    }
                    break;
                case "d":
                    str += "<a href=\"#\" onclick=\"delall()\"><img src=\"../../images/del.gif\" border=\"0\" /></a>";
                    break;
                case "b":
                    str += "<a href=\"#\"><img src=\"../../images/back.gif\" border=\"0\" /></a>";
                    break;
                case "p":
                    str += "<a href=\"#\" onclick=\"pub()\"><img src=\"../../images/pub.gif\" border=\"0\" /></a>";
                    break;
                case "s":
                    str += "<a href=\"#\" onclick=\"save()\"><img src=\"../../images/save.gif\" border=\"0\" /></a>";
                    break;
                case "g":
                    str += "<a href=\"#\" onclick=\"history.go(-1);return false;\"><img src=\"../../images/goback.gif\" border=\"0\" /></a>";
                    break;
				case "x":
                    str += "<a href=\"#\" onclick=\"next()\"><img src=\"../../images/next.gif\" border=\"0\" /></a>";
                    break;
                case "e":
                    str += "<a href=\"#\" onclick=\"xls()\"><img src=\"../../images/xls.gif\" border=\"0\" /></a>";
                    break;
                default:
                    break;
            }
        }
        return str;
    }


    static public string showCompList(int id)
    {
        string str = "";
        DataTable dt;
        MyDB db = new MyDB();
        db.Open();
        dt = db.Execute("select * from [Components] where [Type]=" + id);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            str += "<option value=\"" + dt.Rows[i]["ID"] + "\">" + dt.Rows[i]["Name"] + " - " + dt.Rows[i]["About"] + "</option>";
        }
        db.Close();
        return str;
    }

    static public string showCompList(int id, string sid)
    {
        string str = "";
        DataTable dt;
        MyDB db = new MyDB();
        db.Open();
        dt = db.Execute("select * from [Components] where [Type]=" + id);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            str += "<option value=\"" + dt.Rows[i]["ID"] + "\"";
            if (sid == dt.Rows[i]["ID"].ToString())
                str += "selected=\"selected\" style=\"color:#00F\"";
            str += ">" + dt.Rows[i]["Name"] + " - " + dt.Rows[i]["About"] + "</option>";
        }
        db.Close();
        return str;
    }

    static public string showSourceList(int id, string lv)
    {
        string str = "";
        DataTable dt;
        MyDB db = new MyDB();
        db.Open();
        dt = db.Execute("select * from [SubMenu] where [Link]=" + id);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i == dt.Rows.Count-1)
            {
                str += "<option value=\"" + dt.Rows[i]["ID"] + "\">" + lv + "　└" + dt.Rows[i]["Name"] + "</option>";
                str += showSourceList(int.Parse(dt.Rows[i]["ID"].ToString()), lv + "　　");
            }
            else
            {
                str += "<option value=\"" + dt.Rows[i]["ID"] + "\">" + lv + "　├" + dt.Rows[i]["Name"] + "</option>";
                str += showSourceList(int.Parse(dt.Rows[i]["ID"].ToString()), lv + "　│");
            }
        }
        db.Close();
        return str;
    }

    static public string showSourceList(int id, string lv, string link)
    {
        string str = "";
        DataTable dt;
        MyDB db = new MyDB();
        db.Open();
        dt = db.Execute("select * from [SubMenu] where [Link]=" + id);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i == dt.Rows.Count - 1)
            {
                str += "<option value=\"" + dt.Rows[i]["ID"] + "\"";
                if (link == dt.Rows[i]["ID"].ToString())
                    str += "selected=\"selected\" style=\"color:#00F\"";
                str += ">" + lv + "　└" + dt.Rows[i]["Name"] + "</option>";
                str += showSourceList(int.Parse(dt.Rows[i]["ID"].ToString()), lv + "　　", link);
            }
            else
            {
                str += "<option value=\"" + dt.Rows[i]["ID"] + "\"";
                if (link == dt.Rows[i]["ID"].ToString())
                    str += "selected=\"selected\" style=\"color:#00F\"";
                str += ">" + lv + "　├" + dt.Rows[i]["Name"] + "</option>";
                str += showSourceList(int.Parse(dt.Rows[i]["ID"].ToString()), lv + "　│", link);
            }
        }
        db.Close();
        return str;
    }
}
