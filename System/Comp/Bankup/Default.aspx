<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="System_Comp_Bankup_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>数据备份管理</title>
<script type="text/javascript" src="../../Inc/jquery.js"></script>
<script type="text/javascript" src="../../Inc/rna.js"></script>
<link href="../../css/comp.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="pagetit">&gt; 数据备份管理（只针对Access）</div>
        <div id="table"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FAFAFA">
          <tr>
            <td height="26" id="actbar">
              <input class="button" type="button" onclick="window.location.href='../../Main.aspx'" value=" 返回 " />
              <input class="button" type="button" onclick="window.location.href='?act=bak'" value=" 立即备份 " />
            </td>
          </tr>
          <tr>
            <td><table id="unit1" width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><table width="100%" border="1" align="center" cellpadding="0" cellspacing="0" class="table">
                      <tr>
                        <td width="50" class="title"><div class="center">
                            <input type="checkbox" id="C_all" name="C_all" value="" onclick="c_all()" />
                        </div></td>
                        <td width="50"class="title"><div class="center">序号</div></td>
                        <td class="title"><div class="center">备份名</div></td>
                        <td class="title"><div class="center">文件大小</div></td>
                        <td class="title"><div class="center">最后更改</div></td>
                        <td width="60" class="title"><div class="center">操作</div></td>
                      </tr>
                      <%
                          
                          for (int i = 0; i < files.Length; i++)
                          {
                              if (files[i].EndsWith(".bak"))
                              {
                                  System.IO.FileInfo info = new System.IO.FileInfo(files[i]);
                                  
                      %>
                      <tr>
                        <td><div class="center"><input type="checkbox" class="checkbox" name="C_Mark" value="<%=info.Name%>" /></div></td>
                        <td><div class="center"><%=i+1%></div></td>
                        <td><div class="center"><%=info.Name%></div></td>
                        <td><div class="center"><%=(info.Length / 1024.0 / 1024.0)%> MB</div></td>
                        <td><div class="center"><%=info.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss")%></div></td>
                        <td><div class="center">
                          <a href="#" onclick="del('<%=info.Name%>')">删除</a>
                        </div></td>
                      </tr>
					  <%
                              }
                          } 
					  %>
                    </table></td>
                </tr>
              </table></td>
          </tr>
        </table></div>
    </div>
    </form>
</body>
</html>