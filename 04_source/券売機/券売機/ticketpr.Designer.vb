<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ticketpr
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
        bprT540 = New Button()
        bprT460 = New Button()
        bprY430 = New Button()
        bpr380 = New Button()
        bpr330 = New Button()
        bprS270 = New Button()
        bpr210 = New Button()
        bpr180 = New Button()
        bpr160 = New Button()
        bExticket = New Button()
        bprticket = New Button()
        bCoticket = New Button()
        SuspendLayout()
        ' 
        ' bprT540
        ' 
        bprT540.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bprT540.Location = New Point(204, 230)
        bprT540.Name = "bprT540"
        bprT540.Size = New Size(141, 91)
        bprT540.TabIndex = 44
        bprT540.Text = "540"
        bprT540.UseVisualStyleBackColor = True
        ' 
        ' bprT460
        ' 
        bprT460.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bprT460.Location = New Point(645, 133)
        bprT460.Name = "bprT460"
        bprT460.Size = New Size(141, 91)
        bprT460.TabIndex = 42
        bprT460.Text = "490"
        bprT460.UseVisualStyleBackColor = True
        ' 
        ' bprY430
        ' 
        bprY430.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bprY430.Location = New Point(498, 133)
        bprY430.Name = "bprY430"
        bprY430.Size = New Size(141, 91)
        bprY430.TabIndex = 40
        bprY430.Text = "430"
        bprY430.UseVisualStyleBackColor = True
        ' 
        ' bpr380
        ' 
        bpr380.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bpr380.Location = New Point(351, 133)
        bpr380.Name = "bpr380"
        bpr380.Size = New Size(141, 91)
        bpr380.TabIndex = 39
        bpr380.Text = "380"
        bpr380.UseVisualStyleBackColor = True
        ' 
        ' bpr330
        ' 
        bpr330.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bpr330.Location = New Point(204, 133)
        bpr330.Name = "bpr330"
        bpr330.Size = New Size(141, 91)
        bpr330.TabIndex = 38
        bpr330.Text = "330"
        bpr330.UseVisualStyleBackColor = True
        ' 
        ' bprS270
        ' 
        bprS270.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bprS270.Location = New Point(645, 36)
        bprS270.Name = "bprS270"
        bprS270.Size = New Size(141, 91)
        bprS270.TabIndex = 36
        bprS270.Text = "270"
        bprS270.UseVisualStyleBackColor = True
        ' 
        ' bpr210
        ' 
        bpr210.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bpr210.Location = New Point(498, 36)
        bpr210.Name = "bpr210"
        bpr210.Size = New Size(141, 91)
        bpr210.TabIndex = 35
        bpr210.Text = "210"
        bpr210.UseVisualStyleBackColor = True
        ' 
        ' bpr180
        ' 
        bpr180.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bpr180.Location = New Point(351, 36)
        bpr180.Name = "bpr180"
        bpr180.Size = New Size(141, 91)
        bpr180.TabIndex = 34
        bpr180.Text = "180"
        bpr180.UseVisualStyleBackColor = True
        ' 
        ' bpr160
        ' 
        bpr160.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bpr160.Location = New Point(204, 36)
        bpr160.Name = "bpr160"
        bpr160.Size = New Size(141, 91)
        bpr160.TabIndex = 33
        bpr160.Text = "160"
        bpr160.UseVisualStyleBackColor = True
        ' 
        ' bExticket
        ' 
        bExticket.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bExticket.Location = New Point(15, 293)
        bExticket.Name = "bExticket"
        bExticket.Size = New Size(183, 122)
        bExticket.TabIndex = 51
        bExticket.Text = "新幹線切符"
        bExticket.UseVisualStyleBackColor = True
        ' 
        ' bprticket
        ' 
        bprticket.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bprticket.Location = New Point(15, 165)
        bprticket.Name = "bprticket"
        bprticket.Size = New Size(183, 122)
        bprticket.TabIndex = 50
        bprticket.Text = "東武伊勢崎線"
        bprticket.UseVisualStyleBackColor = True
        ' 
        ' bCoticket
        ' 
        bCoticket.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bCoticket.Location = New Point(15, 37)
        bCoticket.Name = "bCoticket"
        bCoticket.Size = New Size(183, 122)
        bCoticket.TabIndex = 49
        bCoticket.Text = "JR切符"
        bCoticket.UseVisualStyleBackColor = True
        ' 
        ' ticketpr
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(bExticket)
        Controls.Add(bprticket)
        Controls.Add(bCoticket)
        Controls.Add(bprT540)
        Controls.Add(bprT460)
        Controls.Add(bprY430)
        Controls.Add(bpr380)
        Controls.Add(bpr330)
        Controls.Add(bprS270)
        Controls.Add(bpr210)
        Controls.Add(bpr180)
        Controls.Add(bpr160)
        Name = "ticketpr"
        Text = "切符購入"
        ResumeLayout(False)
    End Sub

    Friend WithEvents bprT540 As Button
    Friend WithEvents bprT460 As Button
    Friend WithEvents bprY430 As Button
    Friend WithEvents bpr380 As Button
    Friend WithEvents bpr330 As Button
    Friend WithEvents bprS270 As Button
    Friend WithEvents bpr210 As Button
    Friend WithEvents bpr180 As Button
    Friend WithEvents bpr160 As Button
    Friend WithEvents bExticket As Button
    Friend WithEvents bprticket As Button
    Friend WithEvents bCoticket As Button
End Class
