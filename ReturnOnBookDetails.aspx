<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="ReturnOnBookDetails.aspx.vb" Inherits="ReturnOnBookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 196px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width:100%;">
        <tr>
            <td class="style4">
                <asp:Label ID="Label8" runat="server" Text="Member"></asp:Label>
            </td>
            <td class="style5">
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        DataSourceID="AccessDataSource1" Width="235px" DataTextField="username" 
                        DataValueField="username" Enabled="False">
                    </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label3" runat="server" Text="Kode MK"></asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="TextBoxKodeMK" runat="server" Width="235px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label4" runat="server" Text="Pengarang"></asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="TextBoxPengarang" runat="server" Width="235px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label5" runat="server" Text="Judul"></asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="TextBoxJudul" runat="server" Width="235px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label6" runat="server" Text="Penerbit"></asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="TextBoxPenerbit" runat="server" Width="235px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label7" runat="server" Text="Tgl Pengembalian"></asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="TextBoxTglBooking" runat="server" Width="235px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Denda</td>
            <td class="style5">
                <asp:TextBox ID="TextBoxDenda" runat="server" Width="235px">0</asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                <asp:Label ID="LabelError" runat="server" ForeColor="#FF3300"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                <asp:Button ID="ButtonReturn" runat="server" Text="Return" />
&nbsp;&nbsp;
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" />
                <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                    DataFile="~/Database/library.mdb" 
                    SelectCommand="SELECT [username] FROM [login] ORDER BY [username]">
                </asp:AccessDataSource>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

