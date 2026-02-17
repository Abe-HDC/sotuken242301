<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ticketEx
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
        bExticket = New Button()
        bprticket = New Button()
        bCoticket = New Button()
        bprY430 = New Button()
        bpr380 = New Button()
        bpr330 = New Button()
        bprK270 = New Button()
        bprS270 = New Button()
        bpr210 = New Button()
        bpr180 = New Button()
        bpr160 = New Button()
        SuspendLayout()
        ' 
        ' bExticket
        ' 
        bExticket.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bExticket.Location = New Point(15, 290)
        bExticket.Name = "bExticket"
        bExticket.Size = New Size(183, 122)
        bExticket.TabIndex = 48
        bExticket.Text = "新幹線切符"
        bExticket.UseVisualStyleBackColor = True
        ' 
        ' bprticket
        ' 
        bprticket.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bprticket.Location = New Point(15, 162)
        bprticket.Name = "bprticket"
        bprticket.Size = New Size(183, 122)
        bprticket.TabIndex = 47
        bprticket.Text = "東武伊勢崎線"
        bprticket.UseVisualStyleBackColor = True
        ' 
        ' bCoticket
        ' 
        bCoticket.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bCoticket.Location = New Point(15, 34)
        bCoticket.Name = "bCoticket"
        bCoticket.Size = New Size(183, 122)
        bCoticket.TabIndex = 46
        bCoticket.Text = "JR切符"
        bCoticket.UseVisualStyleBackColor = True
        ' 
        ' bprY430
        ' 
        bprY430.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bprY430.Location = New Point(650, 131)
        bprY430.Name = "bprY430"
        bprY430.Size = New Size(141, 91)
        bprY430.TabIndex = 62
        bprY430.Text = "長野"
        bprY430.UseVisualStyleBackColor = True
        ' 
        ' bpr380
        ' 
        bpr380.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bpr380.Location = New Point(503, 131)
        bpr380.Name = "bpr380"
        bpr380.Size = New Size(141, 91)
        bpr380.TabIndex = 61
        bpr380.Text = "上田"
        bpr380.UseVisualStyleBackColor = True
        ' 
        ' bpr330
        ' 
        bpr330.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bpr330.Location = New Point(356, 131)
        bpr330.Name = "bpr330"
        bpr330.Size = New Size(141, 91)
        bpr330.TabIndex = 60
        bpr330.Text = "佐久平"
        bpr330.UseVisualStyleBackColor = True
        ' 
        ' bprK270
        ' 
        bprK270.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bprK270.Location = New Point(209, 131)
        bprK270.Name = "bprK270"
        bprK270.Size = New Size(141, 91)
        bprK270.TabIndex = 59
        bprK270.Text = "軽井沢"
        bprK270.UseVisualStyleBackColor = True
        ' 
        ' bprS270
        ' 
        bprS270.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bprS270.Location = New Point(650, 34)
        bprS270.Name = "bprS270"
        bprS270.Size = New Size(141, 91)
        bprS270.TabIndex = 58
        bprS270.Text = "高崎"
        bprS270.UseVisualStyleBackColor = True
        ' 
        ' bpr210
        ' 
        bpr210.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bpr210.Location = New Point(503, 34)
        bpr210.Name = "bpr210"
        bpr210.Size = New Size(141, 91)
        bpr210.TabIndex = 57
        bpr210.Text = "大宮"
        bpr210.UseVisualStyleBackColor = True
        ' 
        ' bpr180
        ' 
        bpr180.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bpr180.Location = New Point(356, 34)
        bpr180.Name = "bpr180"
        bpr180.Size = New Size(141, 91)
        bpr180.TabIndex = 56
        bpr180.Text = "上野"
        bpr180.UseVisualStyleBackColor = True
        ' 
        ' bpr160
        ' 
        bpr160.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bpr160.Location = New Point(209, 34)
        bpr160.Name = "bpr160"
        bpr160.Size = New Size(141, 91)
        bpr160.TabIndex = 55
        bpr160.Text = "東京"
        bpr160.UseVisualStyleBackColor = True
        ' 
        ' ticketEx
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(bprY430)
        Controls.Add(bpr380)
        Controls.Add(bpr330)
        Controls.Add(bprK270)
        Controls.Add(bprS270)
        Controls.Add(bpr210)
        Controls.Add(bpr180)
        Controls.Add(bpr160)
        Controls.Add(bExticket)
        Controls.Add(bprticket)
        Controls.Add(bCoticket)
        Name = "ticketEx"
        Text = "切符購入"
        ResumeLayout(False)
    End Sub
    Friend WithEvents bExticket As Button
    Friend WithEvents bprticket As Button
    Friend WithEvents bCoticket As Button
    Friend WithEvents bprY430 As Button
    Friend WithEvents bpr380 As Button
    Friend WithEvents bpr330 As Button
    Friend WithEvents bprK270 As Button
    Friend WithEvents bprS270 As Button
    Friend WithEvents bpr210 As Button
    Friend WithEvents bpr180 As Button
    Friend WithEvents bpr160 As Button
End Class
