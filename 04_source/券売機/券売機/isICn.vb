Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class isICn

    Declare Function OTReadData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByRef dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Declare Function OTWriteData Lib "OrangeOneStopEasyAPI.dll" (ByRef data As Byte, ByVal dataLength As Integer, ByRef id As Byte, ByRef idLength As Integer, ByRef cardType As Integer) As Integer
    Const cardType As Integer = 5     'カードタイプ

    Private Sub Nbtn_Click(sender As Object, e As EventArgs) Handles Nbtn.Click
        '変数の宣言
        Dim data(40) As Byte        '読込データバッファ
        Dim dataLength As Integer   '読込データサイズ
        Dim id(10) As Byte          'カードID
        Dim idLength As Integer     'カードIDサイズ
        Dim cardType As Integer     'カードタイプ
        Dim idString As String = ""      'カードID文字列
        Dim dataString As String = ""    '結果文字列
        Dim sei As String = nametxt.Text '名前
        Dim seinen As String = nameDTP.Value.ToString("yyyy/MM/dd")
        Dim result As Integer

        dataString = sei & "," & seinen


        '書込データを作成
        data = System.Text.Encoding.Unicode.GetBytes(dataString)
        dataLength = data.Length

        'データ書込み
        result = OTWriteData(data(0), dataLength, id(0), idLength, cardType)

        '結果表示
        If result = 0 Then
            MessageBox.Show("登録完了しました。")
        Else
            MessageBox.Show("登録に失敗しました。")
        End If

    End Sub
End Class