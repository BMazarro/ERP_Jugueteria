Imports System.Data.SqlClient

Public Class ForMantenimientoAlbaran

    Dim Conexion As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Dim consulta As New SqlCommand
    Dim Mireader As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DistribuidoraJuguetesDataSet

    Private numLinea As Integer = 0         ' - Variable Contador de lineas de albarán
    Private importetotal As Double = 0.0    ' - Variable Global para el importe total
    Private des As Double = 0.0             ' - Variable que uso para hacer calcular el descuento y sus cambios
    Dim Iiva As Integer                     ' - Variable Global para el IVA
    Dim facturado As String                 ' - Variable Global para el facturado (S/N)
    Dim formapago As Char                   ' - Variable Global para almacenar la Forma de Pago (1|2|3)
    Dim porcentajeiva As Integer            ' - Variable Global para almacenar el porcentaje de Iva
    Dim importeLinea As Double = 0.0        ' - Variable Global para el importe de linea
    Dim precio As Double = 0.0              ' - Variable Global para el precio de un producto
    Dim descuentoLinea As Double = 0.0      ' - Variable Global para el descuento en linea

    Private Sub ForMantenimientoAlbaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Centramos la ventana
        Me.CenterToScreen()
        ' ----------------------------------------------------------------------------------------------------

        ' Ponemos el foco en el codigo del albaran a buscar
        tbcodalb.Focus()
        tbcodalb.BackColor = Color.Aquamarine
        ' Solo lectura para los textbox's
        SoloLectura()

        ' Desactivar botones
        BotonesInactivos()

        Try ' Abrimos conexion --------------------------------------------------------
            Conexion.Open()

            ' SI ELEGIMOS MANTENER UN ALBARAN QUE NO EXISTE, SE ABRE LA VENTANA DE ENTRADA DE NUEVO
            ' ALBARAN Y SE CAMBIA LA VARIABLE GLOBAL "ESTADO" A 1. 
            ' UNA VEZ INTRODUCIDO EL NUEVO ALBARÁN PODEMOS QUERER CONSERVAR LA VENTANA
            ' DE MANTENIMIENTO PARA ESE NUEVO ALBARAN CREADO. ESTA INSTRUCCION COMPRUEBA SI SE 
            ' HA CREADO EL NUEVO ALBARAN Y SI SE QUIERE MANTENER, PARA ELLO MIRA SI LA VARIABLE GLOBLA ESTA A 1
            ' Y SI ES ASÍ MUESTRA EL CODIGO DEL ALBARAN CORRESPONDIENTE.
            If (DatosEmpresa.estado = 1) Then
                consulta = New SqlCommand("Select count(*) from CabPieAlbaran", Conexion)
                Dim contador = consulta.ExecuteScalar()
                tbcodalb.Text = contador
            End If

            ' Rellenamos los Combos
            ComboIva()
            ComboFormasPago()

            '- Cerramos conexion
            Conexion.Close()
            ' -----------------------------------------------------------------------
        Catch ex As Exception
            MsgBox("No se ha podido establecer la conexión")
        Finally
            If Conexion.State = ConnectionState.Open Then
                Conexion.Close()
            End If
        End Try
    End Sub

    ' ------- BOTON BUSCAR ALBARAN --------------------------------------------------------------------------------------
    Private Sub ButtonBusAlb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBusAlb.Click
        tbcodalb.Enabled = False
        cbFact.Enabled = False
        ' limpiamos los textboxs y labels
        limpiar()
        ' limpiamos el datagrid
        dg.Rows.Clear()
        Try ' Abrimos la conexion
            Conexion.Open()
            ' Intentamos buscar en la base de datos el albaran correspondiente
            consulta = New SqlCommand("SELECT * FROM CabPieAlbaran WHERE codalbaran='" & tbcodalb.Text & "';", Conexion)
            Mireader = consulta.ExecuteReader()
            Mireader.Read()
            ' Mostramos la cabecera del albaran
            MostrarCabeceraPie()
            ' Mostramos el iva correspondiente
            BuscarItenIva()
            ' Mostramos la forma de pago
            BuscarItenFP()
            ' Mostramos si el albaran está facturado o no
            ComprobarFacturacion()
            ' Mostrar datos del cliente de este albaran
            MostrarDatosCliente()
            ' Mostrar lineas de articulos de este albaran
            MostrarLineasArticulo()
            If cbFact.Checked = False Then
                ' Habilitamos los botones, textbox y labels
                BotonesActivos()
                EscrituraCabPie()
                EscrituraLineas()
                ' Habilitar controles
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
            End If        
            'Cerramos la conexion y el datareader
            Conexion.Close()
            Mireader.Close()
        Catch ex As Exception

            ' SI NO ENCUENTRA EL ALBARAN BUSCADO...PROPONE CREAR UNO NUEVO
            If MessageBox.Show("Desea crear uno nuevo?", "EL albarán no existe", _
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                                        = DialogResult.Yes Then
                ' Gestionamos el cierre de la ventana actual y la abertura de la nueva
                Dim b As New ForEntAlbaran
                b.ShowDialog()
                DatosEmpresa.changeEstado()  ' CAMBIA LA VARIABLE PARA INDICAR QUE HA CREADO EL NUEVO ALBARAN
                Me.Close()
                ' SI QUEREMOS ABRIR LA VENTANA DE MANTENIMIENTO CON EL ALBARAN NUEVO CREADO
                Dim c As New ForMantenimientoAlbaran
                c.ShowDialog()

            Else
                ' SI (NO ACEPTA O CANCELA) EL MENSAJE DE CREAR ALBARAN, DEJAMOS LA VENTANA LIMPIA
                ' Y VOLVEMOS A EMPEZAR
                limpiar()
                tbcodalb.Enabled = True
                tbcodalb.Text = ""
                tbcodalb.Focus()
                Conexion.Close()
                Mireader.Close()
            End If
        End Try
    End Sub

    ' -------- MOSTRAMOS LOS DATOS DEL CLIENTE DEL ALBARAN ------------------------------------------------------------------
    Private Sub MostrarDatosCliente()
        Try
            ' Abrimos la conexion
            Conexion.Open()
            ' Buscamos en la base de datos los datos del cliente
            consulta = New SqlCommand("SELECT * FROM Clientes WHERE codcli='" & tcodcli.Text & "';", Conexion)
            Mireader = consulta.ExecuteReader()
            Mireader.Read()
            ' Campos a mostrar
            LabNom.Text = Mireader("nombre").ToString
            LabDir.Text = Mireader("direccion").ToString
            LabNif.Text = Mireader("nif").ToString
            LabTar.Text = Mireader("tarifa").ToString
            LabDes.Text = Mireader("descuento").ToString
            ' Cerramos las conexiones
            Conexion.Close()
            Mireader.Close()
            ' -------------------------------------------
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ' ------- MOSTRAMOS LAS LINEAS DE ARTICULOS DEL ALBARAN ------------------------------------------------------------
    Private Sub MostrarLineasArticulo()
        Dim contadorF As Integer
        Dim n As Integer = 0          ' Variable a usar en el while de las filas 
        Dim i As Integer

        Try
            ' Abrimos la conexion
            Conexion.Open()
            ' Obtenemos la cantidad de lineas que corresponden a este albaran
            consulta = New SqlCommand("Select count(*) from LineasAlbaran where codalbaran='" & tbcodalb.Text & "';", Conexion)
            contadorF = consulta.ExecuteScalar()
            ' Buscamos en la base de datos los datos de los articulos correspondientes
            consulta = New SqlCommand("SELECT * FROM LineasAlbaran WHERE codalbaran='" & tbcodalb.Text & "';", Conexion)
            Mireader = consulta.ExecuteReader()

            While Mireader.Read
                dg.Rows.Add()
                dg.Rows(n).Cells(0).Value = Mireader("numlinea").ToString
                dg.Rows(n).Cells(1).Value = Mireader("codart").ToString
                dg.Rows(n).Cells(3).Value = Mireader("pvp").ToString
                dg.Rows(n).Cells(4).Value = Mireader("cantidad").ToString
                dg.Rows(n).Cells(5).Value = Mireader("dtolinea").ToString
                dg.Rows(n).Cells(6).Value = Mireader("importe").ToString
                n = n + 1
            End While
            Mireader.Close()

            For i = 0 To dg.RowCount - 1
                consulta = New SqlCommand("Select descripcion from Articulos where codigo='" & dg.Rows(i).Cells(1).Value & "';", Conexion)
                Mireader = consulta.ExecuteReader
                Mireader.Read()
                dg.Rows(i).Cells(2).Value = Mireader("descripcion").ToString
                Mireader.Close()
            Next
            Conexion.Close()
            Mireader.Close()
        Catch ex As Exception
            Conexion.Close()
            Mireader.Close()
        End Try

    End Sub

    ' -------- MUESTRA LOS DATOS DE LA CABECERA Y EL PIE DEL ALBARAN -------------
    Private Sub MostrarCabeceraPie()

        Dim des ' Variable temporal para calcular el descuento
        tcodcli.Text = Mireader("codcli").ToString
        facturado = Mireader("facturado").ToString
        Labfe.Text = Mireader("fecha").ToString
        TextBox2.Text = Mireader("direccion").ToString
        Label19.Text = Mireader("suma").ToString
        TextBox10.Text = Mireader("dto").ToString
        tbportes.Text = Mireader("portes").ToString
        Label23.Text = Mireader("bases").ToString
        Label24.Text = Mireader("iva").ToString
        Label25.Text = Mireader("sumatotal").ToString
        porcentajeiva = CInt(Mireader("porcentajeiva").ToString)
        formapago = Mireader("formapago").ToString
        TextBox9.Text = Mireader("observaciones").ToString
        des = (TextBox10.Text / 100) * Label19.Text
        Label17.Text = Format(des, "N2")
        Conexion.Close()
        Mireader.Close()

    End Sub

    ' -------- BUSCAR DATOS DE ARTICULOS EN LAS LINEAS DE ALBARAN -----------------------------------------------
    Private Sub ButtonX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX.Click
        TextBox7.Text = "0"
        ' Calculamos la linea correspondiente
        For i = 0 To dg.RowCount - 1
            numLinea = i + 1
        Next
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

        ' Inhabilitamos a partir de ahora el codigo del albaran, ya no se puede cambiar 
        tbcodalb.Enabled = False
        
        ' Controlamos que se haya introducido una cantidad
        If Not TextBox6.Text = "" And Not TextBox8.Text = "" Then
            Try ' Abrimos la conexion
                Conexion.Open()
                
                ' Añadimos la linea al DataGrid
                dg.Rows.Add(TextBox1.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text)

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
        Else
            MsgBox("Debe introducir una cantidad")
        End If

    End Sub

    ' ------- BOTON CANCELAR LINEA ----------------------------------------------------------------------------
    Private Sub ButtonC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonC.Click
        Dim cant As Integer
        Dim cod As String
        Dim linea As String
        Try
            ' Tomamos la cantidad de ese articulo
            cant = dg.Item(4, dg.CurrentRow.Index).Value
            ' Tomamos el codigo del articulo seleccionado
            cod = CStr(dg.Item(1, dg.CurrentRow.Index).Value.ToString)
            ' Tomamos la linea del articulo seleccionado para borrar
            linea = dg.Item(0, dg.CurrentRow.Index).Value.ToString
            ' Recalculamos el stock de los articulos
            Conexion.Open()
            consulta = New SqlCommand("UPDATE Articulos set stockactual = stockactual + " & _
                                      cant & " where codigo = '" & cod & "';", Conexion)
            consulta.ExecuteNonQuery()
            Conexion.Close()
                
            'Borramos la fila seleccionada
            dg.Rows.Remove(dg.CurrentRow)
        Catch ex As Exception
            dg.Rows.Remove(dg.CurrentRow)
            MsgBox(ex.Message)
        End Try
        
    End Sub

    Private Sub calculaimportes()
        ' Calculamos la linea correspondiente
        For i = 0 To dg.RowCount - 1
            importetotal = importetotal + dg.Item(6, i).Value
        Next
        Label19.Text = Format(importetotal, "N2")
    End Sub

    ' ------- BOTON NO MAS LINEAS. CALCULAR IMPORTES ------------------------------------------------------------
    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        calculaimportes()
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
            des = (CDbl(TextBox10.Text) / 100) * CDbl(Label19.Text)
            Label17.Text = Format(des, "##,##0.00")
        End If
        tbportes_TextChanged(sender, e)

    End Sub

    ' -------- EVENTO SI CAMBIA EL VALOR DE LOS PORTES ---------------------------------------------------------------
    Private Sub tbportes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbportes.TextChanged

        ' Variables del evento
        Dim imponible As Double
        Dim a As Double
        Dim b As Double

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

    ' --------- BOTON ACEPTAR CAMBIOS --------------------------------------------------------------------------------------
    Private Sub ButtonAcep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAcep.Click
        Dim i As Integer = 0
        Dim n As Integer
        Dim codart As String
        Dim descripcion As String
        Dim pvp, dtolinea, importe As Double
        Dim cantidad, numlinea As Integer

        Try ' Eliminamos las lineas de albaran de la bbdd
            Conexion.Open()
            consulta = New SqlCommand("Delete from LineasAlbaran where codalbaran='" & tbcodalb.Text & "';", Conexion)
            consulta.ExecuteNonQuery()
            Conexion.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
            Conexion.Close()
        End Try

        Try ' Añadimos las nuevas lineas de albaran a la bbdd
            n = dg.RowCount
            While i < n
                numlinea = dg.Rows(i).Cells(0).Value
                codart = dg.Rows(i).Cells(1).Value.ToString
                descripcion = dg.Rows(i).Cells(2).Value.ToString
                pvp = CDbl(dg.Rows(i).Cells(3).Value)
                cantidad = CInt(dg.Rows(i).Cells(4).Value)
                dtolinea = CDbl(dg.Rows(i).Cells(5).Value)
                importe = CDbl(dg.Rows(i).Cells(6).Value)
                Conexion.Open()
                consulta = New SqlCommand("Insert into LineasAlbaran(codalbaran,numlinea,codart,descripcion,pvp,cantidad,dtolinea,importe) values ('" &
                                          tbcodalb.Text & "','" &
                                          numlinea & "','" &
                                          codart & "','" &
                                          descripcion & "'," & Replace(pvp, ",", ".") & "," & cantidad & "," &
                                          Replace(dtolinea, ",", ".") & "," & Replace(importe, ",", ".") & ")", Conexion)
                consulta.ExecuteNonQuery()
                Conexion.Close()
                i = i + 1
            End While
        Catch ex As Exception
            'MsgBox(ex.Message)
            Conexion.Close()
        End Try

        Try ' Actualizamos el pie del albaran

            Conexion.Open()
            consulta =
                New SqlCommand("UPDATE CabPieAlbaran SET suma = " & Label19.Text.Replace(".", "").Replace(",", ".") & "," &
                               " dto = " & TextBox10.Text.Replace(",", ".") & "," &
                               " portes = " & tbportes.Text.Replace(".", "").Replace(",", ".") & "," &
                               " bases = " & Label23.Text.Replace(".", "").Replace(",", ".") & "," &
                               " iva = " & Label24.Text.Replace(",", ".") & "," &
                               " sumatotal = " & Label25.Text.Replace(".", "").Replace(",", ".") & "," &
                               " formapago = '" & CStr(ComboBox1.SelectedIndex + 1) & "'," &
                               " observaciones ='" & TextBox9.Text & "'" &
                               " where codalbaran ='" & tbcodalb.Text & "';", Conexion)
            consulta.ExecuteNonQuery()
            ' INTRODUZCO EL PORCENTAJE POR SEPARADO PORQUE ME DIÓ PROBLEMAS
            consulta = New SqlCommand("UPDATE CabPieAlbaran SET porcentajeiva = " & CInt(ComboBox2.SelectedItem.ToString) &
                              " where codalbaran ='" & tbcodalb.Text & "';", Conexion)
            consulta.ExecuteNonQuery()
            ' Cerramos la conexion
            Conexion.Close()

        Catch ex As Exception
            Conexion.Close()
        End Try
        ' No limpiamos los datos porque es posible que queramos imprimir
    End Sub

    ' -------- BOTON BORRAR ALBARAN COMPLETO -----------------------------------------------------------------------------
    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim Conexion2 As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
        Dim consulta2 As New SqlCommand
        If MessageBox.Show("Desea borrar el albarán?", "AVISO", _
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                                        = DialogResult.Yes Then

            Try ' Volvemos a dejar el stock como estaba
                Conexion.Open()
                consulta = New SqlCommand("Select codart,cantidad from LineasAlbaran where codalbaran = '" & tbcodalb.Text & "';", Conexion)
                Mireader = consulta.ExecuteReader()
                Conexion2.Open()
                While Mireader.Read
                    consulta2 = New SqlCommand("Update Articulos set stockactual=(Select stockactual from Articulos where codigo ='" &
                                Mireader("codart") & "') + " & Mireader("cantidad") & " where codigo='" & Mireader("codart") & "';", Conexion2)
                    consulta2.ExecuteNonQuery()
                End While
                Mireader.Close()
                Conexion2.Close()
                ' Borramos las lineas del albaran
                consulta = New SqlCommand("Delete from LineasAlbaran where codalbaran = '" & tbcodalb.Text & "';", Conexion)
                consulta.ExecuteNonQuery()
                ' Borramos la cabecera y el pie del albaran
                consulta = New SqlCommand("Delete from CabPieAlbaran where codalbaran = '" & tbcodalb.Text & "';", Conexion)
                consulta.ExecuteNonQuery()
                ' Cerramos las conexiones
                Conexion.Close()
                'Limpiamos el datagrid
                While dg.RowCount > 1
                    dg.Rows.Remove(dg.CurrentRow)
                End While
                limpiar()
                limpiarlinea()
                tbcodalb.Text = ""
                tbcodalb.Enabled = True
                BotonesInactivos()
            Catch ex As Exception
                MsgBox(ex.Message)
                Conexion2.Close()
                Conexion.Close()
            End Try
        End If
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
        da1 = New SqlClient.SqlDataAdapter("SELECT * FROM CabPieAlbaran WHERE CabPieAlbaran.codalbaran= '" & tbcodalb.Text & "';", Conexion2)
        da1.Fill(dataset, "CABPIEALBARAN")
        da1 = New SqlClient.SqlDataAdapter("SELECT Articulos.*, LineasAlbaran.* FROM Articulos, LineasAlbaran WHERE Articulos.codigo = LineasAlbaran.codart and LineasAlbaran.codalbaran = '" & tbcodalb.Text & "';", Conexion2)
        da1.Fill(dataset, "LINEASALBARAN")
        da1.Fill(dataset, "ARTICULOS")
        da1 = New SqlClient.SqlDataAdapter("SELECT * FROM Clientes WHERE Clientes.codcli = '" & tcodcli.Text & "';", Conexion2)
        da1.Fill(dataset, "CLIENTES")
        da1 = New SqlClient.SqlDataAdapter("SELECT FormasPago.* FROM FormasPago, CabPieAlbaran WHERE CabPieAlbaran.formapago = FormasPago.tipo and CabPieAlbaran.codalbaran= '" & tbcodalb.Text & "';", Conexion2)
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


    ' -------- BUSCA ITEM CORRESPONDIENTE DEL COMBO IVA ------------
    Public Sub BuscarItenIva()
        If porcentajeiva = 21 Then
            ComboBox2.SelectedIndex = 0
        ElseIf porcentajeiva = 10 Then
            ComboBox2.SelectedIndex = 1
        ElseIf porcentajeiva = 4 Then
            ComboBox2.SelectedIndex = 2
        End If
    End Sub

    ' -------- BUSCA ITEM CORRESPONDIENTE DEL COMBO FORMA DE PAGO ----
    Public Sub BuscarItenFP()
        If formapago = "1" Then
            ComboBox1.SelectedIndex = 0
        ElseIf formapago = "2" Then
            ComboBox1.SelectedIndex = 1
        ElseIf formapago = "3" Then
            ComboBox1.SelectedIndex = 2
        ElseIf formapago = "4" Then
            ComboBox1.SelectedIndex = 3
        End If

    End Sub

    ' -------- CONTROLA EL CHECKBOX QUE MUESTRA EL ESTADO DE LA FACTURACION -------
    Private Sub ComprobarFacturacion()
        If facturado = "N" Then
            cbFact.Checked = False
        ElseIf facturado = "S" Then
            cbFact.Checked = True
        End If

    End Sub

    ' ------- BOTONES INACTIVOS AL INICIO DE LA APLICACION -----------
    Private Sub BotonesInactivos()
        ButtonAcep.Enabled = False      ' - BOTON ACEPTAR CAMBIOS
        ButtonBorrar.Enabled = False    ' - BOTON BORRAR ALBARAN
        ButtonImp.Enabled = False       ' - BOTON IMPRIMIR
        ButtonX.Enabled = False         ' - BOTON BUSCAR DATOS DEL PRODUCTO EN LINEAS DE ALBARAN
        ButtonM.Enabled = False         ' - BOTON AÑADIR LINEA DE ALBARAN
        ButtonC.Enabled = False         ' - BOTON CANCELAR LINEA DE ALBARAN
        ButtonOK.Enabled = False        ' - BOTON NO MAS LINEAS DE ALBARAN
        ButtonBusAlb.Enabled = True     ' - BOTON BUSCAR ALBARAN
        ButtonCanc.Enabled = False      ' - BOTON CANCELAR CAMBIOS
    End Sub

    ' ------- BOTONES ACTIVOS DESPUES DE BUSCAR EL ALBARAN -----------
    Private Sub BotonesActivos()
        'ButtonFac.Enabled = False      ' - BOTON FACTURA DIRECTA
        ButtonAcep.Enabled = True       ' - BOTON ACEPTAR 
        ButtonCanc.Enabled = True      ' - BOTON CANCELAR
        ButtonImp.Enabled = True        ' - BOTON IMPRIMIR ALBARAN
        ButtonX.Enabled = True          ' - BOTON BUSCAR DATOS DEL PRODUCTO EN LINEAS DE ALBARAN
        ButtonM.Enabled = True          ' - BOTON AÑADIR LINEA DE ALBARAN
        ButtonC.Enabled = True          ' - BOTON CANCELAR LINEA DE ALBARAN
        ButtonOK.Enabled = True         ' - BOTON NO MAS LINEAS DE ALBARAN
        ButtonBusAlb.Enabled = False    ' - BOTON BUSCAR ALBARAN
        ButtonSal.Enabled = True        ' - BOTON SALIR
        ButtonBorrar.Enabled = True     ' - BOTON BORRAR ALBARAN
    End Sub

    ' ------- MODO SOLO LECTURA PARA LOS TEXTBOX'S -------
    Private Sub SoloLectura()
        TextBox2.Enabled = False            ' - TEXTBOX DIRECCION DE ENTREGA A NOT ENABLED
        TextBox9.Enabled = False            ' - TEXTBOX OBSERVACIONES A NOT ENABLED
        tcodcli.ReadOnly = True             ' - TEXTBOX CODIGO DEL CLIENTE
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

    ' -------- MODO ESCRITURA PARA LA CABECERA Y EL PIE ----------------------
    Private Sub EscrituraCabPie()
        ComboBox1.Enabled = True            ' - COMBOBOX1 ENABLED
        ComboBox2.Enabled = True            ' - COMBOBOX2 ENABLED
        TextBox2.Enabled = False             ' - TEXTBOX DIRECCION DE ENTREGA ENABLED
        TextBox9.Enabled = False             ' - TEXTBOX OBSERVACIONES ENABLED
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
        tcodcli.Text = ""
        Labfe.Text = ""
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

    ' ------- RELLENA EL COMBO DEL IVA ----------------------------------
    Private Sub ComboIva()
        consulta = New SqlCommand("Select Porcentaje from IVA", Conexion)
        Mireader = consulta.ExecuteReader()
        While Mireader.Read()
            ComboBox2.Items.Add(Mireader("Porcentaje").ToString)
        End While
        Mireader.Close()
        ComboBox2.Enabled = False
    End Sub

    ' ------- RELLENA EL COMBO DE FORMAS DE PAGO ------------
    Private Sub ComboFormasPago()
        consulta = New SqlCommand("SELECT nombre FROM FormasPago", Conexion)
        Mireader = consulta.ExecuteReader()
        While Mireader.Read()
            ComboBox1.Items.Add(Mireader("nombre").ToString)
        End While
        Mireader.Close()
        ComboBox1.Enabled = False
    End Sub

    ' --------- EVENTO SI EL CODIGO DEL ALBARAN CAMBIA --------------------------------------------------------------
    Private Sub tbcodalb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcodalb.TextChanged
        ButtonBusAlb.Enabled = True
    End Sub

    ' -------- BOTON SALIR DE LA APLICACION -----------------------------------------------------  
    Private Sub ButtonSal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSal.Click
        Me.Close()
    End Sub

    ' -------- BOTON CANCELAR ---------------------
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCanc.Click
        dg.Rows.Clear()
        limpiar()
        limpiarlinea()
        tbcodalb.Enabled = True
        tbcodalb.Text = ""
        ForMantenimientoAlbaran_Load(sender, e)
    End Sub
End Class