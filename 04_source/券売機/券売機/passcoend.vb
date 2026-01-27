Public Class passcoend
    Private Sub passcoend_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Interval = 3000
        Timer1.Start()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        Timer1.Stop()

        Dim fnext As New mainf
        fnext.Show()
        Hide()
    End Sub
    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        mainf.Show()
        Me.Hide()
    End Sub

    Private Sub isbtn_Click(sender As Object, e As EventArgs) Handles isbtn.Click
        MessageBox.Show("領収書が発行されました")
    End Sub


End Class