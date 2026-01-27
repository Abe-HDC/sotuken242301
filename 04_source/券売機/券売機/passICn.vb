Imports MySql.Data.MySqlClient

Public Class passICn

    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Const cardType As Integer = 5     'カードタイプ

    Public Property ReceivedId As Integer

    Private Sub passICn_Load(sender As Object, e As EventArgs) Handles Me.Load
        '変数の宣言
        Dim data(40) As Byte        '読込データバッファ
        'Dim dataLength As Integer   '読込データサイズ
        Dim id(10) As Byte          'カードID
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
        Command.CommandText = $"SELECT name,seinen FROM iccard WHERE ICno = {ReceivedId}"
        'SQLを実行
        DataReader = Command.ExecuteReader


        ''書込データを作成
        'data = System.Text.Encoding.Unicode.GetBytes(dataString)
        'dataLength = data.Length

        ''データ書込み
        'result = OTWriteData(data(0), dataLength, id(0), idLength, cardType)

        If DataReader.Read() Then

            nametxt.Text = DataReader("name").ToString()

            nameDTP.Text = DataReader("seinen").ToString()

        End If


        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()
    End Sub

    Private Sub Nbtn_Click(sender As Object, e As EventArgs) Handles Nbtn.Click
        '変数の宣言
        'Dim data() As Byte        '読込データバッファ
        'Dim dataLength As Integer   '読込データサイズ
        Dim id(32) As Byte          'カードID
        'Dim idLength As Integer     'カードIDサイズ
        'Dim cardType As Integer     'カードタイプ
        Dim idString As String = ""      'カードID文字列
        Dim dataString As String = ""    '結果文字列
        Dim result As Integer

        'Dim sei As String = nametxt.Text
        'Dim seinen As String = nameDTP.Value.ToString("yyyy/MM/dd")
        Dim std As String = stDTP.Value.ToString("yyyy/MM/dd")
        Dim endd As String = endDTP.Value.ToString("yyyy/MM/dd")
        Dim mont As Integer
        Dim de As String = deComboBox.Text
        Dim ar As String = arComboBox.Text
        Dim ge As Integer = 1
        Dim stdate As Date = DateTime.Today



        If Rad1m.Checked Then
            mont = Rad1m.Tag
        End If

        If Rad3m.Checked Then
            mont = Rad3m.Tag
        End If

        If Rad6m.Checked Then
            mont = Rad6m.Tag
        End If


        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"UPDATE iccard SET stday = '{std}',endday = '{endd}',depass = '{de}',arpass = '{ar}',gepass = {ge},month = {mont} WHERE ICno = {ReceivedId}"
        'SQLを実行
        DataReader = Command.ExecuteReader
        'Dim newId As Integer = Convert.ToInt32(Command.ExecuteScalar())

        'dataString = std & "," & endd & "," & mont & "," & de & "," & ar & "," & ge & "," & stdate


        ''書込データを作成
        'data = System.Text.Encoding.Unicode.GetBytes(dataString)
        'dataLength = data.Length

        ''データ書込み
        'idLength = id.Length
        'result = OTWriteData(data(0), dataLength, id(0), idLength, cardType)


        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        '結果表示
        If result = 0 Then
            Dim nextForm As New passICFe()
            nextForm.ReceivedId = ReceivedId  ' IDを渡す
            nextForm.Show()
            Me.Hide()
        End If
    End Sub
    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        passIC.Show()
        Me.Hide()
    End Sub


End Class