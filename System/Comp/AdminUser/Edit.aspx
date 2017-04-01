<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="System_Comp_source_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>编辑管理员</title>
<script type="text/javascript" src="../../Inc/jquery.js"></script>
<script type="text/javascript" src="../../Inc/rna.js"></script>
<script type="text/javascript">
    function check() {
        if ($("#Name").val() == "") {
            alert("请输入栏目名称！");
            return false;
        }
        if ($("#AdminPass").val() != $("#AdminPass1").val()) {
            alert("密码输入有错误，请重新输入！");
            return false;
        }
       
        return true;
    }
</script>
<link href="../../css/comp.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" onsubmit="return check();">
    <div>
        <div id="pagetit">&gt; 编辑管理员</div>
        <div id="table"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FAFAFA">
          <tr>
            <td height="26" id="actbar">
              <input class="button" type="button" onclick="window.location.href='<%=Core.Cookies("History")%>'" value=" 返回 " />
              <input class="button" type="submit" value=" 保存 " />
            </td>
          </tr>
          <tr>
            <td><table class="table" width="100%" border="0" cellspacing="0" cellpadding="5">
              <%if (id == 0)
                {%>
              <tr>
                <td width="120" class="tit">用 户 名</td>
                <td><%=Dialog.Text("AdminName", 20, 40, AdminName)%></td>
              </tr>
              <%}
                else
                { %>
              <tr>
                <td width="120" class="tit">用 户 名</td>
                <td><%=Dialog.Output("AdminName", 20, 40, AdminName)%></td>
              </tr>
              <%} %>
              <tr>
                <td class="tit">登录密码</td>
                <td><%=Dialog.Password("AdminPass", 20, 40, "")%></td>
              </tr>
              <tr>
                <td class="tit">确认密码</td>
                <td><%=Dialog.Password("AdminPass1", 20, 40, "")%></td>
              </tr>
              <tr>
                <td class="tit">显示名称</td>
                <td><%=Dialog.Text("RealName", 20, 40, RealName)%></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td>&nbsp;</td>
          </tr>
        </table></div>
    </div>
    </form>
</body>
</html>
