<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="System_Comp_List_PictureEdit_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>编辑附加图表</title>
    <link href="../../../../HtmlEidtor/themes/default/default.css" rel="stylesheet" />
    <link href="../../../css/comp.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../../Inc/jquery.js"></script>
<script type="text/javascript" src="../../../Inc/rna.js"></script>
<script type="text/javascript" src="../../../Inc/ajaxupload.js"></script>

<script src="../../../../HtmlEidtor/kindeditor-min.js"></script>
<script src="../../../../HtmlEidtor/lang/zh_CN.js"></script>
<script type="text/javascript">
    $(function () {
        upload("#ItemUrl", "../../upload/upload.aspx");

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
                window.editor = K.create('#ItemDiscrab', options);
            });
    })
   
    function check() {
        if ($("#ItemTitle").val() == "") {
            alert("请输入图片标题！");
            return false;
        }
        if ($("#ItemUrl").val() == "") {
            alert("请上传图片！");
            return false;
        }
        return true;
    }
</script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return check();">
    <div>
        <div id="pagetit">&gt; 编辑附加图表</div>
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
                <td width="120" class="tit">附件标题</td>
                <td><%=Dialog.Text("ItemTitle", 30, 50, ItemTitle)%></td>
              </tr>
          <tr>
                <td class="tit">是否为主图</td>
                <td><%=Dialog.Radio("IsMain", "否,0|是,1", IsMain)%> *提示：一个项目只能设置一张主图</td>
              </tr>
              <tr>
                <td class="tit">附件上传</td>
               <td><%=Dialog.File("ItemUrl", 50, ItemUrl)%></td>
              </tr>
              <tr>
                <td class="tit">附件描述</td>
                <td><%=Dialog.TextArea("ItemDiscrab", 20, 120, ItemDiscrab)%></td>
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
