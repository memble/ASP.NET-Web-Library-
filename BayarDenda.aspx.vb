
Imports System.Data.OleDb

Partial Class BayarDenda
    Inherits System.Web.UI.Page

    Protected Sub ButtonPay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPay.Click
        LabelError.Text = String.Empty
        Dim tgl As DateTime
        Try
            tgl = Convert.ToDateTime(TextBoxTanggalDenda.Text)
        Catch ex As Exception
            LabelError.Text = ex.Message
            Return
        End Try
        Dim id = Request.QueryString("id")
        Dim connstr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("Database/library.mdb") & ";"
        Dim conn As OleDbConnection = New OleDbConnection(connstr)
        Try


            Dim query = String.Format("UPDATE denda set [Status] = 'Sudah Dibayar' WHERE ID = @ID")
            Dim paramid = New OleDbParameter("@ID", id)
            Dim cmd As OleDbCommand = New OleDbCommand(query, conn)

            cmd.Parameters.Add(paramid)
            conn.Open()
            cmd.ExecuteNonQuery()

            Response.Redirect("InputDenda.aspx")
        Catch ex As Exception

            LabelError.Text = "INPUT DENDA FAILED, Message: " & ex.Message
        Finally
            conn.Close()
        End Try
    End Sub

    Protected Sub ButtonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Response.Redirect("InputDenda.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id = Request.QueryString("id")
        If String.IsNullOrEmpty(id) Then
            Return
        End If

        Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("Database/library.mdb"))


        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM denda where ID = @ID ", conn)

        cmd.Parameters.Add(New OleDbParameter("@ID", id))


        Try
            conn.Open()
            Dim read As OleDbDataReader = cmd.ExecuteReader()
            If read.HasRows Then
                read.Read()
                TextBoxKodeMK.Text = read.Item(3).ToString()
                TextBoxTanggalDenda.Text = Convert.ToDateTime(read.Item(1)).ToString("dd-MMM-yyyy hh:mm")
                TextBoxMember.Text = read.Item(2).ToString()
                TextBoxDenda.Text = read.Item(4).ToString()
                If read.Item(5).ToString().ToLower().Equals("sudah dibayar") Then
                    ButtonPay.Enabled = False
                    LabelError.Text = "Denda sudah dibayar"
                End If

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
End Class
