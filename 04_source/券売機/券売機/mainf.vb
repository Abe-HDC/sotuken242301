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

    Private Sub mainf_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' 画面の作業領域（タスクバーを除く）
        Dim wa = Screen.PrimaryScreen.WorkingArea

        ' 幅と高さを 1/4 に
        Me.Width = wa.Width \ 2
        Me.Height = wa.Height \ 2

        ' 左上に配置
        Me.Left = wa.Left
        Me.Top = wa.Top
    End Sub
End Class
