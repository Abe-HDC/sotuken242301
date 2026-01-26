Imports MySql.Data.MySqlClient

Public Class passFe
    Public Property ReceivedId As Integer

    Private Sub passFe_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT name,seinen,stday,endday,depass,arpass,month FROM iccard WHERE ICno = {ReceivedId} "
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then
            nametxt.Text = DataReader("name").ToString()
            nameDTP.Tag = DataReader("seinen").ToString()
            stDTP.Text = DataReader("stday").ToString()
            endDTP.Text = DataReader("endday").ToString()
            deComboBox.Text = DataReader("depass").ToString()
            arComboBox.Text = DataReader("arpass").ToString()

            Dim monthValue As String = DataReader("month").ToString()

            Rad1m.Checked = (monthValue = "1")
            Rad3m.Checked = (monthValue = "3")
            Rad6m.Checked = (monthValue = "6")
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
        Command.CommandText = $"SELECT name,seinen,stday,endday,depass,arpass,month FROM iccard WHERE ICno = {ReceivedId} "
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then
            nametxt.Text = DataReader("name").ToString()
            nameDTP.Tag = DataReader("seinen").ToString()
            stDTP.Text = DataReader("stday").ToString()
            endDTP.Text = DataReader("endday").ToString()
            deComboBox.Text = DataReader("depass").ToString()
            arComboBox.Text = DataReader("arpass").ToString()

            Dim monthValue As String = DataReader("month").ToString()

            Rad1m.Checked = (monthValue = "1")
            Rad3m.Checked = (monthValue = "3")
            Rad6m.Checked = (monthValue = "6")
        End If


        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()
    End Sub

    Private Sub isbtn_Click(sender As Object, e As EventArgs) Handles isbtn.Click

    End Sub


End Class