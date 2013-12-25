<%@ Page Language="C#" AutoEventWireup="true" CodeFile="indexPage.aspx.cs" Inherits="indexPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>计算机技术论坛</title>
<style type="text/css">
#recomment{font-size:15px;}
#recommend td a{ text-decoration:none;}
#recommend td a:hover{ text-decoration:underline; color:Red;}
</style>
</head>
<body onload="BeginPageLoad()" onunload="EndPageLoad()" style=" position:relative; margin-left:auto; margin-right:auto; text-align:center; font-weight:bolder;">
    <form id="form1" runat="server">
    <div style="font-size:16px; text-align:center; margin-top:50px;">欢迎来到<i>计算机技术论坛</i>,有您的支持我们会做得更好！！</div>
    <div id="LoadingMessages" style="font-size:30px;margin-top:120px; width:500px; margin-bottom:20px;">
        <div>Page is Loading - please wait<span id="progress"></div></span>
    </div>
    <table style="border:0px; width:100%;" id="recommend">
        <tr>
            <td align="center" style="width:100%;">我们将极力像您推荐本论坛的：</td>
        </tr>
        <tr>
            <td><a style="color:#00bb00;">学习交流的：</a><a href="Article.aspx?classid=5">编程开发模块</a></td>
        </tr> 
        <tr>
            <td><a style="color:#00bb00;">学习交流的：</a><a href="Article.aspx?classid=8">网站建设模块</a></td>
        </tr> 
        <tr>
            <td><a style="color:#00bb00;">城市生活的：</a><a href="Article.aspx?classid=15">跳骚市场模块</a></td>
        </tr>    
    </table>
    <div id="foot" style=" font-size:12px; position:relative; margin-top:200px;font-weight:normal; white-space:normal;">
        <b style="color:Red;">注意：</b>本网站暂时只兼容<b style="color:Red;">IE浏览器</b>，在火狐下还有一些功能无法正常使用，所以我们推荐你用IE浏览器打开，<b style="color:Red;">我们正在努力做得更好</b>！！
    </div>
    </form>
<script type="text/javascript">
var counter=1;
var maxCount=8;
//计时对象
var interval;
function BeginPageLoad()
{
    location="<%=TargetPage %>";
    //隔一段时间更新一次进度条
    interval=window.setInterval("counter=UpdateProgress(counter,maxCount);",300);
}
function UpdateProgress(nowCount,nowMaxCount)
{
    var progressObj=document.getElementById("progress");
    nowCount+=1;
    if(nowCount<=nowMaxCount)
    {
        progressObj.innerText+=".";
        return nowCount;
    }
    else
    {
        progressObj.innerText="";
        return 1;
    }
    
}
function EndPageLoad()
{
    window.clearInterval(interval);
}
</script>
</body>
</html>
