Imports System.Data.OleDb
Imports System.Data
Public Class Form4

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        tipoUsuarioLogado = ""
        Form1.LimparLogin()
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Label4_Click_1(sender As Object, e As EventArgs) Handles Label4.Click
        Form7.Show()
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Form6.Show()
        Me.Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Selecione um item para editar.")
            Exit Sub
        End If

        Dim linha As DataGridViewRow = DataGridView1.SelectedRows(0)

        With Form10
            .editarModo = True
            .idProdutoEditar = linha.Cells("ID").Value
            .txtNome.Text = linha.Cells("Nome").Value.ToString()
            .txtDescricao.Text = linha.Cells("Descricao").Value.ToString()
            .txtPreco.Text = linha.Cells("Preco").Value.ToString()
            .txtQuantidade.Text = linha.Cells("Quantidade").Value.ToString()
            .ShowDialog()
        End With
    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Selecione um item para deletar.")
            Exit Sub
        End If

        Dim id As Integer = DataGridView1.SelectedRows(0).Cells("ID").Value

        If MsgBox("Tem certeza que deseja excluir o item selecionado?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmação") = MsgBoxResult.Yes Then
            Try
                sql = "DELETE FROM produtos WHERE ID = " & id
                db.Execute(sql)
                MsgBox("Item deletado com sucesso.", MsgBoxStyle.Information)
                CarregarEstoque()
            Catch ex As Exception
                MsgBox("Erro ao deletar: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Form10.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If db Is Nothing OrElse db.State <> 1 Then
            databaseConnect()
        End If
        CarregarEstoque()
        verificarEstoqueBaixo()
        If tipoUsuarioLogado = "FUNC" Then
            Label3.Visible = False
            Label4.Visible = False
        End If
    End Sub
    Public Sub CarregarEstoque()
        If rs.State = 1 Then rs.Close()
        sql = "SELECT * FROM produtos"
        rs.Open(sql, db, 1, 3)

        Dim dt As DataTable = RecordsetToDataTable(rs)
        DataGridView1.Columns.Clear()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.DataSource = dt
    End Sub
    Private Sub verificarEstoqueBaixo()
        Const limiteMinimo As Integer = 5
        Dim produtosBaixos As New List(Of String)
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Continue For
            Dim nomeProduto As String = row.Cells("Nome").Value?.ToString()
            Dim quantidade As Integer = 0
            If Not IsDBNull(row.Cells("Quantidade").Value) AndAlso
               Integer.TryParse(row.Cells("Quantidade").Value.ToString(), quantidade) Then
                If quantidade <= limiteMinimo Then
                    produtosBaixos.Add($"{nomeProduto} (Qtd: {quantidade})")
                End If
            End If
        Next
        If produtosBaixos.Count > 0 Then
            Dim msg As String = "Os seguintes produtos estão com o estoque baixo:" & vbCrLf &
                                String.Join(vbCrLf, produtosBaixos)
            MsgBox(msg, MsgBoxStyle.OkOnly, "Aviso de Estoque Baixo")
        End If
    End Sub
End Class