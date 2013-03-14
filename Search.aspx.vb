
Partial Class Search
    Inherits System.Web.UI.Page

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
            basequery += " WHERE " + paramquery
        Else
            basequery += " WHERE KodeMK > 0"
        End If
        AccessDataSource2.SelectCommand = basequery
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            AccessDataSource2.SelectCommand = "SELECT * FROM books WHERE KodeMK = 0"
        Else
            'PopulateData()
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        AccessDataSource2.SelectCommand = "SELECT * FROM books WHERE KodeMK = 0"
        TextBoxKodeMK.Text = String.Empty
        TextBoxPengarang.Text = String.Empty
        TextBoxJudul.Text = String.Empty
        TextBoxPenerbit.Text = String.Empty
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        PopulateData()
    End Sub
End Class
