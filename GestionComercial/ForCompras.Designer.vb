<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForCompras
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ForCompras))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.Linea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripción = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PVP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.ButtonX = New System.Windows.Forms.Button()
        Me.ButtonM = New System.Windows.Forms.Button()
        Me.ButtonC = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LabTelefono = New System.Windows.Forms.Label()
        Me.LabProvincia = New System.Windows.Forms.Label()
        Me.LabLocalidad = New System.Windows.Forms.Label()
        Me.LabCP = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tcodprov = New System.Windows.Forms.TextBox()
        Me.LabNom = New System.Windows.Forms.Label()
        Me.LabDir = New System.Windows.Forms.Label()
        Me.ButtonBusProv = New System.Windows.Forms.Button()
        Me.LabNif = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Labna = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Labfe = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ButtonSal = New System.Windows.Forms.Button()
        Me.ButtonCanc = New System.Windows.Forms.Button()
        Me.ButtonAcep = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(243, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(153, 15)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "ALBARÁN DE COMPRA"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dg)
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.TextBox4)
        Me.GroupBox3.Controls.Add(Me.TextBox5)
        Me.GroupBox3.Controls.Add(Me.TextBox6)
        Me.GroupBox3.Controls.Add(Me.TextBox8)
        Me.GroupBox3.Controls.Add(Me.ButtonX)
        Me.GroupBox3.Controls.Add(Me.ButtonM)
        Me.GroupBox3.Controls.Add(Me.ButtonC)
        Me.GroupBox3.Controls.Add(Me.ButtonOK)
        Me.GroupBox3.Location = New System.Drawing.Point(40, 271)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(577, 262)
        Me.GroupBox3.TabIndex = 84
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos de Artículos"
        '
        'dg
        '
        Me.dg.AllowUserToOrderColumns = True
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Linea, Me.Codigo, Me.Descripción, Me.PVP, Me.Cantidad, Me.Importe})
        Me.dg.Location = New System.Drawing.Point(6, 41)
        Me.dg.Name = "dg"
        Me.dg.ReadOnly = True
        Me.dg.Size = New System.Drawing.Size(523, 150)
        Me.dg.TabIndex = 13
        '
        'Linea
        '
        Me.Linea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Linea.DefaultCellStyle = DataGridViewCellStyle1
        Me.Linea.HeaderText = "Línea"
        Me.Linea.Name = "Linea"
        Me.Linea.ReadOnly = True
        Me.Linea.Width = 60
        '
        'Codigo
        '
        Me.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Codigo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 65
        '
        'Descripción
        '
        Me.Descripción.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripción.HeaderText = "Descripción"
        Me.Descripción.Name = "Descripción"
        Me.Descripción.ReadOnly = True
        '
        'PVP
        '
        Me.PVP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.PVP.DefaultCellStyle = DataGridViewCellStyle3
        Me.PVP.HeaderText = "PVP"
        Me.PVP.Name = "PVP"
        Me.PVP.ReadOnly = True
        Me.PVP.Width = 53
        '
        'Cantidad
        '
        Me.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Width = 74
        '
        'Importe
        '
        Me.Importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle5
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 67
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(45, 210)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(61, 20)
        Me.TextBox1.TabIndex = 53
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(105, 210)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(57, 20)
        Me.TextBox3.TabIndex = 14
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(160, 210)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(181, 20)
        Me.TextBox4.TabIndex = 15
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(339, 210)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(59, 20)
        Me.TextBox5.TabIndex = 16
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(395, 210)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(71, 20)
        Me.TextBox6.TabIndex = 17
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(459, 210)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(70, 20)
        Me.TextBox8.TabIndex = 19
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ButtonX
        '
        Me.ButtonX.Image = CType(resources.GetObject("ButtonX.Image"), System.Drawing.Image)
        Me.ButtonX.Location = New System.Drawing.Point(6, 209)
        Me.ButtonX.Name = "ButtonX"
        Me.ButtonX.Size = New System.Drawing.Size(35, 23)
        Me.ButtonX.TabIndex = 20
        Me.ButtonX.UseVisualStyleBackColor = True
        '
        'ButtonM
        '
        Me.ButtonM.Image = CType(resources.GetObject("ButtonM.Image"), System.Drawing.Image)
        Me.ButtonM.Location = New System.Drawing.Point(535, 86)
        Me.ButtonM.Name = "ButtonM"
        Me.ButtonM.Size = New System.Drawing.Size(26, 27)
        Me.ButtonM.TabIndex = 21
        Me.ButtonM.UseVisualStyleBackColor = True
        '
        'ButtonC
        '
        Me.ButtonC.Image = CType(resources.GetObject("ButtonC.Image"), System.Drawing.Image)
        Me.ButtonC.Location = New System.Drawing.Point(535, 119)
        Me.ButtonC.Name = "ButtonC"
        Me.ButtonC.Size = New System.Drawing.Size(26, 26)
        Me.ButtonC.TabIndex = 22
        Me.ButtonC.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Image = CType(resources.GetObject("ButtonOK.Image"), System.Drawing.Image)
        Me.ButtonOK.Location = New System.Drawing.Point(535, 151)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(26, 26)
        Me.ButtonOK.TabIndex = 23
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LabTelefono)
        Me.GroupBox2.Controls.Add(Me.LabProvincia)
        Me.GroupBox2.Controls.Add(Me.LabLocalidad)
        Me.GroupBox2.Controls.Add(Me.LabCP)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.tcodprov)
        Me.GroupBox2.Controls.Add(Me.LabNom)
        Me.GroupBox2.Controls.Add(Me.LabDir)
        Me.GroupBox2.Controls.Add(Me.ButtonBusProv)
        Me.GroupBox2.Controls.Add(Me.LabNif)
        Me.GroupBox2.Location = New System.Drawing.Point(321, 54)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(280, 200)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Proveedor"
        '
        'LabTelefono
        '
        Me.LabTelefono.Location = New System.Drawing.Point(175, 173)
        Me.LabTelefono.Name = "LabTelefono"
        Me.LabTelefono.Size = New System.Drawing.Size(100, 13)
        Me.LabTelefono.TabIndex = 52
        '
        'LabProvincia
        '
        Me.LabProvincia.Location = New System.Drawing.Point(174, 142)
        Me.LabProvincia.Name = "LabProvincia"
        Me.LabProvincia.Size = New System.Drawing.Size(100, 12)
        Me.LabProvincia.TabIndex = 51
        '
        'LabLocalidad
        '
        Me.LabLocalidad.Location = New System.Drawing.Point(26, 142)
        Me.LabLocalidad.Name = "LabLocalidad"
        Me.LabLocalidad.Size = New System.Drawing.Size(100, 12)
        Me.LabLocalidad.TabIndex = 50
        '
        'LabCP
        '
        Me.LabCP.Location = New System.Drawing.Point(174, 101)
        Me.LabCP.Name = "LabCP"
        Me.LabCP.Size = New System.Drawing.Size(62, 13)
        Me.LabCP.TabIndex = 49
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Codigo:"
        '
        'tcodprov
        '
        Me.tcodprov.Location = New System.Drawing.Point(75, 32)
        Me.tcodprov.Name = "tcodprov"
        Me.tcodprov.Size = New System.Drawing.Size(68, 20)
        Me.tcodprov.TabIndex = 5
        '
        'LabNom
        '
        Me.LabNom.Location = New System.Drawing.Point(26, 72)
        Me.LabNom.Name = "LabNom"
        Me.LabNom.Size = New System.Drawing.Size(118, 13)
        Me.LabNom.TabIndex = 8
        '
        'LabDir
        '
        Me.LabDir.Location = New System.Drawing.Point(26, 101)
        Me.LabDir.Name = "LabDir"
        Me.LabDir.Size = New System.Drawing.Size(149, 13)
        Me.LabDir.TabIndex = 9
        '
        'ButtonBusProv
        '
        Me.ButtonBusProv.Image = CType(resources.GetObject("ButtonBusProv.Image"), System.Drawing.Image)
        Me.ButtonBusProv.Location = New System.Drawing.Point(164, 27)
        Me.ButtonBusProv.Name = "ButtonBusProv"
        Me.ButtonBusProv.Size = New System.Drawing.Size(32, 25)
        Me.ButtonBusProv.TabIndex = 48
        Me.ButtonBusProv.UseVisualStyleBackColor = True
        '
        'LabNif
        '
        Me.LabNif.Location = New System.Drawing.Point(25, 173)
        Me.LabNif.Name = "LabNif"
        Me.LabNif.Size = New System.Drawing.Size(118, 13)
        Me.LabNif.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Labna)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Labfe)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(57, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 85)
        Me.GroupBox1.TabIndex = 82
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Albarán"
        '
        'Labna
        '
        Me.Labna.BackColor = System.Drawing.SystemColors.Window
        Me.Labna.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Labna.Location = New System.Drawing.Point(88, 31)
        Me.Labna.Name = "Labna"
        Me.Labna.Size = New System.Drawing.Size(67, 13)
        Me.Labna.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nº Albarán"
        '
        'Labfe
        '
        Me.Labfe.BackColor = System.Drawing.SystemColors.Window
        Me.Labfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Labfe.Location = New System.Drawing.Point(88, 61)
        Me.Labfe.Name = "Labfe"
        Me.Labfe.Size = New System.Drawing.Size(67, 13)
        Me.Labfe.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(430, 652)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(145, 13)
        Me.Label26.TabIndex = 81
        Me.Label26.Text = "_______________________"
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(508, 670)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label25.Size = New System.Drawing.Size(61, 13)
        Me.Label25.TabIndex = 79
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(504, 639)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label24.Size = New System.Drawing.Size(65, 13)
        Me.Label24.TabIndex = 78
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(506, 614)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label23.Size = New System.Drawing.Size(63, 13)
        Me.Label23.TabIndex = 77
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(429, 569)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 13)
        Me.Label22.TabIndex = 76
        Me.Label22.Text = "IMPORTE"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(502, 569)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 73
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(429, 614)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 13)
        Me.Label18.TabIndex = 72
        Me.Label18.Text = "BASE IMP."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(432, 670)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 13)
        Me.Label15.TabIndex = 70
        Me.Label15.Text = "TOTAL"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(430, 639)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 13)
        Me.Label14.TabIndex = 69
        Me.Label14.Text = "% IVA"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(379, 636)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(45, 21)
        Me.ComboBox2.TabIndex = 68
        '
        'ButtonSal
        '
        Me.ButtonSal.Location = New System.Drawing.Point(542, 717)
        Me.ButtonSal.Name = "ButtonSal"
        Me.ButtonSal.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSal.TabIndex = 67
        Me.ButtonSal.Text = "SALIR"
        Me.ButtonSal.UseVisualStyleBackColor = True
        '
        'ButtonCanc
        '
        Me.ButtonCanc.Location = New System.Drawing.Point(315, 717)
        Me.ButtonCanc.Name = "ButtonCanc"
        Me.ButtonCanc.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCanc.TabIndex = 65
        Me.ButtonCanc.Text = "CANCELAR"
        Me.ButtonCanc.UseVisualStyleBackColor = True
        '
        'ButtonAcep
        '
        Me.ButtonAcep.Location = New System.Drawing.Point(225, 717)
        Me.ButtonAcep.Name = "ButtonAcep"
        Me.ButtonAcep.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAcep.TabIndex = 64
        Me.ButtonAcep.Text = "ACEPTAR"
        Me.ButtonAcep.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(55, 581)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Observaciones"
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(58, 597)
        Me.TextBox9.Multiline = True
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(209, 86)
        Me.TextBox9.TabIndex = 61
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(145, 539)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 60
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(54, 542)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 13)
        Me.Label12.TabIndex = 59
        Me.Label12.Text = "Forma de Pago"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(57, 178)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(200, 71)
        Me.TextBox2.TabIndex = 58
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(55, 162)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Dirección de Entrega:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(429, 582)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 13)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "_______________________"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(571, 661)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 25)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "€"
        '
        'ForCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 762)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.ButtonAcep)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ButtonSal)
        Me.Controls.Add(Me.ButtonCanc)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label6)
        Me.Name = "ForCompras"
        Me.Text = "NUEVO ALBARÁN DE COMPRA"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonX As System.Windows.Forms.Button
    Friend WithEvents ButtonM As System.Windows.Forms.Button
    Friend WithEvents ButtonC As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tcodprov As System.Windows.Forms.TextBox
    Friend WithEvents LabNom As System.Windows.Forms.Label
    Friend WithEvents LabDir As System.Windows.Forms.Label
    Friend WithEvents ButtonBusProv As System.Windows.Forms.Button
    Friend WithEvents LabNif As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Labna As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Labfe As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonSal As System.Windows.Forms.Button
    Friend WithEvents ButtonCanc As System.Windows.Forms.Button
    Friend WithEvents ButtonAcep As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LabTelefono As System.Windows.Forms.Label
    Friend WithEvents LabProvincia As System.Windows.Forms.Label
    Friend WithEvents LabLocalidad As System.Windows.Forms.Label
    Friend WithEvents LabCP As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Linea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripción As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PVP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
