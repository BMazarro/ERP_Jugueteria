Imports System.Data.SqlClient

Public Class ForImprimirFactura

    Dim Conexion As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Dim consulta As New SqlCommand
    Dim Mireader As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DistribuidoraJuguetesDataSet

    Private Sub ForImprimirFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        dgFacturas.Rows.Clear()

        ' Cargamos los datos de las facturas
        Try
            Conexion.Open()
            consulta = New SqlCommand("Select codfactura, fecha, codcli, impreso, porcentajeiva, formapago, sumatotal from CabPieFactura", Conexion)
            Mireader = consulta.ExecuteReader() ' Devuelve un conjunto de registros
            While Mireader.Read
                dgFacturas.Rows.Add(Mireader.GetValue(0), Format(Mireader.GetValue(1), "d"), Mireader.GetValue(2), Mireader.GetValue(3), Mireader.GetValue(4), Mireader.GetValue(5), Mireader.GetValue(6))
            End While
            Mireader.Close()
            Conexion.Close()
        Catch ex As Exception
            Conexion.Close()
        End Try
    End Sub

    ' --------- BOTON IMPRIMIR FACTURA ----------------------------------------------------------------------
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

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

        Dim codigo As String
        codigo = CStr(dgFacturas.SelectedRows(0).Cells(0).Value)


        ' Creamos las consultas y rellenamos el dataset 
        da1 = New SqlClient.SqlDataAdapter("SELECT * FROM CabPieFactura WHERE CabPieFactura.codfactura= '" & codigo & "';", Conexion2)
        da1.Fill(dataset, "CABPIEFACTURA")
        da1 = New SqlClient.SqlDataAdapter("SELECT LineasFactura.* FROM LineasFactura WHERE LineasFactura.codfactura = '" & codigo & "';", Conexion2)
        da1.Fill(dataset, "LINEASFACTURA")
        da1 = New SqlClient.SqlDataAdapter("SELECT * FROM Clientes WHERE Clientes.codcli = '" & CStr(dgFacturas.SelectedRows(0).Cells(2).Value) & "';", Conexion2)
        da1.Fill(dataset, "CLIENTES")
        da1 = New SqlClient.SqlDataAdapter("SELECT FormasPago.* FROM FormasPago, CabPieFactura WHERE CabPieFactura.formapago = FormasPago.tipo and CabPieFactura.codfactura= '" & codigo & "';", Conexion2)
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

        ' Ponemos la factura como impresa
        Try
            Conexion.Open()
            consulta = New SqlCommand("UPDATE CABPIEFACTURA SET IMPRESO = 'S' WHERE CODFACTURA ='" & codigo & "'", Conexion)
            consulta.ExecuteNonQuery()
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
        ForImprimirFactura_Load(sender, e)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class