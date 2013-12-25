<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="CheckUserState.aspx.cs" Inherits="Admin_CheckUserState" Title="无标题页" %>

<%@ Register src="UserControl/showUserState.ascx" tagname="showUserState" tagprefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
a{TEXT-DECORATION:none}

</style>
    <link href="Css/AllPage.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   
      
        <div id="UserStateInfo">
            <div id="StateMesu">
                 <span><a href="CheckUserState.aspx?state=normal">正常状态列表</a></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <span><a href="CheckUserState.aspx?state=forbid">禁言状态列表</a></span>
            </div>
            <div id="UserState">
               
                <uc1:showUserState ID="showUserState1" runat="server" />
               
            </div>
        </div>
   </form>
</body>
</html>

