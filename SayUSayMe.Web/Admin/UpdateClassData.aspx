<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateClassData.aspx.cs" Inherits="Admin_UpdateClassData" validateRequest="false" EnableEventValidation="false" %>

<%@ Register src="UserControl/UpdateClass.ascx" tagname="UpdateClass" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:UpdateClass ID="UpdateClass1" runat="server" />
    </div>
    </form>
</body>
</html>
