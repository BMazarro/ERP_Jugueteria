Imports System.Data.SqlClient

Public Class ForCompras

    Dim Conexion As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Dim consulta As New SqlCommand
    Dim Mireader As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DistribuidoraJuguetesDataSet

    Private fecha As Date = Date.Now        ' - Variable que contiene la fecha de hoy
    Private numLinea As Integer = 0         ' - Variable Contador de lineas de albarán
    Private importetotal As Double = 0.0    ' - Variable Global para el importe total
    Private des As Double = 0.0             ' - Variable que uso para hacer calcular el descuento y sus cambios
    Dim Iiva As Integer                     ' - Variable Global para el IVA
    Dim c As Integer = 0                    ' - Variable que controla que la cabecera solo se inserte una vez
    Dim importeLinea As Double = 0.0        ' - Variable Global para el importe de linea
    Dim precio As Double = 0.0              ' - Variable Global para el precio de un producto
    Dim descuentoLinea As Double = 0.0      ' - Variable Global para el descuento en linea

    ' -------- Inicio de la aplicacion -----------------------------------------------------------------------
    Private Sub ForCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Centramos la ventana
        Me.CenterToScreen()
        ' ----------------------------------------------------------------------------------------------------
        Dim contador As Integer         ' - Variable que cuenta la cantidad de albaranes que hay dados de alta
        Dim num As Integer = 1

        ' Ponemos el foco en el codigo del cliente a buscar
        tcodprov.Focus()
        tcodprov.BackColor = Color.Aquamarine
        ' Inicializamos la fecha de hoy
        Labfe.Text = fecha

        ' Solo lectura para los textbox's
        SoloLectura()

        ' Desactivar botones
        BotonesInactivos()

        Try ' Abrimos conexion --------------------------------------------------------
            Conexion.Open()

            ' Obtenemos el Nº de Albarán contando los registros que hay en la BD
            consulta = New SqlCommand("Select count(codalbaran) from CabPieAlbaranCompra", Conexion)
            contador = consulta.ExecuteScalar() ' Devuelve un número
            If contador = 0 Then
                Labna.Text = num.ToString
            Else
                Labna.Text = (contador + 1).ToString
            End If

            ' Rellenamos el Combo del IVA
            consulta = New SqlCommand("Select Porcentaje from IVA", Conexion)
            Mireader = consulta.ExecuteReader() ' Devuelve un conjunto de registros
            While Mireader.Read()
                ComboBox2.Items.Add(Mireader("Porcentaje").ToString)
            End While
            Mireader.Close()
            ComboBox2.SelectedIndex = 0
            ComboBox2.Enabled = False
            Iiva = CSng(ComboBox2.SelectedItem.ToString)

            ' Rellenamos el Combo del FormasPago
            consulta = New SqlCommand("SELECT nombre FROM FormasPago", Conexion)
            Mireader = consulta.ExecuteReader()
            While Mireader.Read()
                ComboBox1.Items.Add(Mireader("nombre").ToString)
            End While
            Mireader.Close()
            ComboBox1.SelectedIndex = 0
            ComboBox1.Enabled = False

            '- Cerramos conexion
            Conexion.Close()
            ' -----------------------------------------------------------------------
            ' Limpiamos el DataGrid y lo inicializamos para que marque el campo Codigo
            dg.ClearSelection()
            Me.dg.Item(1, 0).Selected = True    ' Campo Codigo = columan 1, fila 0

        Catch ex As Exception
            MsgBox(ex.Message)
            'MsgBox("No se ha podido establecer la conexión")
        Finally
            If Conexion.State = ConnectionState.Open Then
                Conexion.Close()
            End If
        End Try
    End Sub

    ' --------- BUSCAR EL PROVEEDOR INTRODUCIDO ------------------------------------------------------------------------
    Private Sub ButtonBusProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBusProv.Click
        Dim posicion As Integer
        TextBox3.Focus()    ' Ponemos el foco en el codigo de articulos de las lineas del albaran

        Try ' Abrimos la conexion
            Conexion.Open()

            ' Buscamos el codigo introducido y vemos en que posicion se encuentra
            consulta = New SqlCommand("Select codprov from Proveedores where codprov='" &
                                      tcodprov.Text & "';", Conexion)
            posicion = consulta.ExecuteScalar()   'Obtenemos la cantidad de registros que tiene hasta su posicion

            ' Si el valor devuelto no existe entonces volvemos al inicio de la aplicacion
            If posicion = Nothing Then

                If MessageBox.Show("Desea crear uno nuevo?", "El proveedor no existe", _
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                                        = DialogResult.Yes Then
                    ' Gestionamos el cierre de la ventana actual y la abertura de la nueva

                    Dim alta As New ForProveedores
                    alta.ShowDialog()

                Else
                    tcodprov.Text = ""
                End If

            Else
                ' Seleccionamos los datos del proveedor introducido
                consulta = New SqlCommand("Select * from Proveedores where codprov='" &
                                          tcodprov.Text & "';", Conexion)
                ' Rellemos el datareader con los datos
                Mireader = consulta.ExecuteReader()
                ' Leemos el datareader
                Mireader.Read()
                ' Mostramos los datos del cliente
                MostrarDatosProveedor()
                ' Habilitamos botones de las lineas de albaran
                BotonesActivos()
                ' Habilitamos la escritura en los campos del articulo de las lineas de albaran
                EscrituraLineas()
                ' Damos color indicativo al campo codigo articulo ya que el foco no funciona
                TextBox3.BackColor = Color.LightBlue
                dg.ClearSelection()
                Me.dg.Item(1, 0).Selected = True
            End If

            ' - Cerramos la conexion y el datareader
            Conexion.Close()
            Mireader.Close()

        Catch ex As Exception
            MsgBox("No ha introducido ningun código de proveedor")
            Mireader.Close()
        Finally
            If Conexion.State = ConnectionState.Open Then
                Conexion.Close()
            End If
        End Try
    End Sub

    ' -------- MOSTRAR LOS DATOS DEL PROVEEDOR -------------
    Private Sub MostrarDatosProveedor()
        LabNom.Text = Mireader("nombre").ToString
        LabDir.Text = Mireader("direccion").ToString
        LabNif.Text = Mireader("nif").ToString
        LabCP.Text = Mireader("cp").ToString
        LabLocalidad.Text = Mireader("localidad").ToString
        LabProvincia.Text = Mireader("provincia").ToString
        LabTelefono.Text = Mireader("telefono").ToString
        TextBox2.Text = Mireader("direccionentrega").ToString
    End Sub

    ' -------- BUSCAR DATOS DE ARTICULOS EN LAS LINEAS DE ALBARAN -----------------------------------------------
    Private Sub ButtonX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX.Click

        ' Calculamos la linea correspondiente
        numLinea = numLinea + 1
        TextBox1.Text = numLinea.ToString

        Try ' Abrimos la conexion
            Conexion.Open()
            ' Buscamos los datos del articulo correspondiente al codigo introducido
            consulta = New SqlCommand("SELECT * from Articulos where codigo='" &
                                      TextBox3.Text & "'", Conexion)
            Mireader = consulta.ExecuteReader()
            Mireader.Read()
            ' Mostramos los datos
            MostrarDatosProducto()
            ' Cerramos el DataReader y la conexion
            Mireader.Close()
            Conexion.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, _
                           "error", MessageBoxButtons.OK, _
                           MessageBoxIcon.Error)
            Mireader.Close()
            If MessageBox.Show("Desea crear uno nuevo?", "El artículo no existe", _
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                                        = DialogResult.Yes Then
                ' Gestionamos el cierre de la ventana actual y la abertura de la nueva

                Dim alta As New ForArticulos
                alta.ShowDialog()

            Else
                TextBox3.Text = ""
            End If

        Finally
            If Conexion.State = ConnectionState.Open Then
                Conexion.Close()
            End If
        End Try
    End Sub

    ' -------- MOSTRAR LOS DATOS DEL PRODUCTO ---------------------------
    Private Sub MostrarDatosProducto()
        ' Muestra la descripcion
        TextBox4.Text = Mireader("descripcion").ToString
        ' Muestra el pvp
        TextBox5.Text = Mireader("pvp1").ToString
        ' Habilitamos el pvp por si lo queremos cambiar a otro específico
        TextBox5.ReadOnly = False

    End Sub

    ' --- SI CAMBIA LA CANTIDAD, calcula el importe de la linea en base a la cantidad de articulos -------------
    Private Sub TextBox6_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        If Not TextBox6.Text = "" Then
            Dim pvp, cant As Double
            pvp = CDbl(TextBox5.Text)
            cant = CDbl(TextBox6.Text)
            importeLinea = pvp * cant
            'Formateamos la salida
            TextBox8.Text = Format(importeLinea, "N2")
        End If
    End Sub

    ' ------- AÑADIR LINEA AL DATAGRID ------------------------------------------------------------------------
    Private Sub ButtonM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonM.Click

        ' Inhabilitamos a partir de ahora el codigo del proveedor, ya no se puede cambiar 
        tcodprov.Enabled = False
        ' Inabilitamos la direccion de entrega, ya no se puede cambiar
        TextBox2.ReadOnly = True

            Try ' Abrimos la conexion
                Conexion.Open()
                ' Añadimos la linea al DataGrid
                dg.Rows.Add(TextBox1.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox8.Text)
                
                ' Insertamos la cabecera. Controlamos con la variable c que solo se inserte una vez
                If (c = 0) Then
                    consulta =
                        New SqlCommand("INSERT INTO CabPieAlbaranCompra(codalbaran,codprov)" &
                    " values(" & "'" & Labna.Text & "'" & "," & "'" & tcodprov.Text & "'" & ")", Conexion)
                    consulta.ExecuteNonQuery()
                    c = 1
                End If

                ' Insertamos la linea introducida
            consulta =
                New SqlCommand("INSERT INTO LineasAlbaranCompra(codalbaran,numlinea,codart,descripcion,pvp,cantidad,importe)" &
                 " values(" & "'" & Labna.Text & "'" & "," & "'" & numLinea & "'" &
                 "," & "'" & TextBox3.Text & "'" & "," & "'" & TextBox4.Text & "'" &
                 "," & TextBox5.Text.Replace(".", "").Replace(",", ".") & "," & TextBox6.Text.Replace(".", "").Replace(",", ".") &
                 "," & TextBox8.Text.Replace(".", "").Replace(",", ".") & ")", Conexion)

                consulta.ExecuteNonQuery()
                'MsgBox("Línea guardada")

                ' Cerramos la conexion
                Conexion.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
                Conexion.Close()
            End Try

            ' Recalculamos el stock de los articulos pedidos
            Try
                Conexion.Open()
                consulta = New SqlCommand("UPDATE Articulos set stockactual = stockactual + " & _
                                          CInt(TextBox6.Text) & " where codigo = '" & TextBox3.Text & "';", Conexion)
                consulta.ExecuteNonQuery()
                Conexion.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Conexion.Close()
            End Try
            
            ' Limpiamos las lineas 
            limpiarlinea()

    End Sub

    ' ------- BOTON CANCELAR LINEA ----------------------------------------------------------------------------
    Private Sub ButtonC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonC.Click
        Dim cant As Integer
        Dim cod As String
        Try
            ' Tomamos la cantidad de ese articulo
            cant = dg.Item(4, dg.CurrentRow.Index).Value
            ' Tomamos el codigo del articulo seleccionado
            cod = CStr(dg.Item(1, dg.CurrentRow.Index).Value.ToString)
            ' Recalculamos el stock de los articulos
            Conexion.Open()
            consulta = New SqlCommand("UPDATE Articulos set stockactual = stockactual - " & _
                                      cant & " where codigo = '" & cod & "';", Conexion)
            consulta.ExecuteNonQuery()
            Conexion.Close()
            ' Borramos la fila seleccionada
            dg.Rows.Remove(dg.CurrentRow)
        Catch ex As Exception
            dg.Rows.Remove(dg.CurrentRow)
        End Try
    End Sub

    ' ------- CALCULAR IMPORTES --------------
    Private Sub CalcularImportes()
        Conexion.Open()
        consulta = New SqlCommand("SELECT SUM(IMPORTE) FROM LINEASALBARANCOMPRA WHERE CODALBARAN='" &
                                     Labna.Text & "'", Conexion)
        Mireader = consulta.ExecuteReader()
        Mireader.Read()
        Label19.Text = Mireader(0).ToString()
        Label19.Text = Format(CDbl(Label19.Text), "N2")
        Mireader.Close()
        Conexion.Close()
    End Sub

    ' ------- BOTON NO MAS LINEAS. CALCULAR IMPORTES -----------------------------------------------------------
    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        ' Variables del evento
        Dim imponible As Double
        Dim a As Double
        Dim b As Double
        CalcularImportes()
        ' Habilitamos los controles del pie
        EscrituraPie()
        ' La base imponible va a ser igual al importetotal
        Label23.Text = Format(CDbl(Label19.Text), "N2")
        imponible = Format(CDbl(Label19.Text), "N2")
        ' Calculamos lo que hay que sumarle de IVA
        a = CDbl(Iiva / 100) * imponible
        Label24.Text = Format(a, "N2")
        ' Sumamos la base imponible y el IVA correspondiente
        b = a + imponible
        ' Formateamos la salida y lo asignamos al TOTAL
        Label25.Text = Format(b, "N2")
        ' ---------------------------------------------------------
        ' Hecho esto se habilita el boton ACEPTAR
        ButtonAcep.Enabled = True
        ' ----------------------------------------------------------------------------
        ' Inhabilitamos las lineas del albarán para que no se puedan introducir datos
        TextBox1.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        'TextBox7.Enabled = False
        TextBox8.Enabled = False
        ' ----------------------------------------------------------------------------
        ' Inhabilitamos los botones correspondientes a las lineas del albarán
        ButtonM.Enabled = False
        ButtonX.Enabled = False
        ButtonOK.Enabled = False
        ButtonC.Enabled = False
        ' ----------------------------------------------------------------------------
    End Sub

    ' ------- EVENTO SI CAMBIA EL VALOR DEL COMBOBOX DEL IVA ------------------------------------------------------------------------------------
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

        ' Variables del evento
        Dim imponible As Double
        Dim a As Double
        Dim b As Double

        ' Controlamos que exista un valor en el importe y los portes no este vacios
        If Not Label19.Text = "" Then
            ' Calculamos la base imponible y formateamos la salida
            imponible = Format(CDbl(Label19.Text), "N2")
            ' Obtenemos el valor del IVA
            Dim iva = CSng(ComboBox2.SelectedItem)
            ' Calculamos lo que hay que sumarle de IVA
            a = CDbl(iva / 100) * imponible
            Label24.Text = Format(a, "N2")
            ' Sumamos la base imponible y el IVA correspondiente
            b = a + imponible
            ' Formateamos la salida y lo asignamos al TOTAL
            Label25.Text = Format(b, "N2")
            ' Asignamos el nuevo IVA a su variable GLOBAL. Se inicializó al rellenar el Combo
            Iiva = iva
        End If
    End Sub

    ' ------- BOTON ACEPTAR ALBARÁN ---------------------------------------------------------------------------------
    Private Sub ButtonAcep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAcep.Click
        Dim contador As Integer = 0
        Dim lin As Integer
        Dim codar, descrip, ctd As String
        Dim import As Double
        Dim pre As Double
        Try
            While contador < dg.Rows.Count 'para cada linea del datagrid
                lin = dg.Rows(contador).Cells(0).Value
                codar = dg.Rows(contador).Cells(1).Value
                descrip = dg.Rows(contador).Cells(2).Value
                pre = CDbl(dg.Rows(contador).Cells(3).Value)
                ctd = CInt(dg.Rows(contador).Cells(4).Value)
                import = CDbl(dg.Rows(contador).Cells(5).Value)

                ' Actualizamos el precio ponderado
                Dim comprado As Boolean
                Try
                    'comprobamos si es la primera vez que se compra este articulo
                    Conexion.Open()
                    consulta = New SqlCommand("SELECT FECHAULTIMACOMPRA FROM ARTICULOS WHERE CODIGO ='" & codar & "'", Conexion)
                    Mireader = consulta.ExecuteReader()
                    Mireader.Read()

                    If (Mireader(0).ToString.CompareTo("") = 0 Or Mireader(0).ToString = Nothing) Then 'si no ha sido comprado
                        comprado = False
                    Else ' si ha sido comprado
                        comprado = True
                    End If
                    Mireader.Close()
                    Conexion.Close()
                Catch ex As Exception
                Finally
                    Conexion.Close()
                End Try

                If (comprado = False) Then 'lo compramos por primera vez --> (precio/unidad * ctd)/cantidad = pvp
                    Try
                        Conexion.Open()
                        consulta = New SqlCommand("UPDATE ARTICULOS SET PRECIOPONDERADO ='" & CStr(pre).Replace(",", ".") &
                            "' WHERE CODIGO = '" & codar & "';", Conexion)
                        consulta.ExecuteNonQuery()
                        Conexion.Close()

                    Catch ex As Exception

                    Finally
                        Conexion.Close()
                    End Try

                ElseIf (comprado = True) Then 'si se compra por 2º vez --> (stockactual * precioponderado + precioactual * cantidad) / stockactual+cantidad
                    Dim preciopo, precioponnuevo As Double
                    Dim stockactual As Integer
                    'obtenemos el precioponderado y el stockactual
                    Try
                        Conexion.Open()
                        consulta = New SqlCommand("SELECT STOCKACTUAL,PRECIOPONDERADO FROM ARTICULOS WHERE CODIGO ='" & codar & "'", Conexion)
                        Mireader = consulta.ExecuteReader()
                        Mireader.Read()
                        preciopo = CSng(Mireader(1).ToString)
                        stockactual = CInt(Mireader(0).ToString)
                        Mireader.Close()
                        Conexion.Close()
                    Catch ex As Exception
                    Finally
                        Conexion.Close()
                    End Try

                    'calculamos el nuevo precioponderado
                    Try
                        Dim cantidad As Integer = CInt(ctd)
                        Dim pvp As Double = CDbl(pre)
                        precioponnuevo = ((preciopo * stockactual) + (pvp * cantidad))
                        precioponnuevo = precioponnuevo / (stockactual + cantidad)
                    Catch ex As Exception

                    End Try

                    'insertamos el nuevo precioponderado
                    Try
                        Conexion.Open()
                        consulta = New SqlCommand("UPDATE ARTICULOS SET PRECIOPONDERADO = '" & CStr(Format(precioponnuevo, "N2").Replace(".", "").Replace(",", ".")) &
                            "' WHERE CODIGO = '" & codar & "';", Conexion)
                        consulta.ExecuteNonQuery()
                        Conexion.Close()
                    Catch ex As Exception

                    Finally
                        Conexion.Close()
                    End Try
                End If
                'Actualizamos la fecha de compra
                Try
                    Conexion.Open()
                    consulta = New SqlCommand("UPDATE ARTICULOS SET FECHAULTIMACOMPRA = '" & Labfe.Text &
                        "' WHERE CODIGO = '" & codar & "';", Conexion)
                    consulta.ExecuteNonQuery()
                    Conexion.Close()
                Catch ex As Exception
                Finally
                    Conexion.Close()
                End Try
                'Actualizamos el precio de ultima compra
                Try
                    Conexion.Open()
                    consulta = New SqlCommand("UPDATE ARTICULOS SET PRECIOULTIMACOMPRA = '" & CStr(pre).Replace(".", "").Replace(",", ".") &
                        "' WHERE CODIGO = '" & codar & "';", Conexion)
                    consulta.ExecuteNonQuery()
                    Conexion.Close()
                Catch ex As Exception
                Finally
                    Conexion.Close()
                End Try
                'Actualizamos el proveedor
                Try
                    Conexion.Open()
                    consulta = New SqlCommand("UPDATE ARTICULOS SET CODPROVEEDORHAB = '" & tcodprov.Text &
                    "' WHERE CODIGO = '" & codar & "';", Conexion)
                    consulta.ExecuteNonQuery()
                    Conexion.Close()
                Catch ex As Exception
                Finally
                    Conexion.Close()
                End Try

                'Actualizamos los pvps
                Dim pvp1, pvp2, pvp3, pp As Single
                Try
                    Conexion.Open()
                    consulta = New SqlCommand("SELECT PRECIOPONDERADO FROM ARTICULOS WHERE CODIGO ='" & codar & "'", Conexion)
                    Mireader = consulta.ExecuteReader()
                    Mireader.Read()
                    pp = CSng(Mireader(0).ToString)
                    Mireader.Close()
                    Conexion.Close()
                Catch ex As Exception
                    Conexion.Close()
                End Try

                pvp1 = (pp * (Porctarifa1 + 100)) / 100
                pvp2 = (pp * (Porctarifa2 + 100)) / 100
                pvp3 = (pp * (Porctarifa3 + 100)) / 100
                pvp1 = Format(pvp1, "N2")
                pvp2 = Format(pvp2, "N2")
                pvp3 = Format(pvp3, "N2")


                Try
                    Conexion.Open()
                    consulta = New SqlCommand("UPDATE ARTICULOS SET PVP1 = '" & CStr(pvp1).Replace(".", "").Replace(",", ".") &
                    "' WHERE CODIGO = '" & codar & "';", Conexion)
                    consulta.ExecuteNonQuery()
                    Conexion.Close()
                Catch ex As Exception
                End Try

                Try
                    Conexion.Open()
                    consulta = New SqlCommand("UPDATE ARTICULOS SET PVP2 = '" & CStr(pvp2).Replace(".", "").Replace(",", ".") &
                    "' WHERE CODIGO = '" & codar & "';", Conexion)
                    consulta.ExecuteNonQuery()
                    Conexion.Close()
                Catch ex As Exception
                End Try

                Try
                    Conexion.Open()
                    consulta = New SqlCommand("UPDATE ARTICULOS SET PVP3 = '" & CStr(pvp3).Replace(".", "").Replace(",", ".") &
                    "' WHERE CODIGO = '" & codar & "';", Conexion)
                    consulta.ExecuteNonQuery()
                    Conexion.Close()
                Catch ex As Exception
                End Try
                contador = contador + 1
            End While

            ' Abrimos la conexion
            Conexion.Open()
            ' LA CABECERA DEL ALBARAN SE INSERTÓ CON ALGUNOS VALORES AL INSERTAR LINEAS DE ARTICULOS
            ' ACTUALIZAMOS LOS CAMPOS QUE FALTAN EN LA CABECERA
            consulta =
                New SqlCommand("UPDATE CabPieAlbaranCompra SET fecha = '" & Labfe.Text & "'," &
                               " direccion = '" & LabDir.Text & "'," &
                               " suma = " & Label19.Text.Replace(".", "").Replace(",", ".") & "," &
                               " bases = " & Label23.Text.Replace(".", "").Replace(",", ".") & "," &
                               " iva = " & Label24.Text.Replace(",", ".") & "," &
                               " sumatotal = " & Label25.Text.Replace(".", "").Replace(",", ".") & "," &
                               " formapago = '" & CStr(ComboBox1.SelectedIndex + 1) & "'," &
                               " observaciones ='" & TextBox9.Text & "'" &
                               " where codalbaran ='" & Labna.Text & "';", Conexion)
            consulta.ExecuteNonQuery()
            ' INTRODUZCO EL PORCENTAJE POR SEPARADO PORQUE ME DIÓ PROBLEMAS
            consulta = New SqlCommand("UPDATE CabPieAlbaranCompra SET porcentajeiva = " & CInt(ComboBox2.SelectedItem.ToString) &
                              " where codalbaran ='" & Labna.Text & "';", Conexion)
            consulta.ExecuteNonQuery()
            'MsgBox("Alta Albarán")

            'creamos la sentencia del libro de iva
            consulta = New SqlCommand("INSERT INTO LibroIVA VALUES ('" & Labna.Text & "','" & Labfe.Text & "','" & LabNom.Text &
                "','" & LabNif.Text & "','" & Label23.Text.Replace(".", "").Replace(",", ".") & "','" &
                Label24.Text.Replace(".", "").Replace(",", ".") & "'," &
                CInt(ComboBox2.SelectedItem.ToString) & ",'" &
                 Label25.Text.Replace(".", "").Replace(",", ".") &
                "','S')", Conexion)
            consulta.ExecuteNonQuery()
            ' Cerramos la conexion
            Conexion.Close()


            ' Inhabilitamos los botones ACEPTAR Y CANCELAR
            ' Habilitamos los botones IMPRIMIR Y SALIR 
            ButtonSal.Enabled = True
            ButtonAcep.Enabled = False
            ButtonCanc.Enabled = False
            'ButtonImp.Enabled = True

            'limpiarlinea()
            'limpiar()
            'dg.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try

    End Sub

    ' -------- BOTON CANCELAR ALBARÁN --------------------------------------------------------------------------------
    Private Sub ButtonCanc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCanc.Click

        ' Inhabilitamos el boton CANCELAR
        ButtonCanc.Enabled = False

        ' Limpiamos el DataGrid, las lineas de articulos, y el albaran entero
        dg.Rows.Clear()
        limpiarlinea()
        limpiar()

        ' Borramos de la base de datos las lineas de articulo dadas de alta
        BorrarLineasVenta()

        ' Borramos de la base de datos la parte de la cabecera que habiamos dado de alta. 
        ' Habiamos guardado el codigo del albaran, el codigo del cliente y facturado=N
        BorrarCabeceraAlbaran()

        ' Inicializamos el numero de lineas de articulo a 0
        numLinea = 0
        ' Inicializamos el importetotal a 0
        importetotal = 0

    End Sub

    ' ------- BORRAR CABECERA DEL ALBARÁN -----------------------------------------------------------------------------
    Private Sub BorrarCabeceraAlbaran()

        ' Borramos codalbaran, codcli y facturado del albaran
        Try
            Conexion.Open()
            consulta = New SqlCommand("Delete from CabPieAlbaranCompra where codalbaran ='" & Labna.Text & "';", Conexion)
            consulta.ExecuteNonQuery()
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'MsgBox("Datos de la cabecera del albaran borrados de la base de datos")

    End Sub

    ' -------- BORRAR LAS LINEAS DE ARTICULOS -------------------------------
    Private Sub BorrarLineasVenta()

        Dim contador As Integer
        Dim i As Integer

        ' Primero calculamos cuantas lineas tiene este albaran
        Try
            Conexion.Open()
            consulta = New SqlCommand("Select count(codalbaran) from LineasAlbaranCompra where codalbaran='" & Labna.Text & "';", Conexion)
            contador = consulta.ExecuteScalar
            Conexion.Close()
            'MsgBox("Este albaran contiene " & contador & " lineas de venta")
        Catch ex As Exception
        End Try

        ' Recorremos cada fila y por cada una, obtenemos el codigo del articulo y la cantidad que se ha pedido
        While i <= contador
            Dim cant As Integer = 0
            Dim codigoarticulo As String = ""
            ' Calcula la cantidad de articulos
            Try
                Conexion.Open()
                consulta = New SqlCommand("Select cantidad, codart from LineasAlbaranCompra where codalbaran = " & Labna.Text &
                    " and numlinea = " & i & ";", Conexion)
                Mireader = consulta.ExecuteReader()
                Mireader.Read()
                cant = CInt(Mireader("cantidad").ToString)      ' Cantidad de este articulo
                codigoarticulo = Mireader("codart").ToString    ' Codigo de este articulo
                Conexion.Close()
                Mireader.Close()
            Catch ex As Exception
                Conexion.Close()
            End Try

            ' Recalculamos el stock de cada articulo
            Try
                If Not codigoarticulo = "" Then
                    Conexion.Open()
                    consulta = New SqlCommand("Update Articulos set stockactual = stockactual - " & cant &
                        " where codigo = '" & codigoarticulo & "';", Conexion)
                    consulta.ExecuteNonQuery()
                    Conexion.Close()
                End If
            Catch ex As Exception
                Conexion.Close()
            End Try
            i = i + 1
        End While

        ' Borramos las lineas del albaran
        Try
            Conexion.Open()
            consulta = New SqlCommand("Delete from LineasAlbaranCompra where codalbaran ='" & Labna.Text & "';", Conexion)
            consulta.ExecuteNonQuery()
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'MsgBox("Datos de lineas de venta borrados de la base de datos")
    End Sub


    ' ------- BOTONES INACTIVOS AL INICIO DE LA APLICACION -----------
    Private Sub BotonesInactivos()
        'ButtonFac.Enabled = False       ' - BOTON FACTURA DIRECTA
        ButtonAcep.Enabled = False      ' - BOTON ACEPTAR 
        ButtonCanc.Enabled = False      ' - BOTON CANCELAR
        'ButtonImp.Enabled = False       ' - BOTON IMPRIMIR
        ButtonX.Enabled = False         ' - BOTON BUSCAR DATOS DEL PRODUCTO EN LINEAS DE ALBARAN
        ButtonM.Enabled = False         ' - BOTON AÑADIR LINEA DE ALBARAN
        ButtonC.Enabled = False         ' - BOTON CANCELAR LINEA DE ALBARAN
        ButtonOK.Enabled = False        ' - BOTON NO MAS LINEAS DE ALBARAN
        ButtonBusProv.Enabled = True     ' - BOTON BUSCAR PROVEEDOR
    End Sub

    ' ------- BOTONES ACTIVOS DESPUES DE BUSCAR EL PROVEEDOR -----------
    Private Sub BotonesActivos()
        'ButtonFac.Enabled = False       ' - BOTON FACTURA DIRECTA
        ButtonAcep.Enabled = False      ' - BOTON ACEPTAR 
        ButtonCanc.Enabled = True       ' - BOTON CANCELAR
        'ButtonImp.Enabled = False       ' - BOTON IMPRIMIR
        ButtonX.Enabled = True          ' - BOTON BUSCAR DATOS DEL PRODUCTO EN LINEAS DE ALBARAN
        ButtonM.Enabled = True          ' - BOTON AÑADIR LINEA DE ALBARAN
        ButtonC.Enabled = True          ' - BOTON CANCELAR LINEA DE ALBARAN
        ButtonOK.Enabled = True         ' - BOTON NO MAS LINEAS DE ALBARAN
        ButtonBusProv.Enabled = False   ' - BOTON BUSCAR PROVEEDOR
        ButtonSal.Enabled = False       ' - BOTON SALIR
    End Sub

    ' ------- MODO SOLO LECTURA PARA LOS TEXTBOX'S -------
    Private Sub SoloLectura()
        TextBox2.Enabled = False            ' - TEXTBOX DIRECCION DE ENTREGA A NOT ENABLED
        TextBox9.Enabled = False            ' - TEXTBOX OBSERVACIONES A NOT ENABLED
        'TextBox2.ReadOnly = True           ' - TEXTBOX DIRECCION DE ENTREGA
        TextBox1.ReadOnly = True            ' - TEXTBOX LINEA
        TextBox3.ReadOnly = True            ' - TEXTBOX CODIGO ARTICULO
        TextBox4.ReadOnly = True            ' - TEXTBOX DESCRIPCION
        TextBox5.ReadOnly = True            ' - TEXTBOX PVP
        TextBox6.ReadOnly = True            ' - TEXTBOX CANTIDAD
        'TextBox7.ReadOnly = True            ' - TEXTBOX DTO.LINEA
        TextBox8.ReadOnly = True            ' - TEXTBOX IMPORTE
        TextBox9.ReadOnly = True            ' - TEXTBOX OBSERVACIONES
        'TextBox10.ReadOnly = True           ' - TEXTBOX DESCUENTO
        'tbportes.ReadOnly = True            ' - TEXTBOX PORTES
    End Sub

    ' -------- MODO ESCRITURA PARA LAS LINEAS DE ALBARAN --------
    Private Sub EscrituraLineas()
        TextBox1.ReadOnly = True            ' - TEXTBOX LINEA
        TextBox3.ReadOnly = False           ' - TEXTBOX CODIGO ARTICULO
        TextBox4.ReadOnly = True            ' - TEXTBOX DESCRIPCION
        TextBox5.ReadOnly = True            ' - TEXTBOX PVP
        TextBox6.ReadOnly = False           ' - TEXTBOX CANTIDAD
        'TextBox7.ReadOnly = False           ' - TEXTBOX DTO.LINEA
        TextBox8.ReadOnly = True            ' - TEXTBOX IMPORTE
    End Sub

    ' -------- MODO ESCRITURA PARA EL PIE ----------------------
    Private Sub EscrituraPie()
        ComboBox1.Enabled = True            ' - COMBOBOX1 ENABLED
        ComboBox2.Enabled = True            ' - COMBOBOX2 ENABLED
        TextBox9.Enabled = True             ' - TEXTBOX OBSERVACIONES ENABLED
        TextBox9.ReadOnly = False           ' - TEXTBOX OBSERVACIONES
        'TextBox10.ReadOnly = False          ' - TEXTBOX DESCUENTO
        'tbportes.ReadOnly = False           ' - TEXTBOX PORTES
    End Sub

    ' --------- LIMPIAR LA LINEA DE ARTICULOS ------
    Private Sub limpiarlinea()
        TextBox1.Text = ""                  ' - TEXTBOX LINEA
        TextBox3.Text = ""                  ' - TEXTBOX CODIGO ARTICULO
        TextBox4.Text = ""                  ' - TEXTBOX DESCRIPCION
        TextBox5.Text = ""                  ' - TEXTBOX PVP
        TextBox6.Text = ""                  ' - TEXTBOX CANTIDAD
        'TextBox7.Text = ""                  ' - TEXTBOX DTO.LINEA
        TextBox8.Text = ""                  ' - TEXTBOX IMPORTE
    End Sub

    ' -------- LIMPIA TODO EL ALBARÁN MENOS LINEAS DE ARTICULOS ---------
    Private Sub limpiar()
        ButtonAcep.Enabled = False
        ButtonSal.Enabled = True
        ButtonM.Enabled = False
        ButtonX.Enabled = False
        ButtonOK.Enabled = False
        ButtonC.Enabled = False
        tcodprov.Enabled = True
        tcodprov.Text = ""
        LabDir.Text = ""
        LabNif.Text = ""
        LabNom.Text = ""
        TextBox2.Text = ""
        TextBox9.Text = ""
        Label19.Text = ""
        Label23.Text = ""
        Label24.Text = ""
        Label25.Text = ""
    End Sub

    ' --------- EVENTO SI EL CODIGO DE CLIENTE CAMBIA --------------------------------------------------------------
    Private Sub tcodcli_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcodprov.TextChanged
        ButtonBusProv.Enabled = True
    End Sub

    Private Sub ButtonSal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSal.Click
        Me.Close()
    End Sub
End Class