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
End Class