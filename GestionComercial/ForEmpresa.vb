Public Class ForEmpresa

    Private Sub EmpresaBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpresaBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.EmpresaBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DistribuidoraJuguetesDataSet)

    End Sub

    Private Sub ForTarifas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DistribuidoraJuguetesDataSet.Empresa' Puede moverla o quitarla según sea necesario.
        Me.CenterToScreen()
        Me.EmpresaTableAdapter.Fill(Me.DistribuidoraJuguetesDataSet.Empresa)
    End Sub

    
    Private Sub TelefonoLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class