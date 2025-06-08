Imports System.Data.OleDb
Imports System.Data
Public Class Form4
    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click_1(sender As Object, e As EventArgs) Handles Label4.Click
        Form7.Show()
        Me.Hide()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click

    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If db Is Nothing OrElse db.State <> 1 Then
            databaseConnect()
        End If

        CarregarEstoque()
    End Sub
    Private Sub CarregarEstoque()
        Dim dt As New DataTable
        Dim rsAux As New ADODB.Recordset
        sql = "SELECT * FROM produtos"

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