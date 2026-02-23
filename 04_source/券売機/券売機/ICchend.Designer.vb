<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ICchend
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
        Label2 = New Label()
        baLal = New Label()
        Label1 = New Label()
        Bbtn = New Button()
        Timer1 = New Timer(components)
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.BorderStyle = BorderStyle.Fixed3D
        Label2.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label2.Location = New Point(627, 144)
        Label2.Name = "Label2"
        Label2.Size = New Size(55, 37)
        Label2.TabIndex = 84
        Label2.Text = "残高"
        ' 
        ' baLal
        ' 
        baLal.BorderStyle = BorderStyle.Fixed3D
        baLal.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        baLal.Location = New Point(419, 181)
        baLal.Name = "baLal"
        baLal.Size = New Size(263, 81)
        baLal.TabIndex = 83
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(166, 194)
        Label1.Name = "Label1"
        Label1.Size = New Size(200, 48)
        Label1.TabIndex = 82
        Label1.Text = "チャージ完了！"
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(637, 320)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(151, 95)
        Bbtn.TabIndex = 85
        Bbtn.Text = "メインメニューに戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' Timer1
        ' 
        ' 
        ' ICchend
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(882, 453)
        Controls.Add(Bbtn)
        Controls.Add(Label2)
        Controls.Add(baLal)
        Controls.Add(Label1)
        Name = "ICchend"
        Text = "チャージ完了"
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents baLal As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Bbtn As Button
    Friend WithEvents Timer1 As Timer
End Class
