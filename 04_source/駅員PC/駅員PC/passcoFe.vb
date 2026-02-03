Imports MySql.Data.MySqlClient

Public Class passcoFe
    Public Property ReceivedId As Integer

    Private Sub passcoFe_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader
        Dim mont As Integer
        Dim ge As Integer


        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT name,seinen,stday,endday,depass,arpass,gepass,month FROM iccard WHERE ICno = {ReceivedId} "
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then
            nametxt.Text = DataReader("name").ToString()
            nameDTP.Tag = DataReader("seinen").ToString()
            stDTP.Text = DataReader("stday").ToString()
            endDTP.Text = DataReader("endday").ToString()
            deComboBox.Text = DataReader("depass").ToString()
            arComboBox.Text = DataReader("arpass").ToString()
            ge = DataReader("gepass").ToString()
            mont = DataReader("month").ToString()
        End If

        If mont = 1 Then
            Rad1m.Checked = True
        ElseIf mont = 3 Then
            Rad3m.Checked = True
        ElseIf mont = 6 Then
            Rad6m.Checked = True
        End If

        If ge = 1 Then
            stRB.Checked = True
        ElseIf ge = 2 Then
            meRB.Checked = True
        ElseIf ge = 3 Then
            stRBu.Checked = True
        ElseIf ge = 4 Then
            stRBk.Checked = True
        ElseIf ge = 5 Then
            stRBc.Checked = True
        End If

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        Calculation()

    End Sub

    Private Sub Calculation()
        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT fare FROM farepass WHERE motno = (SELECT month FROM iccard WHERE ICno = {ReceivedId}) AND passno = (SELECT gepass FROM iccard WHERE ICno = {ReceivedId}) AND busid = (SELECT busid FROM station WHERE stationname = (SELECT depass FROM iccard WHERE ICno = {ReceivedId}) LIMIT 1) AND km = (SELECT CEIL(ABS(s1.pointkm - s2.pointkm)) FROM station s1, station s2, iccard i WHERE i.ICno = {ReceivedId} AND s1.stationname = i.depass AND s2.stationname = i.arpass LIMIT 1) "
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then
            FeLel.Text = DataReader("fare").ToString()
        End If


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

        Dim sum As Integer = tou - FeLel.Text
        chLal.Text = sum

    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        passcopay.Show()
        Me.Hide()
    End Sub

    Private Sub isbtn_Click(sender As Object, e As EventArgs) Handles isbtn.Click
        passcoend.Show()
        Me.Hide()
    End Sub
End Class