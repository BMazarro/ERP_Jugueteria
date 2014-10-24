Imports System.Data.SqlClient

Public Class LibroIVA
    Dim Conexion As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Dim consulta As New SqlCommand
    Dim Mireader As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DistribuidoraJuguetesDataSet


    Private Sub LibroIVA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        ' Borramos las tablas
        dgRep.Rows.Clear()
        dgSop.Rows.Clear()

        ' Cargamos los datos en la tabla Repercutidos (corresponden a las Ventas)
        Try
            Conexion.Open()
            consulta = New SqlCommand("Select codfactura, fecha, nombre, nif, bases,totalfactura from LibroIva where tipo = 'R'", Conexion)
            Mireader = consulta.ExecuteReader() ' Devuelve un conjunto de registros
            While Mireader.Read
                dgRep.Rows.Add(Mireader.GetValue(0), Format(Mireader.GetValue(1), "d"), Mireader.GetValue(2), Mireader.GetValue(3), Mireader.GetValue(4), Mireader.GetValue(5))
            End While
            Mireader.Close()
            Conexion.Close()
        Catch ex As Exception
            Conexion.Close()
        End Try

        ' Cargamos los datos en la tabla Soportados (corresponden a las compras)
        Try
            Conexion.Open()
            consulta = New SqlCommand("Select codfactura, fecha, nombre, nif, bases,totalfactura from LibroIva where tipo = 'S'", Conexion)
            Mireader = consulta.ExecuteReader() ' Devuelve un conjunto de registros
            While Mireader.Read
                dgSop.Rows.Add(Mireader.GetValue(0), Format(Mireader.GetValue(1), "d"), Mireader.GetValue(2), Mireader.GetValue(3), Mireader.GetValue(4), Mireader.GetValue(5))
            End While
            Mireader.Close()
            Conexion.Close()
        Catch ex As Exception
            Conexion.Close()
        End Try

    End Sub

    Private Sub buttonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonSalir.Click
        Me.Close()
    End Sub

End Class