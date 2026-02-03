Imports MySql.Data.MySqlClient

Public Class ticketsFe
    Public Property stdayfe As String
    Public Property stsfe As String
    Public Property endsfe As String
    Public Property rbfe As Integer
    Dim fare As Integer

    Private Sub ticketsFe_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader



        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT s1.stationname,s2.stationname,fareusu.fare FROM com JOIN ruote ON com.busid = ruote.busid JOIN station AS s1 ON ruote.ruoid = s1.ruoid JOIN station AS s2 ON ruote.ruoid = s2.ruoid JOIN fareusu ON com.busid = fareusu.busid JOIN medium ON fareusu.medium = medium.mediumno WHERE s1.stationname = '{stsfe}' AND s2.stationname = '{endsfe}' AND ABS(s2.pointkm - s1.pointkm) >= fareusu.minkm AND ABS(s2.pointkm - s1.pointkm) < fareusu.maxkm AND fareusu.medium = 2"
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then
            fare = DataReader("fare").ToString()
        End If

        dayDTP.Text = stdayfe

        CBst.Text = stsfe

        CBend.Text = endsfe

        If rbfe < 2 Then
            owRB.Checked = True
            FeLel.Text = fare
        Else
            rtRB.Checked = True
            FeLel.Text = fare * 2
        End If

        chLal.Text = 0

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()
    End Sub

    Private Sub FeTxt_TextChanged(sender As Object, e As EventArgs) Handles Fetxt.TextChanged
        Dim tou As Integer = 0

        Integer.TryParse(Fetxt.Text, tou)

        Dim sum As Integer = tou - fare
        chLal.Text = sum

    End Sub

    Private Sub Febtn_Click(sender As Object, e As EventArgs) Handles Febtn.Click
        ticketsch.Show()
        Me.Hide()
    End Sub

    Private Sub Btin_Click(sender As Object, e As EventArgs) Handles Btin.Click
        tickets.Show()
        Me.Hide()
    End Sub
End Class