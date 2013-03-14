
Imports System.Data.OleDb

Partial Class DeleteDetails
    Inherits System.Web.UI.Page

    Protected Sub ButtonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Response.Redirect("Delete.aspx")
    End Sub

    Protected Sub ButtonDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click

        Dim kodemk = 0
        Integer.TryParse(TextBoxKodeMK.Text, kodemk)

        Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("Database/library.mdb"))


        Dim cmd As OleDbCommand = New OleDbCommand(String.Format("DELETE FROM books WHERE KodeMK=@KodeMK"), conn)
        Dim paramKodeMK = New OleDbParameter("@KodeMK", kodemk)
        cmd.Parameters.Add(paramKodeMK)

        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Response.Redirect("BookingBooks.aspx")
        Catch ex As Exception
            Label4.Text = "DELETE BOOK ERROR, " & ex.Message
        Finally
            conn.Close()
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim kodemk = Request.QueryString("kodemk")
        If String.IsNullOrEmpty(kodemk) Then
            Return
        End If

        Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("Database/library.mdb"))


        Dim cmd As OleDbCommand = New OleDbCommand("SELECT KodeMK, Judul, Pengarang, Penerbit FROM books where KodeMK = @KodeMK", conn)

        cmd.Parameters.Add(New OleDbParameter("@KodeMK", kodemk))


        Try
            conn.Open()
            Dim read As OleDbDataReader = cmd.ExecuteReader()
            If read.HasRows Then
                read.Read()
                TextBoxKodeMK.Text = read.Item(0).ToString()
                TextBoxJudul.Text = read.Item(1).ToString()
                TextBoxPengarang.Text = read.Item(2).ToString()
                TextBoxPenerbit.Text = read.Item(3).ToString()
            Else
                LabelError.Text = "Data Not Found"
            End If
            read.Close()
        Catch ex As Exception
            Response.Write(ex.Message())
        Finally
            conn.Close()
        End Try

    End Sub
End Class
