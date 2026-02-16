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

    Dim stde As Integer
    Dim ststa As Integer

    Dim endde As Integer
    Dim endsta As Integer

    Private Sub Nbtn_Click(sender As Object, e As EventArgs) Handles Nbtn.Click
        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

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

        Calculationst()
        Calculationend()


        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"INSERT INTO iccard(name,seinen,stday,endday,ruoteiddp,stationiddp,depass,ruoteidend,stationidend,arpass,gepass,month,caredid) VALUES ('{sei}','{seinen}','{std}','{endd}',{stde},{ststa},'{de}',{endde},{endsta},'{ar}',{ge},{mont},'{ReceivedId}'); "
        'SQLを実行
        DataReader = Command.ExecuteReader

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        Dim nextForm As New passFe()
        nextForm.ReceivedId = ReceivedId ' IDを渡す
        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Calculationst()
        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader


        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT ruoid,stationid FROM station WHERE stationname = '{de}'"
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then
            stde = DataReader("ruoid").ToString()
            ststa = DataReader("stationid").ToString()
        End If

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()
    End Sub

    Private Sub Calculationend()
        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader


        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT ruoid,stationid FROM station WHERE stationname = '{ar}' "
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then
            endde = DataReader("ruoid").ToString()
            endsta = DataReader("stationid").ToString()
        End If

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()
    End Sub
End Class
