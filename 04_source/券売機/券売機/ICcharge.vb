Imports MySql.Data.MySqlClient

Public Class ICcharge
    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Const cardType As Integer = 5     'カードタイプ

    Public Property ReceivedId As String



    Private Sub ICcharge_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' 画面の作業領域（タスクバーを除く）
        Dim wa = Screen.PrimaryScreen.WorkingArea

        ' 幅と高さを 1/4 に
        Me.Width = wa.Width \ 2
        Me.Height = wa.Height \ 2

        ' 左上に配置
        Me.Left = wa.Left
        Me.Top = wa.Top
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
        Command.CommandText = $"SELECT bal FROM iccard WHERE ICno = {ReceivedId}"
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
        '    MessageBox.Show("受け渡し完了")
        '    'Dim nextForm As New ICpay()
        '    'nextForm.ReceivedId = ReceivedId ' IDを渡す
        'End If
    End Sub

    Private Sub ch1000_Click(sender As Object, e As EventArgs) Handles ch1000.Click
        '変数の宣言
        Dim data(40) As Byte        '読込データバッファ
        'Dim dataLength As Integer   '読込データサイズ
        Dim id(10) As Byte          'カードID
        'Dim idLength As Integer     'カードIDサイズ
        'Dim cardType As Integer     'カードタイプ
        Dim idString As String = ""      'カードID文字列
        Dim dataString As String = ""    '結果文字列
        Dim result As Integer

        Dim ch As Integer = 1000

        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"UPDATE iccard SET bal = bal + {ch} WHERE ICno = '{ReceivedId}'"
        'SQLを実行
        DataReader = Command.ExecuteReader



        ''書込データを作成
        'data = System.Text.Encoding.Unicode.GetBytes(dataString)
        'dataLength = data.Length

        ''データ書込み
        'result = OTWriteData(data(0), dataLength, id(0), idLength, cardType)


        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        '結果表示
        If result = 0 Then
            Dim nextForm As New ICpay()
            nextForm.ReceivedId = ReceivedId ' IDを渡す
            nextForm.ReceivedCharge = ch
            nextForm.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub ch2000_Click(sender As Object, e As EventArgs) Handles ch2000.Click
        '変数の宣言
        Dim data(40) As Byte        '読込データバッファ
        'Dim dataLength As Integer   '読込データサイズ
        Dim id(10) As Byte          'カードID
        'Dim idLength As Integer     'カードIDサイズ
        'Dim cardType As Integer     'カードタイプ
        Dim idString As String = ""      'カードID文字列
        Dim dataString As String = ""    '結果文字列
        Dim result As Integer

        Dim ch As Integer = 2000

        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"UPDATE iccard SET bal = bal + {ch} WHERE ICno = '{ReceivedId}'"
        'SQLを実行
        DataReader = Command.ExecuteReader



        ''書込データを作成
        'data = System.Text.Encoding.Unicode.GetBytes(dataString)
        'dataLength = data.Length

        ''データ書込み
        'result = OTWriteData(data(0), dataLength, id(0), idLength, cardType)


        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        '結果表示
        If result = 0 Then
            Dim nextForm As New ICpay()
            nextForm.ReceivedId = ReceivedId ' IDを渡す
            nextForm.ReceivedCharge = ch
            nextForm.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub ch3000_Click(sender As Object, e As EventArgs) Handles ch3000.Click
        '変数の宣言
        Dim data(40) As Byte        '読込データバッファ
        'Dim dataLength As Integer   '読込データサイズ
        Dim id(10) As Byte          'カードID
        'Dim idLength As Integer     'カードIDサイズ
        'Dim cardType As Integer     'カードタイプ
        Dim idString As String = ""      'カードID文字列
        Dim dataString As String = ""    '結果文字列
        Dim result As Integer

        Dim ch As Integer = 3000

        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"UPDATE iccard SET bal = bal + {ch} WHERE ICno = '{ReceivedId}'"
        'SQLを実行
        DataReader = Command.ExecuteReader



        ''書込データを作成
        'data = System.Text.Encoding.Unicode.GetBytes(dataString)
        'dataLength = data.Length

        ''データ書込み
        'result = OTWriteData(data(0), dataLength, id(0), idLength, cardType)


        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        '結果表示
        If result = 0 Then
            Dim nextForm As New ICpay()
            nextForm.ReceivedId = ReceivedId ' IDを渡す
            nextForm.ReceivedCharge = ch
            nextForm.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub ch4000_Click(sender As Object, e As EventArgs) Handles ch4000.Click
        '変数の宣言
        Dim data(40) As Byte        '読込データバッファ
        'Dim dataLength As Integer   '読込データサイズ
        Dim id(10) As Byte          'カードID
        'Dim idLength As Integer     'カードIDサイズ
        'Dim cardType As Integer     'カードタイプ
        Dim idString As String = ""      'カードID文字列
        Dim dataString As String = ""    '結果文字列
        Dim result As Integer

        Dim ch As Integer = 4000

        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"UPDATE iccard SET bal = bal + {ch} WHERE ICno = '{ReceivedId}'"
        'SQLを実行
        DataReader = Command.ExecuteReader



        ''書込データを作成
        'data = System.Text.Encoding.Unicode.GetBytes(dataString)
        'dataLength = data.Length

        ''データ書込み
        'result = OTWriteData(data(0), dataLength, id(0), idLength, cardType)


        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        '結果表示
        If result = 0 Then
            Dim nextForm As New ICpay()
            nextForm.ReceivedId = ReceivedId ' IDを渡す
            nextForm.ReceivedCharge = ch
            nextForm.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub ch5000_Click(sender As Object, e As EventArgs) Handles ch5000.Click
        '変数の宣言
        Dim data(40) As Byte        '読込データバッファ
        'Dim dataLength As Integer   '読込データサイズ
        Dim id(10) As Byte          'カードID
        'Dim idLength As Integer     'カードIDサイズ
        'Dim cardType As Integer     'カードタイプ
        Dim idString As String = ""      'カードID文字列
        Dim dataString As String = ""    '結果文字列
        Dim result As Integer

        Dim ch As Integer = 5000

        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"UPDATE iccard SET bal = bal + {ch} WHERE ICno = '{ReceivedId}'"
        'SQLを実行
        DataReader = Command.ExecuteReader



        ''書込データを作成
        'data = System.Text.Encoding.Unicode.GetBytes(dataString)
        'dataLength = data.Length

        ''データ書込み
        'result = OTWriteData(data(0), dataLength, id(0), idLength, cardType)


        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        '結果表示
        If result = 0 Then
            Dim nextForm As New ICpay()
            nextForm.ReceivedId = ReceivedId ' IDを渡す
            nextForm.ReceivedCharge = ch
            nextForm.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub ch10000_Click(sender As Object, e As EventArgs) Handles ch10000.Click
        '変数の宣言
        Dim data(40) As Byte        '読込データバッファ
        'Dim dataLength As Integer   '読込データサイズ
        Dim id(10) As Byte          'カードID
        'Dim idLength As Integer     'カードIDサイズ
        'Dim cardType As Integer     'カードタイプ
        Dim idString As String = ""      'カードID文字列
        Dim dataString As String = ""    '結果文字列
        Dim result As Integer

        Dim ch As Integer = 10000

        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"UPDATE iccard SET bal = bal + {ch} WHERE ICno = {ReceivedId}"
        'SQLを実行
        DataReader = Command.ExecuteReader



        ''書込データを作成
        'data = System.Text.Encoding.Unicode.GetBytes(dataString)
        'dataLength = data.Length

        ''データ書込み
        'result = OTWriteData(data(0), dataLength, id(0), idLength, cardType)


        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        '結果表示
        If result = 0 Then
            Dim nextForm As New ICpay()
            nextForm.ReceivedId = ReceivedId ' IDを渡す
            nextForm.ReceivedCharge = ch
            nextForm.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        ICmain.Show()
        Me.Hide()
    End Sub
End Class