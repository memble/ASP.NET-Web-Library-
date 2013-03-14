
Partial Class Booking_Books
    Inherits System.Web.UI.Page

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        PopulateData()
    End Sub

    Private Sub PopulateData()

        Dim basequery As String = "SELECT * FROM books"
        Dim paramquery As String = String.Empty
        If TextBoxKodeMK.Text.Trim().Length > 0 Then
            Dim val As Integer
            Integer.TryParse(TextBoxKodeMK.Text, val)
            If val > 0 Then
                paramquery = " KodeMK = " & val.ToString() & " "
                LabelErrorKodeMk.Text = String.Empty
            Else
                LabelErrorKodeMk.Text = "Type Data Kode MK Harus Numerik"
                Return
            End If
        End If

        If TextBoxPengarang.Text.Trim().Length > 0 Then
            If (paramquery.Length > 0) Then
                paramquery += " AND "
            End If
            paramquery += " Pengarang LIKE '%" & TextBoxPengarang.Text & "%' "
        End If

        If TextBoxJudul.Text.Trim().Length > 0 Then
            If (paramquery.Length > 0) Then
                paramquery += " AND "
            End If
            paramquery += " Judul LIKE '%" & TextBoxJudul.Text & "%' "
        End If

        If TextBoxPenerbit.Text.Trim().Length > 0 Then
            If (paramquery.Length > 0) Then
                paramquery += " AND "
            End If
            paramquery += " Penerbit LIKE '%" & TextBoxPenerbit.Text & "%' "
        End If

        If paramquery.Length > 0 Then
            basequery += " WHERE Status = 'Available' AND " + paramquery
        Else
            basequery += " WHERE Status = 'Available' "
        End If
        AccessDataSource3.SelectCommand = basequery
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            AccessDataSource3.SelectCommand = "SELECT * FROM books WHERE KodeMK = 0 AND Status = 'Available'"
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim a = e.NewSelectedIndex
        Dim kodemk = GridView1.Rows(e.NewSelectedIndex).Cells(1).Text
        Response.Redirect("BookingDetail.aspx?kodemk=" & kodemk)
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        PopulateData()
    End Sub
End Class
