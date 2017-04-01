using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///Dialog 的摘要说明
/// </summary>
public class Dialog
{
	public Dialog()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 输出内容
    /// </summary>
    /// <param name="input">字符串对象</param>
    /// <param name="max">街区长度</param>
    /// <returns>HTML</returns>
    static public string Output(object input, int max)
    {
        string html = (string)input;
        if (html.Length > max)
        {
            html = html.Substring(0, max - 2) + "...";
        }
        return html;
    }

    /// <summary>
    /// 文本输出框
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">可显示最大字符数</param>
    /// <param name="size">显示宽度（字符）</param>
    /// <param name="value">输出值</param>
    /// <returns>HTML</returns>
    static public string Output(string name, int maxlength, int size, string value)
    {
        string html = "<input class=\"readonly\" type=\"text\" name=\"" + name + "\" id=\""
            + name + "\" maxlength=\"" + maxlength + "\" readonly=\"readonly\" size=\"" + size
            + "\" value=\"" + HttpContext.Current.Server.HtmlEncode(value) + "\" />";
        return html;
    }

    /// <summary>
    /// 文本输出框
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">可显示最大字符数</param>
    /// <param name="size">显示宽度（百分比，小数）</param>
    /// <param name="value">输出数据</param>
    /// <returns>HTML</returns>
    static public string Output(string name, int maxlength, double size, string value)
    {
        string html = "<input class=\"readonly\" type=\"text\" name=\"" + name + "\" id=\""
            + name + "\" maxlength=\"" + maxlength + "\" readonly=\"readonly\" style=\"width:" + (size * 100) + "%\" value=\"" 
            + HttpContext.Current.Server.HtmlEncode(value) + "\" />";
        return html;
    }

    /// <summary>
    /// 文本输出框
    /// </summary>
    /// <param name="value">输出数据</param>
    /// <returns>HTML</returns>
    static public string Output(string value)
    {
        return "<input class=\"readonly\" type=\"text\" style=\"width:90%\" readonly=\"readonly\" value=\"" + HttpContext.Current.Server.HtmlEncode(value) + "\" />";
    }

    /// <summary>
    /// 文本输出框
    /// </summary>
    /// <param name="value">输出数据</param>
    /// <returns>HTML</returns>
    static public string Output(DateTime value)
    {
        return "<input class=\"readonly\" type=\"text\" style=\"width:90%\" readonly=\"readonly\" value=\"" + HttpContext.Current.Server.HtmlEncode(value.ToString("yyyy-MM-dd")) + "\" />";
    }

    /// <summary>
    /// 文本输出域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="rows">显示行</param>
    /// <param name="cols">显示列</param>
    /// <param name="value">输出数据</param>
    /// <returns>HTML</returns>
    static public string OutputArea(string name, int rows, int cols, string value)
    {
        string html = "<textarea class=\"readonly\" id=\"" + name + "\" name=\"" + name
           + "\" rows=\"" + rows + "\" cols=\"" + cols + "\" readonly=\"readonly\" >"
           + HttpContext.Current.Server.HtmlEncode(value) + "</textarea>";
        return html;
    }

    /// <summary>
    /// 文件链接
    /// </summary>
    /// <param name="name">表单名（无用）</param>
    /// <param name="value">输出数据</param>
    /// <returns>HTML</returns>
    static public string OutputFile(string name, string value) 
    {
        string html = "<ul>";
        if (value != "")
        {
            string[] files = value.Split(',');
            for (int i = 0; i < files.Length; i++) 
            {
                if (files[i].Length > 0)
                {
                    html += "<li><a href=\"#\">" + files[i].Substring(18) + "</a></li>";
                }
            }
        }
        html += "<ul>";
        return html;
    }

    /// <summary>
    /// 浮点输入域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">最大输入长度</param>
    /// <param name="size">显示长度</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Text(string name, int maxlength, int size, double value)
    {
        string html = "<input class=\"text\" type=\"text\" name=\"" + name + "\" id=\""
            + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
            + "\" value=\"" + value + "\" />";
        return html;
    }

    /// <summary>
    /// 高级浮点输入域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">最大输入长度</param>
    /// <param name="size">显示长度</param>
    /// <param name="value">默认值</param>
    /// <param name="pattern">验证正则式</param>
    /// <param name="title">提示文本</param>
    /// <param name="required">是否启用正则验证</param>
    /// <returns>HTML</returns>
    static public string Text(string name, int maxlength, int size, double value, string pattern, string title, bool required)
    {
        string html = "<input class=\"text\" type=\"number\" name=\"" + name + "\" id=\""
            + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
            + "\" value=\"" + value + "\" pattern=\"" + pattern + "\" title=\"" + title + "\" ";
        if (required)
        {
            html += "required=\"required\"";
        }
        html += " />";
        return html;
    }

    /// <summary>
    /// 整数输入域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">最大输入长度</param>
    /// <param name="size">显示长度</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Text(string name, int maxlength, int size, int value)
    {
        string html = "<input class=\"text\" type=\"number\" name=\"" + name + "\" id=\""
            + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
            + "\" value=\"" + value + "\" />";
        return html;
    }

    /// <summary>
    /// 高级整数输入域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">最大输入长度</param>
    /// <param name="size">显示长度</param>
    /// <param name="value">默认值</param>
    /// <param name="pattern">验证正则式</param>
    /// <param name="title">提示文本</param>
    /// <param name="required">是否启用正则验证</param>
    /// <returns>HTML</returns>
    static public string Text(string name, int maxlength, int size, int value, string pattern, string title, bool required)
    {
        string html = "<input class=\"text\" type=\"number\" name=\"" + name + "\" id=\""
            + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
            + "\" value=\"" + value + "\" pattern=\"" + pattern + "\" title=\"" + title + "\" ";
        if (required)
        {
            html += "required=\"required\"";
        }
        html += " />";
        return html;
    }

    /// <summary>
    /// 文本输入域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">最大输入长度</param>
    /// <param name="size">显示长度</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Text(string name, int maxlength, int size, string value)
    {
        string html = "<input class=\"text\" type=\"text\" name=\"" + name + "\" id=\""
            + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
            + "\" value=\"" + HttpContext.Current.Server.HtmlEncode(value) + "\" />";
        return html;
    }
    /// <summary>
    /// 文本输入域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">最大输入长度</param>
    /// <param name="size">显示长度</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Text_ReadOnly(string name, int maxlength, int size,string value)
    {
        string html = "<input class=\"text\" type=\"text\" name=\"" + name + "\" id=\""
            + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size+"\" readonly=\"true\""
            + " value=\"" + HttpContext.Current.Server.HtmlEncode(value) + "\" />";
        return html;
    }
    /// <summary>
    /// 带日历控件的文本输入域文本输入域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">最大输入长度</param>
    /// <param name="size">显示长度</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Text_date(string name, int size, string value)
    {
        string html = "<input class=\"text laydate-icon\" type=\"text\" name=\"" + name + "\" id=\""
            + name+ "\" size=\"" + size
            + "\" value=\"" + HttpContext.Current.Server.HtmlEncode(value) + "\" onclick=\"laydate()\"/>";
        return html;
    }

    /// <summary>
    /// 扩展文本输入域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">最大输入长度</param>
    /// <param name="size">显示长度</param>
    /// <param name="value">默认值</param>
    /// <param name="type">文本类型（text,email,number等）</param>
    /// <returns>HTML</returns>
    static public string Text(string name, int maxlength, int size, string value, string type)
    {
        if (type == "") { type = "text"; }
        string html = "<input class=\"text\" type=\"" + type + "\" name=\"" + name + "\" id=\""
            + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
            + "\" value=\"" + HttpContext.Current.Server.HtmlEncode(value) + "\" />";
        return html;
    }

    /// <summary>
    /// 高级文本输入域
    /// <param name="name">表单名</param>
    /// <param name="maxlength">最大输入长度</param>
    /// <param name="size">显示长度</param>
    /// <param name="value">默认值</param>
    /// <param name="type">文本类型（text,email,number等）</param>
    /// <param name="pattern">验证正则式</param>
    /// <param name="title">提示文本</param>
    /// <param name="required">是否启用正则验证</param>
    /// <returns>HTML</returns>
    static public string Text(string name, int maxlength, int size, string value, string type, string pattern, string title, bool required)
    {
        if (type == "") { type = "text"; }
        string html = "<input class=\"text\" type=\"" + type + "\" name=\"" + name + "\" id=\""
            + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
            + "\" value=\"" + HttpContext.Current.Server.HtmlEncode(value)
            + "\" pattern=\"" + pattern + "\" title=\"" + title + "\" ";
        if (required)
        {
            html += "required=\"required\"";
        }
        html += " />";
        return html;
    }

    /// <summary>
    /// 货币输入域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">最大输入长度</param>
    /// <param name="size">显示长度</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Text(string name, int maxlength, int size, decimal value)
    {
        string html = "<input class=\"text\" type=\"text\" name=\"" + name + "\" id=\""
            + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
            + "\" value=\"" + value.ToString("C2") + "\" />";
        return html;
    }

    /// <summary>
    /// 日期输入域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">最大输入长度（10=yyyy-MM-dd，7=yyyy-MM，其他=yyyy-MM-dd HH:mm:ss）</param>
    /// <param name="size">显示长度</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Text(string name, int maxlength, int size, DateTime value)
    {
        string html = "<input class=\"text\" type=\"text\" name=\"" + name + "\" id=\""
                + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
                + "\" value=\"";

        if (value != new DateTime())
        {
            if (maxlength == 10)
            {
                html += value.ToString("yyyy-MM-dd");
            }
            else if (maxlength == 7)
            {
                html += value.ToString("yyyy-MM");
            }
            else
            {
                html += value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        html += "\" />";

        return html;
    }

    /// <summary>
    /// 高级日期输入域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">最大输入长度（10=yyyy-MM-dd，7=yyyy-MM，其他=yyyy-MM-dd HH:mm:ss）</param>
    /// <param name="size">显示长度</param>
    /// <param name="value">默认值</param>
    /// <param name="pattern"></param>
    /// <param name="title"></param>
    /// <returns>HTML</returns>
    static public string Text(string name, int maxlength, int size, DateTime value, string pattern, string title)
    {
        string html = "<input class=\"text\" type=\"text\" name=\"" + name + "\" id=\""
                + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
                + "\" value=\"";

        if (value != new DateTime())
        {
            if (maxlength == 10)
            {
                html += value.ToString("yyyy-MM-dd");
            }
            else if (maxlength == 7)
            {
                html += value.ToString("yyyy-MM");
            }
            else
            {
                html += value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        html += "\" pattern=\"" + pattern + "\" title=\"" + title + "\" />";
        html += "\" />";

        return html;
    }
    /// <summary>
    /// 密码输入域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">最大输入长度</param>
    /// <param name="size">显示长度</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Password(string name, int maxlength, int size, string value)
    {
        string html = "<input class=\"text\" type=\"password\" name=\"" + name + "\" id=\""
            + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
            + "\" value=\"" + HttpContext.Current.Server.HtmlEncode(value) + "\" />";
        return html;
    }

    /// <summary>
    /// 高级密码输入域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="maxlength">最大输入长度</param>
    /// <param name="size">显示长度</param>
    /// <param name="value">默认值</param>
    /// <param name="pattern"></param>
    /// <param name="title"></param>
    /// <returns>HTML</returns>
    static public string Password(string name, int maxlength, int size, string value, string pattern, string title)
    {
        string html = "<input class=\"text\" type=\"password\" name=\"" + name + "\" id=\""
            + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
            + "\" value=\"" + HttpContext.Current.Server.HtmlEncode(value)
            + "\" pattern=\"" + pattern + "\" title=\"" + title + "\" />";
        return html;
    }

    /// <summary>
    /// 隐藏输入域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Hidden(string name, string value)
    {
        string html = "<input type=\"hidden\" name=\"" + name + "\" id=\""
            + name + "\" value=\"" + HttpContext.Current.Server.HtmlEncode(value) + "\" />";
        return html;
    }

    /// <summary>
    /// Checkbox模式是否选择域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string YesNo(string name, int value)
    {
        if (value == 1)
        {
            return "<input type=\"checkbox\" name=\"" + name + "\" id=\"" + name + "\" value=\"1\" checked=\"checked\" />";
        }
        else
        {
            return "<input type=\"checkbox\" name=\"" + name + "\" id=\"" + name + "\" value=\"1\" />";
        }
    }

    /// <summary>
    /// Checkbox模式是否选择域，带文本
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="text">显示文本</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string YesNo(string name, string text, int value)
    {
        if (value == 1)
        {
            return "<label><input type=\"checkbox\" name=\"" + name + "\" id=\"" + name + "\" value=\"1\" checked=\"checked\" />" + text + "</label>";
        }
        else 
        {
            return "<label><input type=\"checkbox\" name=\"" + name + "\" id=\"" + name + "\" value=\"1\" />" + text + "</label>";
        }
    }


    static public string addPrice(string name, int maxlength, int size, double value)
    {
        string html = "<input class=\"text\" type=\"text\" name=\"" + name + "\" id=\""
            + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
            + "\" value=\"" + value.ToString("C") + "\" />";
        return html;
    }

    /// <summary>
    /// HTML编辑器域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="rows">显示行数</param>
    /// <param name="cols">每行字数</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string TextArea(string name, int rows, int cols, string value)
    {
        string html = "<textarea class=\"textarea\" id=\"" + name + "\" name=\"" + name
            + "\" rows=\"" + rows + "\" cols=\"" + cols + "\" >"
            + HttpContext.Current.Server.HtmlEncode(value) + "</textarea>";
        return html;
    }
    static public string TextArea_Readonly(string name, int rows, int cols, string value)
    {
        string html = "<textarea class=\"textarea\" id=\"" + name + "\" name=\"" + name
            + "\" readonly=\"true\" rows=\"" + rows + "\" cols=\"" + cols + "\" >"
            + HttpContext.Current.Server.HtmlEncode(value) + "</textarea>";
        return html;
    }
    static public string SwfFile(string name, int maxlength, int size, string value)
    {
        string html = "<input type=\"hidden\" name=\"" + name + "\" id=\""
            + name + "\" value=\"" + HttpContext.Current.Server.HtmlEncode(value) + "\" />";
        html += "<span id=\"" + name + "_ButtonPlaceholder\"></span>\r\n";
        return html;
    }

    static public string File(string name, int size, string value)
    {
        string html = "<input class=\"text\" type=\"text\" name=\"" + name + "\" id=\"" + name + "\" value=\""
            + value + "\" size=\"" + size + "\" readonly=\"readonly\" />&nbsp;<input class=\"button upload\" type=\"button\" name=\""
            + name + "_bt\" id=\"" + name + "_bt\" value=\"加载文件\" />\r\n";
        return html;
    }

    static public string FileBox(string name, string value)
    {
        string html = "<input type=\"hidden\" name=\"" + name + "\" id=\"" + name + "\" value=\""
            + value + "\" /><div class=\"filebox\" id=\"" + name + "_box\"><ul>";

        if (value != "")
        {
            string[] files = value.Split(',');
            for (int i = 0; i < files.Length; i++)
            {
                html += "<li><a title=\"下载该附件\" onclick=\"downfile('"
                             + files[i] + "')\">" + files[i].Substring(files[i].LastIndexOf('-') + 1)
                             + "</a> <a title=\"删除该附件\" onclick=\"delfile('" +  files[i] + "', this)\">删除</a></li>";
            }
        }

        html += "</ul></div><input class=\"button filebox_button\" type=\"button\" name=\""
            + name + "_bt\" id=\"" + name + "_bt\" value=\"添加文件\" />\r\n";
        return html;
    }

    static public string listFileBox(string name, string value)
    {
        string html = "<input type=\"hidden\" name=\"" + name + "\" id=\"" + name + "\" value=\""
            + value + "\" /><div class=\"filebox\" id=\"" + name + "_box\"><ul>";

        if (value != "")
        {
            string[] files = value.Split(',');
            for (int i = 0; i < files.Length; i++)
            {
                html += "<li><a title=\"下载该附件\" onclick=\"downfile('"
                             + files[i] + "')\">" + files[i].Substring(files[i].LastIndexOf('-') + 1)
                             + "</a></li>";
            }
        }

        html += "</ul></div>\r\n";
        return html;
    }

    static public string List(string name, int size, string options, string value)
    {
        string html = "<select size=\"" + size + "\" class=\"select\" name=\"" + name + "\" id=\"" + name + "\">";
        if (options != "")
        {
            string[] option = options.Split('|');
            for (int i = 0; i < option.Length; i++)
            {
                if (option[i].IndexOf(',') > 0)
                {
                    html += "<option value=\"" + option[i].Split(',')[1] + "\">" + option[i].Split(',')[0] + "</option>";
                }
                else
                {
                    html += "<option>" + option[i] + "</option>";
                }
            }
        }
        html += "</select>";
        return html;
    }


    /// <summary>
    /// 下拉列表域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="option">选项</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Select(string name, string[] option, int value)
    {
        return Select(name, "——请选择——", option, value);
    }

    /// <summary>
    /// 下拉列表域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="option">选项</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Select(string name, string title, string[] option, int value)
    {
        string html = "<select class=\"select\" name=\"" + name + "\" id=\"" + name + "\">";
        if (value == 0)
        {
            html += "<option value=\"\">" + title + "</option>";
        }
        for (int i = 0; i < option.Length; i++)
        {
            html += "<option value=\"" + i + "\"";
            if (i == value)
            {
                html += " selected=\"selected\"";
            }
            html += ">" + option[i] + "</option>";
        }

        html += "</select>";

        return html;
    }

    /// <summary>
    /// 下拉列表域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="options">选项，格式为（名称1,值1|名称2,值2）</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Select(string name, string options, string value)
    {
        return Select(name, "——请选择——", options, value);
    }

    /// <summary>
    /// 下拉列表域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="title">标题名</param>
    /// <param name="options">选项，格式为（名称1,值1|名称2,值2）</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Select(string name, string title, string options, string value)
    {
        string[] option = options.TrimEnd('|').Split('|');

        string html = "<select class=\"select\" name=\"" + name + "\" id=\"" + name + "\">";
        if (value == "")
        {
            if (title != "")
            {
                html += "<option value=\"\">" + title + "</option>";
            }
            //html += "<option value=\"\"></option>";
        }
        if (options != "")
        {
            for (int i = 0; i < option.Length; i++)
            {
                if (option[i].IndexOf(",") > 0)
                {
                    html += "<option value=\"" + option[i].Split(',')[1] + "\"";
                    if (option[i].Split(',')[1] == value)
                    {
                        html += " selected=\"selected\"";
                    }
                    html += ">" + option[i].Split(',')[0] + "</option>";
                }
                else
                {
                    html += "<option value=\"" + option[i] + "\"";
                    if (option[i] == value)
                    {
                        html += " selected=\"selected\"";
                    }
                    html += ">" + option[i] + "</option>";
                }
            }
        }
        html += "</select>";

        return html;
    }

    /// <summary>
    /// 超级树形下拉列表域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="title">标题名（初始节点名）</param>
    /// <param name="table">表名</param>
    /// <param name="option_name">列表项目名称</param>
    /// <param name="parent">关联字段</param>
    /// <param name="value">传入值</param>
    /// <param name="id">初始节点值</param>
    /// <returns>HTML</returns>
    static public string Select(string name, string title, string table, string option_name, string parent, string value, int id)
    {
        string html = "<select class=\"select\" name=\"" + name + "\" id=\"" + name + "\">";
        if (title != "")
        {
            html += "<option value=\"\">" + title + "</option>";
        }
        else 
        {
            html += "<option value=\"\">——"
                + Data.Execute("select [" + option_name + "] from [" + table 
                + "] where [" + table.Substring(table.LastIndexOf('_')).Trim('_') + "_ID" 
                + "]=" + id).Rows[0][0] + "——</option>";
        }
        html += SubSelect(table, option_name, parent, "", id, value, "");
        html += "</select>";
        return html;
    }

    static public string Output(string name, int maxlength, int size, string table, string option_name, string id, string value)
    {
        if (value != "")
        {
            System.Data.DataTable dt = Data.Execute("select top 1 * from [" + table + "] where [" + id + "]=" + value);
            if (dt.Rows.Count > 0)
            {
                return Output(name, maxlength, size, dt.Rows[0][option_name].ToString());
            }
            else
            {
                return Output(name, maxlength, size, "");
            }
        }
        else 
        {
            return Output(name, maxlength, size, "");
        }
    }


    static private string SubSelect(string table, string name, string parent, string parentvalue, int id, string value, string deep)
    {
        string html = "";
        System.Data.DataTable dt = Data.Execute("select * from [" + table + "] where [" + parent + "]=" + id);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //string thisvalue = dt.Rows[i][name].ToString();
            string thisvalue = dt.Rows[i][table.Substring(table.LastIndexOf('_')).Trim('_') + "_ID"].ToString();
            //if (parentvalue != "")
            //{
            //    thisvalue = parentvalue + " " + thisvalue;
            //}
            html += "<option value=\"" + thisvalue + "\"";
            if (thisvalue == value)
            {
                html += " selected=\"selected\"";
            }
           
            if (i == dt.Rows.Count - 1)
            {
                html += ">" + deep.Replace("└", "&nbsp;&nbsp;").Replace("├", "│") + "└" + dt.Rows[i][name] + "</option>";
                html += SubSelect(table, name, parent, thisvalue, (int)dt.Rows[i][table.Substring(table.LastIndexOf('_')).Trim('_') + "_ID"], value, deep + "└");
            }
            else
            {
                html += ">" + deep.Replace("└", "&nbsp;&nbsp;").Replace("├", "│") + "├" + dt.Rows[i][name] + "</option>";
                html += SubSelect(table, name, parent, thisvalue, (int)dt.Rows[i][table.Substring(table.LastIndexOf('_')).Trim('_') + "_ID"], value, deep + "├");
            }
        }
        return html;
    }

    /// <summary>
    /// 超级树形下拉列表域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="title">标题名（初始节点名）</param>
    /// <param name="table">表名</param>
    /// <param name="option_name">列表项目名称</param>
    /// <param name="parent">关联字段</param>
    /// <param name="value">传入值</param>
    /// <param name="id">初始节点值</param>
    /// <returns>HTML</returns>
    static public string Select(string name, string title, string table, string option_name, string parent, int value, int id)
    {
        string html = "<select class=\"select\" name=\"" + name + "\" id=\"" + name + "\">";
        if (title != "")
        {
            html += "<option value=\"\">" + title + "</option>";
        }
        else
        {
            html += "<option value=\"\">——"
                + Data.Execute("select [" + option_name + "] from [" + table
                + "] where [" + table.Substring(table.LastIndexOf('_')).Trim('_') + "_ID"
                + "]=" + id).Rows[0][0] + "——</option>";
        }
        html += SubSelect(table, option_name, parent, id, value, "");
        html += "</select>";
        return html;
    }

    static private string SubSelect(string table, string name, string parent, int id, int value, string deep)
    {
        string html = "";
        System.Data.DataTable dt = Data.Execute("select * from [" + table + "] where [" + parent + "]=" + id);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int thisvalue = (int)dt.Rows[i][table.Substring(table.LastIndexOf('_')).Trim('_') + "_ID"];
            html += "<option value=\"" + thisvalue + "\"";
            if (thisvalue == value)
            {
                html += " selected=\"selected\"";
            }

            if (i == dt.Rows.Count - 1)
            {
                html += ">" + deep.Replace("└", "&nbsp;&nbsp;").Replace("├", "│") + "└" + dt.Rows[i][name] + "</option>";
                html += SubSelect(table, name, parent, (int)dt.Rows[i][table.Substring(table.LastIndexOf('_')).Trim('_') + "_ID"], value, deep + "└");
            }
            else
            {
                html += ">" + deep.Replace("└", "&nbsp;&nbsp;").Replace("├", "│") + "├" + dt.Rows[i][name] + "</option>";
                html += SubSelect(table, name, parent, (int)dt.Rows[i][table.Substring(table.LastIndexOf('_')).Trim('_') + "_ID"], value, deep + "├");
            }
        }
        return html;
    }


    /// <summary>
    /// 下拉列表域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="title">标题名</param>
    /// <param name="sql">查询</param>
    /// <param name="option_name">列表项目名称</param>
    /// <param name="option_value">列表项目值</param>
    /// <param name="value">传入值</param>
    /// <returns>HTML</returns>
    static public string Select(string name, string title, string sql, string option_name, string option_value, string value)
    {
        System.Data.DataTable dt = Data.Execute(sql);
        string html = "<select class=\"select\" name=\"" + name + "\" id=\"" + name + "\">";
        if (value == "")
        {
            html += "<option value=\"\">" + title + "</option>";
            //html += "<option value=\"\"></option>";
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {

            html += "<option value=\"" + dt.Rows[i][option_value] + "\"";
            if (dt.Rows[i][option_value].ToString() == value)
            {
                html += " selected=\"selected\"";
            }
            html += ">" + dt.Rows[i][option_name] + "</option>";

        }
        html += "</select>";

        return html;
    }

    /// <summary>
    /// 下拉列表域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="sql">查询</param>
    /// <param name="option_name">列表项目名称</param>
    /// <param name="option_value">列表项目值</param>
    /// <param name="value">传入值</param>
    /// <returns>HTML</returns>
    static public string Select(string name, string sql, string option_name, string option_value, string value)
    {
        return Select(name, "——请选择——", sql, option_name, option_value, value);
    }



    /// <summary>
    /// 下拉列表域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="title">标题名</param>
    /// <param name="sql">查询</param>
    /// <param name="option_name">列表项目名称</param>
    /// <param name="option_value">列表项目值</param>
    /// <param name="value">传入值</param>
    /// <returns>HTML</returns>
    static public string Select(string name, string title, string sql, string option_name, string option_value, int value)
    {
        System.Data.DataTable dt = Data.Execute(sql);
        string html = "<select class=\"select\" name=\"" + name + "\" id=\"" + name + "\">";
        if (value == 0)
        {
            html += "<option value=\"\">" + title + "</option>";
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {

            html += "<option value=\"" + dt.Rows[i][option_value] + "\"";
            if ((int)dt.Rows[i][option_value] == value)
            {
                html += " selected=\"selected\"";
            }
            html += ">" + dt.Rows[i][option_name] + "</option>";

        }
        html += "</select>";

        return html;
    }

    /// <summary>
    /// 下拉列表域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="sql">查询</param>
    /// <param name="option_name">列表项目名称</param>
    /// <param name="option_value">列表项目值</param>
    /// <param name="value">传入值</param>
    /// <returns>HTML</returns>
    static public string Select(string name, string sql, string option_name, string option_value, int value)
    {
        return Select(name, "——请选择——", sql, option_name, option_value, value);
    }

    /// <summary>
    /// 下拉列表跳转项
    /// </summary>
    /// <param name="name">列表标识</param>
    /// <param name="title">列表名称</param>
    /// <param name="sql">列表数据</param>
    /// <param name="option_name">列表字段名</param>
    /// <param name="option_value">列表字段值</param>
    /// <returns>HTML</returns>
    static public string SelectJump(string name, string title, string sql, string option_name, string option_value)
    {
        string val = Core.get(name);

        string html = "<select class=\"select\" name=\"" + name + "\" id=\"" + name + "\" onchange=\"jump('" + name + "', this.value)\">";
        html += "<option value=\"\">--" + title + "--</option>";
        System.Data.DataTable dt =Data.Execute(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            html += "<option value=\"" + dt.Rows[i][option_value] + "\"";
            if (dt.Rows[i][option_value].ToString() == val)
            {
                html += " selected=\"selected\"";
            }
            html += ">" + dt.Rows[i][option_name] + "</option>";
        }
        html += "</select>";
        return html;
    }

    /// <summary>
    /// 下拉列表跳转项
    /// </summary>
    /// <param name="name">列表标识</param>
    /// <param name="title">列表名称</param>
    /// <param name="options">列表数据字符串</param>
    /// <returns>HTML</returns>
    static public string SelectJump(string name, string title, string options)
    {
        string val = Core.get(name);

        string[] option = options.TrimEnd('|').Split('|');
        string html = "<select class=\"select\" name=\"" + name + "\" id=\"" + name + "\" onchange=\"jump('" + name + "', this.value)\">";
        if (title != "")
        {
            html += "<option value=\"\">--" + title + "--</option>";
        }
        for (int i = 0; i < option.Length; i++)
        {
            html += "<option value=\"" + option[i].Split(',')[1] + "\"";
            if (option[i].Split(',')[1] == val)
            {
                html += " selected=\"selected\"";
            }
            html += ">" + option[i].Split(',')[0] + "</option>";
        }
        html += "</select>";
        return html;
    }

    /// <summary>
    /// 下拉列表跳转项
    /// </summary>
    /// <param name="name">列表标识</param>
    /// <param name="title">列表名称</param>
    /// <param name="start">列表数据字符串</param>
    /// <param name="end">列表数据字符串</param>
    /// <returns>HTML</returns>
    static public string SelectJump(string name, string title, string unit, int start, int end)
    {
        int val = Core.getInt(name);

        string html = "<select class=\"select\" name=\"" + name + "\" id=\"" + name + "\" onchange=\"jump('" + name + "', this.value)\">";
        html += "<option value=\"\">--" + title + "--</option>";
        for (int i = start; i < end; i++)
        {
            html += "<option value=\"" + i + "\"";
            if (i == val)
            {
                html += " selected=\"selected\"";
            }
            html += ">" + i + unit + "</option>";
        }
        html += "</select>";
        return html;
    }

    /// <summary>
    /// 传统日期选择框
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="options">选择范围（例如，1900-2012）</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Select(string name, string options, DateTime value)
    {
        string[] option = options.Split('-');
        DateTime nul = new DateTime();

        string html = "<select class=\"select\" name=\"" + name + "_y\" id=\"" + name + "_y\">";
        if (value == nul)
        {
            html += "<option value=\"\">年</option>";
        }
        for (int i = int.Parse(option[0]); i <= int.Parse(option[1]); i++)
        {
                html += "<option value=\"" + i + "\"";
                if ((i == value.Year) && (value != nul))
                {
                    html += " selected=\"selected\"";
                }
                html += ">" + i + "</option>";
           
        }
        html += "</select>&nbsp;";

        html += "<select class=\"select\" name=\"" + name + "_m\" id=\"" + name + "_m\">";
        if (value == nul)
        {
            html += "<option value=\"\">月</option>";
        }
        for (int i = 1; i <= 12; i++)
        {
            html += "<option value=\"" + i + "\"";
            if ((i == value.Month) && (value != nul))
            {
                html += " selected=\"selected\"";
            }
            html += ">" + i + "</option>";

        }
        html += "</select>&nbsp;";

        html += "<select class=\"select\" name=\"" + name + "_d\" id=\"" + name + "_d\">";
        if (value == nul)
        {
            html += "<option value=\"\">日</option>";
        }
        for (int i = 1; i <= 31; i++)
        {
            html += "<option value=\"" + i + "\"";
            if ((i == value.Day) && (value != nul))
            {
                html += " selected=\"selected\"";
            }
            html += ">" + i + "</option>";

        }
        html += "</select>";

        return html;
    }


    static public string AjaxSelect(string name, int maxlength, int size, string value)
    {
        string html = "<input autocomplete=\"off\" class=\"listtext\" id=\"" + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
            + "\" name=\"" + name + "\" value=\"" + value + "\" /><br/><div class=\"ajaxlist\"></div>";
        return html;
    }

    static public string AjaxSelectReadonly(string name, int maxlength, int size, string value)
    {
        string html = "<input readonly=\"readonly\" class=\"listtext\" id=\"" + name + "\" maxlength=\"" + maxlength + "\" size=\"" + size
            + "\" name=\"" + name + "\" value=\"" + value + "\" /><br/><div class=\"ajaxlist\"></div>";
        return html;
    }


    /// <summary>
    /// 下拉列表域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="options">选项，格式为（名称1,值1|名称2,值2）</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Select(string name, string options, int value)
    {
        string[] option = options.TrimEnd('|').Split('|');

        string html = "<select class=\"select\" name=\"" + name + "\" id=\"" + name + "\">";
        if ((value == 0) && (option[0] != "0"))
        {
            html += "<option value=\"\">——请选择——</option>";
        }
        for (int i = 0; i < option.Length; i++)
        {
            if (option[i].IndexOf(",") > 0)
            {
                html += "<option value=\"" + option[i].Split(',')[1] + "\"";
                if (int.Parse(option[i].Split(',')[1]) == value)
                {
                    html += " selected=\"selected\"";
                }
                html += ">" + option[i].Split(',')[0] + "</option>";
            }
            else
            {
                html += "<option value=\"" + i + "\"";
                if (i == value)
                {
                    html += " selected=\"selected\"";
                }
                html += ">" + option[i] + "</option>";
            }
        }

        html += "</select>";

        return html;
    }

    static public string Select(string name, int min, int max, int value)
    {
        string html = "<select class=\"select\" name=\"" + name + "\" id=\"" + name + "\">";
        for (int i = min; i <= max; i++)
        {
            html += "<option value=\"" + i + "\"";
            if (i == value)
            {
                html += " selected=\"selected\"";
            }
            html += ">" + i + "</option>";
        }
        html += "</select>";
        return html;
    }
    /// <summary>
    /// 省市双极联动选择器
    /// </summary>
    /// <param name="name"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    static public string Select_place(string name, string value)
    {
        string html = "<select class=\"select\" name=\"" + name + "\" id=\"" + name + "\" selectedvalue=\"" + HttpContext.Current.Server.HtmlEncode(value) + "\">";
        html += "</select>";
        return html;
    }
    /// <summary>
    /// 复选选择域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="options">选项，格式为（名称1,值1|名称2,值2）</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Checkbox(string name, string options, string value)
    {
        string[] option = options.TrimEnd('|').Split('|');

        string html = "";
        for (int i = 0; i < option.Length; i++)
        {
            if (option[i].IndexOf(",") > 0)
            {
                html += "<label><input id=\"" + name + "_" + i + "\" type=\"checkbox\" value=\""
                    + option[i].Split(',')[1] + "\" name=\"" + name + "\"";
                if (("," + value + ",").IndexOf("," + option[i].Split(',')[1] + ",") >= 0)
                {
                    html += " checked=\"checked\"";
                }
                html += " />" + option[i].Split(',')[0] + "</label>";
            }
            else
            {
                html += "<label><input id=\"" + name + "_" + i + "\" type=\"checkbox\" value=\""
                   + option[i] + "\" name=\"" + name + "\"";
                if (("," + value + ",").IndexOf("," + option[i] + ",") >= 0)
                {
                    html += " checked=\"checked\"";
                }
                html += " />" + option[i] + "</label>";
            }
        }

        return html;
    }


     /// <summary>
    /// 单选选择域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="options">选项，格式为（名称1,值1|名称2,值2）</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Radio(string name, string options, int value)
    {
        return Radio(name, options, value.ToString());
    }

    /// <summary>
    /// 单选选择域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="options">选项，格式为（名称1,值1|名称2,值2）</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string Radio(string name, string options, string value)
    {
        string[] option = options.TrimEnd('|').Split('|');

        string html = "";
        for (int i = 0; i < option.Length; i++)
        {
            if (option[i].IndexOf(",") > 0)
            {
                html += "<label><input id=\"" + name + "_" + i + "\" type=\"radio\" value=\""
                    + option[i].Split(',')[1] + "\" name=\"" + name + "\"";
                if (("," + value + ",").IndexOf(option[i].Split(',')[1]) >= 0)
                {
                    html += " checked=\"checked\"";
                }
                html += " />" + option[i].Split(',')[0] + "</label>";
            }
            else
            {
                html += "<label><input id=\"" + name + "_" + i + "\" type=\"radio\" value=\""
                   + option[i] + "\" name=\"" + name + "\"";
                if (("," + value + ",").IndexOf(option[i]) >= 0)
                {
                    html += " checked=\"checked\"";
                }
                html += " />" + option[i] + "</label>";
            }
        }

        return html;
    }

    /// <summary>
    /// 超级单选选择域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="title">标题名（初始节点名）</param>
    /// <param name="table">表名</param>
    /// <param name="option_name">列表项目名称</param>
    /// <param name="parent">关联字段</param>
    /// <param name="value">传入值</param>
    /// <param name="id">初始节点值</param>
    /// <returns>HTML</returns>
    static public string Radio(string name, string title, string table, string option_name, string parent, int value, int id)
    {
        string html = title;
        html += SubRadio(table, option_name, parent, id, value);
        return html;
    }

    static private string SubRadio(string table, string name, string parent, int id, int value)
    {
        string html = "";
        System.Data.DataTable dt = Data.Execute("select * from [" + table + "] where [" + parent + "]=" + id);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int thisvalue = (int)dt.Rows[i][table.Substring(table.LastIndexOf('_')).Trim('_') + "_ID"];

            html += "<label><input id=\"" + name + "_" + i + "\" type=\"radio\" value=\""
                    + thisvalue + "\" name=\"" + name + "\"";
            if (("," + value + ",").IndexOf("," + thisvalue + ",") >= 0)
            {
                html += " checked=\"checked\"";
            }
            html += " />" + dt.Rows[i][name] + "</label>";

            html += SubRadio(table, name, parent, (int)dt.Rows[i][table.Substring(table.LastIndexOf('_')).Trim('_') + "_ID"], value);
        }
        return html;
    }


    /// <summary>
    /// 日期选择域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="value">默认值</param>
    /// <returns>HTML</returns>
    static public string DatePicker(string name, DateTime value)
    {
        string html = "<input class=\"datepicker\" type=\"text\" name=\"" + name + "\" id=\""
           + name + "\" maxlength=\"10\" size=\"10\" value=\"" + value.ToString("yyyy-MM-dd") + "\" />";
        return html;
    }

    /// <summary>
    /// 高级日期选择域
    /// </summary>
    /// <param name="name">表单名</param>
    /// <param name="value">默认值</param>
    /// <param name="type">自定义域类型</param>
    /// <returns></returns>
    static public string DatePicker(string name, DateTime value, string type)
    {
        string html = "<input class=\"datepicker\" type=\"" + type + "\" name=\"" + name + "\" id=\""
           + name + "\" maxlength=\"10\" size=\"10\" value=\"" + value.ToString("yyyy-MM-dd") + "\" />";
        return html;
    }

    static public string Date(string name, DateTime value)
    {
        return Date(name, 1900, DateTime.Now.Year + 10, value);
    }

    static public string Date(string name, int start, DateTime value)
    {
        return Date(name, start, DateTime.Now.Year, value);
    }

    static public string Date(string name, int start, int end, DateTime value)
    {
        string html = "<select class=\"select\" id=\"" + name + "_y\" name=\"" + name + "\">";
        for (int i = start; i <= end; i++)
        {
            html += "<option value=\"" + i + "\"";
            if (value.Year == i)
            {
                html += " selected=\"selected\"";
            }
            html += ">" + i + "年</option>";

        }
        html += "</select>\r\n";

        html += "<select class=\"select\" id=\"" + name + "_m\" name=\"" + name + "\">";
        for (int i = 1; i <= 12; i++)
        {

            html += "<option value=\"" + i + "\"";
            if (value.Month == i)
            {
                html += " selected=\"selected\"";
            }
            html += ">" + i + "月</option>";

        }
        html += "</select>\r\n";

        html += "<select class=\"select\" id=\"" + name + "_d\" name=\"" + name + "\">";
        for (int i = 1; i <= 31; i++)
        {

            html += "<option value=\"" + i + "\"";
            if (value.Day == i)
            {
                html += " selected=\"selected\"";
            }
            html += ">" + i + "日</option>";

        }
        html += "</select>\r\n";

        return html;
    }
}

