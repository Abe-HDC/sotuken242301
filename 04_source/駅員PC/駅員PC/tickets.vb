Public Class tickets
    Private Sub Nbtn_Click(sender As Object, e As EventArgs) Handles Nbtn.Click
        Dim stday As String = dayDTP.Value.ToString("yyyy/MM/dd")
        Dim sts As String = CBst.Text
        Dim ends As String = CBend.Text
        Dim rb As Integer

        If owRB.Checked Then
            rb = 1
        End If

        If rtRB.Checked Then
            rb = 2
        End If


    End Sub
End Class