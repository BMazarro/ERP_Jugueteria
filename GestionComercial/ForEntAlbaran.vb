Imports System.Data.SqlClient

Public Class ForEntAlbaran

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

    ' --------- INICIO DE LA APLICACION -----------------------------------------------------------------------------
    Private Sub ForEntAlbaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load      

        ' Centramos la ventana
        Me.CenterToScreen()
        ' ----------------------------------------------------------------------------------------------------
        Dim contador As Integer         ' - Variable que cuenta la cantidad de albaranes que hay dados de alta
        Dim num As Integer = 1

        ' Ponemos el foco en el codigo del cliente a buscar
        tcodcli.Focus()
        tcodcli.BackColor = Color.Aquamarine
        ' Inicializamos la fecha de hoy
        Labfe.Text = fecha

        ' Solo lectura para los textbox's
        SoloLectura()

        ' Desactivar botones
        BotonesInactivos()

        Try ' Abrimos conexion --------------------------------------------------------
            Conexion.Open()

            ' Obtenemos el Nº de Albarán contando los registros que hay en la BD
            consulta = New SqlCommand("Select count(codalbaran) from CabPieAlbaran", Conexion)
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

    
    ' --------- BUSCAR EL CLIENTE INTRODUCIDO ------------------------------------------------------------------------
    Private Sub ButtonBusCli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBusCli.Click

        Dim posicion As Integer
        TextBox3.Focus()
        TextBox7.Text = "0"
        Try ' Abrimos la conexion
            Conexion.Open()

            ' Buscamos el codigo introducido y vemos en que posicion se encuentra
            consulta = New SqlCommand("Select codcli from Clientes where codcli='" &
                                      tcodcli.Text & "';", Conexion)
            posicion = consulta.ExecuteScalar()   'Obtenemos la cantidad de registros que tiene hasta su posicion

            ' Si el valor devuelto no existe entonces volvemos al inicio de la aplicacion
            If posicion = Nothing Then

                If MessageBox.Show("Desea crear uno nuevo?", "El cliente no existe", _
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                                        = DialogResult.Yes Then
                    ' Gestionamos el cierre de la ventana actual y la abertura de la nueva
                    Dim alta As New ForClientes
                    alta.ShowDialog()
                Else
                    tcodcli.Text = ""
                End If
            Else
                ' Seleccionamos los datos del cliente introducido
                consulta = New SqlCommand("Select * from Clientes where codcli='" &
                                          tcodcli.Text & "';", Conexion)
                ' Rellemos el datareader con los datos
                Mireader = consulta.ExecuteReader()
                ' Leemos el datareader
                Mireader.Read()
                ' Mostramos los datos del cliente
                MostrarDatosCliente()
                ' Habilitamos botones de las lineas de albaran
                BotonesActivos()
                ' Habilitamos la escritura en los campos del articulo de las lineas de albaran
                EscrituraLineas()
                ' Damos color indicativo al campo codigo articulo
                TextBox3.BackColor = Color.LightBlue
                dg.ClearSelection()
                Me.dg.Item(1, 0).Selected = True
            End If
                ' - Cerramos la conexion y el datareader
                Conexion.Close()
                Mireader.Close()

        Catch ex As Exception
            MsgBox("No ha introducido ningun código de cliente")
            Mireader.Close()
        Finally
            If Conexion.State = ConnectionState.Open Then
                Conexion.Close()
            End If
        End Try
    End Sub

    ' -------- MOSTRAR LOS DATOS DEL CLIENTE -------------
    Private Sub MostrarDatosCliente()
        LabNom.Text = Mireader("nombre").ToString
        LabDir.Text = Mireader("direccion").ToString
        LabNif.Text = Mireader("nif").ToString
        LabTar.Text = Mireader("tarifa").ToString
        LabDes.Text = Mireader("descuento").ToString
        TextBox2.Text = Mireader("direccionentrega").ToString
    End Sub

    ' -------- BUSCAR DATOS DE ARTICULOS EN LAS LINEAS DE ALBARAN -----------------------------------------------
    Private Sub ButtonX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX.Click
        TextBox7.Text = "0"
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
        If LabTar.Text = 1 Then TextBox5.Text = Mireader("pvp1").ToString
        If LabTar.Text = 2 Then TextBox5.Text = Mireader("pvp2").ToString
        If LabTar.Text = 3 Then TextBox5.Text = Mireader("pvp3").ToString
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

    ' --- SI CAMBIA EL DESCUENTO, recalcula el importe de la linea ---------------------------------------------
    Private Sub TextBox7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

        'Dim precio As Double
        Dim cant As Double
        Dim desc As Double
        If Not TextBox6.Text = "" Then
            cant = CDbl(TextBox6.Text)
        End If

        Try ' Controlamos el precio
            If Not TextBox5.Text = "" Then
                precio = TextBox5.Text
            Else
                precio = 0.0
            End If
            ' Controlamos el descuento
            If Not TextBox7.Text = "" Then
                descuentoLinea = CDbl(TextBox7.Text)
                desc = (cant * precio) * (descuentoLinea / 100)
            Else
                desc = 0.0
                descuentoLinea = 0.0
            End If
            importeLinea = (cant * precio) - desc
            ' Formateamos la salida
            TextBox8.Text = Format(importeLinea, "N2")
        Catch ex As Exception
        End Try

    End Sub

    ' ------- AÑADIR LINEA AL DATAGRID ------------------------------------------------------------------------
    Private Sub ButtonM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonM.Click

        ' Inhabilitamos a partir de ahora el codigo del cliente, ya no se puede cambiar 
        tcodcli.Enabled = False
        ' Inabilitamos la direccion de entrega, ya no se puede cambiar
        TextBox2.ReadOnly = True

        Try ' Abrimos la conexion
            Conexion.Open()
            ' Añadimos la linea al DataGrid
            dg.Rows.Add(TextBox1.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text)
            
            ' Insertamos la cabecera. Controlamos con la variable c que solo se inserte una vez
            If (c = 0) Then
                consulta =
                    New SqlCommand("INSERT INTO CabPieAlbaran(codalbaran,codcli,facturado)" &
                " values(" & "'" & Labna.Text & "'" & "," & "'" & tcodcli.Text & "'" & "," & "'N'" & ")", Conexion)
                consulta.ExecuteNonQuery()
                c = 1
            End If

            ' Insertamos la linea introducida
            consulta =
                New SqlCommand("INSERT INTO LineasAlbaran(codalbaran,numlinea,codart,descripcion,pvp,cantidad,dtolinea,importe)" &
                 " values(" & "'" & Labna.Text & "'" & "," & "'" & numLinea & "'" &
                 "," & "'" & TextBox3.Text & "'" & "," & "'" & TextBox4.Text & "'" &
                 "," & TextBox5.Text.Replace(".", "").Replace(",", ".") & "," & TextBox6.Text.Replace(",", ".") &
                 "," & TextBox7.Text.Replace(",", ".") & "," & TextBox8.Text.Replace(".", "").Replace(",", ".") & ")", Conexion)

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
            consulta = New SqlCommand("UPDATE Articulos set stockactual = stockactual - " & _
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
            consulta = New SqlCommand("UPDATE Articulos set stockactual = stockactual + " & _
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
        consulta = New SqlCommand("SELECT SUM(IMPORTE) FROM LINEASALBARAN WHERE CODALBARAN='" &
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
        CalcularImportes()
        ' Habilitamos los controles del pie
        EscrituraPie()
        ' Asignamos el descuento correspondiente a ese cliente
        TextBox10.Text = LabDes.Text
        ' Calculamos el descuento que se le restará y lo formateamos
        des = (TextBox10.Text / 100) * Label19.Text
        Label17.Text = Format(des, "N2")
        ' ----------------------------------------------------------------------------
        ' Inhabilitamos las lineas del albarán para que no se puedan introducir datos
        TextBox1.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        ' ----------------------------------------------------------------------------
        ' Inhabilitamos los botones correspondientes a las lineas del albarán
        ButtonM.Enabled = False
        ButtonX.Enabled = False
        ButtonOK.Enabled = False
        ButtonC.Enabled = False
        ' ----------------------------------------------------------------------------
    End Sub
    ' -------- EVENTO SI CAMBIA EL VALOR DEL DESCUENTO -----------------------------------------------------------------
    Private Sub TextBox10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged

        ' Controlamos que la casilla de descuento tenga algun valor
        If Not TextBox10.Text = "" Then
            ' Calculamos el descuento que se le restará y lo formateamos
            des = (TextBox10.Text / 100) * Label19.Text
            Label17.Text = Format(des, "##,##0.00")
        End If

    End Sub

    ' -------- EVENTO SI CAMBIA EL VALOR DE LOS PORTES ---------------------------------------------------------------
    Private Sub tbportes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbportes.TextChanged

        ' Variables del evento
        Dim imponible As Double
        Dim a As Double
        Dim b As Double

        ' Controlamos que en caso de que la casilla descuento estuviera vacía establecemos descuento 0
        If TextBox10.Text = "" Then
            TextBox10.Text = 0
            des = 0.0
            Label17.Text = Format(des, "N2")
        End If

        Try
            ' Controlamos que la casilla portes tenga algun valor
            If Not tbportes.Text = "" Then
                ' Calculamos la base imponible y formateamos la salida
                imponible = CDbl(tbportes.Text) + CDbl(Label19.Text) - des
                Label23.Text = Format(imponible, "N2")
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
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' ------- EVENTO SI CAMBIA EL VALOR DEL COMBOBOX DEL IVA ------------------------------------------------------------------------------------
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

        ' Variables del evento
        Dim imponible As Double
        Dim a As Double
        Dim b As Double

        ' Controlamos que exista un valor en el importe y los portes no este vacios
        If Not tbportes.Text = "" And Not Label19.Text = "" Then
            ' Calculamos la base imponible y formateamos la salida
            imponible = CDbl(tbportes.Text) + CDbl(Label19.Text) - des
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
            consulta = New SqlCommand("Delete from CabPieAlbaran where codalbaran ='" & Labna.Text & "';", Conexion)
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
            consulta = New SqlCommand("Select count(codalbaran) from LineasAlbaran where codalbaran='" & Labna.Text & "';", Conexion)
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
                consulta = New SqlCommand("Select cantidad, codart from LineasAlbaran where codalbaran = " & Labna.Text &
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
                    consulta = New SqlCommand("Update Articulos set stockactual = stockactual + " & cant &
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
            consulta = New SqlCommand("Delete from LineasAlbaran where codalbaran ='" & Labna.Text & "';", Conexion)
            consulta.ExecuteNonQuery()
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'MsgBox("Datos de lineas de venta borrados de la base de datos")
    End Sub

    ' ------- BOTON ACEPTAR ALBARÁN ---------------------------------------------------------------------------------
    Private Sub ButtonAcep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAcep.Click

        Try ' Abrimos la conexion
            Conexion.Open()
            Dim suma As String
            suma = Label19.Text.Replace(".", "")
            suma = suma.Replace(",", ".")

            ' LA CABECERA DEL ALBARAN SE INSERTÓ CON ALGUNOS VALORES AL INSERTAR LINEAS DE ARTICULOS
            ' ACTUALIZAMOS LOS CAMPOS QUE FALTAN EN LA CABECERA
            consulta =
                New SqlCommand("UPDATE CabPieAlbaran SET fecha = '" & Labfe.Text & "'," &
                               " direccion = '" & LabDir.Text & "'," &
                               " suma = " & suma & "," &
                               " dto = " & TextBox10.Text.Replace(",", ".") & "," &
                               " portes = " & tbportes.Text.Replace(".", "").Replace(",", ".") & "," &
                               " bases = " & Label23.Text.Replace(".", "").Replace(",", ".") & "," &
                               " iva = " & Label24.Text.Replace(",", ".") & "," &
                               " sumatotal = " & Label25.Text.Replace(".", "").Replace(",", ".") & "," &
                               " formapago = '" & CStr(ComboBox1.SelectedIndex + 1) & "'," &
                               " observaciones ='" & TextBox9.Text & "'" &
                               " where codalbaran ='" & Labna.Text & "';", Conexion)
            consulta.ExecuteNonQuery()
            ' INTRODUZCO EL PORCENTAJE POR SEPARADO PORQUE ME DIÓ PROBLEMAS
            consulta = New SqlCommand("UPDATE CabPieAlbaran SET porcentajeiva = " & CInt(ComboBox2.SelectedItem.ToString) &
                              " where codalbaran ='" & Labna.Text & "';", Conexion)
            consulta.ExecuteNonQuery()
            'MsgBox("Alta Albarán")

            ' Cerramos la conexion
            Conexion.Close()

            ' Inhabilitamos los botones ACEPTAR Y CANCELAR
            ' Habilitamos los botones IMPRIMIR Y SALIR 
            ButtonSal.Enabled = True
            ButtonAcep.Enabled = False
            ButtonCanc.Enabled = False
            ButtonImp.Enabled = True
            ButtonFac.Enabled = True


            'limpiarlinea()
            'limpiar()
            'dg.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try

    End Sub

    ' -------- IMPRIME EL ALBARAN CORRESPONDIENTE ------------------------------------------------------------------
    Private Sub ButtonImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImp.Click
        ' Creamos una nueva conexion
        Dim Conexion2 As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
        ' Creamos un Visor
        Dim visor As New Visor
        ' Creamos un dataset
        Dim dataset As New NuevoDataSet
        ' Creamos un Listado para Albaranes
        Dim listado As New Albaran
        ' Creamos un DataAdapter
        Dim da1 As SqlClient.SqlDataAdapter

        ' Creamos las consultas y rellenamos el dataset 
        da1 = New SqlClient.SqlDataAdapter("SELECT * FROM CabPieAlbaran WHERE CabPieAlbaran.codalbaran= '" & Labna.Text & "';", Conexion2)
        da1.Fill(dataset, "CABPIEALBARAN")
        da1 = New SqlClient.SqlDataAdapter("SELECT Articulos.*, LineasAlbaran.* FROM Articulos, LineasAlbaran WHERE Articulos.codigo = LineasAlbaran.codart and LineasAlbaran.codalbaran = '" & Labna.Text & "';", Conexion2)
        da1.Fill(dataset, "LINEASALBARAN")
        da1.Fill(dataset, "ARTICULOS")
        da1 = New SqlClient.SqlDataAdapter("SELECT * FROM Clientes WHERE Clientes.codcli = '" & tcodcli.Text & "';", Conexion2)
        da1.Fill(dataset, "CLIENTES")
        da1 = New SqlClient.SqlDataAdapter("SELECT FormasPago.* FROM FormasPago, CabPieAlbaran WHERE CabPieAlbaran.formapago = FormasPago.tipo and CabPieAlbaran.codalbaran= '" & Labna.Text & "';", Conexion2)
        Try
            da1.Fill(dataset, "FORMASPAGO")
        Catch ex As System.Data.ConstraintException
            MsgBox(ex.Message)
        End Try

        '---Cerramos la conexion 
        Conexion2.Close()

        ' Preparamos el Visor 
        visor.CrViewer.ReportSource = listado
        listado.SetDataSource(dataset)

        ' Mostramos los parámetros de los datos de Empresa
        listado.SetParameterValue("nombre", nombre.ToString)
        listado.SetParameterValue("domicilio", domicilio.ToString)
        listado.SetParameterValue("localidad", localidad.ToString)
        listado.SetParameterValue("provincia", provincia.ToString)
        listado.SetParameterValue("cp", cp.ToString)
        listado.SetParameterValue("nif", nif.ToString)
        listado.SetParameterValue("telefono", telefono.ToString)

        ' Mostramos el Visor
        visor.Show()

        ' Inhabilitamos el boton IMPRIMIR
        ButtonImp.Enabled = False
    End Sub

    ' ------- BOTONES INACTIVOS AL INICIO DE LA APLICACION -----------
    Private Sub BotonesInactivos()
        ButtonFac.Enabled = False       ' - BOTON FACTURA DIRECTA
        ButtonAcep.Enabled = False      ' - BOTON ACEPTAR 
        ButtonCanc.Enabled = False      ' - BOTON CANCELAR
        ButtonImp.Enabled = False       ' - BOTON IMPRIMIR
        ButtonX.Enabled = False         ' - BOTON BUSCAR DATOS DEL PRODUCTO EN LINEAS DE ALBARAN
        ButtonM.Enabled = False         ' - BOTON AÑADIR LINEA DE ALBARAN
        ButtonC.Enabled = False         ' - BOTON CANCELAR LINEA DE ALBARAN
        ButtonOK.Enabled = False        ' - BOTON NO MAS LINEAS DE ALBARAN
        ButtonBusCli.Enabled = True     ' - BOTON BUSCAR CLIENTE
    End Sub

    ' ------- BOTONES ACTIVOS DESPUES DE BUSCAR EL CLIENTE -----------
    Private Sub BotonesActivos()
        ButtonFac.Enabled = False       ' - BOTON FACTURA DIRECTA
        ButtonAcep.Enabled = False      ' - BOTON ACEPTAR 
        ButtonCanc.Enabled = True       ' - BOTON CANCELAR
        ButtonImp.Enabled = False       ' - BOTON IMPRIMIR
        ButtonX.Enabled = True          ' - BOTON BUSCAR DATOS DEL PRODUCTO EN LINEAS DE ALBARAN
        ButtonM.Enabled = True          ' - BOTON AÑADIR LINEA DE ALBARAN
        ButtonC.Enabled = True          ' - BOTON CANCELAR LINEA DE ALBARAN
        ButtonOK.Enabled = True         ' - BOTON NO MAS LINEAS DE ALBARAN
        ButtonBusCli.Enabled = False    ' - BOTON BUSCAR CLIENTE
        ButtonSal.Enabled = False       ' - BOTON SALIR
    End Sub

    ' ------- MODO SOLO LECTURA PARA LOS TEXTBOX'S -------
    Private Sub SoloLectura()
        TextBox2.Enabled = False            ' - TEXTBOX DIRECCION DE ENTREGA A NOT ENABLED
        TextBox9.Enabled = False            ' - TEXTBOX OBSERVACIONES A NOT ENABLED
        'TextBox2.ReadOnly = True            ' - TEXTBOX DIRECCION DE ENTREGA
        TextBox1.ReadOnly = True            ' - TEXTBOX LINEA
        TextBox3.ReadOnly = True            ' - TEXTBOX CODIGO ARTICULO
        TextBox4.ReadOnly = True            ' - TEXTBOX DESCRIPCION
        TextBox5.ReadOnly = True            ' - TEXTBOX PVP
        TextBox6.ReadOnly = True            ' - TEXTBOX CANTIDAD
        TextBox7.ReadOnly = True            ' - TEXTBOX DTO.LINEA
        TextBox8.ReadOnly = True            ' - TEXTBOX IMPORTE
        TextBox9.ReadOnly = True            ' - TEXTBOX OBSERVACIONES
        TextBox10.ReadOnly = True           ' - TEXTBOX DESCUENTO
        tbportes.ReadOnly = True            ' - TEXTBOX PORTES
    End Sub

    ' -------- MODO ESCRITURA PARA LAS LINEAS DE ALBARAN --------
    Private Sub EscrituraLineas()
        TextBox1.ReadOnly = True            ' - TEXTBOX LINEA
        TextBox3.ReadOnly = False           ' - TEXTBOX CODIGO ARTICULO
        TextBox4.ReadOnly = True            ' - TEXTBOX DESCRIPCION
        TextBox5.ReadOnly = True            ' - TEXTBOX PVP
        TextBox6.ReadOnly = False           ' - TEXTBOX CANTIDAD
        TextBox7.ReadOnly = False           ' - TEXTBOX DTO.LINEA
        TextBox8.ReadOnly = True            ' - TEXTBOX IMPORTE
    End Sub

    ' -------- MODO ESCRITURA PARA EL PIE ----------------------
    Private Sub EscrituraPie()
        ComboBox1.Enabled = True            ' - COMBOBOX1 ENABLED
        ComboBox2.Enabled = True            ' - COMBOBOX2 ENABLED
        TextBox9.Enabled = True             ' - TEXTBOX OBSERVACIONES ENABLED
        TextBox9.ReadOnly = False           ' - TEXTBOX OBSERVACIONES
        TextBox10.ReadOnly = False          ' - TEXTBOX DESCUENTO
        tbportes.ReadOnly = False           ' - TEXTBOX PORTES
    End Sub

    ' --------- LIMPIAR LA LINEA DE ARTICULOS ------
    Private Sub limpiarlinea()
        TextBox1.Text = ""                  ' - TEXTBOX LINEA
        TextBox3.Text = ""                  ' - TEXTBOX CODIGO ARTICULO
        TextBox4.Text = ""                  ' - TEXTBOX DESCRIPCION
        TextBox5.Text = ""                  ' - TEXTBOX PVP
        TextBox6.Text = ""                  ' - TEXTBOX CANTIDAD
        TextBox7.Text = ""                  ' - TEXTBOX DTO.LINEA
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
        tcodcli.Enabled = True
        tcodcli.Text = ""
        LabDes.Text = ""
        LabDir.Text = ""
        LabNif.Text = ""
        LabNom.Text = ""
        LabTar.Text = ""
        TextBox2.Text = ""
        TextBox10.Text = ""
        TextBox9.Text = ""
        Label19.Text = ""
        Label17.Text = ""
        tbportes.Text = ""
        Label23.Text = ""
        Label24.Text = ""
        Label25.Text = ""
    End Sub

    ' --------- EVENTO SI EL CODIGO DE CLIENTE CAMBIA --------------------------------------------------------------
    Private Sub tcodcli_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcodcli.TextChanged
        ButtonBusCli.Enabled = True
    End Sub

    ' -------- BOTON SALIR DE LA APLICACION -----------------------------------------------------
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSal.Click
        'ForEntAlbaran_Load(sender, e)
        Me.Close()
    End Sub

    ' -------- BOTON FACTURA DIRECTA -----------------------------------------------------------------------------
    Private Sub ButtonFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFac.Click
        Dim cant As Integer = 0
        Dim contador As Integer = 0
        Dim codigoF As String
        ' Calcula la cantidad de facturas
        Try
            Conexion.Open()
            ' Obtenemos el Nº de Factura contando los registros que hay en la BD
            consulta = New SqlCommand("Select count(codfactura) from CabPieFactura", Conexion)
            contador = consulta.ExecuteScalar() ' Devuelve un número
            codigoF = (contador + 1).ToString
            Conexion.Close()
        Catch ex As Exception
            Conexion.Close()
        End Try

        Try  ' Damos de alta la cabecera de la factura
            Conexion.Open()
            consulta = New SqlCommand("Insert into CabPieFactura values('" & codigoF & "','" &
                Labfe.Text & "','" & tcodcli.Text & "','" & LabDir.Text & "'," &
                "'N'" & "," & Label19.Text.Replace(".", "").Replace(",", ".") & "," &
                TextBox10.Text.Replace(".", "").Replace(",", ".") & "," &
                    tbportes.Text.Replace(".", "").Replace(",", ".") & "," &
                    Label23.Text.Replace(".", "").Replace(",", ".") & "," &
                    Label24.Text.Replace(",", ".") & "," &
                    Label25.Text.Replace(".", "").Replace(",", ".") & ",'" &
                CStr(ComboBox1.SelectedIndex + 1) & "','" &
                TextBox9.Text & "'," &
                CInt(ComboBox2.SelectedItem.ToString) & ");", Conexion)
            consulta.ExecuteNonQuery()
            Conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion.Close()
        End Try

        Try 'Damos de alta el cuerpo de la factura
            Conexion.Open()
            consulta = New SqlCommand("Insert into LineasFactura Select * from LineasAlbaran where codalbaran = '" & Labna.Text & "'", Conexion)
            consulta.ExecuteNonQuery()
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion.Close()
        End Try

        Try  ' Actualizamos el codigo de factura de las lineas
            Conexion.Open()
            consulta = New SqlCommand("Update LineasFactura set codfactura = '" & codigoF & "' where codfactura = '" & Labna.Text & "'", Conexion)
            consulta.ExecuteNonQuery()
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion.Close()
        End Try

        Try ' Ponemos el albaran como facturado
            Conexion.Open()
            consulta = New SqlCommand("Update CabPieAlbaran set facturado = 'S' where codalbaran = '" & Labna.Text & "'", Conexion)
            consulta.ExecuteNonQuery()
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion.Close()
        End Try

        'Dar de alta la factura en el libro de iva
        Dim icodfactura, ifecha, icodcli, ibases, iiva, iimporte, inombre, inif, ibanco, icuenta, iporcentaje As String

        Try ' Obtenemos los datos de la factura
            Conexion.Open()
            consulta = New SqlCommand("Select codfactura,fecha,codcli,bases,iva,sumatotal,porcentajeiva from CabPieFactura where codfactura ='" & codigoF & "'", Conexion)
            Mireader = consulta.ExecuteReader()
            Mireader.Read()
            icodfactura = Mireader("codfactura").ToString
            ifecha = CStr(Format(CDate(Mireader("fecha").ToString), "d"))
            icodcli = Mireader("codcli").ToString
            ibases = Mireader("bases").ToString.Replace(".", "").Replace(",", ".")
            iiva = CStr(Format(CDbl(Mireader("iva").ToString), "N")).Replace(".", "").Replace(",", ".")
            iporcentaje = Mireader("porcentajeiva").ToString
            iimporte = CStr(Format(CDbl(Mireader("sumatotal").ToString), "N")).Replace(".", "").Replace(",", ".")
            Mireader.Close()
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion.Close()
        End Try

        Try ' Obtenemos los datos de la factura
            Conexion.Open()
            consulta = New SqlCommand("Select nombre,nif,banco,cuenta from clientes where codcli='" & icodcli & "'", Conexion)
            Mireader = consulta.ExecuteReader()
            Mireader.Read()
            inombre = Mireader("nombre").ToString
            inif = Mireader("nif").ToString
            ibanco = Mireader("banco").ToString
            icuenta = Mireader("cuenta").ToString
            Mireader.Close()
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion.Close()
        End Try

        Try ' Damos de alta en el libro de IVA
            Conexion.Open()
            consulta = New SqlCommand("Insert into LibroIva values('" & icodfactura & "','" & ifecha & "','" & inombre &
            "','" & inif & "','" & ibases & "','" & iiva & "','" & iporcentaje & "','" & iimporte &
            "','R')", Conexion)
            consulta.ExecuteNonQuery()
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion.Close()
        End Try


        If MessageBox.Show("Desea imprimir la factura?", "Advertencia", _
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                                        = DialogResult.Yes Then

            ' Creamos una nueva conexion
            Dim Conexion2 As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
            ' Creamos un Visor
            Dim visor As New Visor
            ' Creamos un dataset
            Dim dataset As New NuevoDataSet
            ' Creamos un Listado para Albaranes
            Dim listado As New Factura
            ' Creamos un DataAdapter
            Dim da1 As SqlClient.SqlDataAdapter

            ' Creamos las consultas y rellenamos el dataset 
            da1 = New SqlClient.SqlDataAdapter("SELECT * FROM CabPieFactura WHERE CabPieFactura.codfactura= '" & codigoF & "';", Conexion2)
            da1.Fill(dataset, "CABPIEFACTURA")
            da1 = New SqlClient.SqlDataAdapter("SELECT LineasFactura.* FROM LineasFactura WHERE LineasFactura.codfactura = '" & codigoF & "';", Conexion2)
            da1.Fill(dataset, "LINEASFACTURA")
            da1 = New SqlClient.SqlDataAdapter("SELECT * FROM Clientes WHERE Clientes.codcli = '" & tcodcli.Text & "';", Conexion2)
            da1.Fill(dataset, "CLIENTES")
            da1 = New SqlClient.SqlDataAdapter("SELECT FormasPago.* FROM FormasPago, CabPieFactura WHERE CabPieFactura.formapago = FormasPago.tipo and CabPieFactura.codfactura= '" & codigoF & "';", Conexion2)
            Try
                da1.Fill(dataset, "FORMASPAGO")
            Catch ex As System.Data.ConstraintException
                MsgBox(ex.Message)
            End Try

            '---Cerramos la conexion 
            Conexion2.Close()

            ' Preparamos el Visor 
            visor.CrViewer.ReportSource = listado
            listado.SetDataSource(dataset)

            ' Mostramos los parámetros de los datos de Empresa
            listado.SetParameterValue("nombre", nombre.ToString)
            listado.SetParameterValue("domicilio", domicilio.ToString)
            listado.SetParameterValue("localidad", localidad.ToString)
            listado.SetParameterValue("provincia", provincia.ToString)
            listado.SetParameterValue("cp", cp.ToString)
            listado.SetParameterValue("nif", nif.ToString)
            listado.SetParameterValue("telefono", telefono.ToString)

            ' Mostramos el Visor
            visor.Show()
            ' Ponemos la factura impresa
            Try
                Conexion.Open()
                consulta = New SqlCommand("Update CabPieFactura set impreso = 'S' where codfactura = '" & codigoF & "'", Conexion)
                consulta.ExecuteNonQuery()
                Conexion.Close()
            Catch ex As Exception
            Finally
                Conexion.Close()
            End Try
        End If

        ' Inhabilitamos el boton factura y el de imprimir
        ButtonFac.Enabled = False
        ButtonImp.Enabled = False

        'Creamos los recibos para esa factura
        Dim codrecibo As Integer = 1
        Dim cantidadrecibos As Integer = 0
        Dim intervalo As Integer
        Dim fechaprev As Date
        Dim total, importerecibo As Double
        'obtenemos la fecha de la factura
        fechaprev = Labfe.Text

        total = CDbl(iimporte.Replace(".", ","))

        'obtenemos la cantidad de recibos(plazos) y su intervalo
        Try
            Conexion.Open()
            consulta = New SqlCommand("Select recibos, intervaloTiempo from FormasPago where tipo ='" & CStr(ComboBox1.SelectedIndex + 1) & "'", Conexion)
            Mireader = consulta.ExecuteReader() ' 
            Mireader.Read()
            cantidadrecibos = CInt(Mireader("recibos").ToString)
            intervalo = CInt(Mireader("intervaloTiempo").ToString)
            Mireader.Close()
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion.Close()
        End Try

        'Comprobamos si tiene plazos o no
        If (cantidadrecibos >= 1) Then 'si tiene plazos
            importerecibo = total / cantidadrecibos
            importerecibo = Math.Truncate(importerecibo)

            While codrecibo <= cantidadrecibos 'para todos los recibos

                fechaprev = fechaprev.AddDays(intervalo) 'sumamos el intervalo a la fecha

                If (codrecibo = cantidadrecibos) Then 'si el recibo es el ultimo
                    importerecibo = total
                Else
                    total = total - importerecibo 'si no es el ultimo
                End If

                'insertamos el recibo
                Try
                    Conexion.Open()
                    consulta = New SqlCommand("Insert into Recibos values('" & codrecibo & "','" & inombre & "','" &
                        codigoF & "','" & ibanco & "','" & icuenta & "','" & fechaprev & "','" &
                        CStr(importerecibo).Replace(",", ".") & "','N')", Conexion)
                    consulta.ExecuteNonQuery()
                    Conexion.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Conexion.Close()
                End Try
                codrecibo += 1
            End While
        End If
    End Sub
End Class