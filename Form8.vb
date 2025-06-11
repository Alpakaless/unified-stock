Public Class Form8
    Public modoEdicao As Boolean = False
    Public cpfSelecionado As String = ""
    Public nomeFuncionario, emailFuncionario, cpfFuncionario, senhaFuncionario, tipoFuncionario As String

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If modoEdicao Then
            sql = "SELECT * FROM funcionarios WHERE cpf = '" & cpfSelecionado & "'"
            rs.Open(sql, db, 1, 1)
            If Not rs.EOF Then
                txtCPF.Text = rs("cpf").Value
                txtNome.Text = rs("nome").Value
                txtEmail.Text = rs("email").Value
                txtSenha.Text = rs("senha").Value
                cmbTipo.Text = rs("tipo").Value
                txtCPF.Enabled = False
            End If
            rs.Close()
            GunaButton1.Text = "Salvar"
        End If
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        If txtNome.Text.Trim() = "" Or txtCPF.Text.Trim() = "" Or txtSenha.Text.Trim() = "" Or cmbTipo.Text.Trim() = "" Then
            MsgBox("Preencha todos os campos obrigatórios.")
            Exit Sub
        End If
        If Not IsNumeric(txtCPF.Text) OrElse txtCPF.Text.Any(Function(c) Not Char.IsDigit(c)) Then
            MsgBox("O CPF deve conter apenas números.")
            Exit Sub
        End If
        If txtCPF.Text.Length <> 11 Then
            MsgBox("Insira um CPF válido")
            Exit Sub
        End If
        If db Is Nothing OrElse db.State <> 1 Then
            databaseConnect()
        End If
        If Not modoEdicao Then
            sql = "SELECT * FROM funcionarios WHERE cpf = '" & txtCPF.Text & "'"
            rs.Open(sql, db, 1, 1)
            If Not rs.EOF Then
                MsgBox("Já existe um funcionário cadastrado com este CPF.")
                rs.Close()
                Exit Sub
            End If
            rs.Close()
        End If
        If modoEdicao Then
            sql = "UPDATE funcionarios SET nome = '" & txtNome.Text & "', email = '" & txtEmail.Text & "', senha = '" & txtSenha.Text & "', tipo = '" & cmbTipo.Text & "' WHERE cpf = '" & cpfSelecionado & "'"
        Else
            sql = "INSERT INTO funcionarios (cpf, nome, email, senha, tipo) VALUES ('" & txtCPF.Text & "', '" & txtNome.Text & "', '" & txtEmail.Text & "', '" & txtSenha.Text & "', '" & cmbTipo.Text & "')"
        End If
        Try
            db.Execute(sql)
            MsgBox("Funcionário salvo com sucesso!")
            Form6.carregarFuncionarios()
            Me.Close()
        Catch ex As Exception
            MsgBox("Erro: " & ex.Message)
        End Try
    End Sub
End Class