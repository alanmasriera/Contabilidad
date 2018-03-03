<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.BModificarNodo = New System.Windows.Forms.Button()
        Me.TBID = New System.Windows.Forms.TextBox()
        Me.TBNombre = New System.Windows.Forms.TextBox()
        Me.TBPadre = New System.Windows.Forms.TextBox()
        Me.TBNum1 = New System.Windows.Forms.TextBox()
        Me.TBNum2 = New System.Windows.Forms.TextBox()
        Me.TBNum3 = New System.Windows.Forms.TextBox()
        Me.TBNum4 = New System.Windows.Forms.TextBox()
        Me.TBNum5 = New System.Windows.Forms.TextBox()
        Me.TBNum6y7 = New System.Windows.Forms.TextBox()
        Me.BGuardarModificacion = New System.Windows.Forms.Button()
        Me.BCancelarModificacion = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(99, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 72)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(439, 281)
        Me.DataGridView1.TabIndex = 1
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(471, 23)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(250, 373)
        Me.TreeView1.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(174, 367)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BModificarNodo
        '
        Me.BModificarNodo.Location = New System.Drawing.Point(782, 23)
        Me.BModificarNodo.Name = "BModificarNodo"
        Me.BModificarNodo.Size = New System.Drawing.Size(363, 53)
        Me.BModificarNodo.TabIndex = 4
        Me.BModificarNodo.Text = "Modificar Cuenta"
        Me.BModificarNodo.UseVisualStyleBackColor = True
        '
        'TBID
        '
        Me.TBID.Enabled = False
        Me.TBID.Location = New System.Drawing.Point(782, 106)
        Me.TBID.Name = "TBID"
        Me.TBID.Size = New System.Drawing.Size(100, 20)
        Me.TBID.TabIndex = 5
        '
        'TBNombre
        '
        Me.TBNombre.Enabled = False
        Me.TBNombre.Location = New System.Drawing.Point(920, 106)
        Me.TBNombre.Name = "TBNombre"
        Me.TBNombre.Size = New System.Drawing.Size(100, 20)
        Me.TBNombre.TabIndex = 6
        '
        'TBPadre
        '
        Me.TBPadre.Enabled = False
        Me.TBPadre.Location = New System.Drawing.Point(1045, 106)
        Me.TBPadre.Name = "TBPadre"
        Me.TBPadre.Size = New System.Drawing.Size(100, 20)
        Me.TBPadre.TabIndex = 7
        '
        'TBNum1
        '
        Me.TBNum1.Enabled = False
        Me.TBNum1.Location = New System.Drawing.Point(782, 168)
        Me.TBNum1.Name = "TBNum1"
        Me.TBNum1.Size = New System.Drawing.Size(19, 20)
        Me.TBNum1.TabIndex = 8
        '
        'TBNum2
        '
        Me.TBNum2.Enabled = False
        Me.TBNum2.Location = New System.Drawing.Point(807, 168)
        Me.TBNum2.Name = "TBNum2"
        Me.TBNum2.Size = New System.Drawing.Size(19, 20)
        Me.TBNum2.TabIndex = 9
        '
        'TBNum3
        '
        Me.TBNum3.Enabled = False
        Me.TBNum3.Location = New System.Drawing.Point(832, 168)
        Me.TBNum3.Name = "TBNum3"
        Me.TBNum3.Size = New System.Drawing.Size(19, 20)
        Me.TBNum3.TabIndex = 10
        '
        'TBNum4
        '
        Me.TBNum4.Enabled = False
        Me.TBNum4.Location = New System.Drawing.Point(857, 168)
        Me.TBNum4.Name = "TBNum4"
        Me.TBNum4.Size = New System.Drawing.Size(19, 20)
        Me.TBNum4.TabIndex = 11
        '
        'TBNum5
        '
        Me.TBNum5.Enabled = False
        Me.TBNum5.Location = New System.Drawing.Point(882, 168)
        Me.TBNum5.Name = "TBNum5"
        Me.TBNum5.Size = New System.Drawing.Size(19, 20)
        Me.TBNum5.TabIndex = 12
        '
        'TBNum6y7
        '
        Me.TBNum6y7.Enabled = False
        Me.TBNum6y7.Location = New System.Drawing.Point(907, 168)
        Me.TBNum6y7.Name = "TBNum6y7"
        Me.TBNum6y7.Size = New System.Drawing.Size(31, 20)
        Me.TBNum6y7.TabIndex = 13
        '
        'BGuardarModificacion
        '
        Me.BGuardarModificacion.Location = New System.Drawing.Point(782, 212)
        Me.BGuardarModificacion.Name = "BGuardarModificacion"
        Me.BGuardarModificacion.Size = New System.Drawing.Size(363, 53)
        Me.BGuardarModificacion.TabIndex = 14
        Me.BGuardarModificacion.Text = "Guardar"
        Me.BGuardarModificacion.UseVisualStyleBackColor = True
        '
        'BCancelarModificacion
        '
        Me.BCancelarModificacion.Location = New System.Drawing.Point(782, 282)
        Me.BCancelarModificacion.Name = "BCancelarModificacion"
        Me.BCancelarModificacion.Size = New System.Drawing.Size(363, 25)
        Me.BCancelarModificacion.TabIndex = 15
        Me.BCancelarModificacion.Text = "Cancelar"
        Me.BCancelarModificacion.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 442)
        Me.Controls.Add(Me.BCancelarModificacion)
        Me.Controls.Add(Me.BGuardarModificacion)
        Me.Controls.Add(Me.TBNum6y7)
        Me.Controls.Add(Me.TBNum5)
        Me.Controls.Add(Me.TBNum4)
        Me.Controls.Add(Me.TBNum3)
        Me.Controls.Add(Me.TBNum2)
        Me.Controls.Add(Me.TBNum1)
        Me.Controls.Add(Me.TBPadre)
        Me.Controls.Add(Me.TBNombre)
        Me.Controls.Add(Me.TBID)
        Me.Controls.Add(Me.BModificarNodo)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents Button2 As Button
    Friend WithEvents BModificarNodo As Button
    Friend WithEvents TBID As TextBox
    Friend WithEvents TBNombre As TextBox
    Friend WithEvents TBPadre As TextBox
    Friend WithEvents TBNum1 As TextBox
    Friend WithEvents TBNum2 As TextBox
    Friend WithEvents TBNum3 As TextBox
    Friend WithEvents TBNum4 As TextBox
    Friend WithEvents TBNum5 As TextBox
    Friend WithEvents TBNum6y7 As TextBox
    Friend WithEvents BGuardarModificacion As Button
    Friend WithEvents BCancelarModificacion As Button
End Class
