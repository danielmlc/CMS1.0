
<%@ Page Language="C#" AutoEventWireup="true" %>
<%=CMS.Inc("Header.aspx") %>
<!-- 主题图 -->
	
        
 <%=CMS.Output(47,true,"<div class=\"container-fluid cus-navbar cus-container-fluid\"><div class=\"jumbotron  min-height\" style=\"background-image: url([链接-图片]);\">[链接-描述] </div>","","","") %>
	


  <!-- 主体 -->
	<div class="container">

<div class="tabbable" id="tabs-773997">
				<ul class="nav nav-pills">
					<li class="active">
						<a href="#jainjie" data-toggle="tab">公司简介</a>
					</li>
					<li >
						<a href="#wenhua" data-toggle="tab">企业文化</a>
					</li>
					<li >
						<a href="#zhaopin" data-toggle="tab">人才招聘</a>
					</li>
					<li >
						<a href="#lianxi" data-toggle="tab">联系我们</a>
					</li>
				</ul>
				<div class="tab-content ">
					<div class="tab-pane fade in active" id="jainjie">
						<div>
                              <%=CMS.List("21","[正文]","",1,"") %>
	                    </div>
					</div>
					<div class="tab-pane fade" id="wenhua">
						<div>
                              <%=CMS.List("22","[正文]","",1,"") %>
						</div>
					</div>
					<div class="tab-pane fade" id="zhaopin">
						<div>
                               <%=CMS.List("23","[正文]","",1,"") %>
						</div>
					</div>
					<div class="tab-pane fade" id="lianxi">
						<div>
                             <%=CMS.List("24","[正文]","",1,"") %>
						</div>
					</div> 
				</div>
			</div>

		
	</div>
  <br/>
<!-- 页脚 -->
<%=CMS.Inc("Footer.aspx") %>