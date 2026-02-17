'Imports MySql.Data.MySqlClient

'Public Class passcopay
'    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
'    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
'    Const cardType As Integer = 5     'カードタイプ

'    Public Property ReceivedId As Integer

'    Dim std As String
'    Dim endd As String
'    Dim mont As Integer = 0
'    Dim de As String
'    Dim ar As String
'    Dim ge As Integer = 1
'    Dim stdate As Date

'    Dim stde As Integer
'    Dim ststa As Integer

'    Dim endde As Integer
'    Dim endsta As Integer
'    Private Sub passcopay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        '変数の宣言
'        'Dim data() As Byte        '読込データバッファ
'        'Dim dataLength As Integer   '読込データサイズ
'        Dim id(32) As Byte          'カードID
'        'Dim idLength As Integer     'カードIDサイズ
'        'Dim cardType As Integer     'カードタイプ
'        Dim idString As String = ""      'カードID文字列
'        Dim dataString As String = ""    '結果文字列
'        'Dim result As Integer

'        Dim Connection As New MySqlConnection
'        Dim Command As MySqlCommand
'        Dim DataReader As MySqlDataReader

'        '接続文字列の設定
'        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

'        'オープン
'        Connection.Open()

'        Command = Connection.CreateCommand
'        Command.CommandText = $"SELECT name,seinen,stday,endday,depass,arpass,month FROM iccard WHERE ICno = {ReceivedId} "
'        'SQLを実行
'        DataReader = Command.ExecuteReader

'        If DataReader.Read() Then
'            nametxt.Text = DataReader("name").ToString()
'            nameDTP.Tag = DataReader("seinen").ToString()
'            stDTP.Text = DataReader("endday").ToString()
'            endDTP.Text = DataReader("endday").ToString()
'            deComboBox.Text = DataReader("depass").ToString()
'            arComboBox.Text = DataReader("arpass").ToString()

'            Dim monthValue As Integer = DataReader("month").ToString()

'            Rad1m.Checked = (monthValue = "1")
'            Rad3m.Checked = (monthValue = "3")
'            Rad6m.Checked = (monthValue = "6")
'        End If


'        'クローズ
'        DataReader.Close()
'        Connection.Close()

'        'Dispose
'        Command.Dispose()
'        Connection.Dispose()
'    End Sub

'    Private Sub Nbtn_Click(sender As Object, e As EventArgs) Handles Nbtn.Click
'        '変数の宣言
'        'Dim data() As Byte        '読込データバッファ
'        'Dim dataLength As Integer   '読込データサイズ
'        Dim id(32) As Byte          'カードID
'        'Dim idLength As Integer     'カードIDサイズ
'        'Dim cardType As Integer     'カードタイプ
'        Dim idString As String = ""      'カードID文字列
'        Dim dataString As String = ""    '結果文字列
'        Dim result As Integer

'        std = stDTP.Value.ToString("yyyy/MM/dd")
'        endd = endDTP.Value.ToString("yyyy/MM/dd")
'        de = deComboBox.Text
'        ar = arComboBox.Text
'        stdate = DateTime.Today


'        If Rad1m.Checked Then
'            mont = 1
'        End If

'        If Rad3m.Checked Then
'            mont = 3
'        End If

'        If Rad6m.Checked Then
'            mont = 6
'        End If

'        Calculationst()
'        Calculationend()


'        Dim Connection As New MySqlConnection
'        Dim Command As MySqlCommand
'        Dim DataReader As MySqlDataReader

'        '接続文字列の設定
'        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

'        'オープン
'        Connection.Open()

'        Command = Connection.CreateCommand
'        Command.CommandText = $"UPDATE iccard SET stday = '{std}',endday = '{endd}',ruoteiddp = {stde},stationiddp = {ststa},depass = '{de}',ruoteidend = {endde},stationidend = {endsta},arpass = '{ar}',gepass = {ge},month = {mont} WHERE ICno = {ReceivedId}"
'        'SQLを実行
'        DataReader = Command.ExecuteReader
'        'Dim newId As Integer = Convert.ToInt32(Command.ExecuteScalar())

'        'dataString = std & "," & endd & "," & mont & "," & de & "," & ar & "," & ge & "," & stdate


'        ''書込データを作成
'        'data = System.Text.Encoding.Unicode.GetBytes(dataString)
'        'dataLength = data.Length

'        ''データ書込み
'        'idLength = id.Length
'        'result = OTWriteData(data(0), dataLength, id(0), idLength, cardType)


'        'クローズ
'        DataReader.Close()
'        Connection.Close()

'        'Dispose
'        Command.Dispose()
'        Connection.Dispose()

'        '結果表示
'        If result = 0 Then
'            Dim nextForm As New passcoFe()
'            nextForm.ReceivedId = ReceivedId  ' IDを渡す
'            nextForm.Show()
'            Me.Hide()
'        End If
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
'        Command.CommandText = $"SELECT ruoid,stationid FROM station WHERE stationname = '{de}'"
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
'        Command.CommandText = $"SELECT ruoid,stationid FROM station WHERE stationname = '{ar}' "
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
'        passco.Show()
'        Me.Hide()
'    End Sub
'End Class

Imports MySql.Data.MySqlClient

Public Class passcopay
    Private Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Private Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Const cardType As Integer = 5     'カードタイプ

    Public Property ReceivedId As Integer
    Dim sei As String
    Dim seinen As String
    Dim stdd As DateTime
    Dim std As String
    Dim endd As String
    Dim mont As Integer = 0
    Dim de As String
    Dim ar As String
    Dim ge As Integer = 1
    Dim stdate As Date

    Dim stde As Integer
    Dim ststa As Integer

    Dim endde As Integer
    Dim endsta As Integer
    Private Sub passcopay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            stdd = DataReader("endday").ToString()
            stDTP.Text = stdd.AddDays(1)
            endDTP.Text = DataReader("endday").ToString()
            deComboBox.Text = DataReader("depass").ToString()
            arComboBox.Text = DataReader("arpass").ToString()

            Dim monthValue As Integer = DataReader("month").ToString()

            Rad1m.Checked = (monthValue = "1")
            Rad3m.Checked = (monthValue = "3")
            Rad6m.Checked = (monthValue = "6")
        End If


        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()
    End Sub

    Private Sub Nbtn_Click(sender As Object, e As EventArgs) Handles Nbtn.Click
        sei = nametxt.Text
        seinen = nameDTP.Text
        std = stDTP.Value.ToString("yyyy/MM/dd")
        endd = endDTP.Value.ToString("yyyy/MM/dd")
        de = deComboBox.Text
        ar = arComboBox.Text
        stdate = DateTime.Today


        If Rad1m.Checked Then
            mont = 1
        End If

        If Rad3m.Checked Then
            mont = 3
        End If

        If Rad6m.Checked Then
            mont = 6
        End If




        Dim nextForm As New passcoFe()
        nextForm.ReceivedId = ReceivedId ' IDを渡す
        nextForm.Sei = sei
        nextForm.Seinen = seinen
        nextForm.Std = std
        nextForm.Endd = endd

        nextForm.De = de
        nextForm.Ar = ar
        nextForm.Stdate = stdate
        nextForm.Ge = ge
        nextForm.Mont = mont


        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Calculationst()
        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader


        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT ruoid,stationid FROM station WHERE stationname = '{de}'"
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then
            stde = DataReader("ruoid").ToString()
            ststa = DataReader("stationid").ToString()
        End If

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()
    End Sub

    Private Sub Calculationend()
        Dim Connection As New MySqlConnection
        Dim Command As MySqlCommand
        Dim DataReader As MySqlDataReader


        '接続文字列の設定
        Connection.ConnectionString = "Database=sotuken242301;Data Source=localhost;User Id=root"

        'オープン
        Connection.Open()

        Command = Connection.CreateCommand
        Command.CommandText = $"SELECT ruoid,stationid FROM station WHERE stationname = '{ar}' "
        'SQLを実行
        DataReader = Command.ExecuteReader

        If DataReader.Read() Then
            endde = DataReader("ruoid").ToString()
            endsta = DataReader("stationid").ToString()
        End If

        'クローズ
        DataReader.Close()
        Connection.Close()

        'Dispose
        Command.Dispose()
        Connection.Dispose()
    End Sub

    Private Sub Bbtn_Click(sender As Object, e As EventArgs) Handles Bbtn.Click
        passco.Show()
        Me.Hide()
    End Sub
End Class