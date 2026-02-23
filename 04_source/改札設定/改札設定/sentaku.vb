Public Class sentaku
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ruote As Integer = TextBox2.Text

        Dim station As Integer = TextBox1.Text

        Dim nextForm As New gateend()
        nextForm.ruoteid = ruote ' IDを渡す
        nextForm.stationid = station
        nextForm.Show()
        Me.Hide()

    End Sub

    Private Sub sentaku_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' 画面の作業領域（タスクバーを除く）
        Dim wa = Screen.PrimaryScreen.WorkingArea

        ' 幅と高さを 1/4 に
        Me.Width = wa.Width \ 2
        Me.Height = wa.Height \ 2

        ' 左上に配置
        Me.Left = wa.Left
        Me.Top = wa.Bottom - Me.Height
    End Sub
End Class