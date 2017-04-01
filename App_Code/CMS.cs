using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Web.Caching;
using System.Web.UI.MobileControls;


/// <summary>
///CMS 的摘要说明
/// </summary>
public class CMS
{
	public CMS()
	{
		//
		//TODO: 该类库提供各种网页数据调用方法
		//
	}

    /*===================页面引用函数==========================================*/
    #region   引用页面函数
    //（引用多个页面，含有from表单不能拆分在多个页面）
    /// <summary>
    /// 引用页面
    /// </summary>
    /// <param name="path">页面相对路径</param>
    static public string Inc(string path)
    {
        if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(path)))
        {
            HttpContext.Current.Server.Execute(path);
        }
        return "";
    }

    #endregion
    /*===================处理node层函数========================================*/
     #region  处理node层函数


    /// <summary>
    /// 通过父级栏目节点返回子级相关的标记
    /// 可使用标记：[序号][节点][栏目][参数][预留]
    /// </summary>
    /// <param name="template"></param>
    /// <returns></returns>
    static public string Node(string template)
    {
        return Node(RNA.getNode(), template);
    }
    /// <summary>
    /// 通过父级栏目节点返回子级相关的标记
    /// 可使用标记：[序号][节点][栏目][参数][预留]
    /// </summary>
    /// <param name="node">节点ID</param>
    /// <param name="template">HTML模板</param>
    /// <returns></returns>
    static public string Node(int node, string template)
    {
        string output = "";
        DataTable dt = Data.Execute("SELECT  *  FROM  [W_DataSource]  WHERE  [Link]= " + node + " order by [Index] Desc, ID");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Active"].ToString()=="1")
            {
                string temp = template;
                temp = Replace(temp, "[序号]", dt.Rows[i]["index"].ToString());      //排列序号
                temp = Replace(temp, "[节点]", dt.Rows[i]["ID"].ToString());         //该栏目ID
                temp = Replace(temp, "[栏目]", dt.Rows[i]["Name"].ToString());       //栏目名称
                temp = Replace(temp, "[参数]", dt.Rows[i]["Param"].ToString());      //对应配置文本
                temp = Replace(temp, "[预留]", dt.Rows[i]["Preview"].ToString());    //预留文本
                output += temp;
            }
        }
        return output;
    }

    /// <summary>
    /// 通过栏目节点返回相关的标记
    ///  可使用标记：[序号][节点][栏目][参数][预留]
    /// </summary>
    /// <param name="template"></param>
    /// <returns></returns>
    static public string NodeOutput(string template)
    {
        return NodeOutput(RNA.getNode(), template);
    }
    /// <summary>
    /// 通过栏目节点返回相关的标记
    /// 可使用标记：[序号][节点][栏目][参数][预留]
    /// </summary>
    /// <param name="node">节点ID</param>
    /// <param name="template">HTML模板</param>
    /// <returns></returns>
    static public string NodeOutput(int node, string template)
    {
        string output = "";
        DataTable dt = Data.Execute("SELECT top 1 *  FROM  [W_DataSource]  WHERE  [id]= " + node);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["Active"].ToString() == "1")
            {
                string temp = template;
                temp = Replace(temp, "[序号]", dt.Rows[0]["index"].ToString());      //排列序号
                temp = Replace(temp, "[节点]", dt.Rows[0]["ID"].ToString());         //该栏目ID
                temp = Replace(temp, "[栏目]", dt.Rows[0]["Name"].ToString());       //栏目名称
                temp = Replace(temp, "[参数]", dt.Rows[0]["Param"].ToString());      //对应配置文本
                temp = Replace(temp, "[预留]", dt.Rows[0]["Preview"].ToString());    //预留文本
                output = temp;
            }
            return output;
        }
        return "";
    }

 
    /// <summary>
    /// 当配置文本中字段以逗号相隔时，将文本分割成多条，依次取出分割值
    /// 可使用标记[值] 注意：逗号必须为英文符逗号相隔
    /// </summary>
    /// <param name="node"></param>
    /// <param name="template"></param>
    /// <returns></returns>
    static public string NodeParam(int node, string template)
    {
        string output = "";
        string param ="";
        DataTable dt = Data.Execute("SELECT top 1 * FROM [W_DataSource] WHERE [ID]=" + node);
        if (dt.Rows.Count > 0)
        {
           param= dt.Rows[0]["Param"].ToString();
        }
        if (param != "")
        {
            string[] params1 = param.Split(',');
            for (int i = 0; i < params1.Length; i++)
            {
                output += template.Replace("[值]", params1[i]);
            }
        }
        return output;
    }

    static public string NodeParam(string template)
    {
        return NodeParam(Core.getNode(), template);
    }



    /// <summary>
    /// 根据子nodeID返回根层ID
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    static public int rootNode(int node)
    {
        DataTable dt = Data.Execute("SELECT top 1 * FROM [W_DataSource] WHERE [ID]=" + node);
        if (dt.Rows.Count > 0)
        {
            if ((int)dt.Rows[0]["Link"] == 0)
            {
                return node;
            }
            else
            {
                return rootNode((int)dt.Rows[0]["Link"]);
            }
        }
        return 0;
    }
    /// <summary>
    /// 根据子nodeID返回父层ID
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    static public int ParentNode(int node)
    {
        DataTable dt = Data.Execute("SELECT top 1 * FROM [W_DataSource] WHERE [ID]=" + node);
        if (dt.Rows.Count > 0)
        {
            if ((int)dt.Rows[0]["Link"] == 0)
            {
                return node;
            }
            else
            {
                return (int)dt.Rows[0]["Link"];
            }
        }
        return 0;
    }
    
    /// <summary>
    /// 通过页面传入的节点返回栏目名称
    /// </summary>
    /// <returns></returns>
    static public string Node()
    {
        return Node(RNA.getNode());
    }

    /// <summary>
    /// 返回通过栏目节点ID返回栏目名称
    /// </summary>
    /// <param name="node">节点ID</param>
    /// <returns></returns>
    static public string Node(int node)
    {
        DataTable dt = Data.Execute("SELECT * FROM [W_DataSource] WHERE [ID]=" + node);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0]["Name"].ToString();
        }
        return "";
    }
    /// <summary>
    /// 返回通过列表ID返回node
    /// </summary>
    /// <param name="node">节点ID</param>
    /// <returns></returns>
    static public string GetNode(int id)
    {
        DataTable dt = Data.Execute("SELECT * FROM [View_Complist] WHERE [ID]=" + id);
        return dt.Rows[0]["Node"].ToString();
     
    }

    /// <summary>
    /// 根据栏目名称返回栏目ID
    /// </summary>
    /// <param name="title">栏目名称</param>
    /// <returns></returns>
    static public int NodeName(string Name)
    {
        DataTable dt = Data.Execute("SELECT top 1 * FROM [W_DataSource] WHERE [Name]='" + Name + "'");
        if (dt.Rows.Count > 0)
        {
            return int.Parse(dt.Rows[0]["id"].ToString());
        }
        return 0;
    }

    #endregion
    /*===================处理complist层函数====================================*/
    #region 处理complist层函数

    /// <summary>
    /// 根据ID输出项目各项信息
    /// </summary>
    /// <param name="id">输出项目ID</param>
    /// <param name="template_main">单次输出HTML模板</param>
    /// <param name="template_pic">遍历输出展示图HTML模板</param>
    /// <param name="template_date">遍历输出日期HTML模板</param>
    /// <param name="template_route">遍历输出线路HTML模板</param>
    /// <param name="format">格式限定</param>
    /// <returns>html模板结果</returns>
    static public string OutputFrist(string node,string template_main,int Num,  string format)
    {
        Hashtable formats = new Hashtable();
        if (format != "")
        {
            string[] format1 = format.Split(',');
            for (int i = 0; i < format1.Length; i++)
            {
                formats.Add(format1[i].Split('=')[0], format1[i].Split('=')[1]);
            }
        }
        string output = "";
        int page = RNA.getPage();
        DataTable dt_base = Data.Execute("SELECT top " + Num + " * FROM [V_W_ImageAndText] where node=" + node + " order by ID desc");
            if (dt_base.Rows.Count > 0)
            {
                //基本信息取值
                if (dt_base.Rows[0]["Active"].ToString() == "1")
                {
                    string temp = template_main;
                    temp = Replace(temp, "[链接-序号]", dt_base.Rows[0]["ID"].ToString());
                    temp = Replace(temp, "[链接-节点]", dt_base.Rows[0]["Node"].ToString());
                    temp = Replace(temp, "[链接-图片]", dt_base.Rows[0]["ItemUrl"].ToString());
                    temp = Replace(temp, "[链接-标题]", Format(dt_base.Rows[0]["ItemTitle"], "[链接-标题]", formats));
                    temp = Replace(temp, "[链接-描述]", Format(dt_base.Rows[0]["ItemDiscrab"], "[链接-描述]", formats));
                    temp = Replace(temp, "[链接-链接]", Format(dt_base.Rows[0]["Link"], "[链接-链接]", formats));
                    temp = Replace(temp, "[链接-索引]", dt_base.Rows[0]["index"].ToString());
                    temp = Replace(temp, "[链接-关键字]", Format(dt_base.Rows[0]["KeyWords"], "[链接-关键字]", formats));
                    temp = Replace(temp, "[链接-添加人]", dt_base.Rows[0]["AddName"].ToString());
                    temp = Replace(temp, "[链接-添加时间]", Format(dt_base.Rows[0]["AddDate"], "[链接-添加时间]", formats));
                    temp = Replace(temp, "[链接-修改人]", dt_base.Rows[0]["UppdataName"].ToString());
                    temp = Replace(temp, "[链接-修改时间]", Format(dt_base.Rows[0]["UppdataDate"], "[链接-修改时间]", formats));
                    output = temp;
                }
            }
            return output;
       

    }

    static public string Output(int id, string template_main, string format)
    {
        return Output(id, true, template_main,  "", "", format);
    }
    /// <summary>
    /// 根据ID输出项目各项信息
    /// </summary>
    /// <param name="template_main">单次输出HTML模板</param>
    /// <param name="format">格式限定</param>
    /// <returns>html模板结果</returns>
    static public string Output(string template_main, string format)
    {
        return Output(Core.getNode(), true, template_main, "", "", format);
    }
    static public string Output( bool islink, string template_main, string template_pic, string template_route, string format)
    {
        return Output(Core.getNode(), islink, template_main, template_pic, template_route, format);
    }
/// <summary>
/// 根据ID输出项目各项信息
/// </summary>
/// <param name="id">输出项目ID</param>
/// <param name="template_main">单次输出HTML模板</param>
/// <param name="template_pic">遍历输出展示图HTML模板</param>
/// <param name="template_date">遍历输出日期HTML模板</param>
/// <param name="template_route">遍历输出线路HTML模板</param>
/// <param name="format">格式限定</param>
/// <returns>html模板结果</returns>
    static public string Output(int id,bool islink, string template_main, string template_pic, string template_route, string format)
    {
        Hashtable formats = new Hashtable();
        if (format != "")
        {
            string[] format1 = format.Split(',');
            for (int i = 0; i < format1.Length; i++)
            {
                formats.Add(format1[i].Split('=')[0], format1[i].Split('=')[1]);
            }
        }
        string output = "";
        int page = RNA.getPage();
        if (!islink)
        {
            DataTable dt_base = Data.Execute("SELECT top 1 * FROM [V_W_SuperModel] WHERE [ID]=" + id);
            DataTable dt_route = Data.Execute("SELECT  * FROM [W_SuperAttch] WHERE [PID]=" + id);
            DataTable dt_pic = Data.Execute("SELECT  *  FROM [W_ImageAndtext] WHERE [PID]=" + id + "order by IsMain desc");

            string temp = template_main;
            string str_pic = string.Empty;
            string str_route = string.Empty;
            if (dt_pic.Rows.Count > 0 && template_pic != "")
            { //图集
                for (int i = 0; i < dt_pic.Rows.Count; i++)
                {
                    string temp_pic = template_pic;
                    temp_pic = Replace(temp_pic, "[图集-序号]", dt_pic.Rows[i]["ID"].ToString());
                    temp_pic = Replace(temp_pic, "[图集-标题]", Format(dt_pic.Rows[i]["ItemTitle"], "[图集-标题]", formats));
                    temp_pic = Replace(temp_pic, "[图集-描述]", Format(dt_pic.Rows[i]["ItemDiscrab"], "[图集-描述]", formats));
                    temp_pic = Replace(temp_pic, "[图集-路径]", dt_pic.Rows[i]["ItemUrl"].ToString());
                    str_pic += temp_pic;
                }
            }
           

            if (dt_route.Rows.Count > 0 && template_route != "")
            { //文本集

                for (int i = 0; i < dt_route.Rows.Count; i++)
                {
                    string temp_route = template_route;
                    temp_route = Replace(temp_route, "[文本-序号]", dt_route.Rows[i]["ID"].ToString());
                    temp_route = Replace(temp_route, "[文本-标题]", Format(dt_route.Rows[i]["Title"], "[文本-标题]", formats));
                    temp_route = Replace(temp_route, "[文本-简介]", Format(dt_route.Rows[i]["NutShell"], "[文本-简介]", formats));
                    temp_route = Replace(temp_route, "[文本-内容]", Format(dt_route.Rows[i]["Content"], "[文本-内容]", formats));
                    temp_route = Replace(temp_route, "[文本-备注]", Format(dt_route.Rows[i]["Remark"], "[文本-备注]", formats));
                    str_route += temp_route;
                }

            }
            if (dt_base.Rows.Count > 0)
            {
                //基本信息取值
                template_main = "";
                DataTable dt_picM = Data.Execute("SELECT  top 1 * FROM [W_ImageAndtext] WHERE [PID]=" + id + " and  [IsMain]=1");
                if (dt_picM.Rows.Count != 0)
                {
                    temp = Replace(temp, "[主图-标题]", Format(dt_picM.Rows[0]["ItemTitle"], "[主图-标题]", formats));
                    temp = Replace(temp, "[主图-路径]", dt_picM.Rows[0]["ItemUrl"].ToString());
                    temp = Replace(temp, "[主图-描述]", Format(dt_picM.Rows[0]["ItemDiscrab"], "[主图-描述]", formats));
                }
                temp = Replace(temp, "[序号]", dt_base.Rows[0]["ID"].ToString());
                temp = Replace(temp, "[短文本一]", Format(dt_base.Rows[0]["S_str1"], "[短文本一]", formats));
                temp = Replace(temp, "[短文本二]", Format(dt_base.Rows[0]["S_str2"], "[短文本二]", formats));
                temp = Replace(temp, "[短文本三]", Format(dt_base.Rows[0]["S_str3"], "[短文本三]", formats));
                temp = Replace(temp, "[短文本四]", Format(dt_base.Rows[0]["S_str4"], "[短文本四]", formats));
                temp = Replace(temp, "[短文本五]", Format(dt_base.Rows[0]["S_str5"], "[短文本五]", formats));
                temp = Replace(temp, "[短文本六]", Format(dt_base.Rows[0]["S_str6"], "[短文本六]", formats));
                temp = Replace(temp, "[中文本一]", Format(dt_base.Rows[0]["M_str1"], "[中文本一]", formats));
                temp = Replace(temp, "[中文本二]", Format(dt_base.Rows[0]["M_str2"], "[中文本二]", formats));
                temp = Replace(temp, "[中文本三]", Format(dt_base.Rows[0]["M_str3"], "[中文本三]", formats));
                temp = Replace(temp, "[长文本一]", Format(dt_base.Rows[0]["L_str1"], "[长文本一]", formats));
                temp = Replace(temp, "[长文本二]", Format(dt_base.Rows[0]["L_str2"], "[长文本二]", formats));
                temp = Replace(temp, "[长文本三]", Format(dt_base.Rows[0]["L_str3"], "[长文本三]", formats));
                temp = Replace(temp, "[长文本四]", Format(dt_base.Rows[0]["L_str4"], "[长文本四]", formats));
                temp = Replace(temp, "[浮点数一]", dt_base.Rows[0]["Float1"].ToString());
                temp = Replace(temp, "[浮点数二]", dt_base.Rows[0]["Float2"].ToString());
                temp = Replace(temp, "[整型一]", dt_base.Rows[0]["Int1"].ToString());
                temp = Replace(temp, "[整型二]", dt_base.Rows[0]["Int2"].ToString());
                temp = Replace(temp, "[日期一]", Format(dt_base.Rows[0]["Datetime1"], "[日期一]", formats));
                temp = Replace(temp, "[日期二]", Format(dt_base.Rows[0]["Datetime2"], "[日期二]", formats));
                temp = Replace(temp, "[主线-索引]", dt_base.Rows[0]["index"].ToString());
                temp = Replace(temp, "[主线-关键字]", Format(dt_base.Rows[0]["KeyWords"], "[主线-关键字]", formats));
                temp = Replace(temp, "[主线-节点]", dt_base.Rows[0]["Node"].ToString());
                temp = Replace(temp, "[主线-链接]", Format(dt_base.Rows[0]["Link"], "[主线-链接]", formats));
                temp = Replace(temp, "[主线-添加人]", dt_base.Rows[0]["AddName"].ToString());
                temp = Replace(temp, "[主线-添加时间]", Format(dt_base.Rows[0]["AddDate"], "[主线-添加时间]", formats));
                temp = Replace(temp, "[主线-修改人]", dt_base.Rows[0]["UppdataName"].ToString());
                temp = Replace(temp, "[主线-修改时间]", Format(dt_base.Rows[0]["UppdataDate"], "[主线-修改时间]", formats));
                template_main += temp;

            }
            return output = string.Format(template_main, str_pic,str_route);
        }
        else //当包含有link的情况
        {
            DataTable dt_base = Data.Execute("SELECT top 1 * FROM [V_W_ImageAndText] WHERE [ID]=" + id);
            if (dt_base.Rows.Count > 0)
            {
                //基本信息取值
                if (dt_base.Rows[0]["Active"].ToString() == "1")
                {
                    string temp = template_main;
                    temp = Replace(temp, "[链接-序号]", dt_base.Rows[0]["ID"].ToString());
                    temp = Replace(temp, "[链接-节点]", dt_base.Rows[0]["Node"].ToString());
                    temp = Replace(temp, "[链接-图片]", dt_base.Rows[0]["ItemUrl"].ToString());
                    temp = Replace(temp, "[链接-标题]", Format(dt_base.Rows[0]["ItemTitle"], "[链接-标题]", formats));
                    temp = Replace(temp, "[链接-描述]", Format(dt_base.Rows[0]["ItemDiscrab"], "[链接-描述]", formats));
                    temp = Replace(temp, "[链接-链接]", Format(dt_base.Rows[0]["Link"], "[链接-链接]", formats));
                    temp = Replace(temp, "[链接-索引]", dt_base.Rows[0]["index"].ToString());
                    temp = Replace(temp, "[链接-关键字]", Format(dt_base.Rows[0]["KeyWords"], "[链接-关键字]", formats));
                    temp = Replace(temp, "[链接-添加人]", dt_base.Rows[0]["AddName"].ToString());
                    temp = Replace(temp, "[链接-添加时间]", Format(dt_base.Rows[0]["AddDate"], "[链接-添加时间]", formats));
                    temp = Replace(temp, "[链接-修改人]", dt_base.Rows[0]["UppdataName"].ToString());
                    temp = Replace(temp, "[链接-修改时间]", Format(dt_base.Rows[0]["UppdataDate"], "[链接-修改时间]", formats));
                    output = temp;
                }
            }
            return output;  
        }
     
    }
    
 
    static public string List(string template_main, string format, int pageset)
    {
        return List(Core.get("node"), template_main, format, pageset,"");
    }

    static public string List(string nodes, string template_main, string format, int pageset,string key)
    {
        return List(nodes, true, template_main, "", "", format, pageset, key);
    }
    static public string List(string nodes, string template_main,string template_pic, string template_route,int pageset,string key)
    {
        return List(nodes, true, template_main, "", "", "", pageset, key);
    }
    /// <summary>
    /// 返回一个节点上的所有信息
    /// </summary>
    /// <param name="nodes">节点</param>
    /// <param name="islink">是否为链接</param>
    /// <param name="template_main">主线内容</param>
    /// <param name="template_pic">图片内容</param>
    /// <param name="template_route">文本内容</param>
    /// <param name="format">格式</param>
    /// <param name="pageset">翻页设置</param>
    /// <param name="key"></param>
    /// <returns></returns>
    /// 当node为0时可以筛选出所以项目信息或链接信息中的项目   依靠关键字  当pageset为11时，默认为没有翻页情况
    static public string List(string nodes,bool islink, string template_main, string template_pic, string template_route, string format, int pageset, string key)
    {
        string output = "";
        DataTable dt=new DataTable();
        if (key != ""&&nodes=="0")
        { dt = Data.Execute("SELECT top 1 * FROM [V_SubMenu] where Type=3"); }
        else
        { dt = Data.Execute("SELECT top 1 * FROM [V_SubMenu] WHERE [ID] in (" + nodes + ")"); }
        if (dt.Rows.Count > 0)
        {
            Hashtable formats = new Hashtable();
            if (format != "")
            {
                string[] format1 = format.Split(',');
                for (int i = 0; i < format1.Length; i++)
                {
                    formats.Add(format1[i].Split('=')[0], format1[i].Split('=')[1]);
                }
            }
            if ((int)dt.Rows[0]["Type"] ==3)//链接栏目或项目栏目
            {
                int page = 1;
                if (pageset != 11)//当pageset为11时，默认为没有翻页情况
                {
                    page = Core.page();
                }
                else
                { page = 1; }

                string schkey = "";
                if (key != "")
                {
                    string[] keys = key.Split(',');
                    for (int i = 0; i < keys.Length; i++)
                    {
                        schkey += " and [KeyWords] like '%" + keys[i].Trim() + "%' ";
                    }
                }
                if (!islink)//详细列表
                {
                    DataTable dt_base = new DataTable();
                    if (key != "" && nodes == "0") { dt_base = Data.Execute("SELECT top " + (page * pageset) + " * FROM [V_W_SuperModel] WHERE [Active]=1 " + schkey + " ORDER BY [INDEX] DESC,[ID] DESC"); }
                    else { dt_base = Data.Execute("SELECT top " + (page * pageset) + " * FROM [V_W_SuperModel] WHERE [Active]=1 and [Node] in (" + nodes + ") " + schkey + " ORDER BY [INDEX] DESC,[ID] DESC"); }
                    for (int i = (page - 1) * pageset; i < dt_base.Rows.Count; i++)
                    {
                        string projid = dt_base.Rows[i]["ID"].ToString();
                        DataTable dt_route = Data.Execute("SELECT  * FROM [W_SuperAttch] WHERE [PID]=" + projid);
                        DataTable dt_pic = Data.Execute("SELECT  *  FROM [W_ImageAndtext] WHERE [PID]=" + projid + "order by IsMain desc");
                        string temp = template_main;
                        string str_pic = string.Empty;
                        string str_route = string.Empty;
                        string str_main = string.Empty;
                        if (dt_pic.Rows.Count > 0 && template_pic != "")
                        { //图集
                            for (int j = 0; j < dt_pic.Rows.Count; j++)
                            {
                                string temp_pic = template_pic;
                                temp_pic = Replace(temp_pic, "[图集-序号]", dt_pic.Rows[j]["ID"].ToString());
                                temp_pic = Replace(temp_pic, "[图集-标题]", Format(dt_pic.Rows[j]["ItemTitle"], "[图集-标题]", formats));
                                temp_pic = Replace(temp_pic, "[图集-描述]", Format(dt_pic.Rows[j]["ItemDiscrab"], "[图集-描述]", formats));
                                temp_pic = Replace(temp_pic, "[图集-路径]", dt_pic.Rows[j]["ItemUrl"].ToString());
                                str_pic += temp_pic;
                            }
                        }
                       
                        if (dt_route.Rows.Count > 0 && template_route != "")
                        { //文本集

                            for (int j = 0; j < dt_route.Rows.Count; j++)
                            {
                                string temp_route = template_route;
                                temp_route = Replace(temp_route, "[文本-序号]", dt_route.Rows[j]["ID"].ToString());
                                temp_route = Replace(temp_route, "[文本-标题]", Format(dt_route.Rows[j]["Title"], "[文本-标题]", formats));
                                temp_route = Replace(temp_route, "[文本-简介]", Format(dt_route.Rows[j]["NutShell"], "[文本-简介]", formats));
                                temp_route = Replace(temp_route, "[文本-内容]", Format(dt_route.Rows[j]["Content"], "[文本-内容]", formats));
                                temp_route = Replace(temp_route, "[文本-备注]", Format(dt_route.Rows[j]["Remark"], "[文本-备注]", formats));
                                str_route += temp_route;
                            }
                        }
                        //基本信息取值
                        DataTable dt_picM = Data.Execute("SELECT  top 1 * FROM [W_ImageAndtext] WHERE [PID]=" + projid + "and [IsMain]=" + 1);
                        if (dt_picM.Rows.Count != 0)
                        {
                            temp = Replace(temp, "[主图-标题]", Format(dt_picM.Rows[0]["ItemTitle"], "[主图-标题]", formats));
                            temp = Replace(temp, "[主图-路径]", dt_picM.Rows[0]["ItemUrl"].ToString());
                            temp = Replace(temp, "[主图-描述]", Format(dt_picM.Rows[0]["ItemDiscrab"], "[主图-描述]", formats));
                        }
                        temp = Replace(temp, "[序号]", dt_base.Rows[i]["ID"].ToString());
                        temp = Replace(temp, "[短文本一]", Format(dt_base.Rows[i]["S_str1"], "[短文本一]", formats));
                        temp = Replace(temp, "[短文本二]", Format(dt_base.Rows[i]["S_str2"], "[短文本二]", formats));
                        temp = Replace(temp, "[短文本三]", Format(dt_base.Rows[i]["S_str3"], "[短文本三]", formats));
                        temp = Replace(temp, "[短文本四]", Format(dt_base.Rows[i]["S_str4"], "[短文本四]", formats));
                        temp = Replace(temp, "[短文本五]", Format(dt_base.Rows[i]["S_str5"], "[短文本五]", formats));
                        temp = Replace(temp, "[短文本六]", Format(dt_base.Rows[i]["S_str6"], "[短文本六]", formats));
                        temp = Replace(temp, "[中文本一]", Format(dt_base.Rows[i]["M_str1"], "[中文本一]", formats));
                        temp = Replace(temp, "[中文本二]", Format(dt_base.Rows[i]["M_str2"], "[中文本二]", formats));
                        temp = Replace(temp, "[中文本三]", Format(dt_base.Rows[i]["M_str3"], "[中文本三]", formats));
                        temp = Replace(temp, "[长文本一]", Format(dt_base.Rows[i]["L_str1"], "[长文本一]", formats));
                        temp = Replace(temp, "[长文本二]", Format(dt_base.Rows[i]["L_str2"], "[长文本二]", formats));
                        temp = Replace(temp, "[长文本三]", Format(dt_base.Rows[i]["L_str3"], "[长文本三]", formats));
                        temp = Replace(temp, "[长文本四]", Format(dt_base.Rows[i]["L_str4"], "[长文本四]", formats));
                        temp = Replace(temp, "[浮点数一]", dt_base.Rows[i]["Float1"].ToString());
                        temp = Replace(temp, "[浮点数二]", dt_base.Rows[i]["Float2"].ToString());
                        temp = Replace(temp, "[整型一]", dt_base.Rows[i]["Int1"].ToString());
                        temp = Replace(temp, "[整型二]", dt_base.Rows[i]["Int2"].ToString());
                        temp = Replace(temp, "[日期一]", Format(dt_base.Rows[i]["Datetime1"], "[日期一]", formats));
                        temp = Replace(temp, "[日期二]", Format(dt_base.Rows[i]["Datetime2"], "[日期二]", formats));
                        temp = Replace(temp, "[主线-索引]", dt_base.Rows[i]["index"].ToString());
                        temp = Replace(temp, "[主线-关键字]", Format(dt_base.Rows[i]["KeyWords"], "[主线-关键字]", formats));
                        temp = Replace(temp, "[主线-节点]", dt_base.Rows[i]["Node"].ToString());
                        temp = Replace(temp, "[主线-链接]", Format(dt_base.Rows[i]["Link"], "[主线-链接]", formats));
                        temp = Replace(temp, "[主线-添加人]",dt_base.Rows[i]["AddName"].ToString());
                        temp = Replace(temp, "[主线-添加时间]", Format(dt_base.Rows[i]["AddDate"], "[主线-添加时间]", formats));
                        temp = Replace(temp, "[主线-修改人]", dt_base.Rows[i]["UppdataName"].ToString());
                        temp = Replace(temp, "[主线-修改时间]", Format(dt_base.Rows[i]["UppdataDate"], "[主线-修改时间]", formats));
                        str_main += temp;
                        output += string.Format(str_main,str_pic,str_route);
                    }
                }
                else //图文连接
                {
                    DataTable dt_base = new DataTable();
                    if (key != "" && nodes == "0") { dt_base = Data.Execute("SELECT top " + (page * pageset) + " * FROM [V_W_ImageAndText] WHERE [Active]=1 " + schkey + " ORDER BY [INDEX] DESC,[ID] DESC"); }
                    else { dt_base = Data.Execute("SELECT top " + (page * pageset) + " * FROM [V_W_ImageAndText] WHERE [Active]=1 and [Node] in (" + nodes + ") " + schkey + " ORDER BY [INDEX] DESC,[ID] DESC"); }  
                    for (int i = (page - 1) * pageset; i < dt_base.Rows.Count; i++)
                    {
                        string temp = template_main;
                        temp = Replace(temp, "[链接-序号]", dt_base.Rows[i]["ID"].ToString());
                        temp = Replace(temp, "[链接-节点]", dt_base.Rows[i]["Node"].ToString());
                        temp = Replace(temp, "[链接-图片]", dt_base.Rows[i]["ItemUrl"].ToString());
                        temp = Replace(temp, "[链接-标题]", Format(dt_base.Rows[i]["ItemTitle"], "[链接-标题]", formats));
                        temp = Replace(temp, "[链接-描述]", Format(dt_base.Rows[i]["ItemDiscrab"], "[链接-描述]", formats));
                        temp = Replace(temp, "[链接-链接]", Format(dt_base.Rows[i]["Link"], "[链接-链接]", formats));
                        temp = Replace(temp, "[链接-索引]", dt_base.Rows[i]["index"].ToString());
                        temp = Replace(temp, "[链接-关键字]", Format(dt_base.Rows[i]["KeyWords"], "[链接-关键字]", formats));
                        temp = Replace(temp, "[链接-添加人]", dt_base.Rows[i]["AddName"].ToString());
                        temp = Replace(temp, "[链接-添加时间]", Format(dt_base.Rows[i]["AddDate"], "[链接-添加时间]", formats));
                        temp = Replace(temp, "[链接-修改人]", dt_base.Rows[i]["UppdataName"].ToString());
                        temp = Replace(temp, "[链接-修改时间]", Format(dt_base.Rows[i]["UppdataDate"], "[链接-修改时间]", formats));
                        output+=temp;
                    }

                }
            }
            else
            {
                //空白文本
                string temp = "";
                temp = template_main;
                dt = Data.Execute("SELECT top 1 * FROM [V_W_SuperModel] WHERE [Node]=" + nodes);
                if (dt.Rows.Count > 0)
                {
                    temp = Replace(temp, "[节点]", dt.Rows[0]["Node"].ToString());
                    temp = Replace(temp, "[标题]", Format(dt.Rows[0]["S_str1"], "[标题]", formats));
                    temp = Replace(temp, "[正文]", Format(dt.Rows[0]["L_str1"], "[正文]", formats));
                    temp = Replace(temp, "[添加人]", dt.Rows[0]["AddName"].ToString());
                    temp = Replace(temp, "[添加时间]", Format(dt.Rows[0]["AddDate"], "[添加时间]", formats));
                    temp = Replace(temp, "[修改人]", dt.Rows[0]["UppdataName"].ToString());
                    temp = Replace(temp, "[修改时间]", Format(dt.Rows[0]["UppdataDate"], "[修改时间]", formats));
                    output = temp;
                }
            }
        }
        return output;
    }

    /// <summary>
    /// 翻页区域
    /// 基础区域可使用标记：[首页链接],[上页链接],[下页链接],[末页链接]
    /// 页码区域可使用标记：[页链接],[页码]
    /// </summary>
    /// <param name="setup">基础区域模板</param>
    /// <param name="template">页码区域模板</param>
    /// <param name="count">页码区域长度</param>
    /// <param name="pageset">每页条数</param>
    /// <returns></returns>
    static public string Page( bool islink, string setup, string template, int count, int pageset)
    {
        return Page(Core.getInt("node").ToString(),islink, setup, template,"", count, pageset);
    }

    /// <summary>
    /// 翻页区域
    /// 基础区域可使用标记：[首页链接],[上页链接],[下页链接],[末页链接]
    /// 页码区域可使用标记：[页链接],[页码]
    /// </summary>
    /// <param name="node">对应的列表分类</param>
    /// <param name="setup">基础区域模板</param>
    /// <param name="template">页码区域模板</param>
    /// <param name="count">页码区域长度 当值小于3时页面全部显示</param>
    /// <param name="pageset">每页条数</param>
    /// <returns></returns>
    /// 
    //该函数一般与list函数搭配使用，其中的参数pageset为整数


    static public string Page(string nodes,bool islink, string setup, string template,string KeyWords, int count, int pageset)
    {
        string output = "";

        if (count < 6) { count = 6; }
        int allcount;
        if (nodes == "0" && KeyWords != "")
        {
            if (!islink) { allcount = (int)Data.Execute("SELECT count(ID) FROM [V_W_SuperModel] WHERE  KeyWords like '%" + KeyWords + "%'").Rows[0][0]; }
            else { allcount = (int)Data.Execute("SELECT count(ID) FROM [V_W_ImageAndText] WHERE  KeyWords like '%" + KeyWords + "%'").Rows[0][0]; }
        }
        else
        {
            if (!islink) { allcount = (int)Data.Execute("SELECT count(ID) FROM [V_W_SuperModel] WHERE [Node] in(" + nodes + " )").Rows[0][0]; }
            else { allcount = (int)Data.Execute("SELECT count(ID) FROM [V_W_ImageAndText] WHERE [Node] in(" + nodes + " )").Rows[0][0]; }
        }
        if (allcount > pageset)
        {
            // 处理原始地址
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



            output = setup;
           
            int page = Core.page();
            int maxpage = (int)((allcount - 1) / pageset) + 1;

            int start = 1;
            int end = maxpage;
            string temps = "";
            
            output = Replace(output, "[总条数]", allcount.ToString());
            output = Replace(output, "[总页数]", maxpage.ToString());
            output = Replace(output, "[当前页数]", page.ToString());
           //在页数4以上时，当count值不为空时，显示count个页码 其余都已...代替不做连接
            
                for (int i = start; i <= end; i++)
                {
                    string temp = template;
                    if (count - i == 2 && count <end)
                    {
                        temps += "...";
                        i = end - 2;
                    }
                    else
                    {
                        if (page == i)
                        {
                            temp = Replace(temp, "[页链接]", "#");
                        }
                        else
                        {
                            temp = Replace(temp, "[页链接]", "?page=" + i + newpath);
                         }
                        temp = Replace(temp, "[页码]", i.ToString());
                        temps += temp;
                   }
                  
                  
                }
              
            if (page == 1)
            {
                output = Replace(output, "[上页链接]", "#");
                output = Replace(output, "[首页链接]", "#");
            }
            else
            {
                output = Replace(output, "[上页链接]", "?page=" + (page - 1) + newpath);
                output = Replace(output, "[首页链接]", "?page=" + "1" + newpath);
            }

            if (page == maxpage)
            {
                output = Replace(output, "[下页链接]", "#");
                output = Replace(output, "[末页链接]", "#");
            }
            else
            {
                output = Replace(output, "[下页链接]", "?page=" + (page + 1) + newpath);
                output = Replace(output, "[末页链接]", "?page=" + maxpage + newpath);
            }
            output = Replace(output, "[页码区]", temps);
        }

        return output;
    }


  

    static public string get(string val)
    {
        return Core.get(val);
    }

    static public int getInt(string val)
    {
        return Core.getInt(val);
    }

    /// 根据ID返回栏目名称
    /// </summary>
    /// <param name="id">字串ID</param>
    /// <returns></returns>
    static public string Title(int id)
    {
        DataTable dt = Data.Execute("SELECT top 1 * FROM [W_CompList] WHERE [ID]=" + id);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0]["title"].ToString();
        }
        return "";
    }

    /// <summary>
    /// 根据栏目名称返回栏目ID
    /// </summary>
    /// <param name="title">栏目名称</param>
    /// <returns></returns>
    static public int Title(string title)
    {
        DataTable dt = Data.Execute("SELECT top 1 * FROM [W_CompList] WHERE [title]='" + title + "'");
        if (dt.Rows.Count > 0)
        {
            return int.Parse(dt.Rows[0]["id"].ToString());
        }
        return 0;
    }
    #endregion
    /*===================字符串处理函数========================================*/
    #region 字符串处理函数
    /// 根据字串ID返回Value
    /// </summary>
    /// <param name="id">字串ID</param>
    /// <returns></returns>
    static public string Value(int id)
    {
        DataTable dt = Data.Execute("SELECT top 1 * FROM [W_Constant] WHERE [ID]=" + id);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0]["Value"].ToString();
        }
        return "";
    }

    /// <summary>
    /// 根据字串名返回Value
    /// </summary>
    /// <param name="name">字串名</param>
    /// <returns></returns>
    static public string Value(string name)
    {
        DataTable dt = Data.Execute("SELECT top 1 * FROM [W_Constant] WHERE [Name]='" + name + "'");
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0]["Value"].ToString();
        }
        return "";
    }


    #endregion
    /*===================特殊处理函数==========================================*/
    #region  特殊处理函数

    //将html中的某段字符替换
    static private string Replace(string html, string mark, string value)
    {
        if (html.IndexOf(mark) != -1)
        {
            return html.Replace(mark, value);
        }
        else
        {
            return html;
        }
    }

    /// <summary>
    /// 格式处理函数
    /// </summary>
    /// <param name="data">待处理数据</param>
    /// <param name="type">处理类型</param>
    /// <param name="format">处理指定格式</param>
    /// <returns></returns>
    static private string Format(object data, string type, Hashtable format)
    {
        if (format[type] != null)
        {
            switch (type)
            {

                    case"[图集-标题]":
                    case"[图集-描述]":
                    case"[文本-标题]":
                    case"[文本-简介]":
                    case"[文本-内容]":
                    case"[文本-备注]":
                    case"[主图-标题]":
                    case"[主图-描述]":
                    case"[短文本一]":
                    case"[短文本二]":
                    case "[短文本三]":
                    case "[短文本四]":
                    case "[短文本五]":
                    case "[短文本六]":
                    case "[中文本一]":
                    case "[中文本二]":
                    case "[中文本三]":
                    case "[长文本一]":
                    case "[长文本二]":
                    case "[长文本三]":
                    case "[长文本四]":
                    case "[主线-关键字]":
                    case "[主线-链接]":
                    case "[链接-标题]":
                    case "[链接-描述]":
                    case "[链接-链接]":
                    case "[链接-关键字]":
                    case "[标题]":
                    case "[正文]":
                    string title = data.ToString();
                    int length = int.Parse(format[type].ToString());
                    if (length == -1)
                    {
                        return title;
                    }
                    else
                    {
                        title = System.Text.RegularExpressions.Regex.Replace(title, "<[^>]+>", "");
                        title = System.Text.RegularExpressions.Regex.Replace(title, "&[^;]+;", "");
                        title = title.Replace(" ", "");
                        if (title.Length > length)
                        {
                            return title.Substring(0, length) + "...";
                        }
                        else
                        {
                            return title;
                        }
                    }
                    case "[日期一]":
                    case "[日期二]":
                    case "[主线-添加时间]":
                    case "[主线-修改时间]":
                    case "[链接-添加时间]":
                    case "[链接-修改时间]":
                    case "[添加时间]":
                    case "[修改时间]":
                    try
                    {
                        return ((DateTime)data).ToString(format[type].ToString());
                    }
                    catch { }
                    break;
                default:
                    return data.ToString();
            }
        }
        return data.ToString();
    }
    #endregion
}