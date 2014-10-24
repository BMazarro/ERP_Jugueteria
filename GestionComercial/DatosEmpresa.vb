Imports System.Data.SqlClient

Module DatosEmpresa

    Public nombre As String
    Public domicilio As String
    Public localidad As String
    Public provincia As String
    Public cp As String
    Public nif As String
    Public telefono As String
    Dim Conexion3 As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Dam2_1314\Beatriz\GComercial\DistribuidoraJuguetes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    Dim consulta As New SqlCommand
    Dim Mireader As SqlDataReader
    Public Porctarifa1, Porctarifa2, Porctarifa3 As Integer
    Public estado As Integer = 0

    Public Sub leerDatosEmpresa()
        Try
            Conexion3.Open()
            consulta = New SqlCommand("Select * from Empresa", Conexion3)
            Mireader = consulta.ExecuteReader()
            Mireader.Read()
            nombre = Mireader("razon")
            domicilio = Mireader("domicilio")
            localidad = Mireader("localidad")
            provincia = Mireader("provincia")
            cp = Mireader("cp")
            nif = Mireader("nif")
            telefono = Mireader("telefono")
            Conexion3.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion3.Close()
            Mireader.Close()
        End Try
        Try
            Conexion3.Open()
            consulta = New SqlCommand("Select Porcentaje from Tarifas", Conexion3)
            Mireader = consulta.ExecuteReader()
            Mireader.Read()
            Porctarifa1 = CInt(Mireader(0).ToString)
            Mireader.Read()
            Porctarifa2 = CInt(Mireader(0).ToString)
            Mireader.Read()
            Porctarifa3 = CSng(Mireader(0).ToString)
            Mireader.Close()
            Conexion3.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub changeEstado()
        estado = 1
    End Sub
End Module
