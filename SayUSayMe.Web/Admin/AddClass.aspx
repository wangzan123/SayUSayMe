<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddClass.aspx.cs" Inherits="Admin_AddClass" %>

<%@ Register src="UserControl/AddClass.ascx" tagname="AddClass" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="Css/AllPage.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:AddClass ID="AddClass1" runat="server" />
    </div>
    </form>
</body>
</html>
