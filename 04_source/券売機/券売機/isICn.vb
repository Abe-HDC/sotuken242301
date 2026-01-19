Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class isICn

    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Const cardType As Integer = 5     'カードタイプ

    Private Sub Nbtn_Click(sender As Object, e As EventArgs) Handles Nbtn.Click

        '変数の宣言
        Dim data() As Byte        '読込データバッファ
        Dim dataLength As Integer   '読込データサイズ
        Dim id(32) As Byte          'カードID
        Dim idLength As Integer     'カードIDサイズ
        Dim cardType As Integer     'カードタイプ
        Dim idString As String = ""      'カードID文字列
        Dim dataString As String = ""    '結果文字列
        Dim result As Integer
        Dim sei As String = nametxt.Text '名前
        Dim seinen As String = nameDTP.Value.ToString("yyyy/MM/dd")


        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        'Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"INSERT INTO iccard(name,seinen) VALUES ('{sei}','{seinen}'); SELECT LAST_INSERT_ID();"
        'SQLを実行
        'DataReader = Command.ExecuteReader
        Dim newId As Integer = Convert.ToInt32(Command.ExecuteScalar())

        dataString = sei & "," & seinen


        '書込データを作成
        data = System.Text.Encoding.Unicode.GetBytes(dataString)
        dataLength = data.Length

        'データ書込み
        idLength = id.Length
        result = OTWriteData(data(0), dataLength, id(0), idLength, cardType)


        'クローズ
        'DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        '結果表示
        If result = 0 Then
            Dim nextForm As New isIC()
            nextForm.ReceivedId = newId  ' IDを渡す
            nextForm.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        isICt.Show()
        Me.Hide()
    End Sub
End Class