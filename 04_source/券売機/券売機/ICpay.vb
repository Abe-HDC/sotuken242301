Imports MySql.Data.MySqlClient

Public Class ICpay
    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Const cardType As Integer = 5     'カードタイプ
    Public Property ReceivedId As Integer

    Public Property ReceivedCharge As Integer

    Private Sub ICpay_Load(sender As Object, e As EventArgs) Handles Me.Load
        FeLel.Text = ReceivedCharge.ToString()
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
        Command.CommandText = $"SELECT bal-{ReceivedCharge} bal FROM iccard WHERE ICno = {ReceivedId}"
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then

            baLal.Text = DataReader("bal").ToString()

        End If

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        'If result = 0 Then
        '    Dim nextForm As New ICpay()
        '    nextForm.ReceivedId = ReceivedId ' IDを渡す
        'End If
    End Sub


    Private Sub Febtn_Click(sender As Object, e As EventArgs) Handles Febtn.Click
        '変数の宣言
        'Dim data() As Byte        '読込データバッファ
        'Dim dataLength As Integer   '読込データサイズ
        Dim id(32) As Byte          'カードID
        'Dim idLength As Integer     'カードIDサイズ
        'Dim cardType As Integer     'カードタイプ
        Dim idString As String = ""      'カードID文字列
        Dim dataString As String = ""    '結果文字列
        Dim result As Integer


        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT bal-{ReceivedCharge} bal FROM iccard WHERE ICno = {ReceivedId}"
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then

            baLal.Text = DataReader("bal").ToString()

        End If

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        If result = 0 Then
            Dim nextForm As New ICchend()
            nextForm.ReceivedId = ReceivedId ' IDを渡す
            nextForm.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        ICcharge.Show()
        Me.Hide()
    End Sub
End Class