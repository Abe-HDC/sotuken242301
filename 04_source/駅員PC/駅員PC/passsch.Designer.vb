<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class passsch
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
        isbtn = New Button()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Bbtn = New Button()
        SuspendLayout()
        ' 
        ' isbtn
        ' 
        isbtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        isbtn.Location = New Point(595, 314)
        isbtn.Name = "isbtn"
        isbtn.Size = New Size(164, 100)
        isbtn.TabIndex = 7
        isbtn.Text = "発行"
        isbtn.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Yu Gothic UI", 19.8000011F)
        Label3.Location = New Point(39, 210)
        Label3.Name = "Label3"
        Label3.Size = New Size(698, 46)
        Label3.TabIndex = 6
        Label3.Text = "領収書が必要の場合は発行ボタンを押してください"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Yu Gothic UI", 19.8000011F)
        Label2.Location = New Point(197, 164)
        Label2.Name = "Label2"
        Label2.Size = New Size(420, 46)
        Label2.TabIndex = 5
        Label2.Text = "お取り忘れにご注意ください！"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Yu Gothic UI", 19.8000011F)
        Label1.Location = New Point(238, 118)
        Label1.Name = "Label1"
        Label1.Size = New Size(348, 46)
        Label1.TabIndex = 4
        Label1.Text = "定期券が発行されました"
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(438, 314)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(151, 95)
        Bbtn.TabIndex = 73
        Bbtn.Text = "メインメニューに戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' passsch
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Bbtn)
        Controls.Add(isbtn)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "passsch"
        Text = "定期券購入"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents isbtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Bbtn As Button
End Class
