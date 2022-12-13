Public Class FrmProductos
    Private Sub btnactualizar_Click(sender As Object, e As EventArgs) Handles btnactualizar.Click
        If txtidproducto.Text = "" Or txtdescripcion.Text = "" Or txttipoproducto.Text = "" Then
            MessageBox.Show("Debe llenar todos los campos")
        Else
            Dim con As SqlClient.SqlConnection = New SqlClient.SqlConnection(My.Settings.proyecto)
            Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("SP_Productos", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@bandera", 2)
            cmd.Parameters.AddWithValue("@idproducto", txtidproducto.Text)
            cmd.Parameters.AddWithValue("@descripcion", txtdescripcion.Text)
            cmd.Parameters.AddWithValue("@tipoproducto", txttipoproducto.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Producto actualizado correctamente", "Proyecto RAD")
            limpiar()
            con.Close()
        End If
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        If txtidproducto.Text = "" Or txtdescripcion.Text = "" Or txttipoproducto.Text = "" Then
            MessageBox.Show("Debe llenar todos los campos")
        Else
            Dim con As SqlClient.SqlConnection = New SqlClient.SqlConnection(My.Settings.proyecto)
            Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("SP_Productos", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@bandera", 1)
            cmd.Parameters.AddWithValue("@idproducto", txtidproducto.Text)
            cmd.Parameters.AddWithValue("@descripcion", txtdescripcion.Text)
            cmd.Parameters.AddWithValue("@tipoproducto", txttipoproducto.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Producto guardado correctamente", "Proyecto RAD")
            limpiar()
            con.Close()
        End If
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        Limpiar()
    End Sub
    Sub limpiar()
        txtidproducto.Clear()
        txtdescripcion.Clear()
        txttipoproducto.Clear()

        txtidproducto.Focus()
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Close()
    End Sub

    Private Sub btnselect_Click(sender As Object, e As EventArgs) Handles btnselect.Click
        Dim con As New SqlClient.SqlConnection(My.Settings.proyecto)
        con.Open()
        Dim reader As SqlClient.SqlDataReader
        Dim cmd As New SqlClient.SqlCommand("SELECT * FROM productos WHERE idproducto = '" & txtidproducto.Text & "'", con)
        reader = cmd.ExecuteReader

        If reader.Read() Then
            txtidproducto.Text = reader.Item("idproducto")
            txtdescripcion.Text = reader.Item("descripcion")
            txttipoproducto.Text = reader.Item("tipoproducto")
            btnactualizar.Enabled = True
            btnguardar.Enabled = False
        Else
            limpiar()



            If MsgBox("Este producto no esta registrado en la base de datos, desea crearlo?", MsgBoxStyle.Information + vbYesNo) = vbYes Then
                btnguardar.Enabled = True
                btnactualizar.Enabled = False
            Else
                Return
            End If
        End If
        con.Close()
    End Sub

    Private Sub txtidproducto_TextChanged(sender As Object, e As EventArgs) Handles txtidproducto.TextChanged

    End Sub
End Class