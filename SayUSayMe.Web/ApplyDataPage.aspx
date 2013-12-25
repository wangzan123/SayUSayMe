<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyDataPage.aspx.cs" Inherits="ApplyDataPage" %>
<%@ Import Namespace="SayUSayMe.DAL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style type="text/css">
*{margin:0px; padding:0px;}
body{margin:0px;}
 .title{ font-size:13px; font-weight:bolder; background-position:left top; color: #FF0000;background-color: #000000;background-repeat:repeat-x; padding:5px 0px 5px 30px; width:100%;}

.dataPlace{ min-height:100px; border:1px solid #cccccc; width:100%;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div >
     <div class="title">申请处理</div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
         DataKeyNames="applyID" DataSourceID="SqlDataSource1" 
         AutoGenerateColumns="False" Width="100%" BackColor="White" 
         BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="查看" />
                <asp:BoundField DataField="applyTitle" HeaderText="申请标题" 
                    SortExpression="applyTitle" />
                <asp:TemplateField HeaderText="申请状态" >
                    <ItemTemplate>
                        <span><%#Convert.ToInt32(Eval("applyState"))==(int)EnumEntity.ApplyState.waitForDeal?"正在办理中":(Convert.ToInt32(Eval("applyState"))==(int)EnumEntity.ApplyState.applyFailed?"申请失败":"申请成功") %></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="addDate" HeaderText="申请日期" 
                    SortExpression="addDate" DataFormatString="{0:d}" />
            </Columns>
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
     </asp:GridView>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
         ConnectionString="<%$ ConnectionStrings:DbconnectionString %>" 
         SelectCommand="GetApplyDataByUserName" SelectCommandType="StoredProcedure">
         <SelectParameters>
             <asp:SessionParameter Name="userName" SessionField="userName" Type="String" />
         </SelectParameters>
     </asp:SqlDataSource>
     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
         DataSourceID="SqlDataSource2" CellPadding="4" BackColor="White" 
         BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" Width="100%" >
         <FooterStyle BackColor="White" ForeColor="#333333" />
         <RowStyle BackColor="White" ForeColor="#333333" />
         <Columns>
         <asp:TemplateField HeaderText="申请内容">
            <ItemTemplate>
                <div><%# System.Web.HttpUtility.HtmlDecode(Eval("applyText").ToString()) %></div>
            </ItemTemplate>
             <ItemStyle Width="50%" />
         </asp:TemplateField>
         <asp:TemplateField HeaderText="申请失败原因"  >
            <ItemTemplate>
                <div><%# System.Web.HttpUtility.HtmlDecode(Eval("applyFailedText").ToString())%></div>
            </ItemTemplate>
             <ItemStyle Width="50%" />
         </asp:TemplateField>
         </Columns>
         <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
         <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
     </asp:GridView>
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DbconnectionString %>" 
            SelectCommand="GetApplyFailedData" SelectCommandType="StoredProcedure">
         <SelectParameters>
             <asp:ControlParameter ControlID="GridView1" 
                    Name="applyID" PropertyName="SelectedValue" Type="Int32" />
         </SelectParameters>
     </asp:SqlDataSource>
     </div>
    </form>
</body>
</html>
