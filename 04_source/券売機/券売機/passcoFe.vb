Imports MySql.Data.MySqlClient

Public Class passcoFe
    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Const cardType As Integer = 5     'カードタイプ
    Public Property ReceivedId As Integer

    Dim stdape As String
    Dim endar As String

    Private Sub passcoFe_Load(sender As Object, e As EventArgs) Handles Me.Load
        '変数の宣言
        'Dim data() As Byte        '読込データバッファ
        'Dim dataLength As Integer   '読込データサイズ
        Dim id(32) As Byte          'カードID
        'Dim idLength As Integer     'カードIDサイズ
        'Dim cardType As Integer     'カードタイプ
        Dim idString As String = ""      'カードID文字列
        Dim dataString As String = ""    '結果文字列
        'Dim result As Integer

        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT name,seinen,stday,endday,depass,arpass,month FROM iccard WHERE ICno = {ReceivedId} "
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then
            nametxt.Text = DataReader("name").ToString()
            nameDTP.Tag = DataReader("seinen").ToString()
            stDTP.Text = DataReader("stday").ToString()
            endDTP.Text = DataReader("endday").ToString()
            deComboBox.Text = DataReader("depass").ToString()
            arComboBox.Text = DataReader("arpass").ToString()

            Dim monthValue As Integer = DataReader("month").ToString()

            Rad1m.Checked = (monthValue = "1")
            Rad3m.Checked = (monthValue = "3")
            Rad6m.Checked = (monthValue = "6")
        End If

        stdape = deComboBox.Text

        endar = arComboBox.Text


        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        Farepass()

        'Calculation()
    End Sub

    Private Sub Farepass()
        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        Try
            Connection.Open()
            Command = Connection.CreateCommand

            ' 月数設定 (Rad1m=1, Rad3m=2, Rad6m=3)
            Dim mNo As Integer
            If Rad1m.Checked Then mNo = 1 ' ここをDBの定義(1,2,3)に合わせて調整
            If Rad3m.Checked Then mNo = 3
            If Rad6m.Checked Then mNo = 6

            ' --- 修正点1: caredid を ICno に変更 ---
            ' --- 修正点2: FLOOR で一致しない可能性を考え >= を推奨しますが、切り下げ指示のため一旦そのまま ---
            Dim sql As String = "
SELECT  
    (
        IFNULL((SELECT fare FROM farepass  
                WHERE busid = 1 AND passno = 1 AND motno = @monthNo  
                AND km = FLOOR(T.JR通算距離)  
                LIMIT 1), 0) 
        + 
        IFNULL((SELECT fare FROM farepass  
                WHERE busid = 2 AND passno = 1 AND motno = @monthNo  
                AND km = FLOOR(T.東武通算距離)  
                LIMIT 1), 0) 
    ) AS 合計定期運賃
FROM (
    SELECT  
        CASE  
            WHEN S_start.ruoid <= 3 AND S_end.ruoid <= 3  
            THEN ABS(S_end.pointkm - S_start.pointkm)
            ELSE 0 END AS JR通算距離,
              
        CASE  
            WHEN S_start.ruoid = 4 AND S_end.ruoid = 4  
            THEN ABS(S_end.pointkm - S_start.pointkm)
            ELSE 0 END AS 東武通算距離
    FROM  
        iccard AS I
        INNER JOIN station AS S_start ON I.depass = S_start.stationname
        INNER JOIN station AS S_end ON I.arpass = S_end.stationname
    WHERE  
        I.ICno = @targetId  -- ★ここを caredid から ICno に修正
    LIMIT 1
) AS T;"

            Command.CommandText = sql
            ' ReceivedId を文字列として渡す
            Command.Parameters.AddWithValue("@targetId", ReceivedId)
            Command.Parameters.AddWithValue("@monthNo", mNo)

            DataReader = Command.ExecuteReader

            If DataReader.Read() Then
                FeLel.Text = DataReader("合計定期運賃").ToString()
            Else
                FeLel.Text = "0" ' データが見つからない場合
            End If

            DataReader.Close()
        Catch ex As Exception
            MessageBox.Show("計算エラー: " & ex.Message)
        Finally
            Connection.Close()
            Connection.Dispose()
        End Try
    End Sub

    'Private Sub Calculation()
    '    Dim Connection As New MySqlConnection
    '    Dim Command As MySqlCommand
    '    Dim DataReader As MySqlDataReader

    '    '接続文字列の設定
    '    Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

    '    'オープン
    '    Connection.Open()

    '    Command = Connection.CreateCommand
    '    Command.CommandText = $"SELECT com.busname,iccard.ICno,ABS(s_arr.pointkm - s_dep.pointkm) AS distance,(SELECT f.fare FROM farepass f WHERE f.busid = com.busid AND f.km >= (s_arr.pointkm - s_dep.pointkm) ORDER BY f.km ASC LIMIT 1) AS fare FROM iccard JOIN station AS s_dep ON iccard.depass = s_dep.stationname JOIN station AS s_arr ON iccard.arpass = s_arr.stationname JOIN ruote ON s_dep.ruoid = ruote.ruoid AND s_arr.ruoid = ruote.ruoid JOIN com ON ruote.busid = com.busid WHERE iccard.ICno = {ReceivedId}; "
    '    'SQLを実行
    '    DataReader = Command.ExecuteReader

    '    If DataReader.Read() Then
    '        FeLel.Text = DataReader("fare").ToString()
    '    End If


    '    'クローズ
    '    DataReader.Close()
    '    Connection.Close()

    '    'Dispose
    '    Command.Dispose()
    '    Connection.Dispose()
    'End Sub

    Private Sub FeTxt_TextChanged(sender As Object, e As EventArgs) Handles Fetxt.TextChanged
        Dim tou As Integer = 0

        Integer.TryParse(Fetxt.Text, tou)

        Dim sum As Integer = tou - FeLel.Text
        chLal.Text = sum

    End Sub
    Private Sub isbtn_Click(sender As Object, e As EventArgs) Handles isbtn.Click
        passcoend.Show()
        Me.Hide()
    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        passcopay.Show()
        Me.Hide()
    End Sub
End Class