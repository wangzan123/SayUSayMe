<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserGrade.aspx.cs" Inherits="Admin_UserGrade" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>等级：</td>
                <td><asp:TextBox runat="server" ID="gradeID"></asp:TextBox></td>
            </tr>
            <tr>
                <td>等级所需积分：</td>
                <td><asp:TextBox runat="server" ID="gradScore"></asp:TextBox></td>
            </tr>
            <tr>
                <td>图片数：</td>
                <td><img src="../image/grade/level1.gif" /><asp:TextBox runat="server" ID="level1"></asp:TextBox></td>
            </tr>
            <tr>
                <td>图片数：</td>
                <td><img src="../image/grade/level2.gif" /><asp:TextBox runat="server" ID="level2"></asp:TextBox></td>
            </tr>
            <tr>
                <td>图片数：</td>
                <td><img src="../image/grade/level3.gif" /><asp:TextBox runat="server" ID="level3"></asp:TextBox></td>
            </tr>
            <tr>
                <td>图片数：</td>
                <td><img src="../image/grade/level4.gif" /><asp:TextBox runat="server" ID="level4"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button runat="server" Text="确定" ID="addBtn" OnClick="addBtnClick" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
