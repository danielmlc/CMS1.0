
<%@ Page Language="C#" AutoEventWireup="true" %>
<%=CMS.Inc("Header.aspx") %>
<!-- 主题图 -->
	
        
 <%=CMS.Output(45,true,"<div class=\"container-fluid cus-navbar cus-container-fluid\"><div class=\"jumbotron  min-height\" style=\"background-image: url([链接-图片]); \">[链接-描述] </div>","","","") %>
	


  <!-- 主体 -->
	<div class="container">

<div class="tabbable" id="tabs-773997">
				<ul class="nav nav-pills">
					<li class="active">
						<a href="#jainjie" data-toggle="tab">服务体系</a>
					</li>
					<li >
						<a href="#wenhua" data-toggle="tab">服务公告</a>
					</li>
				</ul>
				<div class="tab-content ">
					<div class="tab-pane fade in active" id="jainjie">
						<div>
                              <%=CMS.List("28","[正文]","",1,"") %>
	                    </div>
					</div>
					<div class="tab-pane fade" id="wenhua">
						<div>
                              <%=CMS.List("27","[正文]","",1,"") %>
						</div>
					</div>
				</div>
			</div>

		
	</div>
  <br/>
<!-- 页脚 -->
<%=CMS.Inc("Footer.aspx") %>