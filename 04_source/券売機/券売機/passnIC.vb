Imports MySql.Data.MySqlClient

Public Class passnIC
    ' --- API定義はそのまま ---
    Private Declare Function GetCardIDIndex Lib "OrangeOneStopEasyAPI.dll" (ByRef id As Byte, ByRef length As Integer, ByVal index As Integer) As Integer

    ' --- 変数宣言 ---
    Dim idString As String = ""
    Const cardType As Integer = 5

    ' 【必須】バイト配列を16進数文字列に変換する関数
    ' これがないと idString が正しく作られず、照合に失敗します
    Private Function ByteArrayToHexString(ByVal ba As Byte(), ByVal len As Integer) As String
        Dim sb As New System.Text.StringBuilder()
        For i As Integer = 0 To len - 1
            sb.Append(ba(i).ToString("X2"))
        Next
        Return sb.ToString()
    End Function

    Private Function ReadStart(ByVal reader As Integer) As Integer
        Dim id(10) As Byte
        Dim length As Integer
        Return GetCardIDIndex(id(0), length, reader)
    End Function

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim id(10) As Byte
        Dim length As Integer

        ' 1. カード読み取り
        If GetCardIDIndex(id(0), length, 0) = 0 Then
            Timer1.Enabled = False

            ' 2. カードの物理IDを文字列として取得（オーバーフロー回避）
            Dim currentCardId As String = ByteArrayToHexString(id, length)

            Using Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
                Try
                    Connection.Open()

                    ' 3. 登録済みかチェック（caredidは文字列型カラムである前提）
                    Dim sql As String = "SELECT ICno FROM iccard WHERE caredid = @cid"
                    Dim Command As New MySqlCommand(sql, Connection)
                    Command.Parameters.AddWithValue("@cid", currentCardId)

                    Dim result = Command.ExecuteScalar()

                    If result Is Nothing OrElse result Is DBNull.Value Then
                        Dim regForm As New pass()
                        ' String型として渡す
                        regForm.ReceivedId = currentCardId
                        regForm.Show()
                        Me.Hide()
                        'Else
                        '    ' 【登録済み】
                        '    ' ICno（連番）は小さい数値なので Integer に変換可能
                        '    Dim foundId As Integer = Convert.ToInt32(result)

                        '    Dim nextForm As New pass() ' または遷移先のフォーム
                        '    nextForm.ReceivedId = foundId
                        '    nextForm.Show()
                        '    Me.Hide()
                    End If

                Catch ex As Exception
                    MessageBox.Show("DBエラー: " & ex.Message)
                    Timer1.Enabled = True
                End Try
            End Using
        End If
    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        passn.Show()
        Me.Hide()
    End Sub
End Class