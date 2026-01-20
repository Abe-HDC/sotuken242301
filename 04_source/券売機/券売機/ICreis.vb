Public Class ICreis
    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        mainf.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()

        Dim fnext As New mainf()
        fnext.Show()
        Me.Hide()
    End Sub

    Private Sub isICend_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Interval = 3000
        Timer1.Start()
    End Sub
End Class