﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="BayarDenda.aspx.vb" Inherits="BayarDenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 176px;
        }
        .style5
        {
            width: 250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
        <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="Denda"></asp:Label>
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="style4">
                    <asp:Label ID="Label5" runat="server" Text="Tanggal Denda"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="TextBoxTanggalDenda" runat="server" Width="235px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Member</td>
                <td class="style5">
                    <asp:TextBox ID="TextBoxMember" runat="server" Width="235px" ReadOnly="True"></asp:TextBox>
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
                    <asp:Label ID="Label4" runat="server" Text="Jumlah Denda"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="TextBoxDenda" runat="server" Width="235px" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="LabelError" runat="server" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
            </table>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonPay" runat="server" Text="Pay" Width="70px"/>
    &nbsp;&nbsp;
    &nbsp;<asp:Button ID="ButtonCancel" runat="server" Text="Cancel" Width="70px"/>
    </p>

</asp:Content>

