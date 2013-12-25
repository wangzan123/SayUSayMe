<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckArticle.aspx.cs" Inherits="Admin_CheckArticle" %>

<%@ Register Src="~/Admin/UserControl/ShowArticle.ascx" TagName="showArticle" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/AllPage.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="adminOperateBtn">
            <a href="CheckArticle.aspx?type=new">尚未查看的文章</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <a href="CheckArticle.aspx?type=history">已查看的文章</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <a href="CheckArticle.aspx?type=delete">已删除文章</a>
        </div>
        <div id="pageContent">
            <uc1:showArticle ID="showArticle1" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
