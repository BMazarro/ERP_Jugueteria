Imports System.Data.SqlClient

Public Class ForFacturarClientes

    Dim Conexion As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Dim consulta As New SqlCommand
    Dim Mireader As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DistribuidoraJuguetesDataSet

    Dim opcionCB As String                            ' Variable para recoger la opcion del combo box
    Dim codigoC, nombreC, nifC As String            ' Variables para recoger los datos de cliente
    Dim codA, fecA, sumA, porA, pagoA As String     ' Variables para recoger los datos del albaran
    Dim ListAlbaranes As New List(Of String)            ' Lista para almacenar los albaranes

    Private Sub ForFacturarClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Centramos la ventana
        Me.CenterToScreen()
        ' ----------------------------------------------------------------------------------------------------
        ' Habilitamos los controles
        ComboBuscar.Enabled = True
        tbcliente.Enabled = True
        ButtonBuscarCli.Enabled = True
        ButtonSalir.Enabled = True
        '----------------------------------------------------------------------------
        ' Deshabilitamos el boton Facturar hasta que no se haya encontrado un cliente
        ButtonFacturar.Enabled = False
        '----------------------------------------------------------------------------
        ' Rellenamos el combo de opciones
        ComboBuscar.Items.Add("Código")
        ComboBuscar.Items.Add("Nombre")
        '---------------------------------------------------------------------------
        ComboBuscar.SelectedIndex = 0
        opcionCB = CStr(ComboBuscar.SelectedItem.ToString)
    End Sub

    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click
        Me.Close()
    End Sub

    ' ------------ BOTON BUSCAR CLIENTE ------------------------------------------------------------------
    Private Sub ButtonBuscarCli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarCli.Click
        ' ---------------------------------------------
        dgcliente.Rows.Clear()
        dgalbaranSF.Rows.Clear()
        
        ' ---------------------------------------------
        If Not tbcliente.Text = "" Then

            opcionCB = CStr(ComboBuscar.SelectedItem.ToString)

            ' Si elige por codigo
            If opcionCB.CompareTo("Código") = 0 Then

                If Not IsNumeric(tbcliente.Text) Then
                    MsgBox("Debe introducir digitos numericos")
                Else
                    codigoC = tbcliente.Text
                    Try
                        Conexion.Open()
                        ' Seleccionamos los datos del cliente introducido
                        consulta = New SqlCommand("Select * from Clientes where codcli='" &
                                                  codigoC & "';", Conexion)
                        ' Rellemos el datareader con los datos
                        Mireader = consulta.ExecuteReader()
                        ' Leemos el datareader
                        Mireader.Read()
                        ' Mostramos los datos del cliente
                        nombreC = Mireader("nombre").ToString
                        nifC = Mireader("nif").ToString
                        ' Cerramos
                        Mireader.Close()
                        Conexion.Close()
                        ' Añadimos los datos al datagrid
                        dgcliente.Rows.Add(codigoC, nombreC, nifC)
                    Catch ex As Exception
                        MsgBox("No existe ningún cliente con ese código")
                        ' Cerramos
                        Mireader.Close()
                        Conexion.Close()
                    End Try
                End If
            End If

            ' Si elige por nombre
            If opcionCB.CompareTo("Nombre") = 0 Then

                If IsNumeric(tbcliente.Text) Then
                    MsgBox("Debe introducir el nombre del cliente")
                Else
                    nombreC = tbcliente.Text
                    Try
                        Conexion.Open()
                        ' Seleccionamos los datos del cliente introducido
                        consulta = New SqlCommand("Select * from Clientes where nombre='" &
                                                  nombreC & "';", Conexion)
                        ' Rellemos el datareader con los datos
                        Mireader = consulta.ExecuteReader()
                        ' Leemos el datareader
                        Mireader.Read()
                        ' Mostramos los datos del cliente
                        codigoC = Mireader("codcli").ToString
                        nifC = Mireader("nif").ToString
                        ' Cerramos
                        Mireader.Close()
                        Conexion.Close()
                        ' Añadimos los datos al datagrid
                        dgcliente.Rows.Add(codigoC, nombreC, nifC)
                    Catch ex As Exception
                        MsgBox("No existe ningún cliente con ese código")
                        ' Cerramos
                        Mireader.Close()
                        Conexion.Close()
                    End Try
                End If
            End If
        Else
            MsgBox("Debe introducir un código o nombre de cliente")
        End If

        'Añadimos los albaranes sin facturar de este cliente al datagrid
        '----------------------------------------------------------------------
        Try
            Conexion.Open()
            ' Seleccionamos los datos del cliente introducido
            consulta = New SqlCommand("Select codalbaran, fecha, sumatotal, formapago, porcentajeiva from CabPieAlbaran where codcli='" &
                                      codigoC & "' and facturado='N';", Conexion)

            Dim cuenta = consulta.ExecuteScalar
            If cuenta = Nothing Then
                ButtonFacturar.Enabled = False
            Else
                ' Rellemos el datareader con los datos
                Mireader = consulta.ExecuteReader()
                ' Leemos el datareader
                While Mireader.Read()
                    codA = Mireader("codalbaran").ToString
                    fecA = Mireader("fecha").ToString
                    sumA = Mireader("sumatotal").ToString
                    porA = Mireader("porcentajeiva").ToString
                    pagoA = Mireader("formapago").ToString
                    ' Añadimos los datos al datagrid
                    dgalbaranSF.Rows.Add(codA, CDate(fecA), sumA, porA, pagoA)
                End While
                ' Habilitamos el boton Facturar
                ButtonFacturar.Enabled = True
            End If
            ' Cerramos
            Mireader.Close()
            Conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            ' Cerramos
            Mireader.Close()
            Conexion.Close()
        End Try
    End Sub

    ' ---------- BOTON FACTURAR --------------------------------------------------------------------------
    Private Sub ButtonFacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFacturar.Click
        Dim contador As Integer = 0
        Dim codigoF As String
        '-----------------------------------------------------------
        Dim opcionTP As String            ' Variable para elegir tipo de pago
        Dim sigue As Boolean = True     ' Variable para el bucle
        Dim tipo As Integer = 1         ' Guarda el tipo de iva

        ' Pedimos la opcion de pago por la que desea facturar 
        opcionTP = -1
        While sigue = True
            opcionTP = InputBox("" & Chr(13) &
                " 1 - Al contado " & Chr(13) &
                " 2 - A los 30 días " & Chr(13) &
                " 3 - A los 30 y 60 días " & Chr(13) &
                " 4 - A los 30, 60 y 90 días ", "Elija una forma de pago", 1)
            ' If user has clicked Cancel
            If opcionTP Is "" Then
                opcionTP = 0
                sigue = False
            Else
                If 1 > opcionTP Or opcionTP > 4 Then
                    MsgBox("Debe introducir una opción válida")
                    sigue = True
                Else
                    sigue = False
                    Conexion.Open()
                    consulta = New SqlCommand("Select * from CabPieAlbaran where CabPieAlbaran.codcli='" &
                                              codigoC & "' and CabPieAlbaran.formapago='" & opcionTP &
                                               "'", Conexion)
                    Mireader = consulta.ExecuteReader
                    If Mireader.Read Then
                        sigue = False
                    Else
                        MsgBox("Este cliente no tiene albaranes con esa forma de pago")
                        sigue = True
                    End If
                    Mireader.Close()
                    Conexion.Close()
                End If
            End If
            
        End While

        Dim Ssuma, Sdto, Sportes, Sbases, Siva, Ssumatotal As String
        Dim direccionC, observacionesC As String

        ' Para cada tipo de iva vamos a intentar agrupar los albaranes y facturarlos, si no hay de un tipo de iva se exceptua
        While tipo <= 3 And Not opcionTP = 0
            Dim porcentaje As Integer
            If tipo = 1 Then porcentaje = 21
            If tipo = 2 Then porcentaje = 10
            If tipo = 3 Then porcentaje = 4

            Try
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

                Conexion.Open()
                ' Buscamos albaranes para este tipo de iva
                consulta = New SqlCommand("Select CabPieAlbaran.* from CabPieAlbaran where CabPieAlbaran.codcli='" &
                                          codigoC & "' and CabPieAlbaran.formapago='" & opcionTP &
                                          "' and CabPieAlbaran.porcentajeiva=" & porcentaje & "", Conexion)
                Mireader = consulta.ExecuteReader
                If Mireader.Read Then
                    ' Si entra quiere decir que existen albaranes para ese tipo de iva
                    Mireader.Close()
                    Conexion.Close()

                    Try
                        Conexion.Open()
                        ' Obtenemos las sumas de los importes de estos albaranes
                        consulta = New SqlCommand("Select sum(suma), sum(dto), sum(portes), sum(bases), sum(iva), sum(sumatotal) from CabPieAlbaran" & _
                                              " where codcli='" &
                                              codigoC & "' and formapago='" & opcionTP & "' and porcentajeiva=" & porcentaje & " and facturado='N'", Conexion)
                        Mireader = consulta.ExecuteReader
                        Mireader.Read()
                        ' Recogemos el pie de la factura
                        Ssuma = Format(CDbl(Mireader(0).ToString), "N2")
                        Sdto = Format(CDbl(Mireader(1).ToString), "N2")
                        Sportes = Format(CDbl(Mireader(2).ToString), "N2")
                        Sbases = Format(CDbl(Mireader(3).ToString), "N2")
                        Siva = Format(CDbl(Mireader(4).ToString), "N2")
                        Ssumatotal = Format(CDbl(Mireader(5).ToString), "N2")
                        Mireader.Close()
                        Conexion.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Mireader.Close()
                        Conexion.Close()
                    End Try

                    Try
                        ' Obtenemos la direccion de entrega y las observaciones del cliente
                        Conexion.Open()
                        consulta = New SqlCommand("Select observaciones, direccionentrega from Clientes" &
                                              " where codcli='" & codigoC & "'", Conexion)
                        Mireader = consulta.ExecuteReader
                        Mireader.Read()
                        observacionesC = Mireader(0).ToString
                        direccionC = Mireader(1).ToString
                        Mireader.Close()
                        Conexion.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Mireader.Close()
                        Conexion.Close()
                    End Try

                    Dim lineas As Integer = dgalbaranSF.Rows.Count - 1

                    Dim i As Integer = 0
                    ListAlbaranes.Clear()
                    ' Vamos a guardar los codigos de los albaranes de este cliente con este iva y pago
                    While (i < lineas)
                        If (dgalbaranSF.Rows.Item(i).Cells.Item(3).Value = porcentaje And dgalbaranSF.Rows.Item(i).Cells.Item(4).Value = opcionTP) Then
                            ListAlbaranes.Add(dgalbaranSF.Rows.Item(i).Cells.Item(0).Value)
                        End If
                        i = i + 1
                    End While

                    Dim total As Double
                    Dim stotal As String
                    Dim fe As Date

                    ' Vamos a recoger los importes totales y la fecha de cada albaran
                    Dim j As Integer = 0
                    While (j < ListAlbaranes.Count)
                        Try
                            Conexion.Open()
                            consulta = New SqlCommand("Select sumatotal, fecha from CabPieAlbaran" &
                                              " where codalbaran='" & ListAlbaranes(j) & "'", Conexion)
                            Mireader = consulta.ExecuteReader
                            Mireader.Read()
                            total = CDbl(Mireader(0).ToString)
                            stotal = Format(total, "N2")

                            fe = CDate(Mireader(1).ToString)
                            fe = Format(fe, "d")
                            Mireader.Close()
                            Conexion.Close()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            Mireader.Close()
                            Conexion.Close()
                        End Try

                        Try
                            Conexion.Open()
                            ' Insertamos las lineas de la factura donde indicamos los albaranes a facturar
                            consulta = New SqlCommand("Insert into LineasFactura values ('" & codigoF & "','" &
                                                      (j + 1) & "','0" &
                                                      "','Alb: " & ListAlbaranes(j) & " - Fecha: " & fe &
                                                      "','" & "','" & "','" & "'," &
                                                      stotal.Replace(".", "").Replace(",", ".") &
                                                      ")", Conexion)
                            consulta.ExecuteNonQuery()
                            Conexion.Close()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            Mireader.Close()
                            Conexion.Close()
                        End Try
                        j = j + 1
                    End While

                    ' Insertamos la cabecera de la factura
                    Try
                        Conexion.Open()
                        consulta = New SqlCommand("Insert into CabPieFactura values ('" & codigoF & "','" &
                                                  Format(System.DateTime.Today, "d") & "','" &
                                                  codigoC & "','" & direccionC & "','" & "N'" & "," &
                                                   Ssuma.Replace(".", "").Replace(",", ".") & "," &
                                                  Sdto.Replace(".", "").Replace(",", ".") & "," &
                                                  Sportes.Replace(".", "").Replace(",", ".") & "," &
                                                  Sbases.Replace(".", "").Replace(",", ".") & "," &
                                                  Siva.Replace(",", ".") & "," &
                                                  Ssumatotal.Replace(".", "").Replace(",", ".") & ",'" & opcionTP & "','" & observacionesC & "'," & porcentaje & ");", Conexion)
                        consulta.ExecuteNonQuery()
                        Conexion.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Mireader.Close()
                        Conexion.Close()
                    End Try

                    ' Ponemos la lista de albaranes como facturado
                    Dim k As Integer = 0
                    While k < ListAlbaranes.Count
                        Try
                            Conexion.Open()
                            consulta = New SqlCommand("Update CabPieAlbaran set facturado = 'S' where codalbaran = '" & ListAlbaranes(k) & "'", Conexion)
                            consulta.ExecuteNonQuery()
                            Conexion.Close()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            Conexion.Close()
                        End Try
                        k = k + 1
                    End While

                    'Damos de alta la factura en el libro de iva
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
                        consulta = New SqlCommand("Select nombre,nif,banco,cuenta from clientes where codcli='" & codigoC & "'", Conexion)
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
                        da1 = New SqlClient.SqlDataAdapter("SELECT * FROM Clientes WHERE Clientes.codcli = '" & codigoC & "';", Conexion2)
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

                    'Creamos los recibos para esa factura
                    Dim codrecibo As Integer = 1
                    Dim cantidadrecibos As Integer = 0
                    Dim intervalo As Integer
                    Dim fechaprev As Date
                    Dim totalre, importerecibo As Double
                    'obtenemos la fecha de la factura
                    fechaprev = Format(System.DateTime.Today, "d")

                    totalre = CDbl(iimporte.Replace(".", ","))

                    'obtenemos la cantidad de recibos(plazos) y su intervalo
                    Try
                        Conexion.Open()
                        consulta = New SqlCommand("Select recibos, intervaloTiempo from FormasPago where tipo ='" & opcionTP & "'", Conexion)
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
                        importerecibo = totalre / cantidadrecibos
                        importerecibo = Math.Truncate(importerecibo)

                        While codrecibo <= cantidadrecibos 'para todos los recibos

                            fechaprev = fechaprev.AddDays(intervalo) 'sumamos el intervalo a la fecha

                            If (codrecibo = cantidadrecibos) Then 'si el recibo es el ultimo
                                importerecibo = totalre
                            Else
                                totalre = totalre - importerecibo 'si no es el ultimo
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

                Else
                    ' No existen albaranes para ese tipo de iva
                    Mireader.Close()
                    Conexion.Close()
                End If
            Catch ex As Exception
                Conexion.Close()
                MsgBox(ex.Message)
            End Try
            tipo = tipo + 1
        End While
        ButtonFacturar.Enabled = False
    End Sub
End Class