Imports System.Net

Public Class passsch

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()

        Dim fnext As New mainsf()
        fnext.Show()
        Me.Hide()
    End Sub
    Private Sub isbtn_Click(sender As Object, e As EventArgs) Handles isbtn.Click
        MessageBox.Show("領収書が発行されました")
    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        mainsf.Show()
        Me.Hide()
    End Sub

    Private Sub passsch_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Interval = 3000
        Timer1.Start()
    End Sub
End Class