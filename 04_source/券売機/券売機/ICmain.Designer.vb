<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ICmain
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
        baLal = New Label()
        Label1 = New Label()
        chbtn = New Button()
        adbtn = New Button()
        Bbtn = New Button()
        SuspendLayout()
        ' 
        ' baLal
        ' 
        baLal.BorderStyle = BorderStyle.Fixed3D
        baLal.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        baLal.Location = New Point(492, 307)
        baLal.Name = "baLal"
        baLal.Size = New Size(263, 81)
        baLal.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.BorderStyle = BorderStyle.Fixed3D
        Label1.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(700, 270)
        Label1.Name = "Label1"
        Label1.Size = New Size(55, 37)
        Label1.TabIndex = 1
        Label1.Text = "残高"
        ' 
        ' chbtn
        ' 
        chbtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        chbtn.Location = New Point(510, 104)
        chbtn.Name = "chbtn"
        chbtn.Size = New Size(226, 81)
        chbtn.TabIndex = 2
        chbtn.Text = "チャージ"
        chbtn.UseVisualStyleBackColor = True
        ' 
        ' adbtn
        ' 
        adbtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        adbtn.Location = New Point(127, 104)
        adbtn.Name = "adbtn"
        adbtn.Size = New Size(226, 81)
        adbtn.TabIndex = 3
        adbtn.Text = "入場履歴確認"
        adbtn.UseVisualStyleBackColor = True
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(127, 293)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(151, 95)
        Bbtn.TabIndex = 72
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' ICmain
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(882, 453)
        Controls.Add(Bbtn)
        Controls.Add(adbtn)
        Controls.Add(chbtn)
        Controls.Add(Label1)
        Controls.Add(baLal)
        Name = "ICmain"
        Text = "ICカードチャージ・入場履歴確認"
        ResumeLayout(False)
    End Sub

    Friend WithEvents baLal As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chbtn As Button
    Friend WithEvents adbtn As Button
    Friend WithEvents Bbtn As Button
End Class
