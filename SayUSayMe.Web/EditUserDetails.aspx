<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditUserDetails.aspx.cs" Inherits="EditUserDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style type="text/css">
*{margin:0px; padding:0px;}
body{margin:5px;}
#editDetails{margin:0px; width:100%; font-size:15px;}
#editDetails .title
{
	/*background-image: url(image/head.gif);*/
	font-size: 13px;
	font-weight: bolder;
	background-position: left top;
	background-repeat: repeat-x;
	padding: 5px 0px 5px 30px;
	width: 100%;
	background-color: #494949;
	color: white;
}
#editDetails #baseDetails{ width:100%;min-height:200px;}
#editDetails #others{width:100%;min-height:200px;}
#editDetails .textBox{border:1px solid black;}
#editDetails .textBoxFocus{border:1px solid green;}
#editDetails table{background-color: #FFFFFF;
	padding: 20px;
	line-height: 50px;}
#editDetails #baseDetailsContent, #othersContent
{
	margin: 2px auto;
	background-color:white;
	min-height: 170px;
	padding: 10px 0px 0px 30px;
	border: 1px solid #FFFFFF;
	color: #494949;
}

 .saveHypeLink{background-color:#494949;color: white ;  padding:8px 30px; background-repeat:no-repeat; text-align:center; text-decoration:none;}


 /*设置所有输入框的默认样式*/
.inputCss {   
    width:320px;
    height: 18px;
}
 /*设置所有输入框鼠标点击的时候的样式*/
.inputCss:focus{
 transition:border linear .2s,box-shadow linear .5s;
 -moz-transition:border linear .2s,-moz-box-shadow linear .5s;
 -webkit-transition:border linear .2s,-webkit-box-shadow linear .5s;
 outline:none;border-color:rgba(39,147,230,.75);
 box-shadow:0 0 8px rgba(39,147,220,.5);
 -moz-box-shadow:0 0 8px rgba(39,147,220,.5);
 -webkit-box-shadow:0 0 5px rgba(39,147,220,3);
   
    width:320px;
    height: 20px;
}

input[type=text]:focus, input[type=password]:focus, textarea:focus {
    transition: border linear .2s,box-shadow linear .5s;
    -moz-transition: border linear .2s,-moz-box-shadow linear .5s;
    -webkit-transition: border linear .2s,-webkit-box-shadow linear .5s;
    outline: none;
    border-color: rgba(39,147,230,.75);
    box-shadow: 0 0 8px rgba(39,147,220,.5);
    -moz-box-shadow: 0 0 8px rgba(39,147,220,.5);
    -webkit-box-shadow: 0 0 8px rgba(39,147,220,3);
   
    width:320px;
    height: 20px;
}
</style>
</head>
<body style="background-color: #ffffff">
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server">
        <Services>
            <asp:ServiceReference Path="~/WebService.asmx" />
        </Services>
    </asp:ScriptManager>
    <div id="editDetails">
        <div id="baseDetails">
            <div class="title" style="height: 30px;font-family:幼圆;font-size: 20px;" >基本资料</div>
            <div id="baseDetailsContent">
                <table>
                    <tr>
                        <td><label id="userName">注册用户名：</label></td>
                        <td><label style="padding:2px 30px;border:1px solid #ff0000;"><%#GetDetails("userName")%></label></td>
                    </tr>  
                    <tr>
                        <td><label for="userShowName">论坛使用名：</label></td>
                        <td><input type="text" class="inputCss" onfocus="textBoxFocus(this)" id="userShowName" onblur="textBoxBlur(this)" value="<%# GetDetails("userShowName") %>" /></td>
                    </tr>    
                    <tr>
                        <td><label id="sex">性别：</label></td>
                        <td><input type="radio" name="sexRadio" checked="checked" id="boy"/>男<input type="radio" name="sexRadio" id="girl"/>女</td>
                    </tr>       
                </table>
            </div>
        </div>
        <div id="others">
            <div class="title" style="height: 30px;font-family:inherit;font-size: 20px;">其他资料( 填写更多资料可以让人更了解你,我们不会公开您的私人资料)</div>
            <div id="othersContent">
                <table>
                    <tr>
                        <td><label for="usermajor">职业：</label></td>
                        <td><input id="userMajor" class="inputCss" type="text" onfocus="textBoxFocus(this)" onblur="textBoxBlur(this)" value="<%# GetDetails("userMajor") %>"/></td>
                    </tr>
                    <tr>
                        <td><label for="userAddress">地址：</label></td>
                        <td><input id="userAddress" class="inputCss" type="text" onfocus="textBoxFocus(this)"  onblur="textBoxBlur(this)" value="<%# GetDetails("userAddress") %>"/></td>
                    </tr>
                    <tr>
                        <td><label for="userMaxim">格言：</label></td>
                        <td><input id="userMaxim" class="inputCss" type="text" onfocus="textBoxFocus(this)" onblur="textBoxBlur(this)" value="<%#GetDetails("userMaxim") %>" /></td>
                    </tr>
                    <tr>
                        <td><label for="userMoblie">手机号码：</label></td>
                        <td><input id="userMoblie" class="inputCss" type="text" onfocus="textBoxFocus(this)" onblur="textBoxBlur(this)" value="<%#GetDetails("userMoblie") %>"/></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center"><input type="button"  onclick="submitHypeLink();return false;" class="saveHypeLink"  value="保存"></input></td>
                    </tr>
                </table> 
            </div>
        </div>
    </div>
    <asp:Literal ID="script" runat="server"></asp:Literal>
    </form>
<script type="text/javascript">
//获得焦点的样式
function textBoxFocus(element)
{   
    element.className=element.className+"Focus";

    element.oldValue=element.value;

}
//失去焦点样式
function textBoxBlur(element)
{
     element.className=element.className.replace(/Focus/g,"");
     element.newValue=element.value;
     if(element.newValue!=element.oldValue)
        element.changed=true;
}
function submitHypeLink()
{
    var postDate="";
    var form=document.forms["form1"];
    var element;
    for(var i=0;i<form.elements.length;i++)
    {
        element=form.elements[i];
        if(element.type=="text"&&element.changed)
        {
            postDate+=element.id+"="+element.value+"&";
            
        }
        if(element.type=="radio"&&element.checked)
        {
            postDate+=element.id+"="+element.value+"&";
        }
    }
    WebService.UpdateUserDetails(postDate,onSuccessSave,onError);
    function onSuccessSave(result)
    {
        if (result == 1) {
            alert("保存成功");
            window.location('Default.aspx');
        }
         
        else
            alert("保存失败");
    }
    function onError(result)
    {   
        
        result.get_message();
    }
}
</script>
</body>
</html>
