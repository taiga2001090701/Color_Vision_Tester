Imports System.Drawing
Imports System.Windows.Forms

Public Class Main
    Dim b As Integer
    Dim t As Boolean
    Dim cr, cg, cb As Integer
    Dim tr, tg, tb As Integer
    Dim r As New Random

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To 100
            SL.Items.Add(i & "階調")
        Next
        SL.SelectedIndex = SL.Items.Count - 1
        t = False
    End Sub

    Private Sub BN_Click(sender As Object, e As EventArgs) Handles BN.Click
        BN.Enabled = False
        SL.Enabled = False
        b = r.Next(1, 101)
        cr = r.Next(0, 256)
        cg = r.Next(0, 256)
        cb = r.Next(0, 256)
        For i = 1 To 100
            If i = b Then
                tr = cr
                tg = cg
                tb = cb
                Dim n As Integer
                n = SL.SelectedIndex + 1
                Dim w As Integer
                If 255 * 3 - tr - tg - tb < n Then
                    w = 2
                ElseIf tr + tg + tb < n Then
                    w = 1
                Else
                    w = r.Next(1, 3)
                End If
                Do Until n = 0
                    Select Case r.Next(1, 4)
                        Case 1
                            If w = 1 Then
                                If tr < 255 Then
                                    tr += 1
                                    n -= 1
                                End If
                            Else
                                If tr > 0 Then
                                    tr -= 1
                                    n -= 1
                                End If
                            End If
                        Case 2
                            If w = 1 Then
                                If tg < 255 Then
                                    tg += 1
                                    n -= 1
                                End If
                            Else
                                If tg > 0 Then
                                    tg -= 1
                                    n -= 1
                                End If
                            End If
                        Case 3
                            If w = 1 Then
                                If tb < 255 Then
                                    tb += 1
                                    n -= 1
                                End If
                            Else
                                If tb > 0 Then
                                    tb -= 1
                                    n -= 1
                                End If
                            End If
                    End Select
                Loop
                Controls.Find("Button" & i, False)(0).BackColor = Color.FromArgb(tr, tg, tb)
                Refresh()
            Else
                Controls.Find("Button" & i, False)(0).BackColor = Color.FromArgb(cr, cg, cb)
                Refresh()
            End If
        Next
        t = True
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button99.Click, Button98.Click, Button97.Click, Button96.Click, Button95.Click, Button94.Click, Button93.Click, Button92.Click, Button91.Click, Button90.Click, Button9.Click, Button89.Click, Button88.Click, Button87.Click, Button86.Click, Button85.Click, Button84.Click, Button83.Click, Button82.Click, Button81.Click, Button80.Click, Button8.Click, Button79.Click, Button78.Click, Button77.Click, Button76.Click, Button75.Click, Button74.Click, Button73.Click, Button72.Click, Button71.Click, Button70.Click, Button7.Click, Button69.Click, Button68.Click, Button67.Click, Button66.Click, Button65.Click, Button64.Click, Button63.Click, Button62.Click, Button61.Click, Button60.Click, Button6.Click, Button59.Click, Button58.Click, Button57.Click, Button56.Click, Button55.Click, Button54.Click, Button53.Click, Button52.Click, Button51.Click, Button50.Click, Button5.Click, Button49.Click, Button48.Click, Button47.Click, Button46.Click, Button45.Click, Button44.Click, Button43.Click, Button42.Click, Button41.Click, Button40.Click, Button4.Click, Button39.Click, Button38.Click, Button37.Click, Button36.Click, Button35.Click, Button34.Click, Button33.Click, Button32.Click, Button31.Click, Button30.Click, Button3.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click, Button21.Click, Button20.Click, Button2.Click, Button19.Click, Button18.Click, Button17.Click, Button16.Click, Button15.Click, Button14.Click, Button13.Click, Button12.Click, Button11.Click, Button100.Click, Button10.Click, Button1.Click
        If t Then
            t = False
            If sender.Name = "Button" & b Then
                Refresh()
                If SL.SelectedIndex = 0 Then
                    MsgBox("1階調の違いまでを認識できました" & vbCrLf & "(" & cr & ", " & cg & ", " & cb & ") - " & "(" & tr & ", " & tg & ", " & tb & ")" & vbCrLf & "これ以上微妙な色の差はコンピュータ上では表現できません！", MsgBoxStyle.OkOnly, "Perfect")
                Else
                    MsgBox(SL.SelectedIndex + 1 & "階調の違いを認識できました" & vbCrLf & "(" & cr & ", " & cg & ", " & cb & ") - " & "(" & tr & ", " & tg & ", " & tb & ")", MsgBoxStyle.OkOnly, "Clear")
                    SL.SelectedIndex = SL.SelectedIndex - 1
                End If
                BN.Enabled = True
                SL.Enabled = True
                BN.Focus()
            Else
                Refresh()
                CType(Controls.Find("Button" & b, False)(0), Button).FlatAppearance.BorderSize = 2
                Refresh()
                Threading.Thread.Sleep(500)
                CType(Controls.Find("Button" & b, False)(0), Button).FlatAppearance.BorderSize = 0
                Refresh()
                Threading.Thread.Sleep(500)
                CType(Controls.Find("Button" & b, False)(0), Button).FlatAppearance.BorderSize = 2
                Refresh()
                Threading.Thread.Sleep(500)
                CType(Controls.Find("Button" & b, False)(0), Button).FlatAppearance.BorderSize = 0
                Refresh()
                Threading.Thread.Sleep(500)
                CType(Controls.Find("Button" & b, False)(0), Button).FlatAppearance.BorderSize = 2
                Refresh()
                Threading.Thread.Sleep(500)
                CType(Controls.Find("Button" & b, False)(0), Button).FlatAppearance.BorderSize = 0
                Refresh()
                MsgBox(SL.SelectedIndex + 1 & "階調の違いを認識できませんでした" & vbCrLf & "(" & cr & ", " & cg & ", " & cb & ") - " & "(" & tr & ", " & tg & ", " & tb & ")", MsgBoxStyle.OkOnly, "Game Over")
                BN.Enabled = True
                SL.Enabled = True
                BN.Focus()
            End If
        End If
    End Sub

    Private Sub SL_KeyDown(sender As Object, e As KeyEventArgs) Handles SL.KeyDown
        If e.KeyCode = Keys.Enter Then
            BN.PerformClick()
        End If
    End Sub
End Class