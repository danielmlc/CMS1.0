<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="System_Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>我的站点</title>
<script type="text/javascript" src="Inc/jquery.js"></script>
<script type="text/javascript" src="Inc/rna.js"></script>
<link href="css/comp.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .blank
    {
        line-height:50px;
	    font-size:20px;
	    font-family:微软雅黑,黑体;
	    padding-left:10px;
	    color:Gray;
	    margin:20px;
	    border-bottom:4px solid Gray;
	    background-color:#FFF;
    }
    .block
    {
        line-height:50px;
	   
	    padding-left:10px;
	   
	    margin:20px;
	    border-left:10px solid #0076A3;
	    border-bottom:4px solid #0076A3;
	    background-color:#FFF;
	    cursor:pointer;
    }
  
    .block:hover
    {
        background-color:#F0F0F0;
    }
     .block a
     { font-size:20px;
	   font-family:微软雅黑,黑体;
	   color:#0076A3;
	   text-decoration:none;
     }
</style>
</head>
<body>
    <form name="form1">
    <div>
        <div id="pagetit">&gt; 我的站点</div>
        <div id="table"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FAFAFA">
          <tr>
            <td height="26" id="actbar">请选择管理的栏目&nbsp;</td>
          </tr>
          <tr>
            <td><table id="unit1" width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><table width="100%" border="1" align="center" cellpadding="0" cellspacing="0" class="table">
                 <tr>
                  <td><%Show(0);%></td>
                </tr>
                </table></td>
                </tr>
             </table></td>
          </tr>
        </table></div>
    </div>
    </form>
</body>
</html>

