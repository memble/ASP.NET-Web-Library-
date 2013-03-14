
Partial Class ListDenda
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Context.Session("USERNAME") Is Nothing Then
            Response.Redirect("Logout.aspx?mode=expired")
        End If
        PopulateData()

    End Sub

    Private Sub PopulateData()

        Dim username = Context.Session("USERNAME").ToString()
        If String.IsNullOrEmpty(username) Then
            Response.Redirect("Login.aspx")
            Return
        End If

        Dim role = Context.Session("USERROLE").ToString()

        If role.ToLower().Equals("admin") Then
            AccessDataSource2.SelectCommand = "SELECT * FROM [denda] ORDER BY [TglDenda]"
        Else
            AccessDataSource2.SelectCommand = "SELECT * FROM [denda] WHERE username = '" & username & "' ORDER BY [TglDenda]"
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        PopulateData()
    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging

    End Sub
End Class
