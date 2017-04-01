<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="System_Comp_comp_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>管理员管理</title>
<script type="text/javascript" src="../../Inc/jquery.js"></script>
<script type="text/javascript" src="../../Inc/rna.js"></script>
<link href="../../css/comp.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="pagetit">&gt; 管理员管理</div>
        <div id="table"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FAFAFA">
          <tr>
            <td height="26" id="actbar">
              <input class="button" type="button" onclick="window.location.href='../../Main.aspx'" value=" 返回 " />
              <input class="button" type="button" onclick="window.location.href='edit.aspx'" value=" 新建 " />
            </td>
          </tr>
          <tr>
            <td><table id="unit1" width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><table width="100%" border="1" align="center" cellpadding="0" cellspacing="0" class="table">
                      <tr>
                        <td width="50" class="title"><div class="center">
                            <input type="checkbox" id="C_all" name="C_all" value="" onclick="c_all()" />
                        </div></td>
                        <td width="50"class="title"><div class="center">ID号</div></td>
                        <td class="title"><div class="center">用户名</div></td>
                        <td class="title"><div class="center">显示名</div></td>
                        <td width="160" class="title"><div class="center">上次登录</div></td>
                        <td width="80" class="title"><div class="center">状态</div></td>
                        <td width="80" class="title"><div class="center">操作</div></td>
                      </tr>
                      <%
                          for (int i = RNA.startIndex(); i < RNA.endIndex(dt.Rows.Count); i++)
                          {
								  
                      %>
                      <tr>
                        <td><div class="center"><input type="checkbox" class="checkbox" name="C_Mark" value="<%=dt.Rows[i]["ID"]%>" /></div></td>
                        <td><div class="center"><%=dt.Rows[i]["ID"]%></div></td>
                        <td><div class="center"><%=dt.Rows[i]["AdminName"]%></div></td>
                        <td><div class="center"><%=dt.Rows[i]["RealName"]%></div></td>
                        <td><div class="center"><%=dt.Rows[i]["AdminLastTime"]%></div></td>
                        <td><div class="center">
                        <%
						  if(dt.Rows[i]["AdminGroup"].ToString()=="0"){
							  Response.Write("<span class=\"red\">已禁用</span>");
						  }else{
							  Response.Write("<span class=\"blue\">已启用</span>");
						  }
					    %>
                        </div></td>
                        <td><div class="center"><a href="#" onclick="del(<%=dt.Rows[i]["ID"]%>)">删除</a> <a href="edit.aspx?id=<%=dt.Rows[i]["ID"]%>">修改</a> </div></td>
                      </tr>
					  <%
					  } %>
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
