Imports System.Data.OleDb
Imports System.Web.UI.Control

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("Database/library.mdb"))


        Dim cmd As OleDbCommand = New OleDbCommand("SELECT Username, Password, UserRole FROM login where user='" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'", conn)

        cmd.Parameters.AddWithValue("@Username", TextBox1.Text)
        cmd.Parameters.AddWithValue("@Password", TextBox2.Text)


        Try
            conn.Open()
            Dim read As OleDbDataReader = cmd.ExecuteReader()
            If read.HasRows Then
                read.Read()
                If HttpContext.Current.User IsNot Nothing Then
                    If HttpContext.Current.User.Identity.IsAuthenticated Then
                        Web.Security.FormsAuthentication.SignOut()
                    End If
                End If
                If Context.Session IsNot Nothing Then
                    Context.Session.RemoveAll()
                End If
                If Context.Session IsNot Nothing Then
                    Context.Session.Add("USERNAME", TextBox1.Text)
                End If
                Web.Security.FormsAuthentication.SetAuthCookie(TextBox1.Text, False)
                Label4.Text = "Log In Success"
                Dim role = read.Item(2).ToString()
                If role.ToLower().Equals("admin") Then
                    Context.Session.Add("USERROLE", "admin")

                Else
                    Context.Session.Add("USERROLE", "student")
                    'Response.Redirect("HomepageS.aspx")
                End If
                Response.Redirect("Homepage.aspx")
            Else
                Label4.Text = "Log In Failed"
            End If
            read.Close()
        Catch ex As Exception
            Response.Write(ex.Message())
        Finally
            conn.Close()
        End Try

        If Label4.Text = "Log In Success" Then

        End If

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("RegisterNewUser.aspx")
    End Sub
End Class
