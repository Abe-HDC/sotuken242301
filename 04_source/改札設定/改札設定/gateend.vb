'Imports System.Data.Common
'Imports MySql.Data.MySqlClient
'Imports System.Text
'Imports System.Collections.Generic
'Imports System.Linq

'Public Class gateend
'    ' Orange Tags API
'    Private Declare Function GetCardIDIndex Lib "OrangeOneStopEasyAPI.dll" (ByRef id As Byte, ByRef length As Integer, ByVal index As Integer) As Integer

'    ' --- データ構造の定義 ---
'    Private Structure StationData
'        Public RuoID As Integer       ' 路線ID
'        Public StationID As Integer   ' 駅ID
'        Public Name As String         ' 駅名
'        Public PointKm As Double      ' キロ程
'        Public CompanyID As Integer   ' 1: JR(1-3), 2: 東武(4)
'    End Structure

'    Private Structure FareData
'        Public BusID As Integer
'        Public MinKm As Double
'        Public MaxKm As Double
'        Public Price As Integer
'    End Structure

'    Private StationList As New List(Of StationData)
'    Private FareList As New List(Of FareData)

'    Public Property ruoteid As Integer    ' 現在の改札の路線ID
'    Public Property stationid As Integer  ' 現在の改札の駅ID
'    Dim ICid As Integer
'    Dim newid As String
'    Dim rdepoid As Integer = 0 ' 入場路線ID
'    Dim sdepoid As Integer = 0 ' 入場駅ID
'    Dim fare As Integer = 0

'    ' --- 初期ロード ---
'    Private Sub gateend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        ' 画面の作業領域（タスクバーを除く）
'        Dim wa = Screen.PrimaryScreen.WorkingArea

'        ' 幅と高さを 1/4 に
'        Me.Width = wa.Width \ 2
'        Me.Height = wa.Height \ 2

'        ' 左上に配置
'        Me.Left = wa.Left
'        Me.Top = wa.Bottom - Me.Height

'        Try
'            LoadMasterData()
'        Catch ex As Exception
'            MessageBox.Show("データのロードに失敗しました: " & ex.Message)
'        End Try
'    End Sub

'    Private Sub LoadMasterData()
'        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
'            conn.Open()
'            Dim cmdSt = New MySqlCommand("SELECT ruoid, stationid, stationname, pointkm FROM station", conn)
'            Using r = cmdSt.ExecuteReader()
'                While r.Read()
'                    Dim rid = r.GetInt32("ruoid")
'                    StationList.Add(New StationData With {
'                        .RuoID = rid,
'                        .StationID = r.GetInt32("stationid"),
'                        .Name = r.GetString("stationname"),
'                        .PointKm = r.GetDouble("pointkm"),
'                        .CompanyID = If(rid <= 3, 1, 2)
'                    })
'                End While
'            End Using
'            Dim cmdFa = New MySqlCommand("SELECT busid, minkm, maxkm, fare FROM fareusu WHERE medium = 1", conn)
'            Using r = cmdFa.ExecuteReader()
'                While r.Read()
'                    FareList.Add(New FareData With {
'                        .BusID = r.GetInt32("busid"),
'                        .MinKm = r.GetDouble("minkm"),
'                        .MaxKm = r.GetDouble("maxkm"),
'                        .Price = r.GetInt32("fare")
'                    })
'                End While
'            End Using
'        End Using
'    End Sub

'    ' --- 運賃計算(通常用) ---
'    Private Function GetTotalFare(inR As Integer, inS As Integer, outR As Integer, outS As Integer) As Integer
'        Try
'            Dim startNode = StationList.FirstOrDefault(Function(s) s.RuoID = inR AndAlso s.StationID = inS)
'            Dim endNode = StationList.FirstOrDefault(Function(s) s.RuoID = outR AndAlso s.StationID = outS)

'            If startNode.Name Is Nothing OrElse endNode.Name Is Nothing Then Return -1

'            ' 【修正】同じ路線の場合は最短経路探索を通さず直接計算
'            If inR = outR Then
'                Dim dist = Math.Abs(startNode.PointKm - endNode.PointKm)
'                Return GetFare(startNode.CompanyID, dist)
'            End If

'            ' 路線が違う場合は乗り換え探索
'            Dim minTotalFare As Integer = -1
'            FindPath(inR, outR, New List(Of Integer) From {inR}, 0, 0, startNode, endNode, 0, minTotalFare)
'            Return minTotalFare
'        Catch
'            Return -1
'        End Try
'    End Function

'    Private Sub FindPath(currentR As Integer, targetR As Integer, visitedR As List(Of Integer),
'                         jrKm As Double, tobuKm As Double, currentSt As StationData,
'                         goalSt As StationData, depth As Integer, ByRef minFare As Integer)
'        If depth > 3 Then Exit Sub
'        If currentR = targetR Then
'            Dim dist = Math.Abs(currentSt.PointKm - goalSt.PointKm)
'            Dim fJR = jrKm : Dim fTobu = tobuKm
'            If currentSt.CompanyID = 1 Then fJR += dist Else fTobu += dist
'            Dim total = GetFare(1, fJR) + GetFare(2, fTobu)
'            If minFare = -1 OrElse total < minFare Then minFare = total
'            Exit Sub
'        End If
'        Dim transferStations = StationList.Where(Function(s) s.RuoID = currentR).ToList()
'        For Each ts In transferStations
'            Dim nextLines = StationList.Where(Function(s) s.Name = ts.Name AndAlso Not visitedR.Contains(s.RuoID)).ToList()
'            For Each nextSt In nextLines
'                Dim dist = Math.Abs(currentSt.PointKm - ts.PointKm)
'                Dim nJR = jrKm : Dim nTobu = tobuKm
'                If ts.CompanyID = 1 Then nJR += dist Else nTobu += dist
'                Dim nextVisited = New List(Of Integer)(visitedR) : nextVisited.Add(nextSt.RuoID)
'                FindPath(nextSt.RuoID, targetR, nextVisited, nJR, nTobu, nextSt, goalSt, depth + 1, minFare)
'            Next
'        Next
'    End Sub

'    Private Function GetFare(busID As Integer, km As Double) As Integer
'        If km <= 0 Then Return 0
'        Dim row = FareList.Find(Function(f) f.BusID = busID AndAlso km >= f.MinKm AndAlso km < f.MaxKm)
'        Return If(row.Price > 0, row.Price, 0)
'    End Function

'    ' --- 改良版：定期区間判定(逆方向・区間内乗降対応) ---
'    'Private Function IsWithinPass(inR As Integer, inS As Integer, outR As Integer, outS As Integer,
'    '                              pSR As Integer, pSS As Integer, pER As Integer, pES As Integer) As Boolean
'    '    If pSR = 0 Or pER = 0 Then Return False

'    '    ' 1. 定期区間(起点〜終点)の最短距離を取得
'    '    Dim passJR, passTobu As Double
'    '    GetMinKm(pSR, pSS, pER, pES, passJR, passTobu)

'    '    ' 2. 乗車駅(In)が定期経路上の点か判定
'    '    ' 起点→乗車駅 + 乗車駅→終点 = 起点→終点 なら、その駅は経路上にある
'    '    Dim inStartJR, inStartTobu, inEndJR, inEndTobu As Double
'    '    GetMinKm(pSR, pSS, inR, inS, inStartJR, inStartTobu)
'    '    GetMinKm(inR, inS, pER, pES, inEndJR, inEndTobu)
'    '    Dim inOnPath As Boolean = (Math.Abs(passJR - (inStartJR + inEndJR)) < 0.1) AndAlso
'    '                              (Math.Abs(passTobu - (inStartTobu + inEndTobu)) < 0.1)

'    '    ' 3. 降車駅(Out)が定期経路上の点か判定
'    '    Dim outStartJR, outStartTobu, outEndJR, outEndTobu As Double
'    '    GetMinKm(pSR, pSS, outR, outS, outStartJR, outStartTobu)
'    '    GetMinKm(outR, outS, pER, pES, outEndJR, outEndTobu)
'    '    Dim outOnPath As Boolean = (Math.Abs(passJR - (outStartJR + outEndJR)) < 0.1) AndAlso
'    '                               (Math.Abs(passTobu - (outStartTobu + outEndTobu)) < 0.1)

'    '    ' 両方の駅が定期区間内に含まれていれば、方向に関わらず区間内
'    '    Return inOnPath AndAlso outOnPath
'    'End Function

'    Private Function IsWithinPass(inR As Integer, inS As Integer, outR As Integer, outS As Integer,
'                                  pSR As Integer, pSS As Integer, pER As Integer, pES As Integer) As Boolean
'        ' 定期情報が未登録(0)なら即座に「区間外(False)」として扱う
'        If pSR <= 0 Or pER <= 0 Then Return False

'        Try
'            ' 1. 定期全区間の距離
'            Dim passJR, passTobu As Double
'            GetMinKm(pSR, pSS, pER, pES, passJR, passTobu)
'            If passJR = 999.0 And passTobu = 999.0 Then Return False ' 定期区間自体が計算不能

'            ' 2. 今回の乗車駅が定期経路上か
'            Dim inStartJR, inStartTobu, inEndJR, inEndTobu As Double
'            GetMinKm(pSR, pSS, inR, inS, inStartJR, inStartTobu)
'            GetMinKm(inR, inS, pER, pES, inEndJR, inEndTobu)
'            Dim inOnPath As Boolean = (Math.Abs(passJR - (inStartJR + inEndJR)) < 0.1) AndAlso
'                                      (Math.Abs(passTobu - (inStartTobu + inEndTobu)) < 0.1)

'            ' 3. 今回の降車駅が定期経路上か
'            Dim outStartJR, outStartTobu, outEndJR, outEndTobu As Double
'            GetMinKm(pSR, pSS, outR, outS, outStartJR, outStartTobu)
'            GetMinKm(outR, outS, pER, pES, outEndJR, outEndTobu)
'            Dim outOnPath As Boolean = (Math.Abs(passJR - (outStartJR + outEndJR)) < 0.1) AndAlso
'                                       (Math.Abs(passTobu - (outStartTobu + outEndTobu)) < 0.1)

'            Return inOnPath AndAlso outOnPath
'        Catch
'            Return False
'        End Try
'    End Function

'    Private Sub GetMinKm(inR As Integer, inS As Integer, outR As Integer, outS As Integer, ByRef outJR As Double, ByRef outTobu As Double)
'        Dim minJR As Double = 999.0 : Dim minTobu As Double = 999.0
'        Try
'            Dim startNode = StationList.First(Function(s) s.RuoID = inR AndAlso s.StationID = inS)
'            Dim endNode = StationList.First(Function(s) s.RuoID = outR AndAlso s.StationID = outS)
'            FindDistancePath(inR, outR, New List(Of Integer) From {inR}, 0, 0, startNode, endNode, 0, minJR, minTobu)
'        Catch
'        End Try
'        outJR = minJR : outTobu = minTobu
'    End Sub

'    Private Sub FindDistancePath(currentR As Integer, targetR As Integer, visitedR As List(Of Integer),
'                                 jrKm As Double, tobuKm As Double, currentSt As StationData,
'                                 goalSt As StationData, depth As Integer, ByRef minJR As Double, ByRef minTobu As Double)
'        If depth > 3 Then Exit Sub
'        If currentR = targetR Then
'            Dim dist = Math.Abs(currentSt.PointKm - goalSt.PointKm)
'            Dim fJR = jrKm : Dim fTobu = tobuKm
'            If currentSt.CompanyID = 1 Then fJR += dist Else fTobu += dist
'            If (fJR + fTobu) < (minJR + minTobu) Then : minJR = fJR : minTobu = fTobu : End If
'            Exit Sub
'        End If
'        Dim transferStations = StationList.Where(Function(s) s.RuoID = currentR).ToList()
'        For Each ts In transferStations
'            Dim nextLines = StationList.Where(Function(s) s.Name = ts.Name AndAlso Not visitedR.Contains(s.RuoID)).ToList()
'            For Each nextSt In nextLines
'                Dim dist = Math.Abs(currentSt.PointKm - ts.PointKm)
'                Dim nJR = jrKm : Dim nTobu = tobuKm
'                If ts.CompanyID = 1 Then nJR += dist Else nTobu += dist
'                Dim nextVisited = New List(Of Integer)(visitedR) : nextVisited.Add(nextSt.RuoID)
'                FindDistancePath(nextSt.RuoID, targetR, nextVisited, nJR, nTobu, nextSt, goalSt, depth + 1, minJR, minTobu)
'            Next
'        Next
'    End Sub

'    ' --- タイマー(カード検知) ---
'    'Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
'    '    Dim id(10) As Byte
'    '    Dim length As Integer
'    '    If GetCardIDIndex(id(0), length, 0) = 0 Then
'    '        Timer1.Enabled = False
'    '        Dim idString As String = ByteArrayToHexString(id, length)
'    '        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
'    '            conn.Open()
'    '            Dim sql = "SELECT ICno, caredid, ruoteiddapo, stationiddapo, stday, endday, " &
'    '                      "ruoteiddp, stationiddp, ruoteidend, stationidend FROM iccard WHERE caredid = @cid"
'    '            Dim cmd = New MySqlCommand(sql, conn)
'    '            cmd.Parameters.AddWithValue("@cid", idString)
'    '            Using reader = cmd.ExecuteReader()
'    '                If reader.Read() Then
'    '                    newid = reader("caredid").ToString() : ICid = Convert.ToInt32(reader("ICno"))
'    '                    rdepoid = If(IsDBNull(reader("ruoteiddapo")), 0, Convert.ToInt32(reader("ruoteiddapo")))
'    '                    sdepoid = If(IsDBNull(reader("stationiddapo")), 0, Convert.ToInt32(reader("stationiddapo")))
'    '                    Dim stDay As Date = If(IsDBNull(reader("stday")), #1/1/1900#, Convert.ToDateTime(reader("stday")))
'    '                    Dim endDay As Date = If(IsDBNull(reader("endday")), #1/1/1900#, Convert.ToDateTime(reader("endday")))
'    '                    Dim pSR As Integer = If(IsDBNull(reader("ruoteiddp")), 0, Convert.ToInt32(reader("ruoteiddp")))
'    '                    Dim pSS As Integer = If(IsDBNull(reader("stationiddp")), 0, Convert.ToInt32(reader("stationiddp")))
'    '                    Dim pER As Integer = If(IsDBNull(reader("ruoteidend")), 0, Convert.ToInt32(reader("ruoteidend")))
'    '                    Dim pES As Integer = If(IsDBNull(reader("stationidend")), 0, Convert.ToInt32(reader("stationidend")))
'    '                    reader.Close()

'    '                    If rdepoid = 0 Then
'    '                        UpdateEntry(conn) : MoveToGate(0)
'    '                    Else
'    '                        Dim isPassValid As Boolean = (stDay <= Date.Today AndAlso Date.Today <= endDay)
'    '                        If isPassValid AndAlso IsWithinPass(rdepoid, sdepoid, ruoteid, stationid, pSR, pSS, pER, pES) Then
'    '                            fare = 0
'    '                        Else
'    '                            fare = GetTotalFare(rdepoid, sdepoid, ruoteid, stationid)
'    '                        End If

'    '                        If fare >= 0 Then
'    '                            If ExecutePayment(conn, fare) Then MoveToGate(fare)
'    '                        Else
'    '                            MessageBox.Show("経路が見つかりません。")
'    '                            Timer1.Enabled = True
'    '                        End If
'    '                    End If
'    '                Else
'    '                    MessageBox.Show("未登録カード") : Timer1.Enabled = True
'    '                End If
'    '            End Using
'    '        End Using
'    '    End If
'    'End Sub

'    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
'        Dim id(10) As Byte
'        Dim length As Integer
'        If GetCardIDIndex(id(0), length, 0) = 0 Then
'            Timer1.Enabled = False
'            Dim idString As String = ByteArrayToHexString(id, length)
'            Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
'                conn.Open()
'                Dim sql = "SELECT ICno, caredid, ruoteiddapo, stationiddapo, stday, endday, " &
'                          "ruoteiddp, stationiddp, ruoteidend, stationidend FROM iccard WHERE caredid = @cid"
'                Dim cmd = New MySqlCommand(sql, conn)
'                cmd.Parameters.AddWithValue("@cid", idString)
'                Using reader = cmd.ExecuteReader()
'                    If reader.Read() Then
'                        newid = reader("caredid").ToString() : ICid = Convert.ToInt32(reader("ICno"))
'                        rdepoid = If(IsDBNull(reader("ruoteiddapo")), 0, Convert.ToInt32(reader("ruoteiddapo")))
'                        sdepoid = If(IsDBNull(reader("stationiddapo")), 0, Convert.ToInt32(reader("stationiddapo")))

'                        ' 定期情報の取得
'                        Dim stDayObj = reader("stday")
'                        Dim endDayObj = reader("endday")
'                        Dim pSR As Integer = If(IsDBNull(reader("ruoteiddp")), 0, Convert.ToInt32(reader("ruoteiddp")))
'                        Dim pSS As Integer = If(IsDBNull(reader("stationiddp")), 0, Convert.ToInt32(reader("stationiddp")))
'                        Dim pER As Integer = If(IsDBNull(reader("ruoteidend")), 0, Convert.ToInt32(reader("ruoteidend")))
'                        Dim pES As Integer = If(IsDBNull(reader("stationidend")), 0, Convert.ToInt32(reader("stationidend")))
'                        reader.Close()

'                        If rdepoid = 0 Then
'                            ' 入場処理
'                            UpdateEntry(conn) : MoveToGate(0)
'                        Else
'                            ' 退場・精算処理
'                            ' 有効期限の厳密なチェック（NULLや0の場合はFalseにする）
'                            Dim isPassValid As Boolean = False
'                            If Not IsDBNull(stDayObj) AndAlso Not IsDBNull(endDayObj) Then
'                                Dim stDay As Date = Convert.ToDateTime(stDayObj)
'                                Dim endDay As Date = Convert.ToDateTime(endDayObj)
'                                If Date.Today >= stDay AndAlso Date.Today <= endDay Then isPassValid = True
'                            End If

'                            ' 定期判定 or 通常運賃計算
'                            If isPassValid AndAlso IsWithinPass(rdepoid, sdepoid, ruoteid, stationid, pSR, pSS, pER, pES) Then
'                                fare = 0
'                            Else
'                                fare = GetTotalFare(rdepoid, sdepoid, ruoteid, stationid)
'                            End If

'                            ' 支払実行
'                            If fare >= 0 Then
'                                If ExecutePayment(conn, fare) Then MoveToGate(fare) Else Timer1.Enabled = True
'                            Else
'                                MessageBox.Show("運賃が計算できませんでした。") : Timer1.Enabled = True
'                            End If
'                        End If
'                    Else
'                        MessageBox.Show("未登録カード") : Timer1.Enabled = True
'                    End If
'                End Using
'            End Using
'        End If
'    End Sub



'    ' --- その他サブ関数(ExecutePayment, UpdateEntry, MoveToGate, ByteArrayToHexString) ---
'    ' ※以前の回答と同じ内容のため、統合してご利用ください。
'    'Private Function ExecutePayment(conn As MySqlConnection, payFare As Integer) As Boolean
'    '    Dim bal As Integer
'    '    Using c = New MySqlCommand("SELECT bal FROM iccard WHERE ICno = @id", conn)
'    '        c.Parameters.AddWithValue("@id", ICid)
'    '        bal = Convert.ToInt32(c.ExecuteScalar())
'    '    End Using
'    '    If bal < payFare Then : MessageBox.Show("残高不足") : Return False : End If
'    '    Dim tr = conn.BeginTransaction()
'    '    Try
'    '        Using c = New MySqlCommand("UPDATE iccard SET bal = bal - @f, ruoteiddapo = 0, stationiddapo = 0 WHERE ICno = @id", conn, tr)
'    '            c.Parameters.AddWithValue("@f", payFare) : c.Parameters.AddWithValue("@id", ICid) : c.ExecuteNonQuery()
'    '        End Using
'    '        Dim inName = StationList.Find(Function(s) s.RuoID = rdepoid AndAlso s.StationID = sdepoid).Name
'    '        Dim outName = StationList.Find(Function(s) s.RuoID = ruoteid AndAlso s.StationID = stationid).Name
'    '        Using c = New MySqlCommand("INSERT INTO resume (ICno, reday, bos, gos, fare) VALUES (@id, CURDATE(), @in, @out, @f)", conn, tr)
'    '            c.Parameters.AddWithValue("@id", ICid) : c.Parameters.AddWithValue("@in", inName) : c.Parameters.AddWithValue("@out", outName) : c.Parameters.AddWithValue("@f", payFare) : c.ExecuteNonQuery()
'    '        End Using
'    '        tr.Commit() : Return True
'    '    Catch : tr.Rollback() : Return False : End Try
'    'End Function

'    Private Function ExecutePayment(conn As MySqlConnection, payFare As Integer) As Boolean
'        Try
'            Dim bal As Integer
'            Using c = New MySqlCommand("SELECT bal FROM iccard WHERE ICno = @id", conn)
'                c.Parameters.AddWithValue("@id", ICid)
'                bal = Convert.ToInt32(c.ExecuteScalar())
'            End Using
'            If bal < payFare Then : MessageBox.Show("残高不足: " & payFare & "円必要です") : Return False : End If

'            Dim tr = conn.BeginTransaction()
'            Try
'                ' 残高更新 & 入場情報クリア
'                Using c = New MySqlCommand("UPDATE iccard SET bal = bal - @f, ruoteiddapo = 0, stationiddapo = 0 WHERE ICno = @id", conn, tr)
'                    c.Parameters.AddWithValue("@f", payFare) : c.Parameters.AddWithValue("@id", ICid) : c.ExecuteNonQuery()
'                End Using

'                ' 履歴保存（駅名が見つからない場合のフォールバック）
'                Dim inSt = StationList.FirstOrDefault(Function(s) s.RuoID = rdepoid AndAlso s.StationID = sdepoid)
'                Dim outSt = StationList.FirstOrDefault(Function(s) s.RuoID = ruoteid AndAlso s.StationID = stationid)
'                Dim inName As String = If(inSt.Name, "不明(" & rdepoid & ")")
'                Dim outName As String = If(outSt.Name, "不明(" & ruoteid & ")")

'                Using c = New MySqlCommand("INSERT INTO resume (ICno, reday, bos, gos, fare) VALUES (@id, CURDATE(), @in, @out, @f)", conn, tr)
'                    c.Parameters.AddWithValue("@id", ICid) : c.Parameters.AddWithValue("@in", inName) : c.Parameters.AddWithValue("@out", outName) : c.Parameters.AddWithValue("@f", payFare)
'                    c.ExecuteNonQuery()
'                End Using
'                tr.Commit() : Return True
'            Catch ex As Exception
'                tr.Rollback() : MessageBox.Show("決済エラー: " & ex.Message) : Return False
'            End Try
'        Catch ex As Exception
'            MessageBox.Show("DBエラー: " & ex.Message) : Return False
'        End Try
'    End Function

'    Private Sub UpdateEntry(conn As MySqlConnection)
'        Using c = New MySqlCommand("UPDATE iccard SET ruoteiddapo = @r, stationiddapo = @s WHERE ICno = @id", conn)
'            c.Parameters.AddWithValue("@r", ruoteid) : c.Parameters.AddWithValue("@s", stationid) : c.Parameters.AddWithValue("@id", ICid) : c.ExecuteNonQuery()
'        End Using
'    End Sub

'    Private Sub MoveToGate(payAmt As Integer)
'        Dim g As New gate()
'        g.ReceivedId = newid : g.ICId = ICid : g.pay = payAmt : g.Show() : Me.Hide()
'    End Sub

'    Private Function ByteArrayToHexString(ByVal ba As Byte(), ByVal len As Integer) As String
'        Dim sb As New StringBuilder()
'        For i As Integer = 0 To len - 1 : sb.Append(ba(i).ToString("X2")) : Next
'        Return sb.ToString()
'    End Function
'End Class

Imports System.Data.Common
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Collections.Generic
Imports System.Linq

Public Class gateend
    ' Orange Tags API
    Private Declare Function GetCardIDIndex Lib "OrangeOneStopEasyAPI.dll" (ByRef id As Byte, ByRef length As Integer, ByVal index As Integer) As Integer

    ' --- データ構造 ---
    Private Structure StationData
        Public RuoID As Integer
        Public StationID As Integer
        Public Name As String
        Public PointKm As Double
        Public CompanyID As Integer ' 1: JR, 2: 東武
    End Structure

    Private Structure FareData
        Public BusID As Integer
        Public MinKm As Double
        Public MaxKm As Double
        Public Price As Integer
    End Structure

    Private StationList As New List(Of StationData)
    Private FareList As New List(Of FareData)

    Public Property ruoteid As Integer
    Public Property stationid As Integer
    Dim ICid As Integer
    Dim newid As String

    ' --- ロード処理 ---
    Private Sub gateend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 画面の作業領域（タスクバーを除く）
        Dim wa = Screen.PrimaryScreen.WorkingArea

        ' 幅と高さを 1/4 に
        Me.Width = wa.Width \ 2
        Me.Height = wa.Height \ 2

        ' 左上に配置
        Me.Left = wa.Left
        Me.Top = wa.Bottom - Me.Height

        Try
            LoadMasterData()
        Catch ex As Exception
            MessageBox.Show("データのロードに失敗しました: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadMasterData()
        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            conn.Open()
            Dim cmdSt = New MySqlCommand("SELECT ruoid, stationid, stationname, pointkm FROM station", conn)
            Using r = cmdSt.ExecuteReader()
                While r.Read()
                    Dim rid = r.GetInt32("ruoid")
                    StationList.Add(New StationData With {
                        .RuoID = rid,
                        .StationID = r.GetInt32("stationid"),
                        .Name = r.GetString("stationname"),
                        .PointKm = r.GetDouble("pointkm"),
                        .CompanyID = If(rid <= 3, 1, 2)
                    })
                End While
            End Using
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

    ' --- メイン処理 (Timer) ---
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim id(10) As Byte
        Dim length As Integer
        If GetCardIDIndex(id(0), length, 0) = 0 Then
            Timer1.Enabled = False
            Dim idString As String = ByteArrayToHexString(id, length)

            Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
                conn.Open()
                ' 1. 基本情報を取得
                Dim sqlBasic = "SELECT ICno, caredid, ruoteiddapo, stationiddapo, gepass, bal FROM iccard WHERE caredid = @cid"
                Dim cmdBasic = New MySqlCommand(sqlBasic, conn)
                cmdBasic.Parameters.AddWithValue("@cid", idString)

                Dim icNo As Integer = 0, gepass As Integer = 0, bal As Integer = 0
                Dim rdepoid As Integer = 0, sdepoid As Integer = 0
                Dim isFound As Boolean = False

                Using reader = cmdBasic.ExecuteReader()
                    If reader.Read() Then
                        isFound = True
                        icNo = Convert.ToInt32(reader("ICno"))
                        newid = reader("caredid").ToString()
                        rdepoid = If(IsDBNull(reader("ruoteiddapo")), 0, Convert.ToInt32(reader("ruoteiddapo")))
                        sdepoid = If(IsDBNull(reader("stationiddapo")), 0, Convert.ToInt32(reader("stationiddapo")))
                        gepass = If(IsDBNull(reader("gepass")), 0, Convert.ToInt32(reader("gepass")))
                        bal = Convert.ToInt32(reader("bal"))
                    End If
                End Using

                If Not isFound Then
                    MessageBox.Show("未登録カード") : Timer1.Enabled = True : Exit Sub
                End If

                ' 2. 定期券(gepass > 0)の場合のみ詳細を取得
                Dim pSR As Integer = 0, pSS As Integer = 0, pER As Integer = 0, pES As Integer = 0
                Dim isPassValid As Boolean = False

                If gepass > 0 Then
                    Dim sqlPass = "SELECT stday, endday, ruoteiddp, stationiddp, ruoteidend, stationidend FROM iccard WHERE ICno = @id"
                    Dim cmdPass = New MySqlCommand(sqlPass, conn)
                    cmdPass.Parameters.AddWithValue("@id", icNo)
                    Using readerP = cmdPass.ExecuteReader()
                        If readerP.Read() Then
                            Dim stDay = If(IsDBNull(readerP("stday")), Date.MinValue, Convert.ToDateTime(readerP("stday")))
                            Dim endDay = If(IsDBNull(readerP("endday")), Date.MinValue, Convert.ToDateTime(readerP("endday")))
                            pSR = If(IsDBNull(readerP("ruoteiddp")), 0, Convert.ToInt32(readerP("ruoteiddp")))
                            pSS = If(IsDBNull(readerP("stationiddp")), 0, Convert.ToInt32(readerP("stationiddp")))
                            pER = If(IsDBNull(readerP("ruoteidend")), 0, Convert.ToInt32(readerP("ruoteidend")))
                            pES = If(IsDBNull(readerP("stationidend")), 0, Convert.ToInt32(readerP("stationidend")))

                            If Date.Today >= stDay AndAlso Date.Today <= endDay Then isPassValid = True
                        End If
                    End Using
                End If

                ' 3. 入場 or 退場判定
                If rdepoid = 0 Then
                    UpdateEntry(conn, icNo) : MoveToGate(icNo, 0)
                Else
                    Dim fare As Integer = 0
                    If isPassValid AndAlso IsWithinPass(rdepoid, sdepoid, ruoteid, stationid, pSR, pSS, pER, pES) Then
                        fare = 0
                    Else
                        fare = GetTotalFare(rdepoid, sdepoid, ruoteid, stationid)
                    End If

                    If fare >= 0 Then
                        If ExecutePayment(conn, icNo, fare, bal, rdepoid, sdepoid) Then
                            MoveToGate(icNo, fare)
                        Else
                            Timer1.Enabled = True
                        End If
                    Else
                        MessageBox.Show("運賃計算不可") : Timer1.Enabled = True
                    End If
                End If
            End Using
        End If
    End Sub

    ' --- 以下、引数を正しく合わせたメソッド群 ---

    ' 【修正】引数を (conn, icNo) に合わせました
    Private Sub UpdateEntry(conn As MySqlConnection, targetIcNo As Integer)
        Using c = New MySqlCommand("UPDATE iccard SET ruoteiddapo = @r, stationiddapo = @s WHERE ICno = @id", conn)
            c.Parameters.AddWithValue("@r", ruoteid)
            c.Parameters.AddWithValue("@s", stationid)
            c.Parameters.AddWithValue("@id", targetIcNo)
            c.ExecuteNonQuery()
        End Using
    End Sub

    ' 【修正】引数を (conn, icNo, fare, bal, rdepoid, sdepoid) に合わせました
    Private Function ExecutePayment(conn As MySqlConnection, targetIcNo As Integer, payFare As Integer, currentBal As Integer, inR As Integer, inS As Integer) As Boolean
        If currentBal < payFare Then
            MessageBox.Show("残高不足: " & payFare & "円必要") : Return False
        End If

        Dim tr = conn.BeginTransaction()
        Try
            Using c = New MySqlCommand("UPDATE iccard SET bal = bal - @f, ruoteiddapo = 0, stationiddapo = 0 WHERE ICno = @id", conn, tr)
                c.Parameters.AddWithValue("@f", payFare)
                c.Parameters.AddWithValue("@id", targetIcNo)
                c.ExecuteNonQuery()
            End Using

            ' 履歴保存用
            Dim inSt = StationList.FirstOrDefault(Function(s) s.RuoID = inR AndAlso s.StationID = inS)
            Dim outSt = StationList.FirstOrDefault(Function(s) s.RuoID = ruoteid AndAlso s.StationID = stationid)
            Dim inName = If(inSt.Name, "不明") : Dim outName = If(outSt.Name, "不明")

            Using c = New MySqlCommand("INSERT INTO resume (ICno, reday, bos, gos, fare) VALUES (@id, CURDATE(), @in, @out, @f)", conn, tr)
                c.Parameters.AddWithValue("@id", targetIcNo)
                c.Parameters.AddWithValue("@in", inName)
                c.Parameters.AddWithValue("@out", outName)
                c.Parameters.AddWithValue("@f", payFare)
                c.ExecuteNonQuery()
            End Using
            tr.Commit() : Return True
        Catch ex As Exception
            tr.Rollback() : MessageBox.Show("決済失敗") : Return False
        End Try
    End Function

    ' 【修正】引数を (icNo, payAmt) に合わせました
    Private Sub MoveToGate(targetIcNo As Integer, payAmt As Integer)
        Dim g As New gate()
        g.ReceivedId = newid
        g.ICId = targetIcNo
        g.pay = payAmt
        g.Show() : Me.Hide()
    End Sub

    ' --- 運賃計算・定期判定ロジック (変更なし) ---
    Private Function GetTotalFare(inR As Integer, inS As Integer, outR As Integer, outS As Integer) As Integer
        Try
            Dim startNode = StationList.First(Function(s) s.RuoID = inR AndAlso s.StationID = inS)
            Dim endNode = StationList.First(Function(s) s.RuoID = outR AndAlso s.StationID = outS)
            If inR = outR Then
                Return GetFare(startNode.CompanyID, Math.Abs(startNode.PointKm - endNode.PointKm))
            End If
            Dim minF As Integer = -1
            FindPath(inR, outR, New List(Of Integer) From {inR}, 0, 0, startNode, endNode, 0, minF)
            Return minF
        Catch
            Return -1
        End Try
    End Function

    Private Sub FindPath(currentR As Integer, targetR As Integer, visitedR As List(Of Integer), jrKm As Double, tobuKm As Double, currentSt As StationData, goalSt As StationData, depth As Integer, ByRef minFare As Integer)
        If depth > 3 Then Exit Sub
        If currentR = targetR Then
            Dim dist = Math.Abs(currentSt.PointKm - goalSt.PointKm)
            Dim fJR = jrKm : Dim fTobu = tobuKm
            If currentSt.CompanyID = 1 Then fJR += dist Else fTobu += dist
            Dim total = GetFare(1, fJR) + GetFare(2, fTobu)
            If minFare = -1 OrElse total < minFare Then minFare = total
            Exit Sub
        End If
        Dim transfers = StationList.Where(Function(s) s.RuoID = currentR).ToList()
        For Each ts In transfers
            Dim nextLines = StationList.Where(Function(s) s.Name = ts.Name AndAlso Not visitedR.Contains(s.RuoID)).ToList()
            For Each nextSt In nextLines
                Dim dist = Math.Abs(currentSt.PointKm - ts.PointKm)
                Dim nJR = jrKm : Dim nTobu = tobuKm
                If ts.CompanyID = 1 Then nJR += dist Else nTobu += dist
                Dim nVisited = New List(Of Integer)(visitedR) : nVisited.Add(nextSt.RuoID)
                FindPath(nextSt.RuoID, targetR, nVisited, nJR, nTobu, nextSt, goalSt, depth + 1, minFare)
            Next
        Next
    End Sub

    Private Function GetFare(busID As Integer, km As Double) As Integer
        If km <= 0 Then Return 0
        Dim row = FareList.Find(Function(f) f.BusID = busID AndAlso km >= f.MinKm AndAlso km < f.MaxKm)
        Return If(row.Price > 0, row.Price, 0)
    End Function

    Private Function IsWithinPass(inR As Integer, inS As Integer, outR As Integer, outS As Integer, pSR As Integer, pSS As Integer, pER As Integer, pES As Integer) As Boolean
        If pSR = 0 Or pER = 0 Then Return False
        Dim passJR, passTobu As Double
        GetMinKm(pSR, pSS, pER, pES, passJR, passTobu)
        Dim inSJR, inSTbu, inEJR, inETbu As Double
        GetMinKm(pSR, pSS, inR, inS, inSJR, inSTbu)
        GetMinKm(inR, inS, pER, pES, inEJR, inETbu)
        Dim outSJR, outSTbu, outEJR, outETbu As Double
        GetMinKm(pSR, pSS, outR, outS, outSJR, outSTbu)
        GetMinKm(outR, outS, pER, pES, outEJR, outETbu)
        Return (Math.Abs(passJR - (inSJR + inEJR)) < 0.1 And Math.Abs(passJR - (outSJR + outEJR)) < 0.1)
    End Function

    Private Sub GetMinKm(inR As Integer, inS As Integer, outR As Integer, outS As Integer, ByRef outJR As Double, ByRef outTobu As Double)
        Dim minJR As Double = 999 : Dim minTbu As Double = 999
        Try
            Dim s = StationList.First(Function(x) x.RuoID = inR And x.StationID = inS)
            Dim e = StationList.First(Function(x) x.RuoID = outR And x.StationID = outS)
            FindDist(inR, outR, New List(Of Integer) From {inR}, 0, 0, s, e, 0, minJR, minTbu)
        Catch
        End Try
        outJR = minJR : outTobu = minTbu
    End Sub

    Private Sub FindDist(currentR As Integer, targetR As Integer, visitedR As List(Of Integer), jrKm As Double, tobuKm As Double, currentSt As StationData, goalSt As StationData, depth As Integer, ByRef minJR As Double, ByRef minTbu As Double)
        If depth > 3 Then Exit Sub
        If currentR = targetR Then
            Dim dist = Math.Abs(currentSt.PointKm - goalSt.PointKm)
            Dim fJR = jrKm : Dim fTbu = tobuKm
            If currentSt.CompanyID = 1 Then fJR += dist Else fTbu += dist
            If (fJR + fTbu) < (minJR + minTbu) Then : minJR = fJR : minTbu = fTbu : End If
            Exit Sub
        End If
        Dim transfers = StationList.Where(Function(s) s.RuoID = currentR).ToList()
        For Each ts In transfers
            Dim nextLines = StationList.Where(Function(s) s.Name = ts.Name AndAlso Not visitedR.Contains(s.RuoID)).ToList()
            For Each nextSt In nextLines
                Dim dist = Math.Abs(currentSt.PointKm - ts.PointKm)
                Dim nJR = jrKm : Dim nTbu = tobuKm
                If ts.CompanyID = 1 Then nJR += dist Else nTbu += dist
                Dim nVisited = New List(Of Integer)(visitedR) : nVisited.Add(nextSt.RuoID)
                FindDist(nextSt.RuoID, targetR, nVisited, nJR, nTbu, nextSt, goalSt, depth + 1, minJR, minTbu)
            Next
        Next
    End Sub

    Private Function ByteArrayToHexString(ByVal ba As Byte(), ByVal len As Integer) As String
        Dim sb As New StringBuilder()
        For i As Integer = 0 To len - 1 : sb.Append(ba(i).ToString("X2")) : Next
        Return sb.ToString()
    End Function
End Class