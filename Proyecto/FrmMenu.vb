Public Class FrmMenu

    Private Sub ReiniciarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReiniciarToolStripMenuItem.Click
        Application.Restart()
    End Sub

    Private Sub SalirToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem1.Click
        Application.Exit()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)

        FrmEmpleados.ShowDialog()
    End Sub

    Private Sub SucToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SucToolStripMenuItem.Click

        Frmsucursal.ShowDialog()
    End Sub

    Private Sub RegistroEmpleadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroEmpleadosToolStripMenuItem.Click

        FrmEmpleados.ShowDialog()
    End Sub

    Private Sub RegistroProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroProductosToolStripMenuItem.Click

        FrmProductos.ShowDialog()
    End Sub

    Private Sub EmpleadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpleadosToolStripMenuItem.Click

        FrmReporteEmpleados.ShowDialog()
    End Sub

    Private Sub ProductosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem1.Click

        FrmReporteProductos.ShowDialog()
    End Sub
End Class