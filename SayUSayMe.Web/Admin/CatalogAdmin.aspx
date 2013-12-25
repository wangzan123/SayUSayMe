<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="CatalogAdmin.aspx.cs" Inherits="Admin_CatalogAdmin" Title="版主管理" %>

<%@ Register Src="~/Admin/UserControl/AddClass.ascx" TagName="AddClass" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="adminPage">
    <div id="left">
        <div id="leftTitle">系统功能</div>
        <div id="navigator">
            <div class="parentNavigator"><img src="image/add_1.gif" id="operateID" onclick="closeChildOperate('operateID','classManager')" /><a href="javascript:" onclick="showChildOperate('operateID','classManager')">板块信息管理</a></div>
            <div class="childNavigator" id="classManager" style="display:none;">
                
                <div><img src="image/add_1.gif" id="img2" onclick="closeChildOperate('img2','child2')"/><a href="UpdateCatalogData.aspx" target="userControlFram" onclick="showChildOperate('img2','child2')">修改板块</a></div> 
                <div class="childNavigator" id="child2" style=" display:none;">
                    <div><img src="image/add_1.gif" /><a href="AddClass.aspx" target="userControlFram">添加子板块</a></div>
                    <div><img src="image/add_1.gif" /><a href="UpdateClassData.aspx" target="userControlFram">修改子板块</a></div>
                    <div><img src="image/add_1.gif" /><a href="DeleteClassData.aspx" target="userControlFram">删除子板块</a></div>
                </div>
            </div>
            <div class="parentNavigator"><img src="image/folder.gif"/><a href="CheckArticle.aspx" target="userControlFram">文章管理</a></div>
            <%-- <div class="parentNavigator"><img src="image/folder.gif"/><a href="CheckUserState.aspx" target="userControlFram">用户管理</a></div>--%>
        </div>
    </div>
    <div id="contentPage">
        <div id="contentTitle"></div>
        <div id="content">
             <iframe id="userControlFram" name="userControlFram"  frameborder="0" scrolling="auto" src="Welcome.htm" style=" width:100%; min-height:500px; padding:0px;"></iframe>
        </div>
    </div>
</div>
<script type="text/javascript">

    var ss='<%=Session["role"]%>';
    if(!ss){
        alert("你没有登陆或者超时!");
        var ifram=document.getElementById("userControlFram");
        ifram.src="../Login.aspx";
    }

//显示子菜单
function showChildOperate(operateID,childID)
{
    var operateImg=document.getElementById(operateID);
    var obj=document.getElementById(childID);

    obj.style.display="";
    operateImg.src="image/plus_1.gif";

}
//关闭子菜单
function closeChildOperate(operateID,childID)
{
    var operateImg=document.getElementById(operateID);
    var obj=document.getElementById(childID);
    if(obj.style.display=="")
    {
        obj.style.display="none";
        operateImg.src="image/add_1.gif";
    }
    else if(obj.style.display=="none")
    {
        obj.style.display="";
        operateImg.src="image/plus_1.gif";
    }

}
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
                cwin.height = cwin.contentDocument.body.offsetHeight+100;
                document.getElementById('right').style.height=cwin.contentDocument.body.offsetHeight+80;
            }
            else if(cwin.Document && cwin.Document.body.scrollHeight)
            {
                cwin.height = cwin.Document.body.scrollHeight+100;
                document.getElementById('right').style.height=cwin.Document.body.scrollHeight+80;
            }
        }
    }
}

</script>
</asp:Content>

