<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.output2 = New System.Windows.Forms.Button()
        Me.showbox2 = New System.Windows.Forms.PictureBox()
        Me.preview2 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.colorchoce2 = New System.Windows.Forms.Button()
        Me.clear_text2 = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.colorchoce = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fontsize = New System.Windows.Forms.TextBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.fontlist = New System.Windows.Forms.ListBox()
        Me.showbox = New System.Windows.Forms.PictureBox()
        Me.preview = New System.Windows.Forms.Button()
        Me.output = New System.Windows.Forms.Button()
        Me.clear_text = New System.Windows.Forms.Button()
        Me.openfile = New System.Windows.Forms.TextBox()
        Me.open = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.output3 = New System.Windows.Forms.Button()
        Me.preview3 = New System.Windows.Forms.Button()
        Me.clear_text3 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.servent_def = New System.Windows.Forms.NumericUpDown()
        Me.servent_atk = New System.Windows.Forms.NumericUpDown()
        Me.servent_hp = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.showbox3 = New System.Windows.Forms.PictureBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.showbox4 = New System.Windows.Forms.PictureBox()
        Me.colorselect = New System.Windows.Forms.ColorDialog()
        Me.colorselect2 = New System.Windows.Forms.ColorDialog()
        Me.TabPage2.SuspendLayout()
        CType(Me.showbox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.showbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.servent_def, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.servent_atk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.servent_hp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.showbox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.showbox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "jpg"
        Me.SaveFileDialog1.Filter = "jpg檔案|*.jpg|png檔案|*.png"
        Me.SaveFileDialog1.RestoreDirectory = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.output2)
        Me.TabPage2.Controls.Add(Me.showbox2)
        Me.TabPage2.Controls.Add(Me.preview2)
        Me.TabPage2.Controls.Add(Me.TextBox2)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.colorchoce2)
        Me.TabPage2.Controls.Add(Me.clear_text2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 21)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(648, 389)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "士兵"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'output2
        '
        Me.output2.Location = New System.Drawing.Point(473, 322)
        Me.output2.Name = "output2"
        Me.output2.Size = New System.Drawing.Size(75, 23)
        Me.output2.TabIndex = 23
        Me.output2.Text = "匯出"
        Me.output2.UseVisualStyleBackColor = True
        '
        'showbox2
        '
        Me.showbox2.Location = New System.Drawing.Point(6, 6)
        Me.showbox2.Name = "showbox2"
        Me.showbox2.Size = New System.Drawing.Size(232, 339)
        Me.showbox2.TabIndex = 15
        Me.showbox2.TabStop = False
        '
        'preview2
        '
        Me.preview2.Location = New System.Drawing.Point(311, 322)
        Me.preview2.Name = "preview2"
        Me.preview2.Size = New System.Drawing.Size(75, 23)
        Me.preview2.TabIndex = 22
        Me.preview2.Text = "預覽"
        Me.preview2.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(281, 40)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(201, 22)
        Me.TextBox2.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(289, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 14)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "顏色"
        '
        'colorchoce2
        '
        Me.colorchoce2.BackColor = System.Drawing.Color.Black
        Me.colorchoce2.Location = New System.Drawing.Point(330, 105)
        Me.colorchoce2.Name = "colorchoce2"
        Me.colorchoce2.Size = New System.Drawing.Size(75, 23)
        Me.colorchoce2.TabIndex = 19
        Me.colorchoce2.UseVisualStyleBackColor = False
        '
        'clear_text2
        '
        Me.clear_text2.Location = New System.Drawing.Point(392, 322)
        Me.clear_text2.Name = "clear_text2"
        Me.clear_text2.Size = New System.Drawing.Size(75, 23)
        Me.clear_text2.TabIndex = 16
        Me.clear_text2.Text = "清除"
        Me.clear_text2.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.showbox)
        Me.TabPage1.Controls.Add(Me.preview)
        Me.TabPage1.Controls.Add(Me.output)
        Me.TabPage1.Controls.Add(Me.clear_text)
        Me.TabPage1.Location = New System.Drawing.Point(4, 21)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(648, 389)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "領地"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.colorchoce)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.fontsize)
        Me.GroupBox1.Controls.Add(Me.RichTextBox1)
        Me.GroupBox1.Controls.Add(Me.fontlist)
        Me.GroupBox1.Location = New System.Drawing.Point(244, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(390, 191)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "文字敘述"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(199, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 14)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "顏色"
        '
        'colorchoce
        '
        Me.colorchoce.BackColor = System.Drawing.Color.Black
        Me.colorchoce.Location = New System.Drawing.Point(279, 151)
        Me.colorchoce.Name = "colorchoce"
        Me.colorchoce.Size = New System.Drawing.Size(75, 23)
        Me.colorchoce.TabIndex = 19
        Me.colorchoce.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(196, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 14)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "字體大小"
        '
        'fontsize
        '
        Me.fontsize.Location = New System.Drawing.Point(279, 123)
        Me.fontsize.Name = "fontsize"
        Me.fontsize.Size = New System.Drawing.Size(32, 22)
        Me.fontsize.TabIndex = 17
        Me.fontsize.Text = "10"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(18, 21)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(175, 139)
        Me.RichTextBox1.TabIndex = 12
        Me.RichTextBox1.Text = ""
        '
        'fontlist
        '
        Me.fontlist.FormattingEnabled = True
        Me.fontlist.ItemHeight = 12
        Me.fontlist.Location = New System.Drawing.Point(199, 21)
        Me.fontlist.Name = "fontlist"
        Me.fontlist.Size = New System.Drawing.Size(177, 88)
        Me.fontlist.TabIndex = 15
        '
        'showbox
        '
        Me.showbox.Location = New System.Drawing.Point(6, 6)
        Me.showbox.Name = "showbox"
        Me.showbox.Size = New System.Drawing.Size(232, 339)
        Me.showbox.TabIndex = 14
        Me.showbox.TabStop = False
        '
        'preview
        '
        Me.preview.Location = New System.Drawing.Point(311, 322)
        Me.preview.Name = "preview"
        Me.preview.Size = New System.Drawing.Size(75, 23)
        Me.preview.TabIndex = 13
        Me.preview.Text = "預覽"
        Me.preview.UseVisualStyleBackColor = True
        '
        'output
        '
        Me.output.Location = New System.Drawing.Point(476, 322)
        Me.output.Name = "output"
        Me.output.Size = New System.Drawing.Size(67, 23)
        Me.output.TabIndex = 10
        Me.output.Text = "匯出"
        Me.output.UseVisualStyleBackColor = True
        '
        'clear_text
        '
        Me.clear_text.Location = New System.Drawing.Point(392, 322)
        Me.clear_text.Name = "clear_text"
        Me.clear_text.Size = New System.Drawing.Size(75, 23)
        Me.clear_text.TabIndex = 16
        Me.clear_text.Text = "清除"
        Me.clear_text.UseVisualStyleBackColor = True
        '
        'openfile
        '
        Me.openfile.Location = New System.Drawing.Point(12, 13)
        Me.openfile.Name = "openfile"
        Me.openfile.Size = New System.Drawing.Size(553, 22)
        Me.openfile.TabIndex = 9
        '
        'open
        '
        Me.open.Location = New System.Drawing.Point(571, 13)
        Me.open.Name = "open"
        Me.open.Size = New System.Drawing.Size(67, 23)
        Me.open.TabIndex = 8
        Me.open.Text = "圖片"
        Me.open.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(0, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(656, 414)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.output3)
        Me.TabPage3.Controls.Add(Me.preview3)
        Me.TabPage3.Controls.Add(Me.clear_text3)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.showbox3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 21)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(648, 389)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "英靈"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'output3
        '
        Me.output3.Location = New System.Drawing.Point(473, 322)
        Me.output3.Name = "output3"
        Me.output3.Size = New System.Drawing.Size(75, 23)
        Me.output3.TabIndex = 26
        Me.output3.Text = "匯出"
        Me.output3.UseVisualStyleBackColor = True
        '
        'preview3
        '
        Me.preview3.Location = New System.Drawing.Point(311, 322)
        Me.preview3.Name = "preview3"
        Me.preview3.Size = New System.Drawing.Size(75, 23)
        Me.preview3.TabIndex = 25
        Me.preview3.Text = "預覽"
        Me.preview3.UseVisualStyleBackColor = True
        '
        'clear_text3
        '
        Me.clear_text3.Location = New System.Drawing.Point(392, 322)
        Me.clear_text3.Name = "clear_text3"
        Me.clear_text3.Size = New System.Drawing.Size(75, 23)
        Me.clear_text3.TabIndex = 24
        Me.clear_text3.Text = "清除"
        Me.clear_text3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.servent_def)
        Me.GroupBox2.Controls.Add(Me.servent_atk)
        Me.GroupBox2.Controls.Add(Me.servent_hp)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(244, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(390, 163)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "能力值"
        '
        'servent_def
        '
        Me.servent_def.Location = New System.Drawing.Point(170, 114)
        Me.servent_def.Name = "servent_def"
        Me.servent_def.Size = New System.Drawing.Size(120, 22)
        Me.servent_def.TabIndex = 29
        Me.servent_def.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'servent_atk
        '
        Me.servent_atk.Location = New System.Drawing.Point(170, 66)
        Me.servent_atk.Name = "servent_atk"
        Me.servent_atk.Size = New System.Drawing.Size(120, 22)
        Me.servent_atk.TabIndex = 28
        Me.servent_atk.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'servent_hp
        '
        Me.servent_hp.Location = New System.Drawing.Point(170, 24)
        Me.servent_hp.Name = "servent_hp"
        Me.servent_hp.Size = New System.Drawing.Size(120, 22)
        Me.servent_hp.TabIndex = 27
        Me.servent_hp.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(108, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 19)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "ATK"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(108, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 19)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "DEF"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(108, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 19)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "HP"
        '
        'showbox3
        '
        Me.showbox3.Location = New System.Drawing.Point(6, 6)
        Me.showbox3.Name = "showbox3"
        Me.showbox3.Size = New System.Drawing.Size(232, 339)
        Me.showbox3.TabIndex = 16
        Me.showbox3.TabStop = False
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.showbox4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 21)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(648, 389)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "????"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'showbox4
        '
        Me.showbox4.Location = New System.Drawing.Point(6, 6)
        Me.showbox4.Name = "showbox4"
        Me.showbox4.Size = New System.Drawing.Size(232, 339)
        Me.showbox4.TabIndex = 17
        Me.showbox4.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 450)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.openfile)
        Me.Controls.Add(Me.open)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.showbox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.showbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.servent_def, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.servent_atk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.servent_hp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.showbox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.showbox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents openfile As System.Windows.Forms.TextBox
    Friend WithEvents open As System.Windows.Forms.Button
    Friend WithEvents output As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents preview As System.Windows.Forms.Button
    Friend WithEvents showbox As System.Windows.Forms.PictureBox
    Friend WithEvents clear_text As System.Windows.Forms.Button
    Friend WithEvents fontlist As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fontsize As System.Windows.Forms.TextBox
    Friend WithEvents colorchoce As System.Windows.Forms.Button
    Friend WithEvents colorselect As System.Windows.Forms.ColorDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents colorchoce2 As System.Windows.Forms.Button
    Friend WithEvents clear_text2 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents preview2 As System.Windows.Forms.Button
    Friend WithEvents showbox2 As System.Windows.Forms.PictureBox
    Friend WithEvents output2 As System.Windows.Forms.Button
    Friend WithEvents colorselect2 As System.Windows.Forms.ColorDialog
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents showbox3 As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents showbox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents output3 As System.Windows.Forms.Button
    Friend WithEvents preview3 As System.Windows.Forms.Button
    Friend WithEvents clear_text3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents servent_hp As System.Windows.Forms.NumericUpDown
    Friend WithEvents servent_atk As System.Windows.Forms.NumericUpDown
    Friend WithEvents servent_def As System.Windows.Forms.NumericUpDown

End Class
