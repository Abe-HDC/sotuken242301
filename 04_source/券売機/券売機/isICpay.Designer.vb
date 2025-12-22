<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class isICpay
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
        Label3 = New Label()
        Bbtn = New Button()
        Febtn = New Button()
        FeTxt = New TextBox()
        Label1 = New Label()
        FeLel = New Label()
        nametxt = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        nameDTP = New DateTimePicker()
        Label4 = New Label()
        SuspendLayout()
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label3.Location = New Point(376, 188)
        Label3.Name = "Label3"
        Label3.Size = New Size(97, 33)
        Label3.TabIndex = 87
        Label3.Text = "投入金額"
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(40, 280)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(151, 95)
        Bbtn.TabIndex = 86
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' Febtn
        ' 
        Febtn.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Febtn.Location = New Point(573, 280)
        Febtn.Name = "Febtn"
        Febtn.Size = New Size(188, 95)
        Febtn.TabIndex = 85
        Febtn.Text = "チャージ"
        Febtn.UseVisualStyleBackColor = True
        ' 
        ' FeTxt
        ' 
        FeTxt.Location = New Point(517, 194)
        FeTxt.Name = "FeTxt"
        FeTxt.Size = New Size(138, 27)
        FeTxt.TabIndex = 84
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(363, 106)
        Label1.Name = "Label1"
        Label1.Size = New Size(110, 33)
        Label1.TabIndex = 83
        Label1.Text = "チャージ金額"
        ' 
        ' FeLel
        ' 
        FeLel.BorderStyle = BorderStyle.Fixed3D
        FeLel.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        FeLel.Location = New Point(517, 105)
        FeLel.Name = "FeLel"
        FeLel.Size = New Size(138, 50)
        FeLel.TabIndex = 82
        ' 
        ' nametxt
        ' 
        nametxt.Location = New Point(147, 110)
        nametxt.Name = "nametxt"
        nametxt.Size = New Size(195, 27)
        nametxt.TabIndex = 91
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label8.Location = New Point(192, 162)
        Label8.Name = "Label8"
        Label8.Size = New Size(106, 31)
        Label8.TabIndex = 90
        Label8.Text = "生年月日"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label7.Location = New Point(216, 76)
        Label7.Name = "Label7"
        Label7.Size = New Size(60, 31)
        Label7.TabIndex = 89
        Label7.Text = "氏名"
        ' 
        ' nameDTP
        ' 
        nameDTP.Location = New Point(147, 194)
        nameDTP.Name = "nameDTP"
        nameDTP.Size = New Size(195, 27)
        nameDTP.TabIndex = 88
        ' 
        ' Label4
        ' 
        Label4.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label4.Location = New Point(422, 158)
        Label4.Name = "Label4"
        Label4.Size = New Size(233, 33)
        Label4.TabIndex = 131
        Label4.Text = "デポジット500円も含みます"
        ' 
        ' isICpay
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label4)
        Controls.Add(nametxt)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(nameDTP)
        Controls.Add(Label3)
        Controls.Add(Bbtn)
        Controls.Add(Febtn)
        Controls.Add(FeTxt)
        Controls.Add(Label1)
        Controls.Add(FeLel)
        Name = "isICpay"
        Text = "ICカード発行・チャージ"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Bbtn As Button
    Friend WithEvents Febtn As Button
    Friend WithEvents FeTxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents FeLel As Label
    Friend WithEvents nametxt As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents nameDTP As DateTimePicker
    Friend WithEvents Label4 As Label
End Class
