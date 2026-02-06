<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class passsFe
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
        Febtn = New Button()
        Btin = New Button()
        mGB = New GroupBox()
        Rad3m = New RadioButton()
        Rad1m = New RadioButton()
        Rad6m = New RadioButton()
        Label6 = New Label()
        Label3 = New Label()
        endDTP = New DateTimePicker()
        nametxt = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        nameDTP = New DateTimePicker()
        Label5 = New Label()
        stDTP = New DateTimePicker()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        arComboBox = New ComboBox()
        deComboBox = New ComboBox()
        Label9 = New Label()
        chLal = New Label()
        Label2 = New Label()
        Fetxt = New TextBox()
        Label1 = New Label()
        FeLel = New Label()
        smGB = New GroupBox()
        stRBc = New RadioButton()
        stRBk = New RadioButton()
        stRBu = New RadioButton()
        meRB = New RadioButton()
        stRB = New RadioButton()
        mGB.SuspendLayout()
        smGB.SuspendLayout()
        SuspendLayout()
        ' 
        ' Febtn
        ' 
        Febtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Febtn.Location = New Point(699, 318)
        Febtn.Name = "Febtn"
        Febtn.Size = New Size(171, 104)
        Febtn.TabIndex = 39
        Febtn.Text = "発行"
        Febtn.UseVisualStyleBackColor = True
        ' 
        ' Btin
        ' 
        Btin.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Btin.Location = New Point(52, 317)
        Btin.Name = "Btin"
        Btin.Size = New Size(171, 104)
        Btin.TabIndex = 34
        Btin.Text = "戻る"
        Btin.UseVisualStyleBackColor = True
        ' 
        ' mGB
        ' 
        mGB.Controls.Add(Rad3m)
        mGB.Controls.Add(Rad1m)
        mGB.Controls.Add(Rad6m)
        mGB.Location = New Point(474, 74)
        mGB.Name = "mGB"
        mGB.Size = New Size(74, 122)
        mGB.TabIndex = 283
        mGB.TabStop = False
        mGB.Text = "月数"
        ' 
        ' Rad3m
        ' 
        Rad3m.AutoSize = True
        Rad3m.Enabled = False
        Rad3m.Location = New Point(6, 56)
        Rad3m.Name = "Rad3m"
        Rad3m.Size = New Size(63, 24)
        Rad3m.TabIndex = 232
        Rad3m.TabStop = True
        Rad3m.Text = "3ヶ月"
        Rad3m.UseVisualStyleBackColor = True
        ' 
        ' Rad1m
        ' 
        Rad1m.AutoSize = True
        Rad1m.Enabled = False
        Rad1m.Location = New Point(6, 26)
        Rad1m.Name = "Rad1m"
        Rad1m.Size = New Size(63, 24)
        Rad1m.TabIndex = 231
        Rad1m.TabStop = True
        Rad1m.Text = "1ヶ月"
        Rad1m.UseVisualStyleBackColor = True
        ' 
        ' Rad6m
        ' 
        Rad6m.AutoSize = True
        Rad6m.Enabled = False
        Rad6m.Location = New Point(6, 86)
        Rad6m.Name = "Rad6m"
        Rad6m.Size = New Size(63, 24)
        Rad6m.TabIndex = 233
        Rad6m.TabStop = True
        Rad6m.Text = "6ヶ月"
        Rad6m.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label6.Location = New Point(279, 106)
        Label6.Name = "Label6"
        Label6.Size = New Size(49, 31)
        Label6.TabIndex = 282
        Label6.Text = "から"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label3.Location = New Point(355, 74)
        Label3.Name = "Label3"
        Label3.Size = New Size(83, 31)
        Label3.TabIndex = 281
        Label3.Text = "終了日"
        ' 
        ' endDTP
        ' 
        endDTP.Enabled = False
        endDTP.Location = New Point(334, 108)
        endDTP.Name = "endDTP"
        endDTP.Size = New Size(134, 27)
        endDTP.TabIndex = 280
        ' 
        ' nametxt
        ' 
        nametxt.Enabled = False
        nametxt.Location = New Point(9, 107)
        nametxt.Name = "nametxt"
        nametxt.Size = New Size(134, 27)
        nametxt.TabIndex = 279
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label8.Location = New Point(25, 200)
        Label8.Name = "Label8"
        Label8.Size = New Size(106, 31)
        Label8.TabIndex = 278
        Label8.Text = "生年月日"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label7.Location = New Point(48, 74)
        Label7.Name = "Label7"
        Label7.Size = New Size(60, 31)
        Label7.TabIndex = 277
        Label7.Text = "氏名"
        ' 
        ' nameDTP
        ' 
        nameDTP.Enabled = False
        nameDTP.Location = New Point(9, 235)
        nameDTP.Name = "nameDTP"
        nameDTP.Size = New Size(134, 27)
        nameDTP.TabIndex = 276
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label5.Location = New Point(154, 74)
        Label5.Name = "Label5"
        Label5.Size = New Size(129, 31)
        Label5.TabIndex = 275
        Label5.Text = "利用開始日"
        ' 
        ' stDTP
        ' 
        stDTP.Enabled = False
        stDTP.Location = New Point(149, 108)
        stDTP.Name = "stDTP"
        stDTP.Size = New Size(134, 27)
        stDTP.TabIndex = 274
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label10.Location = New Point(355, 200)
        Label10.Name = "Label10"
        Label10.Size = New Size(83, 31)
        Label10.TabIndex = 273
        Label10.Text = "到着駅"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label11.Location = New Point(174, 203)
        Label11.Name = "Label11"
        Label11.Size = New Size(83, 31)
        Label11.TabIndex = 272
        Label11.Text = "出発駅"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label12.Location = New Point(279, 234)
        Label12.Name = "Label12"
        Label12.Size = New Size(49, 31)
        Label12.TabIndex = 271
        Label12.Text = "から"
        ' 
        ' arComboBox
        ' 
        arComboBox.Enabled = False
        arComboBox.FormattingEnabled = True
        arComboBox.Location = New Point(334, 237)
        arComboBox.Name = "arComboBox"
        arComboBox.Size = New Size(134, 28)
        arComboBox.TabIndex = 270
        ' 
        ' deComboBox
        ' 
        deComboBox.Enabled = False
        deComboBox.FormattingEnabled = True
        deComboBox.Location = New Point(149, 237)
        deComboBox.Name = "deComboBox"
        deComboBox.Size = New Size(134, 28)
        deComboBox.TabIndex = 269
        ' 
        ' Label9
        ' 
        Label9.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label9.Location = New Point(676, 143)
        Label9.Name = "Label9"
        Label9.Size = New Size(92, 33)
        Label9.TabIndex = 268
        Label9.Text = "投入金額"
        ' 
        ' chLal
        ' 
        chLal.BorderStyle = BorderStyle.Fixed3D
        chLal.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        chLal.Location = New Point(774, 232)
        chLal.Name = "chLal"
        chLal.Size = New Size(138, 50)
        chLal.TabIndex = 267
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label2.Location = New Point(712, 233)
        Label2.Name = "Label2"
        Label2.Size = New Size(56, 33)
        Label2.TabIndex = 266
        Label2.Text = "残額"
        ' 
        ' Fetxt
        ' 
        Fetxt.Location = New Point(774, 147)
        Fetxt.Name = "Fetxt"
        Fetxt.Size = New Size(138, 27)
        Fetxt.TabIndex = 265
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(658, 48)
        Label1.Name = "Label1"
        Label1.Size = New Size(110, 33)
        Label1.TabIndex = 264
        Label1.Text = "支払い金額"
        ' 
        ' FeLel
        ' 
        FeLel.BorderStyle = BorderStyle.Fixed3D
        FeLel.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        FeLel.Location = New Point(774, 58)
        FeLel.Name = "FeLel"
        FeLel.Size = New Size(138, 50)
        FeLel.TabIndex = 263
        ' 
        ' smGB
        ' 
        smGB.Controls.Add(stRBc)
        smGB.Controls.Add(stRBk)
        smGB.Controls.Add(stRBu)
        smGB.Controls.Add(meRB)
        smGB.Controls.Add(stRB)
        smGB.Location = New Point(473, 203)
        smGB.Name = "smGB"
        smGB.Size = New Size(212, 150)
        smGB.TabIndex = 259
        smGB.TabStop = False
        smGB.Text = "通学または通勤"
        ' 
        ' stRBc
        ' 
        stRBc.AutoSize = True
        stRBc.Enabled = False
        stRBc.Font = New Font("Yu Gothic UI", 10.2F)
        stRBc.Location = New Point(87, 106)
        stRBc.Name = "stRBc"
        stRBc.Size = New Size(109, 27)
        stRBc.TabIndex = 242
        stRBc.TabStop = True
        stRBc.Text = "通学(中学)"
        stRBc.UseVisualStyleBackColor = True
        ' 
        ' stRBk
        ' 
        stRBk.AutoSize = True
        stRBk.Enabled = False
        stRBk.Font = New Font("Yu Gothic UI", 10.2F)
        stRBk.Location = New Point(87, 73)
        stRBk.Name = "stRBk"
        stRBk.Size = New Size(109, 27)
        stRBk.TabIndex = 241
        stRBk.TabStop = True
        stRBk.Text = "通学(高校)"
        stRBk.UseVisualStyleBackColor = True
        ' 
        ' stRBu
        ' 
        stRBu.AutoSize = True
        stRBu.Enabled = False
        stRBu.Font = New Font("Yu Gothic UI", 10.2F)
        stRBu.Location = New Point(87, 35)
        stRBu.Name = "stRBu"
        stRBu.Size = New Size(109, 27)
        stRBu.TabIndex = 240
        stRBu.TabStop = True
        stRBu.Text = "通学(大学)"
        stRBu.UseVisualStyleBackColor = True
        ' 
        ' meRB
        ' 
        meRB.AutoSize = True
        meRB.Enabled = False
        meRB.Font = New Font("Yu Gothic UI", 10.2F)
        meRB.Location = New Point(16, 77)
        meRB.Name = "meRB"
        meRB.Size = New Size(65, 27)
        meRB.TabIndex = 239
        meRB.TabStop = True
        meRB.Text = "通学"
        meRB.UseVisualStyleBackColor = True
        ' 
        ' stRB
        ' 
        stRB.AutoSize = True
        stRB.Enabled = False
        stRB.Font = New Font("Yu Gothic UI", 10.2F)
        stRB.Location = New Point(16, 44)
        stRB.Name = "stRB"
        stRB.Size = New Size(65, 27)
        stRB.TabIndex = 238
        stRB.TabStop = True
        stRB.Text = "通勤"
        stRB.UseVisualStyleBackColor = True
        ' 
        ' passsFe
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(935, 450)
        Controls.Add(smGB)
        Controls.Add(mGB)
        Controls.Add(Label6)
        Controls.Add(Label3)
        Controls.Add(endDTP)
        Controls.Add(nametxt)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(nameDTP)
        Controls.Add(Label5)
        Controls.Add(stDTP)
        Controls.Add(Label10)
        Controls.Add(Label11)
        Controls.Add(Label12)
        Controls.Add(arComboBox)
        Controls.Add(deComboBox)
        Controls.Add(Label9)
        Controls.Add(chLal)
        Controls.Add(Label2)
        Controls.Add(Fetxt)
        Controls.Add(Label1)
        Controls.Add(FeLel)
        Controls.Add(Febtn)
        Controls.Add(Btin)
        Name = "passsFe"
        Text = "定期券購入"
        mGB.ResumeLayout(False)
        mGB.PerformLayout()
        smGB.ResumeLayout(False)
        smGB.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Febtn As Button
    Friend WithEvents Btin As Button
    Friend WithEvents mGB As GroupBox
    Friend WithEvents Rad3m As RadioButton
    Friend WithEvents Rad1m As RadioButton
    Friend WithEvents Rad6m As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents endDTP As DateTimePicker
    Friend WithEvents nametxt As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents nameDTP As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents stDTP As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents arComboBox As ComboBox
    Friend WithEvents deComboBox As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents chLal As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Fetxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents FeLel As Label
    Friend WithEvents smGB As GroupBox
    Friend WithEvents stRBc As RadioButton
    Friend WithEvents stRBk As RadioButton
    Friend WithEvents stRBu As RadioButton
    Friend WithEvents meRB As RadioButton
    Friend WithEvents stRB As RadioButton
End Class
