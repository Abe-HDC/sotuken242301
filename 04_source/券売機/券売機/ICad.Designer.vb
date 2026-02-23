<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ICad
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
        adDGV = New DataGridView()
        Bbtn = New Button()
        isbtn = New Button()
        Label3 = New Label()
        Label1 = New Label()
        endDTP = New DateTimePicker()
        stDTP = New DateTimePicker()
        hyozi = New Button()
        CType(adDGV, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' adDGV
        ' 
        adDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        adDGV.Location = New Point(0, 0)
        adDGV.Name = "adDGV"
        adDGV.RowHeadersWidth = 51
        adDGV.Size = New Size(883, 331)
        adDGV.TabIndex = 0
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(43, 343)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(151, 95)
        Bbtn.TabIndex = 73
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' isbtn
        ' 
        isbtn.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        isbtn.Location = New Point(651, 343)
        isbtn.Name = "isbtn"
        isbtn.Size = New Size(188, 95)
        isbtn.TabIndex = 72
        isbtn.Text = "領収書の発行"
        isbtn.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label3.Location = New Point(402, 363)
        Label3.Name = "Label3"
        Label3.Size = New Size(49, 31)
        Label3.TabIndex = 77
        Label3.Text = "から"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(260, 333)
        Label1.Name = "Label1"
        Label1.Size = New Size(223, 31)
        Label1.TabIndex = 76
        Label1.Text = "期間を指定してください"
        ' 
        ' endDTP
        ' 
        endDTP.Location = New Point(457, 367)
        endDTP.Name = "endDTP"
        endDTP.Size = New Size(138, 27)
        endDTP.TabIndex = 75
        ' 
        ' stDTP
        ' 
        stDTP.Location = New Point(260, 367)
        stDTP.Name = "stDTP"
        stDTP.Size = New Size(138, 27)
        stDTP.TabIndex = 74
        ' 
        ' hyozi
        ' 
        hyozi.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        hyozi.Location = New Point(475, 400)
        hyozi.Name = "hyozi"
        hyozi.Size = New Size(120, 41)
        hyozi.TabIndex = 78
        hyozi.Text = "表示"
        hyozi.UseVisualStyleBackColor = True
        ' 
        ' ICad
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(882, 453)
        Controls.Add(hyozi)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(endDTP)
        Controls.Add(stDTP)
        Controls.Add(Bbtn)
        Controls.Add(isbtn)
        Controls.Add(adDGV)
        Name = "ICad"
        Text = "入場履歴確認"
        CType(adDGV, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents adDGV As DataGridView
    Friend WithEvents Bbtn As Button
    Friend WithEvents isbtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents endDTP As DateTimePicker
    Friend WithEvents stDTP As DateTimePicker
    Friend WithEvents hyozi As Button
End Class
