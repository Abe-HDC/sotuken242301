'Imports System.Security.Cryptography
'Imports MySql.Data.MySqlClient
'Imports Org.BouncyCastle.Math.EC

'Public Class passcoFe
'    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
'    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
'    Const cardType As Integer = 5     'カードタイプ
'    Public Property ReceivedId As Integer
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

'    Private Sub passcoFe_Load(sender As Object, e As EventArgs) Handles Me.Load
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
'        passcoend.Show()
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
'        passcopay.Show()
'        Me.Hide()
'    End Sub
'End Class

Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports System.Linq

Public Class passcoFe
    ' --- プロパティ ---
    Public Property ReceivedId As Integer ' ICno
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

    ' 駅データ管理用構造体
    Private Structure StationData
        Public RuoID As Integer
        Public StationID As Integer
        Public Name As String
        Public PointKm As Double
        Public BusID As Integer
    End Structure

    Private StationList As New List(Of StationData)

    ' --- フォームロード ---
    Private Sub passcoFe_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' UIセット
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

        ' 運賃計算の実行
        Farepass()
    End Sub

    ' --- 定期運賃計算メイン ---
    Private Sub Farepass()
        ' 1. 駅データをロード
        LoadStationData()

        ' 2. 出発駅・到着駅の組み合わせを最適化 (JR/東武の整合性を取る)
        RefineStationSelection()

        ' 3. 経路探索と距離計算
        Dim jrKm As Double = 0
        Dim tobuKm As Double = 0
        CalculateSplitDistance(stde, ststa, endde, endsta, jrKm, tobuKm)

        ' 4. 運賃取得
        Dim priceJR As Integer = 0
        Dim priceTobu As Integer = 0

        ' 距離を切り上げて整数で検索 (12.1km -> 13km)
        If jrKm > 0 Then priceJR = GetPassFareFromDB(1, Ge, Mont, CInt(Math.Ceiling(jrKm)))
        If tobuKm > 0 Then priceTobu = GetPassFareFromDB(2, Ge, Mont, CInt(Math.Ceiling(tobuKm)))

        ' 合計を表示
        FeLel.Text = (priceJR + priceTobu).ToString()
    End Sub

    ' --- DBから全駅情報を取得 (ruoteと結合してBusIDを得る) ---
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

    ' --- 重複駅名から最適な路線IDを決定する ---
    Private Sub RefineStationSelection()
        ' 出発・到着の候補を取得
        Dim sOpts = StationList.Where(Function(s) s.Name = De).ToList()
        Dim eOpts = StationList.Where(Function(s) s.Name = Ar).ToList()

        Dim found = False
        ' 同じ会社(BusID)の路線がある組み合わせを優先
        For Each s In sOpts
            For Each e In eOpts
                If s.BusID = e.BusID Then
                    stde = s.RuoID : ststa = s.StationID
                    endde = e.RuoID : endsta = e.StationID
                    found = True : Exit For
                End If
            Next
            If found Then Exit For
        Next

        ' 見つからない場合は各候補の1件目
        If Not found And sOpts.Count > 0 And eOpts.Count > 0 Then
            stde = sOpts(0).RuoID : ststa = sOpts(0).StationID
            endde = eOpts(0).RuoID : endsta = eOpts(0).StationID
        End If
    End Sub

    ' --- 運賃DB(farepass)の検索 ---
    Private Function GetPassFareFromDB(bid As Integer, pno As Integer, mno As Integer, km As Integer) As Integer
        If km > 100 Then km = 100 ' 上限ガード
        Dim resFare As Integer = 0
        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            conn.Open()
            Dim sql = "SELECT fare FROM farepass WHERE busid = @bid AND passno = @pno AND motno = @mno AND km = @km"
            Using cmd = New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@bid", bid)
                cmd.Parameters.AddWithValue("@pno", pno)
                cmd.Parameters.AddWithValue("@mno", mno)
                cmd.Parameters.AddWithValue("@km", km)
                Dim val = cmd.ExecuteScalar()
                If val IsNot Nothing Then resFare = Convert.ToInt32(val)
            End Using
        End Using
        Return resFare
    End Function

    ' --- 距離計算 (再帰探索) ---
    Private Sub CalculateSplitDistance(inR As Integer, inS As Integer, outR As Integer, outS As Integer, ByRef resJR As Double, ByRef resTobu As Double)
        Dim startNode = StationList.FirstOrDefault(Function(s) s.RuoID = inR AndAlso s.StationID = inS)
        Dim endNode = StationList.FirstOrDefault(Function(s) s.RuoID = outR AndAlso s.StationID = outS)
        If startNode.Name Is Nothing Or endNode.Name Is Nothing Then Exit Sub

        Dim minTotalDist As Double = 9999.0
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
        ' 乗り換え検索
        Dim currentLineStations = StationList.Where(Function(s) s.RuoID = currentR).ToList()
        For Each st In currentLineStations
            Dim transfers = StationList.Where(Function(s) s.Name = st.Name AndAlso Not visitedR.Contains(s.RuoID)).ToList()
            For Each nSt In transfers
                Dim d = Math.Abs(currentSt.PointKm - st.PointKm)
                Dim nJR = jrKm, nTobu = tobuKm
                If currentSt.BusID = 1 Then nJR += d Else nTobu += d
                Dim nVisited = New List(Of Integer)(visitedR) : nVisited.Add(nSt.RuoID)
                FindPath(nSt.RuoID, targetR, nVisited, nJR, nTobu, nSt, goalSt, depth + 1, minTotalDist, bestJR, bestTobu)
            Next
        Next
    End Sub

    ' --- 更新ボタン (UPDATE実行) ---
    Private Sub isbtn_Click(sender As Object, e As EventArgs) Handles isbtn.Click
        ' 最新のID情報を確定
        RefineStationSelection()

        Using conn As New MySqlConnection("Database=sotuken242301;Data Source=localhost;User Id=root")
            Try
                conn.Open()
                ' パラメータ化されたUPDATE文
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

                passcoend.Show()
                Me.Hide()
            Catch ex As Exception
                MessageBox.Show("更新エラー: " & ex.Message)
            End Try
        End Using
    End Sub

    ' --- テキスト変更時計算 (お釣り計算など) ---
    Private Sub FeTxt_TextChanged(sender As Object, e As EventArgs) Handles Fetxt.TextChanged
        Dim tou As Integer = 0
        Integer.TryParse(Fetxt.Text, tou)
        Dim price As Integer = 0
        Integer.TryParse(FeLel.Text, price)
        chLal.Text = (tou - price).ToString()
    End Sub

    ' --- 戻るボタン ---
    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        passcopay.Show()
        Me.Hide()
    End Sub

    ' 不要になった古いメソッドは削除または無効化
    Private Sub Calculationst() : End Sub
    Private Sub Calculationend() : End Sub
End Class