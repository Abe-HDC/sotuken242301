<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainsf
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
        ictouch = New Button()
        bofs = New Button()
        SuspendLayout()
        ' 
        ' bticket
        ' 
        bticket.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bticket.Location = New Point(141, 67)
        bticket.Name = "bticket"
        bticket.Size = New Size(206, 121)
        bticket.TabIndex = 0
        bticket.Text = "切符購入"
        bticket.UseVisualStyleBackColor = True
        ' 
        ' bpass
        ' 
        bpass.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bpass.Location = New Point(444, 67)
        bpass.Name = "bpass"
        bpass.Size = New Size(206, 121)
        bpass.TabIndex = 1
        bpass.Text = "定期券購入"
        bpass.UseVisualStyleBackColor = True
        ' 
        ' ictouch
        ' 
        ictouch.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        ictouch.Location = New Point(141, 256)
        ictouch.Name = "ictouch"
        ictouch.Size = New Size(206, 121)
        ictouch.TabIndex = 2
        ictouch.Text = "入場履歴確認"
        ictouch.UseVisualStyleBackColor = True
        ' 
        ' bofs
        ' 
        bofs.Font = New Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        bofs.Location = New Point(444, 256)
        bofs.Name = "bofs"
        bofs.Size = New Size(206, 121)
        bofs.TabIndex = 3
        bofs.Text = "乗り越し精算"
        bofs.UseVisualStyleBackColor = True
        ' 
        ' mainf
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(bofs)
        Controls.Add(ictouch)
        Controls.Add(bpass)
        Controls.Add(bticket)
        Name = "mainf"
        Text = "メインメニュー"
        ResumeLayout(False)
    End Sub

    Friend WithEvents bticket As Button
    Friend WithEvents bpass As Button
    Friend WithEvents ictouch As Button
    Friend WithEvents bofs As Button

End Class
