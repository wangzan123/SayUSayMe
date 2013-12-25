<%@ Page Title="" Language="C#" MasterPageFile="~/NewsManage/Style/MasterPage.master" AutoEventWireup="true" CodeFile="ShowNews.aspx.cs" Inherits="NewsManage_news_datagrid_ShowNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        
        .biaoge{
width: 800px;
height: 100px;
margin: 0px auto;
margin-bottom:20px;
border:1px solid #A5B6C8;
background-color: #EEF3F7
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <form id="form1" runat="server">
    <div>
    
        <center>
    <asp:DataList ID="DataList1" runat="server">
       
        <ItemTemplate>
            <table width="500" class="biaoge">
                <tr><td colspan="2" style="border-left-width: 1px"><h2><%#Eval("NewsSubject") %></h2></td></tr>
                <tr>
                    <td>新闻编号:<%#Eval("NewsID") %></td>
                    <td>更新时间:<%#Eval("addDate") %></td>
                </tr>
                  <tr>
                      <td colspan="2">
                          <%--<asp:Image ID="Image1" runat="server" ImageUrl='Uploads/new/<%#Eval("NewsPhoto") %>' ></asp:Image>--%>
                          <asp:Image ID="Image1" runat="server" ImageUrl='<%#"Uploads/new/"+Eval("NewsPhoto") %>'  ></asp:Image>
                      </td>
                </tr>
                <tr><td colspan="2"><%#Eval("NewsContent") %></td></tr>
            </table>
        </ItemTemplate>
            
    </asp:DataList></center>
    </div>
    </form>
</asp:Content>

