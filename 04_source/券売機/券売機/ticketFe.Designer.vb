<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ticketFe
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
        FeLel = New Label()
        Label1 = New Label()
        FeTxt = New TextBox()
        isbtn = New Button()
        Bbtn = New Button()
        chLal = New Label()
        Label2 = New Label()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' FeLel
        ' 
        FeLel.BorderStyle = BorderStyle.Fixed3D
        FeLel.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        FeLel.Location = New Point(427, 73)
        FeLel.Name = "FeLel"
        FeLel.Size = New Size(138, 50)
        FeLel.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(273, 74)
        Label1.Name = "Label1"
        Label1.Size = New Size(110, 33)
        Label1.TabIndex = 2
        Label1.Text = "支払い金額"
        ' 
        ' FeTxt
        ' 
        FeTxt.Location = New Point(427, 162)
        FeTxt.Name = "FeTxt"
        FeTxt.Size = New Size(138, 27)
        FeTxt.TabIndex = 3
        ' 
        ' isbtn
        ' 
        isbtn.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        isbtn.Location = New Point(613, 327)
        isbtn.Name = "isbtn"
        isbtn.Size = New Size(188, 95)
        isbtn.TabIndex = 8
        isbtn.Text = "発行"
        isbtn.UseVisualStyleBackColor = True
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(80, 327)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(151, 95)
        Bbtn.TabIndex = 71
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' chLal
        ' 
        chLal.BorderStyle = BorderStyle.Fixed3D
        chLal.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        chLal.Location = New Point(427, 247)
        chLal.Name = "chLal"
        chLal.Size = New Size(138, 50)
        chLal.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label2.Location = New Point(297, 248)
        Label2.Name = "Label2"
        Label2.Size = New Size(72, 33)
        Label2.TabIndex = 6
        Label2.Text = "お釣り"
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label3.Location = New Point(286, 162)
        Label3.Name = "Label3"
        Label3.Size = New Size(97, 33)
        Label3.TabIndex = 72
        Label3.Text = "投入金額"
        ' 
        ' ticketFe
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(882, 453)
        Controls.Add(Label3)
        Controls.Add(Bbtn)
        Controls.Add(isbtn)
        Controls.Add(chLal)
        Controls.Add(Label2)
        Controls.Add(FeTxt)
        Controls.Add(Label1)
        Controls.Add(FeLel)
        Name = "ticketFe"
        Text = "支払い画面"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FeLel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents FeTxt As TextBox
    Friend WithEvents isbtn As Button
    Friend WithEvents Bbtn As Button
    Friend WithEvents chLal As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
