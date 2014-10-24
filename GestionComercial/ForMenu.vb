Imports System.Data.SqlClient

Public Class ForMenu
    Dim Conexion As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Dim mivisor As New Visor

    Private Sub ForMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        leerDatosEmpresa()
    End Sub

    Private Sub IVAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IVAToolStripMenuItem.Click
        Dim b As New ForIVA
        b.ShowDialog()
    End Sub

    Private Sub EmpresaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpresaToolStripMenuItem.Click
        Dim b As New ForEmpresa
        b.ShowDialog()
    End Sub

    Private Sub TarifasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifasToolStripMenuItem.Click
        Dim b As New ForTarifas
        b.ShowDialog()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim b As New ForClientes
        b.ShowDialog()
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProveedoresToolStripMenuItem.Click
        Dim b As New ForProveedores
        b.ShowDialog()
    End Sub

    Private Sub ArticulosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArticulosToolStripMenuItem.Click
        Dim b As New ForArticulos
        b.ShowDialog()
    End Sub

    Private Sub EntradaAlbaranesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntradaAlbaranesToolStripMenuItem.Click
        Dim b As New ForEntAlbaran
        b.ShowDialog()
    End Sub

    Private Sub FormasDePagoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormasDePagoToolStripMenuItem.Click
        Dim b As New ForFormasPago
        b.ShowDialog()
    End Sub

    Private Sub ListadoDeClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeClientesToolStripMenuItem.Click

        Dim informeclientes As New CrClientes
        Dim ds As New DataSet
        Dim consulta As String = "Select * from Clientes order by codcli"
        Dim da As New SqlClient.SqlDataAdapter(consulta, Conexion)

        Try
            Conexion.Open()
            da.Fill(ds, "Clientes")
            mivisor.CrViewer.ReportSource = informeclientes
            informeclientes.SetDataSource(ds)
            mivisor.ShowDialog()
            Conexion.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListadoAlfabéticoDeClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoAlfabéticoDeClientesToolStripMenuItem.Click

        Dim informeclientes As New CrClientes
        Dim ds As New DataSet
        Dim consulta As String = "Select * from Clientes order by nombre"
        Dim da As New SqlClient.SqlDataAdapter(consulta, Conexion)

        Try
            Conexion.Open()
            da.Fill(ds, "Clientes")
            mivisor.CrViewer.ReportSource = informeclientes
            informeclientes.SetDataSource(ds)
            mivisor.ShowDialog()
            Conexion.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListadoDeProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeProveedoresToolStripMenuItem.Click

        Dim informeproveedores As New CrProveedores
        Dim ds As New DataSet
        Dim consulta As String = "Select * from Proveedores order by codprov"
        Dim da As New SqlClient.SqlDataAdapter(consulta, Conexion)

        Try
            Conexion.Open()
            da.Fill(ds, "Proveedores")
            mivisor.CrViewer.ReportSource = informeproveedores
            informeproveedores.SetDataSource(ds)
            mivisor.ShowDialog()
            Conexion.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListadoAlfabéticoDeProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoAlfabéticoDeProveedoresToolStripMenuItem.Click

        Dim informeproveedores As New CrProveedores
        Dim ds As New DataSet
        Dim consulta As String = "Select * from Proveedores order by nombre"
        Dim da As New SqlClient.SqlDataAdapter(consulta, Conexion)

        Try
            Conexion.Open()
            da.Fill(ds, "Proveedores")
            mivisor.CrViewer.ReportSource = informeproveedores
            informeproveedores.SetDataSource(ds)
            mivisor.ShowDialog()
            Conexion.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListadoDeArtículosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeArtículosToolStripMenuItem.Click

        Dim informearticulos As New CrArticulos
        Dim ds As New DataSet
        Dim consulta As String = "Select * from Articulos order by codigo"
        Dim da As New SqlClient.SqlDataAdapter(consulta, Conexion)

        Try
            Conexion.Open()
            da.Fill(ds, "Articulos")
            mivisor.CrViewer.ReportSource = informearticulos
            informearticulos.SetDataSource(ds)
            mivisor.ShowDialog()
            Conexion.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListadoAlfabéticoArtículosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoAlfabéticoArtículosToolStripMenuItem.Click

    End Sub

    Private Sub ModificarAlbaránToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarAlbaránToolStripMenuItem.Click
        Dim b As New ForMantenimientoAlbaran
        b.ShowDialog()
    End Sub

    Private Sub EntradaAlbaránCompraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntradaAlbaránCompraToolStripMenuItem.Click
        Dim b As New ForCompras
        b.ShowDialog()
    End Sub

    ' ----------- LISTADO DE ALBARANES POR CLIENTES --------------------------------------------------------------------------------------------------------------
    Private Sub ListadoPorClientesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoPorClientesToolStripMenuItem1.Click
        Dim informealbaranes As New CrAlbaranes
        Dim ds As New DistribuidoraJuguetesDataSet
        Dim consulta As String = "Select * from CabPieAlbaran order by codcli"
        Dim da As New SqlClient.SqlDataAdapter(consulta, Conexion)

        Try
            Conexion.Open()
            da.Fill(ds, "CabPieAlbaran")
            mivisor.CrViewer.ReportSource = informealbaranes
            informealbaranes.SetDataSource(ds)
            mivisor.ShowDialog()
            Conexion.Close()

        Catch ex As Exception

        End Try
    End Sub

    ' ----------- LISTADO DE ALBARANES POR FECHAS ----------------------------------------------------------
    Private Sub AlbaranesPorFechasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlbaranesPorFechasToolStripMenuItem.Click
        Dim informealbaranes As New CrAlbaranes
        Dim ds As New DistribuidoraJuguetesDataSet
        Dim consulta As String = "Select * from CabPieAlbaran order by fecha"
        Dim da As New SqlClient.SqlDataAdapter(consulta, Conexion)

        Try
            Conexion.Open()
            da.Fill(ds, "CabPieAlbaran")
            mivisor.CrViewer.ReportSource = informealbaranes
            informealbaranes.SetDataSource(ds)
            mivisor.ShowDialog()
            Conexion.Close()

        Catch ex As Exception

        End Try
    End Sub

    ' ------------ 
    Private Sub MostrarLibroDeIVAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MostrarLibroDeIVAToolStripMenuItem.Click
        Dim b As New LibroIVA
        b.ShowDialog()
    End Sub

    Private Sub ListadoDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeToolStripMenuItem.Click
        

    End Sub

    ' ----------- LISTADO DE APUNTES REPERCUTIDOS ------------------------------------------------------------------------------------------------------
    Private Sub RepercutidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepercutidoToolStripMenuItem.Click
        Dim listado As New CrLibroIVA
        Dim ds As New DistribuidoraJuguetesDataSet
        Dim consulta As String = "SELECT * FROM LibroIva WHERE TIPO = 'R';"
        Dim da As New SqlClient.SqlDataAdapter(consulta, Conexion)

        Try
            Conexion.Open()
            da.Fill(ds, "LibroIva")
            mivisor.CrViewer.ReportSource = listado
            listado.SetDataSource(ds)
            ' Mostramos los parámetros de los datos de Empresa
            listado.SetParameterValue("nombre", nombre.ToString)
            listado.SetParameterValue("domicilio", domicilio.ToString)
            listado.SetParameterValue("localidad", localidad.ToString)
            listado.SetParameterValue("provincia", provincia.ToString)
            listado.SetParameterValue("cp", cp.ToString)
            listado.SetParameterValue("nif", nif.ToString)
            listado.SetParameterValue("telefono", telefono.ToString)

            mivisor.ShowDialog()
            Conexion.Close()

        Catch ex As Exception

        End Try
    End Sub

    ' ----------- LISTADO DE APUNTES SOPORTADOS -------------------------------------------------------------------------------------------------------
    Private Sub SoportadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoportadoToolStripMenuItem.Click
        Dim listado As New CrLibroIVA
        Dim ds As New DistribuidoraJuguetesDataSet
        Dim consulta As String = "SELECT * FROM LibroIva WHERE TIPO = 'S';"
        Dim da As New SqlClient.SqlDataAdapter(consulta, Conexion)

        Try
            Conexion.Open()
            da.Fill(ds, "LibroIva")
            mivisor.CrViewer.ReportSource = listado
            listado.SetDataSource(ds)
            ' Mostramos los parámetros de los datos de Empresa
            listado.SetParameterValue("nombre", nombre.ToString)
            listado.SetParameterValue("domicilio", domicilio.ToString)
            listado.SetParameterValue("localidad", localidad.ToString)
            listado.SetParameterValue("provincia", provincia.ToString)
            listado.SetParameterValue("cp", cp.ToString)
            listado.SetParameterValue("nif", nif.ToString)
            listado.SetParameterValue("telefono", telefono.ToString)

            mivisor.ShowDialog()
            Conexion.Close()

        Catch ex As Exception

        End Try
    End Sub

    ' ----------- LISTADO DE ALBARANES DE COMPRA POR CODIGO DE PROVEEDOR -----------------------------------------------------------------------------------------------------
    Private Sub ListadoDeAlbaranesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeAlbaranesToolStripMenuItem.Click
        Dim informealbaranes As New CrAlbaranesCompra
        Dim ds As New DistribuidoraJuguetesDataSet
        Dim consulta As String = "Select * from CabPieAlbaranCompra"
        Dim da As New SqlClient.SqlDataAdapter(consulta, Conexion)

        Try
            Conexion.Open()
            da.Fill(ds, "CabPieAlbaranCompra")
            mivisor.CrViewer.ReportSource = informealbaranes
            informealbaranes.SetDataSource(ds)
            mivisor.ShowDialog()
            Conexion.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RecibosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecibosToolStripMenuItem.Click
        Dim b As New ForImprimirFactura
        b.ShowDialog()
    End Sub

    Private Sub ListadoDeFacturasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeFacturasToolStripMenuItem.Click
        Dim b As New ForImprimirRecibo
        b.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim b As New ForFacturarClientes
        b.ShowDialog()
    End Sub

End Class
