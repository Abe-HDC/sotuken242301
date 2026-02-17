<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sepassFe
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
        babtn = New Button()
        cabtn = New Button()
        Bbtn = New Button()
        baLal = New Label()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label4.Location = New Point(439, 191)
        Label4.Name = "Label4"
        Label4.Size = New Size(92, 28)
        Label4.TabIndex = 19
        Label4.Text = "投入金額"
        ' 
        ' Fetxt
        ' 
        Fetxt.Location = New Point(355, 222)
        Fetxt.Name = "Fetxt"
        Fetxt.Size = New Size(176, 27)
        Fetxt.TabIndex = 18
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label3.Location = New Point(642, 22)
        Label3.Name = "Label3"
        Label3.Size = New Size(120, 28)
        Label3.TabIndex = 17
        Label3.Text = "乗り越し運賃"
        ' 
        ' Label2
        ' 
        Label2.BorderStyle = BorderStyle.Fixed3D
        Label2.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label2.Location = New Point(553, 50)
        Label2.Name = "Label2"
        Label2.Size = New Size(209, 71)
        Label2.TabIndex = 16
        ' 
        ' babtn
        ' 
        babtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        babtn.Location = New Point(586, 317)
        babtn.Name = "babtn"
        babtn.Size = New Size(176, 111)
        babtn.TabIndex = 15
        babtn.Text = "残高支払い"
        babtn.UseVisualStyleBackColor = True
        ' 
        ' cabtn
        ' 
        cabtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        cabtn.Location = New Point(355, 317)
        cabtn.Name = "cabtn"
        cabtn.Size = New Size(176, 111)
        cabtn.TabIndex = 14
        cabtn.Text = "現金支払い"
        cabtn.UseVisualStyleBackColor = True
        ' 
        ' Bbtn
        ' 
        Bbtn.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Bbtn.Location = New Point(38, 317)
        Bbtn.Name = "Bbtn"
        Bbtn.Size = New Size(176, 111)
        Bbtn.TabIndex = 13
        Bbtn.Text = "戻る"
        Bbtn.UseVisualStyleBackColor = True
        ' 
        ' baLal
        ' 
        baLal.BorderStyle = BorderStyle.Fixed3D
        baLal.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        baLal.Location = New Point(38, 50)
        baLal.Name = "baLal"
        baLal.Size = New Size(209, 71)
        baLal.TabIndex = 12
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.Location = New Point(195, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(52, 28)
        Label1.TabIndex = 11
        Label1.Text = "残高"
        ' 
        ' sepassFe
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label4)
        Controls.Add(Fetxt)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(babtn)
        Controls.Add(cabtn)
        Controls.Add(Bbtn)
        Controls.Add(baLal)
        Controls.Add(Label1)
        Name = "sepassFe"
        Text = "乗り越し精算(定期券)"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Fetxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents babtn As Button
    Friend WithEvents cabtn As Button
    Friend WithEvents Bbtn As Button
    Friend WithEvents baLal As Label
    Friend WithEvents Label1 As Label
End Class
