<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Logout.aspx.vb" Inherits="Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<meta http-equiv="refresh" content="5;url=Login.aspx" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .style1
        {
            height: 98px;
        }
        .style2
        {
            height: 23px;
        }
        .style3
        {
            height: 23px;
            width: 266px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style1" colspan="3" style="text-align: center">
                    <img alt="" src="Pictures/banner_big.jpg" style="height: 96px; width: 844px" /></td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
            </tr>
        </table>
        <br />
        <table style="width: 106%; height: 254px;">
            <tr bgcolor="#FFE697">
                <td class="style3">
                </td>
                <td class="style2" valign="top">
                    <asp:Label ID="LabelLog" runat="server" Font-Size="X-Large" Text="Log In"></asp:Label>
                    <br />
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Goto Login Page</asp:HyperLink>
                </td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
