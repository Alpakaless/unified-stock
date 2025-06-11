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
                txtNome.Text = rs("nomefornecedor").Value
                txtEmail.Text = rs("emailfornecedor").Value
                txtCNPJ.Text = rs("cnpj").Value
                txtTelefone.Text = rs("telfornecedor").Value
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

        If Not modoEdicao Then
            ' Verifica se CNPJ já existe
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
            sql = "UPDATE fornecedores SET nomefornecedor = '" & txtNome.Text & "', emailfornecedor = '" & txtEmail.Text & "', telfornecedor = '" & txtTelefone.Text & "' WHERE cnpj = '" & cnpjSelecionado & "'"
        Else
            sql = "INSERT INTO fornecedores (cnpj, nomefornecedor, emailfornecedor, telfornecedor) VALUES ('" & txtCNPJ.Text & "', '" & txtNome.Text & "', '" & txtEmail.Text & "', '" & txtTelefone.Text & "')"
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