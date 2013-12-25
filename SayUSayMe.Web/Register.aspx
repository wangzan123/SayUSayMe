<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<%@ Register Src="~/MasterPage.master" TagName="masterPage" TagPrefix="mx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
    
<style type="text/css">
.textinput,.textinputHovered {width:236px;height:15px;background:url(image/input.gif) no-repeat left top;border:none;padding:4px 8px;}
.textinputHovered{background-position:left bottom;}
 table td{ font-size:12px;  }
.textBox{border:0px; border:1px solid #cccccc;}
.textBoxOnFocus{border:1px; background-color:#ccffff;}
.btn{margin:10px 0px 5px 120px;}
</style>

<script type="text/javascript">


</script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager1">
            <Services>
                <asp:ServiceReference Path="~/WebService.asmx" />
            </Services>
        </asp:ScriptManager>
        <table cellpadding="0" cellspacing="0" id="form" >
            <tr>
                <td><div style=" padding:0px 0px 13px 0px;">*用户名:</div></td>
                <td>
                    <asp:TextBox runat="server" ID="userName" CssClass="textinput" MaxLength="20"></asp:TextBox>
                    <div id="userNameState" style="height:20px;"></div>
                </td>
            </tr>
            <tr>
                <td><div style=" padding:0px 0px 13px 0px;">*密码:</div></td>
                <td>
                    <asp:TextBox runat="server" ID="passWord" CssClass="textinput" MaxLength="40" TextMode="Password"></asp:TextBox>
                    <div id="passwordState" style="height:20px;"></div>
                </td>
                
            </tr> 
            <tr>
                <td><div style=" padding:0px 0px 13px 0px;">*密码确认:</div></td>
                <td>
                    <asp:TextBox  runat="server" ID="passWordConfirm" CssClass="textinput" MaxLength="40" TextMode="Password"></asp:TextBox>
                    <div id="passwordState2" style="height:20px;"></div>
                </td>
            </tr>   
            <tr>
                <td><div style=" padding:0px 0px 13px 0px;">*验证码:</div></td>
                <td style="position:relative;">
                    <asp:TextBox runat="server" ID="confirmID" Width="50px" MaxLength="4" CssClass="textBox"></asp:TextBox>
                    <span style="width:40px;height:20px; cursor:pointer; position:relative; top:6px;" onclick="getCode()" id="img"></span>
                    <div id="confirmIDstate" style="height:20px;"></div>
                </td>
                
            </tr>
        </table>
        <hr style=" border:outset 1px #00ee00;"/>
        <asp:Button runat="server" ID="btnRegister" Text="注册" OnClick="btnRegisterClick" CssClass="btn" OnClientClick="return CheckForm()"/>
        <div style="font-size:20px; display:none;" id="success">
            <b style="color:Red;">恭喜</b>,注册成功!请返回登录
        </div>
    </form>
<script type="text/javascript">
/*********************************************************获取验证码*/
//新建一个xmlhttprequest
function getXmlHttpRequst()
{
    if(window.XMLHttpRequest)
    {
        return new XMLHttpRequest();
    }
    else
    {
        var MSXML=['Microsoft.XMLHTTP', 'MSXML2.XMLHTTP.5.0', 'MSXML2.XMLHTTP.4.0', 'MSXML2.XMLHTTP.3.0', 'MSXML2.XMLHTTP'];
        for(var i=0;i<MSXML.length;i++)
        {
            try{
                var xmlHttp=new ActiveXObject(MSXML[i]);
                return xmlHttp;
            }
            catch(e){} 
            
        }
    }
}

//Ajax掉用httpHandler返回验证码图片
function getCode()
{
    var xmlHttp=getXmlHttpRequst();
    xmlHttp.onreadystatechange=function(){
    
        if(xmlHttp.readyState==4)
        {
            if(xmlHttp.status==200)
            {
                var obj=document.getElementById("img");
                
                obj.innerHTML='<img src="GetConfirmID.ashx?a='+Math.random()+'" id="img" onclick="getCode()"/>';
            }
        }
    }
    //最后为标示为异步请求
    
    xmlHttp.open("GET","GetConfirmID.ashx?a="+Math .random(),true);
    xmlHttp.send(null);
}
/********************************************************************结束获取验证码*/


var objConfirmID=document.getElementById("confirmID");
//用户名
var objUserName=document.getElementById("userName");
var objUNstate=document.getElementById("userNameState");
//密码
var objPw1=document.getElementById("passWord");
var objPw2=document.getElementById("passWordConfirm");
var objPWstate=document.getElementById("passwordState");
var objPWstate2=document.getElementById("passwordState2");
//图片
var errorImg='<img src="image/error.png" />{$text}';
var rightImg='<img src="image/tick.gif" />{$text}';
//验证码
var objCode=document.getElementById("confirmIDstate");

//验证结果
objConfirmID.ready=false;
objUserName.ready=false;
objPw1.ready=false;
objPw2.ready=false;
//验证密码
/******************************************/
objPw1.onfocus=function()
{
    this.className=this.className+"Hovered";
    objPWstate.innerHTML="";
    objPw1.ready=false;
}
objPw2.onfocus=function()
{
    this.className=this.className+"Hovered";
    objPWstate2.innerHTML="";
    objPw2.ready=false;
}

objPw1.onblur=function()
{
    this.className=this.className.replace(/Hovered/g,"");
    if(this.value.length<6)
    {
        objPWstate.innerHTML=errorImg.replace(/\{\$text\}/g,"密码长度不够六位");
        objPw1.ready=false;
    }
    else
    {
        objPWstate.innerHTML=rightImg.replace(/\{\$text\}/g,"输入正确");
        objPw1.ready=true;
    }
}
objPw2.onblur=function()
{
    this.className=this.className.replace(/Hovered/g,"");
    if(this.value!=objPw1.value)
    {
        objPWstate2.innerHTML=errorImg.replace(/\{\$text\}/g,"两次输入的密码不同");
        objPw2.ready=false;
    }
    else
    {
        objPWstate2.innerHTML=rightImg.replace(/\{\$text\}/g,"输入正确");
        objPw2.ready=true;
    }
}
/******************************************/

/**************************************************/
//设置用户名
objUserName.onfocus=function()
{
    this.className=this.className+"Hovered";
    objUNstate.innerHTML="";
    objUserName.ready=false;
}
objUserName.onblur=function()
{
    this.className=this.className.replace(/Hovered/g,"");
    if(this.value.length<6)
        if(this.value.replace(/[^\x00-\xff]/g,"**").length<4)
        {
            objUNstate.innerHTML=errorImg.replace(/\{\$text\}/g,"用户名不可以少于6个字母或者两个中文字符");
            objUserName.ready=false;
            return;
        } 
    
    //当输入合法的时候就通过Ajax查询用户名是否已经被注册
    WebService.CheckUserName(this.value,onRequstComplete,onRequstError);
}
//Ajax返回
function onRequstComplete(result)
{
    if(result==1)
    {
        objUNstate.innerHTML=errorImg.replace(/\{\$text\}/g,"已被使用");
        objUserName.ready=false;
    }
    else
    {
        objUNstate.innerHTML=rightImg.replace(/\{\$text\}/g,"可以使用");
        objUserName.ready=true;
    }
}
function onRequstError(result)
{
    //不处理
}
/*****************************************************************/

/***************************************************************/
//设置验证码
objConfirmID.onfocus=function()
{
    objConfirmID.ready=false;
    objCode.innerHTML="";
    this.className="textBoxOnFocus";
    if(document.getElementById("img").innerHTML=="")
        getCode();
}
objConfirmID.onblur=function()
{
    this.className="textBox";
    
    WebService.CheckCodeNumber(this.value,onSuccess,onFailed);
}

function onSuccess(result)
{
    if(result!=1)
    {
        objCode.innerHTML=errorImg.replace(/\{\$text\}/g,"验证码错误");
        getCode();
        objConfirmID.ready=false;
    }
    else
    {
        objConfirmID.ready=true;
    }
}
function onFailed(result)
{
///
}

 function CheckForm()
 {

    if(objConfirmID.ready&&objUserName.ready&&objPw1.ready&&objPw2.ready)
        return true;
    else
    {
        alert("填写错误");
        return false;
    }
        
 } 
 
 /**************************************************************/
</script>
<asp:Literal ID="script" runat="server"></asp:Literal>
</body>
</html>
