Public Class ticketpr

    Private Sub bpr160_Click(sender As Object, e As EventArgs) Handles bpr160.Click
        Dim un As Integer = 160
        Dim ti As New ticketFe(un)
        ti.Show()
        Me.Hide()
    End Sub

    Private Sub bpr180_Click(sender As Object, e As EventArgs) Handles bpr180.Click
        Dim un As Integer = 180
        Dim ti As New ticketFe(un)
        ti.Show()
        Me.Hide()
    End Sub

    Private Sub bpr210_Click(sender As Object, e As EventArgs) Handles bpr210.Click
        Dim un As Integer = 210
        Dim ti As New ticketFe(un)
        ti.Show()
        Me.Hide()
    End Sub

    Private Sub bprS270_Click(sender As Object, e As EventArgs) Handles bprS270.Click
        Dim un As Integer = 270
        Dim ti As New ticketFe(un)
        ti.Show()
        Me.Hide()
    End Sub

    Private Sub bpr330_Click(sender As Object, e As EventArgs) Handles bpr330.Click
        Dim un As Integer = 330
        Dim ti As New ticketFe(un)
        ti.Show()
        Me.Hide()
    End Sub

    Private Sub bpr380_Click(sender As Object, e As EventArgs) Handles bpr380.Click
        Dim un As Integer = 380
        Dim ti As New ticketFe(un)
        ti.Show()
        Me.Hide()
    End Sub

    Private Sub bprY430_Click(sender As Object, e As EventArgs) Handles bprY430.Click
        Dim un As Integer = 430
        Dim ti As New ticketFe(un)
        ti.Show()
        Me.Hide()
    End Sub

    Private Sub bprT460_Click(sender As Object, e As EventArgs) Handles bprT460.Click
        Dim un As Integer = 490
        Dim ti As New ticketFe(un)
        ti.Show()
        Me.Hide()
    End Sub

    Private Sub bprT540_Click(sender As Object, e As EventArgs) Handles bprT540.Click
        Dim un As Integer = 540
        Dim ti As New ticketFe(un)
        ti.Show()
        Me.Hide()
    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        mainf.Show()
        Me.Hide()
    End Sub


    Private Sub ticketpr_Load(sender As Object, e As EventArgs) Handles Me.Load
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