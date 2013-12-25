<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShowArticle.ascx.cs" Inherits="UserControls_ShowArticle" %>
<%@ Import Namespace="SayUSayMe.DAL" %>


<div id="warning">
    <div id="warningTitle"><span>板块公告</span></div>
    <div id="warningContent"><%# GetWarningText() %></div>
</div>
<div id="articleBlock">
    <asp:DataList runat="server" ID="ShowArticle" Width="950px" 
        onselectedindexchanged="ShowArticle_SelectedIndexChanged">
        <HeaderTemplate>
            <div class="articleBlockTitle">
                <div id="subject">主题:</div>
                <div id="TitleWriter">作者/时间</div>
                <div id="replyAndClick">回复/查看</div>
                <div id="lastestReply">最后发表</div>
            </div>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="ArticleItem">
                <div class="ArticleSubject">
                    <span ><%#checkGrade(Eval("articleGrade").ToString())%></span>
                    
                    <span class="title"><span><%# Eval("sortID").ToString()=="-1"?"":"["+ Convert.ToString(CatalogAccess.GetSortNameByID(Int32.Parse(Eval("sortID").ToString())))+"]"%></span>&nbsp;<a href='ArticleContent.aspx?articleid=<%# Eval("articleID") %>&n=<%# System.Web.HttpUtility.UrlEncode(Request.QueryString["n"]) %>'><%# Eval("articleSubject") %></a><%# GetNewImage(Container.DataItem) %></span>
                </div>
                <div class="replyData">
                    <span style="color:#33aadd;"><%#Eval("replySum") %></span>/<span><%#Eval("clickSum") %></span>
                </div>
                <div class="userData">
                    <div style="text-align:center;margin:0px auto;">
                        <span class="userName"><a href='UserHomePage.aspx?userID=<%# Eval("userID")%>&userName=<%# Eval("userShowName") %>'> <%# Eval("userShowName") %></a></span>
                        <span class="date"><%# Eval("addDate") %></span>
                    </div>
                </div>
                <div class="lastReplyData">
                    <div style="text-align:center;margin:0px auto;">
                        <div id="replyShortText"><a href='ArticleContent.aspx?articleid=<%# GetLastestReply(Container.DataItem,"articleID" )%>'><%#GetLastestReply(Container.DataItem,"replyShortText") %></a></div>
                        <div id="userName"><%# GetLastestReply(Container.DataItem, "userShowName")%></div>
                        <div id="replyDate"><%#GetLastestReply(Container.DataItem,"replyDate") %></div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <HeaderStyle BackColor="#aaccff" BorderColor="#eeee44" />
    </asp:DataList>
</div>
<div style="clear:both;"></div>
<div class="pageFoot">
   <div class="operation"><a href="javascript:" onclick="check()"><img src="image/post.png" style="border:0px;"/></a></div> 
   <div class="pageNumber"><span><a href="">返回首页</a></span><asp:Literal runat="server" ID="pageNumber"></asp:Literal>
       <span id="pageJump" style="display:none; padding:0px; background-color:White; border:0px;">转到&nbsp;<asp:TextBox runat="server" BorderWidth="1px" Width="30px" ID="txtPage" Text="1"></asp:TextBox>页&nbsp;
       <asp:LinkButton  runat="server" ID="btnPageNumber" OnClick="btnPageNumberClick" Text="确定" CssClass="linkButton" OnClientClick="return checkPageNumber()"/>
       </span>
   </div> 
</div>
<asp:Literal runat="server" ID="ltScript"></asp:Literal>
<script type="text/javascript">
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
}
</script>