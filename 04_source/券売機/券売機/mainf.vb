Public Class mainf
    Private Sub bticket_Click(sender As Object, e As EventArgs) Handles bticket.Click
        ticketCo.Show()
        Me.Hide()
    End Sub

    Private Sub bpass_Click(sender As Object, e As EventArgs) Handles bpass.Click
        passn.Show()
        Me.Hide()
    End Sub

    Private Sub bictouch_Click(sender As Object, e As EventArgs) Handles bictouch.Click
        IC.Show()
        Me.Hide()
    End Sub

    Private Sub bicissue_Click(sender As Object, e As EventArgs) Handles bicissue.Click
        isICno.Show()
        Me.Hide()
    End Sub
End Class
