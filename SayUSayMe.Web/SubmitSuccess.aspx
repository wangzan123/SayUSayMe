<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SubmitSuccess.aspx.cs" Inherits="SubmitSuccess" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="returnText" style="font-size:20px; margin:20px 10px 20px 50px; border:0px;">
恭喜,发表成功!<a href="ArticleContent.aspx?articleid=<%# articleID %>">返回查看</a>
</div>
</asp:Content>

