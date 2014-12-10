'==========================================================================================================
'Dear Source Code Reader :
'This project is made by jamiephan (http://www.jamiephan.net) / lovemelody (http://tinyurl.com/cx9999v)
'This project is under Attribution-NonCommercial 4.0 International. (non-commercially usage + Attribution )
'Licence link --> http://creativecommons.org/licenses/by-nc/4.0/
'==========================================================================================================
Public Class Form1

    Sub txtboxChange(ByVal HEX As String, RED As String, GREEN As String, BLUE As String)
        Dim hexe = String.Format("0x{0:X8}", HEX)
        txtboxHex.Text = "#" & hexe.Substring(hexe.Length - 6, 6)
        txtBoxRed.Text = RED
        txtboxGreen.Text = GREEN
        txtboxBlue.Text = BLUE
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Timer1.Stop()
        ColorDialog1.FullOpen = True
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Timer1.Start()
        Else
            Dim Color = ColorDialog1.Color
            PictureBox1.BackColor = Color
            txtboxChange(Me.PictureBox1.BackColor.ToArgb(), PictureBox1.BackColor.R.ToString, PictureBox1.BackColor.G.ToString, PictureBox1.BackColor.B.ToString)
            Button1.Text = "Start"
        End If
    End Sub
    Sub loadingRanColor()
        Dim rand As New Random
        PictureBox1.BackColor = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256))
        txtboxChange(Me.PictureBox1.BackColor.ToArgb(), PictureBox1.BackColor.R.ToString, PictureBox1.BackColor.G.ToString, PictureBox1.BackColor.B.ToString)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadingRanColor()
        Timer1.Start()
        Button1.Text = "Stop"
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        loadingRanColor()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Stop" Then
            Timer1.Stop()
            Button1.Text = "Start"
        ElseIf Button1.Text = "Start" Then
            Timer1.Start()
            Button1.Text = "Stop"
        End If
    End Sub
    Sub clipb(ByVal HEX As String, RED As String, GREEN As String, BLUE As String)
        'put into a temp richtextbox
        RichTextBox1.Text = HEX & vbNewLine & RED & vbNewLine & GREEN & vbNewLine & BLUE
        Clipboard.SetText(RichTextBox1.Text)
        Me.Text = "Jamie Colour (Copied)"
        Timer2.Start()
        Timer1.Stop()
    End Sub

    Private Sub txtboxClick(sender As Object, e As MouseEventArgs) Handles txtboxHex.MouseClick, txtBoxRed.MouseClick, txtboxGreen.MouseClick, txtboxBlue.MouseClick
        clipb(txtboxHex.Text, txtBoxRed.Text, txtboxGreen.Text, txtboxBlue.Text)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Me.Text = "Jamie Colour"
        Timer2.Stop()
        If Button1.Text = "Stop" Then
            Timer1.Start()
        Else
            Return
        End If
    End Sub
End Class
