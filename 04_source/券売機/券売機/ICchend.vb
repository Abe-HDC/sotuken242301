Imports MySql.Data.MySqlClient

Public Class ICchend
    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Const cardType As Integer = 5     'カードタイプ
    Public Property ReceivedId As Integer

    Private Sub ICchend_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        Timer1.Interval = 3000
        Timer1.Start()

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT  bal FROM iccard WHERE ICno = {ReceivedId}"
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

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        mainf.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()

        Dim fnext As New mainf()
        fnext.Show()
        Me.Hide()
    End Sub
End Class