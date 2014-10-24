<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForEmpresa
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
        Dim RazonLabel As System.Windows.Forms.Label
        Dim NifLabel As System.Windows.Forms.Label
        Dim DomicilioLabel As System.Windows.Forms.Label
        Dim CpLabel As System.Windows.Forms.Label
        Dim LocalidadLabel As System.Windows.Forms.Label
        Dim ProvinciaLabel As System.Windows.Forms.Label
        Dim TelefonoLabel As System.Windows.Forms.Label
        Dim EmailLabel As System.Windows.Forms.Label
        Dim GerenteLabel As System.Windows.Forms.Label
        Dim TelefonogerenteLabel As System.Windows.Forms.Label
        Dim DireccionentregaLabel As System.Windows.Forms.Label
        Dim BancopreferenteLabel As System.Windows.Forms.Label
        Dim CuentaLabel As System.Windows.Forms.Label
        Dim WebLabel As System.Windows.Forms.Label
        Dim LogotipoLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ForEmpresa))
        Me.DistribuidoraJuguetesDataSet = New GestionComercial.DistribuidoraJuguetesDataSet()
        Me.EmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmpresaTableAdapter = New GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.EmpresaTableAdapter()
        Me.TableAdapterManager = New GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.TableAdapterManager()
        Me.EmpresaBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.EmpresaBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.RazonTextBox = New System.Windows.Forms.TextBox()
        Me.NifTextBox = New System.Windows.Forms.TextBox()
        Me.DomicilioTextBox = New System.Windows.Forms.TextBox()
        Me.CpTextBox = New System.Windows.Forms.TextBox()
        Me.LocalidadTextBox = New System.Windows.Forms.TextBox()
        Me.ProvinciaTextBox = New System.Windows.Forms.TextBox()
        Me.TelefonoTextBox = New System.Windows.Forms.TextBox()
        Me.EmailTextBox = New System.Windows.Forms.TextBox()
        Me.GerenteTextBox = New System.Windows.Forms.TextBox()
        Me.TelefonogerenteTextBox = New System.Windows.Forms.TextBox()
        Me.DireccionentregaTextBox = New System.Windows.Forms.TextBox()
        Me.BancopreferenteTextBox = New System.Windows.Forms.TextBox()
        Me.CuentaTextBox = New System.Windows.Forms.TextBox()
        Me.WebTextBox = New System.Windows.Forms.TextBox()
        Me.LogotipoTextBox = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        RazonLabel = New System.Windows.Forms.Label()
        NifLabel = New System.Windows.Forms.Label()
        DomicilioLabel = New System.Windows.Forms.Label()
        CpLabel = New System.Windows.Forms.Label()
        LocalidadLabel = New System.Windows.Forms.Label()
        ProvinciaLabel = New System.Windows.Forms.Label()
        TelefonoLabel = New System.Windows.Forms.Label()
        EmailLabel = New System.Windows.Forms.Label()
        GerenteLabel = New System.Windows.Forms.Label()
        TelefonogerenteLabel = New System.Windows.Forms.Label()
        DireccionentregaLabel = New System.Windows.Forms.Label()
        BancopreferenteLabel = New System.Windows.Forms.Label()
        CuentaLabel = New System.Windows.Forms.Label()
        WebLabel = New System.Windows.Forms.Label()
        LogotipoLabel = New System.Windows.Forms.Label()
        CType(Me.DistribuidoraJuguetesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpresaBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpresaBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'RazonLabel
        '
        RazonLabel.AutoSize = True
        RazonLabel.Location = New System.Drawing.Point(12, 34)
        RazonLabel.Name = "RazonLabel"
        RazonLabel.Size = New System.Drawing.Size(70, 13)
        RazonLabel.TabIndex = 1
        RazonLabel.Text = "Razón Social"
        '
        'NifLabel
        '
        NifLabel.AutoSize = True
        NifLabel.Location = New System.Drawing.Point(12, 73)
        NifLabel.Name = "NifLabel"
        NifLabel.Size = New System.Drawing.Size(24, 13)
        NifLabel.TabIndex = 3
        NifLabel.Text = "NIF"
        '
        'DomicilioLabel
        '
        DomicilioLabel.AutoSize = True
        DomicilioLabel.Location = New System.Drawing.Point(102, 34)
        DomicilioLabel.Name = "DomicilioLabel"
        DomicilioLabel.Size = New System.Drawing.Size(49, 13)
        DomicilioLabel.TabIndex = 5
        DomicilioLabel.Text = "Domicilio"
        '
        'CpLabel
        '
        CpLabel.AutoSize = True
        CpLabel.Location = New System.Drawing.Point(102, 73)
        CpLabel.Name = "CpLabel"
        CpLabel.Size = New System.Drawing.Size(49, 13)
        CpLabel.TabIndex = 7
        CpLabel.Text = "C. Postal"
        '
        'LocalidadLabel
        '
        LocalidadLabel.AutoSize = True
        LocalidadLabel.Location = New System.Drawing.Point(174, 73)
        LocalidadLabel.Name = "LocalidadLabel"
        LocalidadLabel.Size = New System.Drawing.Size(53, 13)
        LocalidadLabel.TabIndex = 9
        LocalidadLabel.Text = "Localidad"
        '
        'ProvinciaLabel
        '
        ProvinciaLabel.AutoSize = True
        ProvinciaLabel.Location = New System.Drawing.Point(12, 112)
        ProvinciaLabel.Name = "ProvinciaLabel"
        ProvinciaLabel.Size = New System.Drawing.Size(51, 13)
        ProvinciaLabel.TabIndex = 11
        ProvinciaLabel.Text = "Provincia"
        '
        'TelefonoLabel
        '
        TelefonoLabel.AutoSize = True
        TelefonoLabel.Location = New System.Drawing.Point(103, 112)
        TelefonoLabel.Name = "TelefonoLabel"
        TelefonoLabel.Size = New System.Drawing.Size(49, 13)
        TelefonoLabel.TabIndex = 13
        TelefonoLabel.Text = "Teléfono"
        AddHandler TelefonoLabel.Click, AddressOf Me.TelefonoLabel_Click
        '
        'EmailLabel
        '
        EmailLabel.AutoSize = True
        EmailLabel.Location = New System.Drawing.Point(174, 112)
        EmailLabel.Name = "EmailLabel"
        EmailLabel.Size = New System.Drawing.Size(32, 13)
        EmailLabel.TabIndex = 15
        EmailLabel.Text = "Email"
        '
        'GerenteLabel
        '
        GerenteLabel.AutoSize = True
        GerenteLabel.Location = New System.Drawing.Point(12, 151)
        GerenteLabel.Name = "GerenteLabel"
        GerenteLabel.Size = New System.Drawing.Size(45, 13)
        GerenteLabel.TabIndex = 17
        GerenteLabel.Text = "Gerente"
        '
        'TelefonogerenteLabel
        '
        TelefonogerenteLabel.AutoSize = True
        TelefonogerenteLabel.Location = New System.Drawing.Point(101, 151)
        TelefonogerenteLabel.Name = "TelefonogerenteLabel"
        TelefonogerenteLabel.Size = New System.Drawing.Size(67, 13)
        TelefonogerenteLabel.TabIndex = 19
        TelefonogerenteLabel.Text = "Tfn. Gerente"
        '
        'DireccionentregaLabel
        '
        DireccionentregaLabel.AutoSize = True
        DireccionentregaLabel.Location = New System.Drawing.Point(174, 151)
        DireccionentregaLabel.Name = "DireccionentregaLabel"
        DireccionentregaLabel.Size = New System.Drawing.Size(63, 13)
        DireccionentregaLabel.TabIndex = 21
        DireccionentregaLabel.Text = "Dir. Entrega"
        '
        'BancopreferenteLabel
        '
        BancopreferenteLabel.AutoSize = True
        BancopreferenteLabel.Location = New System.Drawing.Point(11, 188)
        BancopreferenteLabel.Name = "BancopreferenteLabel"
        BancopreferenteLabel.Size = New System.Drawing.Size(38, 13)
        BancopreferenteLabel.TabIndex = 23
        BancopreferenteLabel.Text = "Banco"
        '
        'CuentaLabel
        '
        CuentaLabel.AutoSize = True
        CuentaLabel.Location = New System.Drawing.Point(120, 188)
        CuentaLabel.Name = "CuentaLabel"
        CuentaLabel.Size = New System.Drawing.Size(86, 13)
        CuentaLabel.TabIndex = 25
        CuentaLabel.Text = "Cuenta Corriente"
        '
        'WebLabel
        '
        WebLabel.AutoSize = True
        WebLabel.Location = New System.Drawing.Point(12, 227)
        WebLabel.Name = "WebLabel"
        WebLabel.Size = New System.Drawing.Size(30, 13)
        WebLabel.TabIndex = 27
        WebLabel.Text = "Web"
        '
        'LogotipoLabel
        '
        LogotipoLabel.AutoSize = True
        LogotipoLabel.Location = New System.Drawing.Point(12, 266)
        LogotipoLabel.Name = "LogotipoLabel"
        LogotipoLabel.Size = New System.Drawing.Size(48, 13)
        LogotipoLabel.TabIndex = 29
        LogotipoLabel.Text = "Logotipo"
        '
        'DistribuidoraJuguetesDataSet
        '
        Me.DistribuidoraJuguetesDataSet.DataSetName = "DistribuidoraJuguetesDataSet"
        Me.DistribuidoraJuguetesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmpresaBindingSource
        '
        Me.EmpresaBindingSource.DataMember = "Empresa"
        Me.EmpresaBindingSource.DataSource = Me.DistribuidoraJuguetesDataSet
        '
        'EmpresaTableAdapter
        '
        Me.EmpresaTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ArticulosTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CabPieAlbaranTableAdapter = Nothing
        Me.TableAdapterManager.ClientesTableAdapter = Nothing
        Me.TableAdapterManager.EmpresaTableAdapter = Me.EmpresaTableAdapter
        Me.TableAdapterManager.FormasPagoTableAdapter = Nothing
        Me.TableAdapterManager.IVATableAdapter = Nothing
        Me.TableAdapterManager.LineasAlbaranTableAdapter = Nothing
        Me.TableAdapterManager.ProveedoresTableAdapter = Nothing
        Me.TableAdapterManager.TarifasTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'EmpresaBindingNavigator
        '
        Me.EmpresaBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.EmpresaBindingNavigator.BindingSource = Me.EmpresaBindingSource
        Me.EmpresaBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.EmpresaBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.EmpresaBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.EmpresaBindingNavigatorSaveItem})
        Me.EmpresaBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.EmpresaBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.EmpresaBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.EmpresaBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.EmpresaBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.EmpresaBindingNavigator.Name = "EmpresaBindingNavigator"
        Me.EmpresaBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.EmpresaBindingNavigator.Size = New System.Drawing.Size(322, 25)
        Me.EmpresaBindingNavigator.TabIndex = 0
        Me.EmpresaBindingNavigator.Text = "BindingNavigator1"
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
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(38, 22)
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
        'EmpresaBindingNavigatorSaveItem
        '
        Me.EmpresaBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EmpresaBindingNavigatorSaveItem.Image = CType(resources.GetObject("EmpresaBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.EmpresaBindingNavigatorSaveItem.Name = "EmpresaBindingNavigatorSaveItem"
        Me.EmpresaBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.EmpresaBindingNavigatorSaveItem.Text = "Guardar datos"
        '
        'RazonTextBox
        '
        Me.RazonTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "razon", True))
        Me.RazonTextBox.Location = New System.Drawing.Point(12, 50)
        Me.RazonTextBox.Name = "RazonTextBox"
        Me.RazonTextBox.Size = New System.Drawing.Size(82, 20)
        Me.RazonTextBox.TabIndex = 2
        '
        'NifTextBox
        '
        Me.NifTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "nif", True))
        Me.NifTextBox.Location = New System.Drawing.Point(12, 89)
        Me.NifTextBox.Name = "NifTextBox"
        Me.NifTextBox.Size = New System.Drawing.Size(82, 20)
        Me.NifTextBox.TabIndex = 4
        '
        'DomicilioTextBox
        '
        Me.DomicilioTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "domicilio", True))
        Me.DomicilioTextBox.Location = New System.Drawing.Point(105, 50)
        Me.DomicilioTextBox.Name = "DomicilioTextBox"
        Me.DomicilioTextBox.Size = New System.Drawing.Size(204, 20)
        Me.DomicilioTextBox.TabIndex = 6
        '
        'CpTextBox
        '
        Me.CpTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "cp", True))
        Me.CpTextBox.Location = New System.Drawing.Point(105, 89)
        Me.CpTextBox.Name = "CpTextBox"
        Me.CpTextBox.Size = New System.Drawing.Size(66, 20)
        Me.CpTextBox.TabIndex = 8
        '
        'LocalidadTextBox
        '
        Me.LocalidadTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "localidad", True))
        Me.LocalidadTextBox.Location = New System.Drawing.Point(177, 89)
        Me.LocalidadTextBox.Name = "LocalidadTextBox"
        Me.LocalidadTextBox.Size = New System.Drawing.Size(132, 20)
        Me.LocalidadTextBox.TabIndex = 10
        '
        'ProvinciaTextBox
        '
        Me.ProvinciaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "provincia", True))
        Me.ProvinciaTextBox.Location = New System.Drawing.Point(12, 128)
        Me.ProvinciaTextBox.Name = "ProvinciaTextBox"
        Me.ProvinciaTextBox.Size = New System.Drawing.Size(79, 20)
        Me.ProvinciaTextBox.TabIndex = 12
        '
        'TelefonoTextBox
        '
        Me.TelefonoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "telefono", True))
        Me.TelefonoTextBox.Location = New System.Drawing.Point(105, 128)
        Me.TelefonoTextBox.Name = "TelefonoTextBox"
        Me.TelefonoTextBox.Size = New System.Drawing.Size(66, 20)
        Me.TelefonoTextBox.TabIndex = 14
        '
        'EmailTextBox
        '
        Me.EmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "email", True))
        Me.EmailTextBox.Location = New System.Drawing.Point(177, 128)
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(132, 20)
        Me.EmailTextBox.TabIndex = 16
        '
        'GerenteTextBox
        '
        Me.GerenteTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "gerente", True))
        Me.GerenteTextBox.Location = New System.Drawing.Point(12, 167)
        Me.GerenteTextBox.Name = "GerenteTextBox"
        Me.GerenteTextBox.Size = New System.Drawing.Size(82, 20)
        Me.GerenteTextBox.TabIndex = 18
        '
        'TelefonogerenteTextBox
        '
        Me.TelefonogerenteTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "telefonogerente", True))
        Me.TelefonogerenteTextBox.Location = New System.Drawing.Point(105, 167)
        Me.TelefonogerenteTextBox.Name = "TelefonogerenteTextBox"
        Me.TelefonogerenteTextBox.Size = New System.Drawing.Size(66, 20)
        Me.TelefonogerenteTextBox.TabIndex = 20
        '
        'DireccionentregaTextBox
        '
        Me.DireccionentregaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "direccionentrega", True))
        Me.DireccionentregaTextBox.Location = New System.Drawing.Point(177, 167)
        Me.DireccionentregaTextBox.Name = "DireccionentregaTextBox"
        Me.DireccionentregaTextBox.Size = New System.Drawing.Size(132, 20)
        Me.DireccionentregaTextBox.TabIndex = 22
        '
        'BancopreferenteTextBox
        '
        Me.BancopreferenteTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "bancopreferente", True))
        Me.BancopreferenteTextBox.Location = New System.Drawing.Point(12, 204)
        Me.BancopreferenteTextBox.Name = "BancopreferenteTextBox"
        Me.BancopreferenteTextBox.Size = New System.Drawing.Size(98, 20)
        Me.BancopreferenteTextBox.TabIndex = 24
        '
        'CuentaTextBox
        '
        Me.CuentaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "cuenta", True))
        Me.CuentaTextBox.Location = New System.Drawing.Point(123, 204)
        Me.CuentaTextBox.Name = "CuentaTextBox"
        Me.CuentaTextBox.Size = New System.Drawing.Size(186, 20)
        Me.CuentaTextBox.TabIndex = 26
        '
        'WebTextBox
        '
        Me.WebTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "web", True))
        Me.WebTextBox.Location = New System.Drawing.Point(12, 243)
        Me.WebTextBox.Name = "WebTextBox"
        Me.WebTextBox.Size = New System.Drawing.Size(297, 20)
        Me.WebTextBox.TabIndex = 28
        '
        'LogotipoTextBox
        '
        Me.LogotipoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpresaBindingSource, "logotipo", True))
        Me.LogotipoTextBox.Location = New System.Drawing.Point(12, 282)
        Me.LogotipoTextBox.Name = "LogotipoTextBox"
        Me.LogotipoTextBox.Size = New System.Drawing.Size(297, 20)
        Me.LogotipoTextBox.TabIndex = 30
        '
        'ForEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 319)
        Me.Controls.Add(RazonLabel)
        Me.Controls.Add(Me.RazonTextBox)
        Me.Controls.Add(NifLabel)
        Me.Controls.Add(Me.NifTextBox)
        Me.Controls.Add(DomicilioLabel)
        Me.Controls.Add(Me.DomicilioTextBox)
        Me.Controls.Add(CpLabel)
        Me.Controls.Add(Me.CpTextBox)
        Me.Controls.Add(LocalidadLabel)
        Me.Controls.Add(Me.LocalidadTextBox)
        Me.Controls.Add(ProvinciaLabel)
        Me.Controls.Add(Me.ProvinciaTextBox)
        Me.Controls.Add(TelefonoLabel)
        Me.Controls.Add(Me.TelefonoTextBox)
        Me.Controls.Add(EmailLabel)
        Me.Controls.Add(Me.EmailTextBox)
        Me.Controls.Add(GerenteLabel)
        Me.Controls.Add(Me.GerenteTextBox)
        Me.Controls.Add(TelefonogerenteLabel)
        Me.Controls.Add(Me.TelefonogerenteTextBox)
        Me.Controls.Add(DireccionentregaLabel)
        Me.Controls.Add(Me.DireccionentregaTextBox)
        Me.Controls.Add(BancopreferenteLabel)
        Me.Controls.Add(Me.BancopreferenteTextBox)
        Me.Controls.Add(CuentaLabel)
        Me.Controls.Add(Me.CuentaTextBox)
        Me.Controls.Add(WebLabel)
        Me.Controls.Add(Me.WebTextBox)
        Me.Controls.Add(LogotipoLabel)
        Me.Controls.Add(Me.LogotipoTextBox)
        Me.Controls.Add(Me.EmpresaBindingNavigator)
        Me.Name = "ForEmpresa"
        Me.Text = "EMPRESA"
        CType(Me.DistribuidoraJuguetesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpresaBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpresaBindingNavigator.ResumeLayout(False)
        Me.EmpresaBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DistribuidoraJuguetesDataSet As GestionComercial.DistribuidoraJuguetesDataSet
    Friend WithEvents EmpresaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmpresaTableAdapter As GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.EmpresaTableAdapter
    Friend WithEvents TableAdapterManager As GestionComercial.DistribuidoraJuguetesDataSetTableAdapters.TableAdapterManager
    Friend WithEvents EmpresaBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents EmpresaBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents RazonTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NifTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DomicilioTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CpTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LocalidadTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProvinciaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TelefonoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GerenteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TelefonogerenteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DireccionentregaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BancopreferenteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CuentaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents WebTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LogotipoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
