'Imports System.Data.Common
'Imports System.DirectoryServices.ActiveDirectory
'Imports System.Runtime.InteropServices
'Imports MySql.Data.MySqlClient
'Imports Org.BouncyCastle.Asn1

'Public Class gateend
'    'Orange Tags Easy APIの定義
'    Private Declare Function GetCardIDIndex Lib "OrangeOneStopEasyAPI.dll" (ByRef id As Byte, ByRef length As Integer, ByVal index As Integer) As Integer
'    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
'    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer

'    '変数の宣言
'    Dim data(47) As Byte            '読込データバッファ
'    Dim dataLength As Integer       '読込データサイズ
'    Dim id(10) As Byte              'カードID
'    Dim idLength As Integer         'カードIDサイズ
'    Dim idString As String = ""     'カードID文字列
'    Dim dataString As String = ""   '結果文字列
'    Dim result As Integer           '読書き結果
'    Const cardType As Integer = 5   'カードタイプ

'    Dim newid As String
'    Dim ICid As Integer

'    'Dim stname As String = "高崎"
'    Public Property ruoteid As Integer
'    Public Property stationid As Integer

'    Dim rdepoid As Integer = 0
'    Dim sdepoid As Integer = 0

'    'Dim endname As String = "新前橋"
'    'Dim depo As String = ""

'    Dim post As Integer
'    Dim poend As Integer

'    Dim point As Integer

'    Dim fare As Integer = 0

'    Dim pay As Integer

'    Private Function ByteArrayToHexString(ByVal ba As Byte(), ByVal len As Integer) As String
'        Dim sb As New System.Text.StringBuilder()
'        For i As Integer = 0 To len - 1
'            sb.Append(ba(i).ToString("X2"))
'        Next
'        Return sb.ToString()
'    End Function

'    'Private Function ReadStart(ByVal reader As Integer) As Integer
'    '    '変数の宣言
'    '    Dim id(10) As Byte
'    '    Dim length As Integer
'    '    Dim Ret As Integer = GetCardIDIndex(id(0), length, reader)
'    '    Return Ret
'    'End Function
'    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
'        'If ReadStart(0) = 0 Then
'        '    Timer1.Enabled = False
'        '    Dim Connection As New MySqlConnection
'        '    Dim Command As MySqlCommand
'        '    'Dim DataReader As MySqlDataReader


'        '    '接続文字列の設定
'        '    Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

'        '    'オープン
'        '    Connection.Open()

'        '    Command = Connection.CreateCommand
'        '    Command.CommandText = $" SELECT MAX(ICno) FROM iccard"
'        '    'SQLを実行
'        '    'DataReader = Command.ExecuteReader
'        '    newId = Convert.ToInt32(Command.ExecuteScalar())

'        '    'Station()

'        '    CheckDepoStatus()

'        '    If 0 = rdepoid Then
'        '        ProcessExit()
'        '    Else
'        '        Processst()
'        '        Processend()

'        '        If post < poend Then
'        '            point = poend - post
'        '        Else
'        '            point = post - poend
'        '        End If

'        '        Keisan()
'        '        Balkeisan()
'        '    End If

'        '    'クローズ
'        '    'DataReader.Close()
'        '    Connection.Close()

'        '    'Dispose
'        '    Command.Dispose()
'        '    Connection.Dispose()


'        '    Dim nextForm As New gate()
'        '    nextForm.ReceivedId = newId ' IDを渡す
'        '    nextForm.pay = fare
'        '    nextForm.Show()
'        '    Me.Hide()
'        'End If

'        ' 1. カードを読み取る
'        Dim id(10) As Byte
'        Dim length As Integer
'        If GetCardIDIndex(id(0), length, 0) = 0 Then
'            Timer1.Enabled = False

'            ' 2. バイト配列を文字列に変換（これがDBのcaredidと一致する）
'            idString = ByteArrayToHexString(id, length)

'            Dim Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
'            Try
'                Connection.Open()
'                ' 3. パラメータを使って検索（caredidは文字列として扱う）
'                Dim sql As String = "SELECT ICno, caredid FROM iccard WHERE caredid = @cardid"
'                Dim Command As New MySqlCommand(sql, Connection)
'                Command.Parameters.AddWithValue("@cardid", idString)

'                Dim DataReader As MySqlDataReader = Command.ExecuteReader

'                If DataReader.Read() Then
'                    ' 一致するカードが見つかった場合
'                    newId = DataReader("caredid").ToString()
'                    ICid = Convert.ToInt32(DataReader("ICno"))

'                    CheckDepoStatus()

'                    If 0 = rdepoid Then
'                        ProcessExit()
'                    Else
'                        'Balkeisan()
'                    End If

'                    ' 画面遷移
'                    Dim nextForm As New gate()
'                    nextForm.ReceivedId = newid
'                    nextForm.ICId = ICid
'                    nextForm.Show()
'                    Me.Hide()
'                Else
'                    ' カードが登録されていなかった場合
'                    MessageBox.Show("このカードは登録されていません。")
'                    Timer1.Enabled = True ' 再度読み取りを許可
'                End If

'                DataReader.Close()
'            Catch ex As Exception
'                MessageBox.Show("DBエラー: " & ex.Message)
'                Timer1.Enabled = True
'            Finally
'                Connection.Close()
'            End Try
'        End If


'    End Sub

'    Private Sub ProcessExit()
'        Dim Connection As New MySqlConnection
'        Dim Command As MySqlCommand
'        Dim DataReader As MySqlDataReader


'        '接続文字列の設定
'        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

'        'オープン
'        Connection.Open()

'        Command = Connection.CreateCommand
'        Command.CommandText = $" UPDATE iccard SET ruoteiddapo = {ruoteid},stationiddapo = {stationid} WHERE ICno = {ICid}"
'        'SQLを実行
'        DataReader = Command.ExecuteReader

'        'クローズ
'        DataReader.Close()
'        Connection.Close()

'        'Dispose
'        Command.Dispose()
'        Connection.Dispose()
'    End Sub

'    Private Sub CheckDepoStatus()
'        Dim Connection As New MySqlConnection
'        Dim Command As MySqlCommand
'        Dim DataReader As MySqlDataReader


'        '接続文字列の設定
'        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

'        'オープン
'        Connection.Open()

'        Command = Connection.CreateCommand
'        Command.CommandText = $" SELECT ruoteiddapo,stationiddapo FROM iccard WHERE ICno = {ICid}"
'        'SQLを実行
'        DataReader = Command.ExecuteReader

'        If DataReader.Read() Then

'            rdepoid = DataReader("ruoteiddapo").ToString()
'            sdepoid = DataReader("stationiddapo").ToString()

'        End If


'        'クローズ
'        DataReader.Close()
'        Connection.Close()

'        'Dispose
'        Command.Dispose()
'        Connection.Dispose()
'    End Sub

'    Private Sub Balkeisan()
'        Dim Connection As New MySqlConnection
'        Dim Command As MySqlCommand
'        Dim DataReader As MySqlDataReader

'        point = post - poend


'        '接続文字列の設定
'        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

'        'オープン
'        Connection.Open()

'        Command = Connection.CreateCommand
'        Command.CommandText = $"UPDATE iccard SET bal = bal - {fare},ruoteiddapo = 0,stationiddapo = 0 WHERE ICno={newId}"
'        'SQLを実行
'        DataReader = Command.ExecuteReader

'        'クローズ
'        DataReader.Close()
'        Connection.Close()

'        'Dispose
'        Command.Dispose()
'        Connection.Dispose()
'    End Sub

'End Class

'Imports System.Data.Common
'Imports System.DirectoryServices.ActiveDirectory
'Imports System.Runtime.InteropServices
'Imports MySql.Data.MySqlClient
'Imports Org.BouncyCastle.Asn1
'Imports System.Text

'Public Class gateend
'    'Orange Tags Easy APIの定義
'    Private Declare Function GetCardIDIndex Lib "OrangeOneStopEasyAPI.dll" (ByRef id As Byte, ByRef length As Integer, ByVal index As Integer) As Integer

'    '変数の宣言
'    Dim newid As String
'    Dim ICid As Integer

'    '現在の駅（改札機が設置されている駅）
'    Public Property ruoteid As Integer
'    Public Property stationid As Integer

'    '入場駅の情報（カードから取得）
'    Dim rdepoid As Integer = 0
'    Dim sdepoid As Integer = 0

'    Dim fare As Integer = 0

'    Private Function ByteArrayToHexString(ByVal ba As Byte(), ByVal len As Integer) As String
'        Dim sb As New System.Text.StringBuilder()
'        For i As Integer = 0 To len - 1
'            sb.Append(ba(i).ToString("X2"))
'        Next
'        Return sb.ToString()
'    End Function

'    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
'        ' 1. カードを読み取る
'        Dim id(10) As Byte
'        Dim length As Integer

'        ' カード読み取り成功時
'        If GetCardIDIndex(id(0), length, 0) = 0 Then
'            Timer1.Enabled = False ' 処理中はタイマー停止

'            Dim idString As String = ByteArrayToHexString(id, length)
'            Dim Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")

'            Try
'                Connection.Open()
'                ' カードIDからユーザー情報を取得
'                Dim sql As String = "SELECT ICno, caredid FROM iccard WHERE caredid = @cardid"
'                Dim Command As New MySqlCommand(sql, Connection)
'                Command.Parameters.AddWithValue("@cardid", idString)

'                Dim DataReader As MySqlDataReader = Command.ExecuteReader

'                If DataReader.Read() Then
'                    ' --- カード登録あり ---
'                    newid = DataReader("caredid").ToString()
'                    ICid = Convert.ToInt32(DataReader("ICno"))
'                    DataReader.Close() ' 次の処理のために閉じる

'                    ' 入場状態を確認
'                    CheckDepoStatus()

'                    If rdepoid = 0 Then
'                        ' --- 入場記録がない場合（これから入場） ---
'                        ' 現在の駅を入場駅として記録する（メソッド名はProcessExitだが中身はUPDATE）
'                        ProcessEntry()
'                        'MessageBox.Show("入場しました。")

'                        ' 画面遷移（必要なら）
'                        Me.Hide()
'                        Dim nextForm As New gate()
'                        nextForm.ReceivedId = newid
'                        nextForm.ICId = ICid
'                        nextForm.Show()

'                    Else
'                        ' --- 入場記録がある場合（出場・運賃精算） ---

'                        ' 0～3回乗り換えの最安運賃を計算
'                        fare = CalculateBestFare()

'                        If fare = -1 Then
'                            MessageBox.Show("経路が見つかりません、または運賃計算エラーです。")
'                        Else
'                            ' 残高更新と入場記録消去
'                            If Balkeisan() Then
'                                ' 画面遷移
'                                Dim nextForm As New gate()
'                                nextForm.ReceivedId = newid
'                                nextForm.ICId = ICid
'                                nextForm.pay = fare ' 支払い額を渡す
'                                nextForm.Show()
'                                Me.Hide()
'                            End If
'                        End If
'                    End If

'                Else
'                    ' --- カード登録なし ---
'                    MessageBox.Show("このカードは登録されていません。")
'                    Timer1.Enabled = True
'                End If

'                If Not DataReader.IsClosed Then DataReader.Close()

'            Catch ex As Exception
'                MessageBox.Show("DBエラー: " & ex.Message)
'                Timer1.Enabled = True
'            Finally
'                Connection.Close()
'            End Try
'        End If
'    End Sub

'    ' 入場処理（ProcessExitから改名推奨ですが、元のロジックを維持）
'    Private Sub ProcessEntry()
'        Using Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
'            Connection.Open()
'            Dim sql As String = $"UPDATE iccard SET ruoteiddapo = {ruoteid}, stationiddapo = {stationid} WHERE ICno = {ICid}"
'            Using Command As New MySqlCommand(sql, Connection)
'                Command.ExecuteNonQuery()
'            End Using
'        End Using
'    End Sub

'    ' 入場状態の確認
'    Private Sub CheckDepoStatus()
'        rdepoid = 0
'        sdepoid = 0
'        Using Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
'            Connection.Open()
'            Dim sql As String = $"SELECT ruoteiddapo, stationiddapo FROM iccard WHERE ICno = {ICid}"
'            Using Command As New MySqlCommand(sql, Connection)
'                Using DataReader As MySqlDataReader = Command.ExecuteReader()
'                    If DataReader.Read() Then
'                        Integer.TryParse(DataReader("ruoteiddapo").ToString(), rdepoid)
'                        Integer.TryParse(DataReader("stationiddapo").ToString(), sdepoid)
'                    End If
'                End Using
'            End Using
'        End Using
'    End Sub

'    ' 精算処理（残高引き落とし ＆ 入場フラグクリア）
'    'Private Function Balkeisan() As Boolean
'    '    Using Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
'    '        Connection.Open()

'    '        ' まず残高不足チェック（オプション）
'    '        Dim checkSql As String = $"SELECT bal FROM iccard WHERE ICno = {ICid}"
'    '        Dim currentBal As Integer = 0
'    '        Using cmdCheck As New MySqlCommand(checkSql, Connection)
'    '            currentBal = Convert.ToInt32(cmdCheck.ExecuteScalar())
'    '        End Using

'    '        If currentBal < fare Then
'    '            MessageBox.Show($"残高不足です。(残高:{currentBal}円, 運賃:{fare}円)")
'    '            Timer1.Enabled = True ' 再試行可能にする
'    '            Return False
'    '        End If

'    '        ' 引き落としと入場情報クリア
'    '        Dim sql As String = $"UPDATE iccard SET bal = bal - {fare}, ruoteiddapo = 0, stationiddapo = 0 WHERE ICno = {ICid}"
'    '        Using Command As New MySqlCommand(sql, Connection)
'    '            If Command.ExecuteNonQuery() > 0 Then
'    '                Return True
'    '            Else
'    '                Return False
'    '            End If
'    '        End Using
'    '    End Using
'    'End Function

'    ' 精算処理（残高引き落とし ＆ 入場フラグクリア ＆ 履歴保存）
'    Private Function Balkeisan() As Boolean
'        Using Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
'            Connection.Open()

'            ' 1. 現在の残高を確認
'            Dim checkSql As String = "SELECT bal FROM iccard WHERE ICno = @icno"
'            Dim currentBal As Integer = 0
'            Using cmdCheck As New MySqlCommand(checkSql, Connection)
'                cmdCheck.Parameters.AddWithValue("@icno", ICid)
'                currentBal = Convert.ToInt32(cmdCheck.ExecuteScalar())
'            End Using

'            If currentBal < fare Then
'                MessageBox.Show($"残高不足です。(残高:{currentBal}円, 運賃:{fare}円)")
'                Timer1.Enabled = True
'                Return False
'            End If

'            ' トランザクション開始
'            Dim transaction As MySqlTransaction = Connection.BeginTransaction()

'            Try
'                ' 2. 残高の引き落としと入場情報のクリア
'                Dim updateSql As String = "UPDATE iccard SET bal = bal - @fare, ruoteiddapo = 0, stationiddapo = 0 WHERE ICno = @icno"
'                Using cmdUpdate As New MySqlCommand(updateSql, Connection, transaction)
'                    cmdUpdate.Parameters.AddWithValue("@fare", fare)
'                    cmdUpdate.Parameters.AddWithValue("@icno", ICid)
'                    cmdUpdate.ExecuteNonQuery()
'                End Using

'                ' 3. 利用履歴（resume）の保存 [テーブル定義に合わせました]
'                ' bos = 入場駅名, gos = 出場駅名, reday = 日付
'                Dim historySql As String = "INSERT INTO resume (ICno, reday, bos, gos, fare) " &
'                                         "SELECT @icno, CURDATE(), " &
'                                         "(SELECT stationname FROM station WHERE ruoid = @rdep AND stationid = @sdep), " &
'                                         "(SELECT stationname FROM station WHERE ruoid = @rout AND stationid = @stat), " &
'                                         "@fare"

'                Using cmdHistory As New MySqlCommand(historySql, Connection, transaction)
'                    cmdHistory.Parameters.AddWithValue("@icno", ICid)
'                    cmdHistory.Parameters.AddWithValue("@rdep", rdepoid)    ' 入場路線ID
'                    cmdHistory.Parameters.AddWithValue("@sdep", sdepoid)    ' 入場駅ID
'                    cmdHistory.Parameters.AddWithValue("@rout", ruoteid)   ' 出場路線ID
'                    cmdHistory.Parameters.AddWithValue("@stat", stationid) ' 出場駅ID
'                    cmdHistory.Parameters.AddWithValue("@fare", fare)
'                    cmdHistory.ExecuteNonQuery()
'                End Using

'                transaction.Commit()
'                Return True

'            Catch ex As Exception
'                transaction.Rollback()
'                MessageBox.Show("履歴保存中にエラーが発生しました: " & ex.Message)
'                Return False
'            End Try
'        End Using
'    End Function

'    ' ★★★ 最も安い運賃を計算する関数（0,1,2,3回乗り換え全てを網羅） ★★★
'    Private Function CalculateBestFare() As Integer
'        Dim minFare As Integer = -1

'        ' 同じ駅の場合は0円
'        If rdepoid = ruoteid And sdepoid = stationid Then Return 0

'        Dim sb As New StringBuilder()

'        ' SQL全体を囲む（最小値を取得）
'        sb.AppendLine("SELECT MIN(合計IC運賃) FROM (")

'        ' --- 0. 乗り換えなし (同一路線内) ---
'        sb.AppendLine("SELECT ")
'        sb.AppendLine(" (IFNULL((SELECT fare FROM fareusu WHERE (CASE WHEN S_start.ruoid <= 3 THEN ABS(S_start.pointkm - S_end.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 1 LIMIT 1), 0) + ")
'        sb.AppendLine("  IFNULL((SELECT fare FROM fareusu WHERE (CASE WHEN S_start.ruoid = 4  THEN ABS(S_start.pointkm - S_end.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 2 LIMIT 1), 0)) AS 合計IC運賃")
'        sb.AppendLine("FROM station AS S_start, station AS S_end")
'        sb.AppendLine($"WHERE S_start.ruoid = {rdepoid} AND S_start.stationid = {sdepoid} AND S_end.ruoid = {ruoteid} AND S_end.stationid = {stationid} AND S_start.ruoid = S_end.ruoid")

'        sb.AppendLine("UNION ALL")

'        ' --- 1. 乗り換え1回 ---
'        sb.AppendLine("SELECT ")
'        sb.AppendLine(" (IFNULL((SELECT fare FROM fareusu WHERE (CASE WHEN S_start.ruoid <= 3 THEN ABS(S_start.pointkm - J1_s.pointkm) ELSE 0 END + CASE WHEN S_end.ruoid <= 3 THEN ABS(J1_e.pointkm - S_end.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 1 LIMIT 1), 0) + ")
'        sb.AppendLine("  IFNULL((SELECT fare FROM fareusu WHERE (CASE WHEN S_start.ruoid = 4  THEN ABS(S_start.pointkm - J1_s.pointkm) ELSE 0 END + CASE WHEN S_end.ruoid = 4  THEN ABS(J1_e.pointkm - S_end.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 2 LIMIT 1), 0)) AS 合計IC運賃")
'        sb.AppendLine("FROM station AS S_start, station AS S_end, bosr1 AS B1a, bosr2 AS B1b, station AS J1_s, station AS J1_e")
'        sb.AppendLine($"WHERE S_start.ruoid = {rdepoid} AND S_start.stationid = {sdepoid} AND S_end.ruoid = {ruoteid} AND S_end.stationid = {stationid}")
'        sb.AppendLine("AND ((B1a.ruoid = S_start.ruoid AND B1b.ruoid = S_end.ruoid AND J1_s.stationid = B1a.stationid AND J1_e.ruoid = B1b.ruoid AND J1_e.stationid = B1b.stationid)")
'        sb.AppendLine("  OR (B1b.ruoid = S_start.ruoid AND B1a.ruoid = S_end.ruoid AND J1_s.stationid = B1b.stationid AND J1_e.ruoid = B1a.ruoid AND J1_e.stationid = B1a.stationid))")
'        sb.AppendLine("AND J1_s.ruoid = S_start.ruoid AND J1_s.stationname = J1_e.stationname")

'        sb.AppendLine("UNION ALL")

'        ' --- 2. 乗り換え2回 ---
'        sb.AppendLine("SELECT ")
'        sb.AppendLine(" (IFNULL((SELECT fare FROM fareusu WHERE (CASE WHEN S_start.ruoid <= 3 THEN ABS(S_start.pointkm - J1_s.pointkm) ELSE 0 END + CASE WHEN J1_e.ruoid <= 3 THEN ABS(J2_s.pointkm - J1_e.pointkm) ELSE 0 END + CASE WHEN S_end.ruoid <= 3 THEN ABS(J2_e.pointkm - S_end.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 1 LIMIT 1), 0) + ")
'        sb.AppendLine("  IFNULL((SELECT fare FROM fareusu WHERE (CASE WHEN S_start.ruoid = 4 THEN ABS(S_start.pointkm - J1_s.pointkm) ELSE 0 END + CASE WHEN J1_e.ruoid = 4 THEN ABS(J2_s.pointkm - J1_e.pointkm) ELSE 0 END + CASE WHEN S_end.ruoid = 4 THEN ABS(J2_e.pointkm - S_end.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 2 LIMIT 1), 0)) AS 合計IC運賃")
'        sb.AppendLine("FROM station AS S_start, station AS S_end, bosr1 AS B1a, bosr2 AS B1b, station AS J1_s, station AS J1_e, bosr1 AS B2a, bosr2 AS B2b, station AS J2_s, station AS J2_e")
'        sb.AppendLine($"WHERE S_start.ruoid = {rdepoid} AND S_start.stationid = {sdepoid} AND S_end.ruoid = {ruoteid} AND S_end.stationid = {stationid}")
'        ' 乗り換え1
'        sb.AppendLine("AND ((B1a.ruoid = S_start.ruoid AND B1b.ruoid <> S_start.ruoid AND J1_s.stationid = B1a.stationid AND J1_e.ruoid = B1b.ruoid AND J1_e.stationid = B1b.stationid) OR (B1b.ruoid = S_start.ruoid AND B1a.ruoid <> S_start.ruoid AND J1_s.stationid = B1b.stationid AND J1_e.ruoid = B1a.ruoid AND J1_e.stationid = B1a.stationid)) AND J1_s.ruoid = S_start.ruoid AND J1_s.stationname = J1_e.stationname")
'        ' 乗り換え2 (ゴールへ)
'        sb.AppendLine("AND ((B2a.ruoid = J1_e.ruoid AND B2b.ruoid = S_end.ruoid AND J2_s.stationid = B2a.stationid AND J2_e.ruoid = B2b.ruoid AND J2_e.stationid = B2b.stationid) OR (B2b.ruoid = J1_e.ruoid AND B2a.ruoid = S_end.ruoid AND J2_s.stationid = B2b.stationid AND J2_e.ruoid = B2a.ruoid AND J2_e.stationid = B2a.stationid)) AND J2_s.ruoid = J1_e.ruoid AND J2_s.stationname = J2_e.stationname")

'        sb.AppendLine("UNION ALL")

'        ' --- 3. 乗り換え3回 (提供されたSQLを組み込み) ---
'        sb.AppendLine("SELECT ")
'        sb.AppendLine(" (IFNULL((SELECT fare FROM fareusu WHERE (CASE WHEN S_start.ruoid <= 3 THEN ABS(S_start.pointkm - J1_s.pointkm) ELSE 0 END + CASE WHEN J1_e.ruoid <= 3 THEN ABS(J2_s.pointkm - J1_e.pointkm) ELSE 0 END + CASE WHEN J2_e.ruoid <= 3 THEN ABS(J3_s.pointkm - J2_e.pointkm) ELSE 0 END + CASE WHEN S_end.ruoid <= 3 THEN ABS(S_end.pointkm - J3_e.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 1 LIMIT 1), 0) + ")
'        sb.AppendLine("  IFNULL((SELECT fare FROM fareusu WHERE (CASE WHEN S_start.ruoid = 4 THEN ABS(S_start.pointkm - J1_s.pointkm) ELSE 0 END + CASE WHEN J1_e.ruoid = 4 THEN ABS(J2_s.pointkm - J1_e.pointkm) ELSE 0 END + CASE WHEN J2_e.ruoid = 4 THEN ABS(J3_s.pointkm - J2_e.pointkm) ELSE 0 END + CASE WHEN S_end.ruoid = 4 THEN ABS(S_end.pointkm - J3_e.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 2 LIMIT 1), 0)) AS 合計IC運賃")
'        sb.AppendLine("FROM station AS S_start, station AS S_end, bosr1 AS B1a, bosr2 AS B1b, station AS J1_s, station AS J1_e, bosr1 AS B2a, bosr2 AS B2b, station AS J2_s, station AS J2_e, bosr1 AS B3a, bosr2 AS B3b, station AS J3_s, station AS J3_e")
'        sb.AppendLine($"WHERE S_start.ruoid = {rdepoid} AND S_start.stationid = {sdepoid} AND S_end.ruoid = {ruoteid} AND S_end.stationid = {stationid}")
'        ' 乗り換え1
'        sb.AppendLine("AND ((B1a.ruoid = S_start.ruoid AND B1b.ruoid <> S_start.ruoid AND J1_s.stationid = B1a.stationid AND J1_e.ruoid = B1b.ruoid AND J1_e.stationid = B1b.stationid) OR (B1b.ruoid = S_start.ruoid AND B1a.ruoid <> S_start.ruoid AND J1_s.stationid = B1b.stationid AND J1_e.ruoid = B1a.ruoid AND J1_e.stationid = B1a.stationid)) AND J1_s.ruoid = S_start.ruoid AND J1_s.stationname = J1_e.stationname")
'        ' 乗り換え2
'        sb.AppendLine("AND ((B2a.ruoid = J1_e.ruoid AND B2b.ruoid <> J1_e.ruoid AND J2_s.stationid = B2a.stationid AND J2_e.ruoid = B2b.ruoid AND J2_e.stationid = B2b.stationid) OR (B2b.ruoid = J1_e.ruoid AND B2a.ruoid <> J1_e.ruoid AND J2_s.stationid = B2b.stationid AND J2_e.ruoid = B2a.ruoid AND J2_e.stationid = B2a.stationid)) AND J2_s.ruoid = J1_e.ruoid AND J2_s.stationname = J2_e.stationname")
'        ' 乗り換え3 (ゴールへ)
'        sb.AppendLine("AND ((B3a.ruoid = J2_e.ruoid AND B3b.ruoid = S_end.ruoid AND J3_s.stationid = B3a.stationid AND J3_e.ruoid = B3b.ruoid AND J3_e.stationid = B3b.stationid) OR (B3b.ruoid = J2_e.ruoid AND B3a.ruoid = S_end.ruoid AND J3_s.stationid = B3b.stationid AND J3_e.ruoid = B3a.ruoid AND J3_e.stationid = B3a.stationid)) AND J3_s.ruoid = J2_e.ruoid AND J3_s.stationname = J3_e.stationname")

'        sb.AppendLine(") AS AllRoutes")

'        Using Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
'            Connection.Open()
'            Dim Command As New MySqlCommand(sb.ToString(), Connection)
'            Dim result = Command.ExecuteScalar()

'            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
'                Return Convert.ToInt32(result)
'            Else
'                Return -1 ' 経路が見つからない場合
'            End If
'        End Using
'    End Function

'End Class

Imports System.Data.Common
Imports System.DirectoryServices.ActiveDirectory
Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Asn1
Imports System.Text

Public Class gateend
    'Orange Tags Easy APIの定義
    Private Declare Function GetCardIDIndex Lib "OrangeOneStopEasyAPI.dll" (ByRef id As Byte, ByRef length As Integer, ByVal index As Integer) As Integer

    '変数の宣言
    Dim newid As String
    Dim ICid As Integer

    '--- 定期券用変数 ---
    Dim gepass As Integer = 0
    Dim depass As String = ""
    Dim arpass As String = ""
    '-----------------------

    '現在の駅（改札機が設置されている駅）
    Public Property ruoteid As Integer
    Public Property stationid As Integer

    '入場駅の情報（カードから取得）
    Dim rdepoid As Integer = 0
    Dim sdepoid As Integer = 0

    Dim fare As Integer = 0

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

        ' カード読み取り成功時
        If GetCardIDIndex(id(0), length, 0) = 0 Then
            Timer1.Enabled = False ' 処理中はタイマー停止

            ' ★重要：変数の初期化（前回のデータが残らないようにリセット）
            gepass = 0
            depass = ""
            arpass = ""
            fare = 0

            Dim idString As String = ByteArrayToHexString(id, length)
            Dim Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")

            Try
                Connection.Open()
                ' カードIDからユーザー情報と定期情報を取得
                Dim sql As String = "SELECT ICno, caredid, gepass, depass, arpass FROM iccard WHERE caredid = @cardid"
                Dim Command As New MySqlCommand(sql, Connection)
                Command.Parameters.AddWithValue("@cardid", idString)

                Dim DataReader As MySqlDataReader = Command.ExecuteReader

                If DataReader.Read() Then
                    ' --- カード登録あり ---
                    newid = DataReader("caredid").ToString()
                    ICid = Convert.ToInt32(DataReader("ICno"))

                    ' 定期情報の取得
                    If Not IsDBNull(DataReader("gepass")) Then gepass = Convert.ToInt32(DataReader("gepass"))
                    If Not IsDBNull(DataReader("depass")) Then depass = DataReader("depass").ToString()
                    If Not IsDBNull(DataReader("arpass")) Then arpass = DataReader("arpass").ToString()

                    DataReader.Close() ' 次の処理のために閉じる

                    ' 入場状態を確認
                    CheckDepoStatus()

                    If rdepoid = 0 Then
                        ' --- 入場記録がない場合（これから入場） ---
                        ProcessEntry()

                        ' 画面遷移
                        Me.Hide()
                        Dim nextForm As New gate()
                        nextForm.ReceivedId = newid
                        nextForm.ICId = ICid
                        nextForm.Show()

                    Else
                        ' --- 入場記録がある場合（出場・運賃精算） ---

                        ' 定期券の判定ロジック
                        Dim isPassValid As Boolean = False

                        If gepass <> 0 Then
                            ' 定期券持ちの場合、区間内かチェック
                            isPassValid = IsStationInPassRange()
                        End If

                        If isPassValid Then
                            ' 定期区間内の場合は0円
                            fare = 0
                        Else
                            ' 定期区間外、または定期なしの場合は最安運賃計算
                            fare = CalculateBestFare()
                        End If

                        If fare = -1 Then
                            MessageBox.Show("経路が見つかりません、または運賃計算エラーです。")
                        Else
                            ' 残高更新と入場記録消去
                            If Balkeisan() Then
                                ' 画面遷移
                                Dim nextForm As New gate()
                                nextForm.ReceivedId = newid
                                nextForm.ICId = ICid
                                nextForm.pay = fare ' 支払い額を渡す
                                nextForm.Show()
                                Me.Hide()
                            End If
                        End If
                    End If

                Else
                    ' --- カード登録なし ---
                    MessageBox.Show("このカードは登録されていません。")
                    Timer1.Enabled = True
                End If

                If Not DataReader.IsClosed Then DataReader.Close()

            Catch ex As Exception
                MessageBox.Show("DBエラー: " & ex.Message)
                Timer1.Enabled = True
            Finally
                Connection.Close()
            End Try
        End If
    End Sub

    ' 入場処理
    Private Sub ProcessEntry()
        Using Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            Connection.Open()
            Dim sql As String = $"UPDATE iccard SET ruoteiddapo = {ruoteid}, stationiddapo = {stationid} WHERE ICno = {ICid}"
            Using Command As New MySqlCommand(sql, Connection)
                Command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' 入場状態の確認
    Private Sub CheckDepoStatus()
        rdepoid = 0
        sdepoid = 0
        Using Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            Connection.Open()
            Dim sql As String = $"SELECT ruoteiddapo, stationiddapo FROM iccard WHERE ICno = {ICid}"
            Using Command As New MySqlCommand(sql, Connection)
                Using DataReader As MySqlDataReader = Command.ExecuteReader()
                    If DataReader.Read() Then
                        Integer.TryParse(DataReader("ruoteiddapo").ToString(), rdepoid)
                        Integer.TryParse(DataReader("stationiddapo").ToString(), sdepoid)
                    End If
                End Using
            End Using
        End Using
    End Sub

    ' 精算処理
    Private Function Balkeisan() As Boolean
        Using Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            Connection.Open()

            ' 1. 現在の残高を確認
            Dim checkSql As String = "SELECT bal FROM iccard WHERE ICno = @icno"
            Dim currentBal As Integer = 0
            Using cmdCheck As New MySqlCommand(checkSql, Connection)
                cmdCheck.Parameters.AddWithValue("@icno", ICid)
                currentBal = Convert.ToInt32(cmdCheck.ExecuteScalar())
            End Using

            If currentBal < fare Then
                MessageBox.Show($"残高不足です。(残高:{currentBal}円, 運賃:{fare}円)")
                Timer1.Enabled = True
                Return False
            End If

            ' トランザクション開始
            Dim transaction As MySqlTransaction = Connection.BeginTransaction()

            Try
                ' 2. 残高の引き落としと入場情報のクリア
                Dim updateSql As String = "UPDATE iccard SET bal = bal - @fare, ruoteiddapo = 0, stationiddapo = 0 WHERE ICno = @icno"
                Using cmdUpdate As New MySqlCommand(updateSql, Connection, transaction)
                    cmdUpdate.Parameters.AddWithValue("@fare", fare)
                    cmdUpdate.Parameters.AddWithValue("@icno", ICid)
                    cmdUpdate.ExecuteNonQuery()
                End Using

                ' 3. 利用履歴の保存
                Dim historySql As String = "INSERT INTO resume (ICno, reday, bos, gos, fare) " &
                                         "SELECT @icno, CURDATE(), " &
                                         "(SELECT stationname FROM station WHERE ruoid = @rdep AND stationid = @sdep), " &
                                         "(SELECT stationname FROM station WHERE ruoid = @rout AND stationid = @stat), " &
                                         "@fare"

                Using cmdHistory As New MySqlCommand(historySql, Connection, transaction)
                    cmdHistory.Parameters.AddWithValue("@icno", ICid)
                    cmdHistory.Parameters.AddWithValue("@rdep", rdepoid)
                    cmdHistory.Parameters.AddWithValue("@sdep", sdepoid)
                    cmdHistory.Parameters.AddWithValue("@rout", ruoteid)
                    cmdHistory.Parameters.AddWithValue("@stat", stationid)
                    cmdHistory.Parameters.AddWithValue("@fare", fare)
                    cmdHistory.ExecuteNonQuery()
                End Using

                transaction.Commit()
                Return True

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("履歴保存中にエラーが発生しました: " & ex.Message)
                Return False
            End Try
        End Using
    End Function

    ' 定期区間内判定ロジック
    Private Function IsStationInPassRange() As Boolean
        If rdepoid = ruoteid And sdepoid = stationid Then Return True
        If String.IsNullOrEmpty(depass) Or String.IsNullOrEmpty(arpass) Then Return False

        Using Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            Connection.Open()

            Dim sqlPass As String = "SELECT ruoid, stationid, pointkm, stationname FROM station WHERE stationname = @p1 OR stationname = @p2"
            Dim pStart As New Dictionary(Of String, Object)
            Dim pEnd As New Dictionary(Of String, Object)

            Using cmd As New MySqlCommand(sqlPass, Connection)
                cmd.Parameters.AddWithValue("@p1", depass)
                cmd.Parameters.AddWithValue("@p2", arpass)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        Dim name As String = dr("stationname").ToString()
                        Dim info As New Dictionary(Of String, Object) From {
                            {"ruoid", dr("ruoid")},
                            {"pointkm", dr("pointkm")}
                        }
                        If name = depass Then pStart = info
                        If name = arpass Then pEnd = info
                    End While
                End Using
            End Using

            If pStart.Count = 0 Or pEnd.Count = 0 Then Return False

            Dim sqlRide As String = "SELECT pointkm FROM station WHERE ruoid = @rid AND stationid = @sid"
            Dim entryKm As Double = -1
            Dim exitKm As Double = -1

            Using cmdEntry As New MySqlCommand(sqlRide, Connection)
                cmdEntry.Parameters.AddWithValue("@rid", rdepoid)
                cmdEntry.Parameters.AddWithValue("@sid", sdepoid)
                Dim res = cmdEntry.ExecuteScalar()
                If res IsNot Nothing Then entryKm = Convert.ToDouble(res)
            End Using

            Using cmdExit As New MySqlCommand(sqlRide, Connection)
                cmdExit.Parameters.AddWithValue("@rid", ruoteid)
                cmdExit.Parameters.AddWithValue("@sid", stationid)
                Dim res = cmdExit.ExecuteScalar()
                If res IsNot Nothing Then exitKm = Convert.ToDouble(res)
            End Using

            Dim passRouteID As Integer = Convert.ToInt32(pStart("ruoid"))

            ' 簡易判定：定期が同一路線内で、乗車区間もその路線内にある場合
            If passRouteID = Convert.ToInt32(pEnd("ruoid")) Then
                If rdepoid = passRouteID And ruoteid = passRouteID Then
                    Dim startKm As Double = Convert.ToDouble(pStart("pointkm"))
                    Dim endKm As Double = Convert.ToDouble(pEnd("pointkm"))
                    Dim minKm As Double = Math.Min(startKm, endKm)
                    Dim maxKm As Double = Math.Max(startKm, endKm)

                    If entryKm >= minKm And entryKm <= maxKm And exitKm >= minKm And exitKm <= maxKm Then
                        Return True
                    End If
                End If
            End If

            Return False
        End Using
    End Function

    ' ★★★ 修正箇所：距離をCEILING()で切り上げて計算 ★★★
    Private Function CalculateBestFare() As Integer
        Dim minFare As Integer = -1

        If rdepoid = ruoteid And sdepoid = stationid Then Return 0

        Dim sb As New StringBuilder()

        ' CEILING()を追加して、小数点の距離（例:3.5km）を整数（4km）に切り上げ、運賃表の隙間落ちを防ぐ
        sb.AppendLine("SELECT MIN(合計IC運賃) FROM (")

        ' --- 0. 乗り換えなし ---
        sb.AppendLine("SELECT ")
        sb.AppendLine(" (IFNULL((SELECT fare FROM fareusu WHERE CEILING(CASE WHEN S_start.ruoid <= 3 THEN ABS(S_start.pointkm - S_end.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 1 LIMIT 1), 0) + ")
        sb.AppendLine("  IFNULL((SELECT fare FROM fareusu WHERE CEILING(CASE WHEN S_start.ruoid = 4  THEN ABS(S_start.pointkm - S_end.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 2 LIMIT 1), 0)) AS 合計IC運賃")
        sb.AppendLine("FROM station AS S_start, station AS S_end")
        sb.AppendLine($"WHERE S_start.ruoid = {rdepoid} AND S_start.stationid = {sdepoid} AND S_end.ruoid = {ruoteid} AND S_end.stationid = {stationid} AND S_start.ruoid = S_end.ruoid")

        sb.AppendLine("UNION ALL")

        ' --- 1. 乗り換え1回 ---
        sb.AppendLine("SELECT ")
        sb.AppendLine(" (IFNULL((SELECT fare FROM fareusu WHERE CEILING(CASE WHEN S_start.ruoid <= 3 THEN ABS(S_start.pointkm - J1_s.pointkm) ELSE 0 END + CASE WHEN S_end.ruoid <= 3 THEN ABS(J1_e.pointkm - S_end.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 1 LIMIT 1), 0) + ")
        sb.AppendLine("  IFNULL((SELECT fare FROM fareusu WHERE CEILING(CASE WHEN S_start.ruoid = 4  THEN ABS(S_start.pointkm - J1_s.pointkm) ELSE 0 END + CASE WHEN S_end.ruoid = 4  THEN ABS(J1_e.pointkm - S_end.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 2 LIMIT 1), 0)) AS 合計IC運賃")
        sb.AppendLine("FROM station AS S_start, station AS S_end, bosr1 AS B1a, bosr2 AS B1b, station AS J1_s, station AS J1_e")
        sb.AppendLine($"WHERE S_start.ruoid = {rdepoid} AND S_start.stationid = {sdepoid} AND S_end.ruoid = {ruoteid} AND S_end.stationid = {stationid}")
        sb.AppendLine("AND ((B1a.ruoid = S_start.ruoid AND B1b.ruoid = S_end.ruoid AND J1_s.stationid = B1a.stationid AND J1_e.ruoid = B1b.ruoid AND J1_e.stationid = B1b.stationid)")
        sb.AppendLine("  OR (B1b.ruoid = S_start.ruoid AND B1a.ruoid = S_end.ruoid AND J1_s.stationid = B1b.stationid AND J1_e.ruoid = B1a.ruoid AND J1_e.stationid = B1a.stationid))")
        sb.AppendLine("AND J1_s.ruoid = S_start.ruoid AND J1_s.stationname = J1_e.stationname")

        sb.AppendLine("UNION ALL")

        ' --- 2. 乗り換え2回 ---
        sb.AppendLine("SELECT ")
        sb.AppendLine(" (IFNULL((SELECT fare FROM fareusu WHERE CEILING(CASE WHEN S_start.ruoid <= 3 THEN ABS(S_start.pointkm - J1_s.pointkm) ELSE 0 END + CASE WHEN J1_e.ruoid <= 3 THEN ABS(J2_s.pointkm - J1_e.pointkm) ELSE 0 END + CASE WHEN S_end.ruoid <= 3 THEN ABS(J2_e.pointkm - S_end.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 1 LIMIT 1), 0) + ")
        sb.AppendLine("  IFNULL((SELECT fare FROM fareusu WHERE CEILING(CASE WHEN S_start.ruoid = 4 THEN ABS(S_start.pointkm - J1_s.pointkm) ELSE 0 END + CASE WHEN J1_e.ruoid = 4 THEN ABS(J2_s.pointkm - J1_e.pointkm) ELSE 0 END + CASE WHEN S_end.ruoid = 4 THEN ABS(J2_e.pointkm - S_end.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 2 LIMIT 1), 0)) AS 合計IC運賃")
        sb.AppendLine("FROM station AS S_start, station AS S_end, bosr1 AS B1a, bosr2 AS B1b, station AS J1_s, station AS J1_e, bosr1 AS B2a, bosr2 AS B2b, station AS J2_s, station AS J2_e")
        sb.AppendLine($"WHERE S_start.ruoid = {rdepoid} AND S_start.stationid = {sdepoid} AND S_end.ruoid = {ruoteid} AND S_end.stationid = {stationid}")
        sb.AppendLine("AND ((B1a.ruoid = S_start.ruoid AND B1b.ruoid <> S_start.ruoid AND J1_s.stationid = B1a.stationid AND J1_e.ruoid = B1b.ruoid AND J1_e.stationid = B1b.stationid) OR (B1b.ruoid = S_start.ruoid AND B1a.ruoid <> S_start.ruoid AND J1_s.stationid = B1b.stationid AND J1_e.ruoid = B1a.ruoid AND J1_e.stationid = B1a.stationid)) AND J1_s.ruoid = S_start.ruoid AND J1_s.stationname = J1_e.stationname")
        sb.AppendLine("AND ((B2a.ruoid = J1_e.ruoid AND B2b.ruoid = S_end.ruoid AND J2_s.stationid = B2a.stationid AND J2_e.ruoid = B2b.ruoid AND J2_e.stationid = B2b.stationid) OR (B2b.ruoid = J1_e.ruoid AND B2a.ruoid = S_end.ruoid AND J2_s.stationid = B2b.stationid AND J2_e.ruoid = B2a.ruoid AND J2_e.stationid = B2a.stationid)) AND J2_s.ruoid = J1_e.ruoid AND J2_s.stationname = J2_e.stationname")

        sb.AppendLine("UNION ALL")

        ' --- 3. 乗り換え3回 ---
        sb.AppendLine("SELECT ")
        sb.AppendLine(" (IFNULL((SELECT fare FROM fareusu WHERE CEILING(CASE WHEN S_start.ruoid <= 3 THEN ABS(S_start.pointkm - J1_s.pointkm) ELSE 0 END + CASE WHEN J1_e.ruoid <= 3 THEN ABS(J2_s.pointkm - J1_e.pointkm) ELSE 0 END + CASE WHEN J2_e.ruoid <= 3 THEN ABS(J3_s.pointkm - J2_e.pointkm) ELSE 0 END + CASE WHEN S_end.ruoid <= 3 THEN ABS(S_end.pointkm - J3_e.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 1 LIMIT 1), 0) + ")
        sb.AppendLine("  IFNULL((SELECT fare FROM fareusu WHERE CEILING(CASE WHEN S_start.ruoid = 4 THEN ABS(S_start.pointkm - J1_s.pointkm) ELSE 0 END + CASE WHEN J1_e.ruoid = 4 THEN ABS(J2_s.pointkm - J1_e.pointkm) ELSE 0 END + CASE WHEN J2_e.ruoid = 4 THEN ABS(J3_s.pointkm - J2_e.pointkm) ELSE 0 END + CASE WHEN S_end.ruoid = 4 THEN ABS(S_end.pointkm - J3_e.pointkm) ELSE 0 END) BETWEEN minkm AND maxkm AND medium = 1 AND busid = 2 LIMIT 1), 0)) AS 合計IC運賃")
        sb.AppendLine("FROM station AS S_start, station AS S_end, bosr1 AS B1a, bosr2 AS B1b, station AS J1_s, station AS J1_e, bosr1 AS B2a, bosr2 AS B2b, station AS J2_s, station AS J2_e, bosr1 AS B3a, bosr2 AS B3b, station AS J3_s, station AS J3_e")
        sb.AppendLine($"WHERE S_start.ruoid = {rdepoid} AND S_start.stationid = {sdepoid} AND S_end.ruoid = {ruoteid} AND S_end.stationid = {stationid}")
        sb.AppendLine("AND ((B1a.ruoid = S_start.ruoid AND B1b.ruoid <> S_start.ruoid AND J1_s.stationid = B1a.stationid AND J1_e.ruoid = B1b.ruoid AND J1_e.stationid = B1b.stationid) OR (B1b.ruoid = S_start.ruoid AND B1a.ruoid <> S_start.ruoid AND J1_s.stationid = B1b.stationid AND J1_e.ruoid = B1a.ruoid AND J1_e.stationid = B1a.stationid)) AND J1_s.ruoid = S_start.ruoid AND J1_s.stationname = J1_e.stationname")
        sb.AppendLine("AND ((B2a.ruoid = J1_e.ruoid AND B2b.ruoid <> J1_e.ruoid AND J2_s.stationid = B2a.stationid AND J2_e.ruoid = B2b.ruoid AND J2_e.stationid = B2b.stationid) OR (B2b.ruoid = J1_e.ruoid AND B2a.ruoid <> J1_e.ruoid AND J2_s.stationid = B2b.stationid AND J2_e.ruoid = B2a.ruoid AND J2_e.stationid = B2a.stationid)) AND J2_s.ruoid = J1_e.ruoid AND J2_s.stationname = J2_e.stationname")
        sb.AppendLine("AND ((B3a.ruoid = J2_e.ruoid AND B3b.ruoid = S_end.ruoid AND J3_s.stationid = B3a.stationid AND J3_e.ruoid = B3b.ruoid AND J3_e.stationid = B3b.stationid) OR (B3b.ruoid = J2_e.ruoid AND B3a.ruoid = S_end.ruoid AND J3_s.stationid = B3b.stationid AND J3_e.ruoid = B3a.ruoid AND J3_e.stationid = B3a.stationid)) AND J3_s.ruoid = J2_e.ruoid AND J3_s.stationname = J3_e.stationname")

        sb.AppendLine(") AS AllRoutes")

        Using Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            Connection.Open()
            Dim Command As New MySqlCommand(sb.ToString(), Connection)
            Dim result = Command.ExecuteScalar()

            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Return Convert.ToInt32(result)
            Else
                Return -1
            End If
        End Using
    End Function

End Class