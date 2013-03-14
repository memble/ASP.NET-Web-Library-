<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="Delete.aspx.vb" Inherits="Delete" title="Untitled Page" Debug="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .style4
        {
            width: 91px;
        }
        .style5
        {
            width: 191px;
        }
        .style6
        {
            width: 172px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="height: 28px">
        <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="Delete Books"></asp:Label>
    </p>
    <p style="height: 84px">
        <table style="width: 100%; height: 105px;">
            <tr>
                <td class="style4">
                    <asp:Label ID="Label3" runat="server" Text="Kode MK"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="TextBoxKodeMK" runat="server" Width="210px"></asp:TextBox>
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
                    <asp:TextBox ID="TextBoxPengarang" runat="server" Width="210px"></asp:TextBox>
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label5" runat="server" Text="Judul"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="TextBoxJudul" runat="server" Width="210px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label6" runat="server" Text="Penerbit"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="TextBoxPenerbit" runat="server" Width="210px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Button ID="Button1" runat="server" Text="Search" />
                    &nbsp;
                    <asp:Button ID="Button2" runat="server" Text="Clear" />
                </td>
                <td>
                    
                </td>
            </tr>
        </table>
         <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" 
                    BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    CellSpacing="2" AutoGenerateColumns="False" DataKeyNames="KodeMK" 
                    DataSourceID="AccessDataSource2" AllowPaging="True" 
            AllowSorting="True">
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <Columns>
                        <asp:CommandField SelectText="Delete" ShowSelectButton="True" />
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
                <asp:AccessDataSource ID="AccessDataSource2" runat="server" 
                    DataFile="~/Database/library.mdb" SelectCommand="SELECT * FROM books">
                </asp:AccessDataSource>
    </p>
    <p style="height: 6px">
        &nbsp;</p>
    <p style="height: 23px">
        &nbsp;</p>
    <p style="height: 23px">
        &nbsp;</p>
    <p style="height: 118px">
        &nbsp;</p>
</asp:Content>

