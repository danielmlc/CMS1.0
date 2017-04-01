<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="System_Comp_List_PictureEdit_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>文本管理编辑</title>
    <link href="../../../../HtmlEidtor/themes/default/default.css" rel="stylesheet" />
<script type="text/javascript" src="../../../Inc/jquery.js"></script>
<script type="text/javascript" src="../../../Inc/rna.js"></script>
<link href="../../../css/comp.css" rel="stylesheet" type="text/css" />
 <script src="../../../Inc/ajaxupload.js" type="text/javascript"></script>
 <script src="../../../../HtmlEidtor/kindeditor-min.js"></script>
<script src="../../../../HtmlEidtor/lang/zh_CN.js"></script>

<script type="text/javascript">
    $(function () {
        var options = {
            uploadJson: '../../../../HtmlEidtor/asp.net/upload_json.ashx',     //上传文件配置
            fileManagerJson: '../../../../HtmlEidtor/asp.net/file_manager_json.ashx',   //上传文件配置
            allowFileManager: true,  //是否允许查看服务器空间
            filterMode: false,   //是否过滤代码
            themeType: "default",  //主题
            pasteType: 2, //0:禁止粘贴, 1:纯文本粘贴, 2:HTML粘贴
          
        };
        KindEditor.ready(
            function (K) {
                window.editor = K.create('#Content', options);
            });
    })
    function check() {
        if ($("#Title").val() == "") {
            alert("标题不能为空！");
            return false;
        }
        return true;
    }
</script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return check();">
    <div>
        <div id="pagetit">&gt; 文本管理编辑</div>
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
                <td width="120" class="tit">标题</td>
                <td><%=Dialog.Text("Title", 50, 60, Title)%></td>
              </tr>
          <tr>
                <td width="120" class="tit">简述</td>
                <td><%=Dialog.TextArea("NutShell", 2, 120, NutShell)%></td>
              </tr>
               <tr>
                <td width="120" class="tit">内容</td>
                <td><%=Dialog.TextArea("Content", 15, 120, Content)%></td>
              </tr>
               <tr>
                <td width="120" class="tit">备注</td>
                 <td><%=Dialog.TextArea("Remark", 4, 120, Remark)%></td>
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
