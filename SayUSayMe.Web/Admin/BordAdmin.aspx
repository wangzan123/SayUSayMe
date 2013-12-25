<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="BordAdmin.aspx.cs" Inherits="Admin_BordAdmin" Title="无标题页" %>

<%@ Register Src="~/Admin/UserControl/ShowArticle.ascx" TagName="ShowArticle" TagPrefix="Article" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="adminPage">
    <div id="left">
        <div id="leftTitle">系统功能</div>
        <div id="navigator">
            <div><img src="image/add_1.gif" /><a href="UpdateClassData.aspx" target="userControlFram">修改子板块</a></div>   
            <div class="parentNavigator"><img src="image/folder.gif"/><a href="CheckArticle.aspx" target="userControlFram">文章管理</a></div>
        </div>
    </div>
    <div id="contentPage">
        
        <div id="contentTitle"></div>
        <div id="content">
        <iframe id="userControlFram" name="userControlFram"  frameborder="0" scrolling="auto" src="Welcome.htm" style=" width:100%; min-height:500px; padding:0px;"></iframe>
       <%--     <div id="adminOperateBtn">
        <a href="BordAdmin.aspx?type=new">查看未处理的文章</a>
        <a href="BordAdmin.aspx?type=history">查看已处理的文章</a>
        <a href="BordAdmin.aspx?type=delete">查看已删除文章</a>--%>
    </div>
    <asp:PlaceHolder runat="server" ID="newArticle">
        <Article:ShowArticle ID="ShowArticle1" runat="server" />
    </asp:PlaceHolder>
         
        </div>
    </div>
<script type="text/javascript">
    var ss='<%=Session["role"]%>';
    if(!ss){
        alert("你没有登陆或者超时!");
        var ifram=document.getElementById("userControlFram");
        ifram.src="../Login.aspx";
    }
</script>

</asp:Content>

