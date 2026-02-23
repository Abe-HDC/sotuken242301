<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ICpay
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
        Label1 = New Label()
        Label2 = New Label()
        baLal = New Label()
        Febtn = New Button()
        FeLel = New Label()
        FeTxt = New TextBox()
        Label3 = New Label()
        Bbtn = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(136, 102)
        Label1.Name = "Label1"
        Label1.Size = New Size(110, 33)
        Label1.TabIndex = 73
        Label1.Text = "チャージ金額"
        ' 
        ' Label2
        ' 
        Label2.BorderStyle = BorderStyle.Fixed3D
        Label2.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label2.Location = New Point(645, 99)
        Label2.Name = "Label2"
        Label2.Size = New Size(134, 37)
        Label2.TabIndex = 81
        Label2.Text = "チャージ前残高"
        ' 
        ' baLal
        ' 
        baLal.BorderStyle = BorderStyle.Fixed3D
        baLal.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        baLal.Location = New Point(516, 136)
        baLal.Name = "baLal"
        baLal.Size = New Size(263, 81)
        baLal.TabIndex = 80
        ' 
        ' Febtn
        ' 
        Febtn.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Febtn.Location = New Point(606, 303)
        Febtn.Name = "Febtn"
        Febtn.Size = New Size(188, 95)
        Febtn.TabIndex = 77
        Febtn.Text = "チャージ"
        Febtn.UseVisualStyleBackColor = True
        ' 
        ' FeLel
        ' 
        FeLel.BorderStyle = BorderStyle.Fixed3D
        FeLel.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        FeLel.Location = New Point(290, 101)
        FeLel.Name = "FeLel"
        FeLel.Size = New Size(138, 50)
        FeLel.TabIndex = 72
        ' 
        ' FeTxt
        ' 
        FeTxt.Location = New Point(290, 190)
        FeTxt.Name = "FeTxt"
        FeTxt.Size = New Size(138, 27)
        FeTxt.TabIndex = 74
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label3.Location = New Point(149, 184)
        Label3.Name = "Label3"
        Label3.Size = New Size(97, 33)
        Label3.TabIndex = 79
        Label3.Text = "投入金額"
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(73, 303)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(151, 95)
        Bbtn.TabIndex = 78
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' ICpay
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(882, 453)
        Controls.Add(Label2)
        Controls.Add(baLal)
        Controls.Add(Label3)
        Controls.Add(Bbtn)
        Controls.Add(Febtn)
        Controls.Add(FeTxt)
        Controls.Add(Label1)
        Controls.Add(FeLel)
        Name = "ICpay"
        Text = "ICカードチャージ"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents baLal As Label
    Friend WithEvents Febtn As Button
    Friend WithEvents FeLel As Label
    Friend WithEvents FeTxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Bbtn As Button
End Class
