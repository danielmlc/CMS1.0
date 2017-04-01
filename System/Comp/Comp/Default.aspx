<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="System_Comp_comp_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>站点组件管理</title>
<script type="text/javascript" src="../../Inc/jquery.js"></script>
<script type="text/javascript" src="../../Inc/rna.js"></script>
<link href="../../css/comp.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form name="form1" method="post" action="Default.aspx?node=12" id="form1">
    <div>
        <div id="pagetit">&gt; 站点组件管理</div>
        <div id="table"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FAFAFA">
          <tr>
            <td height="26" id="actbar">&nbsp;</td>
          </tr>
          <tr>
            <td><table id="unit1" width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><table width="100%" border="1" align="center" cellpadding="0" cellspacing="0" class="table">
                      <tr>
                        <td width="50" class="title"><div align="center">
                            <input type="checkbox" id="C_all" name="C_all" value="checked" onclick="c_all()" />
                        </div></td>
                        <td width="50"class="title"><div align="center">ID号</div></td>
                        <td class="title"><div align="center">组件名称</div></td>
                        <td class="title"><div align="center">组件标识</div></td>
                        <td width="80" class="title"><div align="center">版本</div></td>
                      </tr>
                      <%
                          for (int i = RNA.startIndex(); i < RNA.endIndex(dt.Rows.Count); i++)
                          {
           				%>
                      <tr>
                        <td class="first"><div align="center">
                            <input type="checkbox" class="checkbox" name="C_Mark" value="<%=dt.Rows[i]["ID"]%>" />
                          </div></td>
                        <td><div align="center"><%=dt.Rows[i]["ID"]%></div></td>
                        <td><div align="center"><%=dt.Rows[i]["Name"]%></div></td>
                        <td><div align="center"><%=dt.Rows[i]["Path"]%></div></td>
                        <td><div align="center"><%
                              System.Xml.XmlDocument config = new System.Xml.XmlDocument();
                              try
                              {
                                  config.Load(Server.MapPath("../" + dt.Rows[i]["Path"] + "/config.xml"));
                                  Response.Write(config.SelectSingleNode("/config/version").InnerText.ToString());
                                  Response.Write("&nbsp;");
                                  Response.Write(config.SelectSingleNode("/config/revision").InnerText.ToString());
                              }
                              catch 
                              {
                                  Response.Write("未知");
                              }
                              
                              
                              
						%></div></div></td>
                      </tr>
                      <%
                          }
				      %>
                    </table></td>
                </tr>
              </table></td>
          </tr>
        </table></div>
    </div>
    </form>
</body>
</html>
