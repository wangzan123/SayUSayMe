<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AdminSys.aspx.cs" Inherits="AdminClass" Title="IT论坛后台管理系统" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="Stylesheet" href="Css/AllPage.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager runat="server" ID="ScriptManager1">
    <Services>
        <asp:ServiceReference Path="~/WebService.asmx" />
    </Services>
</asp:ScriptManager>
<div id="adminPage">
    <div id="left">
        <div id="leftTitle">系统功能</div>
        <div id="navigator">
            <div class="parentNavigator"><img src="image/add_1.gif" id="operateID" onclick="closeChildOperate('operateID','classManager')" /><a href="javascript:" onclick="showChildOperate('operateID','classManager')">板块信息管理</a></div>
            <div class="childNavigator" id="classManager" style="display:none;">
                <div><img src="image/add_1.gif" id="Img1" onclick="closeChildOperate('Img1','child1')" /><a href="AddCatalog.aspx" target="userControlFram" onclick="showChildOperate('Img1','child1')">添加板块</a></div>
                <div class="childNavigator" id="child1" style="display:none;">
                    <div><a href="AddClass.aspx" target="userControlFram">添加子版块</a></div>
                </div>
                <div><img src="image/add_1.gif" id="Img2" onclick="closeChildOperate('Img2','child2')"/><a href="UpdateCatalogData.aspx" target="userControlFram" onclick="showChildOperate('Img2','child2')">修改板块</a></div>
                <div class="childNavigator" id="child2" style=" display:none;">
                    <div><a href="UpdateClassData.aspx" target="userControlFram">修改子板块</a></div>
                </div> 
                  <div><img src="image/add_1.gif" id="Img4" onclick="closeChildOperate('Img4','child3')"/><a href="DeleteCatalogData.aspx" target="userControlFram" onclick="showChildOperate('Img4','child3')">删除板块</a></div>
                <div class="childNavigator" id="child3" style=" display:none;">
                    <div><a href="DeleteClassData.aspx" target="userControlFram">删除子板块</a></div>
                </div> 
            </div>
            <div class="parentNavigator">
                <img src="image/add_1.gif" id="Img3" onclick="closeChildOperate('Img3','applyTitle')" /><a href="javascript:" target="userControlFram" onclick="GetApplyTitle('Img3','applyTitle')">申请处理</a>
                <div class="childNavigator" id="applyTitle" style="display:none;"></div>
            </div>
<%--            <div class="parentNavigator"><img src="image/folder.gif" /><a href="../AddArticle.aspx">新闻发布系统</a></div>--%>
            <div class="parentNavigator"><img src="image/folder.gif" /><a href="CheckArticle.aspx" target="userControlFram">文章管理</a></div>
<%--            <div class="parentNavigator"><img src="image/folder.gif" /><a href="UserGrade.aspx" target="userControlFram">等级管理</a></div>--%>
            <div class="parentNavigator"><img src="image/folder.gif" /><a href="CheckUserState.aspx" target="userControlFram">会员管理</a></div>
        </div>
    </div>
    <div id="contentPage">
          <div id="contentTitle"></div>
          <div id="content">
               <iframe id="userControlFram" name="userControlFram" scrolling="auto"  frameborder="0" src="Welcome.htm" style=" width:100%; min-height:500px; padding:0px;"></iframe>
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
//通过Ajax调用生成子菜单
function GetApplyTitle(imgObj,childID)
{
    var operateImg=document.getElementById(imgObj);
    operateImg.src="image/plus_1.gif";
    
    var childObj=document.getElementById(childID);
    if(childObj.style.display=='none')
    {
        WebService.GetApplyTitle(onSuccess);
        function onSuccess(result)
        {
            var titleUrlText="<a href='dillApply.aspx?name={$titleUrlName}' target='userControlFram'>{$titleName}</a><br />";
            var titleData=result.split("&");//分离版主申请信息
            document.getElementById("applyTitle").innerHTML="";//显示子菜单
            for(var i=0;i<titleData.length-1;i++)
            {        
                //动态生成子菜单                                            
                document.getElementById("applyTitle").innerHTML+=titleUrlText.replace(/\{\$titleUrlName\}/g,encodeURI(titleData[i])).replace(/\{\$titleName\}/g,titleData[i]);
            }
        }
        childObj.style.display='';
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
                cwin.height = cwin.contentDocument.body.offsetHeight;
                document.getElementById('right').style.height=cwin.contentDocument.body.offsetHeight+40;
            }
            else if(cwin.Document && cwin.Document.body.scrollHeight)
            {
                cwin.height = cwin.Document.body.scrollHeight;
                document.getElementById('right').style.height=cwin.Document.body.scrollHeight+40;
            }
        }
    }
}

</script>
</asp:Content>

