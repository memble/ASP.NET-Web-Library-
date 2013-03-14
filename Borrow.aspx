<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="Borrow.aspx.vb" Inherits="Borrow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 122px;
        }
        .style5
        {
            width: 250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="Borrow Books"></asp:Label>
</p>
        <table style="width:100%;">
            <tr>
                <td class="style4">
                    <asp:Label ID="Label7" runat="server" Text="Member"></asp:Label>
                </td>
                <td class="style5">
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        DataSourceID="AccessDataSource4" Width="235px" DataTextField="username" 
                        DataValueField="username" AutoPostBack="True">
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
                    <asp:TextBox ID="TextBoxKodeMK" runat="server" Width="235px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelErrorKodeMk" runat="server" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label4" runat="server" Text="Pengarang"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="TextBoxPengarang" runat="server" Width="235px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label5" runat="server" Text="Judul"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="TextBoxJudul" runat="server" Width="235px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label6" runat="server" Text="Penerbit"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="TextBoxPenerbit" runat="server" Width="235px"></asp:TextBox>
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
                    &nbsp;</td>
            </tr>
        </table>
    <p>
        <asp:Button ID="ButtonSearch" runat="server" Text="Search" />
    &nbsp;&nbsp;
        <asp:Button ID="ButtonClear" runat="server" Text="Clear" />
    &nbsp;
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" CellSpacing="2" DataKeyNames="KodeMK" 
        DataSourceID="AccessDataSource3" AllowPaging="True" AllowSorting="True">
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectText="Borrow"  />
            <asp:BoundField DataField="KodeMK" HeaderText="KodeMK" ReadOnly="True" 
                SortExpression="KodeMK" />
            <asp:BoundField DataField="Judul" HeaderText="Judul" SortExpression="Judul" />
            <asp:BoundField DataField="Pengarang" HeaderText="Pengarang" 
                SortExpression="Pengarang" />
            <asp:BoundField DataField="Penerbit" HeaderText="Penerbit" 
                SortExpression="Penerbit" />
            <asp:BoundField DataField="Status" HeaderText="Status" 
                SortExpression="Status" />
            <asp:BoundField DataField="TglPinjam" HeaderText="TglPinjam" 
                SortExpression="TglPinjam" />
            <asp:BoundField DataField="TglKembali" HeaderText="TglKembali" 
                SortExpression="TglKembali" />
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource4" runat="server" 
            DataFile="~/Database/library.mdb" 
            SelectCommand="SELECT [username] FROM [login] ORDER BY [username]">
        </asp:AccessDataSource>
</p>
<p>
    <asp:AccessDataSource ID="AccessDataSource3" runat="server" 
        DataFile="~/Database/library.mdb" SelectCommand="SELECT * FROM Books">
    </asp:AccessDataSource>
</p>
</asp:Content>

