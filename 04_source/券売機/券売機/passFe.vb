'Imports MySql.Data.MySqlClient

'Public Class passFe
'    Public Property ReceivedId As String
'    Public Property Sei As String
'    Public Property Seinen As String
'    Public Property Std As String
'    Public Property Endd As String
'    Public Property Mont As Integer
'    Public Property De As String
'    Public Property Ar As String
'    Public Property Ge As Integer
'    Public Property Stdate As Date


'    Dim stdape As String
'    Dim endar As String

'    Dim stde As Integer
'    Dim ststa As Integer

'    Dim endde As Integer
'    Dim endsta As Integer


'    Private Sub passFe_Load(sender As Object, e As EventArgs) Handles Me.Load

'        nametxt.Text = Sei
'        nameDTP.Text = Seinen
'        stDTP.Text = Std
'        endDTP.Text = Endd
'        deComboBox.Text = De
'        arComboBox.Text = Ar

'        If Mont = 1 Then
'            Rad1m.Checked = True
'        ElseIf Mont = 3 Then
'            Rad3m.Checked = True
'        ElseIf Mont = 6 Then
'            Rad6m.Checked = True
'        End If

'        stdape = deComboBox.Text

'        endar = arComboBox.Text

'        Farepass()

'    End Sub

'    Private Sub Farepass()

'    End Sub


'    Private Sub FeTxt_TextChanged(sender As Object, e As EventArgs) Handles Fetxt.TextChanged
'        Dim tou As Integer = 0

'        Integer.TryParse(Fetxt.Text, tou)

'        Dim sum As Integer = tou - FeLel.Text
'        chLal.Text = sum

'    End Sub

'    Private Sub isbtn_Click(sender As Object, e As EventArgs) Handles isbtn.Click
'        Calculationst()
'        Calculationend()
'        Dim Connection As New MySqlConnection
'        Dim Command As MySqlCommand
'        Dim DataReader As MySqlDataReader

'        Calculationst()
'        Calculationend()


'        '接続文字列の設定
'        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

'        'オープン
'        Connection.Open()

'        Command = Connection.CreateCommand
'        Command.CommandText = $"INSERT INTO iccard(name,seinen,stday,endday,ruoteiddp,stationiddp,depass,ruoteidend,stationidend,arpass,gepass,month,caredid) VALUES ('{Sei}','{Seinen}','{Std}','{Endd}',{stde},{ststa},'{De}',{endde},{endsta},'{Ar}',{Ge},{Mont},'{ReceivedId}'); "
'        'SQLを実行
'        DataReader = Command.ExecuteReader

'        'クローズ
'        DataReader.Close()
'        Connection.Close()

'        'Dispose
'        Command.Dispose()
'        Connection.Dispose()
'        passch.Show()
'        Me.Hide()
'    End Sub

'    Private Sub Calculationst()
'        Dim Connection As New MySqlConnection
'        Dim Command As MySqlCommand
'        Dim DataReader As MySqlDataReader


'        '接続文字列の設定
'        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

'        'オープン
'        Connection.Open()

'        Command = Connection.CreateCommand
'        Command.CommandText = $"SELECT ruoid,stationid FROM station WHERE stationname = '{De}'"
'        'SQLを実行
'        DataReader = Command.ExecuteReader

'        If DataReader.Read() Then
'            stde = DataReader("ruoid").ToString()
'            ststa = DataReader("stationid").ToString()
'        End If

'        'クローズ
'        DataReader.Close()
'        Connection.Close()

'        'Dispose
'        Command.Dispose()
'        Connection.Dispose()
'    End Sub

'    Private Sub Calculationend()
'        Dim Connection As New MySqlConnection
'        Dim Command As MySqlCommand
'        Dim DataReader As MySqlDataReader


'        '接続文字列の設定
'        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

'        'オープン
'        Connection.Open()

'        Command = Connection.CreateCommand
'        Command.CommandText = $"SELECT ruoid,stationid FROM station WHERE stationname = '{Ar}' "
'        'SQLを実行
'        DataReader = Command.ExecuteReader

'        If DataReader.Read() Then
'            endde = DataReader("ruoid").ToString()
'            endsta = DataReader("stationid").ToString()
'        End If

'        'クローズ
'        DataReader.Close()
'        Connection.Close()

'        'Dispose
'        Command.Dispose()
'        Connection.Dispose()
'    End Sub

'    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
'        pass.Show()
'        Me.Hide()
'    End Sub
'End Class

Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports System.Linq

Public Class passFe
    ' --- プロパティ定義（既存のまま） ---
    Public Property ReceivedId As String
    Public Property Sei As String
    Public Property Seinen As String
    Public Property Std As String
    Public Property Endd As String
    Public Property Mont As Integer ' 期間 (1, 3, 6)
    Public Property De As String    ' 出発駅名
    Public Property Ar As String    ' 到着駅名
    Public Property Ge As Integer   ' 定期種別 (1:通勤, 2:通学... と仮定)
    Public Property Stdate As Date

    Dim stdape As String
    Dim endar As String
    Dim stde As Integer    ' 出発路線ID
    Dim ststa As Integer   ' 出発駅ID
    Dim endde As Integer   ' 到着路線ID
    Dim endsta As Integer  ' 到着駅ID

    ' --- 駅データ管理用の構造体 ---
    Private Structure StationData
        Public RuoID As Integer
        Public StationID As Integer
        Public Name As String
        Public PointKm As Double
        Public BusID As Integer ' 1: JR, 2: 東武 (ruoteテーブルから取得)
    End Structure

    ' 駅リストをメモリに保持
    Private StationList As New List(Of StationData)

    ' --- フォームロード ---
    Private Sub passFe_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' UIへのセット
        nametxt.Text = Sei
        nameDTP.Text = Seinen
        stDTP.Text = Std
        endDTP.Text = Endd
        deComboBox.Text = De
        arComboBox.Text = Ar

        If Mont = 1 Then
            Rad1m.Checked = True
        ElseIf Mont = 3 Then
            Rad3m.Checked = True
        ElseIf Mont = 6 Then
            Rad6m.Checked = True
        End If

        stdape = deComboBox.Text
        endar = arComboBox.Text

        ' 駅名からIDを取得 (DBアクセス)
        Calculationst()
        Calculationend()

        ' 定期運賃計算の実行
        Farepass()
    End Sub

    ' ==========================================
    '   ここから運賃計算ロジック
    ' ==========================================

    ' --- 定期運賃計算のメイン処理 ---
    'Private Sub Farepass()
    '    ' 1. 駅データをメモリにロード (まだロードしていなければ)
    '    '    ruoteテーブルと結合してBusID(会社)も取得します
    '    If StationList.Count = 0 Then LoadStationData()

    '    ' 値チェック
    '    If stde = 0 Or endde = 0 Then
    '        FeLel.Text = "0"
    '        Exit Sub
    '    End If

    '    ' 2. 経路探索と距離計算
    '    Dim jrKm As Double = 0
    '    Dim tobuKm As Double = 0

    '    ' 最短経路の距離を計算して jrKm, tobuKm に代入
    '    CalculateSplitDistance(stde, ststa, endde, endsta, jrKm, tobuKm)

    '    ' 3. DB(farepassテーブル)から運賃を取得
    '    Dim priceJR As Integer = 0
    '    Dim priceTobu As Integer = 0

    '    ' 距離は切り上げで計算 (例: 12.1km → 13kmの料金を参照)
    '    Dim searchKmJR As Integer = CInt(Math.Ceiling(jrKm))
    '    Dim searchKmTobu As Integer = CInt(Math.Ceiling(tobuKm))

    '    ' busid=1 (JR) の運賃取得
    '    If searchKmJR > 0 Then
    '        priceJR = GetPassFareFromDB(1, Ge, Mont, searchKmJR)
    '    End If

    '    ' busid=2 (東武) の運賃取得
    '    If searchKmTobu > 0 Then
    '        priceTobu = GetPassFareFromDB(2, Ge, Mont, searchKmTobu)
    '    End If

    '    ' 4. 合計を表示
    '    Dim totalFare As Integer = priceJR + priceTobu
    '    FeLel.Text = totalFare.ToString()
    'End Sub
    Private Sub Farepass()
        ' 1. 駅データをロード（BusIDを含む最新版）
        LoadStationData()

        ' 2. 出発駅・到着駅のIDを確定させる（ここで東武線を優先的に探す）
        RefineStationSelection()

        ' 3. 経路探索と距離計算
        Dim jrKm As Double = 0
        Dim tobuKm As Double = 0
        CalculateSplitDistance(stde, ststa, endde, endsta, jrKm, tobuKm)

        ' 4. DBから運賃を取得
        Dim priceJR As Integer = 0
        Dim priceTobu As Integer = 0

        ' 距離を切り上げて整数にする (12.2km -> 13km)
        Dim intKmJR As Integer = CInt(Math.Ceiling(jrKm))
        Dim intKmTobu As Integer = CInt(Math.Ceiling(tobuKm))

        ' JR (busid=1) の運賃
        If intKmJR > 0 Then
            priceJR = GetPassFareFromDB(1, Ge, Mont, intKmJR)
        End If

        ' 東武 (busid=2) の運賃
        If intKmTobu > 0 Then
            priceTobu = GetPassFareFromDB(2, Ge, Mont, intKmTobu)
        End If

        ' 5. 表示
        Dim totalFare As Integer = priceJR + priceTobu
        If totalFare = 0 Then
            MessageBox.Show("料金が見つかりませんでした。DBのfarepassテーブルに該当データがあるか確認してください。" & vbCrLf &
                        "条件: BusID=" & If(intKmTobu > 0, "2", "1") & ", PassNo=" & Ge & ", Month=" & Mont & ", Km=" & Math.Max(intKmJR, intKmTobu))
        End If
        FeLel.Text = totalFare.ToString()
    End Sub

    ' --- 改良版：駅選択の最適化 ---
    Private Sub RefineStationSelection()
        ' 伊勢崎駅のように複数路線ある場合、出発と到着で同じ会社(busid)になる組み合わせを優先する
        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            conn.Open()

            ' 出発駅の候補リストを取得
            Dim sqlSt = "SELECT s.ruoid, s.stationid, r.busid FROM station s JOIN ruote r ON s.ruoid = r.ruoid WHERE s.stationname = @name"
            Dim startOptions As New List(Of (rid As Integer, sid As Integer, bid As Integer))
            Using cmd = New MySqlCommand(sqlSt, conn)
                cmd.Parameters.AddWithValue("@name", De)
                Using dr = cmd.ExecuteReader()
                    While dr.Read() : startOptions.Add((dr("ruoid"), dr("stationid"), dr("busid"))) : End While
                End Using
            End Using

            ' 到着駅の候補リストを取得
            Dim endOptions As New List(Of (rid As Integer, sid As Integer, bid As Integer))
            Using cmd = New MySqlCommand(sqlSt, conn)
                cmd.Parameters.AddWithValue("@name", Ar)
                Using dr = cmd.ExecuteReader()
                    While dr.Read() : endOptions.Add((dr("ruoid"), dr("stationid"), dr("busid"))) : End While
                End Using
            End Using

            ' 同じBusID（会社）の組み合わせがあればそれを優先
            Dim foundMatch As Boolean = False
            For Each s In startOptions
                For Each e In endOptions
                    If s.bid = e.bid Then
                        stde = s.rid : ststa = s.sid
                        endde = e.rid : endsta = e.sid
                        foundMatch = True : Exit For
                    End If
                Next
                If foundMatch Then Exit For
            Next

            ' マッチしなければ最初の候補を使用
            If Not foundMatch AndAlso startOptions.Count > 0 AndAlso endOptions.Count > 0 Then
                stde = startOptions(0).rid : ststa = startOptions(0).sid
                endde = endOptions(0).rid : endsta = endOptions(0).sid
            End If
        End Using
    End Sub

    ' --- 駅データのロード (station + ruote結合) ---
    Private Sub LoadStationData()
        StationList.Clear()
        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            conn.Open()
            ' stationテーブルとruoteテーブルを結合し、busidも取得する
            Dim sql As String = "SELECT s.ruoid, s.stationid, s.stationname, s.pointkm, r.busid " &
                                "FROM station s " &
                                "JOIN ruote r ON s.ruoid = r.ruoid"
            Dim cmd = New MySqlCommand(sql, conn)
            Using r = cmd.ExecuteReader()
                While r.Read()
                    StationList.Add(New StationData With {
                        .RuoID = r.GetInt32("ruoid"),
                        .StationID = r.GetInt32("stationid"),
                        .Name = r.GetString("stationname"),
                        .PointKm = r.GetDouble("pointkm"),
                        .BusID = r.GetInt32("busid") ' 1=JR, 2=東武
                    })
                End While
            End Using
        End Using
    End Sub

    ' --- データベースから定期運賃を取得 (farepassテーブル) ---
    'Private Function GetPassFareFromDB(targetBusId As Integer, targetPassNo As Integer, targetMotNo As Integer, distKm As Integer) As Integer
    '    Dim fare As Integer = 0

    '    ' 距離が100kmを超える場合は100kmとして扱う（またはエラー処理）
    '    If distKm > 100 Then distKm = 100

    '    Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
    '        conn.Open()
    '        ' farepassテーブル: busid, passno(種類), motno(期間), km, fare
    '        Dim sql As String = "SELECT fare FROM farepass WHERE busid = @bid AND passno = @pno AND motno = @mno AND km = @km"

    '        Using cmd As New MySqlCommand(sql, conn)
    '            cmd.Parameters.AddWithValue("@bid", targetBusId)
    '            cmd.Parameters.AddWithValue("@pno", targetPassNo) ' Geプロパティを使用
    '            cmd.Parameters.AddWithValue("@mno", targetMotNo)  ' Montプロパティを使用
    '            cmd.Parameters.AddWithValue("@km", distKm)

    '            Dim result = cmd.ExecuteScalar()
    '            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
    '                fare = Convert.ToInt32(result)
    '            End If
    '        End Using
    '    End Using
    '    Return fare
    'End Function

    ' --- 経路探索のエントリーポイント ---

    Private Function GetPassFareFromDB(bid As Integer, pno As Integer, mno As Integer, km As Integer) As Integer
        Dim res As Integer = 0
        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            conn.Open()
            ' あなたのSQLに合わせてカラム名を調整しています
            ' busid, passno, motno, km, fare
            Dim sql = "SELECT fare FROM farepass WHERE busid = @bid AND passno = @pno AND motno = @mno AND km = @km"
            Using cmd = New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@bid", bid)
                cmd.Parameters.AddWithValue("@pno", pno)
                cmd.Parameters.AddWithValue("@mno", mno)
                cmd.Parameters.AddWithValue("@km", km)
                Dim val = cmd.ExecuteScalar()
                If val IsNot Nothing Then res = Convert.ToInt32(val)
            End Using
        End Using
        Return res
    End Function
    Private Sub CalculateSplitDistance(inR As Integer, inS As Integer, outR As Integer, outS As Integer, ByRef resJR As Double, ByRef resTobu As Double)
        Dim startNode = StationList.FirstOrDefault(Function(s) s.RuoID = inR AndAlso s.StationID = inS)
        Dim endNode = StationList.FirstOrDefault(Function(s) s.RuoID = outR AndAlso s.StationID = outS)

        If startNode.Name Is Nothing Or endNode.Name Is Nothing Then Exit Sub

        Dim minTotalDist As Double = 9999.0
        Dim bestJR As Double = 0
        Dim bestTobu As Double = 0

        ' 再帰探索開始
        FindPath(inR, outR, New List(Of Integer) From {inR}, 0, 0, startNode, endNode, 0, minTotalDist, bestJR, bestTobu)

        resJR = bestJR
        resTobu = bestTobu
    End Sub

    ' --- 再帰的経路探索ロジック ---
    Private Sub FindPath(currentR As Integer, targetR As Integer, visitedR As List(Of Integer),
                         jrKm As Double, tobuKm As Double, currentSt As StationData,
                         goalSt As StationData, depth As Integer,
                         ByRef minTotalDist As Double, ByRef bestJR As Double, ByRef bestTobu As Double)

        ' 乗り換え回数制限 (深さ3まで)
        If depth > 3 Then Exit Sub

        ' 同じ路線にいる場合、ゴール判定
        If currentR = targetR Then
            Dim dist = Math.Abs(currentSt.PointKm - goalSt.PointKm)
            Dim finalJR = jrKm
            Dim finalTobu = tobuKm

            ' 現在の駅の会社IDで加算先を分岐
            If currentSt.BusID = 1 Then finalJR += dist Else finalTobu += dist

            Dim total = finalJR + finalTobu

            ' 最短距離なら更新
            If total < minTotalDist Then
                minTotalDist = total
                bestJR = finalJR
                bestTobu = finalTobu
            End If
            Exit Sub
        End If

        ' 乗り換え駅を探す
        Dim currentLineStations = StationList.Where(Function(s) s.RuoID = currentR).ToList()
        For Each st In currentLineStations
            ' 同じ名前で、まだ乗っていない別の路線の駅を探す
            Dim transferStations = StationList.Where(Function(s) s.Name = st.Name AndAlso Not visitedR.Contains(s.RuoID)).ToList()

            For Each nextSt In transferStations
                ' 現在地から乗換駅までの距離
                Dim dist = Math.Abs(currentSt.PointKm - st.PointKm)
                Dim nextJR = jrKm
                Dim nextTobu = tobuKm
                If currentSt.BusID = 1 Then nextJR += dist Else nextTobu += dist

                ' 次の路線へ再帰
                Dim nextVisited = New List(Of Integer)(visitedR)
                nextVisited.Add(nextSt.RuoID)
                FindPath(nextSt.RuoID, targetR, nextVisited, nextJR, nextTobu, nextSt, goalSt, depth + 1, minTotalDist, bestJR, bestTobu)
            Next
        Next
    End Sub

    ' ==========================================
    '   イベントハンドラ・その他
    ' ==========================================

    Private Sub FeTxt_TextChanged(sender As Object, e As EventArgs) Handles Fetxt.TextChanged
        Dim tou As Integer = 0
        Integer.TryParse(Fetxt.Text, tou)

        Dim price As Integer = 0
        Integer.TryParse(FeLel.Text, price)

        Dim sum As Integer = tou - price
        chLal.Text = sum.ToString()
    End Sub

    Private Sub isbtn_Click(sender As Object, e As EventArgs) Handles isbtn.Click
        If stde = 0 Or endde = 0 Then
            MessageBox.Show("駅情報が正しく取得できていません。")
            Exit Sub
        End If

        Using Connection As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            Try
                Connection.Open()
                Dim Command = Connection.CreateCommand
                ' パラメータ化クエリでSQLインジェクション対策
                Command.CommandText = "INSERT INTO iccard(name,seinen,stday,endday,ruoteiddp,stationiddp,depass,ruoteidend,stationidend,arpass,gepass,month,caredid) " &
                                      "VALUES (@nm, @sn, @sd, @ed, @rdp, @sdp, @dp, @rend, @send, @ap, @gp, @mt, @cid)"
                Command.Parameters.AddWithValue("@nm", Sei)
                Command.Parameters.AddWithValue("@sn", Seinen)
                Command.Parameters.AddWithValue("@sd", Std)
                Command.Parameters.AddWithValue("@ed", Endd)
                Command.Parameters.AddWithValue("@rdp", stde)
                Command.Parameters.AddWithValue("@sdp", ststa)
                Command.Parameters.AddWithValue("@dp", De)
                Command.Parameters.AddWithValue("@rend", endde)
                Command.Parameters.AddWithValue("@send", endsta)
                Command.Parameters.AddWithValue("@ap", Ar)
                Command.Parameters.AddWithValue("@gp", Ge)
                Command.Parameters.AddWithValue("@mt", Mont)
                Command.Parameters.AddWithValue("@cid", ReceivedId)

                Command.ExecuteNonQuery()

                passch.Show()
                Me.Hide()
            Catch ex As Exception
                MessageBox.Show("登録エラー: " & ex.Message)
            End Try
        End Using
    End Sub

    ' 駅名からIDを取得
    Private Sub Calculationst()
        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT ruoid, stationid FROM station WHERE stationname = @name", conn)
            cmd.Parameters.AddWithValue("@name", De)
            Using dr = cmd.ExecuteReader()
                If dr.Read() Then
                    stde = Convert.ToInt32(dr("ruoid"))
                    ststa = Convert.ToInt32(dr("stationid"))
                End If
            End Using
        End Using
    End Sub

    Private Sub Calculationend()
        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT ruoid, stationid FROM station WHERE stationname = @name", conn)
            cmd.Parameters.AddWithValue("@name", Ar)
            Using dr = cmd.ExecuteReader()
                If dr.Read() Then
                    endde = Convert.ToInt32(dr("ruoid"))
                    endsta = Convert.ToInt32(dr("stationid"))
                End If
            End Using
        End Using
    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        pass.Show()
        Me.Hide()
    End Sub
End Class