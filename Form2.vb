Public Class Form2
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Dim usuario As String = txtUsuario.Text.Trim()
        Dim novaSenha As String = txtNovaSenha.Text.Trim()
        Dim repetirSenha As String = txtRepetirSenha.Text.Trim()
        If usuario = "" Or novaSenha = "" Or repetirSenha = "" Then
            MsgBox("Preencha todos os campos.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If novaSenha <> repetirSenha Then
            MsgBox("As senhas não coincidem.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If db.State = 0 Then databaseConnect()
        sql = "SELECT * FROM funcionarios WHERE CPF = '" & usuario & "'"

        If rs.State = 1 Then rs.Close()
        rs.Open(sql, db, 1, 3)

        If rs.EOF Then
            MsgBox("Usuário não encontrado.", MsgBoxStyle.Critical)
            rs.Close()
            Exit Sub
        End If
        rs.Close()
        sql = "UPDATE funcionarios SET Senha = '" & novaSenha & "' WHERE CPF = '" & usuario & "'"
        Try
            db.Execute(sql)
            MsgBox("Senha redefinida com sucesso!", MsgBoxStyle.Information)
            Me.Close()
        Catch ex As Exception
            MsgBox("Erro ao redefinir senha: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class