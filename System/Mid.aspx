<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mid.aspx.cs" Inherits="System_Mid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>无标题页</title>
<script type="text/javascript">
var _screen=false;
function shiftwindow() {
	if(_screen==false) {
		window.parent.document.getElementById("frame1").cols='0,8,*';
		_screen=true;
		document.getElementById("button").src = 'images/mid_show.gif';
	}
	else if(_screen==true) {
		window.parent.document.getElementById("frame1").cols='200,8,*';
		_screen=false;
		document.getElementById("button").src = 'images/mid_hide.gif';
	}
}
</script>
<style type="text/css">
html 
{
	height:100%;
}
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	height:100%;
	background-image:url(images/mid_bg.gif);
}
#outbox {
	display:table;
	position:static;
	height:100%;
}
#midbox{
	position:absolute;
	top:50%;
	left:0 0 0 0;
}
</style>
</head>
<body>
    <div id="outbox">
    	<div id="midbox"><img onselectstart="return false;" id="button" style="cursor:pointer" src="images/mid_hide.gif" width="8" height="58" border="0" onclick="shiftwindow()" /></div>
    </div>
</body>
</html>
