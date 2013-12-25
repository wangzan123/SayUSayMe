<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QuoteToReply.aspx.cs" Inherits="QuoteToReply" Title="引用发表"  ValidateRequest="false"%>

<%@ Register src="UserControls/AddArticle.ascx" tagname="AddArticle" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
<div><span style="font-size:x-large;">&nbsp;参与/回复主题</span></div><br />
<div><span style=" font-size:larger; font-family:inherit;">&nbsp;&nbsp;&nbsp;RE：&nbsp;&nbsp;&nbsp;<asp:Label ID="articleSuject" runat="server" Text="Label"></asp:Label></span></div><br />
<div>
    <span>&nbsp;&nbsp;&nbsp;引用：</span><asp:Label ID="quoteContent" runat="server" Text="Label"></asp:Label></div>
<div>
    <uc1:AddArticle ID="AddArticle1" runat="server" />
    
</div>
</asp:Content>

