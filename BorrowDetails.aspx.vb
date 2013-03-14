
Imports System.Data.OleDb

Partial Class BorrowDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim kodemk = Request.QueryString("kodemk")
        Dim member = Request.QueryString("member")
        If String.IsNullOrEmpty(kodemk) AndAlso String.IsNullOrEmpty(member) Then
            Return
        End If

        Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("Database/library.mdb"))


        Dim cmd As OleDbCommand = New OleDbCommand("SELECT KodeMK, Judul, Pengarang, Penerbit FROM books where KodeMK = @KodeMK ", conn)

        cmd.Parameters.Add(New OleDbParameter("@KodeMK", kodemk))

        DropDownList1.Text = member
        Try
            conn.Open()
            Dim read As OleDbDataReader = cmd.ExecuteReader()
            If read.HasRows Then
                read.Read()
                TextBoxKodeMK.Text = read.Item(0).ToString()
                TextBoxJudul.Text = read.Item(1).ToString()
                TextBoxPengarang.Text = read.Item(2).ToString()
                TextBoxPenerbit.Text = read.Item(3).ToString()
                TextBoxTglBooking.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm")
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

    Protected Sub ButtonBookingClick(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonBooking.Click
        Dim startbook = Convert.ToDateTime(TextBoxTglBooking.Text)
        Dim username = DropDownList1.Text
        Const status As String = "Borrowed"
        Dim kodemk = 0
        Integer.TryParse(TextBoxKodeMK.Text, kodemk)

        Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("Database/library.mdb"))


        Dim cmd As OleDbCommand = New OleDbCommand(String.Format("UPDATE books SET [Status] = @Status, TglPinjam = @TglPinjam , BookingBy = @BookingBy where KodeMK=@KodeMK"), conn)
        Dim paramStatus = New OleDbParameter("@Status", status)
        Dim paramTglPinjam = New OleDbParameter("@TglPinjam", startbook)
        Dim paramBookingBy = New OleDbParameter("@BookingBy", username)
        Dim paramKodeMk = New OleDbParameter("@KodeMK", kodemk)
        cmd.Parameters.Add(paramStatus)
        cmd.Parameters.Add(paramTglPinjam)
        cmd.Parameters.Add(paramBookingBy)
        cmd.Parameters.Add(paramKodeMk)

        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            Response.Redirect("Borrow.aspx")
        Catch ex As Exception
            Label4.Text = "BORROW BOOK ERROR, " & ex.Message
        Finally
            conn.Close()
        End Try

    End Sub

    Protected Sub ButtonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Response.Redirect("Borrow.aspx")
    End Sub
End Class
