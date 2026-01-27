Imports System.Net
Imports System.Runtime.Intrinsics.Arm
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class gate
    Public Property ReceivedId As Integer

    Private Sub gate_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        Command.CommandText = $"SELECT bal FROM iccard WHERE ICno = {ReceivedId} "
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then
            Label2.Text = DataReader("bal").ToString()

        End If


        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()

        Timer1.Interval = 3000
        Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()

        Dim fnext As New gateend()
        fnext.show()
        Me.Hide()
    End Sub
End Class