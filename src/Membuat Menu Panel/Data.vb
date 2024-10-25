Public Class Data
    Private Sub dgv_coba_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.Columns(e.ColumnIndex).Name = "Tanggal Checkin" Then
            If e.Value IsNot Nothing Then
                Dim tgl As DateTime = Convert.ToDateTime(e.Value)
                e.Value = tgl.ToString("dd MMMM yyyy", New System.Globalization.CultureInfo("id-ID"))
                e.FormattingApplied = True
            End If
        End If

        If DataGridView1.Columns(e.ColumnIndex).Name = "Tanggal Checkout" Then
            If e.Value IsNot Nothing Then
                Dim tgl As DateTime = Convert.ToDateTime(e.Value)
                e.Value = tgl.ToString("dd MMMM yyyy", New System.Globalization.CultureInfo("id-ID"))
                e.FormattingApplied = True
            End If
        End If

        If DataGridView1.Columns(e.ColumnIndex).Name = "Tanggal Lahir" Then
            If e.Value IsNot Nothing Then
                Dim tgl As DateTime = Convert.ToDateTime(e.Value)
                e.Value = tgl.ToString("dd MMMM yyyy", New System.Globalization.CultureInfo("id-ID"))
                e.FormattingApplied = True
            End If
        End If
    End Sub
End Class