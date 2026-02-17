Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Google.Protobuf.Reflection.FieldDescriptorProto.Types
Imports MySql.Data.MySqlClient

Public Class isICpay

    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Const cardType As Integer = 5     'カードタイプ

    Public Property ReceivedId As Integer
    Private Sub Febtn_Click(sender As Object, e As EventArgs) Handles Febtn.Click
        isICend.Show()
        Me.Hide()
    End Sub

    Private Sub isICpay_Load(sender As Object, e As EventArgs) Handles Me.Load
        '変数の宣言
        Dim data(40) As Byte        '読込データバッファ
        'Dim dataLength As Integer   '読込データサイズ
        Dim id(10) As Byte          'カードID
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
        Command.CommandText = $"SELECT name,seinen,bal FROM iccard WHERE ICno = {ReceivedId}"
        'SQLを実行
        DataReader = Command.ExecuteReader


        ''書込データを作成
        'data = System.Text.Encoding.Unicode.GetBytes(dataString)
        'dataLength = data.Length

        ''データ書込み
        'result = OTWriteData(data(0), dataLength, id(0), idLength, cardType)

        If DataReader.Read() Then

            nametxt.Text = DataReader("name").ToString()

            nameDTP.Text = DataReader("seinen").ToString()

            Dim currentBal As Integer = 0
            If Not IsDBNull(DataReader("bal")) Then
                currentBal = Convert.ToInt32(DataReader("bal"))
            End If


            FeLel.Text = (currentBal + 500).ToString()
        End If


        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()


    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        isIC.Show()
        Me.Hide()
    End Sub
End Class