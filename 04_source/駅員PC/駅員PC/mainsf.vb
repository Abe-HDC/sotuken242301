Public Class mainsf
    Private Sub bticket_Click(sender As Object, e As EventArgs) Handles bticket.Click
        tickets.Show()
        Me.Hide()
    End Sub

    Private Sub bpass_Click(sender As Object, e As EventArgs) Handles bpass.Click
        passn.Show()
        Me.Hide()
    End Sub

    Private Sub ictouch_Click(sender As Object, e As EventArgs) Handles ictouch.Click
        ICs.Show()
        Me.Hide()
    End Sub

    Private Sub bofs_Click(sender As Object, e As EventArgs) Handles bofs.Click
        mainsse.Show()
        Me.Hide()
    End Sub
End Class
