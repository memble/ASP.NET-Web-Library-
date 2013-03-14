Imports System.Data
Imports System.Data.OleDb

Partial Class Homepage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' clear booking status
        Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("Database/library.mdb"))
        Const status As String = "Available"

        Dim cmd As OleDbCommand = New OleDbCommand(String.Format("UPDATE books SET [Status] = @Status where [Status] = 'Booked' AND TglAkhirBooking < @TglAkhirBooking"), conn)
        Dim paramStatus = New OleDbParameter("@Status", status)
        Dim paramTglAkhirBooking = New OleDbParameter("@TglAkhirBooking", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"))
        cmd.Parameters.Add(paramStatus)
        cmd.Parameters.Add(paramTglAkhirBooking)
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Response.Write("UPDATE BOOK ERROR, " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
End Class
