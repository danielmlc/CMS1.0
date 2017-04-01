// JavaScript Document
var keylis = new Array("贸易","制裁","改造","中国","经济","中国经济","拯救","美国","美国经济","整顿","银行业","银行","速度","温家宝","美中","逆差","贸易逆差","结构性","转移性","机电","进出口","商会","彩电","倾销","税率","交涉","东北","亚洲","亚洲经济","论坛","增长","失业率","失业","回落","批评","限制","纺织品","进口","加拿大","统计","移民","收入","差异","中央银行","中央","商业银行","政策","措施","经济发展","发展","日本","日本经济","复苏","决定","锻铸","铁管","管件","征收","反倾销","垄断","倾销税","联合国","联合","实施","伊拉克","石油","食品","计划","发展中国家","发达国家","国家","家电","电信","产业","电子","信息","产销","俄罗斯","检察官","检察","首富","犯罪","调查","结束","欧盟","争端","投资","受挫","改革","委员会","委员","实行","临时","价格","干预","施行","美联储","警告","通货膨胀","膨胀","下滑","衰退","季度","扬言","演示简单","后台");
var keydrop="";
function delHtmlTag(str) 
{ 
	return str.replace(/<[^>]+>/g,"");//去掉所有的html标记 
}
function lastIndexDemo(a)
{
	var str = delHtmlTag(document.getElementById("keywords").value);//获取字符串
	var keys = new Array;//词表存储序列
	var titles = new Array;
	var key = new Array;//关键词对象存储序列
	var gotkey = new Array();//关键词对象
	var name = new Array();//关键词name
	var address = new Array();//关键词在词表中位置
	var times = new Array();//关键词在本篇目中的出现次数
	var tfx = new Array();//关键词tfx值
	var stopkey = new Array();//关键词是否为停用词
	var desc = new Array();//关键词排名
	var strkey;// 声明变量预存关键字
	var strl = str.length;//获取字符串长度
	getkeywords(keys,titles);//初始化关键词表和标题序列
	getkey(str,strkey,strl,keys,key,name,address,stopkey);//获取关键词，词表位置，是否停用
	timesn(times,address);//获取n（出现多少次）
	gettfx(times,tfx);
	toobject(key,address,times,tfx,stopkey,name);
	outresult(key,address,times,tfx,stopkey,name,str);				   
}
function getkeywords(keys,titles){
	var titl = 1;
	var keyl = keylis.length;
	var keyd = keydrop.length;
	for(i=0;i<keyl;i++){
		keys[i] = keylis[i];
	}
	for(i=0;i<keyd;i++){
		keys[i+keyl] = keydrop[i].childNodes[0].nodeValue;
	}
	for(i=0;i<titl;i++){
		titles[i] = document.getElementById("keywords").value;
	}
}
function timesn(times,address){
	var k = 0;
	for(i=0;i<address.length;i++){
		for(j=0;j<address.length;j++){	
			if(address[i] == address[j]){
				k = k+1;
			}
		}
		times.push(k);
		k = 0;
	}
}
function gettfx(times,tfx){
	var k = Math.log(10);
	var l;
	var j;
	var m;
	var n;
	for(i=0;i<times.length;i++){
		l = times[i]/1;
		j = Math.log(l);
		n = times[i]*j;
		tfx.push(n.toFixed(3));
	}
}
function toobject(key,address,times,tfx,stopkey,name){
	var gotdkey = new Array;
	key["name"] = name;
	key["address"] = address;
	key["tfx"] = tfx;
	key["stopkey"] = stopkey;
	key["times"] = times;
	
}
function getkey(str,strkey,strl,keys,key,name,address,stopkey){
	for(k=strl;k>0;k--){//控制循环次数
	
		   label:
		   for(j=6;j>0;j--)//通过最大关键字长度控制循环
				{
					var strkey = str.substr(k-j, j);
					
					//确定预检索字符串 strl-j 是位置 j是长度
					for(i=0;i<keys.length;i++)//通过关键字字库的数量确定循环次数
					{
						if(keys[i]==strkey){//如果现有关键字与字库匹配
							name.push(strkey);
							address.push(i);
							if(i>keylis.length){
							stopkey.push(false);
							}
							else{
							stopkey.push(true);
							}
							k-=j;
							k++;
							break label;
						}
						
					}
				}	
		}
}
function outresult(key,address,times,tfx,stopkey,name,str){
	var outtit = document.getElementById("outtit");
	var outkey = document.getElementById("outkey");
	var outtfx = document.getElementById("outtfx");
	var outstop = document.getElementById("outstop");
	var outval = document.getElementById("outval");
	var outword = document.getElementById("outword");
	var outdeep = document.getElementById("outdeep");
	var outkeyword = document.getElementById("outkeyword");
	var outtags = document.getElementById("tags");
	var indesc = document.getElementById("indesc").value;
	var intfx = document.getElementById("intfx").value;
	var outkeyarray = new Array();
	var outkeyarray1 = new Array();
	var outkeystoparray = new Array();
	var outwordarray = new Array();
	var outtfxarray = new Array();
	var outtfxarray1 = new Array();	
	outtit.firstChild.nodeValue = str;
	
	for(i=0;i<name.length;i++)
	{
		
		if(key["stopkey"][i] == true)
		{outkeyarray.push(key["name"][i]);
		 outtfxarray.push(key["tfx"][i]);}
		 
	}
	for(i=0;i<outkeyarray.length;i++)
	{
		for(j=outkeyarray.length;j>i;j--)
		{
			if(outkeyarray[i] == outkeyarray[j])
			{
				outkeyarray = outkeyarray.slice(0,j).concat(outkeyarray.slice(j+1,outkeyarray.length));
				outtfxarray = outtfxarray.slice(0,j).concat(outtfxarray.slice(j+1,outtfxarray.length));
			}
		}
	}
	
	outkey.firstChild.nodeValue = outkeyarray.join(",");
	outtfx.firstChild.nodeValue = outtfxarray.join(",");
	//
	for(i=0;i<name.length;i++)
	{
		if(key["stopkey"][i] == false)
		{outkeystoparray.push(key["name"][i]);}
	}
	outstop.firstChild.nodeValue = outkeystoparray.join(",");
	//
	
	outval.firstChild.nodeValue = intfx;
	//
	for(i=0;i<outkeyarray.length;i++)
	{
		
		if(outtfxarray[i]>intfx)
		{outwordarray.push(outkeyarray[i]);
		 outtfxarray1.push(outtfxarray[i])}
	}
	outword.firstChild.nodeValue = outwordarray.join(",");
	outdeep.firstChild.nodeValue = indesc;
	for(i=0;i<outwordarray.length;i++)
	{ var k,l;
		for(j=i+1;j<outwordarray.length;j++)
		{
			if(outtfxarray1[i]<outtfxarray1[j])
			{
				k=outtfxarray1[i];outtfxarray1[i]=outtfxarray1[j];outtfxarray1[j]=k;
				l=outwordarray[i];outwordarray[i]=outwordarray[j];outwordarray[j]=l;
			}
		}
	
	}
	outwordarray = outwordarray.slice(0,indesc)
	outkeyword.firstChild.nodeValue = outwordarray.join(",");
	outtags.value = outwordarray.join(",");
}