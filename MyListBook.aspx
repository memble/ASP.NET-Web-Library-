<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="MyListBook.aspx.vb" Inherits="MyListBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" CellSpacing="2" DataKeyNames="KodeMK" 
        DataSourceID="AccessDataSource3" AllowPaging="True" AllowSorting="True">
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <Columns>
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

<p>
    <asp:AccessDataSource ID="AccessDataSource3" runat="server" 
        DataFile="~/Database/library.mdb" SelectCommand="SELECT * FROM Books">
    </asp:AccessDataSource>
</p>
</asp:Content>

