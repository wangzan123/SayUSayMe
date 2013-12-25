<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserControl.aspx.cs" Inherits="UserControl" Title="个人中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" href="App_Themes/mainTheme/userControl.css" rel="Stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="userAllPage">
    <div id="userHead">
        <a href="UserControlIndex.aspx" target="userControlFram">控制面板首页</a>
        <a href="EditUserDetails.aspx" target="userControlFram">编辑个人资料</a>
        <a href="WebData.aspx" target="userControlFram">查看历史文章</a>
        <a href="ApplyDataPage.aspx" target="userControlFram">查看申请信息</a>
    </div>
    <div style="clear:both; height:0px; width:0px;"></div>
    <iframe id="userControlFram" name="userControlFram"  frameborder="0" scrolling="no" src="UserControlIndex.aspx" style="width:100%;padding:0px; height:95%" onload="SetCwinHeight()"></iframe>
</div>


    
<script type="text/javascript">
//iframe自适应高度
function SetCwinHeight()
{
var cwin=document.getElementById("userControlFram");

        if (document.getElementById)
        {    
            if (cwin && !window.opera)
            {      
                if (cwin.contentDocument && cwin.contentDocument.body.offsetHeight)
                {
                    
                    cwin.height = cwin.contentDocument.body.offsetHeight+10;//offsetHeight返回元素可见的高度
                    document.getElementById('userAllPage').style.height=cwin.contentDocument.body.offsetHeight+100;
                }
                else if(cwin.Document && cwin.Document.body.scrollHeight)
                {   
                    
                    cwin.height = cwin.Document.body.scrollHeight+10;//scrollHeight返回元素的完整的高度
                    document.getElementById('userAllPage').style.height=cwin.Document.body.scrollHeight+100;
                }
            }
        }
}

</script>
</asp:Content>



