<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class seticket
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
        Label4 = New Label()
        Fetxt = New TextBox()
        Label3 = New Label()
        Label2 = New Label()
        cabtn = New Button()
        Bbtn = New Button()
        Label1 = New Label()
        Label5 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Label6 = New Label()
        Label7 = New Label()
        Button1 = New Button()
        ComboBox1 = New ComboBox()
        SuspendLayout()
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label4.Location = New Point(658, 191)
        Label4.Name = "Label4"
        Label4.Size = New Size(92, 28)
        Label4.TabIndex = 28
        Label4.Text = "投入金額"
        ' 
        ' Fetxt
        ' 
        Fetxt.Location = New Point(574, 222)
        Fetxt.Name = "Fetxt"
        Fetxt.Size = New Size(176, 27)
        Fetxt.TabIndex = 27
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label3.Location = New Point(642, 22)
        Label3.Name = "Label3"
        Label3.Size = New Size(120, 28)
        Label3.TabIndex = 26
        Label3.Text = "乗り越し運賃"
        ' 
        ' Label2
        ' 
        Label2.BorderStyle = BorderStyle.Fixed3D
        Label2.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label2.Location = New Point(553, 50)
        Label2.Name = "Label2"
        Label2.Size = New Size(209, 71)
        Label2.TabIndex = 25
        ' 
        ' cabtn
        ' 
        cabtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        cabtn.Location = New Point(574, 317)
        cabtn.Name = "cabtn"
        cabtn.Size = New Size(176, 111)
        cabtn.TabIndex = 23
        cabtn.Text = "現金支払い"
        cabtn.UseVisualStyleBackColor = True
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(38, 317)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(176, 111)
        Bbtn.TabIndex = 22
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(85, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(83, 31)
        Label1.TabIndex = 29
        Label1.Text = "出発駅"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label5.Location = New Point(247, 22)
        Label5.Name = "Label5"
        Label5.Size = New Size(83, 31)
        Label5.TabIndex = 30
        Label5.Text = "到着駅"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(65, 56)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(125, 27)
        TextBox1.TabIndex = 31
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(226, 56)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(125, 27)
        TextBox2.TabIndex = 32
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label6.Location = New Point(183, 50)
        Label6.Name = "Label6"
        Label6.Size = New Size(49, 31)
        Label6.TabIndex = 34
        Label6.Text = "から"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label7.Location = New Point(398, 22)
        Label7.Name = "Label7"
        Label7.Size = New Size(133, 31)
        Label7.TabIndex = 35
        Label7.Text = "乗り越した駅"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Button1.Location = New Point(432, 89)
        Button1.Name = "Button1"
        Button1.Size = New Size(99, 57)
        Button1.TabIndex = 36
        Button1.Text = "計算"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(380, 56)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(151, 28)
        ComboBox1.TabIndex = 37
        ' 
        ' seticket
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(ComboBox1)
        Controls.Add(Button1)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(Label5)
        Controls.Add(Label1)
        Controls.Add(Label4)
        Controls.Add(Fetxt)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(cabtn)
        Controls.Add(Bbtn)
        Name = "seticket"
        Text = "乗り越し精算(切符)"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Fetxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cabtn As Button
    Friend WithEvents Bbtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
End Class
