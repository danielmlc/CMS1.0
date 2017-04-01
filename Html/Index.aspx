
<%@ Page Language="C#" AutoEventWireup="true" %>
<%=CMS.Inc("Header.aspx") %>

  <!-- 主体 -->
 <div class="container-fluid">
                    <!-- 展示区 -->
           <!--  轮播图 -->
            <div class="row">


     <div id="carousel-example-generic" class="carousel slide" data-ride="carousel" data-interval="5000">
  <!-- Indicators -->
  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
    <%=CMS.List("12", " <div class=\"item [链接-链接]\"><img src=\"[链接-图片]\" ><div class=\"carousel-caption\"> <h3>[链接-标题]</h3><p>[链接-描述]</p> </div> </div>", "",4,"")%>
    
  </div>

  <!-- Controls -->
  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
  

      </div>
 <br/>

<!-- 分栏 -->
     <div class="container">
            <div class="row ">

						<div class="col-md-4 ">
					    	<div class="bigpadding">
								<div class="media">
									<div class="media-left">
									<a href="#">
									<img class="media-object icon_smallsize" src="img/svg/print.svg" alt="...">
									</a>
									</div>
									<div class="media-body">
										<h4 class="media-heading">产品&方案</h4>
										<ul class="list-inline">
                                            <%=CMS.List("17",false,"<li><a href=\"Product.aspx?node=[序号]\">[短文本一]</a></li>","","","",8,"") %>
											
										</ul>
									</div>
								</div>
							 </div>
                         </div>
						
						<div class="col-md-4">
							<div class="bigpadding">
								<div class="media">
									<div class="media-left">
									<a href="#">
									<img class="media-object icon_smallsize" src="img/svg/people.svg" alt="...">
									</a>
									</div>
									<div class="media-body">
										<h4 class="media-heading">服务&支持</h4>
										<ul class="list-inline">
												<li><a href="ProductList.aspx">产品预约演示</a></li>
                                                <li><a href="https://qiyukf.com/client?k=278ead0636b98b6efc9e9a69a48ba2ea&u=dtpdglnicadutdq6jrdw&gid=0&sid=0&atom=0&dvctimer=0&t=%E8%A5%BF%E5%AE%89%E6%98%93%E9%BE%99%E7%A7%91%E6%8A%80%E5%BC%80%E5%8F%91%E6%9C%89%E9%99%90%E5%85%AC%E5%8F%B8" target="blank"> 在线客服</a></li>
										</ul>
									</div>
                             </div>
						</div>
						</div>	
						<div class="col-md-4">
							
							<div class="bigpadding">
                            
								<div class="media">
									<div class="media-left">
									<a href="#">
									<img class="media-object icon_smallsize" src="img/svg/technology.svg" alt="...">
									</a>
									</div>
									<div class="media-body">
										<h4 class="media-heading">新闻&资讯</h4>
										<ul class="list-inline">
                                               <%=CMS.List("19", "<li><a href=\"CompanyNews.aspx?node=[链接-序号]\">[链接-标题]</a></li>","[链接-标题]=18",5,"")%>
										</ul>
								    </div>
						        </div>
                         </div>
                       </div>
            </div>
 <hr/>
            <div class="row">	
           
	            <div class="padding text-center">
	            	<h3>部分典型用户</h3>
	            	<p>  <%=CMS.NodeOutput(13,"[参数]")%></p>
	            </div>
            </div>
           
            <div class="row">

              <%=CMS.List("13", " <div class=\"col-md-2 col-sm-4 col-xs-6 cus-col\"><img src=\"[链接-图片]\" class=\"img-responsive center-block\" alt=\"[链接-标题]\"> </div>", "",16,"")%>
            
            
            </div>
              
  </div>

  <br/>
<!-- 页脚 -->
<%=CMS.Inc("Footer.aspx") %>