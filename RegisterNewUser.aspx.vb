Imports System.Data.OleDb

Partial Class RegisterNewUser
    Inherits System.Web.UI.Page

    Protected Sub Button2Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("Database/library.mdb"))


        Dim cmd As OleDbCommand = New OleDbCommand(String.Format("SELECT Username, Password, UserRole FROM login where Username=@Username"), conn)
        Dim parameter = New OleDbParameter("@Username", TextBox1.Text)
        cmd.Parameters.Add(parameter)
        Dim result As Boolean = True

        Try
            conn.Open()
            Dim read As OleDbDataReader = cmd.ExecuteReader()
            If read.HasRows Then
                Label4.Text = "User Name " & TextBox1.Text & " Already Registered, please choose another username "
                result = False
            End If
            read.Close()
        Catch ex As Exception
            Label4.Text = "REGISTER USER ERROR, " & ex.Message
        Finally
            conn.Close()
        End Try

        If result Then
            Try
                cmd.Parameters.Clear()
                cmd.CommandText = "INSERT INTO login ([username], [password], [UserRole]) values (@Username, @Password, @UserRole)"
                cmd.Parameters.Add(New OleDbParameter("@Username", TextBox1.Text))
                cmd.Parameters.Add(New OleDbParameter("@Password", TextBox2.Text))
                cmd.Parameters.Add(New OleDbParameter("@UserRole", "student"))
                conn.Open()
                Dim i = cmd.ExecuteNonQuery()
                conn.Close()
                Response.Redirect("Login.aspx")
            Catch ex As Exception
                Label4.Text = "REGISTER USER ERROR, " & ex.Message
            End Try

        End If

    End Sub
End Class
