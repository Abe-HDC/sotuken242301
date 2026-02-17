<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ICreis
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
        components = New ComponentModel.Container()
        Label1 = New Label()
        Label2 = New Label()
        Bbtn = New Button()
        Timer1 = New Timer(components)
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Yu Gothic UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(186, 151)
        Label1.Name = "Label1"
        Label1.Size = New Size(460, 54)
        Label1.TabIndex = 85
        Label1.Text = "領収書の発行がされました！"
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Yu Gothic UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label2.Location = New Point(197, 196)
        Label2.Name = "Label2"
        Label2.Size = New Size(426, 54)
        Label2.TabIndex = 86
        Label2.Text = "お取り忘れにご注意ください"
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(605, 316)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(151, 95)
        Bbtn.TabIndex = 87
        Bbtn.Text = "メインメニューに戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' ICreis
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Bbtn)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "ICreis"
        Text = "領収書の発行確認"
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Bbtn As Button
    Friend WithEvents Timer1 As Timer
End Class
