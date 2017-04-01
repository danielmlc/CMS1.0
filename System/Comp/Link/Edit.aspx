<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="System_Comp_List_Edit" validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>编辑链接</title>
<link href="../../../HtmlEidtor/themes/default/default.css" rel="stylesheet" />
<script type="text/javascript" src="../../Inc/jquery.js"></script>
<script type="text/javascript" src="../../Inc/rna.js"></script>
<script type="text/javascript" src="../../Inc/ajaxupload.js"></script>
<script src="../../../HtmlEidtor/kindeditor-min.js"></script>
<script src="../../../HtmlEidtor/lang/zh_CN.js"></script>
<script type="text/javascript">
    $(function () {
        upload("#ItemUrl", "../upload/upload.aspx");

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
                window.editor = K.create('#ItemDiscrab', options);
            });


    })
    function check() {
        //if ($("#ItemTitle").val() == "") {
        //    alert("请输入标题！");
        //    return false;
        //}
        return true;
    }
</script>
<link href="../../css/comp.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" onsubmit="return check();">
    <div>
        <div id="pagetit">&gt; <%=tit%></div>
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
                <td><%=Dialog.Text("ItemTitle", 50, 50, ItemTitle)%></td>
              </tr>
              <tr>
                <td width="120" class="tit">链接排序</td>
                <td><%=Dialog.Select("Index", "自然顺序（添加时间正序）,0|1,1|2,2|3,3|4,4|5,5|6,6|7,7|8,8|9,9|10,10|11,11|12,12|13,13|14,14|15,15|16,16|17,17|18,18|19,19|20,20", Index)%></td>
              </tr>
               <tr>
                <td class="tit">是否启用</td>
                <td><%=Dialog.Radio("Active", "启用,1|禁用,0", Active)%></td>
              </tr>
              <tr>
                <td class="tit">关 键 字</td>
                <td><%=Dialog.Text("KeyWords", 50, 50, KeyWords)%></td>
              </tr>
              <tr>
                <td class="tit">链接资源</td>
                <td><%=Dialog.File("ItemUrl", 50, ItemUrl)%></td>
              </tr>
               <tr>
                <td class="tit">连接地址</td>
                <td><%=Dialog.Text("Link", 100, 50, Link)%></td>
              </tr>
              <tr>
                <td class="tit">文本描述</td>
                <td><%=Dialog.TextArea("ItemDiscrab", 25, 120, ItemDiscrab)%></td>
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