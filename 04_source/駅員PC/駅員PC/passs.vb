Imports MySql.Data.MySqlClient

Public Class passs
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
        Dim ge As Integer
        Dim stdate As Date = DateTime.Today


        If Rad1m.Checked Then
            mont = 1
        End If

        If Rad3m.Checked Then
            mont = 3
        End If

        If Rad6m.Checked Then
            mont = 6
        End If

        If stRB.Checked Then
            ge = 1
        End If

        If meRB.Checked Then
            ge = 2
        End If

        If stRBu.Checked Then
            ge = 3
        End If

        If stRBk.Checked Then
            ge = 4
        End If

        If stRBc.Checked Then
            ge = 5
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

        Dim nextForm As New passsFe()
        nextForm.ReceivedId = newId ' IDを渡す
        nextForm.Show()
        Me.Hide()
    End Sub
End Class