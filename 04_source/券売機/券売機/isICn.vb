Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class isICn

    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Const cardType As Integer = 5     'カードタイプ

    'Private Sub Nbtn_Click(sender As Object, e As EventArgs) Handles Nbtn.Click

    '    '変数の宣言
    '    Dim data() As Byte        '読込データバッファ
    '    Dim dataLength As Integer   '読込データサイズ
    '    Dim id(32) As Byte          'カードID
    '    Dim idLength As Integer     'カードIDサイズ
    '    Dim cardType As Integer     'カードタイプ
    '    Dim idString As String = ""      'カードID文字列
    '    Dim dataString As String = ""    '結果文字列
    '    Dim result As Integer
    '    Dim sei As String = nametxt.Text '名前
    '    Dim seinen As String = nameDTP.Value.ToString("yyyy/MM/dd")


    '    Dim Connection As New MySqlConnection
    '    Dim Command As MySqlCommand
    '    Dim DataReader As MySqlDataReader

    '    '接続文字列の設定
    '    Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

    '    'オープン
    '    Connection.Open()

    '    Command = Connection.CreateCommand
    '    Command.CommandText = $"INSERT INTO iccard(name,seinen) VALUES ('{sei}','{seinen}');"
    '    'SQLを実行
    '    DataReader = Command.ExecuteReader


    '    dataString = sei & "," & seinen


    '    '書込データを作成
    '    data = System.Text.Encoding.Unicode.GetBytes(dataString)
    '    dataLength = data.Length

    '    'データ書込み
    '    idLength = id.Length
    '    result = OTWriteData(data(0), dataLength, id(0), idLength, cardType)


    '    'クローズ
    '    DataReader.Close()
    '    Connection.Close()

    '    'Dispose
    '    Command.Dispose()
    '    Connection.Dispose()

    '    '結果表示
    '    If result = 0 Then
    '        Dim nextForm As New isIC()
    '        nextForm.ReceivedId = newId  ' IDを渡す
    '        nextForm.Show()
    '        Me.Hide()
    '    End If

    'End Sub

    'Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
    '    isICt.Show()
    '    Me.Hide()
    'End Sub

    ' バイト配列を16進数文字列に変換する関数（クラス内に追加してください）
    Private Function ByteArrayToHexString(ByVal ba As Byte(), ByVal len As Integer) As String
        Dim sb As New System.Text.StringBuilder()
        For i As Integer = 0 To len - 1
            sb.Append(ba(i).ToString("X2"))
        Next
        Return sb.ToString()
    End Function

    Private Sub Nbtn_Click(sender As Object, e As EventArgs) Handles Nbtn.Click
        ' --- 変数宣言 ---
        Dim data() As Byte
        Dim dataLength As Integer
        Dim id(32) As Byte
        Dim idLength As Integer = id.Length
        Dim result As Integer
        Dim sei As String = nametxt.Text
        Dim seinen As String = nameDTP.Value.ToString("yyyy/MM/dd")

        ' --- 1. ICカードへのデータ書き込み ---
        Dim dataString As String = sei & "," & seinen
        data = System.Text.Encoding.Unicode.GetBytes(dataString)
        dataLength = data.Length

        ' ここでカードに書き込みつつ、id配列にカードの識別番号を取得します
        result = OTWriteData(data(0), dataLength, id(0), idLength, cardType)

        If result <> 0 Then
            MessageBox.Show("カードの書き込みに失敗しました。")
            Exit Sub
        End If

        ' --- 2. カードの物理IDを文字列に変換 ---
        Dim cardIdStr As String = ByteArrayToHexString(id, idLength)

        ' --- 3. データベースへの保存処理 ---
        Dim connStr As String = "Database=sotuken242301;Data Source=localhost;User Id=root"

        Using connection As New MySqlConnection(connStr)
            Try
                connection.Open()

                ' card_idカラムも一緒に保存するSQL
                Dim sql As String = "INSERT INTO iccard(name, seinen ,caredid) VALUES (@name, @seinen, @caredid); SELECT LAST_INSERT_ID();"

                Using command As New MySqlCommand(sql, connection)
                    command.Parameters.AddWithValue("@name", sei)
                    command.Parameters.AddWithValue("@seinen", seinen)
                    command.Parameters.AddWithValue("@caredid", cardIdStr)


                    ' 新しく採番されたID（newId）を取得
                    Dim newId As Integer = Convert.ToInt32(command.ExecuteScalar())

                    ' --- 4. 画面遷移 ---
                    Dim nextForm As New isIC()
                    ' フォーム間で値を渡すために isIC 側に Public Property ReceivedId As Integer が必要です
                    nextForm.ReceivedId = newId
                    nextForm.Show()
                    Me.Hide()
                End Using

            Catch ex As Exception
                MessageBox.Show("DBエラー: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub isICn_Load(sender As Object, e As EventArgs) Handles Me.Load
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