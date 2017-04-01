<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="System_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>导航</title>
<style type="text/css">
body 
{
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #EBEBEB;
}
body, td, th
{
	font-size: 14px;
	font-family:宋体;
	color:#0076A3;
}
a:link
{
	color: #0076A3;
	text-decoration: none;
}
a:visited
{
	color: #0076A3;
	text-decoration: none;
}
a:hover
{
	color: #0076A3;
	text-decoration: underline;
}
a:active
{
	color: #0076A3;
	text-decoration: none;
}
ul
{
	padding:0px;
	margin:0px;
	padding-left:24px;
	padding-top:0px;
	padding-bottom:0px;
}
li
{
	line-height:24px;
}
.child
{
	padding-left:20px;
	padding-top:5px;
	padding-bottom:5px;
	font-size:12px;
}
.list
{
    margin-top:20px;
}
.root
{
	line-height:36px;
	height:36px;
	font-weight:bold;
	text-align:center;
	cursor:pointer;
	background-image:url(images/title_bg2.jpg);
	color:#FFF;
	width:180px;
	margin-left:auto;
	margin-right:auto;
}
.exit
{
    line-height:50px;
    height:50px;
}
.logo
{
    line-height:25px;
    text-align:center;
    font-size:12px;
    font-family:Arial Black;
    font-weight:bold;
     margin-top:15px;
}
.ver
{  
    line-height:20px;
    text-align:center;
    font-size:12px;
    font-family:Arial;
    margin-top:5px;
    margin-bottom:25px;
}
</style>
<script src="Inc/jquery.js" type="text/javascript"></script>
<script language="JavaScript" type="text/javascript">
    function sw(id) {
        if ($("#child" + id).css("display") == "none") {
            $("#child" + id).show(100);
        } else {
            $("#child" + id).hide(100);
        }
    }
function exit(){
	if (window.confirm('确定要退出系统么？')){
		  $.ajax({
              type: "POST",
              url: "Exit.aspx",
              data: "",
              success: function (msg) {
               
				 if(msg=="1"){ window.parent.location.href="Login.aspx"; }
                                 },
			  error: function(msg){
			       alert(msg.value);
			  }
          });
	}
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     
        
        <div class="list">
            <div class="root" onclick="sw(0)">站点管理单元</div>
            <div class="child" id="child0">
                <ul id="c_1">
                <li><a href="Main.aspx" target="mainFrame">网站结构一览</a></li>
                 <li><a href="Comp/Source/Default.aspx" target="mainFrame">站点结构管理</a></li>
                <li><a href="Comp/Constant/Default.aspx" target="mainFrame">字符串管理</a></li>
                </ul>
            </div>
            <div class="root" onclick="sw(1)">内容维护单元</div>
            <div class="child" id="child1">
           
                <% showMenu(0);%>
            </div>
            <div class="root" onclick="sw(2)">数据管理单元</div>
            <div class="child" id="child2">
                <ul id="Ul1">
                <li><a href="Comp/AdminUser/Default.aspx" target="mainFrame">用户管理</a></li>
              
                  <li><a href="Comp/Bankup/Default.aspx" target="mainFrame">数据备份管理</a></li>
                 <%--<li><a href="Comp/Requestinfo/Default.aspx" target="mainFrame">需求信息管理</a></li>
                 <li><a href="Comp/Orderinfo/Default.aspx" target="mainFrame">订单信息管理</a></li>
                    <li><a href="Comp/Evaluate/Default.aspx" target="mainFrame">评论信息审核管理</a></li>
                 </ul>--%>
            </div>
            <div class="root" onclick="exit()">退出系统</div>
            <div class="logo">当前用户：<%=Core.Session("UserName")%></div>
        <div class="ver">Copyright@2015<br/>DanielMLC All Rights Reserved</div>
        </div>
       
    </div>
    </form>
</body>
</html>
