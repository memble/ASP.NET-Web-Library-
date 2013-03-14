Imports System.Data
Imports System.Data.OleDb

Partial Class Input
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Dim connstr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("Database/library.mdb") & ";"
            Dim conn As OleDbConnection = New OleDbConnection(connstr)
            conn.Open()
            Dim query = String.Format("INSERT INTO books (KodeMK, Judul, Pengarang, Penerbit, Status) values (@KodeMK, @Judul, @Pengarang, @Penerbit, 'Available')")
            Dim paramkodemk = New OleDbParameter("@KodeMK", TextBox1.Text)
            Dim paramJudul = New OleDbParameter("@Judul", TextBox3.Text)
            Dim paramPengarang = New OleDbParameter("@Pengarang", TextBox2.Text)
            Dim paramPenerbit = New OleDbParameter("@Penerbit", TextBox4.Text)
            Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
            'cmd.Parameters.AddRange(New object[]{paramkodemk, paramJudul})
            cmd.Parameters.Add(paramkodemk)
            cmd.Parameters.Add(paramJudul)
            cmd.Parameters.Add(paramPengarang)
            cmd.Parameters.Add(paramPenerbit)
            cmd.ExecuteNonQuery()
            conn.Close()
            AccessDataSource2.SelectCommand = "SELECT * FROM books WHERE KodeMK = " & TextBox1.Text
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
            TextBox3.Text = String.Empty
            TextBox4.Text = String.Empty
            LabelError.Text = String.Empty
        Catch ex As Exception

            LabelError.Text = "INPUT BUKU FAILED, Message: " & ex.Message

        End Try

    End Sub
End Class
