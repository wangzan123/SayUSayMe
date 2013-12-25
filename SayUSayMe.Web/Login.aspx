<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
<style type="text/css">
.textinput,.textinputHovered {width:236px;height:15px;background:url(image/input.gif) no-repeat left top;border:none;padding:4px 8px;}
.textinputHovered{background-position:left bottom;}
table td{ font-size:12px;  }
.textBox{border:0px; border:1px solid #cccccc;}
.textBoxOnFocus
{
	border: 1px;
	background-color: #000000;
}
.btn{margin:10px 0px 5px 120px;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1">
        <Services>
            <asp:ServiceReference Path="~/WebService.asmx" />
        </Services>
    </asp:ScriptManager>
    <div>
        <table cellpadding="0" cellspacing="0" id="form" >
                <tr>
                    <td><div style=" padding:0px 0px 13px 0px;">用户名:</div></td>
                    <td>
                        <asp:TextBox runat="server" ID="userName" CssClass="textinput" MaxLength="20"></asp:TextBox>*
                        <div id="userNameState" style="height:20px;"></div>
                    </td>
                </tr>
                <tr>
                    <td><div style=" padding:0px 0px 13px 0px;">密码:</div></td>
                    <td>
                        <asp:TextBox runat="server" ID="passWord" CssClass="textinput" MaxLength="40" TextMode="Password"></asp:TextBox>*
                        <div id="passwordState" style="height:20px;"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <a href="javascript:" onclick="login()" ><img src="image/submit1.gif" style="border:0px;"  alt="登陆"/></a> 
                        <div id="allstate" style="height:20px;"></div>
                    </td>
                </tr>
         </table>
         <div style="font-size:20px; display:none; text-align:center;" id="success">
            <b style="color:Red; ">恭喜</b><p/><p/>登陆成功!
        </div>
    </div>
    </form>
<script type="text/javascript">
//图片
var errorImg='<img src="image/error.png" />{$text}';
var rightImg='<img src="image/tick.gif" />{$text}';

var objName=document.getElementById("userName");
var objNameState=document.getElementById("userNameState");
var objPW=document.getElementById("passWord");
var objPWstate=document.getElementById("passwordState");
var objAllstate=document.getElementById("allstate");

//获得焦点
objName.onfocus=function()
{
    objNameState.innerHTML="";
}
objPW.onfocus=function()
{
    objPWstate.innerHTML="";
}
document.body.onkeypress=function(e)
{
    if(!e)e=window.event;    
    if(e.keyCode == 13)//keycode   13 = Enter
       login();
}

//登陆函数
function login()
{
    if(objName.value=="")
    {
        objNameState.innerHTML=errorImg.replace(/{\$text\}/g,"用户名不能为空");
        return false;
    }  
    else if(objPW.value=="")
    {
        objPWstate.innerHTML=errorImg.replace(/{\$text\}/g,"密码不能为空");
        return false;
    }
//   
    WebService.Login(objName.value,objPW.value,onSuccess,onFailed);
}
//登陆成功
function onSuccess(result)
{
     
    if(result==1||result==0)
    {
        document.getElementById('form').style.display='none';
        document.getElementById('success').style.display='';
   

    }
    else if(result==-1)
         alert("对不起，你的用户已经被停用");
    else if(result==-2)
    {
        objAllstate.innerHTML=errorImg.replace(/{\$text\}/g,"登陆失败,密码或用户名错误");
    }

}   
function onFailed(result)
{
    alert(result.get_message());
   
}
</script>
</body>
</html>
