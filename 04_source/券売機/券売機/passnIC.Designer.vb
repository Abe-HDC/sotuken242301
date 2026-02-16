<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class passnIC
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
        Bbtn = New Button()
        Label1 = New Label()
        Timer1 = New Timer(components)
        SuspendLayout()
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(37, 302)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(151, 95)
        Bbtn.TabIndex = 77
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Yu Gothic UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(159, 100)
        Label1.Name = "Label1"
        Label1.Size = New Size(474, 71)
        Label1.TabIndex = 76
        Label1.Text = "ICカードをタッチしてください"
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        ' 
        ' passnIC
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Bbtn)
        Controls.Add(Label1)
        Name = "passnIC"
        Text = "passnIC"
        ResumeLayout(False)
    End Sub

    Friend WithEvents Bbtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
End Class
