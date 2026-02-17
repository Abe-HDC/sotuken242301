<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainf
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        bticket = New Button()
        bpass = New Button()
        bictouch = New Button()
        bicissue = New Button()
        SuspendLayout()
        ' 
        ' bticket
        ' 
        bticket.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bticket.Location = New Point(137, 89)
        bticket.Name = "bticket"
        bticket.Size = New Size(206, 121)
        bticket.TabIndex = 0
        bticket.Text = "切符購入"
        bticket.UseVisualStyleBackColor = True
        ' 
        ' bpass
        ' 
        bpass.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bpass.Location = New Point(455, 89)
        bpass.Name = "bpass"
        bpass.Size = New Size(206, 121)
        bpass.TabIndex = 1
        bpass.Text = "定期券購入"
        bpass.UseVisualStyleBackColor = True
        ' 
        ' bictouch
        ' 
        bictouch.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bictouch.Location = New Point(137, 258)
        bictouch.Name = "bictouch"
        bictouch.Size = New Size(206, 121)
        bictouch.TabIndex = 2
        bictouch.Text = "ICカードチャージ入場履歴確認"
        bictouch.UseVisualStyleBackColor = True
        ' 
        ' bicissue
        ' 
        bicissue.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bicissue.Location = New Point(455, 258)
        bicissue.Name = "bicissue"
        bicissue.Size = New Size(206, 121)
        bicissue.TabIndex = 3
        bicissue.Text = "ICカード発行"
        bicissue.UseVisualStyleBackColor = True
        ' 
        ' mainf
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(bicissue)
        Controls.Add(bictouch)
        Controls.Add(bpass)
        Controls.Add(bticket)
        Name = "mainf"
        Text = "メインメニュー"
        ResumeLayout(False)
    End Sub

    Friend WithEvents bticket As Button
    Friend WithEvents bpass As Button
    Friend WithEvents bictouch As Button
    Friend WithEvents bicissue As Button

End Class
