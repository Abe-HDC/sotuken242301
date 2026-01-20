Imports MySql.Data.MySqlClient

Public Class ICad
    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Const cardType As Integer = 5     'カードタイプ

    Public Property ReceivedId As Integer
    Private Sub ICad_Load(sender As Object, e As EventArgs) Handles Me.Load
        DisplayBalance()
    End Sub

    Private Sub DisplayBalance()
        '変数の宣言
        'Dim data() As Byte        '読込データバッファ
        'Dim dataLength As Integer   '読込データサイズ
        Dim id(32) As Byte          'カードID
        'Dim idLength As Integer     'カードIDサイズ
        'Dim cardType As Integer     'カードタイプ
        Dim idString As String = ""      'カードID文字列
        Dim dataString As String = ""    '結果文字列
        'Dim result As Integer


        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT reday 利用日時,bos 乗車駅,gos 降車駅,fare 運賃 FROM resume WHERE ICno = {ReceivedId}"
        'SQLを実行
        DataReader = Command.ExecuteReader

        Dim dt As New DataTable()

        dt.Load(DataReader)

        adDGV.DataSource = dt

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        'If result = 0 Then

        '    Dim nextForm As New ICcharge()
        '    nextForm.ReceivedId = ReceivedId ' IDを渡す
        'End If
    End Sub

    Private Sub hyozi_Click(sender As Object, e As EventArgs) Handles hyozi.Click
        '変数の宣言
        'Dim data() As Byte        '読込データバッファ
        'Dim dataLength As Integer   '読込データサイズ
        Dim id(32) As Byte          'カードID
        'Dim idLength As Integer     'カードIDサイズ
        'Dim cardType As Integer     'カードタイプ
        Dim idString As String = ""      'カードID文字列
        Dim dataString As String = ""    '結果文字列
        'Dim result As Integer
        Dim stD As String = stDTP.Value.ToString("yyyy/MM/dd")
        Dim endD As String = endDTP.Value.ToString("yyyy/MM/dd")


        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT reday 利用日時,bos 乗車駅,gos 降車駅,fare 運賃 FROM resume WHERE ICno = {ReceivedId} AND reday >= '{stD}' AND reday <= '{endD}' "
        'SQLを実行
        DataReader = Command.ExecuteReader

        Dim dt As New DataTable()

        dt.Load(DataReader)

        adDGV.DataSource = dt

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        'If result = 0 Then

        '    Dim nextForm As New ICcharge()
        '    nextForm.ReceivedId = ReceivedId ' IDを渡す
        'End If
    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        ICmain.Show()
        Me.Hide()
    End Sub

    Private Sub isbtn_Click(sender As Object, e As EventArgs) Handles isbtn.Click
        ICreis.Show()
        Me.Hide()
    End Sub
End Class