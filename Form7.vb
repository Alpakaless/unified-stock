Public Class Form7
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Form4.Show()
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Form6.Show()
        Me.Close()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Form1.LimparLogin()
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Dim cadastroForm As New Form9()
        cadastroForm.ShowDialog()
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If db Is Nothing OrElse db.State <> 1 Then databaseConnect()
        carregarFornecedores()
    End Sub
    Public Sub carregarFornecedores()
        sql = "SELECT * FROM fornecedores"
        If rs.State = 1 Then rs.Close()
        rs.Open(sql, db, 1, 1)

        Dim dt As New DataTable
        dt = RecordsetToDataTable(rs)
        DataGridView1.Columns.Clear()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.DataSource = dt
        rs.Close()
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim linha As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim formCadastro As New Form9()
            formCadastro.modoEdicao = True
            formCadastro.cnpjSelecionado = linha.Cells("cnpj").Value.ToString()
            formCadastro.ShowDialog()
        Else
            MsgBox("Selecione um fornecedor para editar.")
        End If
    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Selecione um fornecedor para remover.")
            Exit Sub
        End If
        Dim cnpj As String = DataGridView1.SelectedRows(0).Cells("CNPJ").Value.ToString()
        If MsgBox("Deseja realmente excluir este fornecedor?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            sql = "DELETE FROM fornecedores WHERE CNPJ = '" & cnpj & "'"
            Try
                db.Execute(sql)
                MsgBox("Fornecedor removido com sucesso!")
                carregarFornecedores()
            Catch ex As Exception
                MsgBox("Erro ao remover: " & ex.Message)
            End Try
        End If
    End Sub
End Class