Imports System.Data.SqlClient
Public Class Frmlogin

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Application.Exit()
    End Sub

    Private Sub btningresar_Click(sender As Object, e As EventArgs) Handles btningresar.Click
        Dim con As New SqlClient.SqlConnection(My.Settings.proyecto)
        con.Open()
        Dim reader As SqlClient.SqlDataReader
        Dim cmd As New SqlClient.SqlCommand("SELECT * FROM Usuarios WHERE idusuario = '" & txtusuario.Text & " ' and contraseña =  '" & txtcontrasena.Text & "' ", con)
        reader = cmd.ExecuteReader

        If reader.Read() Then
            If reader.Item("activo") = True Then
                VariablesPublicas.idusuario = reader.Item("idusuario")
                VariablesPublicas.nivelacceso = reader.Item("nivelacceso")
                VariablesPublicas.nombreusuario = reader.Item("Nombrecompleto")
                Me.Dispose()
                FrmMenu.ShowDialog()
            Else
                MessageBox.Show("Usuario inactivo")
            End If
        Else
            MessageBox.Show("Usuario o contrasena incorrectos")
        End If
    End Sub

    Private Sub txtusuario_TextChanged(sender As Object, e As EventArgs) Handles txtusuario.TextChanged

    End Sub
End Class
