Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If tipoUsuarioLogado = "" Then
            MsgBox("Você precisa fazer login primeiro.")
            Form1.Show()
            Me.Close()
            Exit Sub
        End If
        If tipoUsuarioLogado = "FUNC" Then
            Label3.Visible = False
            Label4.Visible = False
        ElseIf tipoUsuarioLogado = "ADM" Then
            Label3.Visible = True
            Label4.Visible = True
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        tipoUsuarioLogado = ""
        Form1.LimparLogin()
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form4.Show()
        Me.Close()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Form7.Show()
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Form6.Show()
        Me.Close()
    End Sub
End Class