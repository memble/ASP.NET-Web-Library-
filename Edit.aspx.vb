Imports System.Data
Imports System.Data.OleDb

Partial Class Edit
    Inherits System.Web.UI.Page

    Private connection As OleDbDataAdapter
    Private con As OleDbConnection
    'Private ds As New DataSet()
    'Private query As String = "select * from carddata"
    'Private query As String = "select CardNumber, Names, Address, Phone, Birth, Occupation [Password] from carddata"
    Dim connstr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("Database/library.mdb") & ";"
    'Private conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\Debug\carddata.mdb"
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader


    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim str As String = "select * from books where KodeMK ='" & TextBox1.Text & "'"

        con = New OleDb.OleDbConnection(connstr)

        con.Open()
        cmd = New OleDb.OleDbCommand(str, con)
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            TextBox1.Text = dr(0)
            TextBox2.Text = dr(1)
            TextBox3.Text = dr(2)
            TextBox4.Text = dr(3)
        Else
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""

        End If

        con.Close()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim connstr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("Database/library.mdb") & ";"
        Dim conn As OleDbConnection = New OleDbConnection(connstr)
        conn.Open()
        Dim query As String = "Update books set KodeMK='" & TextBox1.Text & "',Pengarang='" & TextBox2.Text & "',Judul='" & TextBox3.Text & "',Penerbit='" & TextBox4.Text & "' where KodeMK = '" & TextBox1.Text & "'"

        Dim cmd As OleDbCommand = New OleDbCommand(query, conn)

        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    
End Class
