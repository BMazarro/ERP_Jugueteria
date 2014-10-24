Public Class ForFormasPago

    Private Sub FormasPagoBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormasPagoBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.FormasPagoBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DistribuidoraJuguetesDataSet)

    End Sub

    Private Sub ForFormasPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DistribuidoraJuguetesDataSet.FormasPago' Puede moverla o quitarla según sea necesario.
        Me.CenterToScreen()
        Me.FormasPagoTableAdapter.Fill(Me.DistribuidoraJuguetesDataSet.FormasPago)
    End Sub

End Class