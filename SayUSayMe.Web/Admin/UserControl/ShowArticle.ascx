<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShowArticle.ascx.cs" Inherits="UserControls_ShowArticle" %>

<asp:ScriptManager ID="ScriptManager1" runat="server">
    <Services>
        <asp:ServiceReference Path="~/WebService.asmx" />
    </Services>
</asp:ScriptManager>
<div id="articleBlock">
    <asp:DataList runat="server" ID="ShowArticle" Width="100%" 
        onselectedindexchanged="ShowArticle_SelectedIndexChanged">
        <HeaderTemplate>
            <div class="articleBlockTitle">
                <div id="subject">主题:</div>
                <div id="TitleWriter">作者/时间</div>
                <div id="operateText">操作</div>
            </div>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="ArticleItem">
                <div class="ArticleSubject">
                    <span><img src="image/topicnew.gif"/></span>
                    <span class="title"><a href='../ArticleContent.aspx?articleid=<%# Eval("articleID") %>'> <%# Eval("articleSubject") %></a></span>
                </div>
                <div class="userData">
                    <div style="text-align:center;margin:0px auto;">
                        <span class="userName"><a href='../UserHomePage.aspx?userID=<%# Eval("userID")%>&userName=<%# Eval("userShowName") %>'> <%# Eval("userShowName") %></a></span>
                        <span class="date"><%# Eval("addDate") %></span>
                    </div>
                </div>
                <div class="operateButton">
                    <a href="javascript:" onclick="CheckContent(<%# Eval("articleID") %>)" id="btnArticleCheck<%#Eval("articleID") %>">查看内容</a>
                    <a href="javascript:" onclick="ViewUserData(<%# Eval("userID")%>,<%#Eval("articleID") %>)" id="btnViewUserData<%# Eval("articleID") %>">查看作者</a>
                    <span id="deleteOrNot"><%# GetOperateBtn(Container.DataItem) %></span>
                    <a id="articleCheckState<%#Eval("articleID") %>"></a>
                    <a href="javascript:" onclick="changeArticleGrade(<%# Eval("articleID") %>,<%# Eval("articleGrade") %>)"><%#showArticleGrade(Eval("articleGrade").ToString())%></a>
                </div>
            </div>
            <div id="userData<%#Eval("articleID")%>" class="viewUserData" style="display:none;"></div>
            <div id="ArticleContent<%#Eval("articleID") %>" style=" display:none; border:2px solid #0055ff; padding:5px 5px 5px 10px;"><%# System.Web.HttpUtility.HtmlDecode(Eval("articleContent").ToString()) %></div>
        </ItemTemplate>
        <HeaderStyle BackColor="#aaccff" BorderColor="#eeee44" />
    </asp:DataList>
</div>
<div style="clear:both;"></div>
<div class="pageFoot">
   <div class="pageNumber"><asp:Literal runat="server" ID="pageNumber"></asp:Literal></div> 
</div>
<script type="text/javascript">
function changeArticleGrade(article_id,article_grade){
    if(!confirm("确定该操作吗？"))
        return false;
    
//    alert(article_id);
//    alert(article_grade);
    WebService.updateArticleGradeByID(article_id,article_grade,onUpdateSuccess);
     
    function onUpdateSuccess(result){
//    alert(result);
        if(result==1)
            alert("操作成功");
        else
            alert("操作失败");
        window.location="<%# Request.Url %>";
    }
    function onFailed(result){
        alert(result.get_message());
    }

}

function DeletArticle(articleID){
    if(!confirm("确定删除？"))
        return false;
    WebService.SetArticleStateByID(articleID,'delete',onDeleteSuccess);
    function onDeleteSuccess(result){
        alert("删除成功");
        window.location="<%# Request.Url %>";
    }
    function onFailed(result){
        alert(result.get_message());
    }
    
}
function unDeletArticle(articleID)
{
    if(!confirm("确定撤销删除吗？"))
        return false;
    WebService.SetArticleStateByID(articleID,"undelete",onUnDeleteSuccess,onFailed);
    function onUnDeleteSuccess(result)
    {
        alert("撤销删除成功");
        window.location="<%# Request.Url %>";
    }
    function onFailed(result)
    {
        alert(result.get_message());
    }
    
}
//查看内容
function CheckContent(articleID)
{
    var contentId="ArticleContent"+articleID;
    var btnId="btnArticleCheck"+articleID;
    var checkState="articleCheckState"+articleID;
    if(document.getElementById(contentId).style.display=="")
    {
        document.getElementById(contentId).style.display="none";
        document.getElementById(btnId).innerHTML="查看内容";
        document.getElementById(checkState).innerHTML="已查看";
        WebService.CheckArticleByID(articleID);
    }
    //第一次查看
    else
    {
        document.getElementById(contentId).style.display="";
        document.getElementById(btnId).innerHTML="收起内容";
        
    }
}
//查看作者
function ViewUserData(userID,articleID)
{
  
   var operatorObj=document.getElementById("btnViewUserData"+articleID);
   var dataObj=document.getElementById("userData"+articleID);
   if(dataObj.style.display=="")
   {
        operatorObj.innerHTML="查看作者";
        dataObj.style.display="none";
   }
   else
   {
       WebService.GetUserData(userID,onGetUsersSuccess);
       operatorObj.innerHTML="收起作者信息";
   }
   function onGetUsersSuccess(result)
   {
       dataObj.innerHTML=result;
       dataObj.style.display="";
   }
}


</script>
<asp:Literal runat="server" ID="ltScript"></asp:Literal>
