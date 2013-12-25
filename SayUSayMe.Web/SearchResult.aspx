<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
#searchItem{ width:920px; padding-top:20px; margin-left:30px;}
#searchItem #articleTitle{ font-size:25px;}
#searchItem #shortContent{ font-size:15px; height:auto; width:100%;}
#searchItem #otherData{ color:Green;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView runat="server" ID="gridSearch" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <div id="searchItem">
                        <div id="articleTitle"><a href='ArticleContent.aspx?articleid=<%#Eval("articleID") %>'><%#Eval("articleSubject").ToString().Replace(searchTxt,"<font style='color:red;'>"+searchTxt+"</font>") %></a></div>
                        <div id="shortContent"><%#HttpUtility.HtmlDecode(Eval("sortContent").ToString().Replace(searchTxt,"<font style='color:red;'>"+searchTxt+"</font>"))%></div>
                        <div id="otherData">
                            <span>浏览:<%#Eval("clickSum") %></span>
                            <span>回复:<%#Eval("replySum") %></span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
   <div class="pageFoot">
       <div class="operation"><a href="javascript:" onclick="check()"><img src="image/post.png" style="border:0px;"/></a></div> 
       <div class="pageNumber" style="margin:-10px 0px 0px -20px;"><span><a href="">返回首页</a></span><asp:Literal runat="server" ID="pageNumber"></asp:Literal>
           <span id="pageJump" style="display:none; padding:0px; background-color:White; border:0px;">转到&nbsp;<asp:TextBox runat="server" BorderWidth="1px" Width="30px" ID="txtPage" Text="1"></asp:TextBox>页&nbsp;
           <asp:LinkButton  runat="server" ID="btnPageNumber" OnClick="btnPageNumberClick" Text="确定" CssClass="linkButton" OnClientClick="return checkPageNumber()"/>
           </span>
       </div> 
   </div>
<asp:Literal runat="server" ID="ltScript"></asp:Literal>
</asp:Content>

