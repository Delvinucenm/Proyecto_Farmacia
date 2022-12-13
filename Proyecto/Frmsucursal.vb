Public Class Frmsucursal

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click

        If txtidsucursal.Text = "" Or txtnombresucursal.Text = "" Or txtubicacion.Text = "" Then
            MessageBox.Show("Debe llenar todos los campos")
        Else
            Dim con As SqlClient.SqlConnection = New SqlClient.SqlConnection(My.Settings.proyecto)
            Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("SP_sucursales", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@bandera", 1)
            cmd.Parameters.AddWithValue("@idsucursal", txtidsucursal.Text)
            cmd.Parameters.AddWithValue("@nombresucursal", txtnombresucursal.Text)
            cmd.Parameters.AddWithValue("@ubicacion", txtubicacion.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Surcursal guardada correctamente", "Proyecto")
            limpiar_controles()
            con.Close()
        End If

    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Close()
    End Sub

    Sub limpiar_controles()
        txtidsucursal.Text = ""
        txtnombresucursal.Text = ""
        txtubicacion.Text = ""
        txtidsucursal.Focus()
    End Sub

End Class