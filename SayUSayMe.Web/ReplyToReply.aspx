<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReplyToReply.aspx.cs" Inherits="ReplyToReply" Title="无标题页"  ValidateRequest="false"%>
<%@ Register Src="~/UserControls/AddArticle.ascx" TagName="AddArticle" TagPrefix="Article" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div><span style="font-size:x-large;">参与/回复主题</span></div><br />
<div><span style=" font-size:larger; font-family:inherit;">RE:<asp:Label ID="articleContentLabel" runat="server" Text="Label"></asp:Label></span></div><br />
<div>
    <asp:Label ID="CommentLinkLabel" runat="server" Text="Label"></asp:Label></div>
<div><br />
 <Article:AddArticle ID="AddArticle3" runat="server"/>
</div>

</asp:Content>

