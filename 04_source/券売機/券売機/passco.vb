Imports MySql.Data.MySqlClient

Public Class passco
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

    ' バイト配列を16進数文字列に変換する関数（必須）
    Private Function ByteArrayToHexString(ByVal ba As Byte(), ByVal len As Integer) As String
        Dim sb As New System.Text.StringBuilder()
        For i As Integer = 0 To len - 1
            sb.Append(ba(i).ToString("X2"))
        Next
        Return sb.ToString()
    End Function

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        ' 変数の準備
        Dim id(10) As Byte
        Dim length As Integer

        ' 1. カード読み取り実行
        If GetCardIDIndex(id(0), length, 0) = 0 Then
            Timer1.Enabled = False

            ' 2. バイト配列を文字列（16進数）に変換
            idString = ByteArrayToHexString(id, length)

            Dim Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            Try
                Connection.Open()

                ' 3. カードID（caredid）を使って最新の登録情報を取得するSQL
                ' パラメータ（@cid）を使うことでエラーを防ぎます
                Dim sql As String = "SELECT ICno FROM iccard WHERE caredid = @cid ORDER BY ICno DESC LIMIT 1"
                Dim Command As New MySqlCommand(sql, Connection)
                Command.Parameters.AddWithValue("@cid", idString)

                ' 実行
                Dim result = Command.ExecuteScalar()

                If result IsNot Nothing Then
                    ' 登録があった場合：そのICnoを次のフォームに渡す
                    Dim foundId As Integer = Convert.ToInt32(result)

                    Dim nextForm As New passcopay()
                    nextForm.ReceivedId = foundId
                    nextForm.Show()
                    Me.Hide()
                Else
                    ' 登録がなかった場合
                    MessageBox.Show("このカードは登録されていません。")
                    Timer1.Enabled = True
                End If

            Catch ex As Exception
                MessageBox.Show("DBエラー: " & ex.Message)
                Timer1.Enabled = True
            Finally
                Connection.Close()
            End Try
        End If
    End Sub
    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        passn.Show()
        Me.Hide()
    End Sub
End Class