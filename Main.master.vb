
Partial Class Main
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Context.Session("USERROLE") Is Nothing Then
            Response.Redirect("Logout.aspx?mode=expired")
        End If
        Dim role = Context.Session("USERROLE").ToString()
        If String.IsNullOrEmpty(role) Then
            Response.Redirect("Login.aspx")
            Return
        End If
        TreeView1.Nodes.Clear()


        If role.ToLower().Equals("admin") Then
            TreeView1.Nodes.Add(GetHomeNode())
            TreeView1.Nodes(0).ChildNodes.Add(GetSearchNode())
            TreeView1.Nodes(0).ChildNodes.Add(GetInputNode())
            TreeView1.Nodes(0).ChildNodes.Add(GetDeleteNode())
            TreeView1.Nodes(0).ChildNodes.Add(GetBookingNode())
            TreeView1.Nodes(0).ChildNodes.Add(GetBorrowNode())
            TreeView1.Nodes(0).ChildNodes.Add(GetReturnOnBookNode())
            TreeView1.Nodes(0).ChildNodes.Add(GetAmercementNode())
            TreeView1.Nodes(0).ChildNodes.Add(GetListAmercementNode())
            TreeView1.Nodes.Add(GetLogoutNode())
        Else
            TreeView1.Nodes.Add(GetHomeNode())
            TreeView1.Nodes(0).ChildNodes.Add(GetSearchNode())
            TreeView1.Nodes(0).ChildNodes.Add(GetBookingNode())
            TreeView1.Nodes(0).ChildNodes.Add(GetMyListBookNode())
            TreeView1.Nodes(0).ChildNodes.Add(GetListAmercementNode())
            TreeView1.Nodes.Add(GetLogoutNode())
        End If

        TreeView1.ExpandAll()

    End Sub

    Private Function GetReturnOnBookNode() As TreeNode
        Dim node = New TreeNode()
        node.Text = "Return On Book"
        node.NavigateUrl = "ReturnOnBook.aspx"
        Return node
    End Function

    Private Function GetMyListBookNode() As TreeNode
        Dim node = New TreeNode()
        node.Text = "My List Book"
        node.NavigateUrl = "MyListBook.aspx"
        Return node
    End Function

    Private Function GetLogoutNode() As TreeNode
        Dim node = New TreeNode()
        node.Text = "Logout"
        node.NavigateUrl = "Logout.aspx"
        Return node
    End Function

    Private Function GetAmercementNode() As TreeNode
        Dim node = New TreeNode()
        node.Text = "Amercement"
        node.NavigateUrl = "InputDenda.aspx"
        Return node
    End Function

    Private Function GetListAmercementNode() As TreeNode
        Dim node = New TreeNode()
        node.Text = "My List Amercement"
        node.NavigateUrl = "ListDenda.aspx"
        Return node
    End Function

    Private Function GetBorrowNode() As TreeNode
        Dim node = New TreeNode()
        node.Text = "Borrow"
        node.NavigateUrl = "Borrow.aspx"
        Return node
    End Function

    Private Function GetInputNode() As TreeNode
        Dim node = New TreeNode()
        node.Text = "Input New Books"
        node.NavigateUrl = "Input.aspx"
        Return node
    End Function

    Private Function GetSearchNode() As TreeNode
        Dim node = New TreeNode()
        node.Text = "Search Books"
        node.NavigateUrl = "Search.aspx"
        Return node
    End Function

    Private Function GetHomeNode() As TreeNode
        Dim node = New TreeNode()
        node.Text = "Home"
        node.NavigateUrl = "Homepage.aspx"
        Return node
    End Function

    Private Function GetBookingNode() As TreeNode
        Dim node = New TreeNode()
        node.Text = "Booking"
        node.NavigateUrl = "BookingBooks.aspx"
        Return node
    End Function

    Private Function GetDeleteNode() As TreeNode
        Dim node = New TreeNode()
        node.Text = "Delete Books"
        node.NavigateUrl = "Delete.aspx"
        Return node
    End Function

End Class

