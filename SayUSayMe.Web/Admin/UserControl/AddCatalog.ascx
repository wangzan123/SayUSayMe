<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddCatalog.ascx.cs" Inherits="Admin_UserControl_AddCatalog" %>
<table id="catalogTable">
<tr>
    <td>板块名称：</td>
    <td><asp:TextBox runat="server" ID="catalogName"></asp:TextBox></td>
    <td><asp:RequiredFieldValidator ControlToValidate="catalogName" ErrorMessage="板块名字不许为空" runat="server" ID="requiredName"></asp:RequiredFieldValidator></td>
</tr>
<tr>
    <td>板块首页：</td>
    <td><asp:TextBox runat="server" ID="indexUrl"></asp:TextBox></td>
    <td><asp:RequiredFieldValidator ControlToValidate="indexUrl" ErrorMessage="板块首页不许为空" runat="server" ID="RequiredFieldValidator1"></asp:RequiredFieldValidator></td>
</tr>
<tr>
    <td>板块描述：</td>
    <td><asp:TextBox ID="catalogDescription" runat="server" Columns="40" Rows="3" TextMode="MultiLine"></asp:TextBox></td>
    <td><asp:RequiredFieldValidator ControlToValidate="catalogDescription" ErrorMessage="板块描述不许为空" runat="server" ID="RequiredFieldValidator2"></asp:RequiredFieldValidator></td>
</tr>
<tr>
    <td colspan="2" align="center"><asp:Button runat="server" ID="BtnAddCatalog" Text="添加" CausesValidation="true" OnClick="BtnAddClick" /></td>
</tr>
</table>
<asp:Literal runat="server" ID="script"></asp:Literal>