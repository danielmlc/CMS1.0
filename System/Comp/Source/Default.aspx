<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="System_Comp_comp_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>站点结构管理</title>
<script type="text/javascript" src="../../Inc/jquery.js"></script>
<script type="text/javascript" src="../../Inc/rna.js"></script>
<link href="../../css/comp.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="pagetit">&gt; 站点结构管理</div>
        <div id="table">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FAFAFA">
          <tr>
            <td height="26" id="actbar">
              <input class="button" type="button" onclick="window.location.href='../../Main.aspx'" value=" 返回 " />
              <input class="button" type="button" onclick="window.location.href='edit.aspx'" value=" 新建 " />
            </td>
          </tr>
         
          <tr>
            <td>
            <table id="unit1" width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                          <td>
                            <table width="100%" border="1" align="center" cellpadding="0" cellspacing="0" class="table">
                              <tr>
                                <td width="50" class="title"><div align="center"></div></td>
                                <td width="50"class="title"><div align="center">ID号</div></td>
                                <td class="title"><div align="center">栏目名称</div></td>
                                <td width="100" class="title"><div align="center">所用组件</div></td>
                                <td width="100" class="title"><div align="center">排序权重</div></td>
                                <td width="40" class="title"><div align="center">状态</div></td>
                                <td width="80" class="title"><div align="center">操作</div></td>
                              </tr>
                              <%showSource(0,"");%>
                            </table>
                        </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
              </table>
              </td>
          </tr>
        </table>
        </div>
    </div>
    </form>
</body>
</html>
