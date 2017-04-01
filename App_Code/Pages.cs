using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///Pages 的摘要说明
/// </summary>
public class Pages
{
	public Pages()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    static public int page()
    {
        try
        {
            int page = int.Parse(HttpContext.Current.Request["page"]);
            if (page < 1)
            {
                page = 1;
            };
            return page;
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

    static public int allPage(int num, int pageNum)
    {
        return (int)((num - 1) / pageNum) + 1;
    }

    static public string page(int num)
    {
        return page(num, 20);
    }

    static public string page(int num, int pageNum)
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

        int maxpage = allPage(num, pageNum);
        int nowpage = page();

        string str = "共<b>" + num + "</b>条记录,当前<b>" + nowpage + "</b>/" + maxpage + "页 ";
        if (nowpage < 10)
        {
            if (maxpage > 1)
            {
                if (nowpage > 1)
                {
                    str += "<a href=\"?page=1" + newpath + "\">首页</a> ";
                    str += "<a href=\"?page=" + (nowpage - 1) + newpath + "\">上一页</a> ";
                }
                else
                {
                    str += "首页 ";
                    str += "上一页 ";
                }
                if (maxpage < 11)
                {
                    for (int i = 1; i < maxpage + 1; i++)
                    {
                        if (nowpage == i)
                        {
                            str += "" + i + " ";
                        }
                        else
                        {
                            str += "<a href=\"?page=" + i + newpath + "\">" + i + "</a> ";
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < 11; i++)
                    {
                        if (nowpage == i)
                        {
                            str += "" + i + " ";
                        }
                        else
                        {
                            str += "<a href=\"?page=" + i + newpath + "\">" + i + "</a> ";
                        }
                    }
                }
                if (nowpage < maxpage)
                {
                    str += "<a href=\"?page=" + (nowpage + 1) + newpath + "\">下一页</a> ";
                    str += "<a href=\"?page=" + maxpage + newpath + "\">末页</a>";
                }
                else
                {
                    str += "下一页 ";
                    str += "末页";
                }
            }
        }
        else
        {
            if (maxpage - nowpage >= 9)
            {
                if (maxpage > 1)
                {
                    if (nowpage > 1)
                    {
                        str += "<a href=\"?page=1" + newpath + "\">首页</a> ";
                        str += "<a href=\"?page=" + (nowpage - 1) + newpath + "\">上一页</a> ";
                    }
                    else
                    {
                        str += "首页 ";
                        str += "上一页 ";
                    }

                    for (int i = nowpage - 4; i < nowpage + 5; i++)
                    {
                        if (nowpage == i)
                        {
                            str += "" + i + " ";
                        }
                        else
                        {
                            str += "<a href=\"?page=" + i + newpath + "\">" + i + "</a> ";
                        }
                    }

                    if (nowpage < maxpage)
                    {
                        str += "<a href=\"?page=" + (nowpage + 1) + newpath + "\">下一页</a> ";
                        str += "<a href=\"?page=" + maxpage + newpath + "\">末页</a>";
                    }
                    else
                    {
                        str += "下一页 ";
                        str += "末页";
                    }
                }
            }
            else
            {
                if (maxpage > 1)
                {
                    if (nowpage > 1)
                    {
                        str += "<a href=\"?page=1&" + newpath + "\">首页</a> ";
                        str += "<a href=\"?page=" + (nowpage - 1) + newpath + "\">上一页</a> ";
                    }
                    else
                    {
                        str += "首页 ";
                        str += "上一页 ";
                    }

                    for (int i = maxpage - 9; i < maxpage + 1; i++)
                    {
                        if (nowpage == i)
                        {
                            str += "" + i + " ";
                        }
                        else
                        {
                            str += "<a href=\"?page=" + i + newpath + "\">" + i + "</a> ";
                        }
                    }

                    if (nowpage < maxpage)
                    {
                        str += "<a href=\"?page=" + (nowpage + 1) + newpath + "\">下一页</a> ";
                        str += "<a href=\"?page=" + maxpage + newpath + "\">末页</a>";
                    }
                    else
                    {
                        str += "下一页 ";
                        str += "末页";
                    }
                }
            }
        }
        str += " 跳转到第<input name=\"pagenum\" class=\"input1\" type=\"text\" value=\"1\" />页 <input type=\"button\" value=\"提交\" onclick=\"sendpage()\" /><input id=\"act\" name=\"act\" type=\"hidden\" value=\"\">";

        return str;
    }

    static public int startIndex()
    {
        return startIndex(20);
    }

    static public int startIndex(int pageNum)
    {
        int nowpage = page();
        return (nowpage - 1) * pageNum;
    }

    static public int endIndex(int allCount)
    {
        return endIndex(allCount, 20);
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
}
