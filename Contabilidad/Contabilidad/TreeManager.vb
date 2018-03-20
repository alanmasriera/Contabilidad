Public Class TreeManager
    Dim table As New DataTable
    Dim tree As TreeView
    Dim nodeList As List(Of TreeNode) = New List(Of TreeNode)

    Public Sub GetTree(ByVal t As DataTable, ByVal tv As TreeView)

        table = t
        tree = tv
        tree.Nodes.Clear()
        table.PrimaryKey = New DataColumn() {table.Columns("Id")}
        For Each row As DataRow In table.Rows
            Dim node As New TreeNode
            Dim nodeNum As String = GetNodeNum(row("id")).ToString
            nodeNum = CompletarNuemracion(nodeNum)
            node.Text = nodeNum + " - " + row("Nombre")
            node.Tag = row("id")
            addNode(node, row("ID_NodoPadre"))
        Next
    End Sub

    Private Function GetNodeNum(ByVal id As Integer) As String
        Dim row As DataRow
        Dim parentID As Integer

        row = table.Rows.Find(id)
        parentID = row("ID_NodoPadre")
        If parentID = 0 Then
            Return row("Numeracion").ToString
        Else
            Return GetNodeNum(parentID).ToString + row("Numeracion").ToString
        End If

    End Function

    Private Sub addNode(ByVal node As TreeNode, ByVal idParentNode As Integer)

        If idParentNode = 0 Then
            tree.Nodes.Add(node)
        Else
            GetNodeFromID(idParentNode, nodeList).Nodes.Add(node)
        End If
        nodeList.Add(node)
    End Sub

    Private Function GetNodeFromID(ByVal id As Integer, nodeList As List(Of TreeNode)) As TreeNode
        For Each node As TreeNode In nodeList
            If node.Tag = id Then
                Return node
            End If
        Next
    End Function

    Private Function CompletarNuemracion(ByVal str As String)
        While str.Length < 7
            str = str + "0"
        End While
        Return str
    End Function

End Class
