<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="System_Comp_Text_Default" validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title><%=title%></title>
 <link href="../../../HtmlEidtor/themes/default/default.css" rel="stylesheet" />
<script type="text/javascript" src="../../Inc/jquery.js"></script>
<script type="text/javascript" src="../../Inc/rna.js"></script>
<script type="text/javascript" src="../../../HtmlEidtor/kindeditor-min.js"></script>
<script type="text/javascript" src="../../../HtmlEidtor/lang/zh_CN.js"></script>
<script type="text/javascript">
    $(function () {
        var options = {
            uploadJson: '../../../HtmlEidtor/asp.net/upload_json.ashx',     //上传文件配置
            fileManagerJson: '../../../HtmlEidtor/asp.net/file_manager_json.ashx',   //上传文件配置
            allowFileManager: true,  //是否允许查看服务器空间
            filterMode: false,   //是否过滤代码
            themeType: "default",  //主题
            pasteType: 2, //0:禁止粘贴, 1:纯文本粘贴, 2:HTML粘贴
        };
        KindEditor.ready(
           function (K) {
               window.editor = K.create('#L_str1', options);
           });
    })
    function check() {
        if ($("#S_str1").val() == "") {
            alert("请输入页面标题！");
            return false;
        }
        return true;
    }
</script>
<link href="../../css/comp.css" rel="stylesheet" type="text/css" />
</head>
<body onload="editor()">
    <form id="form1" runat="server" onsubmit="return check();">
    <div>
        <div id="pagetit">&gt; <%=title%></div>
        <div id="table"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FAFAFA">
          <tr>
            <td height="26" id="actbar">
              <input class="button" type="button" onclick="window.location.href='../../Main.aspx'" value=" 返回 " />
              <input class="button" type="submit" value=" 保存 " />
            </td>
          </tr>
          <tr>
            <td><table class="table" width="100%" border="0" cellspacing="0" cellpadding="5">
              <tr>
                <td width="120" class="tit">页面标题</td>
                <td><%=Dialog.Text("S_str1", 50, 50, Title)%></td>
              </tr>
              <tr>
                <td class="tit">页面内容</td>
                <td><%=Dialog.TextArea("L_str1", 40, 120, Text)%></td>
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
