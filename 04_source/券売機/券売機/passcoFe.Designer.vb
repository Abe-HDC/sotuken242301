<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class passcoFe
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
        isbtn = New Button()
        Label6 = New Label()
        Label3 = New Label()
        endDTP = New DateTimePicker()
        Rad6m = New RadioButton()
        Rad3m = New RadioButton()
        Rad1m = New RadioButton()
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
        SuspendLayout()
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(33, 313)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(151, 95)
        Bbtn.TabIndex = 142
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' isbtn
        ' 
        isbtn.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        isbtn.Location = New Point(579, 313)
        isbtn.Name = "isbtn"
        isbtn.Size = New Size(188, 95)
        isbtn.TabIndex = 137
        isbtn.Text = "更新"
        isbtn.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label6.Location = New Point(286, 116)
        Label6.Name = "Label6"
        Label6.Size = New Size(49, 31)
        Label6.TabIndex = 213
        Label6.Text = "から"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label3.Location = New Point(362, 84)
        Label3.Name = "Label3"
        Label3.Size = New Size(83, 31)
        Label3.TabIndex = 212
        Label3.Text = "終了日"
        ' 
        ' endDTP
        ' 
        endDTP.Location = New Point(341, 118)
        endDTP.Name = "endDTP"
        endDTP.Size = New Size(134, 27)
        endDTP.TabIndex = 211
        ' 
        ' Rad6m
        ' 
        Rad6m.AutoSize = True
        Rad6m.Location = New Point(482, 210)
        Rad6m.Name = "Rad6m"
        Rad6m.Size = New Size(63, 24)
        Rad6m.TabIndex = 210
        Rad6m.TabStop = True
        Rad6m.Tag = "6"
        Rad6m.Text = "6ヶ月"
        Rad6m.UseVisualStyleBackColor = True
        ' 
        ' Rad3m
        ' 
        Rad3m.AutoSize = True
        Rad3m.Location = New Point(482, 167)
        Rad3m.Name = "Rad3m"
        Rad3m.Size = New Size(63, 24)
        Rad3m.TabIndex = 209
        Rad3m.TabStop = True
        Rad3m.Tag = "3"
        Rad3m.Text = "3ヶ月"
        Rad3m.UseVisualStyleBackColor = True
        ' 
        ' Rad1m
        ' 
        Rad1m.AutoSize = True
        Rad1m.Location = New Point(482, 128)
        Rad1m.Name = "Rad1m"
        Rad1m.Size = New Size(63, 24)
        Rad1m.TabIndex = 208
        Rad1m.TabStop = True
        Rad1m.Tag = "1"
        Rad1m.Text = "1ヶ月"
        Rad1m.UseVisualStyleBackColor = True
        ' 
        ' nametxt
        ' 
        nametxt.Location = New Point(16, 117)
        nametxt.Name = "nametxt"
        nametxt.Size = New Size(134, 27)
        nametxt.TabIndex = 207
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label8.Location = New Point(32, 210)
        Label8.Name = "Label8"
        Label8.Size = New Size(106, 31)
        Label8.TabIndex = 206
        Label8.Text = "生年月日"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label7.Location = New Point(55, 84)
        Label7.Name = "Label7"
        Label7.Size = New Size(60, 31)
        Label7.TabIndex = 205
        Label7.Text = "氏名"
        ' 
        ' nameDTP
        ' 
        nameDTP.Enabled = False
        nameDTP.Location = New Point(16, 245)
        nameDTP.Name = "nameDTP"
        nameDTP.Size = New Size(134, 27)
        nameDTP.TabIndex = 204
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label5.Location = New Point(161, 84)
        Label5.Name = "Label5"
        Label5.Size = New Size(129, 31)
        Label5.TabIndex = 203
        Label5.Text = "利用開始日"
        ' 
        ' stDTP
        ' 
        stDTP.Location = New Point(156, 118)
        stDTP.Name = "stDTP"
        stDTP.Size = New Size(134, 27)
        stDTP.TabIndex = 202
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label10.Location = New Point(362, 210)
        Label10.Name = "Label10"
        Label10.Size = New Size(83, 31)
        Label10.TabIndex = 201
        Label10.Text = "到着駅"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label11.Location = New Point(181, 213)
        Label11.Name = "Label11"
        Label11.Size = New Size(83, 31)
        Label11.TabIndex = 200
        Label11.Text = "出発駅"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label12.Location = New Point(286, 244)
        Label12.Name = "Label12"
        Label12.Size = New Size(49, 31)
        Label12.TabIndex = 199
        Label12.Text = "から"
        ' 
        ' arComboBox
        ' 
        arComboBox.FormattingEnabled = True
        arComboBox.Location = New Point(341, 247)
        arComboBox.Name = "arComboBox"
        arComboBox.Size = New Size(134, 28)
        arComboBox.TabIndex = 198
        ' 
        ' deComboBox
        ' 
        deComboBox.FormattingEnabled = True
        deComboBox.Location = New Point(156, 247)
        deComboBox.Name = "deComboBox"
        deComboBox.Size = New Size(134, 28)
        deComboBox.TabIndex = 197
        ' 
        ' Label9
        ' 
        Label9.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label9.Location = New Point(543, 149)
        Label9.Name = "Label9"
        Label9.Size = New Size(92, 33)
        Label9.TabIndex = 196
        Label9.Text = "投入金額"
        ' 
        ' chLal
        ' 
        chLal.BorderStyle = BorderStyle.Fixed3D
        chLal.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        chLal.Location = New Point(641, 238)
        chLal.Name = "chLal"
        chLal.Size = New Size(138, 50)
        chLal.TabIndex = 195
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label2.Location = New Point(566, 239)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 33)
        Label2.TabIndex = 194
        Label2.Text = "お釣り"
        ' 
        ' Fetxt
        ' 
        Fetxt.Location = New Point(641, 153)
        Fetxt.Name = "Fetxt"
        Fetxt.Size = New Size(138, 27)
        Fetxt.TabIndex = 193
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(525, 64)
        Label1.Name = "Label1"
        Label1.Size = New Size(110, 33)
        Label1.TabIndex = 192
        Label1.Text = "支払い金額"
        ' 
        ' FeLel
        ' 
        FeLel.BorderStyle = BorderStyle.Fixed3D
        FeLel.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        FeLel.Location = New Point(641, 64)
        FeLel.Name = "FeLel"
        FeLel.Size = New Size(138, 50)
        FeLel.TabIndex = 191
        ' 
        ' passcoFe
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label6)
        Controls.Add(Label3)
        Controls.Add(endDTP)
        Controls.Add(Rad6m)
        Controls.Add(Rad3m)
        Controls.Add(Rad1m)
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
        Controls.Add(Bbtn)
        Controls.Add(isbtn)
        Name = "passcoFe"
        Text = "定期券更新"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Bbtn As Button
    Friend WithEvents isbtn As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents endDTP As DateTimePicker
    Friend WithEvents Rad6m As RadioButton
    Friend WithEvents Rad3m As RadioButton
    Friend WithEvents Rad1m As RadioButton
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
End Class
