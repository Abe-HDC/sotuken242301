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
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Collections.Generic
Imports System.Linq ' リスト操作を楽にするために追加

Public Class gateend
    ' Orange Tags API
    Private Declare Function GetCardIDIndex Lib "OrangeOneStopEasyAPI.dll" (ByRef id As Byte, ByRef length As Integer, ByVal index As Integer) As Integer

    ' --- データ構造の定義 ---
    Private Structure StationData
        Public RuoID As Integer       ' 路線ID
        Public StationID As Integer   ' 駅ID
        Public Name As String         ' 駅名
        Public PointKm As Double      ' キロ程
        Public CompanyID As Integer   ' 1: JR(1-3), 2: 東武(4)
    End Structure

    Private Structure FareData
        Public BusID As Integer
        Public MinKm As Double
        Public MaxKm As Double
        Public Price As Integer
    End Structure

    ' メモリ上に保持する配列
    Private StationList As New List(Of StationData)
    Private FareList As New List(Of FareData)

    ' プロパティ
    Public Property ruoteid As Integer    ' 現在の改札の路線ID
    Public Property stationid As Integer  ' 現在の改札の駅ID
    Dim ICid As Integer
    Dim newid As String
    Dim rdepoid As Integer = 0 ' 入場路線ID
    Dim sdepoid As Integer = 0 ' 入場駅ID
    Dim fare As Integer = 0

    ' --- フォーム起動時にデータを配列に読み込む ---
    Private Sub gateend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadMasterData()
        Catch ex As Exception
            MessageBox.Show("データのロードに失敗しました: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadMasterData()
        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            conn.Open()
            ' 駅データのロード
            Dim cmdSt = New MySqlCommand("SELECT ruoid, stationid, stationname, pointkm FROM station", conn)
            Using r = cmdSt.ExecuteReader()
                While r.Read()
                    Dim rid = r.GetInt32("ruoid")
                    StationList.Add(New StationData With {
                        .RuoID = rid,
                        .StationID = r.GetInt32("stationid"),
                        .Name = r.GetString("stationname"),
                        .PointKm = r.GetDouble("pointkm"),
                        .CompanyID = If(rid <= 3, 1, 2) ' 1-3はJR(1), 4は東武(2)
                    })
                End While
            End Using
            ' 運賃データのロード
            Dim cmdFa = New MySqlCommand("SELECT busid, minkm, maxkm, fare FROM fareusu WHERE medium = 1", conn)
            Using r = cmdFa.ExecuteReader()
                While r.Read()
                    FareList.Add(New FareData With {
                        .BusID = r.GetInt32("busid"),
                        .MinKm = r.GetDouble("minkm"),
                        .MaxKm = r.GetDouble("maxkm"),
                        .Price = r.GetInt32("fare")
                    })
                End While
            End Using
        End Using
    End Sub

    ' --- 運賃計算の核心部分 ---
    Private Function GetTotalFare(inR As Integer, inS As Integer, outR As Integer, outS As Integer) As Integer
        ' 最適な（最短の）キロ数を入れる変数
        Dim bestJR_Km As Double = 9999.0
        Dim bestTobu_Km As Double = 9999.0
        Dim minTotalFare As Integer = -1

        ' 開始駅と終了駅を取得
        Dim startNode = StationList.First(Function(s) s.RuoID = inR AndAlso s.StationID = inS)
        Dim endNode = StationList.First(Function(s) s.RuoID = outR AndAlso s.StationID = outS)

        ' 再帰的な経路探索 (現在の路線, 目的路線, 訪れた路線リスト, JRキロ累計, 東武キロ累計, 現在の駅, 深さ)
        FindPath(inR, outR, New List(Of Integer) From {inR}, 0, 0, startNode, endNode, 0, minTotalFare)

        Return minTotalFare
    End Function

    ' 経路探索サブ関数 (最大3回乗り換え = 深さ3まで)
    Private Sub FindPath(currentR As Integer, targetR As Integer, visitedR As List(Of Integer),
                         jrKm As Double, tobuKm As Double, currentSt As StationData,
                         goalSt As StationData, depth As Integer, ByRef minFare As Integer)

        ' 深さ制限（乗り換え3回 = 4路線まで）
        If depth > 3 Then Exit Sub

        If currentR = targetR Then
            ' 目的地路線に到達した場合、最後の区間キロを足す
            Dim dist = Math.Abs(currentSt.PointKm - goalSt.PointKm)
            Dim finalJR = jrKm : Dim finalTobu = tobuKm
            If currentSt.CompanyID = 1 Then finalJR += dist Else finalTobu += dist

            ' 運賃計算：JR合計運賃 + 東武合計運賃
            Dim fareJR = GetFare(1, finalJR)
            Dim fareTobu = GetFare(2, finalTobu)
            Dim total = fareJR + fareTobu

            ' 最安値を更新
            If minFare = -1 OrElse total < minFare Then minFare = total
            Exit Sub
        End If

        ' 乗り換え駅を探す (今の路線 currentR と、まだ訪れていない他の路線で、同じ駅名を持つものを探す)
        Dim transferStations = StationList.Where(Function(s) s.RuoID = currentR).ToList()

        For Each ts In transferStations
            ' この駅と同じ名前を持つ、別の路線の駅があるか確認
            Dim nextLines = StationList.Where(Function(s) s.Name = ts.Name AndAlso Not visitedR.Contains(s.RuoID)).ToList()

            For Each nextSt In nextLines
                ' 乗り換え発生：現在の路線の走行キロを足す
                Dim dist = Math.Abs(currentSt.PointKm - ts.PointKm)
                Dim nextJR = jrKm : Dim nextTobu = tobuKm
                If ts.CompanyID = 1 Then nextJR += dist Else nextTobu += dist

                ' 次の路線へ進む（再帰）
                Dim nextVisited = New List(Of Integer)(visitedR)
                nextVisited.Add(nextSt.RuoID)
                FindPath(nextSt.RuoID, targetR, nextVisited, nextJR, nextTobu, nextSt, goalSt, depth + 1, minFare)
            Next
        Next
    End Sub

    ' 会社別合計キロから運賃表を引く
    Private Function GetFare(busID As Integer, km As Double) As Integer
        If km = 0 Then Return 0
        Dim row = FareList.Find(Function(f) f.BusID = busID AndAlso km >= f.MinKm AndAlso km < f.MaxKm)
        Return If(row.Price > 0, row.Price, 0)
    End Function

    ' --- タイマー処理（カード検知） ---
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim id(10) As Byte
        Dim length As Integer

        If GetCardIDIndex(id(0), length, 0) = 0 Then
            Timer1.Enabled = False
            Dim idString As String = ByteArrayToHexString(id, length)

            Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
                conn.Open()
                ' ICカード・入場状態確認
                Dim cmd = New MySqlCommand("SELECT ICno, caredid, ruoteiddapo, stationiddapo FROM iccard WHERE caredid = @cid", conn)
                cmd.Parameters.AddWithValue("@cid", idString)

                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        newid = reader("caredid").ToString()
                        ICid = Convert.ToInt32(reader("ICno"))
                        rdepoid = If(IsDBNull(reader("ruoteiddapo")), 0, Convert.ToInt32(reader("ruoteiddapo")))
                        sdepoid = If(IsDBNull(reader("stationiddapo")), 0, Convert.ToInt32(reader("stationiddapo")))
                        reader.Close()

                        If rdepoid = 0 Then
                            ' 入場
                            UpdateEntry(conn)
                            MoveToGate(0)
                        Else
                            ' 出場：★ここで新ロジックの運賃計算★
                            fare = GetTotalFare(rdepoid, sdepoid, ruoteid, stationid)

                            If fare >= 0 Then
                                If ExecutePayment(conn, fare) Then MoveToGate(fare)
                            Else
                                MessageBox.Show("経路が見つかりません。")
                                Timer1.Enabled = True
                            End If
                        End If
                    Else
                        MessageBox.Show("未登録カード")
                        Timer1.Enabled = True
                    End If
                End Using
            End Using
        End If
    End Sub

    ' --- 精算と履歴保存 (トランザクション) ---
    Private Function ExecutePayment(conn As MySqlConnection, payFare As Integer) As Boolean
        ' 1. 残高取得
        Dim bal As Integer
        Using c = New MySqlCommand("SELECT bal FROM iccard WHERE ICno = @id", conn)
            c.Parameters.AddWithValue("@id", ICid)
            bal = Convert.ToInt32(c.ExecuteScalar())
        End Using

        If bal < payFare Then
            MessageBox.Show("残高不足")
            Return False
        End If

        Dim tr = conn.BeginTransaction()
        Try
            ' 残高・入場フラグ更新
            Using c = New MySqlCommand("UPDATE iccard SET bal = bal - @f, ruoteiddapo = 0, stationiddapo = 0 WHERE ICno = @id", conn, tr)
                c.Parameters.AddWithValue("@f", payFare)
                c.Parameters.AddWithValue("@id", ICid)
                c.ExecuteNonQuery()
            End Using

            ' 履歴保存
            Dim inName = StationList.Find(Function(s) s.RuoID = rdepoid AndAlso s.StationID = sdepoid).Name
            Dim outName = StationList.Find(Function(s) s.RuoID = ruoteid AndAlso s.StationID = stationid).Name
            Using c = New MySqlCommand("INSERT INTO resume (ICno, reday, bos, gos, fare) VALUES (@id, CURDATE(), @in, @out, @f)", conn, tr)
                c.Parameters.AddWithValue("@id", ICid)
                c.Parameters.AddWithValue("@in", inName)
                c.Parameters.AddWithValue("@out", outName)
                c.Parameters.AddWithValue("@f", payFare)
                c.ExecuteNonQuery()
            End Using

            tr.Commit()
            Return True
        Catch ex As Exception
            tr.Rollback()
            Return False
        End Try
    End Function

    ' 入場更新
    Private Sub UpdateEntry(conn As MySqlConnection)
        Using c = New MySqlCommand("UPDATE iccard SET ruoteiddapo = @r, stationiddapo = @s WHERE ICno = @id", conn)
            c.Parameters.AddWithValue("@r", ruoteid)
            c.Parameters.AddWithValue("@s", stationid)
            c.Parameters.AddWithValue("@id", ICid)
            c.ExecuteNonQuery()
        End Using
    End Sub

    ' 共通：画面遷移
    Private Sub MoveToGate(payAmt As Integer)
        Dim g As New gate()
        g.ReceivedId = newid
        g.ICId = ICid
        g.pay = payAmt
        g.Show()
        Me.Hide()
    End Sub

    Private Function ByteArrayToHexString(ByVal ba As Byte(), ByVal len As Integer) As String
        Dim sb As New StringBuilder()
        For i As Integer = 0 To len - 1 : sb.Append(ba(i).ToString("X2")) : Next
        Return sb.ToString()
    End Function
End Class