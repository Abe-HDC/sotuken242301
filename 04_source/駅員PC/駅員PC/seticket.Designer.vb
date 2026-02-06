<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class seticket
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label4 = New Label()
        Fetxt = New TextBox()
        Label3 = New Label()
        FeLal = New Label()
        cabtn = New Button()
        Bbtn = New Button()
        Label1 = New Label()
        Label5 = New Label()
        stTB = New TextBox()
        endTB = New TextBox()
        Label6 = New Label()
        Label7 = New Label()
        Button1 = New Button()
        endCB = New ComboBox()
        SuspendLayout()
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label4.Location = New Point(658, 191)
        Label4.Name = "Label4"
        Label4.Size = New Size(92, 28)
        Label4.TabIndex = 28
        Label4.Text = "投入金額"
        ' 
        ' Fetxt
        ' 
        Fetxt.Location = New Point(574, 222)
        Fetxt.Name = "Fetxt"
        Fetxt.Size = New Size(176, 27)
        Fetxt.TabIndex = 27
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label3.Location = New Point(642, 22)
        Label3.Name = "Label3"
        Label3.Size = New Size(120, 28)
        Label3.TabIndex = 26
        Label3.Text = "乗り越し運賃"
        ' 
        ' FeLal
        ' 
        FeLal.BorderStyle = BorderStyle.Fixed3D
        FeLal.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        FeLal.Location = New Point(553, 50)
        FeLal.Name = "FeLal"
        FeLal.Size = New Size(209, 71)
        FeLal.TabIndex = 25
        ' 
        ' cabtn
        ' 
        cabtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        cabtn.Location = New Point(574, 317)
        cabtn.Name = "cabtn"
        cabtn.Size = New Size(176, 111)
        cabtn.TabIndex = 23
        cabtn.Text = "現金支払い"
        cabtn.UseVisualStyleBackColor = True
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(38, 317)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(176, 111)
        Bbtn.TabIndex = 22
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(85, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(83, 31)
        Label1.TabIndex = 29
        Label1.Text = "出発駅"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label5.Location = New Point(247, 22)
        Label5.Name = "Label5"
        Label5.Size = New Size(83, 31)
        Label5.TabIndex = 30
        Label5.Text = "到着駅"
        ' 
        ' stTB
        ' 
        stTB.Location = New Point(65, 56)
        stTB.Name = "stTB"
        stTB.Size = New Size(125, 27)
        stTB.TabIndex = 31
        ' 
        ' endTB
        ' 
        endTB.Location = New Point(226, 56)
        endTB.Name = "endTB"
        endTB.Size = New Size(125, 27)
        endTB.TabIndex = 32
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label6.Location = New Point(183, 50)
        Label6.Name = "Label6"
        Label6.Size = New Size(49, 31)
        Label6.TabIndex = 34
        Label6.Text = "から"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label7.Location = New Point(398, 22)
        Label7.Name = "Label7"
        Label7.Size = New Size(133, 31)
        Label7.TabIndex = 35
        Label7.Text = "乗り越した駅"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Button1.Location = New Point(432, 89)
        Button1.Name = "Button1"
        Button1.Size = New Size(99, 57)
        Button1.TabIndex = 36
        Button1.Text = "計算"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' endCB
        ' 
        endCB.FormattingEnabled = True
        endCB.Items.AddRange(New Object() {"高崎", "高崎問屋町", "井野", "新前橋", "群馬総社", "八木原", "渋川", "敷島", "津久田", "岩本", "沼田", "後閑", "上牧", "水上", "北高崎", "群馬八幡", "安中", "磯部", "松井田", "西松井田", "横川", "桐生", "岩宿", "伊勢崎", "駒形", "前橋大島", "前橋", "舘林", "多々良", "県", "福居", "野州山辺", "韮川", "太田", "細谷", "木崎", "剛志", "新伊勢崎"})
        endCB.Location = New Point(380, 56)
        endCB.Name = "endCB"
        endCB.Size = New Size(151, 28)
        endCB.TabIndex = 37
        ' 
        ' seticket
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(endCB)
        Controls.Add(Button1)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(endTB)
        Controls.Add(stTB)
        Controls.Add(Label5)
        Controls.Add(Label1)
        Controls.Add(Label4)
        Controls.Add(Fetxt)
        Controls.Add(Label3)
        Controls.Add(FeLal)
        Controls.Add(cabtn)
        Controls.Add(Bbtn)
        Name = "seticket"
        Text = "乗り越し精算(切符)"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Fetxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents FeLal As Label
    Friend WithEvents cabtn As Button
    Friend WithEvents Bbtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents stTB As TextBox
    Friend WithEvents endTB As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents endCB As ComboBox
End Class
