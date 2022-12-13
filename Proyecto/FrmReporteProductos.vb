
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class FrmReporteProductos
    Private Sub FrmReporteProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Using con As New SqlConnection(My.Settings.proyecto)
            con.Open()
            Dim cmd As New SqlCommand("sp_ReporteProductos", con)
            cmd.CommandType = CommandType.StoredProcedure
            'cmd.Parameters.AddWithValue("",valor)
            cmd.CommandTimeout = 600
            Dim ta As New SqlDataAdapter(cmd)
            ta.Fill(dt)
        End Using

        With Me.ReportViewer1.LocalReport
            .DataSources.Clear() 'Limpiar origenes de datos previos.
            .ReportEmbeddedResource = "Proyecto.RptReporteProductos.rdlc" 'asignar el reporte.
            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetProductos", dt)) 'Asignar origen de datos.
        End With
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.Percent = 100
    End Sub
End Class