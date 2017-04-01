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
using System.Data.SqlClient;
using System.Text;     //因为用了encoding类 
using System.Net;      //因为用了webclient 类
using System.Web.Mail;
//using jmail;
using System.Text.RegularExpressions;
using System.IO;
//using MSXML2;

public class Publicclass 
{
    public static string Title()
    {
        string output = "";
        DataTable dt = Data.Execute("select top 1 * from [Comp_Config] where [Node]=38");
        if (dt.Rows.Count > 0)
        {
            output += dt.Rows[0]["Webname"].ToString();
        }
        return output;
    }

    public static string website()
    {
        string output = "";
        DataTable dt = Data.Execute("select top 1 * from [Comp_Config] where [Node]=38");
        if (dt.Rows.Count > 0)
        {
            output += dt.Rows[0]["WebSite"].ToString();
        }
        return output;
    }

    public static string keywords()
    {
        string output = "";
        DataTable dt = Data.Execute("select top 1 * from [Comp_Config] where [Node]=38");
        if (dt.Rows.Count > 0)
        {
            output += dt.Rows[0]["KeyWord"].ToString();
        }
        return output;
    }

    public static string description()
    {
        string output = "";
        DataTable dt = Data.Execute("select top 1 * from [Comp_Config] where [Node]=38");
        if (dt.Rows.Count > 0)
        {
            output += dt.Rows[0]["Description"].ToString();
        }
        return output;
    }

    public static string copyright()
    {
        string output = "";
        DataTable dt = Data.Execute("select top 1 * from [Comp_Config] where [Node]=38");
        if (dt.Rows.Count > 0)
        {
            output += dt.Rows[0]["CopyRight"].ToString();
        }
        return output;
    }

	public static int page()
    {
        int page;
        try
        {
            page = int.Parse(HttpContext.Current.Request["page"].ToString());
        }
        catch
        {
            page = 1;
        }

        return page;
    }

    public static string ToSBC(string input)
    {
        char[] c = input.ToCharArray();
        for (int i = 0; i < c.Length; i++)
        {
            if (c[i] == 32)
            {
                c[i] = (char)12288;
                continue;
            }
            if (c[i] < 127)
            {
                if (c[i] >= 65 && c[i] <= 90)
                {
                    c[i] = (char)c[i];
                }
                else
                {
                    c[i] = (char)(c[i] + 65248);
                }
            }
        }
        return new string(c);
    }

    public static string GetFirstLetter(string chineseStr)
    {
            byte[] _cBs = System.Text.Encoding.Default.GetBytes(chineseStr);

            if(_cBs.Length<2)
                return chineseStr;

            byte ucHigh, ucLow;
            int  nCode;

            string strFirstLetter = string.Empty;

            for (int i = 0; i < _cBs.Length; i++)
            {

                if (_cBs[i] < 0x80)
                {
                    strFirstLetter += Encoding.Default.GetString(_cBs, i, 1);
                    continue;
                }

                ucHigh = (byte)_cBs[i];
                ucLow = (byte)_cBs[i + 1];
                if ( ucHigh < 0xa1 || ucLow < 0xa1)
                    continue;
                else
                // Treat code by section-position as an int type parameter,
                // so make following change to nCode.
                    nCode = (ucHigh - 0xa0) * 100 + ucLow - 0xa0;

                string str = FirstLetter(nCode);
                strFirstLetter += str != string.Empty ? str : Encoding.Default.GetString(_cBs, i, 2);
                i++;
            }
            return strFirstLetter;
        }

        /**//// <summary>
        /// Get the first letter of pinyin according to specified Chinese character code
        /// </summary>
        /// <param name="nCode">the code of the chinese character</param>
        /// <returns>receive the string of the first letter</returns>
        public static string FirstLetter(int nCode)
        {
            string strLetter = string.Empty;

            if(nCode >= 1601 && nCode < 1637) strLetter = "A";
            if(nCode >= 1637 && nCode < 1833) strLetter = "B";
            if(nCode >= 1833 && nCode < 2078) strLetter = "C";
            if(nCode >= 2078 && nCode < 2274) strLetter = "D";
            if(nCode >= 2274 && nCode < 2302) strLetter = "E";
            if(nCode >= 2302 && nCode < 2433) strLetter = "F";
            if(nCode >= 2433 && nCode < 2594) strLetter = "G";
            if(nCode >= 2594 && nCode < 2787) strLetter = "H";
            if(nCode >= 2787 && nCode < 3106) strLetter = "J";
            if(nCode >= 3106 && nCode < 3212) strLetter = "K";
            if(nCode >= 3212 && nCode < 3472) strLetter = "L";
            if(nCode >= 3472 && nCode < 3635) strLetter = "M";
            if(nCode >= 3635 && nCode < 3722) strLetter = "N";
            if(nCode >= 3722 && nCode < 3730) strLetter = "O";
            if(nCode >= 3730 && nCode < 3858) strLetter = "P";
            if(nCode >= 3858 && nCode < 4027) strLetter = "Q";
            if(nCode >= 4027 && nCode < 4086) strLetter = "R";
            if(nCode >= 4086 && nCode < 4390) strLetter = "S";
            if(nCode >= 4390 && nCode < 4558) strLetter = "T";
            if(nCode >= 4558 && nCode < 4684) strLetter = "W";
            if(nCode >= 4684 && nCode < 4925) strLetter = "X";
            if(nCode >= 4925 && nCode < 5249) strLetter = "Y";
            if(nCode >= 5249 && nCode < 5590) strLetter = "Z";

            //if (strLetter == string.Empty)
            //    System.Windows.Forms.MessageBox.Show(String.Format("信息：\n{0}为非常用字符编码,不能为您解析相应匹配首字母！",nCode));
            return strLetter;
    }


    public static string message(string str, string link)
    {
        string output = "";
        output = output + "<script type=\"text/javascript\">";
        output = output + "alert('"+str+"');";
        output = output + "window.location.href='" + link + "';";
        output = output + "</script>";
        return output;
    }

    public static int get(string str)
    {
        int id;
        try
        {
            id = int.Parse(HttpContext.Current.Request[str].ToString());
        }
        catch
        {
            id = 0;
        }

        return id;
    }

    public static string getStr(string str)
    {
        string output;
        try
        {
            output = HttpContext.Current.Request[str].ToString();
        }
        catch
        {
            output = "";
        }
        output = output.Replace("'", "''");

        return output;
    }

    public static string setstrlength(string str, int start, int end)
    {
        if (str.Length > end)
        {
            str = str.Substring(start, end - 1) + "...";
        }
        else
        {
            str = str;
        }
        return str;
    }
	
	public static string showtree(int tree,int node){
	   string output = "";
	   MyDB db = new MyDB();
       db.Open();
	   string vs_name = "";
	   string sql="select * from [DataSource] where [Link]=" + tree + " order by [ID]";
       System.Data.DataTable dt = db.Execute(sql);
	   if(dt.Rows.Count > 0){
	        for(int i = 0; i < dt.Rows.Count; i++){
			     output = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"";
			     output = output + " title=\""+dt.Rows[i]["Name"]+"\">";
				 output = output + "<tr>";
				 output = output + "<td id=\"t_"+dt.Rows[i]["id"]+"\" width=\"198\" height=\"25\">";
				 output = output + "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
				 output = output + "<tr>";
				 output = output + "<td width=\"155\">&nbsp;";
				 if(dt.Rows[i]["Components"].ToString()=="1"){
					 output = output + vs_name;
				 }else if(dt.Rows[i]["Components"].ToString()=="3"){
						 output = output + "<a href=\"List.aspx?node="+node+"\">"+vs_name+"</a>";
				 }
				 output = output + "</td>";
				 output = output + "<td><img src=\"images/triangle.gif\" width=\"3\" height=\"5\" alt=\"\" /></td>";
				 output = output + "</tr>";
				 output = output + "</table>";
				 output = output + "</td></tr>";
				 output = output + "<tr><td height=\"1\" colspan=\"2\" bgcolor=\"#CDCDCD\"></td></tr>";
				 output = output + "</table>";
				 showtree(int.Parse(dt.Rows[i]["id"].ToString()),node+20);
		    }
	    }
		db.Close();
	return output;
	}
	
	public static string banquan(int tree){
	   string output = "";
	   MyDB db = new MyDB();
       db.Open();
	   string sql="select * from [CompData] where [DataSource.ID]=" + tree;
       System.Data.DataTable dt = db.Execute(sql);
	   if(dt.Rows.Count > 0){
			     output = dt.Rows[0]["Text"].ToString();
	    }
		db.Close();
	return output;
	}
	
	public static string delhtml(string htmlstring)
    {
        //删除脚本
        htmlstring = htmlstring.Replace("\r\n", "");
        htmlstring = Regex.Replace(htmlstring, @"<script.*?</script>", "", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"<style.*?</style>", "", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"<.*?>", "", RegexOptions.IgnoreCase);
        //删除HTML
        htmlstring = Regex.Replace(htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"-->", "", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(nbsp|#160);", "", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, "\\(\\d{4}-\\d{2}-\\d{2}\\)", "", RegexOptions.IgnoreCase);
        htmlstring = htmlstring.Replace("<", "");
        htmlstring = htmlstring.Replace(">", "");
        htmlstring = htmlstring.Replace("\r\n", "");
        htmlstring = HttpContext.Current.Server.HtmlEncode(htmlstring).Trim();
        return htmlstring;
    }
}