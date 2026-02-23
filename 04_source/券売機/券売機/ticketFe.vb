Public Class ticketFe
    Private tic As Integer

    Public Sub New(ti As Integer)
        InitializeComponent()
        tic = ti
    End Sub

    Private Sub ticketFe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 画面の作業領域（タスクバーを除く）
        Dim wa = Screen.PrimaryScreen.WorkingArea

        ' 幅と高さを 1/4 に
        Me.Width = wa.Width \ 2
        Me.Height = wa.Height \ 2

        ' 左上に配置
        Me.Left = wa.Left
        Me.Top = wa.Top

        FeLel.Text = tic
        chLal.Text = 0
    End Sub

    Private Sub FeTxt_TextChanged(sender As Object, e As EventArgs) Handles FeTxt.TextChanged
        Dim tou As Integer = 0

        Integer.TryParse(FeTxt.Text, tou)

        Dim sum As Integer = tou - tic
        chLal.Text = sum

    End Sub

    Private Sub isbtn_Click(sender As Object, e As EventArgs) Handles isbtn.Click
        ticketch.Show()
        Me.Hide()
    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        ticketCo.Show()
        Me.Hide()
    End Sub
End Class