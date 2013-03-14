<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="InputDenda.aspx.vb" Inherits="InputDenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 106px;
        }
        .style5
        {
            width: 240px;
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
                    <asp:Calendar ID="Calendar1" runat="server">
                        <SelectedDayStyle BackColor="#FF6666" />
                        <TodayDayStyle BackColor="#6699FF" BorderColor="#9900FF" />
                    </asp:Calendar>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Member</td>
                <td class="style5">
                    <asp:DropDownList ID="ListMember" Width="235px" runat="server" 
                        DataSourceID="AccessDataSource3" DataTextField="username" 
                        DataValueField="username">
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
                    <asp:DropDownList ID="DropDownList1" Width="235px" runat="server" 
                        DataSourceID="AccessDataSource4" DataTextField="Judul" 
                        DataValueField="KodeMK">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label4" runat="server" Text="Jumlah Denda"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="TextBox2" runat="server" Width="235px"></asp:TextBox>
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
        <asp:Button ID="Button1" runat="server" Text="Save"/>
    &nbsp;<asp:AccessDataSource ID="AccessDataSource3" runat="server" 
            DataFile="~/Database/library.mdb" 
            SelectCommand="SELECT [username] FROM [login] ORDER BY [username]">
        </asp:AccessDataSource>
        <asp:AccessDataSource ID="AccessDataSource4" runat="server" 
            DataFile="~/Database/library.mdb" 
            
            SelectCommand="SELECT [KodeMK], [Judul] FROM [books] ORDER BY [KodeMK], [Judul]">
        </asp:AccessDataSource>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" 
            BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            CellSpacing="2" AutoGenerateColumns="False" DataKeyNames="ID" 
            DataSourceID="AccessDataSource2" AllowPaging="True" AllowSorting="True">
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Pay" />
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                    SortExpression="ID" />
                <asp:BoundField DataField="TglDenda" HeaderText="TglDenda" 
                    SortExpression="TglDenda" DataFormatString="{0:d}" />
                <asp:BoundField DataField="username" HeaderText="username" 
                    SortExpression="username" />
                <asp:BoundField DataField="KodeMK" HeaderText="KodeMK" 
                    SortExpression="KodeMK" />
                <asp:BoundField DataField="Jumlah" HeaderText="Jumlah" 
                    SortExpression="Jumlah" />
                <asp:BoundField DataField="Status" HeaderText="Status" 
                    SortExpression="Status" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource2" runat="server" 
            DataFile="~/Database/library.mdb" 
            SelectCommand="SELECT * FROM [denda] ORDER BY [TglDenda]">
        </asp:AccessDataSource>
    </p>
    <p>
    </p>
</asp:Content>

