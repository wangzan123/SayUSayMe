<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShowCatalog.ascx.cs" Inherits="UserControls_ShowCatalog" EnableViewState="true"%>
<%@ Import Namespace="SayUSayMe.DAL" %>

<asp:ListView runat="server" ID="catalog">
    <LayoutTemplate>
        <div id="catalogPlace">
            <div id="itemPlaceholder" runat="server"></div>
        </div>
    </LayoutTemplate>
    <ItemTemplate>
    <div id="catalogTitle">【<a href='<%# GetContentUrl(Container.DataItem)%>catalogid=<%# Eval("catalogID") %>&n=<%#System.Web.HttpUtility.UrlEncode(Eval("catalogName").ToString()) %>'><%#Eval("catalogName").ToString().Trim()%></a>】（<%# GetBordAdmin(Container.DataItem,"catalog") %>）<span id="lastestPostText">最近发表</span></div>
        <asp:ListView runat="server" DataSource="<%# CatalogAccess.GetArticleClassByCatalogID(Eval(&quot;catalogID&quot;).ToString())%>">
            <LayoutTemplate>
                <div id="classPlace">
                    <div id="itemPlaceholder" runat="server"></div>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div id="catalogBlock">
                    <div id="imgPlace" >
                       <img src='<%# Eval("classImg")%>'/>
                    </div>  
                    <div id="description">
                        <span id="title">主题:<a href='<%# GetContentUrl(Container.DataItem)%>classid=<%# Eval("classID") %>&n=<%#System.Web.HttpUtility.UrlEncode(Eval("className").ToString()) %>'><%# Eval("className") %></a>(今日:<span style="color:Red"><%# GetTodayArticleByClassID(Container.DataItem) %></span> <span>总文章:<%# Eval("articleSum") %></span>)</span>
                        <div id="descriptionWord"><%# Eval("classDescription")%></div>
                        <div><%# GetBordAdmin(Container.DataItem,"class") %></div>
                    </div>
                    <div style="float:right; width:150px;margin:-34px 90px 0px 0px; position:relative; text-align:center;">
                        <div id="lastestArticle">
                            <div id="subject"><a href='ArticleContent.aspx?articleid=<%# GetArticleID(Container.DataItem) %>&n=<%#System.Web.HttpUtility.UrlEncode(Eval("className").ToString()) %>'><%# GetSubject(Container.DataItem)%></a></div>
                            <div id="user"><a href='UserHomePage.aspx?userID=<%#GetUserID(Container.DataItem) %>'><%# GetUserName(Container.DataItem)%></a></div>
                            <div id="date"><%# GetDate(Container.DataItem) %></div>
                        </div>
                    </div>
                </div>  
            </ItemTemplate> 
        </asp:ListView>
    </ItemTemplate>
</asp:ListView>
<script type="text/javascript">
function checkUserType(url)
{

    WebService.CheckLoginState(onLoginSuccess);
    function onLoginSuccess(result)
    {
        if(result=="")
        {
            alert("请先登录");
            return false;
        }   
            
    } 
    
    WebService.CheckUserType(onSuccess);
    function onSuccess(result)
    {
        if(result>=0)
        {
            alert("一个用户只能担任一个版块的版主");
        }
        else
            {
            
            location.href=url;//跳转到超链接指定的url
    
            }
    }
}
</script>