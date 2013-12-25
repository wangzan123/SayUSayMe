<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomerDataList.ascx.cs" Inherits="UserControls_CustomerDataList" %>
<div id="download">
    <asp:DataList runat="server" ID="DataList1" RepeatColumns='<%# DLRepeatColumns%>'  RepeatDirection='<%# DLRepeatDirection%>' EnableViewState="false">
        <HeaderTemplate>
            <div class="<%#HeadStyle%>">
                <span><a href='<%# headUrl+HeadID %>'><%# HeadText%></a></span>
            </div>
        </HeaderTemplate>
        <ItemTemplate>   
            <span class="<%# ItemStyle %>"><a href='<%# contentUrl+Eval("contentID").ToString() %>'> <%# Eval("ContentText") %></a></span>
        </ItemTemplate>
    </asp:DataList>
</div>