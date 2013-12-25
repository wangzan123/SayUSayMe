<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddClass.ascx.cs" Inherits="Admin_UserControl_AddClass" %>
<div id="catalogName">
    <span id="showText">您准备为下列模块添加板块</span>
    <span><asp:DropDownList runat="server" ID="DroCatalog"></asp:DropDownList></span>
</div>

<table id="classTable" cellspacing="0">
    <tr>
        <td class="titleTD">板块名称：</td>
        <td class="inputTD"><asp:TextBox runat="server" ID="className" CssClass="inputTextBox"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="className" ErrorMessage="板块名字不可以为空"></asp:RequiredFieldValidator>
        </td>    
    </tr>
    <tr>
        <td class="titleTD">板块描述：</td>
        <td  class="inputTD"><asp:TextBox runat="server" CssClass="inputTextBox" ID="classDescription" TextMode="MultiLine" Wrap="true"></asp:TextBox></td>
        <td> 
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="classDescription" ErrorMessage="板块描述不可以为空"></asp:RequiredFieldValidator>
        </td>
   </tr>
    
    <tr>
        <td class="titleTD">板块公告：</td>
        <td class="inputTD"><asp:TextBox runat="server" CssClass="inputTextBox" ID="warning" TextMode="MultiLine" Wrap="true"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="warning" ErrorMessage="板块公告不可以为空"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="titleTD">板块分类：</td>
        <td colspan="2">
            <asp:ListBox runat="server" ID="lsClassSort" Width="100%"></asp:ListBox>
            <asp:TextBox runat="server" ID="classSort"></asp:TextBox>
            <asp:Button runat="server" ID="btnClassSort" OnClick="AddClassSortClick" Text="添加" CausesValidation="false"/>
            <asp:Button runat="server" ID="btnDeleteClassSort" OnClick="DeleteClassSort" Text="删除"  CausesValidation="false" />
        </td>
    </tr> 
    <tr>
        <td class="titleTD">板块图片：</td>
        <td colspan="2">
            <asp:Image ImageUrl="~/Admin/image/forum.gif" runat="server" ID="normalImg"/>
            <asp:Image ImageUrl="~/Admin/image/forumNew.gif" runat="server" ID="newImg" />
            <asp:RadioButtonList runat="server" ID="classImg" RepeatColumns="2" 
                RepeatDirection="Horizontal" BorderStyle="None" 
                BorderWidth="0px" Width="71px">
                <asp:ListItem Selected="True" Value="image/articleClass/forum.gif" Text=""></asp:ListItem>
                <asp:ListItem Value="image/articleClass/forumNew.gif" Text=""></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td colspan="3" align="center">
            <asp:Button runat="server" Text="确定添加" ID="btnAdd" OnClick="btnAddClassClick" CausesValidation="true"/>
        </td>
    </tr>
</table>
<asp:Literal runat="server" ID="script"></asp:Literal>