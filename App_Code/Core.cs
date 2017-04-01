using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Data;
/// <summary>
///Core 的摘要说明
/// </summary>
public class Core
{
	public Core()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public static int ToGetID(string tablename ,string field,string fieldname)
    {
       DataTable dt=Data.Execute("select top 1 id  from " + tablename + " where " + fieldname + "='" + field+"'");
       if (dt.Rows.Count != 0)
       {
           return int.Parse(dt.Rows[0]["id"].ToString());
       }
       return 0;
    }

    public static string setstrlength(string str, int start, int length)
    {
        if (str.Length > length)
        {
            str = str.Substring(start, length - 1) + "...";
        }
        return str;
    }

    public static string hit(string str)
    {
        string hitstr = "";
        if (str.Length / 3 == 1)
        {
            hitstr = str;
        }
        else
        {
            if (str.Length % 3 == 0)
            {
                for (int j = str.Length / 3; j > 0; j--)
                {
                    hitstr += "," + str.Substring(str.Length - (3 * (j - 1)), 3);
                }
                hitstr = hitstr.Substring(1, hitstr.Length - 1);
            }
            else
            {
                hitstr = str.Substring(0, str.Length % 3);
                str = str.Substring(str.Length % 3, str.Length - str.Length % 3);
                for (int j = str.Length / 3; j > 0; j--)
                {
                    hitstr += "," + str.Substring(str.Length - 3 * j, 3);
                }
            }
        }
        return hitstr;
    }

    static public void Mark()
    {
        string path = HttpContext.Current.Request.FilePath.Split('/')[2];
        Cookies("USER_" + path, HttpContext.Current.Request.Url.ToString());
    }

    static public string getMark()
    {
        string path = HttpContext.Current.Request.FilePath.Split('/')[2];
        return Cookies("USER_" + path);
    }

    static public void ReMark()
    {
        if (HttpContext.Current.Request.UrlReferrer != null)
        {
            Cookies("USER_path", HttpContext.Current.Request.UrlReferrer.AbsoluteUri.ToString());
        }
    }

    static public string getReMark()
    {
        return Cookies("USER_path");
    }

    static public void RegMark()
    {
        if (HttpContext.Current.Request.UrlReferrer != null)
        {
            Cookies("regpath", HttpContext.Current.Request.UrlReferrer.AbsoluteUri.ToString());
        }
    }

    static public string getRegMark()
    {
        return Cookies("regpath");
    }

    static public void LoginMark()
    {
        if (HttpContext.Current.Request.UrlReferrer != null)
        {
            Cookies("loginpath", HttpContext.Current.Request.UrlReferrer.AbsoluteUri.ToString());
        }
    }

    static public string getLoginMark()
    {
        return Cookies("loginpath");
    }

    static public void Session(string name, string value)
    {
        HttpContext.Current.Session[name] = HttpContext.Current.Server.UrlEncode(value);
    }
    static public string Session(string name)
    {
        try
        {
            return HttpContext.Current.Server.UrlDecode(HttpContext.Current.Session[name].ToString()).ToString();
        }
        catch
        {
            return "";
        }
    }

    static public bool isLogin()
    {
        HttpContext.Current.Response.Expires = 0;
        HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        HttpContext.Current.Response.AddHeader("cache-control", "private");
        HttpContext.Current.Response.AddHeader("pragma", "no-cache");

        // 验证关键数据
        string USER_SESSION = Core.Cookies("USER_SESSION");
        if ((USER_SESSION != "") && (USER_SESSION == System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(
            Core.Cookies("USER_ID") + "|" + Core.Cookies("USER_PASS") + "|" + Core.Cookies("USER_GROUP") + "|" +
            Core.Cookies("USER_ACCESS"), "SHA1").ToUpper()))
        {
            return true;
        }
        return false;
    }

    static public bool testLogin()
    {
        if (!isLogin())
        {
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">\n");
            HttpContext.Current.Response.Write("parent.window.location.href='/';\n");
            HttpContext.Current.Response.Write("history.go(-1);return false;;\n");
            HttpContext.Current.Response.Write("</script>\n");
            HttpContext.Current.Response.End();
            return false;
        }
        return true;
    }

    static public bool isMemberLogin()
    {
        HttpContext.Current.Response.Expires = 0;
        HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        HttpContext.Current.Response.AddHeader("cache-control", "private");
        HttpContext.Current.Response.AddHeader("pragma", "no-cache");

        // 验证关键数据
        if (Core.Cookies("Member_UserName") == "")
        {
            return false;
        }
        return true;
    }

    static public bool testMemberLogin()
    {
        if (!isMemberLogin())
        {
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">\n");
            HttpContext.Current.Response.Write("window.location.href='/';\n");
            //HttpContext.Current.Response.Write("history.go(-1);return false;;\n");
            HttpContext.Current.Response.Write("</script>\n");
            HttpContext.Current.Response.End();
            return false;
        }
        return true;
    }

    static public bool isPost()
    {
        if (HttpContext.Current.Request.HttpMethod == "POST")
        {
            return true;
        }
        return false;
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

    static public int Number(string str)
    {
        try
        {
            return int.Parse(str);
        }
        catch
        {
            return 0;
        }
    }

    static public double Price(string str)
    {
        try
        {
            return double.Parse(str);
        }
        catch
        {
            return 0;
        }
    }

    static public string Date(string str)
    {
        try
        {
            return DateTime.Parse(str).ToString("yyyy-MM-dd");
        }
        catch
        {
            return DateTime.Now.ToString("yyy-MM-dd");
        }
    }

    static public string Date(object str, string format)
    {
        try
        {
            return ((DateTime)str).ToString(format);
        }
        catch
        {
            return "";
        }
    }

    static public int getInt(string name)
    {
        try
        {
            return int.Parse(HttpContext.Current.Request[name].ToString());
        }
        catch
        {
            return 0;
        }
    }

    static public string get()
    {
        try
        {
            return HttpContext.Current.Request.QueryString.ToString();
        }
        catch
        {
            return "";
        }
    }
  

    static public string get(string name)
    {
        try
        {
            return HttpContext.Current.Request[name].ToString().Trim();
        }
        catch 
        {
            return "";
        }
    }
    static public string getform(string name)
    {
        try
        {
            return HttpContext.Current.Request.Form[name].ToString();
        }
        catch
        {
            return "";
        }
    }
    static public int getid(string name)
    {
        try
        {
            return int.Parse(HttpContext.Current.Request[name].ToString());
        }
        catch
        {
            return 0;
        }
    }

    static public int get(out DateTime var, string name)
    {
        try
        {
            var = DateTime.Parse(HttpContext.Current.Request[name]);
        }
        catch
        {
            var = DateTime.Now;
        }
        return 0;
    }

    static public int get(out int var, string name)
    {
        try
        {
            var = int.Parse(HttpContext.Current.Request[name]);
        }
        catch
        {
            var = -1;
        }
        return -1;
    }

    static public int get(out double var, string name)
    {
        try
        {
            var = double.Parse(HttpContext.Current.Request[name]);
        }
        catch
        {
            var = 0;
        }
        return 0;
    }
    static public int get(out float var, string name)
    {
        try
        {
            var = float.Parse(HttpContext.Current.Request[name]);
        }
        catch
        {
            var = 0;
        }
        return 0;
    }
    static public int get(out decimal var, string name)
    {
        try
        {
            var=decimal.Parse(HttpContext.Current.Request[name]);
        }
        catch
        {
             var=0;
        }
        return 0;
    }
    static public int get(out string var, string name)
    {
        try
        {
            var = HttpContext.Current.Request[name].Replace("'", "''");
        }
        catch
        {
            var = "";
        }
        return 0;
    }

    static public int page()
    {
        try
        {
            int pag = int.Parse(HttpContext.Current.Request["page"]);
            if (pag < 1)
            {
                pag = 1;
            };
            return pag;
        }
        catch
        {
            return 1;
        }
    }

    static public int allPage(int num)
    {
        int pageNum = 20;
        return (int)((num - 1) / pageNum) + 1;
    }

    static public int allPage(int num, int pagenum)
    {
        return (int)((num - 1) / pagenum) + 1;
    }

    static public string page(int num)
    {
        return page(num, 20);
    }

    static public string page(int num, int pagenum)
    {
        string url = HttpContext.Current.Request.RawUrl.Trim('?');
        string[] path = url.Split('?');
        string newpath = "";

        if (path.Length > 1)
        {
            string[] attr = path[1].Split('&');
            for (int i = 0; i < attr.Length; i++)
            {
                string[] attr1 = attr[i].Split('=');
                if (attr1[0] != "page")
                {
                    newpath += "&" + attr1[0] + "=" + attr1[1];

                }
            }
        }

        int maxpage = allPage(num, pagenum);
        int nowpage = page();
        string str = "<div id=\"page\">";

        if (nowpage - 1 > 0)
        {
            str += "<a href=\"?page=" + (nowpage - 1) + newpath + "\">上一页</a>&nbsp;";
        }
        else
        {
            str += "上一页&nbsp;";
        }
        for (int i = 0; i < maxpage; i++)
        {
            if (i == nowpage - 1)
            {
                str += "<strong>" + (i + 1) + "</strong>&nbsp;";
            }
            else
            {
                str += "<a href=\"?page=" + (i + 1) + newpath + "\">" + (i + 1) + "</a>&nbsp;";
            }
        }
        if (nowpage >= maxpage)
        {
            str += "下一页";
        }
        else
        {
            str += "<a href=\"?page=" + (nowpage + 1) + newpath + "\">下一页</a>";
        }
        str += "</div>";

        return str;
    }

    static public int startIndex()
    {
        int nowpage = page();
        int pageNum = 20;
        return (nowpage - 1) * pageNum;
    }

    static public int startIndex(int pageNum)
    {
        int nowpage = page();
        return (nowpage - 1) * pageNum;
    }

    static public int endIndex(int allCount)
    {
        int nowpage = page();
        int pageNum = 20;
        if (allCount > nowpage * pageNum)
        {
            return nowpage * pageNum;
        }
        else
        {
            return allCount;
        }

    }

    static public int endIndex(int allCount, int pageNum)
    {
        int nowpage = page();
        if (allCount > nowpage * pageNum)
        {
            return nowpage * pageNum;
        }
        else
        {
            return allCount;
        }

    }

    static public void message(string msg, string jump)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write("<html>");
        HttpContext.Current.Response.Write("<script type=\"text/javascript\">\n");
        HttpContext.Current.Response.Write("alert('" + msg + "');\n");
        HttpContext.Current.Response.Write("window.location.href='" + jump + "';\n");
        HttpContext.Current.Response.Write("</script>\n");
        HttpContext.Current.Response.Write("</html>");
        HttpContext.Current.Response.End();
    }

    static public void alert(string msg)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write("<html>");
        HttpContext.Current.Response.Write("<script type=\"text/javascript\">\n");
        HttpContext.Current.Response.Write("alert('" + msg + "');\n");
        HttpContext.Current.Response.Write("window.history.go(-1);return false;;\n");
        HttpContext.Current.Response.Write("</script>\n");
        HttpContext.Current.Response.Write("</html>");
        HttpContext.Current.Response.End();
        return;
    }

    static public void reflash(string msg)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write("<html>");
        HttpContext.Current.Response.Write("<script type=\"text/javascript\">\n");
        HttpContext.Current.Response.Write("alert('" + msg + "');\n");
        HttpContext.Current.Response.Write("window.location.reload();\n");
        HttpContext.Current.Response.Write("</script>\n");
        HttpContext.Current.Response.Write("</html>");
        HttpContext.Current.Response.End();
    }

    static public void reload()
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write("<html>");
        HttpContext.Current.Response.Write("<script type=\"text/javascript\">\n");
        HttpContext.Current.Response.Write("window.location.reload();\n");
        HttpContext.Current.Response.Write("</script>\n");
        HttpContext.Current.Response.Write("</html>");
        HttpContext.Current.Response.End();
    }

    static public int getID()
    {
        try
        {
            return int.Parse(HttpContext.Current.Request.QueryString["id"]);
        }
        catch
        {
            return 0;
        }
    }

    static public int getNode()
    {
        try
        {
            return int.Parse(HttpContext.Current.Request["node"]);
        }
        catch
        {
            return 0;
        }
    }

    static public int getpinpai()
    {
        try
        {
            return int.Parse(HttpContext.Current.Request["pinpai"]);
        }
        catch
        {
            return 0;
        }
    }

    static public int getcolor()
    {
        try
        {
            return int.Parse(HttpContext.Current.Request["color"]);
        }
        catch
        {
            return 0;
        }
    }

    static public int getrange()
    {
        try
        {
            return int.Parse(HttpContext.Current.Request["range"]);
        }
        catch
        {
            return 0;
        }
    }

    static public int getCLS()
    {
        try
        {
            return int.Parse(HttpContext.Current.Request["cls"]);
        }
        catch
        {
            return 0;
        }
    }

    static public string smallDateTime(object date)
    {
        try
        {
            return DateTime.Parse(date.ToString()).ToString("yy-MM-dd hh:mm");
        }
        catch
        {
            return "";
        }
    }


    public static string Escape(string str)
    {
        if (str == null)
            return String.Empty;

        StringBuilder sb = new StringBuilder();
        int len = str.Length;

        for (int i = 0; i < len; i++)
        {
            char c = str[i];

            //everything other than the optionally escaped chars _must_ be escaped 
            if (Char.IsLetterOrDigit(c) || c == '-' || c == '_' || c == '/' || c == '\\' || c == '.')
                sb.Append(c);
            else
                sb.Append(Uri.HexEscape(c));
        }

        return sb.ToString();
    }

    public static string UnEscape(string str)
    {
        if (str == null)
            return String.Empty;

        StringBuilder sb = new StringBuilder();
        int len = str.Length;
        int i = 0;
        while (i != len)
        {
            if (Uri.IsHexEncoding(str, i))
                sb.Append(Uri.HexUnescape(str, ref i));
            else
                sb.Append(str[i++]);
        }

        return sb.ToString();
    }


    /// <summary>
    /// 写Cookies
    /// </summary>
    /// <param name="name">键值</param>
    /// <param name="value">内容</param>
    /// <param name="expires">过期时间</param>
    static public void Cookies(string name, string value, DateTime expires)
    {
        HttpContext.Current.Response.Cookies[name].Expires = expires;
        HttpContext.Current.Response.Cookies[name].Value = HttpContext.Current.Server.UrlEncode(value);
    }

    /// <summary>
    /// 写Cookies
    /// </summary>
    /// <param name="name">键值</param>
    /// <param name="value">内容</param>
    static public void Cookies(string name, string value)
    {
        HttpContext.Current.Response.Cookies[name].Value = HttpContext.Current.Server.UrlEncode(value);
    }

    /// <summary>
    /// 读Cookies
    /// </summary>
    /// <param name="name">键值</param>
    /// <returns>内容</returns>
    static public string Cookies(string name)
    {
        try
        {
            return HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Cookies[name].Value).ToString();
        }
        catch
        {
            return "";
        }
    }


    static public List<string> DellString(string str)
    {
        List<string> Liststr = new List<string>();
        int m = str.TrimEnd('|').Split('|').Length;
        for (int i = 0; i < m; i++)
        {
            Liststr.Add(str.TrimEnd('|').Split('|')[i]);
        }
        return Liststr;
    }
    static public string DellSelStr(string str,string str1)
    {
        string  Liststr=string.Empty;
        int m = str.TrimEnd('|').Split('|').Length;
        for (int i = 0; i < m; i++)
        {
            Liststr += (str.TrimEnd('|').Split('|')[i]) + " like '%" + str1 + "%' or ";
        }
        return Liststr.Substring(0, Liststr.Length-3);
    }

    #region ID生产器    eg "XX"0000000001
    /// <summary>
    /// 编号生产器
    /// </summary>
    /// <param name="j">编号副名</param>
    /// <param name="tablename">表名</param>
    /// <param name="IDname">字段ID名称</param>
    /// <returns></returns>
    public static string GroupID(string IDname, string tablename, string ID)
    {
        //先取回数据表中的最大ID
        string str = "select MAX(" + ID + ") from " + tablename;
        int n;
        string m = Data.Execute(str).Rows[0][0].ToString();
        if (m == "")
        {
            //当数据表中数据为空时
            n = 1;
        }
        else
        {
            //当数据表中有数据时对字符串进行处理
            n = Convert.ToInt32(m.Substring(IDname.Length));
            n = n + 1;
        }

        string i = "";
        if (n < 10)
        {
            i = IDname + "00000" + n;
        }
        if (n >= 10 && n < 100)
        {
            i = IDname + "0000" + n;
        }
        if (n >= 100 && n < 1000)
        {
            i = IDname + "000" + n;
        }
        if (n >= 1000 && n < 10000)
        {
            i = IDname + "00" + n;
        }
      
        return i;
    }
    #endregion

}
