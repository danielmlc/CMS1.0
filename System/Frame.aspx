<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frame.aspx.cs" Inherits="System_Frame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站管理平台</title>
</head>

<frameset rows="60,*"> 
<frame name="TopFrame"  src="Top.aspx" id="topFrame" title="topFrame"  frameborder="no" border="0"  ramespacing="0"> 
<frameset id="frame1" cols="220,*" frameborder="no" border="0" framespacing="0">
  <frame src="Left.aspx" name="leftFrame" scrolling="" noresize="noresize" id="leftFrame" title="leftFrame" />
  <frame src="Main.aspx" name="mainFrame" id="mainFrame" title="mainFrame" />
</frameset>
</frameset>
<noframes> 
<body> 
    很抱歉，馈下使用的浏览器不支援框架功能，请转用新的浏览器。 
</body> 
</noframes>
</html>
