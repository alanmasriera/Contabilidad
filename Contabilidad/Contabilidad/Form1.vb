Imports System.Data.SqlClient
Public Class Form1
    Dim table As New DataTable
    Dim connection As New SqlConnection("server=(localdb)\Contabilidad; database=Contabilidad")
    Dim tempTreeView As TreeView
    Dim selectedNode As TreeNode
    Dim treeManager As New TreeManager()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim command As New SqlCommand("Select * From ArbolCuentas", connection)

        Dim adapter As New SqlDataAdapter(command)


        adapter.Fill(table)
        DataGridView1.DataSource = table
        table.PrimaryKey = New DataColumn() {table.Columns("Id")}
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.DataSource = table
        treeManager.GetTree(table, TVCuentas)
        TVCuentas.Refresh()
    End Sub









    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TVCuentas.AfterSelect
        Dim row As DataRow
        row = table.Rows.Find(e.Node.Tag)
        TBID.Text = row("id")
        TBNombre.Text = row("Nombre")
        TBPadre.Text = row("Id_NodoPadre")
        TBNum.Text = e.Node.Text.ToString.Substring(0, 7)
        TBLvl.Text = row("Nivel")

        selectedNode = e.Node

    End Sub

    Private Sub BModificarNodo_Click(sender As Object, e As EventArgs) Handles BModificarNodo.Click
        TVCuentas.Enabled = False
        TBNombre.Enabled = True
        TBNum.Enabled = False



    End Sub



    Private Sub BGuardarModificacion_Click(sender As Object, e As EventArgs) Handles BGuardarModificacion.Click

        TBNombre.Enabled = False
        TVCuentas.Enabled = True
        Dim r As DataRow
        r = table.Rows.Find(TBID.Text)
        r("Nombre") = TBNombre.Text
        treeManager.GetTree(table, TVCuentas)
        TVCuentas.Refresh()
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
        TBNombre.Enabled = False
        TVCuentas.Enabled = True
        TVCuentas.SelectedNode = TVCuentas.Nodes(0)
    End Sub

    Private Sub BAgregar_Click(sender As Object, e As EventArgs) Handles BAgregar.Click
        TVCuentas.Refresh()
    End Sub


















    'Private Sub TreeView1_BeforeCollapse(sender As Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeCollapse
    '    Me.TreeView1.SelectedNode = e.Node
    'End Sub

    'Private Sub treeview1_beforeexpand(sender As Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
    '    Me.TreeView1.SelectedNode = e.Node
    'End Sub
End Class
