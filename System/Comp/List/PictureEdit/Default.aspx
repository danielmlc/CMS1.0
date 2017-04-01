<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="System_Comp_List_PictureEdit_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
<title>项目展附加图表管理</title>
<script type="text/javascript" src="../../../Inc/jquery.js"></script>
<script type="text/javascript" src="../../../Inc/rna.js"></script>
<link href="../../../css/comp.css" rel="stylesheet" type="text/css" />
<script src="../../../Inc/pic/lightbox.js" type="text/javascript"></script>
<script src="../../../Inc/pic/prototype.js" type="text/javascript"></script>
<script  src="../../../Inc/pic/scriptaculous.js?load=effects"  type="text/javascript"></script>
<link rel="stylesheet" href="../../../css/lightbox.css" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="pagetit">&gt;项目附加图表管理</div>
        <div id="table"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FAFAFA">
          <tr>
            <td height="26" id="actbar">
              <input class="button" type="button" onclick="window.location.href='../nextpage.aspx?node=<%=Node%>&id=<%=ProjId%>'" value=" 返回 " />
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
                        <td width="50"class="title"><div class="center">编号</div></td>
                        <td class="title"><div class="center">附件标题</div></td>
                        <td class="title"><div class="center">存放路径</div></td>
                        <td width="50" class="title"><div class="center">是否主图</div></td>
                        <td width="80" class="title"><div class="center">操作</div></td>
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
                        <td><div class="center"><input type="checkbox" class="checkbox" name="C_Mark" value="<%=dt.Rows[i]["ID"]%>" /></div></td>
                        <td><div class="center"><%=dt.Rows[i]["ID"]%></div></td>
                        <td><div class="center"><%=dt.Rows[i]["ItemTitle"]%></div></td>
                        <td><div class="center"><%=dt.Rows[i]["ItemUrl"]%>"</div></td>
                        <td><div class="center">
                        <%
                            if (dt.Rows[i]["IsMain"].ToString() == "1")
                                  {
							      Response.Write("<span class=\"red\">主图</span>");
						          }
                              else{
							        Response.Write("<span class=\"blue\">展示图</span>");
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
