Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports MySql.Data.MySqlClient

Public Class pass

    Public Property ReceivedId As String

    Dim sei As String
    Dim seinen As String
    Dim std As String
    Dim endd As String
    Dim mont As Integer = 0
    Dim de As String
    Dim ar As String
    Dim ge As Integer = 1
    Dim stdate As Date



    Private Sub Nbtn_Click(sender As Object, e As EventArgs) Handles Nbtn.Click
        sei = nametxt.Text
        seinen = nameDTP.Value.ToString("yyyy/MM/dd")
        std = stDTP.Value.ToString("yyyy/MM/dd")
        endd = endDTP.Value.ToString("yyyy/MM/dd")
        de = deComboBox.Text
        ar = arComboBox.Text
        stdate = DateTime.Today


        If Rad1m.Checked Then
            mont = 1
        End If

        If Rad3m.Checked Then
            mont = 3
        End If

        If Rad6m.Checked Then
            mont = 6
        End If




        Dim nextForm As New passFe()
        nextForm.ReceivedId = ReceivedId ' IDを渡す
        nextForm.Sei = sei
        nextForm.Seinen = seinen
        nextForm.Std = std
        nextForm.Endd = endd

        nextForm.De = de
        nextForm.Ar = ar
        nextForm.Stdate = stdate
        nextForm.Ge = ge
        nextForm.Mont = mont


        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click

    End Sub
End Class

