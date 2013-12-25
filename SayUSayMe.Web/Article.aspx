<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Article.aspx.cs" Inherits="Article" Title="查看" %>

<%@ Register Src="~/UserControls/ShowArticle.ascx" TagName="ShowArticle" TagPrefix="ShowArticleUc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="width:850px;">
        <ShowArticleUc:ShowArticle ID="ShowArticle1" runat="server" />
    </div>
</asp:Content>

