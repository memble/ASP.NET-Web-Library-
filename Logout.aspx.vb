
Partial Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim query = Request.QueryString("mode")
        If String.IsNullOrEmpty(query) Then
            LabelLog.Text = "<strong>Terima kasih " & HttpContext.Current.User.Identity.Name & "</strong>, Page akan di redirect ke Page Login setelah 5 detik"
        ElseIf query.ToLower().Equals("expired") Then
            LabelLog.Text = "<strong>Session telah Expired</strong>, Page akan di redirect ke Page Login setelah 5 detik"
        End If


        Web.Security.FormsAuthentication.SignOut()
        Context.Session.RemoveAll()
    End Sub
End Class
