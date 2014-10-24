<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForFormasPago
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
        Me.components = New System.ComponentModel.Container()
        Dim TipoLabel As System.Windows.Forms.Label
        Dim NombreLabel As System.Windows.Forms.Label
        Dim RecibosLabel As System.Windows.Forms.Label
        Dim IntervaloTiempoLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ForFormasPago))
        Me.DistribuidoraJuguetesDataSet = New GestionComercial.DistribuidoraJuguetesDataSet()
        Me.FormasPagoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FormasPagoTableAdapter = New GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.FormasPagoTableAdapter()
        Me.TableAdapterManager = New GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.TableAdapterManager()
        Me.FormasPagoBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.FormasPagoBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.TipoTextBox = New System.Windows.Forms.TextBox()
        Me.NombreTextBox = New System.Windows.Forms.TextBox()
        Me.RecibosTextBox = New System.Windows.Forms.TextBox()
        Me.IntervaloTiempoTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        TipoLabel = New System.Windows.Forms.Label()
        NombreLabel = New System.Windows.Forms.Label()
        RecibosLabel = New System.Windows.Forms.Label()
        IntervaloTiempoLabel = New System.Windows.Forms.Label()
        CType(Me.DistribuidoraJuguetesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FormasPagoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FormasPagoBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FormasPagoBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'TipoLabel
        '
        TipoLabel.AutoSize = True
        TipoLabel.Location = New System.Drawing.Point(114, 113)
        TipoLabel.Name = "TipoLabel"
        TipoLabel.Size = New System.Drawing.Size(28, 13)
        TipoLabel.TabIndex = 1
        TipoLabel.Text = "Tipo"
        '
        'NombreLabel
        '
        NombreLabel.AutoSize = True
        NombreLabel.Location = New System.Drawing.Point(96, 142)
        NombreLabel.Name = "NombreLabel"
        NombreLabel.Size = New System.Drawing.Size(44, 13)
        NombreLabel.TabIndex = 3
        NombreLabel.Text = "Nombre"
        '
        'RecibosLabel
        '
        RecibosLabel.AutoSize = True
        RecibosLabel.Location = New System.Drawing.Point(96, 168)
        RecibosLabel.Name = "RecibosLabel"
        RecibosLabel.Size = New System.Drawing.Size(46, 13)
        RecibosLabel.TabIndex = 5
        RecibosLabel.Text = "Recibos"
        '
        'IntervaloTiempoLabel
        '
        IntervaloTiempoLabel.AutoSize = True
        IntervaloTiempoLabel.Location = New System.Drawing.Point(53, 194)
        IntervaloTiempoLabel.Name = "IntervaloTiempoLabel"
        IntervaloTiempoLabel.Size = New System.Drawing.Size(86, 13)
        IntervaloTiempoLabel.TabIndex = 7
        IntervaloTiempoLabel.Text = "Intervalo Tiempo"
        '
        'DistribuidoraJuguetesDataSet
        '
        Me.DistribuidoraJuguetesDataSet.DataSetName = "DistribuidoraJuguetesDataSet"
        Me.DistribuidoraJuguetesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FormasPagoBindingSource
        '
        Me.FormasPagoBindingSource.DataMember = "FormasPago"
        Me.FormasPagoBindingSource.DataSource = Me.DistribuidoraJuguetesDataSet
        '
        'FormasPagoTableAdapter
        '
        Me.FormasPagoTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ArticulosTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CabPieAlbaranTableAdapter = Nothing
        Me.TableAdapterManager.ClientesTableAdapter = Nothing
        Me.TableAdapterManager.EmpresaTableAdapter = Nothing
        Me.TableAdapterManager.FormasPagoTableAdapter = Me.FormasPagoTableAdapter
        Me.TableAdapterManager.IVATableAdapter = Nothing
        Me.TableAdapterManager.LineasAlbaranTableAdapter = Nothing
        Me.TableAdapterManager.ProveedoresTableAdapter = Nothing
        Me.TableAdapterManager.TarifasTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'FormasPagoBindingNavigator
        '
        Me.FormasPagoBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.FormasPagoBindingNavigator.BindingSource = Me.FormasPagoBindingSource
        Me.FormasPagoBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.FormasPagoBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.FormasPagoBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.FormasPagoBindingNavigatorSaveItem})
        Me.FormasPagoBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.FormasPagoBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.FormasPagoBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.FormasPagoBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.FormasPagoBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.FormasPagoBindingNavigator.Name = "FormasPagoBindingNavigator"
        Me.FormasPagoBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.FormasPagoBindingNavigator.Size = New System.Drawing.Size(322, 25)
        Me.FormasPagoBindingNavigator.TabIndex = 0
        Me.FormasPagoBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Agregar nuevo"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Eliminar"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'FormasPagoBindingNavigatorSaveItem
        '
        Me.FormasPagoBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FormasPagoBindingNavigatorSaveItem.Image = CType(resources.GetObject("FormasPagoBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.FormasPagoBindingNavigatorSaveItem.Name = "FormasPagoBindingNavigatorSaveItem"
        Me.FormasPagoBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.FormasPagoBindingNavigatorSaveItem.Text = "Guardar datos"
        '
        'TipoTextBox
        '
        Me.TipoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FormasPagoBindingSource, "tipo", True))
        Me.TipoTextBox.Location = New System.Drawing.Point(147, 113)
        Me.TipoTextBox.Name = "TipoTextBox"
        Me.TipoTextBox.Size = New System.Drawing.Size(34, 20)
        Me.TipoTextBox.TabIndex = 2
        '
        'NombreTextBox
        '
        Me.NombreTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FormasPagoBindingSource, "nombre", True))
        Me.NombreTextBox.Location = New System.Drawing.Point(147, 139)
        Me.NombreTextBox.Name = "NombreTextBox"
        Me.NombreTextBox.Size = New System.Drawing.Size(118, 20)
        Me.NombreTextBox.TabIndex = 4
        '
        'RecibosTextBox
        '
        Me.RecibosTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FormasPagoBindingSource, "recibos", True))
        Me.RecibosTextBox.Location = New System.Drawing.Point(147, 165)
        Me.RecibosTextBox.Name = "RecibosTextBox"
        Me.RecibosTextBox.Size = New System.Drawing.Size(34, 20)
        Me.RecibosTextBox.TabIndex = 6
        '
        'IntervaloTiempoTextBox
        '
        Me.IntervaloTiempoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FormasPagoBindingSource, "intervaloTiempo", True))
        Me.IntervaloTiempoTextBox.Location = New System.Drawing.Point(147, 191)
        Me.IntervaloTiempoTextBox.Name = "IntervaloTiempoTextBox"
        Me.IntervaloTiempoTextBox.Size = New System.Drawing.Size(34, 20)
        Me.IntervaloTiempoTextBox.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(188, 194)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "(En días)"
        '
        'ForFormasPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 319)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(TipoLabel)
        Me.Controls.Add(Me.TipoTextBox)
        Me.Controls.Add(NombreLabel)
        Me.Controls.Add(Me.NombreTextBox)
        Me.Controls.Add(RecibosLabel)
        Me.Controls.Add(Me.RecibosTextBox)
        Me.Controls.Add(IntervaloTiempoLabel)
        Me.Controls.Add(Me.IntervaloTiempoTextBox)
        Me.Controls.Add(Me.FormasPagoBindingNavigator)
        Me.Name = "ForFormasPago"
        Me.Text = "FORMAS DE PAGO"
        CType(Me.DistribuidoraJuguetesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FormasPagoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FormasPagoBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FormasPagoBindingNavigator.ResumeLayout(False)
        Me.FormasPagoBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DistribuidoraJuguetesDataSet As GestionComercial.DistribuidoraJuguetesDataSet
    Friend WithEvents FormasPagoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FormasPagoTableAdapter As GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.FormasPagoTableAdapter
    Friend WithEvents TableAdapterManager As GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.TableAdapterManager
    Friend WithEvents FormasPagoBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FormasPagoBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents TipoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NombreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RecibosTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IntervaloTiempoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
