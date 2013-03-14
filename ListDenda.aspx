<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="ListDenda.aspx.vb" Inherits="ListDenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" 
            BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            CellSpacing="2" AutoGenerateColumns="False" DataKeyNames="ID" 
            DataSourceID="AccessDataSource2" AllowPaging="True" AllowSorting="True">
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <Columns>
                <asp:CommandField SelectText="Pay" />
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                    SortExpression="ID" Visible="False" />
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
</asp:Content>

