<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tickets
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
        Nbtn = New Button()
        rtRB = New RadioButton()
        owRB = New RadioButton()
        Label4 = New Label()
        Label3 = New Label()
        Btin = New Button()
        Label2 = New Label()
        Label1 = New Label()
        ComboBox2 = New ComboBox()
        ComboBox1 = New ComboBox()
        dayDTP = New DateTimePicker()
        SuspendLayout()
        ' 
        ' Nbtn
        ' 
        Nbtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Nbtn.Location = New Point(577, 300)
        Nbtn.Name = "Nbtn"
        Nbtn.Size = New Size(171, 104)
        Nbtn.TabIndex = 34
        Nbtn.Text = "次へ"
        Nbtn.UseVisualStyleBackColor = True
        ' 
        ' rtRB
        ' 
        rtRB.AutoSize = True
        rtRB.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        rtRB.Location = New Point(102, 198)
        rtRB.Name = "rtRB"
        rtRB.Size = New Size(94, 42)
        rtRB.TabIndex = 33
        rtRB.TabStop = True
        rtRB.Text = "往復"
        rtRB.UseVisualStyleBackColor = True
        ' 
        ' owRB
        ' 
        owRB.AutoSize = True
        owRB.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        owRB.Location = New Point(102, 147)
        owRB.Name = "owRB"
        owRB.Size = New Size(94, 42)
        owRB.TabIndex = 32
        owRB.TabStop = True
        owRB.Text = "片道"
        owRB.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label4.Location = New Point(131, 47)
        Label4.Name = "Label4"
        Label4.Size = New Size(102, 44)
        Label4.TabIndex = 31
        Label4.Text = "日にち"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label3.Location = New Point(502, 94)
        Label3.Name = "Label3"
        Label3.Size = New Size(49, 31)
        Label3.TabIndex = 30
        Label3.Text = "から"
        ' 
        ' Btin
        ' 
        Btin.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Btin.Location = New Point(52, 300)
        Btin.Name = "Btin"
        Btin.Size = New Size(171, 104)
        Btin.TabIndex = 29
        Btin.Text = "戻る"
        Btin.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label2.Location = New Point(600, 50)
        Label2.Name = "Label2"
        Label2.Size = New Size(102, 44)
        Label2.TabIndex = 28
        Label2.Text = "到着駅"
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(348, 50)
        Label1.Name = "Label1"
        Label1.Size = New Size(102, 44)
        Label1.TabIndex = 27
        Label1.Text = "出発駅"
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(557, 97)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(191, 28)
        ComboBox2.TabIndex = 26
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(305, 97)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(191, 28)
        ComboBox1.TabIndex = 25
        ' 
        ' dayDTP
        ' 
        dayDTP.Location = New Point(102, 98)
        dayDTP.Name = "dayDTP"
        dayDTP.Size = New Size(164, 27)
        dayDTP.TabIndex = 35
        ' 
        ' tickets
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(dayDTP)
        Controls.Add(Nbtn)
        Controls.Add(rtRB)
        Controls.Add(owRB)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Btin)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(ComboBox2)
        Controls.Add(ComboBox1)
        Name = "tickets"
        Text = "切符購入"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Nbtn As Button
    Friend WithEvents rtRB As RadioButton
    Friend WithEvents owRB As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Btin As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents dayDTP As DateTimePicker
End Class
