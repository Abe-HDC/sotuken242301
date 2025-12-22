<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class passn
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
        Button1 = New Button()
        coBtn = New Button()
        nBtn = New Button()
        SuspendLayout()
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(67, 306)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(151, 95)
        Bbtn.TabIndex = 73
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Button1.Location = New Point(285, 91)
        Button1.Name = "Button1"
        Button1.Size = New Size(222, 130)
        Button1.TabIndex = 79
        Button1.Text = "新規ICカード発行なし"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' coBtn
        ' 
        coBtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        coBtn.Location = New Point(539, 91)
        coBtn.Name = "coBtn"
        coBtn.Size = New Size(222, 130)
        coBtn.TabIndex = 78
        coBtn.Text = "継続"
        coBtn.UseVisualStyleBackColor = True
        ' 
        ' nBtn
        ' 
        nBtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        nBtn.Location = New Point(36, 91)
        nBtn.Name = "nBtn"
        nBtn.Size = New Size(222, 130)
        nBtn.TabIndex = 77
        nBtn.Text = "新規ICカード発行あり"
        nBtn.UseVisualStyleBackColor = True
        ' 
        ' passn
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button1)
        Controls.Add(coBtn)
        Controls.Add(nBtn)
        Controls.Add(Bbtn)
        Name = "passn"
        Text = "定期券購入"
        ResumeLayout(False)
    End Sub

    Friend WithEvents Bbtn As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents coBtn As Button
    Friend WithEvents nBtn As Button
End Class
