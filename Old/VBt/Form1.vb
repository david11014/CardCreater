Imports System.IO

Public Class Form1

    Dim nowfiledir As String = Directory.GetCurrentDirectory()
    Dim boad As New Bitmap(232, 339)
    Dim boad2 As New Bitmap(232, 339)
    Dim boad3 As New Bitmap(232, 339)
    Dim G As Graphics = Graphics.FromImage(boad)
    Dim G2 As Graphics = Graphics.FromImage(boad2)
    Dim G3 As Graphics = Graphics.FromImage(boad3)
    Dim file As String
    Dim file2 As String
    Dim file3 As String
    Dim im As Image
    Dim brush As Drawing.TextureBrush
    Dim brush2 As Drawing.TextureBrush
    Dim brush3 As Drawing.TextureBrush
    Dim fo As String
    Dim x1 As Integer = 10
    Dim x2 As Integer = 60
    Dim y1 As Integer = 250
    Dim y2 As Integer = 283

    Private Class test

        Dim boad As New Bitmap(232, 339)
        Dim G As Graphics = Graphics.FromImage(boad)
        Dim file As String
        Dim brush As Drawing.TextureBrush

    End Class

    '----------------------item----------------------

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PopulateListBoxWithFonts()
        colorchoce.BackColor = colorselect.Color
        fontlist.SelectedItem = "細明體"

        'RichTextBox1.Text = "sdlfsfjsoif" + vbCrLf + "soidfjosif"
    End Sub

    Private Sub open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles open.Click

        Dim result As Boolean = OpenFileDialog1.ShowDialog()

        If result = True Then
            openfile.Text = OpenFileDialog1.FileName
            If TabControl1.SelectedIndex = 0 Then
                file = openfile.Text
            ElseIf TabControl1.SelectedIndex = 1 Then
                file2 = openfile.Text
            ElseIf TabControl1.SelectedIndex = 2 Then
                file3 = openfile.Text
            End If

        End If
        show()
    End Sub

    '-------------------preview----------------------

    Private Sub preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles preview.Click

        show()
        word(RichTextBox1.Text, x1, y1)

    End Sub

    Private Sub preview2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles preview2.Click

        show()
        word(TextBox2.Text, x2, y2)

    End Sub

    Private Sub preview3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles preview3.Click

        show()
        servent_val()


    End Sub

    '-------------------output------------------------

    Private Sub output_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles output.Click
        save()
    End Sub

    Private Sub output2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles output2.Click
        save()
    End Sub

    Private Sub output3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles output3.Click
        save()
    End Sub

    '--------------------clear------------------------

    Private Sub clear_text_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clear_text.Click

        RichTextBox1.Text = ""
        show()

    End Sub

    Private Sub Clear_text2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clear_text2.Click
        TextBox2.Text = ""
        show()
    End Sub

    Private Sub clear_text3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clear_text3.Click
        show()
    End Sub



    Private Sub colorchoce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles colorchoce.Click

        colorselect.ShowDialog()
        colorchoce.BackColor = colorselect.Color
        word(RichTextBox1.Text, x1, y1)

    End Sub

    Private Sub colorchoce2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles colorchoce2.Click

        colorselect.ShowDialog()
        colorchoce2.BackColor = colorselect2.Color
        word(RichTextBox1.Text, x2, y2)

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fontlist.SelectedIndexChanged

        fo = fontlist.SelectedItem

    End Sub

    Private Sub PopulateListBoxWithFonts()

        Dim oneFontFamily As FontFamily
        For Each oneFontFamily In FontFamily.Families
            fontlist.Items.Add(oneFontFamily.Name)
        Next

    End Sub


    '-----------------------function-------------------------

    Private Sub show()

        If TabControl1.SelectedIndex = 0 And file <> vbNullString Then
            im = Image.FromFile(file)
            brush = New Drawing.TextureBrush(im, Drawing2D.WrapMode.TileFlipXY)
            G.FillRectangle(brush, 0, 0, 232, 339)
            showbox.Image = boad
        ElseIf TabControl1.SelectedIndex = 1 And file2 <> vbNullString Then
            im = Image.FromFile(file2)
            brush2 = New Drawing.TextureBrush(im, Drawing2D.WrapMode.TileFlipXY)
            G2.FillRectangle(brush2, 0, 0, 232, 339)
            showbox2.Image = boad2
        ElseIf TabControl1.SelectedIndex = 2 And file3 <> vbNullString Then
            im = Image.FromFile(file3)
            brush3 = New Drawing.TextureBrush(im, Drawing2D.WrapMode.TileFlipXY)
            G3.FillRectangle(brush3, 0, 0, 232, 339)
            showbox3.Image = boad3
        End If

    End Sub

    Private Sub save()

        Dim result As Boolean = SaveFileDialog1.ShowDialog()

        If result = True Then

            If (SaveFileDialog1.FileName <> vbNullString) Then

                If SaveFileDialog1.FilterIndex = 1 Then
                    If TabControl1.SelectedIndex = 0 Then
                        boad.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                    ElseIf TabControl1.SelectedIndex = 1 Then
                        boad2.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                    ElseIf TabControl1.SelectedIndex = 2 Then
                        boad3.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                    End If
                ElseIf SaveFileDialog1.FilterIndex = 2 Then
                    If TabControl1.SelectedIndex = 0 Then
                        boad.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png)
                    ElseIf TabControl1.SelectedIndex = 1 Then
                        boad2.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png)
                    ElseIf TabControl1.SelectedIndex = 2 Then
                        boad3.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png)
                    End If
                End If

                
            End If
        End If



    End Sub

    Private Sub word(ByVal s As String, ByVal x As Integer, ByVal y As Integer)

        Dim f As New Font(fo, fontsize.Text)
        Dim b As New SolidBrush(colorselect.Color)
        Dim b2 As New SolidBrush(colorselect2.Color)

        If TabControl1.SelectedIndex = 0 Then
            G.DrawString(s, f, b, x, y)
            showbox.Image = boad
        ElseIf TabControl1.SelectedIndex = 1 Then
            G2.DrawString(s, f, b2, x, y)
            showbox2.Image = boad2
        End If

    End Sub

    Private Sub n(ByRef t As String)

        Dim slong As Integer = Len(t)

    End Sub

    Private Sub servent_val()

        Dim hp(2), atk(2), def(2) As Integer
        Dim f1, f2 As String

        hp(1) = servent_hp.Value / 10
        atk(1) = servent_atk.Value / 10
        def(1) = servent_def.Value / 10

        'MsgBox(hp(1))

        hp(2) = servent_hp.Value Mod 10
        atk(2) = servent_atk.Value Mod 10
        def(2) = servent_def.Value Mod 10

        'MsgBox(hp(2))

        Dim hp0, hp1, hp2, at0, at1, at2, de0, de1, de2 As Integer

        'hp
        hp2 = 50
        hp1 = 63
        hp0 = 55

        'atk
        at0 = 130
        at2 = 123
        at1 = 136

        'def
        de0 = 203
        de2 = 198
        de1 = 210
        
        

        Dim ten As Image
        Dim one As Image

        Dim y As Integer = 313
        Dim p(6) As Point
        Dim p2(3) As Point

        f2 = nowfiledir + "\number\" + CStr(hp(2)) + ".png"
        f1 = nowfiledir + "\number\" + CStr(hp(1)) + ".png"
        one = Image.FromFile(f2)
        ten = Image.FromFile(f1)

        If hp(1) <> 0 Then

            p(1) = New Point(hp1, y)
            p(2) = New Point(hp2, y)
            G3.DrawImage(one, p(1))
            G3.DrawImage(ten, p(2))

        Else
            p2(1) = New Point(hp0, y)
            G3.DrawImage(one, p2(1))
        End If

        f2 = nowfiledir + "\number\" + CStr(atk(2)) + ".png"
        f1 = nowfiledir + "\number\" + CStr(atk(1)) + ".png"
        one = Image.FromFile(f2)
        ten = Image.FromFile(f1)

        If atk(1) <> 0 Then
            p(3) = New Point(at1, y)
            p(4) = New Point(at2, y)
            G3.DrawImage(one, p(3))
            G3.DrawImage(ten, p(4))

        Else
            p2(2) = New Point(at0, y)
            G3.DrawImage(one, p2(2))
        End If

        f2 = nowfiledir + "\number\" + CStr(def(2)) + ".png"
        f1 = nowfiledir + "\number\" + CStr(def(1)) + ".png"
        one = Image.FromFile(f2)
        ten = Image.FromFile(f1)

        If def(1) <> 0 Then
            p(5) = New Point(de1, y)
            p(6) = New Point(de2, y)
            G3.DrawImage(one, p(5))
            G3.DrawImage(ten, p(6))

        Else
            p2(3) = New Point(de0, y)
            G3.DrawImage(one, p2(3))
        End If
        



        
        showbox3.Image = boad3
    End Sub


End Class
