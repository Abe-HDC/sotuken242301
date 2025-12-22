<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainsse
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
        bticket = New Button()
        bICpass = New Button()
        bIC = New Button()
        SuspendLayout()
        ' 
        ' bticket
        ' 
        bticket.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bticket.Location = New Point(562, 164)
        bticket.Name = "bticket"
        bticket.Size = New Size(226, 121)
        bticket.TabIndex = 6
        bticket.Text = "切符での乗り越し"
        bticket.UseVisualStyleBackColor = True
        ' 
        ' bICpass
        ' 
        bICpass.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bICpass.Location = New Point(292, 164)
        bICpass.Name = "bICpass"
        bICpass.Size = New Size(226, 121)
        bICpass.TabIndex = 5
        bICpass.Text = "IC定期券"
        bICpass.UseVisualStyleBackColor = True
        ' 
        ' bIC
        ' 
        bIC.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bIC.Location = New Point(12, 164)
        bIC.Name = "bIC"
        bIC.Size = New Size(226, 121)
        bIC.TabIndex = 4
        bIC.Text = "ICカード"
        bIC.UseVisualStyleBackColor = True
        ' 
        ' mainsse
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(bticket)
        Controls.Add(bICpass)
        Controls.Add(bIC)
        Name = "mainsse"
        Text = "乗り越し精算"
        ResumeLayout(False)
    End Sub

    Friend WithEvents bticket As Button
    Friend WithEvents bICpass As Button
    Friend WithEvents bIC As Button
End Class
