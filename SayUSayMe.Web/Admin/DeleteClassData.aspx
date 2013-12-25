<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteClassData.aspx.cs" Inherits="Admin_DeleteClassData" %>
<%@ Register src="UserControl/DeleteClass.ascx" tagname="DeleteClass" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <span style="color:Red;font-family:幼圆"><a href="DeleteClassData.aspx?state=normal">正常使用小模块列表</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="DeleteClassData.aspx?state=deleted">已经删除的小模块列表</a></span>
       <p/> <uc2:DeleteClass ID="DeleteClass1" runat="server" />
</div>
    </form>
</body>
</html>
