<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebData.aspx.cs" Inherits="WebData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style type="text/css">
*{margin:0px; padding:0px;}
body{margin:0px;}
#editDetails{margin:0px; width:100%; font-size:12px;}
 #editDetails .title
{
	background-image: none;
	font-size: 13px;
	font-weight: bolder;
	background-position: left top;
	background-repeat: repeat-x;
	padding: 5px 0px 5px 30px;
	width: 100%;
	color: #FF0000;
	background-color: #000000;
}
  
#editDetails #baseDetails{ width:100%;}
#baseDetails .dataPlace{ min-height:100px; border:1px solid #cccccc; width:100%;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="editDetails">
        <div id="baseDetails">
            <div class="title">历史文章</div>
            <div class="dataPlace">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="4" DataKeyNames="articleID" DataSourceID="SqlDataSource1" Width="100%" 
                    AllowPaging="True" AllowSorting="True" PageSize="20" 
                    EmptyDataText="您没有发表文章" Font-Size="13pt" Font-Underline="False" 
                    HorizontalAlign="Center">
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <RowStyle BackColor="White" ForeColor="#330099" HorizontalAlign="Center"/>
                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="articleID" 
                            DataNavigateUrlFormatString="ArticleContent.aspx?articleid={0}" 
                            DataTextField="articleSubject"  HeaderText="主题"/>
                        <asp:BoundField DataField="className" HeaderText="所属分类" 
                            SortExpression="className" />
                        <asp:TemplateField HeaderText="附件">
                            <ItemTemplate>
                                <span><%# HasFile(Eval("articleID").ToString())%></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="sortName" HeaderText="文章类别" 
                            SortExpression="sortName" />
                        <asp:BoundField DataField="clickSum" HeaderText="点击量" 
                            SortExpression="clickSum" />
                        <asp:BoundField DataField="replySum" HeaderText="回复数" 
                            SortExpression="replySum" />
                        <asp:TemplateField HeaderText="文章状态">
                            <ItemTemplate>
                                <span><%# Int32.Parse(Eval("state").ToString()) == 0 ? "等待处理" :(Int32.Parse(Eval("state").ToString())==-1?"被删除":"已通过")%></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="addDate" HeaderText="发表时间" 
                            SortExpression="addDate" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="articleGrade" HeaderText="文章等级" 
                            SortExpression="articleGrade" />
                    </Columns>
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="center" 
                        BorderColor="#FFCCFF" BorderWidth="1px"
                        Font-Size="12pt" Font-Strikeout="False" BorderStyle="Solid" Width="30" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" 
                        Font-Size="15pt" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DbconnectionString %>" 
                    SelectCommand="GetArticleByUserName" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="userName" SessionField="userName" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
           
        </div>
    </div>
    </form>
</body>
</html>
