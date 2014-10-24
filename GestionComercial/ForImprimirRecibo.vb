Imports System.Data.SqlClient

Public Class ForImprimirRecibo

    Dim Conexion As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Dim consulta As New SqlCommand
    Dim Mireader As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DistribuidoraJuguetesDataSet
    Dim codigo As String


    Private Sub ForImprimirRecibo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        dgRecibos.Rows.Clear()

        ' Cargamos los datos de las facturas
        Try
            Conexion.Open()
            consulta = New SqlCommand("Select codigo, nomcli, codfactura, banco, cuenta, fecharecibo, importe, emitido from Recibos", Conexion)
            Mireader = consulta.ExecuteReader() ' Devuelve un conjunto de registros
            While Mireader.Read
                dgRecibos.Rows.Add(Mireader.GetValue(0), Mireader.GetValue(1), Mireader.GetValue(2), Mireader.GetValue(3), Mireader.GetValue(4), Format(Mireader.GetValue(5), "d"), Mireader.GetValue(6), Mireader.GetValue(7))
            End While
            Mireader.Close()
            Conexion.Close()
        Catch ex As Exception
            Conexion.Close()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' Creamos una nueva conexion
        Dim Conexion2 As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
        ' Creamos un Visor
        Dim visor As New Visor
        ' Creamos un dataset
        Dim dataset As New NuevoDataSet
        ' Creamos un Listado para Albaranes
        Dim listado As New Recibos
        ' Creamos un DataAdapter
        Dim da1 As SqlClient.SqlDataAdapter


        codigo = CStr(dgRecibos.SelectedRows(0).Cells(0).Value)


        ' Creamos las consultas y rellenamos el dataset 
        da1 = New SqlClient.SqlDataAdapter("SELECT * FROM RECIBOS WHERE CODIGO= '" & codigo & "' AND CODFACTURA='" & CStr(dgRecibos.SelectedRows(0).Cells(2).Value) & "';", Conexion2)
        da1.Fill(dataset, "RECIBOS")

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

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class