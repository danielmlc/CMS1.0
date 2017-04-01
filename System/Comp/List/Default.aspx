<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="System_Comp_comp_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title><%=table.Rows[0]["Name"].ToString()%></title>
<script type="text/javascript" src="../../Inc/jquery.js"></script>
<script type="text/javascript" src="../../Inc/rna.js"></script>
<link href="../../css/comp.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="pagetit">&gt; <%=table.Rows[0]["Name"].ToString()%></div>
        <div id="table"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FAFAFA">
          <tr>
            <td height="26" id="actbar">
              <input class="button" type="button" onclick="window.location.href='../../Main.aspx'" value=" 返回 " />
              <input class="button" type="button" onclick="window.location.href='edit.aspx?node=<%=node%>'" value=" 新建 " />
            </td>
          </tr>
          <tr>
            <td><table id="unit1" width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><table width="100%" border="1" align="center" cellpadding="0" cellspacing="0" class="table">
                      <tr>
                        <td width="50" class="title"><div align="center">
                            <input type="checkbox" id="C_all" name="C_all" value="" onclick="c_all()" />
                        </div></td>
                        <td width="50"class="title"><div align="center">ID号</div></td>
                        <td class="title"><div align="center">标题</div></td>
                        <td width="80" class="title"><div align="center">作者</div></td>
                        <td width="150" class="title"><div align="center">添加日期</div></td>
                        <td width="120" class="title"><div align="center">关键字</div></td>
                        <td width="120" class="title"><div align="center">序列</div></td>
                        <td width="40" class="title"><div align="center">状态</div></td>
                        <td width="80" class="title"><div align="center">操作</div></td>
                      </tr>
                      <%
                          if (dt.Rows.Count == 0)
                          {
                              Response.Write("<tr><td class=\"nodata\" colspan=\"7\"><div align=\"center\">暂无数据</div></td></tr>");
                          }
						  
						  for (int i = RNA.startIndex(); i < RNA.endIndex(dt.Rows.Count); i++)
                          {
                      %>
                      <tr>
                        <td><div align="center"><input type="checkbox" class="checkbox" name="C_Mark" value="<%=dt.Rows[i]["ID"]%>" /></div></td>
                        <td><div align="center"><%=dt.Rows[i]["ID"]%></div></td>
                        <td><div class="center"><% =dt.Rows[i]["S_str1"].ToString()%></div></td>
                        <td><div class="center"><% =dt.Rows[i]["S_str2"].ToString()%></div></td>
                        <td><div align="center"><%=Core.Date(dt.Rows[i]["Datetime1"], "yyyy-MM-dd")%></div></td>
                         <td><div class="center"><% =dt.Rows[i]["KeyWords"].ToString()%></div></td>
                         <td><div class="center"><% =dt.Rows[i]["Index"].ToString()%></div></td>
                        <td><div align="center"><a href="#" onclick="active(this,<%=dt.Rows[i]["ID"]%>)"><%
                              if (dt.Rows[i]["Active"].ToString() == "0")
                              {
                            Response.Write("<img src=\"../../images/active_0.gif\" alt=\"未发布\" border=\"0\" />");
                        }else{
                            Response.Write("<img src=\"../../images/active_1.gif\" alt=\"已发布\" border=\"0\" />");
                        }
                        %></a></div></td>
                        <td><div align="center"><a href="#" onclick="del(<%=dt.Rows[i]["ID"]%>,<%=dt.Rows[i]["Node"]%>)">删除</a> <a href="edit.aspx?node=<%=dt.Rows[i]["Node"]%>&id=<%=dt.Rows[i]["ID"]%>">修改</a> </div></td>
                      </tr>
                      <%} %>
                    </table></td>
                </tr>
                <tr>
                    <td><%=RNA.page(dt.Rows.Count)%></td>
                </tr>
              </table></td>
          </tr>
        </table></div>
    </div>
    </form>
</body>
</html>
