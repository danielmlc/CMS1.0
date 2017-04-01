<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="System_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站后台登陆</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../ModelFunctions/Login/css/main.css" rel="stylesheet" type="text/css" />
    <script src="../ModelFunctions/Login/js/fun.base.js" type="text/javascript"></script>
    <script src="../ModelFunctions/CommJs/jquery.js" type="text/javascript"></script>
    <link href="../ModelFunctions/Dialog/animate.min.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function tshowcode() {
        document.getElementById('imgcode').src = '../VerifyCode.aspx?_' + Date();
    }
    $(document).ready(function () {
        document.getElementById('imgcode').src = '../VerifyCode.aspx?_' + Date();
    });
   
    </script>
   
</head>
<body  style=" background-color:#0076A3">
  <form id="form1" runat="server">
<!--focus start-->

<div class="login">
    <div class="box png">
		<div class="logo png"></div>
		<div class="input">
			<div class="log">
				<div class="name">
					<label>用户名</label><input type="text" class="text" id="username" placeholder="用户名" name="username" tabindex="1"/>
				</div>
                <div class="pwd">
					<label>密&nbsp;&nbsp;&nbsp;码</label><input type="password" class="text" id="password" placeholder="密&nbsp;&nbsp码"  name="password" tabindex="2"/>
				</div>
				<div class="code">
                    <label>验证码</label><input type="text" class="text" id="code" placeholder="验证码" name="code"  size="4" maxlength="4"  tabindex="3" style=" width:90px;"/>
                       <span id="spancode" onclick="tshowcode()" title="看不清，点击更换验证码" style="top:4px; position:relative;cursor:pointer; margin-left:10px;"><img id="imgcode" src="" border="0" /></span>
				    	<input type="button" class="submit" tabindex="3" name="button" id="submit_cnzz" value=" 登录系统 " />
				</div>
				
			</div>
		</div>
	</div>
    <div class="footer"></div>
</div>
    </form>
    <script src="../ModelFunctions/Dialog/jquery.hDialog.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#submit_cnzz").click(function () {


            var username = $("#username").val();
            var password = $("#password").val();
            var code = $("#code").val();
            if (username == "" || password == "") {
                $.tooltip('用户名和密码不能为空！！！');
                return false;
            }
            if (code == "") {
                $.tooltip('验证码不能为空！！！');
                return false;
            }
            $("#submit_cnzz").val("登录中...");
            $.ajax({
                url: "login.ashx",
                async: false,
                data: { User: username, Pass: password, Code: code },
                type: "POST",
                success: function (data) {
                    var result = eval("(" + data + ")");
                    var JG = result.data;
                    if (JG == "-4") {
                        $.tooltip('该用户不是网站管理员！！！');
                        $("#submit_cnzz").val("登录系统");
                    }
                    else if (JG == "-3") {
                        $.tooltip('该用户未开通使用权限！！！');
                        $("#submit_cnzz").val("登录系统");
                    }
                    else if (JG == "-2") {
                        //                          
                        $.tooltip('该用户不存在！！！');
                        $("#submit_cnzz").val("登录系统");
                    }
                    else if (JG == "-1") {
                        $.tooltip('密码输入有误！！！');
                        $("#submit_cnzz").val("登录系统");
                    }
                    else if (JG == "0") {
                        //                          
                        $.tooltip('验证码输入有误！！！');
                        $("#submit_cnzz").val("登录系统");

                    }
                    else if (JG == "1") {
                        //                        $.tooltip('登陆成功！！！');
                        $.tooltip('登录成功,跳转中...', 2500, true);
                        window.location.href = "Frame.aspx";
                    }
                    else { $.tooltip('无法登录！！！'); $("#submit_cnzz").val("登录系统"); }
                }
            });

        });
           

    </script>
</body>
</html>
