Public Class ForTarifas

    Private Sub TarifasBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifasBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.TarifasBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DistribuidoraJuguetesDataSet)

    End Sub

    Private Sub ForTarifas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DistribuidoraJuguetesDataSet.Tarifas' Puede moverla o quitarla según sea necesario.
        Me.CenterToScreen()
        Me.TarifasTableAdapter.Fill(Me.DistribuidoraJuguetesDataSet.Tarifas)
    End Sub
End Class