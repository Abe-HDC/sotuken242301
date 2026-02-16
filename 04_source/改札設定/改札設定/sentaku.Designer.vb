<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sentaku
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
        Button1 = New Button()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(509, 189)
        Button1.Name = "Button1"
        Button1.Size = New Size(184, 79)
        Button1.TabIndex = 0
        Button1.Text = "次へ"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(289, 206)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(125, 27)
        TextBox1.TabIndex = 1
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(97, 206)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(125, 27)
        TextBox2.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(129, 183)
        Label1.Name = "Label1"
        Label1.Size = New Size(54, 20)
        Label1.TabIndex = 3
        Label1.Text = "路線ID"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(325, 183)
        Label2.Name = "Label2"
        Label2.Size = New Size(39, 20)
        Label2.TabIndex = 4
        Label2.Text = "駅ID"
        ' 
        ' sentaku
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(Button1)
        Name = "sentaku"
        Text = "sentaku"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
