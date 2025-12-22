<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class isICn
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
        nametxt = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        nameDTP = New DateTimePicker()
        Nbtn = New Button()
        Bbtn = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' nametxt
        ' 
        nametxt.Location = New Point(179, 187)
        nametxt.Name = "nametxt"
        nametxt.Size = New Size(195, 27)
        nametxt.TabIndex = 78
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label8.Location = New Point(472, 153)
        Label8.Name = "Label8"
        Label8.Size = New Size(106, 31)
        Label8.TabIndex = 77
        Label8.Text = "生年月日"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label7.Location = New Point(248, 153)
        Label7.Name = "Label7"
        Label7.Size = New Size(60, 31)
        Label7.TabIndex = 76
        Label7.Text = "氏名"
        ' 
        ' nameDTP
        ' 
        nameDTP.Location = New Point(427, 185)
        nameDTP.Name = "nameDTP"
        nameDTP.Size = New Size(195, 27)
        nameDTP.TabIndex = 75
        ' 
        ' Nbtn
        ' 
        Nbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Nbtn.Location = New Point(574, 318)
        Nbtn.Name = "Nbtn"
        Nbtn.Size = New Size(151, 95)
        Nbtn.TabIndex = 96
        Nbtn.Text = "次へ"
        Nbtn.UseVisualStyleBackColor = True
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(97, 318)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(151, 95)
        Bbtn.TabIndex = 95
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(146, 87)
        Label1.Name = "Label1"
        Label1.Size = New Size(215, 20)
        Label1.TabIndex = 97
        Label1.Text = "名前と生年月日を入力してください"
        ' 
        ' isICn
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label1)
        Controls.Add(Nbtn)
        Controls.Add(Bbtn)
        Controls.Add(nametxt)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(nameDTP)
        Name = "isICn"
        Text = "isICn"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents nametxt As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents nameDTP As DateTimePicker
    Friend WithEvents Nbtn As Button
    Friend WithEvents Bbtn As Button
    Friend WithEvents Label1 As Label
End Class
