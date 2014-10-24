<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForArticulos
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tprecioult = New System.Windows.Forms.TextBox()
        Me.tcodprovhab = New System.Windows.Forms.TextBox()
        Me.tpreciomed = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tstockact = New System.Windows.Forms.TextBox()
        Me.tstockmin = New System.Windows.Forms.TextBox()
        Me.tstockmax = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tpvp1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tpvp2 = New System.Windows.Forms.TextBox()
        Me.tpvp3 = New System.Windows.Forms.TextBox()
        Me.tfechault = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.tdescripcion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tcodigo = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ButtonBuscar = New System.Windows.Forms.Button()
        Me.ButtonModificar = New System.Windows.Forms.Button()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ButtonIrFinal = New System.Windows.Forms.Button()
        Me.ButtonAvance = New System.Windows.Forms.Button()
        Me.ButtonAtras = New System.Windows.Forms.Button()
        Me.ButtonIrInicio = New System.Windows.Forms.Button()
        Me.ButtonSalir = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tprecioult)
        Me.GroupBox1.Controls.Add(Me.tcodprovhab)
        Me.GroupBox1.Controls.Add(Me.tpreciomed)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.tfechault)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.tdescripcion)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(493, 369)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(230, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Fecha de última compra"
        '
        'tprecioult
        '
        Me.tprecioult.Location = New System.Drawing.Point(148, 184)
        Me.tprecioult.Name = "tprecioult"
        Me.tprecioult.Size = New System.Drawing.Size(48, 20)
        Me.tprecioult.TabIndex = 43
        '
        'tcodprovhab
        '
        Me.tcodprovhab.Location = New System.Drawing.Point(148, 130)
        Me.tcodprovhab.Name = "tcodprovhab"
        Me.tcodprovhab.Size = New System.Drawing.Size(48, 20)
        Me.tcodprovhab.TabIndex = 42
        '
        'tpreciomed
        '
        Me.tpreciomed.Location = New System.Drawing.Point(356, 184)
        Me.tpreciomed.Name = "tpreciomed"
        Me.tpreciomed.Size = New System.Drawing.Size(89, 20)
        Me.tpreciomed.TabIndex = 41
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tstockact)
        Me.GroupBox3.Controls.Add(Me.tstockmin)
        Me.GroupBox3.Controls.Add(Me.tstockmax)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(20, 223)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 129)
        Me.GroupBox3.TabIndex = 40
        Me.GroupBox3.TabStop = False
        '
        'tstockact
        '
        Me.tstockact.Location = New System.Drawing.Point(98, 26)
        Me.tstockact.Name = "tstockact"
        Me.tstockact.Size = New System.Drawing.Size(78, 20)
        Me.tstockact.TabIndex = 16
        '
        'tstockmin
        '
        Me.tstockmin.Location = New System.Drawing.Point(98, 56)
        Me.tstockmin.Name = "tstockmin"
        Me.tstockmin.Size = New System.Drawing.Size(78, 20)
        Me.tstockmin.TabIndex = 31
        '
        'tstockmax
        '
        Me.tstockmax.Location = New System.Drawing.Point(98, 87)
        Me.tstockmax.Name = "tstockmax"
        Me.tstockmax.Size = New System.Drawing.Size(78, 20)
        Me.tstockmax.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Stock Actual"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Stock Mínimo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Stock Máximo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.tpvp1)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.tpvp2)
        Me.GroupBox2.Controls.Add(Me.tpvp3)
        Me.GroupBox2.Location = New System.Drawing.Point(275, 223)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 129)
        Me.GroupBox2.TabIndex = 39
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Precios"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "PVP 1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(61, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "PVP 3"
        '
        'tpvp1
        '
        Me.tpvp1.Location = New System.Drawing.Point(104, 23)
        Me.tpvp1.Name = "tpvp1"
        Me.tpvp1.Size = New System.Drawing.Size(66, 20)
        Me.tpvp1.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(61, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "PVP 2"
        '
        'tpvp2
        '
        Me.tpvp2.Location = New System.Drawing.Point(104, 53)
        Me.tpvp2.Name = "tpvp2"
        Me.tpvp2.Size = New System.Drawing.Size(66, 20)
        Me.tpvp2.TabIndex = 18
        '
        'tpvp3
        '
        Me.tpvp3.Location = New System.Drawing.Point(104, 84)
        Me.tpvp3.Name = "tpvp3"
        Me.tpvp3.Size = New System.Drawing.Size(66, 20)
        Me.tpvp3.TabIndex = 17
        '
        'tfechault
        '
        Me.tfechault.Location = New System.Drawing.Point(356, 130)
        Me.tfechault.Name = "tfechault"
        Me.tfechault.Size = New System.Drawing.Size(89, 20)
        Me.tfechault.TabIndex = 36
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(37, 187)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(105, 13)
        Me.Label23.TabIndex = 35
        Me.Label23.Text = "Precio última compra"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(15, 133)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(127, 13)
        Me.Label24.TabIndex = 34
        Me.Label24.Text = "Código del Prov. Habitual"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(27, 25)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(63, 13)
        Me.Label25.TabIndex = 33
        Me.Label25.Text = "Descripción"
        '
        'tdescripcion
        '
        Me.tdescripcion.Location = New System.Drawing.Point(20, 41)
        Me.tdescripcion.Multiline = True
        Me.tdescripcion.Name = "tdescripcion"
        Me.tdescripcion.Size = New System.Drawing.Size(425, 59)
        Me.tdescripcion.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(231, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Precio Med. Ponderado"
        '
        'tcodigo
        '
        Me.tcodigo.Location = New System.Drawing.Point(78, 16)
        Me.tcodigo.Name = "tcodigo"
        Me.tcodigo.Size = New System.Drawing.Size(57, 20)
        Me.tcodigo.TabIndex = 29
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(32, 19)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 13)
        Me.Label22.TabIndex = 32
        Me.Label22.Text = "Código"
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(112, 461)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(61, 23)
        Me.ButtonBuscar.TabIndex = 58
        Me.ButtonBuscar.Text = "BUSCAR"
        Me.ToolTip1.SetToolTip(Me.ButtonBuscar, "Busca un registro")
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'ButtonModificar
        '
        Me.ButtonModificar.Location = New System.Drawing.Point(28, 461)
        Me.ButtonModificar.Name = "ButtonModificar"
        Me.ButtonModificar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonModificar.TabIndex = 57
        Me.ButtonModificar.Text = "MODIFICAR"
        Me.ToolTip1.SetToolTip(Me.ButtonModificar, "Modificar registro")
        Me.ButtonModificar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Location = New System.Drawing.Point(112, 426)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(61, 23)
        Me.ButtonBorrar.TabIndex = 56
        Me.ButtonBorrar.Text = "BORRAR"
        Me.ToolTip1.SetToolTip(Me.ButtonBorrar, "Borrar registro")
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(28, 426)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 55
        Me.ButtonNuevo.Text = "NUEVO"
        Me.ToolTip1.SetToolTip(Me.ButtonNuevo, "Nuevo registro")
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.ButtonIrFinal)
        Me.GroupBox6.Controls.Add(Me.ButtonAvance)
        Me.GroupBox6.Controls.Add(Me.ButtonAtras)
        Me.GroupBox6.Controls.Add(Me.ButtonIrInicio)
        Me.GroupBox6.Location = New System.Drawing.Point(182, 437)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(214, 47)
        Me.GroupBox6.TabIndex = 59
        Me.GroupBox6.TabStop = False
        '
        'ButtonIrFinal
        '
        Me.ButtonIrFinal.Location = New System.Drawing.Point(142, 14)
        Me.ButtonIrFinal.Name = "ButtonIrFinal"
        Me.ButtonIrFinal.Size = New System.Drawing.Size(52, 23)
        Me.ButtonIrFinal.TabIndex = 7
        Me.ButtonIrFinal.Text = ">>"
        Me.ToolTip1.SetToolTip(Me.ButtonIrFinal, "Ir a último registro")
        Me.ButtonIrFinal.UseVisualStyleBackColor = True
        '
        'ButtonAvance
        '
        Me.ButtonAvance.Location = New System.Drawing.Point(108, 14)
        Me.ButtonAvance.Name = "ButtonAvance"
        Me.ButtonAvance.Size = New System.Drawing.Size(28, 23)
        Me.ButtonAvance.TabIndex = 6
        Me.ButtonAvance.Text = ">"
        Me.ToolTip1.SetToolTip(Me.ButtonAvance, "Avance un registro")
        Me.ButtonAvance.UseVisualStyleBackColor = True
        '
        'ButtonAtras
        '
        Me.ButtonAtras.Location = New System.Drawing.Point(74, 14)
        Me.ButtonAtras.Name = "ButtonAtras"
        Me.ButtonAtras.Size = New System.Drawing.Size(28, 23)
        Me.ButtonAtras.TabIndex = 5
        Me.ButtonAtras.Text = "<"
        Me.ToolTip1.SetToolTip(Me.ButtonAtras, "Retrocede un registro")
        Me.ButtonAtras.UseVisualStyleBackColor = True
        '
        'ButtonIrInicio
        '
        Me.ButtonIrInicio.Location = New System.Drawing.Point(18, 14)
        Me.ButtonIrInicio.Name = "ButtonIrInicio"
        Me.ButtonIrInicio.Size = New System.Drawing.Size(49, 23)
        Me.ButtonIrInicio.TabIndex = 4
        Me.ButtonIrInicio.Text = "<<"
        Me.ToolTip1.SetToolTip(Me.ButtonIrInicio, "Ir a primer registro")
        Me.ButtonIrInicio.UseVisualStyleBackColor = True
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Location = New System.Drawing.Point(446, 460)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSalir.TabIndex = 62
        Me.ButtonSalir.Text = "SALIR"
        Me.ToolTip1.SetToolTip(Me.ButtonSalir, "Salir")
        Me.ButtonSalir.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(447, 426)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 61
        Me.ButtonCancel.Text = "CANCELAR"
        Me.ToolTip1.SetToolTip(Me.ButtonCancel, "Cancelar")
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(403, 426)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(38, 23)
        Me.ButtonOK.TabIndex = 60
        Me.ButtonOK.Text = "OK"
        Me.ToolTip1.SetToolTip(Me.ButtonOK, "Aceptar Cambios")
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ForArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(553, 498)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonSalir)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Controls.Add(Me.tcodigo)
        Me.Controls.Add(Me.ButtonModificar)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ForArticulos"
        Me.Text = "ARTÍCULOS"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tfechault As System.Windows.Forms.TextBox
    Friend WithEvents tcodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents tstockmin As System.Windows.Forms.TextBox
    Friend WithEvents tdescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tstockmax As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tstockact As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tpvp3 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tpvp2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tpvp1 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents ButtonModificar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonIrFinal As System.Windows.Forms.Button
    Friend WithEvents ButtonAvance As System.Windows.Forms.Button
    Friend WithEvents ButtonAtras As System.Windows.Forms.Button
    Friend WithEvents ButtonIrInicio As System.Windows.Forms.Button
    Friend WithEvents ButtonSalir As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents tpreciomed As System.Windows.Forms.TextBox
    Friend WithEvents tcodprovhab As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tprecioult As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
