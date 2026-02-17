<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ICsad
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
        hyozi = New Button()
        Label3 = New Label()
        Label1 = New Label()
        endDTP = New DateTimePicker()
        stDTP = New DateTimePicker()
        CType(adDGV, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' adDGV
        ' 
        adDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        adDGV.Location = New Point(0, 0)
        adDGV.Name = "adDGV"
        adDGV.RowHeadersWidth = 51
        adDGV.Size = New Size(799, 326)
        adDGV.TabIndex = 0
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(27, 332)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(154, 106)
        Bbtn.TabIndex = 2
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' isbtn
        ' 
        isbtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        isbtn.Location = New Point(585, 332)
        isbtn.Name = "isbtn"
        isbtn.Size = New Size(193, 106)
        isbtn.TabIndex = 3
        isbtn.Text = "領収書の発行"
        isbtn.UseVisualStyleBackColor = True
        ' 
        ' hyozi
        ' 
        hyozi.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        hyozi.Location = New Point(439, 400)
        hyozi.Name = "hyozi"
        hyozi.Size = New Size(120, 41)
        hyozi.TabIndex = 83
        hyozi.Text = "表示"
        hyozi.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label3.Location = New Point(366, 363)
        Label3.Name = "Label3"
        Label3.Size = New Size(49, 31)
        Label3.TabIndex = 82
        Label3.Text = "から"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(224, 333)
        Label1.Name = "Label1"
        Label1.Size = New Size(223, 31)
        Label1.TabIndex = 81
        Label1.Text = "期間を指定してください"
        ' 
        ' endDTP
        ' 
        endDTP.Location = New Point(421, 367)
        endDTP.Name = "endDTP"
        endDTP.Size = New Size(138, 27)
        endDTP.TabIndex = 80
        ' 
        ' stDTP
        ' 
        stDTP.Location = New Point(224, 367)
        stDTP.Name = "stDTP"
        stDTP.Size = New Size(138, 27)
        stDTP.TabIndex = 79
        ' 
        ' ICsad
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(hyozi)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(endDTP)
        Controls.Add(stDTP)
        Controls.Add(isbtn)
        Controls.Add(Bbtn)
        Controls.Add(adDGV)
        Name = "ICsad"
        Text = "入場履歴確認"
        CType(adDGV, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents adDGV As DataGridView
    Friend WithEvents Bbtn As Button
    Friend WithEvents isbtn As Button
    Friend WithEvents hyozi As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents endDTP As DateTimePicker
    Friend WithEvents stDTP As DateTimePicker
End Class
