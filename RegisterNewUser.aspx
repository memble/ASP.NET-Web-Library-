<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RegisterNewUser.aspx.vb" Inherits="RegisterNewUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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

    <form id="form1" runat="server">
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
                    <asp:Label ID="Label1" runat="server" Font-Size="X-Large" 
                        Text="User Registration"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Username"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="Please Enter Username">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TextBox2" ErrorMessage="Please Enter Password">*</asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="Register" />
                    <br />
                    <br />
                    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="45px" />
                </td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>

</body>
</html>
