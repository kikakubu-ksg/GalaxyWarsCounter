<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Label2 = New System.Windows.Forms.Label
        Me.字幕ボタン = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.フォント変更ボタン = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 38.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(195, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 51)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "0"
        '
        '字幕ボタン
        '
        Me.字幕ボタン.BackColor = System.Drawing.Color.PaleVioletRed
        Me.字幕ボタン.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.字幕ボタン.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.字幕ボタン.Location = New System.Drawing.Point(83, 12)
        Me.字幕ボタン.Name = "字幕ボタン"
        Me.字幕ボタン.Size = New System.Drawing.Size(89, 28)
        Me.字幕ボタン.TabIndex = 2
        Me.字幕ボタン.Text = "字幕表示"
        Me.字幕ボタン.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 60)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "↑：増やす" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "↓：減らす" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ESC：リセット"
        '
        'フォント変更ボタン
        '
        Me.フォント変更ボタン.BackColor = System.Drawing.Color.LightSeaGreen
        Me.フォント変更ボタン.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.フォント変更ボタン.ForeColor = System.Drawing.Color.White
        Me.フォント変更ボタン.Location = New System.Drawing.Point(83, 46)
        Me.フォント変更ボタン.Name = "フォント変更ボタン"
        Me.フォント変更ボタン.Size = New System.Drawing.Size(89, 28)
        Me.フォント変更ボタン.TabIndex = 4
        Me.フォント変更ボタン.Text = "フォント変更"
        Me.フォント変更ボタン.UseVisualStyleBackColor = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkBlue
        Me.BackgroundImage = Global.Osashimi.My.Resources.Resources.tera
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(259, 82)
        Me.Controls.Add(Me.フォント変更ボタン)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.字幕ボタン)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "GWC"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 字幕ボタン As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents フォント変更ボタン As System.Windows.Forms.Button

End Class
