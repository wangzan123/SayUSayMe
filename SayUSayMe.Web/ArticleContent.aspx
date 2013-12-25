<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ArticleContent.aspx.cs" ValidateRequest="false" Inherits="ArticleContent" Title="" %>

<%@ Register Src="~/UserControls/AddArticle.ascx" TagName="AddArticle" TagPrefix="Article" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
<script type="text/javascript">

</script>
     <asp:Literal runat="server" ID="Literal1"></asp:Literal>
    <asp:Literal runat="server" ID="Literal2"></asp:Literal>
    <div class="ArticleBlock">
        <div class="userDetails"> 
            <div class="UserDetailsName"><%# GetUserDetails("userName") %></div>
            <div class="UserDetailsPic"><img src='<%# GetUserDetails("headPhoto") %>'onError="this.src='image/defualtHeadPhoto.gif'" /></div>
            <div class="UserDetailsGrade"><%# GetUserDetails("userGradePic") %></div>
        </div>
        <div class="ArticleDetails" style=" background-color:White;">
            <div class="ArticleDetailsTitle"><img src="image/3.gif" />主题:&nbsp;&nbsp;<%# GetArticleContent("subject") %>&nbsp;&nbsp;&nbsp;&nbsp;|
                &nbsp;&nbsp;&nbsp;&nbsp;发表于:&nbsp;&nbsp;<%# GetArticleContent("date") %>
            </div>
            <div class="ArticleDetailsContent"><%# GetArticleContent("content") %></div>
            <div style="background-color:White;">
                <div id="file" style="background-color:White" class="files"><%#GetArticleFiles(GetArticleContent("articleID"))%></div>
                <div id="replyOperation"><span id="showreply"><img src= "image/32.gif" style="border:0px;" /><a href="#reply">&nbsp;&nbsp;回复</a></span><%#UpdateArticleLink(GetUserDetails("userName")) %><span></span></div>
            </div>
        </div>
    </div>             
    
    <asp:DataList runat="server" ID="showReturn">
        <ItemTemplate>
        <a name="#<%# Eval("commentID") %>"></a>
        <div style="clear:both;"></div>
        <div class="ArticleBlock">   
            <div class="userDetails"> 
                <div class="UserDetailsName"><%# Eval("userShowName")%></div>
                <div class="UserDetailsPic"><img src='<%# Eval("headPhoto")%>' onError="this.src='image/defualtHeadPhoto.gif'"/></div>
                <div class="UserDetailsGrade"><%# GetUserGradePic(Container.DataItem)%> </div>
            </div>
            
            <div class="ArticleDetails"  style=" background-color:White;">
                <div class="ArticleDetailsTitle"><img src="image/online_member.gif" />
                    &nbsp;&nbsp;&nbsp;&nbsp;回复于:&nbsp;&nbsp;<%# Eval("addDate") %>
                </div><br/>
                &nbsp;&nbsp;<div style="font-size:large; background-color:White; color:Gray;"><%#HttpContext.Current.Server.HtmlDecode(Eval("useReplyContent").ToString())%></div><br/>
                <div class="ArticleDetailsContent"><%# GetReplyContent(HttpContext.Current.Server.HtmlDecode(Eval("speakContent").ToString()), Eval("userstate").ToString())%></div>
                <div id="replyFile" style="background-color:White" class="files"><%# GetFile(Container.DataItem, "Reply")%></div>
                <div id="replyToReply">&nbsp;&nbsp;<span>&nbsp;&nbsp;<img src= "image/32.gif" style="border:0px;" />&nbsp;<%#CommentOperation(Eval("commentID").ToString(), Eval("userShowName").ToString(),"replyComment")%></span>
                                                    <span>&nbsp;&nbsp;<img src= "image/32.gif" style="border:0px;" />&nbsp;<%#CommentOperation(Eval("commentID").ToString(), Eval("userShowName").ToString(), "quote")%></span>
                                                   <span><%#UpdateComment(Eval("commentID").ToString(), Eval("userShowName").ToString())%></span>
                </div>
            </div>
        </div>
            
        </ItemTemplate>
    </asp:DataList>
    

    <div class="pageFoot">
        <div class="operation" style="margin:0px 0px -20px 10px;"><a href="javascript:" onclick="check()"><img src="image/post.png" style="border:0px;"/></a></div> 
        <div class="pageNumber" style="margin:-10px 0px 0px -20px;"><span><a href="">返回首页</a></span>
            <asp:Literal runat="server" ID="pageNumber"></asp:Literal>
            <span id="pageJump" style="display:none; padding:0px; background-color:White; border:0px;">转到&nbsp;<asp:TextBox runat="server" BorderWidth="1px" Width="30px" ID="txtPage" Text="1"></asp:TextBox>页&nbsp;
                <asp:LinkButton  runat="server" ID="btnPageNumber" OnClick="btnPageNumberClick" Text="确定" CssClass="linkButton" OnClientClick="return checkPageNumber()"/>
            </span>
       </div> 
    </div>
    <asp:Literal runat="server" ID="script"></asp:Literal>
    <asp:Literal runat="server" ID="ltScript"></asp:Literal>
    <div style="height:2px"></div>
    <div id="addreply">
        <a name="reply"><Article:AddArticle ID="AddArticle2" runat="server" ArticleID="<%# GetArticleContent(&quot;articleID&quot;) %>" /></a>
    </div>
      <asp:Literal runat="server" ID="AricleIDExceptionScript"></asp:Literal>
    <asp:Literal runat="server" ID="replyCommentScirpt"></asp:Literal>
<script type="text/javascript"> 
var files=document.getElementsByName("files");
var ss='<%=Session["userName"]%>';

 $(".files").each(function(){
         if($(this).text()!=''&&!ss){
            $(this).html("<h3>由于未登录，无法查看附件！</h3>");
         }
 }); 



  
var oldValue=document.getElementById("<%#txtPage.ClientID %>").value;
function checkPageNumber()
{
    var obj=document.getElementById("<%#txtPage.ClientID %>");
    var pre=/^\d+$/;
    if(!pre.test(obj.value))
    {
        alert("输入有误");
        return false;
    }
    if(oldValue==obj.value)return false;
   //var reply=document.getElementById("replyOperation");
   // reply.style.display='none';
}
</script>
</asp:Content>

