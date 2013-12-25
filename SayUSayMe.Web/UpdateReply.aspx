<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateReply.aspx.cs" Inherits="UpdateReply" Title="无标题页" ValidateRequest="false" %>
<%@ Register Src="~/UserControls/AddArticle.ascx" TagName="AddArticle" TagPrefix="Article" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <Article:AddArticle ID="AddArticle1" runat="server" />

</asp:Content>

