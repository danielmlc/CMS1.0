
<%@ Page Language="C#" AutoEventWireup="true" %>
<%=CMS.Inc("Header.aspx") %>

	

 <%=CMS.Output(46,true,"<div class=\"container-fluid cus-navbar cus-container-fluid\"><div class=\"jumbotron  min-height\" style=\"background-image: url([链接-图片]);\">[链接-描述] </div>","","","") %>
	


    <div class="container">
    <div class="row">
		<div class="panel panel-default">
			<div class="panel-body">
				

                 <%=CMS.List( " <div class=\"media\"> <div class=\"media-left\"><a href=\"#\"><img class=\"media-object icon_bigsize\" src=\"[链接-图片]\" ></a></div><div class=\"media-body\"><h4 class=\"media-heading\"><a href=\"CompanyNews.aspx?node=[链接-序号]\">[链接-标题]</a></h4> <div class=\"text-left\"><strong><span>发布时间：[链接-添加时间] </span>&nbsp;&nbsp;|<span>关键字：[链接-关键字]</span>&nbsp;&nbsp;|<span>作者：[链接-添加人]</span>&nbsp;&nbsp;|<span></span></strong></div> <p>[链接-描述]</p></div><hr class=\"clear_margin\"> </div>", "[链接-描述]=200,[链接-添加时间]=yyyy-MM-dd",10)%>
			   	
			</div>
	    </div>
        <%=CMS.Page(true,"<nav class=\"navbar-right\"><ul class=\"pagination \"><li><a href=\"[首页链接]\">首页</a></li><li><a href=\"[上页链接]\" aria-label=\"上一页\"><span aria-hidden=\"true\">&laquo;</span></a></li>[页码区]<li><a href=\"[下页链接]\" aria-label=\"下一页\"><span aria-hidden=\"true\">&raquo;</span></a></li><li><a href=\"[末页链接]\">尾页</a></li></ul></nav>", "<li><a href=\"[页链接]\"> [页码] </a></li> ",11,10)%>


       
	    	
    </div>
  
 

     </div>
  <br/>
<!-- 页脚 -->
<%=CMS.Inc("Footer.aspx") %>