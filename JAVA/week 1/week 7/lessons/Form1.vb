Public Class Form1
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        System.Threading.Thread.Sleep(10000)
        End

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("This is all about MENU!!", MsgBoxStyle.Information, "About me")
    End Sub

    Private Sub btn_main_Click(sender As Object, e As EventArgs) Handles btn_main.Click
        Dim cake1 As Cake = New Cake(12, 24, "Red")
        MsgBox(cake1.description, MsgBoxStyle.Information, "Cake Info")
    End Sub
    Private Class Cake
        Private Property _height As Integer
        Private Shared Property _radius As Integer
        Public Property _color As String

        Public Sub New(height As Integer, radius As Integer, color As String)
            _height = height
            _radius = radius
            _color = color
        End Sub

        Protected Overrides Sub finalize()
            MsgBox("End Of app", MsgBoxStyle.Information)

        End Sub

        Friend Function description() As String
            Dim desc As String = ""
            desc += "Height: " & _height & vbNewLine
            desc += "Radius: " & _radius & vbNewLine
            desc += "Color: " & _color & vbNewLine

            Return desc
        End Function
    End Class

    Private Sub btn_scramble_Click(sender As Object, e As EventArgs) Handles btn_scramble.Click
        Dim word As String

        Dim word_array As Char()
        Dim word_arrayList = New ArrayList()
        Dim scrambled_word As String = ""
        word = txtb.Text
        word_array = word.ToLower.ToCharArray

        For i As Integer = 0 To word.Length - 1
            word_arrayList.Add(word_array(i))

        Next
        Do Until word_arrayList.Count = 0
            For j As Integer = 0 To 0
                scrambled_word += word_arrayList(j)
                word_arrayList.RemoveAt(j)
            Next
        Loop
        lb_scrambled.Text = scrambled_word
    End Sub

    Private Sub btn_img_Click(sender As Object, e As EventArgs) Handles btn_img.Click
        Dim num As Integer
        Randomize()
        num = Math.Floor(9 * Rnd())
        pic_box.Image = imglist.Images(num)
    End Sub
End Class
