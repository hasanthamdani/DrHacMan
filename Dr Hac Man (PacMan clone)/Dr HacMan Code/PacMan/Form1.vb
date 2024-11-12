Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form9000.Show()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        MessageBox.Show("W-Forward" & vbCrLf & "A - Left" & vbCrLf & "S - Down" & vbCrLf & "D - Right" & vbCrLf & "The Goal: Evade Ghosts and Collect Pellets" & vbCrLf & "Don't forget the Big Pellets Change the Game" & vbCrLf & "Stay Away from Walls!" & vbCrLf & "Only Use New Game Button to Leave the Screen" & vbCrLf & "DO NOT PUT THIS IN FULL SCREEN. Thank You!")
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        MessageBox.Show("To Win the Game" & vbCrLf & "Just Remain in the Game")
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
