<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableViewState="false" CodeFile="Default.aspx.cs" Inherits="_Default" Title="IT技术交流" Theme="mainTheme"%>

<%@Register Src="~/UserControls/ShowCatalog.ascx" TagName="Catalog" TagPrefix="CatalogUC" %>
<%@Register Src="~/UserControls/Flash.ascx" TagName="Flash" TagPrefix="FlashUc"%>
<%@Register Src="~/UserControls/NewNote.ascx" TagName="NewArticle" TagPrefix="ArticleUc" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="page">
  <div id="container">
    <div id="newsShow">
        <div id="headTitle">
            <span id="headTitle1">≡ 最新图片 ≡</span>
            <span id="headTitle2">≡ 最新帖子 ≡</span>
            <span id="headTitle3">≡ 最新回复 ≡</span>
        </div>
        <div id="flashPic">
            <div id="pic"><FlashUc:Flash ID="Flash1" runat="server"/></div>
        </div>
        <div  id="newNote">
            <div id="newArticle">
               <ArticleUc:NewArticle ID="NewArticle" runat="server"  type="Article"/>
            </div>
            <div id="newComment">
                <ArticleUc:NewArticle ID="NewComment" runat="server" type="Comment"/>
            </div>
        </div>
    </div>
    <div style="clear:both;"></div>
        
    <div id="webBlock">
        <CatalogUC:Catalog ID="catalog1" runat="server"></CatalogUC:Catalog>
    </div>
  </div>
</div>
</asp:Content>

