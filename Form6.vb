Public Class Form6
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Form7.Show()
        Me.Hide()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Form8.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If db Is Nothing OrElse db.State <> 1 Then
            databaseConnect()
        End If

        CarregarFuncionario()
    End Sub
    Private Sub CarregarFuncionario()
        Dim dt As New DataTable
        Dim rsAux As New ADODB.Recordset
        sql = "SELECT * FROM funcionarios"

        Try
            If rsAux.State = 1 Then rsAux.Close()
            rsAux.Open(sql, db, 0, 1)
            If rsAux.EOF Then
                MsgBox("Sem resultados encontrados.")
            Else
                dt = RecordsetToDataTable(rsAux)
                DataGridView1.Columns.Clear()
                DataGridView1.AutoGenerateColumns = True
                DataGridView1.DataSource = dt
            End If
            rsAux.Close()
        Catch ex As Exception
            MsgBox("Erro: " & ex.Message)
        End Try
    End Sub
End Class