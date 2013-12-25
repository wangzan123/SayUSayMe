<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageNews.aspx.cs" Inherits="NewsManage.news.datagrid.NewsManageNewsDatagridManageNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    	<link rel="stylesheet" type="text/css" href="../../themes/default/easyui.css">
	<link rel="stylesheet" type="text/css" href="../../themes/icon.css">
	<link rel="stylesheet" type="text/css" href="../demo.css">
	<script type="text/javascript" src="../../jquery.min.js"></script>
	<script type="text/javascript" src="../../jquery.easyui.min.js"></script>

</head>
    <body>

        <form id="form1" runat="server">
            <h2>新闻管理</h2>
            <div class="demo-info">
                <div class="demo-tip icon-tip"></div>
                <div>进行新闻管理</div>
            </div>
            <div style="margin:10px 0;"></div>
            <div class="easyui-tabs" style="width:700px;height:auto">
                <%-- 第一个选项卡开始 --%>
                <div title="添加新闻" style="padding:10px">
                    <p style="font-size:14px">添加新闻</p>
                    <%-- NewsID,userID,classSort,NewsSubject,NewsContent,addDate,clickSum, --%>
                    <ul>
                        <li>新闻类别：<asp:DropDownList ID="DDLclassSort" runat="server"></asp:DropDownList></li>
                        <li>新闻主题：<asp:TextBox ID="TxtNewsSubject" runat="server"></asp:TextBox></li>
                        <li>内容：<asp:TextBox ID="txtNewsContent" runat="server" Height="135px" Width="335px" Text="短新闻:请尽量少于150字"></asp:TextBox></li>
                        <li>图片：<asp:FileUpload ID="FileUpload1" runat="server" /> <asp:Image ID="showImage" runat="server" /></li><br/>
                        <asp:Button ID="BtnAddNews" runat="server" Text="添加" OnClick="BtnAddNews_Click" />
                    </ul>
                
                </div>
                <%-- 第一个选项卡结束 --%>

                <%-- 第二个选项卡开始 --%>
                <div title="删除新闻" style="padding:10px">
                    下面执行新闻的删除操作；请选择删除的数量：
                    <ul class="easyui-tree" data-options="url:'tree_data1.json',method:'get',animate:true">
                        <li>
                            <asp:DropDownList ID="DDL_DeleteNews" runat="server">
                                <asp:ListItem Value="10" >删除最早10条</asp:ListItem>
                                <asp:ListItem Value="30" >删除最早30条</asp:ListItem>
                                <asp:ListItem Value="50">删除最早50条</asp:ListItem>
                                <asp:ListItem Value="100">删除最早100条</asp:ListItem>
                            </asp:DropDownList>
                             <asp:Button ID="BtnDeleteNews" runat="server" Text="确定" OnClick="BtnDeleteNews_Click" />
                        </li>
                       
                    </ul>
                </div>
                <%-- 第二个选项卡结束 --%>

                <%-- 第三个选项卡开始 --%>
                <div title="帮助" data-options="iconCls:'icon-help',closable:true" style="padding:10px">
                    微新闻管理模块用于增加和删除新闻</div>
                <%-- 第三个选项卡结束 --%>
            </div>
        </form>
    </body>
</html>
