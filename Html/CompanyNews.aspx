
<%@ Page Language="C#" AutoEventWireup="true" %>
<%=CMS.Inc("Header.aspx") %>
 
 <%=CMS.Output(46,true,"<div class=\"container-fluid cus-navbar cus-container-fluid\"><div class=\"jumbotron  min-height\" style=\"background-image: url([链接-图片]);\">[链接-描述] </div>","","","") %>
	

<!-- 主体 -->
 <%=CMS.Output(true," <div class=\"container\">	<div class=\"panel panel-default\"><div class=\"panel-body\"><div class=\"page-header\"><h4 class=\"text-center\">[链接-标题]</h4><div class=\"text-center\"><span>发布时间：[链接-添加时间]</span>&nbsp;&nbsp;|<span>关键字：[链接-关键字]</span>&nbsp;&nbsp;|<span>作者：[链接-添加人]</span>&nbsp;&nbsp;|<span></span></div></div>[链接-描述]</div></div></div>","","","[链接-添加时间]=yyyy-MM-dd") %>
	
  <br/>
<!-- 页脚 -->
<%=CMS.Inc("Footer.aspx") %>