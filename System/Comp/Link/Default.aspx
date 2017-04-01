<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="System_Comp_comp_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title><%=tit%></title>
<script type="text/javascript" src="../../Inc/jquery.js"></script>
<link href="../../css/comp.css" rel="stylesheet" type="text/css" />
<script type="text/jscript">
    function del(id, node) {
        if (confirm("确定要删除么？")) {
            document.forms["form1"].action = "?act=del&id=" + id + "&node=" + node;
            document.forms["form1"].submit();
        }
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="pagetit">&gt;<%=tit%></div>
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
                        <td class="title"><div align="center">资源链接地址</div></td>
                        <td width="140" class="title"><div align="center">添加日期</div></td>
                            <td width="120" class="title"><div align="center">关键字</div></td>
                        <td width="70" class="title"><div align="center">排序</div></td>
                        <td width="40" class="title"><div align="center">状态</div></td>
                        <td width="80" class="title"><div align="center">操作</div></td>
                      </tr>
                      <%
                          if (dt.Rows.Count == 0)
                          {
                              Response.Write("<tr><td class=\"nodata\" colspan=\"9\"><div align=\"center\">暂无数据</div></td></tr>");
                          }
                          for (int i = RNA.startIndex(); i < RNA.endIndex(dt.Rows.Count); i++)
                          {
                      %>
                      <tr>
                        <td><div align="center"><input type="checkbox" class="checkbox" name="C_Mark" value="<%=dt.Rows[i]["ID"]%>" /></div></td>
                        <td><div align="center"><%=dt.Rows[i]["ID"]%></div></td>
                        <td><div class="center"><%=dt.Rows[i]["ItemTitle"]%></div></td>
                        <td><div align="center"><%=dt.Rows[i]["ItemUrl"]%></div></td>
                        <td><div align="center"><%=dt.Rows[i]["AddDate"]%></div></td>
                          <td><div class="center"><% =dt.Rows[i]["KeyWords"].ToString()%></div></td>
                         <td><div align="center"><%=dt.Rows[i]["Index"]%></div></td>
                        <td><div align="center">
                        <%if (dt.Rows[i]["Active"].ToString() == "0")
                              {
                            Response.Write("<span>未启用</span>");
                        }else{
                            Response.Write("<span>已启用</span>");
                        }
                        %></div></td>
                        <td><div align="center"><a href="#" onclick="del(<%=dt.Rows[i]["ID"]%>,<%=node%>)">删除</a> <a href="edit.aspx?id=<%=dt.Rows[i]["ID"]%>&node=<%=node%>">修改</a> </div></td>
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
