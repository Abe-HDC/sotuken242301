<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class seIC
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
        SuspendLayout()
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(22, 308)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(176, 111)
        Bbtn.TabIndex = 3
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Yu Gothic UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(162, 168)
        Label1.Name = "Label1"
        Label1.Size = New Size(474, 60)
        Label1.TabIndex = 2
        Label1.Text = "ICカードをタッチしてください"
        ' 
        ' seIC
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Bbtn)
        Controls.Add(Label1)
        Name = "seIC"
        Text = "乗り越し精算(ICカード)"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Bbtn As Button
    Friend WithEvents Label1 As Label
End Class
