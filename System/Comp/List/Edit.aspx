<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="System_Comp_List_Edit" validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>编辑内容</title>
        <link href="../../../HtmlEidtor/themes/default/default.css" rel="stylesheet" />
<script type="text/javascript" src="../../Inc/jquery.js"></script>
<script type="text/javascript" src="../../Inc/rna.js"></script>
<%--<script type="text/javascript" src="../../Inc/laydate/laydate.js"></script>--%>
<script type="text/javascript" src="../../Inc/ajaxupload.js"></script>
<script type="text/javascript" src="../../../HtmlEidtor/kindeditor-min.js"></script>
<script type="text/javascript" src="../../../HtmlEidtor/lang/zh_CN.js"></script>
<script type="text/javascript">
    $(function () {
        upload("#S_str6", "../upload/upload.aspx");
        upload("#M_str1", "../upload/upload.aspx");
        
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
                window.editor = K.create('#L_str2', options);
                window.editor = K.create('#L_str3', options);
                window.editor = K.create('#L_str4', options);
            });
        
    })
  
    function check(){
        if ($("#S_str1").val() == "") {
	        alert("不可为空！");
	        return false;
	    }
	    var reg = /^\d+(\.\d+)?$/;  //非负浮点数；
	    var regint = /^\d+$/;  //非负整数；
	    if (!$("#Float1").val().match(reg)) {
	        alert("格式输入有误！");
	        return false;
	    }
	    if (!$("#Float2").val().match(reg)) {
	        alert("格式输入有误！");
	        return false;
	    }
	    if (!$("#Int1").val().match(regint)) {
	         alert("格式输入有误！");
	         return false;
	     }
	     if (!$("#Int2").val().match(regint)) {
	         alert("格式输入有误！");
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
        <div id="pagetit">&gt; <%=tit%> 编辑内容</div>
        <div id="table"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FAFAFA">
          <tr>
            <td height="26" id="actbar">
              <input class="button" type="button" onclick="window.location.href='default.aspx'" value=" 返回 " />
               <input class="button" type="submit" value=" 保存进行下一步配置 " />
            </td>
          </tr>
          <tr>
            <td><table class="table" width="100%" border="0" cellspacing="0" cellpadding="5">
              <tr><td width="120" class="tit">【项目基本信息】</td></tr>
              <tr>
                <td width="120" class="tit">产品名称</td>
                <td><%=Dialog.Text("S_str1", 50, 60, S_str1)%></td>
              </tr>
              <tr>
                <td width="120" class="tit">产品经理</td>
                 <td><%=Dialog.Text("S_str2", 50, 60, S_str2)%></td>
              </tr>
              <%-- <tr>
                <td width="120" class="tit">发布日期</td>
                <td><%=Dialog.Text_date("Datetime1", 30, Datetime1.ToString("yyyy-MM-dd"))%></td>
              </tr>--%>
               <tr>
                <td width="120" class="tit">演示地址</td>
                <td><%=Dialog.Text("S_str3", 50, 60, S_str3)%></td>
              </tr>
              <tr>
                <td width="120" class="tit">演示账号信息</td>
                <td><%=Dialog.Text("S_str4", 50, 60, S_str4)%></td>
              </tr>
               <tr>
                <td width="120" class="tit">联系方式</td>
                 <td><%=Dialog.Text("S_str5", 50, 60, S_str5)%></td>
              </tr>
               <tr>
                <td width="120" class="tit">产品缩略图</td>
                <td><%=Dialog.File("S_str6", 50, S_str6)%></td>
              </tr>
                <tr>
                <td width="120" class="tit">产品主图</td>
                 <td><%=Dialog.File("M_str1", 50, M_str1)%></td>
              </tr>
            <%--<tr>
                <td width="120" class="tit">中文本二</td>
                <td><%=Dialog.TextArea("M_str2", 10, 120, M_str2)%></td>
              </tr>
             <tr>
                <td width="120" class="tit">中文本三</td>
                <td><%=Dialog.TextArea("M_str3", 10, 120, M_str3)%></td>
              </tr>--%>
              <tr>
                <td width="120" class="tit">资源列表</td>
                <td><%=Dialog.TextArea("L_str1", 10, 120, L_str1)%></td>
              </tr>
             <tr>
                <td width="120" class="tit">具体描述</td>
                <td><%=Dialog.TextArea("L_str2", 30, 120, L_str2)%></td>
              </tr>
             <%--  <tr>
                <td width="120" class="tit">长文本三</td>
                <td><%=Dialog.TextArea("L_str3", 10, 120, L_str3)%></td>
              </tr>
              <tr>
                <td width="120" class="tit">长文本四</td>
                <td><%=Dialog.TextArea("L_str4", 10, 120, L_str4)%></td>
              </tr>
               <tr>
                <td width="120" class="tit">浮点输入一</td>
               <td><%=Dialog.Text("Float1", 10, 20, Float1)%></td>
              </tr>
               <tr>
                <td width="120" class="tit">浮点输入二</td>
                <td><%=Dialog.Text("Float2", 10, 20, Float2)%></td>
              </tr>
              <tr>
                <td width="120" class="tit">整型输入一</td>
               <td><%=Dialog.Text("Int1", 10, 20, Int1)%></td>
              </tr>
               <tr>
                <td width="120" class="tit">整型输入二</td>
                <td><%=Dialog.Text("Int2", 10, 20, Int2)%></td>
              </tr>
             
              <tr>
                <td width="120" class="tit">日期型二</td>--%>
                <%--<td><%=Dialog.Text_date("Datetime2", 30, Datetime2.ToString("yyyy-MM-dd"))%></td>
              </tr>--%>
                <tr><td width="120" class="tit">【项目配置信息】</td></tr>
                <tr>
                <td class="tit">状态：</td>
                <td><%=Dialog.Radio("Active", "禁用,0|启用,1", Active)%></td>
                </tr>
                <tr>
                <td class="tit">关 键 字：</td>
                <td><%=Dialog.Text("KeyWords", 100, 40, KeyWords)%></td>
              </tr>
              <tr>
                <td width="120" class="tit">项目排序：</td>
                <td><%=Dialog.Select("Index", "自然顺序（添加时间正序）,0|1,1|2,2|3,3|4,4|5,5|6,6|7,7|8,8|9,9|10,10|11,11|12,12|13,13|14,14|15,15|16,16|17,17|18,18|19,19|20,20", Index)%></td>
              </tr>
               <tr>
                <td class="tit">链接配置：</td>
                <td><%=Dialog.Text("Link", 100, 60, Link)%></td>
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