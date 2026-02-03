Imports MySql.Data.MySqlClient

Public Class ICsad
    Public Property ReceivedId As Integer

    Private Sub ICsad_Load(sender As Object, e As EventArgs) Handles Me.Load
        DisplayBalance()
    End Sub

    Private Sub DisplayBalance()
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
        Command.CommandText = $"SELECT iccard.name 名前,iccard.seinen 生年月日,iccard.stday 定期開始日,iccard.endday 定期終了日,iccard.depass 出発駅,iccard.arpass 到着駅,iccard.gepass 種類,iccard.month 月数,resume.reday 利用日時,resume.bos 乗車駅,resume.gos 降車駅,resume.fare 運賃 FROM iccard JOIN resume ON iccard.ICno = resume.ICno WHERE iccard.ICno = {ReceivedId}"
        'SQLを実行
        DataReader = Command.ExecuteReader

        Dim dt As New DataTable()

        dt.Load(DataReader)

        adDGV.DataSource = dt

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        'If result = 0 Then

        '    Dim nextForm As New ICcharge()
        '    nextForm.ReceivedId = ReceivedId ' IDを渡す
        'End If
    End Sub

    Private Sub hyozi_Click(sender As Object, e As EventArgs) Handles hyozi.Click
        '変数の宣言
        'Dim data() As Byte        '読込データバッファ
        'Dim dataLength As Integer   '読込データサイズ
        Dim id(32) As Byte          'カードID
        'Dim idLength As Integer     'カードIDサイズ
        'Dim cardType As Integer     'カードタイプ
        Dim idString As String = ""      'カードID文字列
        Dim dataString As String = ""    '結果文字列
        'Dim result As Integer
        Dim stD As String = stDTP.Value.ToString("yyyy/MM/dd")
        Dim endD As String = endDTP.Value.ToString("yyyy/MM/dd")


        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader

        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT iccard.name 名前,iccard.seinen 生年月日,iccard.stday 定期開始日,iccard.endday 定期終了日,iccard.depass 出発駅,iccard.arpass 到着駅,iccard.gepass 種類,iccard.month 月数,resume.reday 利用日時,resume.bos 乗車駅,resume.gos 降車駅,resume.fare 運賃 FROM iccard JOIN resume ON iccard.ICno = resume.ICno WHERE ICno = {ReceivedId} AND reday >= '{stD}' AND reday <= '{endD}' "
        'SQLを実行
        DataReader = Command.ExecuteReader

        Dim dt As New DataTable()

        dt.Load(DataReader)

        adDGV.DataSource = dt

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()
    End Sub

    Private Sub isbtn_Click(sender As Object, e As EventArgs) Handles isbtn.Click
        ICsreis.Show()
        Me.Hide()
    End Sub
End Class