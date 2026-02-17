Public Class seICend
    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        mainsf.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()

        Dim fnext As New mainsf()
        fnext.Show()
        Me.Hide()
    End Sub

    Private Sub seICend_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Interval = 3000
        Timer1.Start()
    End Sub
End Class