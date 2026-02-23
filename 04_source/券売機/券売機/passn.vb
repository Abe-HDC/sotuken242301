Public Class passn

    Private Sub nBtn_Click(sender As Object, e As EventArgs) Handles nBtn.Click
        passnIC.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        passIC.Show()
        Me.Hide()
    End Sub

    Private Sub coBtn_Click(sender As Object, e As EventArgs) Handles coBtn.Click
        passco.Show()
        Me.Hide()
    End Sub
    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        mainf.Show()
        Me.Hide()
    End Sub

    Private Sub passn_Load(sender As Object, e As EventArgs) Handles Me.Load
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