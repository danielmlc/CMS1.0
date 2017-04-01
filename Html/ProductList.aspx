
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
              <%=CMS.List("18", " <div class=\"item [链接-链接]\"><img src=\"[链接-图片]\" ><div class=\"carousel-caption\"> <h3>[链接-标题]</h3><p>[链接-描述]</p> </div> </div>", "",4,"")%>
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

  </div>
 <br/>
<div class="container">
        <br/>
			<div class="table-responsive">
                <table class="table  table-hover table-bordered">
                    <tr>
                        <th>系统预览图</th>
                        <th>产品名称</th>
                        <th>演示地址</th>
                        <th>产品经理</th>
                        <th>详细了解</th>
                    </tr>
                     <%=CMS.List("17",false, "  <tr><td><img src=\"[短文本六]\" class=\"img-responsive\" alt=\"Responsive image\"></td><td>[短文本一]</td><td> <p>演示地址：<a href=\"[短文本三]\">进入演示地址</a></p> <p>账号信息：[短文本四]</p> </td><td> <p>联系人：[短文本二] </p><p>联系电话:[短文本五]</p> </td><td> <a type=\"button\" class=\"btn btn-primary \" href=\"Product.aspx?node=[序号]\"><span class=\"glyphicon glyphicon-star\" aria-hidden=\"true\"></span> 了解产品</a> </td></tr>", "", "", "",5,"")%>
      
                </table>
			</div>
			
	</div>
    <br/>
<!-- 页脚 -->
<%=CMS.Inc("Footer.aspx") %>