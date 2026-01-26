Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports MySql.Data.MySqlClient

Public Class pass

    Private Sub Nbtn_Click(sender As Object, e As EventArgs) Handles Nbtn.Click
        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        'Dim DataReader As MySqlDataReader
        Dim sei As String = nametxt.Text
        Dim seinen As String = nameDTP.Value.ToString("yyyy/MM/dd")
        Dim std As String = stDTP.Value.ToString("yyyy/MM/dd")
        Dim endd As String = endDTP.Value.ToString("yyyy/MM/dd")
        Dim mont As Integer
        Dim de As String = deComboBox.Text
        Dim ar As String = arComboBox.Text
        Dim ge As Integer = 1
        Dim stdate As Date = DateTime.Today


        If Rad1m.Checked Then
            mont = Rad1m.Tag
        End If

        If Rad3m.Checked Then
            mont = Rad3m.Tag
        End If

        If Rad6m.Checked Then
            mont = Rad6m.Tag
        End If

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"INSERT INTO iccard(name,seinen,stday,endday,depass,arpass,gepass,month) VALUES ('{sei}','{seinen}','{std}','{endd}','{de}','{ar}',{ge},{mont}); SELECT LAST_INSERT_ID(); "
        'SQLを実行
        'DataReader = Command.ExecuteReader
        Dim newId As Integer = Convert.ToInt32(Command.ExecuteScalar())

        'クローズ
        'DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        Dim nextForm As New passFe()
        nextForm.ReceivedId = newId ' IDを渡す
        nextForm.Show()
        Me.Hide()
    End Sub
End Class