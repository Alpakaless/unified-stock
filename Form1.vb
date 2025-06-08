Public Class Form1
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaTextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaTextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Dim usuario As String = txtUsuario.Text
        Dim senha As String = txtSenha.Text

        sql = "Select Tipo FROM funcionarios where Usuario = '" & usuario & "' AND senha = '" & senha & "'"
        Try
            If rs.State = 1 Then rs.Close()
            rs.Open(sql, db, 0, 1)

            If Not rs.EOF Then
                Dim tipoConta As String = rs.Fields("Tipo").Value.ToString()

                If tipoConta = "ADM" Then
                    Form3.Show()
                    Me.Hide()
                ElseIf tipoConta = "FUNC" Then
                    Form3.Show()
                    Me.Hide()
                End If
            Else
                MsgBox("Credenciais inválidas", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
            End If

            rs.Close()
        Catch ex As Exception
            MsgBox("Erro ao tentar logar:" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
        End Try
    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub GunaTextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles txtUsuario.TextChanged

    End Sub

    Private Sub GunaTextBox2_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles Label3.Click
        Form2.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        databaseConnect()
    End Sub
End Class
