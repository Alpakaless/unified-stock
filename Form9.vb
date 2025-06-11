Public Class Form9
    Public modoEdicao As Boolean = False
    Public cnpjSelecionado As String = ""
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If modoEdicao Then
            sql = "SELECT * FROM fornecedores WHERE CNPJ = '" & cnpjSelecionado & "'"
            rs.Open(sql, db, 1, 1)
            If Not rs.EOF Then
                txtNome.Text = rs("Nome").Value
                txtEmail.Text = rs("Email").Value
                txtCNPJ.Text = rs("CNPJ").Value
                txtTelefone.Text = rs("Telefone").Value
                txtCNPJ.Enabled = False
            End If
            rs.Close()
            GunaButton1.Text = "Salvar"
        End If
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        If txtNome.Text.Trim() = "" Or txtCNPJ.Text.Trim() = "" Or txtTelefone.Text.Trim() = "" Then
            MsgBox("Preencha todos os campos obrigatórios.")
            Exit Sub
        End If
        If Not IsNumeric(txtCNPJ.Text) Then
            MsgBox("O CNPJ deve conter apenas números.")
            Exit Sub
        End If
        If txtCNPJ.Text.Length <> 14 Then
            MsgBox("Insira um CNPJ válido")
            Exit Sub
        End If
        If Not modoEdicao Then
            sql = "SELECT * FROM fornecedores WHERE CNPJ = '" & txtCNPJ.Text & "'"
            rs.Open(sql, db, 1, 1)
            If Not rs.EOF Then
                MsgBox("Este CNPJ já está cadastrado.")
                rs.Close()
                Exit Sub
            End If
            rs.Close()
        End If

        If modoEdicao Then
            sql = "UPDATE fornecedores SET Nome = '" & txtNome.Text & "', Email = '" & txtEmail.Text & "', Telefone = '" & txtTelefone.Text & "' WHERE CPNJ = '" & cnpjSelecionado & "'"
        Else
            sql = "INSERT INTO fornecedores (cnpj, Nome, Email, Telefone) VALUES ('" & txtCNPJ.Text & "', '" & txtNome.Text & "', '" & txtEmail.Text & "', '" & txtTelefone.Text & "')"
        End If

        Try
            db.Execute(sql)
            MsgBox("Fornecedor salvo com sucesso!")
            Form7.carregarFornecedores()
            Me.Close()
        Catch ex As Exception
            MsgBox("Erro: " & ex.Message)
        End Try
    End Sub
End Class