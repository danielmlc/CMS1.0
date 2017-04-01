<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<head>
	<meta charset="UTF-8" />
	<title>西安易龙软件有限公司</title>
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <link rel="stylesheet" type="text/css" href="plugins/bootstrap/css/ly_style.css" />
    <link rel="stylesheet" type="text/css" href="css/custom_style.css" />
    <link rel="shortcut icon" href="img/favicon.ico" /> 
</head>
<body>
    
<div class="container-fluid cus-container-fluid header">
		  <nav class="navbar navbar-inverse cus-navbar navbar-fixed-top">
							<div class="container">
							<div class="navbar-header">
							<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-2">
							<span class="sr-only">Toggle navigation</span>
							<span class="icon-bar"></span>
							<span class="icon-bar"></span>
							<span class="icon-bar"></span>
							</button>
							<a class="navbar-brand clear_padding" href="Index.aspx"><img src="img/logo.png" height="55" alt="logo" class="responsive "></a>
							</div>
							<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-2">
							
                                  <%=CMS.List("16", "[正文]", "",1,"")%>

								<%--<form class="navbar-form  navbar-right" role="search">
									<div class="form-group">
									<input type="text" class="form-control" placeholder="搜索">
									</div>
									<button type="submit" class="btn btn-primary">
									        <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
									</button>
								</form>--%>

							
							</div>
							</div>
							</nav>
</div>

<div class="replace"></div>
