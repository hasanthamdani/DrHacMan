Public Class Form1
    Dim R As Single
    Dim C As Single
    Dim MyArray() As Single
    Dim s As New Rectangle
    Dim FormSurface As Graphics = Me.CreateGraphics
    Dim BPen As New Pen(Color.Black)
    Dim bm As Bitmap
    Dim G As Graphics
    Dim G1 As Graphics
    Dim WallE() As Graphics
    Dim i As Integer
    Dim j As Integer

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Me.Focus()
        G = Me.CreateGraphics
        bm = New Bitmap(Me.Width, Me.Height)
        CreatingTheGrid()
    End Sub
    Private Sub CreatingTheGrid()

    End Sub

    Private Sub GridCreation_Tick(sender As System.Object, e As System.EventArgs) Handles GridCreation.Tick
        Dim MyArray(25, 20) As Single
        For i As Integer = 16 To 20
            MyArray(12, i) = 1
            MyArray(14, i) = 1
        Next
        For i As Integer = 15 To 19
            MyArray(i, 17) = 1
        Next
        For i As Integer = 4 To 17
            MyArray(19, i) = 1
        Next
        For i As Integer = 14 To 19
            MyArray(i, 4) = 1
        Next

        For j As Integer = 0 To MyArray.GetLength(1) - 1
            For i As Integer = 0 To MyArray.GetLength(0) - 1
                Console.Write(MyArray(i, j))
            Next
            Console.WriteLine()
        Next

        's = New Rectangle(x * 35, y * 35, 35, 35)
        'G.DrawRectangle(BPen, s)


        G = Graphics.FromImage(bm)

        G1 = Me.CreateGraphics
        G1.DrawImage(bm, 0, 0, Me.Width, Me.Height)

        G.Clear(Color.White)




    End Sub
End Class
