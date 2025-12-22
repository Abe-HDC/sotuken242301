<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ICcharge
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
        Label1 = New Label()
        baLal = New Label()
        ch1000 = New Button()
        ch2000 = New Button()
        ch3000 = New Button()
        ch10000 = New Button()
        ch5000 = New Button()
        ch4000 = New Button()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(79, 346)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(151, 95)
        Bbtn.TabIndex = 75
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(652, 323)
        Label1.Name = "Label1"
        Label1.Size = New Size(55, 37)
        Label1.TabIndex = 74
        Label1.Text = "残高"
        ' 
        ' baLal
        ' 
        baLal.BorderStyle = BorderStyle.Fixed3D
        baLal.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        baLal.Location = New Point(444, 360)
        baLal.Name = "baLal"
        baLal.Size = New Size(263, 81)
        baLal.TabIndex = 73
        ' 
        ' ch1000
        ' 
        ch1000.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        ch1000.Location = New Point(79, 100)
        ch1000.Name = "ch1000"
        ch1000.Size = New Size(204, 88)
        ch1000.TabIndex = 76
        ch1000.Text = "1000"
        ch1000.UseVisualStyleBackColor = True
        ' 
        ' ch2000
        ' 
        ch2000.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        ch2000.Location = New Point(293, 100)
        ch2000.Name = "ch2000"
        ch2000.Size = New Size(204, 88)
        ch2000.TabIndex = 77
        ch2000.Text = "2000"
        ch2000.UseVisualStyleBackColor = True
        ' 
        ' ch3000
        ' 
        ch3000.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        ch3000.Location = New Point(503, 100)
        ch3000.Name = "ch3000"
        ch3000.Size = New Size(204, 88)
        ch3000.TabIndex = 78
        ch3000.Text = "3000"
        ch3000.UseVisualStyleBackColor = True
        ' 
        ' ch10000
        ' 
        ch10000.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        ch10000.Location = New Point(503, 219)
        ch10000.Name = "ch10000"
        ch10000.Size = New Size(204, 88)
        ch10000.TabIndex = 81
        ch10000.Text = "10000"
        ch10000.UseVisualStyleBackColor = True
        ' 
        ' ch5000
        ' 
        ch5000.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        ch5000.Location = New Point(293, 219)
        ch5000.Name = "ch5000"
        ch5000.Size = New Size(204, 88)
        ch5000.TabIndex = 80
        ch5000.Text = "5000"
        ch5000.UseVisualStyleBackColor = True
        ' 
        ' ch4000
        ' 
        ch4000.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        ch4000.Location = New Point(79, 219)
        ch4000.Name = "ch4000"
        ch4000.Size = New Size(204, 88)
        ch4000.TabIndex = 79
        ch4000.Text = "4000"
        ch4000.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label2.Location = New Point(79, 29)
        Label2.Name = "Label2"
        Label2.Size = New Size(418, 46)
        Label2.TabIndex = 82
        Label2.Text = "チャージ金額を選択してください"
        ' 
        ' ICcharge
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label2)
        Controls.Add(ch10000)
        Controls.Add(ch5000)
        Controls.Add(ch4000)
        Controls.Add(ch3000)
        Controls.Add(ch2000)
        Controls.Add(ch1000)
        Controls.Add(Bbtn)
        Controls.Add(Label1)
        Controls.Add(baLal)
        Name = "ICcharge"
        Text = "ICカードチャージ"
        ResumeLayout(False)
    End Sub

    Friend WithEvents Bbtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents baLal As Label
    Friend WithEvents ch1000 As Button
    Friend WithEvents ch2000 As Button
    Friend WithEvents ch3000 As Button
    Friend WithEvents ch10000 As Button
    Friend WithEvents ch5000 As Button
    Friend WithEvents ch4000 As Button
    Friend WithEvents Label2 As Label
End Class
