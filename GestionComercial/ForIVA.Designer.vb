<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForIVA
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
        Dim PorcentajeLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ForIVA))
        Dim NombreLabel As System.Windows.Forms.Label
        Me.DistribuidoraJuguetesDataSet = New GestionComercial.DistribuidoraJuguetesDataSet()
        Me.IVABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IVATableAdapter = New GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.IVATableAdapter()
        Me.TableAdapterManager = New GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.TableAdapterManager()
        Me.IVABindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.IVABindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.TipoTextBox = New System.Windows.Forms.TextBox()
        Me.PorcentajeTextBox = New System.Windows.Forms.TextBox()
        Me.NombreTextBox = New System.Windows.Forms.TextBox()
        TipoLabel = New System.Windows.Forms.Label()
        PorcentajeLabel = New System.Windows.Forms.Label()
        NombreLabel = New System.Windows.Forms.Label()
        CType(Me.DistribuidoraJuguetesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IVABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IVABindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IVABindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'TipoLabel
        '
        TipoLabel.AutoSize = True
        TipoLabel.Location = New System.Drawing.Point(96, 110)
        TipoLabel.Name = "TipoLabel"
        TipoLabel.Size = New System.Drawing.Size(28, 13)
        TipoLabel.TabIndex = 1
        TipoLabel.Text = "Tipo"
        '
        'PorcentajeLabel
        '
        PorcentajeLabel.AutoSize = True
        PorcentajeLabel.Location = New System.Drawing.Point(66, 182)
        PorcentajeLabel.Name = "PorcentajeLabel"
        PorcentajeLabel.Size = New System.Drawing.Size(58, 13)
        PorcentajeLabel.TabIndex = 3
        PorcentajeLabel.Text = "Porcentaje"
        '
        'DistribuidoraJuguetesDataSet
        '
        Me.DistribuidoraJuguetesDataSet.DataSetName = "DistribuidoraJuguetesDataSet"
        Me.DistribuidoraJuguetesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'IVABindingSource
        '
        Me.IVABindingSource.DataMember = "IVA"
        Me.IVABindingSource.DataSource = Me.DistribuidoraJuguetesDataSet
        '
        'IVATableAdapter
        '
        Me.IVATableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ArticulosTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CabPieAlbaranTableAdapter = Nothing
        Me.TableAdapterManager.ClientesTableAdapter = Nothing
        Me.TableAdapterManager.EmpresaTableAdapter = Nothing
        Me.TableAdapterManager.FormasPagoTableAdapter = Nothing
        Me.TableAdapterManager.IVATableAdapter = Me.IVATableAdapter
        Me.TableAdapterManager.LineasAlbaranTableAdapter = Nothing
        Me.TableAdapterManager.ProveedoresTableAdapter = Nothing
        Me.TableAdapterManager.TarifasTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'IVABindingNavigator
        '
        Me.IVABindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.IVABindingNavigator.BindingSource = Me.IVABindingSource
        Me.IVABindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.IVABindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.IVABindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.IVABindingNavigatorSaveItem})
        Me.IVABindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.IVABindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.IVABindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.IVABindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.IVABindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.IVABindingNavigator.Name = "IVABindingNavigator"
        Me.IVABindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.IVABindingNavigator.Size = New System.Drawing.Size(322, 25)
        Me.IVABindingNavigator.TabIndex = 0
        Me.IVABindingNavigator.Text = "BindingNavigator1"
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
        'IVABindingNavigatorSaveItem
        '
        Me.IVABindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.IVABindingNavigatorSaveItem.Image = CType(resources.GetObject("IVABindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.IVABindingNavigatorSaveItem.Name = "IVABindingNavigatorSaveItem"
        Me.IVABindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.IVABindingNavigatorSaveItem.Text = "Guardar datos"
        '
        'TipoTextBox
        '
        Me.TipoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IVABindingSource, "Tipo", True))
        Me.TipoTextBox.Location = New System.Drawing.Point(130, 107)
        Me.TipoTextBox.Name = "TipoTextBox"
        Me.TipoTextBox.Size = New System.Drawing.Size(28, 20)
        Me.TipoTextBox.TabIndex = 2
        '
        'PorcentajeTextBox
        '
        Me.PorcentajeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IVABindingSource, "Porcentaje", True))
        Me.PorcentajeTextBox.Location = New System.Drawing.Point(130, 182)
        Me.PorcentajeTextBox.Name = "PorcentajeTextBox"
        Me.PorcentajeTextBox.Size = New System.Drawing.Size(28, 20)
        Me.PorcentajeTextBox.TabIndex = 4
        '
        'NombreLabel
        '
        NombreLabel.AutoSize = True
        NombreLabel.Location = New System.Drawing.Point(77, 146)
        NombreLabel.Name = "NombreLabel"
        NombreLabel.Size = New System.Drawing.Size(44, 13)
        NombreLabel.TabIndex = 5
        NombreLabel.Text = "Nombre"
        '
        'NombreTextBox
        '
        Me.NombreTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IVABindingSource, "Nombre", True))
        Me.NombreTextBox.Location = New System.Drawing.Point(130, 143)
        Me.NombreTextBox.Name = "NombreTextBox"
        Me.NombreTextBox.Size = New System.Drawing.Size(86, 20)
        Me.NombreTextBox.TabIndex = 6
        '
        'ForIVA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 319)
        Me.Controls.Add(NombreLabel)
        Me.Controls.Add(Me.NombreTextBox)
        Me.Controls.Add(TipoLabel)
        Me.Controls.Add(Me.TipoTextBox)
        Me.Controls.Add(PorcentajeLabel)
        Me.Controls.Add(Me.PorcentajeTextBox)
        Me.Controls.Add(Me.IVABindingNavigator)
        Me.Name = "ForIVA"
        Me.Text = "IVA"
        CType(Me.DistribuidoraJuguetesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IVABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IVABindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IVABindingNavigator.ResumeLayout(False)
        Me.IVABindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DistribuidoraJuguetesDataSet As GestionComercial.DistribuidoraJuguetesDataSet
    Friend WithEvents IVABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IVATableAdapter As GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.IVATableAdapter
    Friend WithEvents TableAdapterManager As GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.TableAdapterManager
    Friend WithEvents IVABindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents IVABindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents TipoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PorcentajeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NombreTextBox As System.Windows.Forms.TextBox
End Class
