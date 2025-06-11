Module Module1
    Public db As New ADODB.Connection
    Public rs As New ADODB.Recordset
    Public sql, cont As String
    Public tipoUsuarioLogado As String

    Sub databaseConnect()
        Try
            db = CreateObject("ADODB.Connection")
            db.Open("DRIVER={MySQL ODBC 3.51 Driver}; SERVER=localhost; DATABASE=unified-stock; UID=root; PWD=usbw; port=3307; option=3")
        Catch ex As Exception
            MsgBox("Erro ao conectar no banco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub
    Public Function RecordsetToDataTable(rs As ADODB.Recordset) As DataTable
        Dim dt As New DataTable

        Try
            If rs Is Nothing OrElse rs.State = 0 Then
                Return dt
            End If

            For i As Integer = 0 To rs.Fields.Count - 1
                dt.Columns.Add(rs.Fields(i).Name)
            Next

            While Not rs.EOF
                Dim row As DataRow = dt.NewRow()
                For i As Integer = 0 To rs.Fields.Count - 1
                    row(i) = rs.Fields(i).Value
                Next
                dt.Rows.Add(row)
                rs.MoveNext()
            End While

        Catch ex As Exception
            MsgBox("Erro ao converter Recordset para DataTable: " & ex.Message, MsgBoxStyle.Critical)
        End Try

        Return dt
    End Function
End Module
