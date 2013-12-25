<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewNote.ascx.cs" Inherits="UserControls_NewNote"  EnableTheming="false"%>

<asp:DataList runat="server" ID="ShowNewArticle">
    <ItemTemplate>
        <div id="newsItemDiv"  onmouseover="this.style.backgroundColor='#ddffff';" onmouseout="this.style.backgroundColor='';">
            <span style="float:left;"><img src="<%# GetItemPic(Container.ItemIndex) %>" style="margin-bottom:-8px;" /><a href='ArticleContent.aspx?articleid=<%# Eval("articleID") %>&n=<%# System.Web.HttpUtility.UrlEncode(Eval("className").ToString()) %><%# GetCommentID(Container.DataItem)%>'><%# Server.HtmlEncode(Eval("newContent").ToString()) %></a></span> 
            <span id="userName">[<%#Eval("userShowName")%>]</span>
        </div>
    </ItemTemplate>
    <ItemStyle CssClass="newsItem" />
</asp:DataList>