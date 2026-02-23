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

    Dim newid As String
    Dim ICid As Integer

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
    '        Dim Connection As New MySqlConnection
    '        Dim Command As MySqlCommand
    '        Dim DataReader As MySqlDataReader


    '        '接続文字列の設定
    '        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

    '        'オープン
    '        Connection.Open()

    '        Command = Connection.CreateCommand
    '        Command.CommandText = $" SELECT ICno,caredid FROM iccard WHERE caredid = '{idString}'"
    '        'SQLを実行
    '        DataReader = Command.ExecuteReader
    '        'Dim newId As Integer = Convert.ToInt32(Command.ExecuteScalar())

    '        If DataReader.Read() Then

    '            newid = DataReader("caredid").ToString()
    '            ICid = DataReader("ICno").ToString()

    '        End If

    '        'クローズ
    '        DataReader.Close()
    '        Connection.Close()

    '        'Dispose
    '        Command.Dispose()
    '        Connection.Dispose()
    '        Dim nextForm As New ICmain()
    '        nextForm.ReceivedId = newid ' IDを渡す
    '        nextForm.ICid = ICid
    '        nextForm.Show()
    '        Me.Hide()
    '    End If
    'End Sub

    ' バイト配列を16進数文字列に変換する関数
    Private Function ByteArrayToHexString(ByVal ba As Byte(), ByVal len As Integer) As String
        Dim sb As New System.Text.StringBuilder()
        For i As Integer = 0 To len - 1
            sb.Append(ba(i).ToString("X2"))
        Next
        Return sb.ToString()
    End Function

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        ' 1. カードを読み取る
        Dim id(10) As Byte
        Dim length As Integer
        If GetCardIDIndex(id(0), length, 0) = 0 Then
            Timer1.Enabled = False

            ' 2. バイト配列を文字列に変換（これがDBのcaredidと一致する）
            idString = ByteArrayToHexString(id, length)

            Dim Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            Try
                Connection.Open()
                ' 3. パラメータを使って検索（caredidは文字列として扱う）
                Dim sql As String = "SELECT ICno, caredid FROM iccard WHERE caredid = @cardid"
                Dim Command As New MySqlCommand(sql, Connection)
                Command.Parameters.AddWithValue("@cardid", idString)

                Dim DataReader As MySqlDataReader = Command.ExecuteReader

                If DataReader.Read() Then
                    ' 一致するカードが見つかった場合
                    newid = DataReader("caredid").ToString()
                    ICid = Convert.ToInt32(DataReader("ICno"))

                    ' 画面遷移
                    Dim nextForm As New ICmain()
                    nextForm.ReceivedId = newid
                    nextForm.ICId = ICid
                    nextForm.Show()
                    Me.Hide()
                Else
                    ' カードが登録されていなかった場合
                    MessageBox.Show("このカードは登録されていません。")
                    Timer1.Enabled = True ' 再度読み取りを許可
                End If

                DataReader.Close()
            Catch ex As Exception
                MessageBox.Show("DBエラー: " & ex.Message)
                Timer1.Enabled = True
            Finally
                Connection.Close()
            End Try
        End If
    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        mainf.Show()
        Me.Hide()
    End Sub

    Private Sub IC_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' 画面の作業領域（タスクバーを除く）
        Dim wa = Screen.PrimaryScreen.WorkingArea

        ' 幅と高さを 1/4 に
        Me.Width = wa.Width \ 2
        Me.Height = wa.Height \ 2

        ' 左上に配置
        Me.Left = wa.Left
        Me.Top = wa.Top
    End Sub
End Class