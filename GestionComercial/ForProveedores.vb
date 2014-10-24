Imports System.Data.SqlClient

Public Class ForProveedores
    Dim Conexion As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Dim consulta As New SqlCommand
    Dim Mireader As SqlDataReader
    Dim contador As Integer = 0
    Dim posicion As Integer = 0
    Dim ultimo As Integer = 0
    Dim opcion As Integer = 0
    Dim fecha As Date = Date.Now

    Private Sub ForProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        ButtonOK.Enabled = False
        ButtonCancel.Enabled = False
        CargarEnPosicion(0)
        'MessageBox.Show("Conectado")
        Try
            Conexion.Open()
            consulta = New SqlCommand("SELECT COUNT(*) FROM Proveedores", Conexion)
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
            consulta = New SqlCommand("SELECT * FROM Proveedores", Conexion)
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
            tcodigo.Text = Mireader("codprov").ToString
            tnombre.Text = Mireader("nombre").ToString
            tnif.Text = Mireader("nif").ToString
            tdireccion.Text = Mireader("direccion").ToString
            tcp.Text = Mireader("cp").ToString
            tlocalidad.Text = Mireader("localidad").ToString
            tprovincia.Text = Mireader("provincia").ToString
            ttelefono.Text = Mireader("telefono").ToString
            temail.Text = Mireader("email").ToString
            tvolumen.Text = Mireader("volumencompras").ToString

            If Not Mireader("fechaultped").ToString = "" Then
                tuf = CDate(Mireader("fechaultped").ToString)
                tufecha.Text = Format(tuf, "d")
            Else
                tufecha.Text = Mireader("fechaultped").ToString
            End If

            tdiren.Text = Mireader("direccionentrega").ToString
            tpersona.Text = Mireader("personacontacto").ToString
            tpercontact.Text = Mireader("telefonocontacto").ToString

            tfa = CDate(Mireader("fechaalta").ToString)
            tfalta.Text = Format(tfa, "d")

            If Not Mireader("fechabaja").ToString = "" Or Not Mireader("fechabaja").ToString = Nothing Then
                tba = CDate(Mireader("fechabaja").ToString)
                tbaja.Text = Format(tba, "d")
            Else
                tbaja.Text = Mireader("fechabaja").ToString
            End If

            tbanco.Text = Mireader("banco").ToString
            tcuenta.Text = Mireader("cuenta").ToString
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

    ' NUEVO PROVEEDOR
    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        opcion = 1
        ButtonOK.Enabled = True
        ButtonCancel.Enabled = True
        Limpiar()
        tfalta.Text = Format(fecha, "d")
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
        Dim res As DialogResult = MessageBox.Show("¿Desea borrar el proveedor?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If res = Windows.Forms.DialogResult.Yes Then
            Try
                Conexion.Open()
                consulta = New SqlCommand("delete from Proveedores where codprov = '" & tcodigo.Text & "';", Conexion)
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
        cod = InputBox("Introduce el codigo del proveedor", "Buscar")
        Try
            Conexion.Open()
            consulta = New SqlClient.SqlCommand("select * from Proveedores where codprov='" & cod & "';", Conexion)
            Mireader = consulta.ExecuteReader
            Mireader.Read()
        Catch ex As Exception
            MsgBox(ex.Message)
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
        If Not tvolumen.Text = "" Then
            tvolumen.Text = tvolumen.Text.Replace(",", ".")
        Else
            tvolumen.Text = "0"
        End If

        If tfalta.Text = "" Then
            MsgBox("Es recomendable introducir una fecha de alta válida")
        End If
        If IsNumeric(tcodigo.Text) And Not tnombre.Text.Equals("") And Not tnif.Text.Equals("") And Not tfalta.Text = "" Then
            If (opcion = 1) Then
                Try
                    Conexion.Open()
                    If tufecha.Text = "" Then
                        consulta = New SqlClient.SqlCommand("insert into Proveedores(codprov, nombre, nif, direccion, cp, localidad, provincia, telefono, observaciones, email, volumencompras, fechaultped, direccionentrega, personacontacto, telefonocontacto, fechaalta, fechabaja, banco, cuenta)" &
                                   "VALUES(" & "'" & tcodigo.Text & "'" & "," & "'" & tnombre.Text & "'" & "," &
                                   "'" & tnif.Text & "'" & "," & "'" & tdireccion.Text & "'" & "," &
                                   "'" & tcp.Text & "'" & "," & "'" & tlocalidad.Text & "'" & "," &
                                   "'" & tprovincia.Text & "'" & "," & "'" & ttelefono.Text & "'" & "," &
                                   "'" & tobserva.Text & "'" & "," &
                                   "'" & temail.Text & "'" & "," & tvolumen.Text & "," &
                                   " NULL " & "," & "'" & tdiren.Text & "'" & "," &
                                   "'" & tpersona.Text & "'" & "," & "'" & tpercontact.Text & "'" & "," &
                                   "'" & tfalta.Text & "'" & "," & " NULL ," &
                                   "'" & tbanco.Text & "'" & "," & "'" & tcuenta.Text & "'" & ");", Conexion)
                    Else
                        consulta = New SqlClient.SqlCommand("insert into Proveedores(codprov, nombre, nif, direccion, cp, localidad, provincia, telefono, observaciones, email, volumencompras, fechaultped, direccionentrega, personacontacto, telefonocontacto, fechaalta, fechabaja, banco, cuenta)" &
                                   "VALUES(" & "'" & tcodigo.Text & "'" & "," & "'" & tnombre.Text & "'" & "," &
                                   "'" & tnif.Text & "'" & "," & "'" & tdireccion.Text & "'" & "," &
                                   "'" & tcp.Text & "'" & "," & "'" & tlocalidad.Text & "'" & "," &
                                   "'" & tprovincia.Text & "'" & "," & "'" & ttelefono.Text & "'" & "," &
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

                    consulta = New SqlClient.SqlCommand("update Proveedores set fechaalta='" & tfalta.Text & "' where codprov=" & "'" & tcodigo.Text & "';", Conexion)
                    consulta.ExecuteNonQuery()
                    If (tbaja.Text = "") Then
                        consulta = New SqlClient.SqlCommand("update Proveedores set fechabaja= NULL where codprov=" & "'" & tcodigo.Text & "';", Conexion)
                        consulta.ExecuteNonQuery()
                    Else
                        consulta = New SqlClient.SqlCommand("update Proveedores set fechabaja='" & tbaja.Text & "' where codprov=" & "'" & tcodigo.Text & "';", Conexion)
                        consulta.ExecuteNonQuery()
                    End If

                    If (tufecha.Text = "") Then
                        consulta = New SqlClient.SqlCommand("update Proveedores set fechaultped= NULL where codprov=" & "'" & tcodigo.Text & "';", Conexion)
                        consulta.ExecuteNonQuery()
                    Else
                        consulta = New SqlClient.SqlCommand("update Proveedores set fechaultped='" & tufecha.Text & "' where codprov=" & "'" & tcodigo.Text & "';", Conexion)
                        consulta.ExecuteNonQuery()
                    End If

                    consulta = New SqlClient.SqlCommand("update Proveedores set codprov=" & "'" & tcodigo.Text & "'" &
                                "," & " nombre=" & "'" & tnombre.Text & "'" &
                                "," & " nif=" & "'" & tnif.Text & "'" &
                                "," & " direccion=" & "'" & tdireccion.Text & "'" &
                                "," & " cp=" & "'" & tcp.Text & "'" &
                                "," & " localidad=" & "'" & tlocalidad.Text & "'" &
                                "," & " provincia=" & "'" & tprovincia.Text & "'" &
                                "," & " telefono=" & "'" & ttelefono.Text & "'" &
                                "," & " observaciones=" & "'" & tobserva.Text & "'" &
                                "," & " email=" & "'" & temail.Text & "'" &
                                "," & " volumencompras=" & tvolumen.Text &
                                "," & " direccionentrega=" & "'" & tdiren.Text & "'" &
                                "," & " personacontacto=" & "'" & tpersona.Text & "'" &
                                "," & " telefonocontacto=" & "'" & tpercontact.Text & "'" &
                                "," & " banco=" & "'" & tbanco.Text & "'" & "," & " cuenta=" & "'" & tcuenta.Text & "'" &
                                " where codprov=" & "'" & tcodigo.Text & "';", Conexion)
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
            MsgBox("El código del proveedor debe ser un valor numérico y el NIF, nombre y la fecha de alta son obligatorios")
            Conexion.Close()
        End If
    End Sub

    ' SALIR
    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click
        Me.Close()
    End Sub

End Class