<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UpdateCatalog.ascx.cs" Inherits="Admin_UserControl_UpdateCatalog" %>
<asp:ScriptManager runat="server" ID="ScriptManager1">
    <Services>
        <asp:ServiceReference Path="~/WebService.asmx" />
    </Services>
</asp:ScriptManager>
<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
        <div>请选择板块：<asp:DropDownList runat="server" ID="droCatalog" OnSelectedIndexChanged="droCatalogChange" AutoPostBack="true"></asp:DropDownList></div>
        <asp:ListView runat="server" ID="catalogDataTable">
            <LayoutTemplate>
                <span id="itemPlaceHolder" runat="server"></span>
            </LayoutTemplate>
            <ItemTemplate>
               <table id="catalogTable">
                    <tr>
                        <td>板块名称：</td>
                        <td><input id="catalogName" value="<%# Eval("catalogName") %>" /></td>
                    </tr>
                    <tr>
                        <td>板块首页：</td>
                        <td><input id="indexUrl" value="<%# Eval("indexUrl") %>" /></td>
                    </tr>
                    <tr>
                        <td>板块描述：</td>
                        <td><textarea id="catalogDescription" cols="40" rows="3"><%# Eval("catalogDescription") %></textarea></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center"><input id="btnUpdate" type="button" value="提交修改" onclick="btnUpdateClick()" /></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:ListView>
    </ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">
function btnUpdateClick()
{
   
    var catalogTable=document.getElementById("catalogTable");
    var inputs=catalogTable.getElementsByTagName("input");
    var textarea=catalogTable.getElementsByTagName("textarea");
    var postData="";
    for(var i=0;i<inputs.length;i++)
    {
        if(inputs[i].type=="text")
        {
            if(inputs[i].value.length==0)
            {
                alert("填写内容不能为空");
                return;
            }
            else
            {
                postData+=inputs[i].id+"="+inputs[i].value+"&";
            }
        }
    }
    for(var i=0;i<textarea.length;i++)
    {
        if(textarea[i].value.length==0)
        {
            alert("填写内容不能为空");
            return;
        }
        else
        {
            postData+=textarea[i].id+"="+textarea[i].value+"&";
        }
    }
    var droCatalog=document.getElementById("<%=droCatalog.ClientID %>");
    WebService.UpdateCatalogData(droCatalog.options[droCatalog.selectedIndex].value,postData,onSuccess,onFailed);
    function onSuccess(result)
    {
        if(result==0)
            alert("修改失败");
        else
            alert("修改成功");
    }
    function onFailed(result)
    {
        alert(result.get_message());
    }
}
</script>