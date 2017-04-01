<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Nextpage.aspx.cs" Inherits="System_Comp_List_Nextpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>项目额外设置</title>
  <script type="text/javascript" src="../../Inc/jquery.js"></script>
<script type="text/javascript" src="../../Inc/rna.js"></script>
<link href="../../css/comp.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" onsubmit="return check();">
    <div>
        <div id="pagetit">&gt;项目额外配置</div>
        <div id="table"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FAFAFA">
          <tr>
            <td height="26" id="actbar">
               <input class="button" type="button" onclick="window.location.href='edit.aspx?node=<%=Node%>&id=<%=ProjId%>'" value=" 返回上层 " />
                 <input class="button" type="button" onclick="window.location.href='default.aspx'" value=" 返回列表页 " /> 
            </td>
          </tr>
          <tr>
            <td><table class="table" width="100%" border="0" cellspacing="0" cellpadding="5">
              <tr> <td class="tit">提示消息：：</td> <td ><h2>项目基本信息配置已经成功，请对项目继续进行一下配置：</h2></td></tr>
               <tr>
                <td class="tit">附加图表列表描述：</td>
                <td><a style="color:Red" href="pictureEdit/default.aspx">【点击此处编辑附加图表列表】</a></td>
              </tr>
               <tr>
                <td class="tit">附加文本列表描述：</td>
                <td><a style="color:Red" href="RouteEdit/default.aspx">【点击此处编辑附加文本列表】</a></td>
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
