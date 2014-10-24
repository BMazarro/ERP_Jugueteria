<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForFacturarClientes
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ForFacturarClientes))
        Me.dgcliente = New System.Windows.Forms.DataGridView()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgalbaranSF = New System.Windows.Forms.DataGridView()
        Me.cod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoIva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.formapago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ButtonSalir = New System.Windows.Forms.Button()
        Me.ButtonFacturar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboBuscar = New System.Windows.Forms.ComboBox()
        Me.tbcliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonBuscarCli = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgcliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgalbaranSF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgcliente
        '
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgcliente.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgcliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgcliente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.nombre, Me.nif})
        Me.dgcliente.Location = New System.Drawing.Point(20, 128)
        Me.dgcliente.Name = "dgcliente"
        Me.dgcliente.ReadOnly = True
        Me.dgcliente.Size = New System.Drawing.Size(516, 62)
        Me.dgcliente.TabIndex = 0
        '
        'codigo
        '
        Me.codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigo.DefaultCellStyle = DataGridViewCellStyle11
        Me.codigo.HeaderText = "Código"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        '
        'nombre
        '
        Me.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombre.DefaultCellStyle = DataGridViewCellStyle12
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        '
        'nif
        '
        Me.nif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nif.DefaultCellStyle = DataGridViewCellStyle13
        Me.nif.HeaderText = "NIF"
        Me.nif.Name = "nif"
        Me.nif.ReadOnly = True
        '
        'dgalbaranSF
        '
        Me.dgalbaranSF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgalbaranSF.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cod, Me.fecha, Me.importe, Me.tipoIva, Me.formapago})
        Me.dgalbaranSF.Location = New System.Drawing.Point(18, 60)
        Me.dgalbaranSF.Name = "dgalbaranSF"
        Me.dgalbaranSF.ReadOnly = True
        Me.dgalbaranSF.Size = New System.Drawing.Size(543, 279)
        Me.dgalbaranSF.TabIndex = 1
        '
        'cod
        '
        Me.cod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cod.DefaultCellStyle = DataGridViewCellStyle14
        Me.cod.HeaderText = "Código"
        Me.cod.Name = "cod"
        Me.cod.ReadOnly = True
        '
        'fecha
        '
        Me.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.Format = "d"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.fecha.DefaultCellStyle = DataGridViewCellStyle15
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        '
        'importe
        '
        Me.importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.importe.DefaultCellStyle = DataGridViewCellStyle16
        Me.importe.HeaderText = "Importe (IVA)"
        Me.importe.Name = "importe"
        Me.importe.ReadOnly = True
        '
        'tipoIva
        '
        Me.tipoIva.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.tipoIva.DefaultCellStyle = DataGridViewCellStyle17
        Me.tipoIva.HeaderText = "Tipo IVA"
        Me.tipoIva.Name = "tipoIva"
        Me.tipoIva.ReadOnly = True
        '
        'formapago
        '
        Me.formapago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.formapago.DefaultCellStyle = DataGridViewCellStyle18
        Me.formapago.HeaderText = "Forma de Pago"
        Me.formapago.Name = "formapago"
        Me.formapago.ReadOnly = True
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Location = New System.Drawing.Point(344, 669)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSalir.TabIndex = 2
        Me.ButtonSalir.Text = "SALIR"
        Me.ButtonSalir.UseVisualStyleBackColor = True
        '
        'ButtonFacturar
        '
        Me.ButtonFacturar.Location = New System.Drawing.Point(238, 669)
        Me.ButtonFacturar.Name = "ButtonFacturar"
        Me.ButtonFacturar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFacturar.TabIndex = 3
        Me.ButtonFacturar.Text = "FACTURAR"
        Me.ButtonFacturar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dgalbaranSF)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(33, 259)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(584, 368)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Albaranes sin facturar"
        '
        'ComboBuscar
        '
        Me.ComboBuscar.FormattingEnabled = True
        Me.ComboBuscar.Location = New System.Drawing.Point(20, 75)
        Me.ComboBuscar.Name = "ComboBuscar"
        Me.ComboBuscar.Size = New System.Drawing.Size(121, 21)
        Me.ComboBuscar.TabIndex = 5
        '
        'tbcliente
        '
        Me.tbcliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbcliente.Location = New System.Drawing.Point(164, 75)
        Me.tbcliente.Name = "tbcliente"
        Me.tbcliente.Size = New System.Drawing.Size(208, 20)
        Me.tbcliente.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Buscar cliente..."
        '
        'ButtonBuscarCli
        '
        Me.ButtonBuscarCli.Image = CType(resources.GetObject("ButtonBuscarCli.Image"), System.Drawing.Image)
        Me.ButtonBuscarCli.Location = New System.Drawing.Point(378, 73)
        Me.ButtonBuscarCli.Name = "ButtonBuscarCli"
        Me.ButtonBuscarCli.Size = New System.Drawing.Size(37, 23)
        Me.ButtonBuscarCli.TabIndex = 8
        Me.ButtonBuscarCli.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonBuscarCli)
        Me.GroupBox2.Controls.Add(Me.ComboBuscar)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dgcliente)
        Me.GroupBox2.Controls.Add(Me.tbcliente)
        Me.GroupBox2.Location = New System.Drawing.Point(51, 39)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(557, 196)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(238, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 24)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "FACTURACIÓN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(265, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(281, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tipos IVA : 1 - 21%        2 - 10%        3 - 4%"
        '
        'ForFacturarClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 732)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ButtonFacturar)
        Me.Controls.Add(Me.ButtonSalir)
        Me.Name = "ForFacturarClientes"
        Me.Text = "Facturar Clientes"
        CType(Me.dgcliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgalbaranSF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgcliente As System.Windows.Forms.DataGridView
    Friend WithEvents dgalbaranSF As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonSalir As System.Windows.Forms.Button
    Friend WithEvents ButtonFacturar As System.Windows.Forms.Button
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBuscar As System.Windows.Forms.ComboBox
    Friend WithEvents tbcliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonBuscarCli As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipoIva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents formapago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
