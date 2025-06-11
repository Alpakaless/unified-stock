Public Class Form10
    Public editarModo As Boolean = False
    Public idProdutoEditar As Integer = -1
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        If txtNome.Text = "" Or txtPreco.Text = "" Or txtQuantidade.Text = "" Then
            MsgBox("Preencha todos os campos obrigatórios.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Try
            If editarModo = False Then
                sql = "INSERT INTO produtos (Nome, Descricao, Preco, Quantidade) VALUES ('" &
                  txtNome.Text & "', '" & txtDescricao.Text & "', '" & txtPreco.Text & "', '" & txtQuantidade.Text & "')"
                db.Execute(sql)
                MsgBox("Produto cadastrado com sucesso!", MsgBoxStyle.Information)
            Else
                sql = "UPDATE produtos SET Nome = '" & txtNome.Text & "', Descricao = '" & txtDescricao.Text &
                  "', Preco = '" & txtPreco.Text & "', Quantidade = '" & txtQuantidade.Text & "' WHERE ID = " & idProdutoEditar
                db.Execute(sql)
                MsgBox("Produto atualizado com sucesso!", MsgBoxStyle.Information)
            End If

            Form4.CarregarEstoque()
            Me.Close()
        Catch ex As Exception
            MsgBox("Erro ao salvar: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub txtNome_TextChanged(sender As Object, e As EventArgs) Handles txtNome.TextChanged

    End Sub
End Class