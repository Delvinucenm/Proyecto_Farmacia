Public Class FrmEmpleados
    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click

        Close()
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        If txtnumempleado.Text = "" Or txtnombres.Text = "" Or txtapellidos.Text = "" Or txtdni.Text = "" Or txtdireccion.Text = "" Or txtcargo.Text = "" Or txtnivelacademico.Text = "" Then
            MessageBox.Show("Debe llenar todos los campos")
        Else
            Dim con As SqlClient.SqlConnection = New SqlClient.SqlConnection(My.Settings.proyecto)
            Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("sp_Empleados", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@bandera", 1)
            cmd.Parameters.AddWithValue("@numempleado", txtnumempleado.Text)
            cmd.Parameters.AddWithValue("@dni", txtdni.Text)
            cmd.Parameters.AddWithValue("@nombres", txtnombres.Text)
            cmd.Parameters.AddWithValue("@apellidos", txtapellidos.Text)
            cmd.Parameters.AddWithValue("@telefono", txttelefono.Text)
            cmd.Parameters.AddWithValue("@correo", txtcorreo.Text)
            cmd.Parameters.AddWithValue("@direccion", txtdireccion.Text)
            cmd.Parameters.AddWithValue("@cargo", txtcargo.Text)
            cmd.Parameters.AddWithValue("@sexo", cmbsexo.SelectedValue)
            cmd.Parameters.AddWithValue("@estadocivil", cmbestadocivil.SelectedValue)
            cmd.Parameters.AddWithValue("@nivelacademico", txtnivelacademico.Text)
            cmd.Parameters.AddWithValue("@fechanacimiento", dtpfechannac.Value)
            Dim activo As Boolean
            If ckactivo.Checked = True Then
                activo = 1
            Else
                activo = 0
            End If
            cmd.Parameters.AddWithValue("@activo", activo)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Empleado guardado correctamente", "Proyecto RAD")
            limpiar_controles()
            con.Close()
        End If
    End Sub

    Private Sub FrmEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarcombosexo()
        llenarcomboestadocivil()
    End Sub

    Sub llenarcombosexo()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim dt As New DataTable
        Dim con As New SqlClient.SqlConnection(My.Settings.proyecto)
        Try
            da = New SqlClient.SqlDataAdapter("SELECT sexo, descripcion FROM listadosexo", con)
            da.Fill(dt)
            cmbsexo.DataSource = dt
            cmbsexo.DisplayMember = "descripcion"
            cmbsexo.ValueMember = "sexo"
        Catch ex As Exception
        End Try
    End Sub

    Sub llenarcomboestadocivil()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim dt As New DataTable
        Dim con As New SqlClient.SqlConnection(My.Settings.proyecto)
        Try
            da = New SqlClient.SqlDataAdapter("select idestadocivil, descriestadocivil from listadoEstadoCivil", con)
            da.Fill(dt)
            cmbestadocivil.DataSource = dt
            cmbestadocivil.DisplayMember = "descriestadocivil"
            cmbestadocivil.ValueMember = "idestadocivil"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnactualizar_Click(sender As Object, e As EventArgs) Handles btnactualizar.Click
        If txtnumempleado.Text = "" Or txtnombres.Text = "" Or txtapellidos.Text = "" Or txtdni.Text = "" Or txtdireccion.Text = "" Or txtcargo.Text = "" Or txtnivelacademico.Text = "" Then
            MessageBox.Show("Debe llenar todos los campos")
        Else
            Dim con As SqlClient.SqlConnection = New SqlClient.SqlConnection(My.Settings.proyecto)
            Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("sp_Empleados", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@bandera", 2)
            cmd.Parameters.AddWithValue("@numempleado", txtnumempleado.Text)
            cmd.Parameters.AddWithValue("@dni", txtdni.Text)
            cmd.Parameters.AddWithValue("@nombres", txtnombres.Text)
            cmd.Parameters.AddWithValue("@apellidos", txtapellidos.Text)
            cmd.Parameters.AddWithValue("@telefono", txttelefono.Text)
            cmd.Parameters.AddWithValue("@correo", txtcorreo.Text)
            cmd.Parameters.AddWithValue("@direccion", txtdireccion.Text)
            cmd.Parameters.AddWithValue("@cargo", txtcargo.Text)
            cmd.Parameters.AddWithValue("@sexo", cmbsexo.SelectedValue)
            cmd.Parameters.AddWithValue("@estadocivil", cmbestadocivil.SelectedValue)
            cmd.Parameters.AddWithValue("@nivelacademico", txtnivelacademico.Text)
            cmd.Parameters.AddWithValue("@fechanacimiento", dtpfechannac.Value)
            Dim activo As Boolean
            If ckactivo.Checked = True Then
                activo = 1
            Else
                activo = 0
            End If
            cmd.Parameters.AddWithValue("@activo", activo)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Empleado actualizado correctamente", "Programacion Rad")
            limpiar_controles()
            con.Close()
        End If
    End Sub
    Sub limpiar_controles()
        txtdni.Text = ""
        txtnombres.Text = ""
        txtapellidos.Text = ""

        dtpfechannac.Value = System.DateTime.Today

        txttelefono.Text = ""
        txtcorreo.Text = ""
        txtnivelacademico.Text = ""
        txtdireccion.Text = ""
        txtcargo.Text = ""

        llenarcombosexo()
        llenarcomboestadocivil()

        ckactivo.Checked = False
        btnactualizar.Enabled = False
        btnguardar.Enabled = False
        txtnumempleado.Text = ""
        txtnumempleado.Focus()
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        limpiar_controles()
    End Sub

    Private Sub btncheck_Click(sender As Object, e As EventArgs) Handles btncheck.Click
        Dim con As New SqlClient.SqlConnection(My.Settings.proyecto)
        con.Open()
        Dim reader As SqlClient.SqlDataReader
        Dim cmd As New SqlClient.SqlCommand("SELECT * FROM Empleados WHERE numempleado = '" & txtnumempleado.Text & "'", con)
        reader = cmd.ExecuteReader

        If reader.Read() Then
            txtdni.Text = reader.Item("dni")
            txtnombres.Text = reader.Item("nombres")
            txtapellidos.Text = reader.Item("apellidos")
            dtpfechannac.Value = reader.Item("fechanacimiento")
            cmbsexo.SelectedValue = reader.Item("sexo")

            txttelefono.Text = reader.Item("telefono")
            txtcorreo.Text = reader.Item("correo")
            txtnivelacademico.Text = reader.Item("nivelacademico")
            txtdireccion.Text = reader.Item("direccion")
            txtcargo.Text = reader.Item("cargo")
            cmbestadocivil.SelectedValue = reader.Item("estadocivil")
            If reader.Item("activo") = True Then
                ckactivo.Checked = True
            Else
                ckactivo.Checked = False
            End If
            btnactualizar.Enabled = True
        Else
            limpiar_controles()

            If MsgBox("Este Empleado no esta registrado en la base de datos, desea crearlo?", MsgBoxStyle.Information + vbYesNo) = vbYes Then
                btnguardar.Enabled = True
            Else
                Return
            End If
        End If
        con.Close()
    End Sub
End Class