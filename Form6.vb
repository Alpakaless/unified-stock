Public Class Form6
    Public modoEdicao As Boolean = False
    Public cpfSelecionado As String = ""

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Form4.Show()
        Me.Close()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Form7.Show()
        Me.Close()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Form1.LimparLogin()
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Dim cadastroForm As New Form8()
        cadastroForm.ShowDialog()
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If db Is Nothing OrElse db.State <> 1 Then
            databaseConnect()
        End If

        carregarFuncionarios()
    End Sub
    Public Sub carregarFuncionarios()
        sql = "SELECT * FROM funcionarios"
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

            Dim editarForm As New Form8()
            editarForm.nomeFuncionario = linha.Cells("Nome").Value.ToString()
            editarForm.emailFuncionario = linha.Cells("Email").Value.ToString()
            editarForm.cpfFuncionario = linha.Cells("CPF").Value.ToString()
            editarForm.senhaFuncionario = linha.Cells("Senha").Value.ToString()
            editarForm.tipoFuncionario = linha.Cells("Tipo").Value.ToString()
            editarForm.modoEdicao = True
            editarForm.cpfSelecionado = linha.Cells("CPF").Value.ToString()

            editarForm.ShowDialog()
            carregarFuncionarios()
        Else
            MsgBox("Selecione um funcionário para atualizar.")
        End If
    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Selecione um funcionário para deletar.")
            Exit Sub
        End If

        Dim cpf As String = DataGridView1.SelectedRows(0).Cells("cpf").Value.ToString()

        If MsgBox("Deseja realmente deletar este funcionário?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            sql = "DELETE FROM funcionarios WHERE cpf = '" & cpf & "'"
            Try
                db.Execute(sql)
                MsgBox("Funcionário deletado com sucesso!")
                carregarFuncionarios()
            Catch ex As Exception
                MsgBox("Erro ao deletar: " & ex.Message)
            End Try
        End If
    End Sub
End Class