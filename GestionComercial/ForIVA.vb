Public Class ForIVA

    Private Sub IVABindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IVABindingNavigatorSaveItem.Click
        Me.Validate()
        Me.IVABindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DistribuidoraJuguetesDataSet)

    End Sub

    Private Sub ForIVA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DistribuidoraJuguetesDataSet.IVA' Puede moverla o quitarla según sea necesario.
        Me.CenterToScreen()
        Me.IVATableAdapter.Fill(Me.DistribuidoraJuguetesDataSet.IVA)
    End Sub
End Class