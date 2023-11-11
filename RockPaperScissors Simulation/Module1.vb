Imports System.Runtime.InteropServices

Module Module1
    Dim CurrentMoveForWinnerChange As Char
    Dim WinnerChangeStreak As Integer = 0
    Dim LoserChangeStreak As Integer = 0
    Dim CurrentMoveForChangingLoser As Char
    Dim CurrentMoveForControl As Char
    Dim STDWinnerChangeStreak As Integer = 0
    Dim STDLoserChangeStreak As Integer = 0
    Dim CurrentMoveForStandard As Char
    Dim CurrentMoveForNash As Char
    Dim NashWin As Integer = 3

    Dim RoundNum As Double = 1
    Dim AmountofRounds As Integer
    Dim StopGo As String = "Yes"
    Dim SimSelector As String
    Dim WinningCountForPlayer2 As Integer = 0
    Dim WinningCountForPlayer1 As Integer = 0
    Dim DrawCount As Integer = 0
    Dim GameNum As Integer = 3

    Dim RepeatCount As Integer

    Sub Main()
        Dim Player1Move As Char
        Dim Player2Move As Char

        Console.WriteLine("Select Simulation: Control, Control vs Nash, Standard vs Control,Standard vs Nash")
            SimSelector = Console.ReadLine

            Console.WriteLine("How many rounds would you like?")
            RoundNum = Console.ReadLine

        If SimSelector = "Control" Then

            Console.WriteLine("Player 1 is 'Control'")
            Console.WriteLine("Player 2 is 'Changing Winner' - press enter to continue")
            Console.ReadLine()

            Do Until RoundNum = 0
                Player1Move = StandardMove()
                Player2Move = MoveForChangingWinner()
                Console.WriteLine(Player1Move)
                Console.WriteLine(Player2Move)
                If Player1Move = "R" And Player2Move = "P" Then
                    Console.WriteLine("Player 2 Wins!")
                    WinningCountForPlayer2 = WinningCountForPlayer2 + 1
                    NashWin = 1
                ElseIf Player1Move = "R" And Player2Move = "S" Then
                    Console.WriteLine("Player 1 Wins!")
                    WinningCountForPlayer1 = WinningCountForPlayer1 + 1
                    NashWin = 2
                ElseIf Player1Move = "R" And Player2Move = "R" Then
                    Console.WriteLine("Draw!")
                    DrawCount = DrawCount + 1
                    NashWin = 3
                ElseIf Player1Move = "P" And Player2Move = "R" Then
                    Console.WriteLine("Player 1 Wins!")
                    WinningCountForPlayer1 = WinningCountForPlayer1 + 1
                    NashWin = 2
                ElseIf Player1Move = "P" And Player2Move = "S" Then
                    Console.WriteLine("Player 2 Wins!")
                    WinningCountForPlayer2 = WinningCountForPlayer2 + 1
                    NashWin = 1
                ElseIf Player1Move = "P" And Player2Move = "P" Then
                    Console.WriteLine("Draw!")
                    DrawCount = DrawCount + 1
                    NashWin = 3
                ElseIf Player1Move = "S" And Player2Move = "R" Then
                    Console.WriteLine("Player 2 Wins!")
                    WinningCountForPlayer2 = WinningCountForPlayer2 + 1
                    NashWin = 1
                ElseIf Player1Move = "S" And Player2Move = "P" Then
                    Console.WriteLine("Player 1 Wins!")
                    WinningCountForPlayer1 = WinningCountForPlayer1 + 1
                    NashWin = 2
                ElseIf Player1Move = "S" And Player2Move = "S" Then
                    Console.WriteLine("Draw!")
                    DrawCount = DrawCount + 1
                    NashWin = 3
                End If
                RoundNum = RoundNum - 1
            Loop
            Call FinishGame()
        ElseIf SimSelector = "Control vs Nash" Then
            Console.WriteLine("Player 1 is 'Control'")
            Console.WriteLine("Player 2 is 'Nash' - Press enter to continue")
            Console.ReadLine()
            Do Until RoundNum = 0
                Player1Move = MoveForAverageHuman()
                Player2Move = MoveForNash()
                Console.WriteLine(Player1Move)
                Console.WriteLine(Player2Move)
                If Player1Move = "R" And Player2Move = "P" Then
                    Console.WriteLine("Player 2 Wins!")
                    WinningCountForPlayer2 = WinningCountForPlayer2 + 1
                    NashWin = 1
                ElseIf Player1Move = "R" And Player2Move = "S" Then
                    Console.WriteLine("Player 1 Wins!")
                    WinningCountForPlayer1 = WinningCountForPlayer1 + 1
                    NashWin = 2
                ElseIf Player1Move = "R" And Player2Move = "R" Then
                    Console.WriteLine("Draw!")
                    DrawCount = DrawCount + 1
                    NashWin = 3
                ElseIf Player1Move = "P" And Player2Move = "R" Then
                    Console.WriteLine("Player 1 Wins!")
                    WinningCountForPlayer1 = WinningCountForPlayer1 + 1
                    NashWin = 2
                ElseIf Player1Move = "P" And Player2Move = "S" Then
                    Console.WriteLine("Player 2 Wins!")
                    WinningCountForPlayer2 = WinningCountForPlayer2 + 1
                    NashWin = 1
                ElseIf Player1Move = "P" And Player2Move = "P" Then
                    Console.WriteLine("Draw!")
                    DrawCount = DrawCount + 1
                    NashWin = 3
                ElseIf Player1Move = "S" And Player2Move = "R" Then
                    Console.WriteLine("Player 2 Wins!")
                    WinningCountForPlayer2 = WinningCountForPlayer2 + 1
                    NashWin = 1
                ElseIf Player1Move = "S" And Player2Move = "P" Then
                    Console.WriteLine("Player 1 Wins!")
                    WinningCountForPlayer1 = WinningCountForPlayer1 + 1
                    NashWin = 2
                ElseIf Player1Move = "S" And Player2Move = "S" Then
                    Console.WriteLine("Draw!")
                    DrawCount = DrawCount + 1
                    NashWin = 3
                End If
                RoundNum = RoundNum - 1
            Loop
            Call FinishGame()
        ElseIf SimSelector = "Standard vs Control" Then
            Console.WriteLine("Player 1 is 'Standard'")
            Console.WriteLine("Player 2 is 'Control' - Press enter to continue")
            Console.ReadLine()
            Do Until RoundNum = 0
                Player1Move = MoveForAverageHuman()
                Player2Move = StandardMove()
                Console.WriteLine(Player1Move)
                Console.WriteLine(Player2Move)
                If Player1Move = "R" And Player2Move = "P" Then
                    Console.WriteLine("Player 2 Wins!")
                    WinningCountForPlayer2 = WinningCountForPlayer2 + 1
                    STDLoserChangeStreak = STDLoserChangeStreak + 1
                    STDWinnerChangeStreak = 0
                ElseIf Player1Move = "R" And Player2Move = "S" Then
                    Console.WriteLine("Player 1 Wins!")
                    WinningCountForPlayer1 = WinningCountForPlayer1 + 1
                    STDLoserChangeStreak = 0
                    STDWinnerChangeStreak = STDWinnerChangeStreak + 1
                ElseIf Player1Move = "R" And Player2Move = "R" Then
                    Console.WriteLine("Draw!")
                    DrawCount = DrawCount + 1
                    STDWinnerChangeStreak = 0
                    STDLoserChangeStreak = 0
                ElseIf Player1Move = "P" And Player2Move = "R" Then
                    Console.WriteLine("Player 1 Wins!")
                    WinningCountForPlayer1 = WinningCountForPlayer1 + 1
                    STDLoserChangeStreak = 0
                    STDWinnerChangeStreak = STDWinnerChangeStreak + 1
                ElseIf Player1Move = "P" And Player2Move = "S" Then
                    Console.WriteLine("Player 2 Wins!")
                    WinningCountForPlayer2 = WinningCountForPlayer2 + 1
                    STDLoserChangeStreak = STDLoserChangeStreak + 1
                    STDWinnerChangeStreak = 0
                ElseIf Player1Move = "P" And Player2Move = "P" Then
                    Console.WriteLine("Draw!")
                    DrawCount = DrawCount + 1
                    STDWinnerChangeStreak = 0
                    STDLoserChangeStreak = 0
                ElseIf Player1Move = "S" And Player2Move = "R" Then
                    Console.WriteLine("Player 2 Wins!")
                    WinningCountForPlayer2 = WinningCountForPlayer2 + 1
                    STDLoserChangeStreak = STDLoserChangeStreak + 1
                    STDWinnerChangeStreak = 0
                ElseIf Player1Move = "S" And Player2Move = "P" Then
                    Console.WriteLine("Player 1 Wins!")
                    WinningCountForPlayer1 = WinningCountForPlayer1 + 1
                    STDLoserChangeStreak = 0
                    STDWinnerChangeStreak = STDWinnerChangeStreak + 1
                ElseIf Player1Move = "S" And Player2Move = "S" Then
                    Console.WriteLine("Draw!")
                    DrawCount = DrawCount + 1
                    STDWinnerChangeStreak = 0
                    STDLoserChangeStreak = 0
                End If
                RoundNum = RoundNum - 1
            Loop
            Call FinishGame()
        ElseIf SimSelector = "Standard vs Nash" Then
            Console.WriteLine("Player 1 is 'Standard'")
            Console.WriteLine("Player 2 is 'Nash' - Press enter to continue")
            Console.ReadLine()
            While RoundNum > 0
                Player1Move = MoveForAverageHuman()
                Player2Move = MoveForNash()
                Console.WriteLine(Player1Move)
                Console.WriteLine(Player2Move)
                If Player1Move = "R" And Player2Move = "P" Then
                    Console.WriteLine("Player 2 Wins!")
                    WinningCountForPlayer2 = WinningCountForPlayer2 + 1
                    STDLoserChangeStreak = STDLoserChangeStreak + 1
                    STDWinnerChangeStreak = 0
                    NashWin = 1
                ElseIf Player1Move = "R" And Player2Move = "S" Then
                    Console.WriteLine("Player 1 Wins!")
                    WinningCountForPlayer1 = WinningCountForPlayer1 + 1
                    STDLoserChangeStreak = 0
                    STDWinnerChangeStreak = STDWinnerChangeStreak + 1
                    NashWin = 2
                ElseIf Player1Move = "R" And Player2Move = "R" Then
                    Console.WriteLine("Draw!")
                    DrawCount = DrawCount + 1
                    STDWinnerChangeStreak = 0
                    STDLoserChangeStreak = 0
                    NashWin = 3
                ElseIf Player1Move = "P" And Player2Move = "R" Then
                    Console.WriteLine("Player 1 Wins!")
                    WinningCountForPlayer1 = WinningCountForPlayer1 + 1
                    STDLoserChangeStreak = 0
                    STDWinnerChangeStreak = STDWinnerChangeStreak + 1
                    NashWin = 2
                ElseIf Player1Move = "P" And Player2Move = "S" Then
                    Console.WriteLine("Player 2 Wins!")
                    WinningCountForPlayer2 = WinningCountForPlayer2 + 1
                    STDLoserChangeStreak = STDLoserChangeStreak + 1
                    STDWinnerChangeStreak = 0
                    NashWin = 1
                ElseIf Player1Move = "P" And Player2Move = "P" Then
                    Console.WriteLine("Draw!")
                    DrawCount = DrawCount + 1
                    STDWinnerChangeStreak = 0
                    STDLoserChangeStreak = 0
                    NashWin = 3
                ElseIf Player1Move = "S" And Player2Move = "R" Then
                    Console.WriteLine("Player 2 Wins!")
                    WinningCountForPlayer2 = WinningCountForPlayer2 + 1
                    STDLoserChangeStreak = STDLoserChangeStreak + 1
                    STDWinnerChangeStreak = 0
                    NashWin = 1
                ElseIf Player1Move = "S" And Player2Move = "P" Then
                    Console.WriteLine("Player 1 Wins!")
                    WinningCountForPlayer1 = WinningCountForPlayer1 + 1
                    STDLoserChangeStreak = 0
                    STDWinnerChangeStreak = STDWinnerChangeStreak + 1
                    NashWin = 2
                ElseIf Player1Move = "S" And Player2Move = "S" Then
                    Console.WriteLine("Draw!")
                    DrawCount = DrawCount + 1
                    STDWinnerChangeStreak = 0
                    STDLoserChangeStreak = 0
                    NashWin = 3
                End If
                RoundNum = RoundNum - 1
            End While
            Call FinishGame()
            NashWin = 3

        End If


    End Sub
    Function FinishGame()
        RoundNum = 0
        Console.WriteLine("Player 1 won " & WinningCountForPlayer1 & " times")
        Console.WriteLine("Player 2 won " & WinningCountForPlayer2 & " times")
        Console.WriteLine("Players drew " & DrawCount & " times")
        Console.WriteLine("Would you like to continue?")
        StopGo = Console.ReadLine
        WinningCountForPlayer1 = 0
        WinningCountForPlayer2 = 0
        DrawCount = 0
        WinnerChangeStreak = 0
        LoserChangeStreak = 0
        STDWinnerChangeStreak = 0
        STDLoserChangeStreak = 0

    End Function

    Function StandardMove() As Char 'This Function determines the standard move For the equal chances player 
        Dim ProbabilityDetermine As Double

        Randomize()

        ProbabilityDetermine = Int(Rnd() * 9) + 1

        If ProbabilityDetermine <= 3 Then
            CurrentMoveForControl = "R"
        End If
        If ProbabilityDetermine > 3 And ProbabilityDetermine <= 6 Then
            CurrentMoveForControl = "P"
        End If
        If ProbabilityDetermine > 6 Then
            CurrentMoveForControl = "S"
        End If

        Return CurrentMoveForControl
    End Function

    Function MoveForChangingWinner() As Char 'This function determines the moves that the changing winner will play
        Dim ProbabilityDetermine As Double
        Dim TempStorage As Char

        If WinnerChangeStreak = 0 Then 'If winning streak is at 0, then each R, P, S has equal chance of being played
            Randomize()
            ProbabilityDetermine = Int(Rnd() * 9) + 1
            If ProbabilityDetermine <= 3 Then
                CurrentMoveForWinnerChange = "R"
            End If
            If ProbabilityDetermine > 3 And ProbabilityDetermine <= 6 Then
                CurrentMoveForWinnerChange = "P"
            End If
            If ProbabilityDetermine > 6 Then
                CurrentMoveForWinnerChange = "S"
            End If
        End If

        If WinnerChangeStreak > 0 Then
            TempStorage = CurrentMoveForWinnerChange
            Randomize()
            ProbabilityDetermine = Int(Rnd() * 99) + 1
            If ProbabilityDetermine <= 65 Then
                CurrentMoveForWinnerChange = CurrentMoveForWinnerChange
            End If
            If ProbabilityDetermine > 65 Then
                Randomize()
                ProbabilityDetermine = Int(Rnd() * 10) + 1
                If TempStorage = "R" Then
                    If ProbabilityDetermine <= 5 Then
                        CurrentMoveForWinnerChange = "S"
                    ElseIf ProbabilityDetermine > 5 Then
                        CurrentMoveForWinnerChange = "P"
                    End If
                End If
                If TempStorage = "P" Then
                    If ProbabilityDetermine <= 5 Then
                        CurrentMoveForWinnerChange = "R"
                    ElseIf ProbabilityDetermine > 5 Then
                        CurrentMoveForWinnerChange = "S"
                    End If
                End If
                If TempStorage = "S" Then
                    If ProbabilityDetermine <= 5 Then
                        CurrentMoveForWinnerChange = "R"
                    ElseIf ProbabilityDetermine > 5 Then
                        CurrentMoveForWinnerChange = "P"
                    End If
                End If
            End If
        End If

        Return CurrentMoveForWinnerChange




    End Function

    Function MoveForChangingLoser() As Char
        Dim ProbabilityDetermine As Double
        Dim TempStorage As Char

        If LoserChangeStreak = 0 Then
            Randomize()
            ProbabilityDetermine = Int(Rnd() * 9) + 1
            If ProbabilityDetermine <= 3 Then
                CurrentMoveForChangingLoser = "R"
            End If
            If ProbabilityDetermine > 3 And ProbabilityDetermine <= 6 Then
                CurrentMoveForChangingLoser = "P"
            End If
            If ProbabilityDetermine > 6 Then
                CurrentMoveForChangingLoser = "S"
            End If
        End If

        If LoserChangeStreak > 0 Then
            TempStorage = CurrentMoveForChangingLoser
            Randomize()
            ProbabilityDetermine = Int(Rnd() * 99) + 1
            If ProbabilityDetermine > 65 Then '35% chance of staying with the same move on a loss
                CurrentMoveForChangingLoser = CurrentMoveForChangingLoser
            Else '65% chance of changing moves on a loss
                Randomize()
                ProbabilityDetermine = Int(Rnd() * 10) + 1
                If TempStorage = "R" Then
                    If ProbabilityDetermine <= 5 Then
                        CurrentMoveForChangingLoser = "S"
                    ElseIf ProbabilityDetermine > 5 Then
                        CurrentMoveForChangingLoser = "P"
                    End If
                End If
                If TempStorage = "P" Then
                    If ProbabilityDetermine <= 5 Then
                        CurrentMoveForChangingLoser = "R"
                    ElseIf ProbabilityDetermine > 5 Then
                        CurrentMoveForChangingLoser = "S"
                    End If
                End If
                If TempStorage = "S" Then
                    If ProbabilityDetermine <= 5 Then
                        CurrentMoveForChangingLoser = "R"
                    ElseIf ProbabilityDetermine > 5 Then
                        CurrentMoveForChangingLoser = "P"
                    End If
                End If
            End If
        End If

        Return CurrentMoveForChangingLoser

    End Function

    Function MoveForAverageHuman()
        If STDWinnerChangeStreak > 1 Then
            STDWinnerChangeStreak = 0
        End If

        Dim ProbabilityDetermine As Double
        Dim TempStorage As Char

        If STDLoserChangeStreak = 0 And STDWinnerChangeStreak = 0 Then
            Randomize()
            ProbabilityDetermine = Int(Rnd() * 9) + 1
            If ProbabilityDetermine <= 3 Then
                CurrentMoveForStandard = "R"
            End If
            If ProbabilityDetermine > 3 And ProbabilityDetermine <= 6 Then
                CurrentMoveForStandard = "P"
            End If
            If ProbabilityDetermine > 6 Then
                CurrentMoveForStandard = "S"
            End If
        ElseIf STDWinnerChangeStreak > 0 Then
            TempStorage = CurrentMoveForStandard
            Randomize()
            ProbabilityDetermine = Int(Rnd() * 99) + 1
            If ProbabilityDetermine <= 55 Then
                CurrentMoveForStandard = CurrentMoveForStandard
            End If
            If ProbabilityDetermine > 55 Then
                Randomize()
                ProbabilityDetermine = Int(Rnd() * 10) + 1
                If TempStorage = "R" Then
                    If ProbabilityDetermine <= 5 Then
                        CurrentMoveForStandard = "S"
                    ElseIf ProbabilityDetermine > 5 Then
                        CurrentMoveForStandard = "P"
                    End If
                End If
                If TempStorage = "P" Then
                    If ProbabilityDetermine <= 5 Then
                        CurrentMoveForStandard = "R"
                    ElseIf ProbabilityDetermine > 5 Then
                        CurrentMoveForStandard = "S"
                    End If
                End If
                If TempStorage = "S" Then
                    If ProbabilityDetermine <= 5 Then
                        CurrentMoveForStandard = "R"
                    ElseIf ProbabilityDetermine > 5 Then
                        CurrentMoveForStandard = "P"
                    End If
                End If
            End If
        ElseIf STDLoserChangeStreak > 0 Then
            TempStorage = CurrentMoveForStandard
            Randomize()
            ProbabilityDetermine = Int(Rnd() * 99) + 1
            If ProbabilityDetermine > 55 Then '45% chance of staying with the same move on a loss
                CurrentMoveForStandard = CurrentMoveForStandard
            Else '65% chance of changing moves on a loss
                Randomize()
                ProbabilityDetermine = Int(Rnd() * 10) + 1
                If TempStorage = "R" Then
                    If ProbabilityDetermine <= 5 Then
                        CurrentMoveForStandard = "S"
                    ElseIf ProbabilityDetermine > 5 Then
                        CurrentMoveForStandard = "P"
                    End If
                End If
                If TempStorage = "P" Then
                    If ProbabilityDetermine <= 5 Then
                        CurrentMoveForStandard = "R"
                    ElseIf ProbabilityDetermine > 5 Then
                        CurrentMoveForStandard = "S"
                    End If
                End If
                If TempStorage = "S" Then
                    If ProbabilityDetermine <= 5 Then
                        CurrentMoveForStandard = "R"
                    ElseIf ProbabilityDetermine > 5 Then
                        CurrentMoveForStandard = "P"
                    End If
                End If
            End If
        End If

        Return CurrentMoveForStandard

    End Function

    Function MoveForNash()
        Dim ProbabilityDetermine As Double
        Dim TempStorage As Char

        Randomize()

        If NashWin = 1 Then
            TempStorage = CurrentMoveForNash
            If TempStorage = "R" Then
                CurrentMoveForNash = "S"
            ElseIf TempStorage = "S" Then
                CurrentMoveForNash = "P"
            ElseIf TempStorage = "P" Then
                CurrentMoveForNash = "R"
            End If
        ElseIf NashWin = 2 Then
            TempStorage = CurrentMoveForNash
            If TempStorage = "R" Then
                CurrentMoveForNash = "S"
            ElseIf TempStorage = "S" Then
                CurrentMoveForNash = "P"
            ElseIf TempStorage = "P" Then
                CurrentMoveForNash = "R"
            End If
        ElseIf NashWin = 3 Then
            ProbabilityDetermine = Int(Rnd() * 9) + 1
            If ProbabilityDetermine <= 3 Then
                CurrentMoveForNash = "R"
            End If
            If ProbabilityDetermine > 3 And ProbabilityDetermine <= 6 Then
                CurrentMoveForNash = "P"
            End If
            If ProbabilityDetermine > 6 Then
                CurrentMoveForNash = "S"
            End If
        End If

        Return CurrentMoveForNash
    End Function

End Module