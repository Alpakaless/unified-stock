Module Module1
    Public db As New ADODB.Connection
    Public rs As New ADODB.Recordset

    Sub databaseConnect()
        Try
            db = CreateObject("ADODB.Connection")
            db.Open("DRIVER={MySQL ODBC 3.51 Driver}; SERVER=localhost; DATABASE=unified-stock; UID=root; PWD=usbw; port=3307; option=3")
            MsgBox("Banco conectado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
        Catch ex As Exception
            MsgBox("Erro ao conectar no banco", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

End Module
