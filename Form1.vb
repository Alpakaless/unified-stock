Imports System.Reflection
Imports Org.BouncyCastle.Utilities

Public Class Form1
    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Dim CPF As String = txtUsuario.Text.Trim()
        Dim senha As String = txtSenha.Text.Trim()
        If CPF = "" Or senha = "" Then
            MsgBox("Preencha todos os campos.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If db.State = 0 Then
            databaseConnect()
        End If
        sql = "SELECT Tipo FROM funcionarios WHERE CPF = '" & CPF & "' AND Senha = '" & senha & "'"
        Try
            If rs.State = 1 Then rs.Close()
            rs.Open(sql, db, 0, 1)
            If Not rs.EOF Then
                tipoUsuarioLogado = rs.Fields("Tipo").Value.ToString()
                Dim novoForm3 As New Form3()
                novoForm3.Show()
                Me.Hide()
            Else
                MsgBox("Credenciais inválidas", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
            End If
            rs.Close()
        Catch ex As Exception
            MsgBox("Erro ao tentar logar: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub LimparLogin()
        txtUsuario.Text = ""
        txtSenha.Text = ""
        tipoUsuarioLogado = ""
    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles Label3.Click
        Form2.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        databaseConnect()
    End Sub
End Class

