Imports System.Data.SqlClient

Public Class ForArticulos

    Dim Conexion As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Dim consulta As New SqlCommand
    Dim Mireader As SqlDataReader
    Dim contador As Integer = 0
    Dim posicion As Integer = 0
    Dim ultimo As Integer = 0
    Dim opcion As Integer = 0

    Private Sub ForArticulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        ButtonOK.Enabled = False
        ButtonCancel.Enabled = False
        CargarEnPosicion(0)
        'MessageBox.Show("Conectado")
        Try
            Conexion.Open()
            consulta = New SqlCommand("SELECT COUNT(*) FROM Articulos", Conexion)
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
            consulta = New SqlCommand("SELECT * FROM Articulos", Conexion)
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
        Dim tuf As Date
        Try
            tcodigo.Text = Mireader("codigo").ToString
            tdescripcion.Text = Mireader("descripcion").ToString
            tstockact.Text = Mireader("stockactual").ToString
            tstockmax.Text = Mireader("stockmax").ToString
            tstockmin.Text = Mireader("stockmin").ToString
            tprecioult.Text = Mireader("precioultimacompra").ToString
            If Not Mireader("fechaultimacompra").ToString = "" And Not Mireader("fechaultimacompra").ToString = Nothing Then
                tuf = CDate(Mireader("fechaultimacompra").ToString)
                tfechault.Text = Format(tuf, "d")
            End If
            tcodprovhab.Text = Mireader("codproveedorhab").ToString
            tpreciomed.Text = Mireader("precioponderado").ToString
            tpvp1.Text = Mireader("pvp1").ToString
            tpvp2.Text = Mireader("pvp2").ToString
            tpvp3.Text = Mireader("pvp3").ToString

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

    ' NUEVO ARTICULO
    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        opcion = 1
        ButtonOK.Enabled = True
        ButtonCancel.Enabled = True
        Limpiar()
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
        tdescripcion.Text = ""
        tstockact.Text = ""
        tstockmax.Text = ""
        tstockmin.Text = ""
        tprecioult.Text = ""
        tfechault.Text = ""
        tcodprovhab.Text = ""
        tpreciomed.Text = ""
        tpvp1.Text = ""
        tpvp2.Text = ""
        tpvp3.Text = ""
    End Sub

    ' BORRAR
    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim res As DialogResult = MessageBox.Show("¿Desea borrar el artículo?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If res = Windows.Forms.DialogResult.Yes Then
            Try
                Conexion.Open()
                consulta = New SqlCommand("delete from Articulos where codigo = '" & tcodigo.Text & "';", Conexion)
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
        cod = InputBox("Introduce el codigo del artículo", "Buscar")
        Try
            Conexion.Open()
            consulta = New SqlClient.SqlCommand("select * from Articulos where codigo='" & cod & "';", Conexion)
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

        If Not tprecioult.Text = "" Then
            tprecioult.Text = tprecioult.Text.Replace(",", ".")
        Else
            tprecioult.Text = "0"
        End If
        If Not tpreciomed.Text = "" Then
            tpreciomed.Text = tpreciomed.Text.Replace(",", ".")
        Else
            tpreciomed.Text = "0"
        End If
        If Not tpvp1.Text = "" Then
            tpvp1.Text = tpvp1.Text.Replace(",", ".")
        Else
            tpvp1.Text = "0"
        End If
        If Not tpvp2.Text = "" Then
            tpvp2.Text = tpvp2.Text.Replace(",", ".")
        Else
            tpvp2.Text = "0"
        End If
        If Not tpvp3.Text = "" Then
            tpvp3.Text = tpvp3.Text.Replace(",", ".")
        Else
            tpvp3.Text = "0"
        End If

            If tstockact.Text = "" Then tstockact.Text = 0
            If tstockmax.Text = "" Then tstockmax.Text = 0
            If tstockmin.Text = "" Then tstockmin.Text = 0

            If IsNumeric(tcodigo.Text) And Not tdescripcion.Text.Equals("") And Not tfechault.Text = "" And Not tcodprovhab.Text = "" And IsNumeric(tcodprovhab.Text) Then

                If (opcion = 1) Then
                    Try
                        Conexion.Open()
                    consulta = New SqlClient.SqlCommand("insert into Articulos (codigo, descripcion, stockactual, stockmax, stockmin, precioultimacompra, fechaultimacompra, codproveedorhab, precioponderado, pvp1, pvp2, pvp3)" &
                                       "VALUES(" & "'" & tcodigo.Text & "'" & "," & "'" & tdescripcion.Text & "'" & "," &
                                        tstockact.Text & "," & tstockmax.Text & "," &
                                        tstockmin.Text & "," & tprecioult.Text & "," &
                                       "'" & tfechault.Text & "'" & "," & "'" & tcodprovhab.Text & "'" & "," &
                                       tpreciomed.Text & "," & tpvp1.Text & "," &
                                       tpvp2.Text & "," &
                                       tpvp3.Text & ");", Conexion)
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
                    consulta = New SqlClient.SqlCommand("update Articulos set codigo=" &
                                "'" & tcodigo.Text & "'" &
                                "," & " descripcion=" & "'" & tdescripcion.Text & "'" &
                                "," & " stockactual=" & tstockact.Text &
                                "," & " stockmax=" & tstockmax.Text &
                                "," & " stockmin=" & tstockmin.Text &
                                "," & " precioultimacompra=" & tprecioult.Text &
                                "," & " fechaultimacompra=" & "'" & tfechault.Text & "'" &
                                "," & " codproveedorhab=" & "'" & tcodprovhab.Text & "'" &
                                "," & " precioponderado=" & tpreciomed.Text &
                                "," & " pvp1=" & tpvp1.Text &
                                "," & " pvp2=" & tpvp2.Text &
                                "," & " pvp3=" & tpvp3.Text &
                                " where codigo=" & "'" & tcodigo.Text & "';", Conexion)


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
            MsgBox("El código del articulo debe ser un valor numérico y es obligatorio. La descripción y la fecha de ultima compra son obligatorias. El código del proveedor debe existir")
                Conexion.Close()
            End If
    End Sub

    ' SALIR
    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click
        Me.Close()
    End Sub

    
End Class