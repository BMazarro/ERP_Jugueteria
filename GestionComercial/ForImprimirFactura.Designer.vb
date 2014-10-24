<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForImprimirFactura
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgFacturas = New System.Windows.Forms.DataGridView()
        Me.CodFactura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codcli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.impreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoiva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.formapago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.dgFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(254, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FACTURAS"
        '
        'dgFacturas
        '
        Me.dgFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFacturas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodFactura, Me.fecha, Me.codcli, Me.impreso, Me.tipoiva, Me.formapago, Me.importe})
        Me.dgFacturas.Location = New System.Drawing.Point(26, 18)
        Me.dgFacturas.Name = "dgFacturas"
        Me.dgFacturas.Size = New System.Drawing.Size(526, 471)
        Me.dgFacturas.TabIndex = 1
        '
        'CodFactura
        '
        Me.CodFactura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CodFactura.HeaderText = "Cod.Factura"
        Me.CodFactura.Name = "CodFactura"
        Me.CodFactura.ReadOnly = True
        '
        'fecha
        '
        Me.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        '
        'codcli
        '
        Me.codcli.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.codcli.HeaderText = "Cod.Cliente"
        Me.codcli.Name = "codcli"
        Me.codcli.ReadOnly = True
        '
        'impreso
        '
        Me.impreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.impreso.HeaderText = "Impreso"
        Me.impreso.Name = "impreso"
        Me.impreso.ReadOnly = True
        '
        'tipoiva
        '
        Me.tipoiva.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tipoiva.HeaderText = "IVA"
        Me.tipoiva.Name = "tipoiva"
        Me.tipoiva.ReadOnly = True
        '
        'formapago
        '
        Me.formapago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.formapago.HeaderText = "Forma Pago"
        Me.formapago.Name = "formapago"
        Me.formapago.ReadOnly = True
        '
        'importe
        '
        Me.importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.importe.DefaultCellStyle = DataGridViewCellStyle1
        Me.importe.HeaderText = "Importe"
        Me.importe.Name = "importe"
        Me.importe.ReadOnly = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(259, 665)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "IMPRIMIR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgFacturas)
        Me.GroupBox1.Location = New System.Drawing.Point(37, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(576, 557)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Facturas"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(340, 665)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "SALIR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ForImprimirFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 762)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ForImprimirFactura"
        Me.Text = "Imprimir Factura"
        CType(Me.dgFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgFacturas As System.Windows.Forms.DataGridView
    Friend WithEvents CodFactura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codcli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents impreso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipoiva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents formapago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
