<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="System_Comp_source_edit" validateRequest="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>编辑栏目</title>
<script type="text/javascript" src="../../Inc/jquery.js"></script>
<script type="text/javascript" src="../../Inc/rna.js"></script>
<script type="text/javascript">
    function check() {
        if ($("#Name").val() == "") {
            alert("请输入栏目名称！");
            return false;
        }
        if ($("#Components").val() == "") {
            alert("请选择所用组件！");
            return false;
        }
        if ($("#Link").val() == "") {
            alert("请选择所属栏目！");
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
        <div id="pagetit">&gt; 站点结构管理 编辑栏目</div>
        <div id="table"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FAFAFA">
           <tr>
            <td height="26" id="actbar">
              <input class="button" type="button" onclick="window.location.href='<%=Core.Cookies("History")%>'" value=" 返回 " />
              <input class="button" type="submit" value=" 保存 " />
            </td>
          </tr>
          <tr>
            <td><table class="table" width="100%" border="0" cellspacing="0" cellpadding="5">
              <tr>
                <td width="120" class="tit">栏目名称</td>
                <td><%=Dialog.Text("Name", 50, 50, Name)%></td>
              </tr>
              <tr>
                <td class="tit">所用组件</td>
                <td><%=Dialog.Select("Components", Data.SelectData("select [CompName],[id] from [W_Components]"), Components)%></td>
              </tr>
              <tr>
                <td class="tit">所属栏目</td>
                <td><%=Dialog.Select("Link", "首页,0|" + Data.SelectData("select [Name],[id] from [W_DataSource] where [Link]=@", 0, ""), Link)%></td>
              </tr>
              <tr>
                <td width="120" class="tit">栏目排序</td>
                <td><%=Dialog.Select("Index", "自然顺序（添加时间正序）,0|1,1|2,2|3,3|4,4|5,5|6,6|7,7|8,8|9,9|10,10|11,11|12,12", Index)%></td>
              </tr>
              <tr>
                <td class="tit">栏目状态</td>
                <td><%=Dialog.Radio("Active", "启用,1|禁用,0", Active)%></td>
              </tr>
              <tr>
                <td width="120" class="tit">预览路径</td>
                <td><%=Dialog.Text("Preview", 50, 50, Preview)%></td>
              </tr>
              <tr>
                <td class="tit">配置文本</td>
                <td><%=Dialog.TextArea("Param", 10, 100, Param)%></td>
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
