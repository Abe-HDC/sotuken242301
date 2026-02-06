Imports MySql.Data.MySqlClient

Public Class seticket
    Dim fare As Integer = 0
    Dim farese As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sts As String = stTB.Text
        Dim ends As String = endTB.Text
        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT s1.stationname,s2.stationname,fareusu.fare FROM com JOIN station AS s1 ON com.busid IN (SELECT busid FROM ruote WHERE ruoid = s1.ruoid) JOIN station AS s2 ON com.busid IN (SELECT busid FROM ruote WHERE ruoid = s2.ruoid) JOIN fareusu ON com.busid = fareusu.busid JOIN medium ON fareusu.medium = medium.mediumno WHERE s1.stationname = '{stTB.Text}' AND s2.stationname = '{endTB.Text}' AND fareusu.medium = 2 AND ABS(s2.pointkm - s1.pointkm) >= fareusu.minkm AND ABS(s2.pointkm - s1.pointkm) < fareusu.maxkm;"
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then
            fare = DataReader("fare").ToString()
        End If

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        Override()

        FeLal.Text = farese - fare

    End Sub

    Private Sub Override()
        Dim sts As String = stTB.Text
        Dim endse As String = endCB.Text
        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT s1.stationname,s2.stationname,fareusu.fare FROM com JOIN station AS s1 ON com.busid IN (SELECT busid FROM ruote WHERE ruoid = s1.ruoid) JOIN station AS s2 ON com.busid IN (SELECT busid FROM ruote WHERE ruoid = s2.ruoid) JOIN fareusu ON com.busid = fareusu.busid JOIN medium ON fareusu.medium = medium.mediumno WHERE s1.stationname = '{stTB.Text}' AND s2.stationname = '{endCB.Text}' AND fareusu.medium = 2 AND ABS(s2.pointkm - s1.pointkm) >= fareusu.minkm AND ABS(s2.pointkm - s1.pointkm) < fareusu.maxkm;"
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then
            farese = DataReader("fare").ToString()
        End If

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()
    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        mainsse.Show()
        Me.Hide()
    End Sub

    Private Sub cabtn_Click(sender As Object, e As EventArgs) Handles cabtn.Click
        seICend.Show()
        Me.Hide()
    End Sub
End Class