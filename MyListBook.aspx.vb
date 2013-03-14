
Partial Class MyListBook
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Context.Session("USERNAME") Is Nothing Then
            Response.Redirect("Logout.aspx?mode=expired")
        End If
        Dim username = Context.Session("USERNAME").ToString()
        Dim role = Context.Session("USERROLE").ToString()
        If String.IsNullOrEmpty(username) Then
            Response.Redirect("Login.aspx")
            Return
        End If
        AccessDataSource3.SelectCommand = "SELECT * FROM [books] WHERE  BookingBy = '" & username & "' AND [Status] <> 'Available' ORDER BY [KodeMK]"
    End Sub
End Class
