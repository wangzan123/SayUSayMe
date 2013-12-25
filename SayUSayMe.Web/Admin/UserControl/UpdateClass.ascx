<%@ Control Language="C#"  AutoEventWireup="true" CodeFile="UpdateClass.ascx.cs" Inherits="Admin_UserControl_UpdateClass" %>
<%@ Import Namespace="SayUSayMe.DAL" %>
<asp:ScriptManager runat="server" ID="ScriptManager1">
</asp:ScriptManager>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div>请选择板块：<asp:DropDownList runat="server" Width="160px" ID="droCatalogName" OnSelectedIndexChanged="DroCatalogChange" AutoPostBack="true"></asp:DropDownList></div>
        <hr style="color:Red; height:1px;" />
        <div>
            选择子版块：<asp:DropDownList runat="server" Width="160px" ID="droClassName" OnSelectedIndexChanged="DroClassChange" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div>
            <div style="float:left;">子版块分类：</div><asp:ListBox runat="server" ID="lsClassSort" Width="160px"></asp:ListBox>
            <asp:Button runat="server" ID="deleteClassSort" Text="删除" OnClientClick="return deletConfirm()" OnClick="DeleteSortClick"/><asp:Button runat="server" ID="addClassSort" Text="添加" OnClick="AddClassSortClick" />
            <asp:TextBox runat="server" ID="txtClassSort" ></asp:TextBox>
        </div>
        
        <asp:ListView runat="server" ID="lstVclassData">
        <LayoutTemplate>
            <span id="itemPlaceHolder" runat="server" class="classTable"></span>
        </LayoutTemplate>
            <ItemTemplate>
                <table id="classTable" cellspacing="0">
                    <tr>
                        <td class="style1">子板块名称：</td>
                        <td class="inputTD"><asp:TextBox runat="server" ID="className" Text="<%#Eval(&quot;className&quot;) %>"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="style1">子板块描述：</td>
                        <td  class="inputTD"><asp:TextBox runat="server" Rows="3" Columns="30" ID="classDescription" Text="<%# Eval(&quot;classDescription&quot;) %>" TextMode="MultiLine"></asp:TextBox></td>
                   </tr>
                    
                    <tr>
                        <td class="style1">子板块公告：</td>
                        <td class="inputTD"><asp:TextBox runat="server" Rows="3" Columns="30" ID="warning" Text="<%# Eval(&quot;warning&quot;) %>" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="style1">子板块图片：</td>
                        <td >
                            <asp:Image ImageUrl="<%# &quot;~/Admin/image/&quot;+GetConfigurationSettings.newImg %>" ID="newImgPlace" runat="server"/>
                            <asp:Image ImageUrl="<%# &quot;~/Admin/image/&quot;+GetConfigurationSettings.normalImg %>" ID="normalImgPlace" runat="server" /><br />
                            <asp:RadioButton runat="server" ID="radioNewImg" GroupName="classImg" Checked="<%# GetClassImg(Container.DataItem,GetConfigurationSettings.newImg) %>"/>
                            <asp:RadioButton runat="server" ID="radioNormalImg" GroupName="classImg" Checked="<%# GetClassImg(Container.DataItem,GetConfigurationSettings.normalImg) %>" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button runat="server" ID="btnUpdate" Text="修改" OnClick="UpdateClassData" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:ListView>
    </ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">
function deletConfirm()
{
    return confirm("删除了将永远丢失，您确定删除吗？");
}
</script>