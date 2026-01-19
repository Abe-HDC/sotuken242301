Imports MySql.Data.MySqlClient

Public Class IC
    'Orange Tags Easy APIの定義
    Private Declare Function GetCardIDIndex Lib "OrangeOneStopEasyAPI.dll" (ByRef id As Byte, ByRef length As Integer, ByVal index As Integer) As Integer
    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer

    '変数の宣言
    Dim data(47) As Byte            '読込データバッファ
    Dim dataLength As Integer       '読込データサイズ
    Dim id(10) As Byte              'カードID
    Dim idLength As Integer         'カードIDサイズ
    Dim idString As String = ""     'カードID文字列
    Dim dataString As String = ""   '結果文字列
    Dim result As Integer           '読書き結果
    Const cardType As Integer = 5   'カードタイプ

    'カードIDの読み込み
    'Private Function ReadStart(ByVal reader As Integer) As Integer
    '    '変数の宣言
    '    Dim id(10) As Byte
    '    Dim length As Integer
    '    Dim Ret As Integer = GetCardIDIndex(id(0), length, reader)
    '    Return Ret
    'End Function



    'Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
    '    If ReadStart(0) = 0 Then
    '        Timer1.Enabled = False
    '        ICmain.Show()
    '        Me.Hide()
    '    End If
    'End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        mainf.Show()
        Me.Hide()
    End Sub

    Private Sub IC_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        'Dim DataReader As MySqlDataReader


        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $" SELECT LAST_INSERT_ID();"
        'SQLを実行
        'DataReader = Command.ExecuteReader
        Dim newId As Integer = Convert.ToInt32(Command.ExecuteScalar())


        'クローズ
        'DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        '結果表示
        If result = 0 Then
            Dim nextForm As New ICmain()
            nextForm.ReceivedId = newId ' IDを渡す
            ICmain.Show()
            Me.Hide()
        End If
    End Sub
End Class