
Imports System.Data.OleDb

Partial Class InputDenda
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccessDataSource4.SelectCommand = "SELECT [KodeMK], [KodeMK] & "" - "" & [Judul] as Judul FROM [books] ORDER BY [KodeMK], [Judul]"
        If IsPostBack = False Then
            Calendar1.SelectedDate = DateTime.Now
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim msg As String = ""
        If ListMember.Text.Length = 0 Then
            msg += "Member is required<br/>"
        End If
        If DropDownList1.Text.Length = 0 Then
            msg += "Book is required<br/>"
        End If
        Dim value As Integer = 0
        Integer.TryParse(TextBox2.Text, value)
        If value = 0 Then
            msg += "Nilai Denda must be numeric"
        End If
        If msg.Length > 0 Then
            LabelError.Text = msg
            Return
        End If
        LabelError.Text = String.Empty
        Dim tgl As Date = Calendar1.SelectedDate
        Dim connstr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("Database/library.mdb") & ";"
        Dim conn As OleDbConnection = New OleDbConnection(connstr)
        Try
            

            Dim query = String.Format("INSERT INTO denda ( [TglDenda], [KodeMK], [username], [Jumlah], [Status]) values ( @TglDenda, @KodeMK, @username, @Jumlah, 'Belum Dibayar')")
            Dim paramkodemk = New OleDbParameter("@KodeMK", Convert.ToInt32(DropDownList1.SelectedValue))
            Dim paramTglDenda = New OleDbParameter("@TglDenda", tgl.ToString("yyyy-MM-dd hh:mm:ss"))
            Dim paramusername = New OleDbParameter("@username", ListMember.Text)
            Dim paramJumlah = New OleDbParameter("@Jumlah", value)
            Dim cmd As OleDbCommand = New OleDbCommand(query, conn)

            cmd.Parameters.Add(paramTglDenda)
            cmd.Parameters.Add(paramkodemk)
            cmd.Parameters.Add(paramusername)
            cmd.Parameters.Add(paramJumlah)
            conn.Open()
            cmd.ExecuteNonQuery()


            DropDownList1.SelectedIndex = 0
            ListMember.SelectedIndex = 0
            TextBox2.Text = String.Empty
            Calendar1.SelectedDate = DateTime.Now
            Response.Redirect("InputDenda.aspx")
        Catch ex As Exception

            LabelError.Text = "INPUT DENDA FAILED, Message: " & ex.Message
        Finally
            conn.Close()
        End Try

    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim id = GridView1.Rows(e.NewSelectedIndex).Cells(1).Text
        Response.Redirect(String.Format("BayarDenda.aspx?id={0}", id))
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        AccessDataSource4.SelectCommand = "SELECT [KodeMK], [KodeMK] & "" - "" & [Judul] as Judul FROM [books] ORDER BY [KodeMK], [Judul]"
    End Sub
End Class
