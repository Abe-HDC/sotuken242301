<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class passcopay
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
        Bbtn = New Button()
        Nbtn = New Button()
        smGB = New GroupBox()
        meRB = New RadioButton()
        stRB = New RadioButton()
        mGB = New GroupBox()
        Rad3m = New RadioButton()
        Rad1m = New RadioButton()
        Rad6m = New RadioButton()
        Label6 = New Label()
        Label4 = New Label()
        endDTP = New DateTimePicker()
        nametxt = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        nameDTP = New DateTimePicker()
        Label5 = New Label()
        stDTP = New DateTimePicker()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        arComboBox = New ComboBox()
        deComboBox = New ComboBox()
        smGB.SuspendLayout()
        mGB.SuspendLayout()
        SuspendLayout()
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(51, 304)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(151, 95)
        Bbtn.TabIndex = 86
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' Nbtn
        ' 
        Nbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Nbtn.Location = New Point(599, 304)
        Nbtn.Name = "Nbtn"
        Nbtn.Size = New Size(151, 95)
        Nbtn.TabIndex = 80
        Nbtn.Text = "次へ"
        Nbtn.UseVisualStyleBackColor = True
        ' 
        ' smGB
        ' 
        smGB.Controls.Add(meRB)
        smGB.Controls.Add(stRB)
        smGB.Location = New Point(679, 35)
        smGB.Name = "smGB"
        smGB.Size = New Size(91, 112)
        smGB.TabIndex = 274
        smGB.TabStop = False
        smGB.Text = "通学または通勤"
        ' 
        ' meRB
        ' 
        meRB.AutoSize = True
        meRB.Font = New Font("Yu Gothic UI", 10.2F)
        meRB.Location = New Point(16, 77)
        meRB.Name = "meRB"
        meRB.Size = New Size(65, 27)
        meRB.TabIndex = 239
        meRB.TabStop = True
        meRB.Text = "通勤"
        meRB.UseVisualStyleBackColor = True
        ' 
        ' stRB
        ' 
        stRB.AutoSize = True
        stRB.Font = New Font("Yu Gothic UI", 10.2F)
        stRB.Location = New Point(16, 44)
        stRB.Name = "stRB"
        stRB.Size = New Size(65, 27)
        stRB.TabIndex = 238
        stRB.TabStop = True
        stRB.Text = "通学"
        stRB.UseVisualStyleBackColor = True
        ' 
        ' mGB
        ' 
        mGB.Controls.Add(Rad3m)
        mGB.Controls.Add(Rad1m)
        mGB.Controls.Add(Rad6m)
        mGB.Location = New Point(599, 25)
        mGB.Name = "mGB"
        mGB.Size = New Size(74, 122)
        mGB.TabIndex = 273
        mGB.TabStop = False
        mGB.Text = "月数"
        ' 
        ' Rad3m
        ' 
        Rad3m.AutoSize = True
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
        Label6.Location = New Point(396, 70)
        Label6.Name = "Label6"
        Label6.Size = New Size(49, 31)
        Label6.TabIndex = 272
        Label6.Text = "から"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label4.Location = New Point(472, 42)
        Label4.Name = "Label4"
        Label4.Size = New Size(83, 31)
        Label4.TabIndex = 271
        Label4.Text = "終了日"
        ' 
        ' endDTP
        ' 
        endDTP.Location = New Point(451, 74)
        endDTP.Name = "endDTP"
        endDTP.Size = New Size(131, 27)
        endDTP.TabIndex = 270
        ' 
        ' nametxt
        ' 
        nametxt.Location = New Point(31, 76)
        nametxt.Name = "nametxt"
        nametxt.Size = New Size(195, 27)
        nametxt.TabIndex = 269
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label8.Location = New Point(76, 180)
        Label8.Name = "Label8"
        Label8.Size = New Size(106, 31)
        Label8.TabIndex = 268
        Label8.Text = "生年月日"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label7.Location = New Point(100, 42)
        Label7.Name = "Label7"
        Label7.Size = New Size(60, 31)
        Label7.TabIndex = 267
        Label7.Text = "氏名"
        ' 
        ' nameDTP
        ' 
        nameDTP.Enabled = False
        nameDTP.Location = New Point(31, 212)
        nameDTP.Name = "nameDTP"
        nameDTP.Size = New Size(195, 27)
        nameDTP.TabIndex = 266
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label5.Location = New Point(261, 42)
        Label5.Name = "Label5"
        Label5.Size = New Size(129, 31)
        Label5.TabIndex = 265
        Label5.Text = "利用開始日"
        ' 
        ' stDTP
        ' 
        stDTP.Location = New Point(261, 74)
        stDTP.Name = "stDTP"
        stDTP.Size = New Size(131, 27)
        stDTP.TabIndex = 264
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label3.Location = New Point(576, 180)
        Label3.Name = "Label3"
        Label3.Size = New Size(83, 31)
        Label3.TabIndex = 263
        Label3.Text = "到着駅"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label2.Location = New Point(320, 180)
        Label2.Name = "Label2"
        Label2.Size = New Size(83, 31)
        Label2.TabIndex = 262
        Label2.Text = "出発駅"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(462, 214)
        Label1.Name = "Label1"
        Label1.Size = New Size(49, 31)
        Label1.TabIndex = 261
        Label1.Text = "から"
        ' 
        ' arComboBox
        ' 
        arComboBox.FormattingEnabled = True
        arComboBox.Location = New Point(517, 214)
        arComboBox.Name = "arComboBox"
        arComboBox.Size = New Size(195, 28)
        arComboBox.TabIndex = 260
        ' 
        ' deComboBox
        ' 
        deComboBox.FormattingEnabled = True
        deComboBox.Location = New Point(261, 214)
        deComboBox.Name = "deComboBox"
        deComboBox.Size = New Size(195, 28)
        deComboBox.TabIndex = 259
        ' 
        ' passcopay
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(smGB)
        Controls.Add(mGB)
        Controls.Add(Label6)
        Controls.Add(Label4)
        Controls.Add(endDTP)
        Controls.Add(nametxt)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(nameDTP)
        Controls.Add(Label5)
        Controls.Add(stDTP)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(arComboBox)
        Controls.Add(deComboBox)
        Controls.Add(Bbtn)
        Controls.Add(Nbtn)
        Name = "passcopay"
        Text = "定期券更新"
        smGB.ResumeLayout(False)
        smGB.PerformLayout()
        mGB.ResumeLayout(False)
        mGB.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Bbtn As Button
    Friend WithEvents Nbtn As Button
    Friend WithEvents smGB As GroupBox
    Friend WithEvents meRB As RadioButton
    Friend WithEvents stRB As RadioButton
    Friend WithEvents mGB As GroupBox
    Friend WithEvents Rad3m As RadioButton
    Friend WithEvents Rad1m As RadioButton
    Friend WithEvents Rad6m As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents endDTP As DateTimePicker
    Friend WithEvents nametxt As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents nameDTP As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents stDTP As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents arComboBox As ComboBox
    Friend WithEvents deComboBox As ComboBox
End Class
