Imports System.Net
Imports System.Runtime.Intrinsics.Arm
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class gate
    Public Property ReceivedId As String

    Public Property ICId As Integer
    Public Property pay As Integer

    Dim niti As String

    Private Sub gate_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' 画面の作業領域（タスクバーを除く）
        Dim wa = Screen.PrimaryScreen.WorkingArea

        ' 幅と高さを 1/4 に
        Me.Width = wa.Width \ 2
        Me.Height = wa.Height \ 2

        ' 左上に配置
        Me.Left = wa.Left
        Me.Top = wa.Bottom - Me.Height

        baldis()
        Label3.Text = pay
        Timer1.Interval = 3000
        Timer1.Start()
    End Sub
    Private Sub baldis()
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
        Command.CommandText = $"SELECT bal,endday FROM iccard WHERE ICno = {ICId} "
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then
            Label2.Text = DataReader("bal").ToString()
            'niti = DataReader("endday").ToString()
        End If

        'If niti.Length = 0 Then
        'Else
        '    Label5.Text = niti
        'End If


        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()

        Dim fnext As New sentaku()
        fnext.show()
        Me.Hide()
    End Sub
End Class