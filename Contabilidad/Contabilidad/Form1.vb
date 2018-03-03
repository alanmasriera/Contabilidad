Imports System.Data.SqlClient
Public Class Form1
    Dim table As New DataTable()
    Dim connection As New SqlConnection("server=(localdb)\Contabilidad; database=Contabilidad")
    Dim tempTreeView As TreeView
    Dim selectedNode As TreeNode
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim command As New SqlCommand("Select * From ArbolCuentas", connection)

        Dim adapter As New SqlDataAdapter(command)


        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadTree()
    End Sub

    Private Sub LoadTree()
        TreeView1.Nodes.Clear()
        For Each row As Data.DataRow In table.Rows
            AddNode(row("ID"), row("Numeracion"), row("Nombre"), row("Id_NodoPadre"))
        Next
    End Sub

    Private Sub AddNode(ByVal id As Integer, ByVal numeracion As Integer, ByVal nombre As String, ByVal parentID As Integer)
        Dim treeNode As New TreeNode
        Dim stNode As New StructNode
        stNode.ID = id
        stNode.Numeracion = numeracion
        stNode.Nombre = nombre
        stNode.Id_NodoPadre = parentID

        treeNode.Text = stNode.Numeracion.ToString + "-" + stNode.Nombre
        treeNode.Tag = stNode

        If parentID = 0 Then
            TreeView1.Nodes.Add(treeNode)
        Else
            GetNodeFromID(parentID, GetAllNodes()).Nodes.Add(treeNode)
        End If

    End Sub
    Private Function GetNodeFromID(ByVal id As Integer, ByVal nodeList As List(Of TreeNode))
        For Each node As TreeNode In nodeList
            If node.Tag.ID = id Then

                Return node
            End If
        Next
    End Function

    Private Function GetAllNodes()
        Dim nodesList As List(Of TreeNode) = New List(Of TreeNode)

        For Each node As System.Windows.Forms.TreeNode In TreeView1.Nodes
            nodesList.Add(node)
            GetAllChildren(node, nodesList)
        Next
        Return nodesList
    End Function
    Sub GetAllChildren(parentNode As TreeNode, nodesList As List(Of TreeNode))
        For Each childNode As TreeNode In parentNode.Nodes
            nodesList.Add(childNode)
            GetAllChildren(childNode, nodesList)
        Next
    End Sub
    Sub GetChildren(parentNode As TreeNode, nodesList As List(Of TreeNode))
        For Each childNode As TreeNode In parentNode.Nodes
            nodesList.Add(childNode)
            GetAllChildren(childNode, nodesList)
        Next
    End Sub

    Structure StructNode
        Dim ID As Integer
        Dim Numeracion As Integer
        Dim Nombre As String
        Dim Id_NodoPadre As Integer
    End Structure

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        TBID.Text = e.Node.Tag.ID
        TBNombre.Text = e.Node.Tag.Nombre
        TBPadre.Text = e.Node.Tag.Id_NodoPadre
        TBNum1.Text = e.Node.Tag.Numeracion.ToString.Substring(0, 1)
        TBNum2.Text = e.Node.Tag.Numeracion.ToString.Substring(1, 1)
        TBNum3.Text = e.Node.Tag.Numeracion.ToString.Substring(2, 1)
        TBNum4.Text = e.Node.Tag.Numeracion.ToString.Substring(3, 1)
        TBNum5.Text = e.Node.Tag.Numeracion.ToString.Substring(4, 1)
        TBNum6y7.Text = e.Node.Tag.Numeracion.ToString.Substring(5, 2)
        selectedNode = e.Node

    End Sub

    Private Sub BModificarNodo_Click(sender As Object, e As EventArgs) Handles BModificarNodo.Click
        TBNumEnabler(True)
        TreeView1.Enabled = False
        TBNombre.Enabled = True
        Dim numeracionPadre As String
        Try
            numeracionPadre = selectedNode.Parent.Tag.Numeracion
        Catch ex As Exception
            Exit Sub
        End Try
        If numeracionPadre.Substring(0, 1) <> 0 Then TBNum1.Enabled = False
        If numeracionPadre.Substring(1, 2) <> 0 Then TBNum2.Enabled = False
        If numeracionPadre.Substring(2, 1) <> 0 Then TBNum3.Enabled = False
        If numeracionPadre.Substring(3, 1) <> 0 Then TBNum4.Enabled = False
        If numeracionPadre.Substring(4, 1) <> 0 Then TBNum5.Enabled = False
        If numeracionPadre.Substring(5, 2) <> 0 Then TBNum6y7.Enabled = False

    End Sub

    Private Sub TBNumEnabler(ByVal b As Boolean)
        TBNum1.Enabled = b
        TBNum2.Enabled = b
        TBNum3.Enabled = b
        TBNum4.Enabled = b
        TBNum5.Enabled = b
        TBNum6y7.Enabled = b
    End Sub

    Private Sub BGuardarModificacion_Click(sender As Object, e As EventArgs) Handles BGuardarModificacion.Click
        TBNumEnabler(False)
        TBNombre.Enabled = False
        TreeView1.Enabled = True
        Dim nuevaNumeracion As Integer = Int(TBNum1.Text + TBNum2.Text + TBNum3.Text + TBNum4.Text + TBNum5.Text + TBNum6y7.Text)
        If Not ValidarNumeracion(selectedNode, nuevaNumeracion) Then
            CancelarModificacion()
            Exit Sub
        End If
        Dim stNode As StructNode = selectedNode.Tag
        stNode.Nombre = TBNombre.Text
            stNode.Numeracion = nuevaNumeracion
            TreeView1.SelectedNode.Text = stNode.Numeracion.ToString + "-" + stNode.Nombre
        TreeView1.SelectedNode.Tag = stNode
        TreeView1.Refresh()

    End Sub

    Private Function ValidarNumeracion(ByVal node As TreeNode, ByVal numeracion As String)
        If node.Level = 0 Then Return True
        Dim padre As New TreeNode
        padre = node.Parent
        Dim brothers As List(Of TreeNode) = New List(Of TreeNode)
        For Each brother As TreeNode In padre.Nodes
            If Not brother.Tag.Equals(node.Tag) Then
                brothers.Add(brother)
            End If

        Next
        'priemro valido que el numero comience igual al del padre
        Dim numPadre As String
        numPadre = padre.Tag.Numeracion
        Dim i As Integer
        For i = 0 To 6
            If i = 6 Then Exit For
            If numPadre.Substring(i, 1) = 0 Then
                Exit For
            ElseIf numPadre.Substring(i, 1) <> numeracion.Substring(i, 1) Then
                MsgBox("La numaracion no continua la numeracion de sus predecesores")
                Return False
            End If
        Next

        'ahora verifico que el numero dsp de su antesesor continue con un numero distonto que 0 y distinto que sus hermanos
        Dim cant As Integer = 1
        If i = 6 Then
            cant = 2
        End If
        For Each brother As TreeNode In brothers
            If brother.Tag.Numeracion.ToString.Substring(i, cant) = numeracion.Substring(i, cant) Then
                MsgBox("Numeracion incorrecta. el numero coincide con el de algun hermano")
                Return False
            End If
        Next


        Return True

    End Function

    Private Sub BCancelarModificacion_Click(sender As Object, e As EventArgs) Handles BCancelarModificacion.Click
        CancelarModificacion()
    End Sub
    Private Sub CancelarModificacion()
        TBNumEnabler(False)
        TBNombre.Enabled = False
        TreeView1.Enabled = True
        TreeView1.SelectedNode = TreeView1.Nodes(0)
    End Sub


    'Private Function GetNumeracionCompleta(ByVal node As TreeNode)
    '    Dim numeracion As Integer
    '    numeracion = GetNumeracionHeredada(node)
    '    numeracion = numeracion + node.Tag.Numeracion.ToString
    '    numeracion = CompleteNumeration(numeracion)

    '    Return numeracion
    'End Function

    'Private Function GetNumeracionHeredada(ByVal node As TreeNode)
    '    Dim numHeredada As Integer
    '    Dim parentNode As TreeNode
    '    Try
    '        parentNode = node.Parent
    '        numHeredada = GetNumeracionHeredada(parentNode) + parentNode.Tag.Numeracion.ToString
    '    Catch
    '        numHeredada = Nothing
    '    End Try


    '    Return numHeredada
    'End Function

    'Private Function CompleteNumeration(ByVal str As String)
    '    While str.Length <7
    '        str = str + "0"
    '    End While
    '    Return str
    'End Function




    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    Dim nodesList As List(Of TreeNode) = New List(Of TreeNode)
    '    nodesList = GetAllNodes()
    '    For Each node As TreeNode In nodesList
    '        Dim num As Integer = GetNumeracionCompleta(node)
    '        Dim stnode As StructNode = node.Tag
    '        stnode.Numeracion = num
    '        node.Tag = stnode
    '    Next
    '    TreeView1.Refresh()
    'End Sub











    'Private Sub TreeView1_BeforeCollapse(sender As Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeCollapse
    '    Me.TreeView1.SelectedNode = e.Node
    'End Sub

    'Private Sub treeview1_beforeexpand(sender As Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
    '    Me.TreeView1.SelectedNode = e.Node
    'End Sub
End Class
