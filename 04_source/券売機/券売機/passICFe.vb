'Imports MySql.Data.MySqlClient

'Public Class passICFe
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
'        Command.CommandText = $"UPDATE iccard SET stday = '{Std}',endday = '{Endd}',ruoteiddp = {stde},stationiddp = {ststa},depass = '{De}',ruoteidend = {endde},stationidend = {endsta},arpass = '{Ar}',gepass = {Ge},month = {Mont} WHERE ICno = {ReceivedId} "
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

''Imports MySql.Data.MySqlClient

''Public Class passICFe

''    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
''    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
''    Const cardType As Integer = 5     'カードタイプ
''    Public Property ReceivedId As String

''    Dim stdape As String
''    Dim endar As String

''    Private Sub passICFe_Load(sender As Object, e As EventArgs) Handles Me.Load
''        '変数の宣言
''        'Dim data() As Byte        '読込データバッファ
''        'Dim dataLength As Integer   '読込データサイズ
''        Dim id(32) As Byte          'カードID
''        'Dim idLength As Integer     'カードIDサイズ
''        'Dim cardType As Integer     'カードタイプ
''        Dim idString As String = ""      'カードID文字列
''        Dim dataString As String = ""    '結果文字列
''        'Dim result As Integer

''        Dim Connection As New MySqlConnection
''        Dim Command As MySqlCommand
''        Dim DataReader As MySqlDataReader

''        '接続文字列の設定
''        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

''        'オープン
''        Connection.Open()

''        Command = Connection.CreateCommand
''        Command.CommandText = $"SELECT name,seinen,stday,endday,depass,arpass,month FROM iccard WHERE ICno = {ReceivedId} "
''        'SQLを実行
''        DataReader = Command.ExecuteReader

''        If DataReader.Read() Then
''            nametxt.Text = DataReader("name").ToString()
''            nameDTP.Tag = DataReader("seinen").ToString()
''            stDTP.Text = DataReader("stday").ToString()
''            endDTP.Text = DataReader("endday").ToString()
''            deComboBox.Text = DataReader("depass").ToString()
''            arComboBox.Text = DataReader("arpass").ToString()

''            Dim monthValue As Integer = DataReader("month").ToString()

''            Rad1m.Checked = (monthValue = "1")
''            Rad3m.Checked = (monthValue = "3")
''            Rad6m.Checked = (monthValue = "6")
''        End If

''        stdape = deComboBox.Text

''        endar = arComboBox.Text


''        'クローズ
''        DataReader.Close()
''        Connection.Close()

''        'Dispose
''        Command.Dispose()
''        Connection.Dispose()

''        Farepass()

''        'Calculation()
''    End Sub

''    Private Sub Farepass()
''        Dim Connection As New MySqlConnection
''        Dim Command As MySqlCommand
''        Dim DataReader As MySqlDataReader

''        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

''        Try
''            Connection.Open()
''            Command = Connection.CreateCommand

''            ' 月数設定 (Rad1m=1, Rad3m=2, Rad6m=3)
''            Dim mNo As Integer
''            If Rad1m.Checked Then mNo = 1 ' ここをDBの定義(1,2,3)に合わせて調整
''            If Rad3m.Checked Then mNo = 3
''            If Rad6m.Checked Then mNo = 6

''            ' --- 修正点1: caredid を ICno に変更 ---
''            ' --- 修正点2: FLOOR で一致しない可能性を考え >= を推奨しますが、切り下げ指示のため一旦そのまま ---
''            Dim sql As String = "
''SELECT  
''    (
''        IFNULL((SELECT fare FROM farepass  
''                WHERE busid = 1 AND passno = 1 AND motno = @monthNo  
''                AND km = FLOOR(T.JR通算距離)  
''                LIMIT 1), 0) 
''        + 
''        IFNULL((SELECT fare FROM farepass  
''                WHERE busid = 2 AND passno = 1 AND motno = @monthNo  
''                AND km = FLOOR(T.東武通算距離)  
''                LIMIT 1), 0) 
''    ) AS 合計定期運賃
''FROM (
''    SELECT  
''        CASE  
''            WHEN S_start.ruoid <= 3 AND S_end.ruoid <= 3  
''            THEN ABS(S_end.pointkm - S_start.pointkm)
''            ELSE 0 END AS JR通算距離,

''        CASE  
''            WHEN S_start.ruoid = 4 AND S_end.ruoid = 4  
''            THEN ABS(S_end.pointkm - S_start.pointkm)
''            ELSE 0 END AS 東武通算距離
''    FROM  
''        iccard AS I
''        INNER JOIN station AS S_start ON I.depass = S_start.stationname
''        INNER JOIN station AS S_end ON I.arpass = S_end.stationname
''    WHERE  
''        I.ICno = @targetId  -- ★ここを caredid から ICno に修正
''    LIMIT 1
'') AS T;"

''            Command.CommandText = sql
''            ' ReceivedId を文字列として渡す
''            Command.Parameters.AddWithValue("@targetId", ReceivedId)
''            Command.Parameters.AddWithValue("@monthNo", mNo)

''            DataReader = Command.ExecuteReader

''            If DataReader.Read() Then
''                FeLel.Text = DataReader("合計定期運賃").ToString()
''            Else
''                FeLel.Text = "0" ' データが見つからない場合
''            End If

''            DataReader.Close()
''        Catch ex As Exception
''            MessageBox.Show("計算エラー: " & ex.Message)
''        Finally
''            Connection.Close()
''            Connection.Dispose()
''        End Try
''    End Sub

''    Private Sub FeTxt_TextChanged(sender As Object, e As EventArgs) Handles Fetxt.TextChanged
''        Dim tou As Integer = 0

''        Integer.TryParse(Fetxt.Text, tou)

''        Dim sum As Integer = tou - FeLel.Text
''        chLal.Text = sum

''    End Sub
''    Private Sub isbtn_Click(sender As Object, e As EventArgs) Handles isbtn.Click
''        passch.Show()
''        Me.Hide()
''    End Sub

''    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
''        passICn.Show()
''        Me.Hide()
''    End Sub
''End Class

'Imports MySql.Data.MySqlClient

'Public Class passICFe
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
'        Command.CommandText = $"UPDATE iccard SET stday = '{Std}',endday = '{Endd}',ruoteiddp = {stde},stationiddp = {ststa},depass = '{De}',ruoteidend = {endde},stationidend = {endsta},arpass = '{Ar}',gepass = {Ge},month = {Mont} WHERE ICno = {ReceivedId} "
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

Public Class passICFe
    ' --- プロパティ ---
    Public Property ReceivedId As String ' ICnoとして使用
    Public Property Sei As String
    Public Property Seinen As String
    Public Property Std As String
    Public Property Endd As String
    Public Property Mont As Integer
    Public Property De As String
    Public Property Ar As String
    Public Property Ge As Integer
    Public Property Stdate As Date

    Dim stde As Integer
    Dim ststa As Integer
    Dim endde As Integer
    Dim endsta As Integer

    ' 駅データ管理用
    Private Structure StationData
        Public RuoID As Integer
        Public StationID As Integer
        Public Name As String
        Public PointKm As Double
        Public BusID As Integer
    End Structure

    Private StationList As New List(Of StationData)

    ' --- フォームロード ---
    Private Sub passICFe_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        ' 計算実行
        Farepass()
    End Sub

    ' --- 定期運賃計算メイン ---
    Private Sub Farepass()
        LoadStationData()
        RefineStationSelection()

        Dim jrKm As Double = 0
        Dim tobuKm As Double = 0

        ' 最短経路の距離を計算
        CalculateSplitDistance(stde, ststa, endde, endsta, jrKm, tobuKm)

        Dim priceJR As Integer = 0
        Dim priceTobu As Integer = 0

        ' 距離を切り上げて運賃を取得
        If jrKm > 0 Then priceJR = GetPassFareFromDB(1, Ge, Mont, CInt(Math.Ceiling(jrKm)))
        If tobuKm > 0 Then priceTobu = GetPassFareFromDB(2, Ge, Mont, CInt(Math.Ceiling(tobuKm)))

        FeLel.Text = (priceJR + priceTobu).ToString()
    End Sub

    ' --- 駅データのロード ---
    Private Sub LoadStationData()
        StationList.Clear()
        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            conn.Open()
            Dim sql = "SELECT s.ruoid, s.stationid, s.stationname, s.pointkm, r.busid FROM station s JOIN ruote r ON s.ruoid = r.ruoid"
            Using cmd = New MySqlCommand(sql, conn)
                Using r = cmd.ExecuteReader()
                    While r.Read()
                        StationList.Add(New StationData With {
                            .RuoID = r.GetInt32("ruoid"),
                            .StationID = r.GetInt32("stationid"),
                            .Name = r.GetString("stationname"),
                            .PointKm = r.GetDouble("pointkm"),
                            .BusID = r.GetInt32("busid")
                        })
                    End While
                End Using
            End Using
        End Using
    End Sub

    ' --- 東武・JRの適切な路線IDを選択 ---
    Private Sub RefineStationSelection()
        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            conn.Open()
            Dim sql = "SELECT s.ruoid, s.stationid, r.busid FROM station s JOIN ruote r ON s.ruoid = r.ruoid WHERE s.stationname = @name"

            Dim sOpts As New List(Of (rid As Integer, sid As Integer, bid As Integer))
            Using cmd = New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", De)
                Using dr = cmd.ExecuteReader() : While dr.Read() : sOpts.Add((dr(0), dr(1), dr(2))) : End While : End Using
            End Using

            Dim eOpts As New List(Of (rid As Integer, sid As Integer, bid As Integer))
            Using cmd = New MySqlCommand(sql, conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@name", Ar)
                Using dr = cmd.ExecuteReader() : While dr.Read() : eOpts.Add((dr(0), dr(1), dr(2))) : End While : End Using
            End Using

            ' 同一会社(BusID)の路線を優先
            Dim found = False
            For Each s In sOpts
                For Each e In eOpts
                    If s.bid = e.bid Then
                        stde = s.rid : ststa = s.sid : endde = e.rid : endsta = e.sid
                        found = True : Exit For
                    End If
                Next
                If found Then Exit For
            Next
            If Not found And sOpts.Count > 0 And eOpts.Count > 0 Then
                stde = sOpts(0).rid : ststa = sOpts(0).sid : endde = eOpts(0).rid : endsta = eOpts(0).sid
            End If
        End Using
    End Sub

    ' --- 運賃DB検索 ---
    Private Function GetPassFareFromDB(bid As Integer, pno As Integer, mno As Integer, km As Integer) As Integer
        If km > 100 Then km = 100
        Dim fare As Integer = 0
        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            conn.Open()
            Dim sql = "SELECT fare FROM farepass WHERE busid = @bid AND passno = @pno AND motno = @mno AND km = @km"
            Using cmd = New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@bid", bid)
                cmd.Parameters.AddWithValue("@pno", pno)
                cmd.Parameters.AddWithValue("@mno", mno)
                cmd.Parameters.AddWithValue("@km", km)
                Dim res = cmd.ExecuteScalar()
                If res IsNot Nothing Then fare = Convert.ToInt32(res)
            End Using
        End Using
        Return fare
    End Function

    ' --- 経路探索ロジック (CalculateSplitDistance / FindPath は passFe と同様に実装) ---
    Private Sub CalculateSplitDistance(inR As Integer, inS As Integer, outR As Integer, outS As Integer, ByRef resJR As Double, ByRef resTobu As Double)
        Dim startNode = StationList.FirstOrDefault(Function(s) s.RuoID = inR AndAlso s.StationID = inS)
        Dim endNode = StationList.FirstOrDefault(Function(s) s.RuoID = outR AndAlso s.StationID = outS)
        If startNode.Name Is Nothing Or endNode.Name Is Nothing Then Exit Sub

        Dim minTotalDist As Double = 999.0
        FindPath(inR, outR, New List(Of Integer) From {inR}, 0, 0, startNode, endNode, 0, minTotalDist, resJR, resTobu)
    End Sub

    Private Sub FindPath(currentR As Integer, targetR As Integer, visitedR As List(Of Integer), jrKm As Double, tobuKm As Double, currentSt As StationData, goalSt As StationData, depth As Integer, ByRef minTotalDist As Double, ByRef bestJR As Double, ByRef bestTobu As Double)
        If depth > 3 Then Exit Sub
        If currentR = targetR Then
            Dim d = Math.Abs(currentSt.PointKm - goalSt.PointKm)
            Dim fJR = jrKm, fTobu = tobuKm
            If currentSt.BusID = 1 Then fJR += d Else fTobu += d
            If (fJR + fTobu) < minTotalDist Then
                minTotalDist = fJR + fTobu : bestJR = fJR : bestTobu = fTobu
            End If
            Exit Sub
        End If
        ' 乗り換え処理（簡略化して記載）
        For Each st In StationList.Where(Function(s) s.RuoID = currentR)
            For Each nSt In StationList.Where(Function(s) s.Name = st.Name AndAlso Not visitedR.Contains(s.RuoID))
                Dim d = Math.Abs(currentSt.PointKm - st.PointKm)
                Dim nJR = jrKm, nTobu = tobuKm
                If currentSt.BusID = 1 Then nJR += d Else nTobu += d
                Dim nVisited = New List(Of Integer)(visitedR) : nVisited.Add(nSt.RuoID)
                FindPath(nSt.RuoID, targetR, nVisited, nJR, nTobu, nSt, goalSt, depth + 1, minTotalDist, bestJR, bestTobu)
            Next
        Next
    End Sub

    ' --- 更新ボタン (UPDATE文) ---
    Private Sub isbtn_Click(sender As Object, e As EventArgs) Handles isbtn.Click
        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            Try
                conn.Open()
                ' パラメータ化クエリで安全に更新
                Dim sql = "UPDATE iccard SET " &
                          "stday = @sd, endday = @ed, ruoteiddp = @ridp, stationiddp = @sidp, " &
                          "depass = @de, ruoteidend = @riend, stationidend = @siend, " &
                          "arpass = @ar, gepass = @ge, month = @mo " &
                          "WHERE ICno = @icno"

                Using cmd = New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@sd", Std)
                    cmd.Parameters.AddWithValue("@ed", Endd)
                    cmd.Parameters.AddWithValue("@ridp", stde)
                    cmd.Parameters.AddWithValue("@sidp", ststa)
                    cmd.Parameters.AddWithValue("@de", De)
                    cmd.Parameters.AddWithValue("@riend", endde)
                    cmd.Parameters.AddWithValue("@siend", endsta)
                    cmd.Parameters.AddWithValue("@ar", Ar)
                    cmd.Parameters.AddWithValue("@ge", Ge)
                    cmd.Parameters.AddWithValue("@mo", Mont)
                    cmd.Parameters.AddWithValue("@icno", ReceivedId)

                    cmd.ExecuteNonQuery()
                End Using

                passch.Show()
                Me.Hide()
            Catch ex As Exception
                MessageBox.Show("更新エラー: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub FeTxt_TextChanged(sender As Object, e As EventArgs) Handles Fetxt.TextChanged
        Dim tou As Integer = 0
        Integer.TryParse(Fetxt.Text, tou)
        Dim price As Integer = 0
        Integer.TryParse(FeLel.Text, price)
        chLal.Text = (tou - price).ToString()
    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        pass.Show()
        Me.Hide()
    End Sub
End Class