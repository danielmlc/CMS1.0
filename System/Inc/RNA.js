// JavaScript Document
String.prototype.trimStart = function (trimStr) {
    if (!trimStr) { return this; }
    var temp = this;
    while (true) {
        if (temp.substr(0, trimStr.length) != trimStr) {
            break;
        }
        temp = temp.substr(trimStr.length);
    }
    return temp;
};
String.prototype.trimEnd = function (trimStr) {
    if (!trimStr) { return this; }
    var temp = this;
    while (true) {
        if (temp.substr(temp.length - trimStr.length, trimStr.length) != trimStr) {
            break;
        }
        temp = temp.substr(0, temp.length - trimStr.length);
    }
    return temp;
};
String.prototype.trim = function (trimStr) {
    var temp = trimStr;
    if (!trimStr) { temp = " "; }
    return this.trimStart(temp).trimEnd(temp);
};
function c_all(){
	$(".checkbox").attr("checked",$("#C_all").attr("checked"));
}
function del(id){
	if (confirm("确定要删除么？")){
	    document.forms["form1"].action = "?act=del&id=" + id;
		document.forms["form1"].submit();
	}
}
function del(id,tid) {
    if (confirm("确定要删除么？")) {
        document.forms["form1"].action = "?act=del&id=" + id + "&tid=" + tid;
        document.forms["form1"].submit();
    }
}
function delall(){
	if (confirm("确定要删除已选择项目么？")){
	    document.forms["form1"].action = "?act=delall"; 
        
		document.forms["form1"].submit();
	}
}
function sel(tid) {
    document.forms["form1"].action = "?act=sel&tid=" + tid;
   
        document.forms["form1"].submit();
}
function pub(id){
	if (confirm("确定要通过审核么？")){
	    document.forms["form1"].action = "?act=pub&id=" + id;
		document.forms["form1"].submit();
	}
}
function unpub(id){
	if (confirm("确定要撤销审核么？")){
	    document.forms["form1"].action = "?act=unpub&id=" + id;
		document.forms["form1"].submit();
	}
}
function xls() {
    if (confirm("确定要导出Excel么？")) {
        document.forms["form1"].action = "?act=xls&id=" + id;
        document.forms["form1"].submit();
    }
}
function preview(info_id) {
	window.location.href = "Preview.aspx?id="+info_id;
}

function active(obj,id){
    if ($(obj).children(":first").attr("alt") == "未发布"){
        $.ajax({ 
            type: "POST", 
            url: "Default.aspx", 
            data: "act=active&id="+id, 
            success: function(msg){ 
                $(obj).children(":first").attr("alt","已发布");
                $(obj).children(":first").attr("src","../../images/active_1.gif");
            } 
        });
    }else{
        $.ajax({ 
            type: "POST", 
            url: "Default.aspx", 
            data: "act=deactive&id="+id,
            success: function(msg){ 
                $(obj).children(":first").attr("alt","未发布");
                $(obj).children(":first").attr("src","../../images/active_0.gif");
            } 
        });
    }
}

function active1(obj,id){
    if ($(obj).children(":first").attr("alt") == "未启用"){
        $.ajax({
            type: "POST", 
            url: "Default.aspx", 
            data: "act=active&id="+id, 
            success: function(msg){ 
                $(obj).children(":first").attr("alt","已启用");
                $(obj).children(":first").attr("src","../../images/active_1.gif");
            } 
        });
    }else{
        $.ajax({ 
            type: "POST", 
            url: "Default.aspx", 
            data: "act=deactive&id="+id, 
            success: function(msg){ 
                $(obj).children(":first").attr("alt","未启用");
                $(obj).children(":first").attr("src","../../images/active_0.gif");
            } 
        });
    }
}

function upload(id,url) {
        new AjaxUpload(id + "_bt", {
            action:url,
            onSubmit: function (file, ext) {
                if (ext && /^(jpg|png|jpeg|gif|zip|rar|pdf|doc|docx|mp3|wmv|xls|avi|ogg)$/.test(ext)) {
                } else {
                    alert("只能上传jpg|png|jpeg|gif|zip|rar|pdf|doc|docx|mp3|wmv|xls|avi|ogg格式的文件！");
                    return false;
                }
            },
            onComplete: function (file, json) {
                if (json.msg != "") {
                    if ($(id + "_select").html() == null) {
                        $(id).attr("value", json.msg);
                    } else {
                        $(id + "_select").append("<option value=\"" + json.msg + "\">" + json.msg + "</option>");
                        $(id + "_select").val(json.msg);
                        try {
                            end(json.msg);
                        } catch (e) { }
                    }
                } else {
                    alert(json.err);
                }
            }
        });
}

function xheditor(id) {
    $(id).xheditor({
        upLinkUrl: "../upload/upload.aspx",
        upLinkExt: "zip,rar,txt,ceb",
        upImgUrl: "../upload/upload.aspx",
        upImgExt: "jpg,jpeg,gif,png",
        upFlashUrl: "../upload/upload.aspx",
        upFlashExt: "swf",
        upMediaUrl: "../upload/upload.aspx",
        upMediaExt: "avi,mp3"
    });
}