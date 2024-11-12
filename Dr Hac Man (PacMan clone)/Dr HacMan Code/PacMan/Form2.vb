
Public Class Form9000
    '>>>>>>>>>>>>>>Globals<<<<<<<<<<<<<<<'
    Dim LargeDots() As PictureBox = {BigPellet1, BigPellet2, BigPellet3, BigPellet4}
    Dim Dots() As PictureBox = {Dot1, Dot2, Dot3, Dot4, Dot5, Dot6, Dot7, Dot8, Dot9, Dot10, Dot11, Dot12, Dot13, Dot14, Dot15, Dot16, Dot17, Dot18, Dot19, Dot20, Dot21, Dot22, Dot23, Dot24, Dot25, Dot26, Dot27, Dot28, Dot29, Dot30, Dot31, Dot32, Dot33, Dot34, Dot35, Dot36, Dot37, Dot38, Dot39, Dot40, Dot41, Dot42, Dot43, Dot44, Dot45, Dot46, Dot47, Dot48, Dot49, Dot50, Dot51, Dot52, Dot53, Dot54, Dot55, Dot56, Dot57, Dot58, Dot59, Dot60, Dot61, Dot62, Dot63, Dot64, Dot65, Dot66, Dot67, Dot68, Dot69, Dot70, Dot71, Dot72, Dot72, Dot73, Dot74, Dot75, Dot76, Dot77, Dot78, Dot79, Dot80, Dot81, Dot82, Dot83, Dot84, Dot85, Dot86, Dot87, Dot88, Dot89, Dot90, Dot91, Dot92, Dot93, Dot94, Dot95, Dot96, Dot97, Dot98, Dot99, Dot100, Dot101, Dot102, Dot103, Dot104, Dot105, Dot106, Dot107, Dot108, Dot109, Dot110, Dot111, Dot112, Dot114, Dot115, Dot116, Dot117, Dot118, Dot119, Dot120, Dot121, Dot122, Dot123, Dot124, Dot125, Dot126, Dot127, Dot128, Dot129, Dot130, Dot131, Dot132, Dot133, Dot134, Dot135, Dot136, Dot137, Dot138, Dot139, Dot140, Dot141, Dot142, Dot143, Dot195, Dot145, Dot146, Dot147, Dot148, Dot149, Dot150, Dot151, Dot152, Dot153, Dot154, Dot155, Dot156, Dot157, Dot158, Dot159, Dot160, Dot161, Dot162, Dot163, Dot164, Dot165, Dot166, Dot167, Dot168, Dot169, Dot170, Dot171, Dot194, Dot173, Dot174, Dot175, Dot176, Dot177, Dot178, Dot179, Dot180, Dot181, Dot182, Dot183, Dot184, Dot186, Dot187}
    Public ActPoints As Integer
    Dim Rectangle1 As New Rectangle(0, 0, 900, 20)
    Dim Surround As New Rectangle(0, 24, 650, 777)
    Dim FormSurface As Graphics = Me.CreateGraphics
    Dim BlinkyDirection As BlinkyMovementDirection
    Dim InkyDirection As InkyMovementDirection
    Dim ClydeDirection As ClydeMovementDirection
    Dim PinkyDirection As PinkyMovementDirection
    Dim Quampa As Integer = 5
    Dim PacSpeed As Integer = 4
    Dim GhostSpeed As Integer = 9
    Dim Lives As Integer = 3
    Dim Random As New Random
    Dim WallE() As PictureBox
    Dim GhostCurrent As New Point
    Dim timeLeft As Integer = 0
    Dim timeLeftO As Integer = 0


    '>>>>>>>>>>>>>>>Enumerations<<<<<<<<<<<<<<<<<<'
    Public Enum BlinkyMovementDirection 'Reference For Random Ghost Movement
        BlinkyUp = 1
        BlinkyDown = 2
        BlinkyLeft = 3
        BlinkyRight = 4
    End Enum
    Public Enum InkyMovementDirection
        InkyUp = 1
        InkyDown = 2
        InkyLeft = 3
        InkyRight = 4
    End Enum
    Public Enum ClydeMovementDirection
        ClydeUp = 1
        ClydeDown = 2
        ClydeLeft = 3
        ClydeRight = 4
    End Enum
    Public Enum PinkyMovementDirection
        PinkyUp = 1
        PinkyDown = 2
        PinkyLeft = 3
        PinkyRight = 4
    End Enum
    '>>>>>>>>>>>Main Events<<<<<<<<<<<<<<<

    'This Sub Entails the Interaction of The WASD Cases As PacMan Movement

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        RightToLefttoRight()
        My.Computer.Audio.Play(My.Resources.pacman_chomp, AudioPlayMode.BackgroundLoop) 'Chomp Sound Loop
        Select Case e.KeyCode
            Case Keys.W 'Moving Forward when W is Pressed; Declaring a variable to reference Keys.W; Set the Velocity; Set the Image; Refresh Image constantly to allow for Gif motion
                Quampa = 4
                Movement.Start()
                DrHacMan.Top -= PacSpeed
                DrHacMan.Image = My.Resources.PacMannoUP
                DrHacMan.Refresh()
            Case Keys.A 'Moving Left When A is pressed; Declaring a variable to reference Keys.W; Set the Velocity; Set the Image; Refresh Image constantly to allow for Gif motion
                Quampa = 3
                Movement.Start()
                DrHacMan.Left -= PacSpeed
                DrHacMan.Image = My.Resources.PacMannoLeft
                DrHacMan.Refresh()
            Case Keys.S 'Moving Down When S is pressed; Declaring a variable to reference Keys.W; Set the Velocity; Set the Image; Refresh Image constantly to allow for Gif motion
                Quampa = 2
                Movement.Start()
                DrHacMan.Top += PacSpeed
                DrHacMan.Image = My.Resources.PacMannoDown
                DrHacMan.Refresh()
            Case Keys.D 'Moving Right When D is Pressed; Declaring a variable to reference Keys.W; Set the Velocity; Set the Image; Refresh Image constantly to allow for Gif motion
                Quampa = 1
                Movement.Start()
                DrHacMan.Left += PacSpeed
                DrHacMan.Image = My.Resources.PacManno
                DrHacMan.Refresh()
        End Select

    End Sub


    Public Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'DrHacMan Location and Major Properties
        DrHacMan.Location = New Point(298, 516)
        DrHacMan.BackColor = Color.Transparent
        DrHacMan.BringToFront()


        'Blinky Location and Major Properties
        Blinky.Location = New Point(298, 258)
        Blinky.BackColor = Color.Transparent
        Blinky.BringToFront()


        'Pinky Location and Major Properties
        Pinky.Location = New Point(298, 324)
        Pinky.BackColor = Color.Transparent
        Pinky.BringToFront()

        'Inky Location and Major Properties
        Inky.Location = New Point(298, 324)
        Inky.BackColor = Color.Transparent
        Inky.BringToFront()

        'Clyde Location and Major Properties
        Clyde.Location = New Point(298, 324)
        Clyde.BackColor = Color.Transparent
        Clyde.BringToFront()

        'Misc: Audio for the Beginning and Timer for Ghost Movement
        My.Computer.Audio.Play(My.Resources.pacman_beginning, AudioPlayMode.Background)
    End Sub



    'This Sub Entails the Start Button Actions
    Private Sub StartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartToolStripMenuItem.Click
        'On Button Click the  Images Change to that of the Ghosts'
        Pinky.Image = My.Resources.Pinky__1_
        Blinky.Image = My.Resources.Blinky__1_
        Clyde.Image = My.Resources.Clyde
        Inky.Image = My.Resources.Inky__1_
        timeLeftO = 2
        MovingForward.Start()
        'Also On Button Click a Rectange is drawn designating the outer boundary of the Maze
        FormSurface.DrawRectangle(Pens.Aquamarine, Surround)
    End Sub


    'This Code simply restarts the application on click Event
    Private Sub NewGameToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewGameToolStripMenuItem.Click
        Application.Restart()
    End Sub

    '>>>>>>>>>>>>>Timers<<<<<<<<<<<<<<<<<<

    'This Code Makes it that if the Pacman intersects with a Dot or LargeDot in the array that Dot or LargeDot becomes Invisible
    Public Sub Point_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Point.Tick

        Dim Dots() As PictureBox = {Dot1, Dot2, Dot3, Dot4, Dot5, Dot6, Dot7, Dot8, Dot9, Dot10, Dot11, Dot12, Dot13, Dot14, Dot15, Dot16, Dot17, Dot18, Dot19, Dot20, Dot21, Dot22, Dot23, Dot24, Dot25, Dot26, Dot27, Dot28, Dot29, Dot30, Dot31, Dot32, Dot33, Dot34, Dot35, Dot36, Dot37, Dot38, Dot39, Dot40, Dot41, Dot42, Dot43, Dot44, Dot45, Dot46, Dot47, Dot48, Dot49, Dot50, Dot51, Dot52, Dot53, Dot54, Dot55, Dot56, Dot57, Dot58, Dot59, Dot60, Dot61, Dot62, Dot63, Dot64, Dot65, Dot66, Dot67, Dot68, Dot69, Dot70, Dot71, Dot72, Dot72, Dot73, Dot74, Dot75, Dot76, Dot77, Dot78, Dot79, Dot80, Dot81, Dot82, Dot83, Dot84, Dot85, Dot86, Dot87, Dot88, Dot89, Dot90, Dot91, Dot92, Dot93, Dot94, Dot95, Dot96, Dot97, Dot98, Dot99, Dot100, Dot101, Dot102, Dot103, Dot104, Dot105, Dot106, Dot107, Dot108, Dot109, Dot110, Dot111, Dot112, Dot114, Dot115, Dot116, Dot117, Dot118, Dot119, Dot120, Dot121, Dot122, Dot123, Dot124, Dot125, Dot126, Dot127, Dot128, Dot129, Dot130, Dot131, Dot132, Dot133, Dot134, Dot135, Dot136, Dot137, Dot138, Dot139, Dot140, Dot141, Dot142, Dot143, Dot195, Dot145, Dot146, Dot147, Dot148, Dot149, Dot150, Dot151, Dot152, Dot153, Dot154, Dot155, Dot156, Dot157, Dot158, Dot159, Dot160, Dot161, Dot162, Dot163, Dot164, Dot165, Dot166, Dot167, Dot168, Dot169, Dot170, Dot171, Dot194, Dot173, Dot174, Dot175, Dot176, Dot177, Dot178, Dot179, Dot180, Dot181, Dot182, Dot183, Dot184, Dot186, Dot187}
        For X = 0 To Dots.Length - 1 'Iterates Over Every Dot
            Dots(X).Image = My.Resources.New_Piskel__1_ 'Every time a dot is iterated their image becomes the one that was set (New_Piskel__1_)
            If DrHacMan.Bounds.IntersectsWith(Dots(X).Bounds) Then 'And Looks For Intersections
                Dots(X).Location = New Point(1000, 1000)
                ActPoints += 10 'This references a measure to check the ammount of dots consumed and add it to the points on a millisecond basis
                IHaveNoChance.Text = "Points: " & ActPoints 'This references the textbox and checks every milisecond the ActPoints Integer
                IHaveNoChance.BackColor = (Color.White)
            End If
        Next
        Dim LargeDots() As PictureBox = {BigPellet1, BigPellet2, BigPellet3, BigPellet4}
        For x = 0 To LargeDots.Length - 1 'Iterates Over Every Dot
            If DrHacMan.Bounds.IntersectsWith(LargeDots(x).Bounds) Then 'And Looks for Intersections

                LargeDots(x).Visible = False
                LargeDots(x).Location = New Point(1000, 1000)
                ActPoints += 200
                timeLeft = 10
                Ghostly.Start() 'This references a seperate Sub which cues a seperate timer and starts a whole new game mode'

            End If

        Next
    End Sub

    'Boundary: This Code checks the Boundary Event every 1 millisecond and then if it intersects runs the boundary event for every single Obstacle
    'Gobble: This Code also includes the Gobble Sub which holds the intersection if pacman hits a ghost that is not in death sequence and checks for this every 1 second
    'Livelihood: Finally this code includes a small Livelihood sub which includes if the lives decrease what happens to the pictureboxes that correspond to the hearts
    Private Sub BoundaryCheck_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoundaryCheck.Tick
        Gobble(Clyde)
        Gobble(Blinky)
        Gobble(Inky)
        Gobble(Pinky)
        Boundary(Obstacle1)
        Boundary(Obstacle2)
        Boundary(Obstacle3)
        Boundary(Obstacle5)
        Boundary(Obstacle6)
        Boundary(Obstacle7)
        Boundary(Obstacle8)
        Boundary(Obstacle9)
        Boundary(Obstacle10)
        Boundary(Obstacle11)
        Boundary(Obstacle12)
        Boundary(Obstacle13)
        Boundary(Obstacle14)
        Boundary(Obstacle15)
        Boundary(Obstacle16)
        Boundary(Obstacle17)
        Boundary(Obstacle18)
        Boundary(Obstacle19)
        Boundary(Obstacle20)
        Boundary(Obstacle21)
        Boundary(Obstacle22)
        Boundary(Obstacle23)
        Boundary(Obstacle24)
        Boundary(Obstacle26)
        Boundary(Obstacle27)
        Boundary(Obstacle28)
        Boundary(Obstacle29)
        Boundary(Obstacle30)
        Boundary(Obstacle31)
        Boundary(Obstacle32)
        Boundary(Obstacle33)
        Boundary(Obstacle34)
        Boundary(Obstacle35)
        Boundary(Obstacle36)
        Boundary(Obstacle37)
        Boundary(Obstacle38)
        Boundary(Obstacle39)
        Boundary(Obstacle40)
        Boundary(Obstacle41)
        Boundary(Obstacle42)
        Boundary(Obstacle45)
        Boundary(Obstacle47)
        Boundary(Obstacle50)
        Livelihood()
        
    End Sub

    'This timer references the key press event and says if a key is pressed a value(PacSpeed) is added to a certain location every milisecond
    Private Sub Movement_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Movement.Tick
        Select Case Quampa '.Top Means Top of Picture Box and .Left Means Left of PictureBox
            Case 4 'Case W is Pressed or Forward
                DrHacMan.Top -= PacSpeed
            Case 3 'Case A is Pressed or Left
                DrHacMan.Left -= PacSpeed
            Case 2 'Case S is Pressed or Down
                DrHacMan.Top += PacSpeed
            Case 1 'Case D is Pressed or Right
                DrHacMan.Left += PacSpeed
        End Select
    End Sub

    Private Sub BlinkyMoves_Tick(sender As System.Object, e As System.EventArgs) Handles BlinkyMoves.Tick
        Select Case BlinkyDirection
            Case BlinkyMovementDirection.BlinkyUp
                Blinky.Top -= GhostSpeed
            Case BlinkyMovementDirection.BlinkyRight
                Blinky.Left += GhostSpeed
            Case BlinkyMovementDirection.BlinkyLeft
                Blinky.Left -= GhostSpeed
            Case BlinkyMovementDirection.BlinkyDown
                Blinky.Top += GhostSpeed
        End Select
        GhostMovement(Blinky)
    End Sub


    '>>>>>>>>>>>>>>Functions<<<<<<<<<<<<<<<<<<<<<<'

    '>>>>>>>>>>>>>>>>>>Seperate Core Subs<<<<<<<<<<<<<<<<<<<<<<'
    'This sub keeps track of the lives 
    Private Sub Livelihood()
        If Lives = 3 Then '3 Lives 3 Picture Boxes
            HeartOne.Image = My.Resources.PacManno
            HeartTwo.Image = My.Resources.PacManno
            HeartThree.Image = My.Resources.PacManno
        ElseIf Lives = 2 Then '2 lives 2 Picture Boxes
            HeartOne.Image = My.Resources.PacManno
            HeartTwo.Image = My.Resources.PacManno
            HeartThree.Image = Nothing
        ElseIf Lives = 1 Then '1 Live 1 Picture Box
            HeartOne.Image = My.Resources.PacManno
            HeartTwo.Image = Nothing
            HeartThree.Image = Nothing
        End If
    End Sub


    Private Sub RightToLefttoRight()
        'This Code says if the Ghosts or PacMan passes a certain threshold (x = 610) their location changes to the opposite side of the form (x = 2) ; this is referenced in the keyDown event to make it that when a key is pressed this function runs
        If DrHacMan.Location.X >= 610 Then
            DrHacMan.Location = New Point(2, DrHacMan.Location.Y)
        End If
        If Blinky.Location.X >= 610 Then
            Blinky.Location = New Point(2, Blinky.Location.Y)
        End If
        If Inky.Location.X >= 610 Then
            Inky.Location = New Point(2, Inky.Location.Y)
        End If
        If Pinky.Location.X >= 610 Then
            Pinky.Location = New Point(2, Pinky.Location.Y)
        End If
        If Clyde.Bounds.X >= 610 Then
            Blinky.Location = New Point(2, Clyde.Location.Y)
        End If


        'This Code is the exact opposite of the code in the early parts of the sub and this moves the PacMan or Ghost from x = 20 or x = 1 to x = 610
        If DrHacMan.Location.X <= 1 Then
            DrHacMan.Location = New Point(610, DrHacMan.Location.Y)
        End If
        If Blinky.Location.X <= 20 Then
            Blinky.Location = New Point(610, Blinky.Location.Y)
        End If
        If Inky.Location.X <= 20 Then
            Inky.Location = New Point(610, Inky.Location.Y)
        End If
        If Pinky.Location.X <= 20 Then
            Pinky.Location = New Point(610, Pinky.Location.Y)
        End If
        If Clyde.Location.X <= 20 Then
            Blinky.Location = New Point(610, Clyde.Location.Y)
        End If
    End Sub


    'This function says if DrHacMan.Bounds intersects wtih another Picture Box (that will be known once you call the function) the timer movement will stop and the pacman will become static until Pacman 
    'moves away from that wall
    Private Sub Boundary(ByRef obs As PictureBox)
        If DrHacMan.Bounds.IntersectsWith(obs.Bounds) Then
            Movement.Stop()
        End If

    End Sub
    'Referenced in BoundaryCheck Timer this says if Pacman intersects with ghost then lives = lives - 1 and includes a case for Lives = 0
    Private Sub Gobble(ByRef Ghost As PictureBox)
        If DrHacMan.Bounds.IntersectsWith(Ghost.Bounds) Then
            Reset()
            Lives = Lives - 1
            If Lives = 0 Then
                HeartOne.Image = Nothing

            ElseIf Ghostly.Enabled = True And DrHacMan.Bounds.IntersectsWith(Ghost.Bounds) Then
                ActPoints += 200
            End If
        End If
    End Sub
    'This sub is referenced in Gobble() and in this first it cues the death sounds; then it refreshes the form; then it resets all the locations, and this is all done in 1 millisecond
    Private Sub Reset()
        My.Computer.Audio.Play(My.Resources.pacman_death, AudioPlayMode.Background)
        Me.Refresh()
        DrHacMan.Location = New Point(298, 518)
        Clyde.Location = New Point(285, 349)
        Inky.Location = New Point(285, 349)
        Blinky.Location = New Point(298, 258)
        Pinky.Location = New Point(285, 349)
    End Sub

    Private Sub Ghostly_Tick(sender As System.Object, e As System.EventArgs) Handles Ghostly.Tick

        Dim x As Integer 'Integer to Iterate with 'Set Timer'
        timeLeft -= 1
        Dim DeadGhost() As PictureBox = {Clyde, Blinky, Inky, Pinky}
        Clyde.Image = My.Resources.Ded__1_ 'Changes the Ghosts' Pictures
        Blinky.Image = My.Resources.Ded__1_
        Inky.Image = My.Resources.Ded__1_
        Pinky.Image = My.Resources.Ded__1_

        For x = 0 To DeadGhost.Length - 1
            If DrHacMan.Bounds.IntersectsWith(DeadGhost(x).Bounds) Then 'Checks for intersection; then time left, and then if collision happens changes visiblity and ActPoints
                DeadGhost(x).Location = New Point(1000, 1000)
                DeadGhost(x).Visible = False
            End If
        Next
        If timeLeft = 0 Then
            For x = 0 To DeadGhost.Length - 1
                DeadGhost(x).Visible = True 'If the Timer is done the visibility resumes
                DeadGhost(x).Location = New Point(285, 349)
                Clyde.Image = My.Resources.Clyde
                Blinky.Image = My.Resources.Blinky__1_
                Inky.Image = My.Resources.Inky__1_
                Pinky.Image = My.Resources.Pinky__1_
            Next
            'If the overall timer is done the Ghosts resume back to what they were
            Ghostly.Stop()
        End If

    End Sub


    Private Sub GhostMovement(ByRef Ghosts As PictureBox)
        Dim x As Integer
        Dim WallE() As PictureBox = {Obstacle1, Obstacle2, Obstacle3, Obstacle40, Obstacle5, Obstacle6, Obstacle7, Obstacle8, Obstacle9, Obstacle10, Obstacle11, Obstacle12, Obstacle13, Obstacle14, Obstacle15, Obstacle16, Obstacle17, Obstacle18, Obstacle19, Obstacle20, Obstacle21, Obstacle22, Obstacle23, Obstacle24, Obstacle26, Obstacle27, Obstacle28, Obstacle29, Obstacle30, Obstacle31, Obstacle32, Obstacle33, Obstacle34, Obstacle35, Obstacle36, Obstacle37, Obstacle38, Obstacle39, Obstacle40, Obstacle41, Obstacle42, Obstacle45, Obstacle47, GhostBoxOne, GhostBoxTwo, GhostBoxThree}
        For Each Wall In WallE
            If Ghosts.Bounds.IntersectsWith(Wall.Bounds) Then
                BlinkyMoves.Stop()
                Select Case BlinkyDirection
                    Case BlinkyMovementDirection.BlinkyUp
                        BlinkyDirection = BlinkyMovementDirection.BlinkyRight
                    Case BlinkyMovementDirection.BlinkyDown
                        BlinkyDirection = BlinkyMovementDirection.BlinkyLeft
                    Case BlinkyMovementDirection.BlinkyRight
                        BlinkyDirection = BlinkyMovementDirection.BlinkyDown
                    Case BlinkyMovementDirection.BlinkyLeft
                        BlinkyDirection = BlinkyMovementDirection.BlinkyUp
                End Select
                Select Case PinkyDirection
                    Case PinkyMovementDirection.PinkyUp
                        PinkyDirection = PinkyMovementDirection.PinkyRight
                    Case PinkyMovementDirection.PinkyDown
                        PinkyDirection = PinkyMovementDirection.PinkyLeft
                    Case PinkyMovementDirection.PinkyRight
                        PinkyDirection = PinkyMovementDirection.PinkyDown
                    Case PinkyMovementDirection.PinkyLeft
                        PinkyDirection = PinkyMovementDirection.PinkyUp
                End Select
                Select Case InkyDirection
                    Case InkyMovementDirection.InkyUp
                        InkyDirection = InkyMovementDirection.InkyRight
                    Case InkyMovementDirection.InkyDown
                        InkyDirection = InkyMovementDirection.InkyLeft
                    Case InkyMovementDirection.InkyRight
                        InkyDirection = InkyMovementDirection.InkyDown
                    Case InkyMovementDirection.InkyLeft
                        InkyDirection = InkyMovementDirection.InkyUp
                End Select

                Select Case ClydeDirection
                    Case ClydeMovementDirection.ClydeUp
                        ClydeDirection = ClydeMovementDirection.ClydeLeft
                    Case ClydeMovementDirection.ClydeDown
                        ClydeDirection = ClydeMovementDirection.ClydeRight
                    Case ClydeMovementDirection.ClydeRight
                        ClydeDirection = ClydeMovementDirection.ClydeUp
                    Case ClydeMovementDirection.ClydeLeft
                        ClydeDirection = ClydeMovementDirection.ClydeDown
                End Select
                BlinkyMoves.Start()
                PinkyMoves.Start()
                InkyMoves.Start()
                ClydeMoves.Start()
            End If
        Next
        If Ghosts.Bounds.IntersectsWith(Surround) Then

        End If

    End Sub


    Private Sub MovingForward_Tick(sender As System.Object, e As System.EventArgs) Handles MovingForward.Tick
        If timeLeftO > 0 Then
            timeLeftO -= 1
            PinkyDirection = PinkyMovementDirection.PinkyUp
            InkyDirection = InkyMovementDirection.InkyUp
            ClydeDirection = ClydeMovementDirection.ClydeUp
            BlinkyDirection = BlinkyMovementDirection.BlinkyRight
        ElseIf timeLeftO = 0 Then
            MovingForward.Stop()
            BlinkyMoves.Start()
            PinkyMoves.Start()
            InkyMoves.Start()
            ClydeMoves.Start()
        End If
    End Sub

    Private Sub PinkyMoves_Tick(sender As System.Object, e As System.EventArgs) Handles PinkyMoves.Tick
        Select Case PinkyDirection
            Case PinkyMovementDirection.PinkyUp
                Pinky.Left -= GhostSpeed
            Case (PinkyMovementDirection.PinkyDown)
                Pinky.Left += GhostSpeed
            Case PinkyMovementDirection.PinkyRight
                Pinky.Top += GhostSpeed
            Case PinkyMovementDirection.PinkyLeft
                Pinky.Top -= GhostSpeed
        End Select
    End Sub

    Private Sub InkyMoves_Tick(sender As System.Object, e As System.EventArgs) Handles InkyMoves.Tick
        Select Case InkyDirection
            Case InkyMovementDirection.InkyUp
                Inky.Top -= GhostSpeed
            Case InkyMovementDirection.InkyDown
                Inky.Top += GhostSpeed
            Case InkyMovementDirection.InkyRight
                Inky.Left += GhostSpeed
            Case InkyMovementDirection.InkyLeft
                Inky.Left -= GhostSpeed
        End Select
    End Sub

    Private Sub ClydeMoves_Tick(sender As System.Object, e As System.EventArgs) Handles ClydeMoves.Tick
        Select Case ClydeDirection
            Case ClydeMovementDirection.ClydeUp
                Clyde.Left += GhostSpeed
            Case ClydeMovementDirection.ClydeDown
                Clyde.Left -= GhostSpeed
            Case ClydeMovementDirection.ClydeRight
                Clyde.Top -= GhostSpeed
            Case ClydeMovementDirection.ClydeLeft
                Clyde.Top += GhostSpeed
        End Select
    End Sub


End Class