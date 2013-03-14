
Imports System.Data.OleDb
Imports System.Data

Partial Class ReturnOnBookDetails
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

    Protected Sub ButtonReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
        Dim startbook As DateTime
        Dim kodemk = 0
        Integer.TryParse(TextBoxKodeMK.Text, kodemk)
        If kodemk = 0 Then
            LabelError.Text = "Error Kode Buku = 0"
            Return
        End If
        Dim value As Integer
        Try
            value = Convert.ToInt32(TextBoxDenda.Text)
        Catch ex As Exception
            LabelError.Text = "Error Nilai Denda, message: " + ex.Message
            Return
        End Try

        Try
            startbook = Convert.ToDateTime(TextBoxTglBooking.Text)
        Catch ex As Exception
            LabelError.Text = "Error Tanggal Pengembalian, message: " + ex.Message
            Return
        End Try

        Dim username = DropDownList1.Text
        Const status As String = "Available"
        

        Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("Database/library.mdb"))

        Dim cmd As OleDbCommand = New OleDbCommand(String.Format("UPDATE books SET [Status] = @Status, TglKembali = @TglKembali where KodeMK=@KodeMK"), conn)
        Dim paramStatus = New OleDbParameter("@Status", status)
        Dim paramTglPinjam = New OleDbParameter("@TglKembali", startbook)
        Dim paramKodeMk = New OleDbParameter("@KodeMK", kodemk)
        cmd.Parameters.Add(paramStatus)
        cmd.Parameters.Add(paramTglPinjam)
        cmd.Parameters.Add(paramKodeMk)
        Dim transaction As OleDbTransaction
        conn.Open()
        transaction = conn.BeginTransaction()
        cmd.Transaction = transaction
        Try
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            If (value <> 0) Then
                cmd.CommandText = "INSERT INTO denda ( [TglDenda], [KodeMK], [username], [Jumlah], [Status]) values ( @TglKembali, @KodeMK, @username, @Jumlah, 'Belum Dibayar')"
                cmd.Parameters.Add(paramTglPinjam)
                cmd.Parameters.Add(paramKodeMk)
                cmd.Parameters.Add(New OleDbParameter("@username", username))
                cmd.Parameters.Add(New OleDbParameter("@Jumlah", value))
                cmd.ExecuteNonQuery()
            End If
            transaction.Commit()
            conn.Close()
            ButtonReturn.Enabled = False
            ButtonCancel.Text = "Back To Return On Book List"
            LabelError.Text = "Return Book has been submitted"
            'Response.Redirect("ReturnOnBook.aspx")
        Catch ex As Exception
            LabelError.Text = "RETURN BOOK ERROR, " & ex.Message
            transaction.Rollback()
        Finally

        End Try
    End Sub

    Protected Sub ButtonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Response.Redirect("ReturnOnBook.aspx")
    End Sub
End Class
