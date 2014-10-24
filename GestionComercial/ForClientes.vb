Imports System.Data.SqlClient

Public Class ForClientes
    Dim Conexion As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Dim consulta As New SqlCommand
    Dim Mireader As SqlDataReader
    Dim contador As Integer = 0
    Dim posicion As Integer = 0
    Dim ultimo As Integer = 0
    Dim opcion As Integer = 0
    Dim fecha As Date = Date.Now

    Private Sub ForClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        ButtonOK.Enabled = False
        ButtonCancel.Enabled = False
        CargarEnPosicion(0)

        'MessageBox.Show("Conectado")
        Try
            Conexion.Open()
            consulta = New SqlCommand("SELECT COUNT(*) FROM Clientes", Conexion)
            ultimo = consulta.ExecuteScalar()   'Obtenemos la cantidad de registros
            Mireader.Close()
            Conexion.Close()
        Catch ex As Exception
            MsgBox("No se ha podido establecer la conexión")
            Conexion.Close()
        End Try
        'MessageBox.Show("El numero de registros es: " & ultimo)
    End Sub

    ' CARGA EN LA POSICION INDICADA
    Private Sub CargarEnPosicion(ByVal pos As Integer)
        Try
            Conexion.Open()
            consulta = New SqlCommand("SELECT * FROM Clientes", Conexion)
            Mireader = consulta.ExecuteReader()
        Catch ex As Exception
            MsgBox("No se ha podido establecer la conexión")
            Conexion.Close()
        End Try
        Try
            pos = pos + 1
            contador = 0
            While (contador < pos)
                Mireader.Read()
                contador = contador + 1

            End While
            MostrarDatos()
            posicion = pos - 1
            Mireader.Close()
            Conexion.Close()
        Catch ex As Exception
            MsgBox("No hay datos en la base de datos")
            Conexion.Close()
        End Try
    End Sub

    ' MUESTRA LOS DATOS
    Private Sub MostrarDatos()
        Dim tuf, tfa, tba As Date
        Try
            tcodigo.Text = Mireader("codcli").ToString
            tnombre.Text = Mireader("nombre").ToString
            tnif.Text = Mireader("nif").ToString
            tdireccion.Text = Mireader("direccion").ToString
            tcp.Text = Mireader("cp").ToString
            tlocalidad.Text = Mireader("localidad").ToString
            tprovincia.Text = Mireader("provincia").ToString
            ttelefono.Text = Mireader("telefono").ToString
            ttarifa.Text = Mireader("tarifa").ToString
            tdescuento.Text = Mireader("descuento").ToString
            temail.Text = Mireader("email").ToString
            tvolumen.Text = Mireader("volumenventas").ToString

            If Not Mireader("fechaultimacompra").ToString = "" Or Not Mireader("fechaultimacompra").ToString = Nothing Then
                tuf = CDate(Mireader("fechaultimacompra").ToString)
                tufecha.Text = Format(tuf, "d")
            Else
                tufecha.Text = Mireader("fechaultimacompra").ToString
            End If

            'tuf = CDate(Mireader("fechaultimacompra").ToString)
            'tufecha.Text = Format(tuf, "d")

            tdiren.Text = Mireader("direccionentrega").ToString
            tpersona.Text = Mireader("personacontacto").ToString
            tpercontact.Text = Mireader("telefonocontacto").ToString

            If Mireader("fechaalta").ToString Is Nothing Then
                tfalta.Text = Format(fecha, "d")
            Else
                tfa = CDate(Mireader("fechaalta").ToString)
                tfalta.Text = Format(tfa, "d")
            End If
            

            If Not Mireader("fechabaja").ToString = "" Or Not Mireader("fechabaja").ToString = Nothing Then
                tba = CDate(Mireader("fechabaja").ToString)
                tbaja.Text = Format(tba, "d")
            Else
                tbaja.Text = Mireader("fechabaja").ToString
            End If

            If Not Mireader("banco").ToString = "" Then
                tbanco.Text = Mireader("banco").ToString
            Else
                tbanco.Text = ""
            End If

            If Not Mireader("cuenta").ToString = "" Then
                tcuenta.Text = Mireader("cuenta").ToString
            Else
                tcuenta.Text = ""
            End If

            tobserva.Text = Mireader("observaciones").ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Conexion.Close()
        End Try

        Mireader.Close()
    End Sub

    ' IR A POSICION INICIAL
    Private Sub ButtonIrInicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonIrInicio.Click
        CargarEnPosicion(0)
    End Sub

    ' IR A POSICION FINAL
    Private Sub ButtonIrFinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonIrFinal.Click
        CargarEnPosicion(ultimo - 1)
    End Sub

    ' CANCELAR CAMBIOS
    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        ButtonOK.Enabled = False
        ButtonCancel.Enabled = False
        Habilitar()
        If opcion = 1 Then
            CargarEnPosicion(0)
        Else
            CargarEnPosicion(posicion)
        End If
    End Sub

    ' IR UNA POSICION ADELANTE
    Private Sub ButtonAvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAvance.Click
        If ((posicion + 1) >= ultimo) Then
            MsgBox("No hay más registros")
        End If
        If ((posicion + 1) < ultimo) Then
            CargarEnPosicion(posicion + 1)
        End If
    End Sub

    ' IR UNA POSICION ATRAS
    Private Sub ButtonAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAtras.Click
        If ((posicion - 1) < 0) Then
            MsgBox("No hay más registros")
        End If
        If ((posicion - 1) >= 0) Then
            CargarEnPosicion(posicion - 1)
        End If
    End Sub

    ' NUEVO CLIENTE
    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click 
        opcion = 1
        ButtonOK.Enabled = True
        ButtonCancel.Enabled = True
        Limpiar()
        tfalta.Text = Format(fecha, "d")
        'tbaja.Text = "00/00/00"
        ButtonBorrar.Enabled = False
        ButtonModificar.Enabled = False
        ButtonBuscar.Enabled = False
        ButtonIrInicio.Enabled = False
        ButtonAtras.Enabled = False
        ButtonAvance.Enabled = False
        ButtonIrFinal.Enabled = False
        ButtonSalir.Enabled = False
        ButtonNuevo.Enabled = False
        posicion = ultimo
    End Sub

    ' HABILITAR
    Private Sub Habilitar()
        ButtonNuevo.Enabled = True
        ButtonBorrar.Enabled = True
        ButtonModificar.Enabled = True
        ButtonBuscar.Enabled = True
        ButtonIrInicio.Enabled = True
        ButtonAtras.Enabled = True
        ButtonAvance.Enabled = True
        ButtonIrFinal.Enabled = True
        ButtonSalir.Enabled = True
    End Sub

    ' LIMPIAR
    Private Sub Limpiar()
        tcodigo.Text = ""
        tnombre.Text = ""
        tnif.Text = ""
        tdireccion.Text = ""
        tcp.Text = ""
        tlocalidad.Text = ""
        tprovincia.Text = ""
        ttelefono.Text = ""
        ttarifa.Text = ""
        tdescuento.Text = ""
        temail.Text = ""
        tvolumen.Text = ""
        tufecha.Text = ""
        tdiren.Text = ""
        tpersona.Text = ""
        tpercontact.Text = ""
        tfalta.Text = ""
        tbaja.Text = ""
        tbanco.Text = ""
        tcuenta.Text = ""
        tobserva.Text = ""
    End Sub

    ' BORRAR
    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim res As DialogResult = MessageBox.Show("¿Desea borrar el cliente?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If res = Windows.Forms.DialogResult.Yes Then
            Try
                Conexion.Open()
                consulta = New SqlCommand("delete from Clientes where codcli = '" & tcodigo.Text & "';", Conexion)
                consulta.ExecuteNonQuery()
                ultimo = ultimo - 1
                MsgBox("Eliminado correctamente")
                Conexion.Close()
                If (posicion = ultimo) Then
                    CargarEnPosicion(0)
                End If
                If (posicion <> ultimo) Then
                    CargarEnPosicion(posicion)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Conexion.Close()
            End Try
        End If
    End Sub

    ' MODIFICAR
    Private Sub ButtonModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonModificar.Click
        opcion = 2
        ButtonOK.Enabled = True
        ButtonCancel.Enabled = True
        ButtonBorrar.Enabled = False
        ButtonModificar.Enabled = False
        ButtonBuscar.Enabled = False
        ButtonIrInicio.Enabled = False
        ButtonAtras.Enabled = False
        ButtonAvance.Enabled = False
        ButtonIrFinal.Enabled = False
        ButtonSalir.Enabled = False
        ButtonNuevo.Enabled = False
    End Sub

    ' BUSCAR
    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        Dim cod As String
        cod = InputBox("Introduce el codigo del cliente", "Buscar")
        Try
            Conexion.Open()
            consulta = New SqlClient.SqlCommand("select * from Clientes where codcli='" & cod & "';", Conexion)
            Mireader = consulta.ExecuteReader
            Mireader.Read()
            
        Catch ex As Exception
            MsgBox("Debe introducir un codigo de cliente")
            Conexion.Close()
        End Try
        MostrarDatos()
        Conexion.Close()
        Mireader.Close()
        
    End Sub

    ' ACEPTAR CAMBIOS
    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        ButtonOK.Enabled = False
        ButtonCancel.Enabled = False

        If Not tdescuento.Text = "" Then
            tdescuento.Text = tdescuento.Text.Replace(",", ".")
        Else
            tdescuento.Text = "0"
        End If
        If Not tvolumen.Text = "" Then
            tvolumen.Text = tvolumen.Text.Replace(",", ".")
        Else
            tvolumen.Text = "0"
        End If
        If tfalta.Text = "" Then
            tfalta.Text = Nothing
        End If
        If tufecha.Text = "" Then
            tufecha.Text = Nothing
        End If
        If ttarifa.Text = "" Then
            ttarifa.Text = "3"
        End If
        If ttarifa.Text > 3 Or ttarifa.Text < 1 Then
            MsgBox("Solo existe tarifa 1, 2 o 3")
        End If
        If IsNumeric(tcodigo.Text) And Not tnombre.Text.Equals("") And Not tnif.Text.Equals("") And IsNumeric(ttarifa.Text) Then
            If (opcion = 1) Then
                Try
                    Conexion.Open()
                    If tufecha.Text = "" Then
                        consulta = New SqlClient.SqlCommand("insert into Clientes(codcli, nombre, nif, direccion, cp, localidad, provincia, telefono, tarifa, descuento, observaciones, email, volumenventas, fechaultimacompra, direccionentrega, personacontacto, telefonocontacto, fechaalta, fechabaja, banco, cuenta)" &
                                   "VALUES(" & "'" & tcodigo.Text & "'" & "," & "'" & tnombre.Text & "'" & "," &
                                   "'" & tnif.Text & "'" & "," & "'" & tdireccion.Text & "'" & "," &
                                   "'" & tcp.Text & "'" & "," & "'" & tlocalidad.Text & "'" & "," &
                                   "'" & tprovincia.Text & "'" & "," & "'" & ttelefono.Text & "'" & "," &
                                   "'" & ttarifa.Text & "'" & "," & tdescuento.Text & "," &
                                   "'" & tobserva.Text & "'" & "," &
                                   "'" & temail.Text & "'" & "," & tvolumen.Text & "," &
                                   " NULL " & "," & "'" & tdiren.Text & "'" & "," &
                                   "'" & tpersona.Text & "'" & "," & "'" & tpercontact.Text & "'" & "," &
                                   "'" & tfalta.Text & "'" & "," & " NULL ," &
                                   "'" & tbanco.Text & "'" & "," & "'" & tcuenta.Text & "'" & ");", Conexion)

                    Else
                        consulta = New SqlClient.SqlCommand("insert into Clientes(codcli, nombre, nif, direccion, cp, localidad, provincia, telefono, tarifa, descuento, observaciones, email, volumenventas, fechaultimacompra, direccionentrega, personacontacto, telefonocontacto, fechaalta, fechabaja, banco, cuenta)" &
                                  "VALUES(" & "'" & tcodigo.Text & "'" & "," & "'" & tnombre.Text & "'" & "," &
                                  "'" & tnif.Text & "'" & "," & "'" & tdireccion.Text & "'" & "," &
                                  "'" & tcp.Text & "'" & "," & "'" & tlocalidad.Text & "'" & "," &
                                  "'" & tprovincia.Text & "'" & "," & "'" & ttelefono.Text & "'" & "," &
                                  "'" & ttarifa.Text & "'" & "," & tdescuento.Text & "," &
                                  "'" & tobserva.Text & "'" & "," &
                                  "'" & temail.Text & "'" & "," & tvolumen.Text & "," &
                                  "'" & tufecha.Text & "'" & "," & "'" & tdiren.Text & "'" & "," &
                                  "'" & tpersona.Text & "'" & "," & "'" & tpercontact.Text & "'" & "," &
                                  "'" & tfalta.Text & "'" & "," & " NULL ," &
                                  "'" & tbanco.Text & "'" & "," & "'" & tcuenta.Text & "'" & ");", Conexion)
                    End If

                    consulta.ExecuteNonQuery()
                    ultimo = ultimo + 1
                    MsgBox("Alta correcta")
                    Conexion.Close()
                    CargarEnPosicion(posicion)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Conexion.Close()
                End Try

            ElseIf (opcion = 2) Then
                Try
                    Conexion.Open()
                    If (tbaja.Text = "") Then

                        consulta = New SqlClient.SqlCommand("update Clientes set codcli=" & "'" & tcodigo.Text & "'" & "," &
                                    " nombre=" & "'" & tnombre.Text & "'" & "," & " nif=" & "'" & tnif.Text & "'" & "," & " direccion=" & "'" & tdireccion.Text & "'" &
                                    "," & " cp=" & "'" & tcp.Text & "'" & "," & " localidad=" &
                                    "'" & tlocalidad.Text & "'" & "," & " provincia=" & "'" & tprovincia.Text & "'" &
                                    "," & " telefono=" & "'" & ttelefono.Text & "'" & "," & " tarifa=" & "'" & ttarifa.Text & "'" &
                                    "," & " descuento=" & tdescuento.Text & "," & " observaciones=" & "'" & tobserva.Text & "'" &
                                    "," & " email=" & "'" & temail.Text & "'" &
                                    "," & " volumenventas=" & tvolumen.Text & "," & " fechaultimacompra=" & "'" & tufecha.Text & "'" &
                                    "," & " direccionentrega=" & "'" & tdiren.Text & "'" & "," & " personacontacto=" & "'" & tpersona.Text & "'" &
                                    "," & " telefonocontacto=" & "'" & tpercontact.Text & "'" &
                                    "," & " fechaalta=" & "'" & tfalta.Text & "'" & ", fechabaja=NULL" &
                                    "," & " banco=" & "'" & tbanco.Text & "'" & "," & " cuenta=" & "'" & tcuenta.Text & "'" &
                                    " where codcli=" & "'" & tcodigo.Text & "';", Conexion)
                    Else

                        consulta = New SqlClient.SqlCommand("update Clientes set codcli=" & "'" & tcodigo.Text & "'" & "," &
                                    " nombre=" & "'" & tnombre.Text & "'" & "," & " nif=" & "'" & tnif.Text & "'" & "," & " direccion=" & "'" & tdireccion.Text & "'" &
                                    "," & " cp=" & "'" & tcp.Text & "'" & "," & " localidad=" &
                                    "'" & tlocalidad.Text & "'" & "," & " provincia=" & "'" & tprovincia.Text & "'" &
                                    "," & " telefono=" & "'" & ttelefono.Text & "'" & "," & " tarifa=" & "'" & ttarifa.Text & "'" &
                                    "," & " descuento=" & tdescuento.Text & "," & " observaciones=" & "'" & tobserva.Text & "'" &
                                    "," & " email=" & "'" & temail.Text & "'" &
                                    "," & " volumenventas=" & tvolumen.Text & "," & " fechaultimacompra=" & "'" & tufecha.Text & "'" &
                                    "," & " direccionentrega=" & "'" & tdiren.Text & "'" & "," & " personacontacto=" & "'" & tpersona.Text & "'" &
                                     "," & " telefonocontacto=" & "'" & tpercontact.Text & "'" &
                                    "," & " fechaalta=" & "'" & tfalta.Text & "'" & "," & " fechabaja=" & "'" & tbaja.Text & "'" &
                                    "," & " banco=" & "'" & tbanco.Text & "'" & "," & " cuenta=" & "'" & tcuenta.Text & "'" &
                                    " where codcli=" & "'" & tcodigo.Text & "';", Conexion)
                    End If

                    consulta.ExecuteNonQuery()
                    MsgBox("Datos modificados")
                    Conexion.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Conexion.Close()
                End Try
            Else
                MsgBox("Debe añadir uno nuevo o pulsar modificar para poder aceptar cambios")
            End If
            opcion = 0
            Habilitar()
        Else
            MsgBox("El código del cliente y el código de tarifa deben ser valores numéricos y el NIF y el nombre son obligatorios")
            Conexion.Close()
        End If
    End Sub

    ' SALIR
    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click
        Me.Close()
    End Sub

End Class