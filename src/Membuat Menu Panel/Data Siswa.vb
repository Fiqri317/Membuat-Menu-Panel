Imports System
Imports System.Data
Imports System.Data.OleDb

Public Class Data_Siswa
    Dim _koneksiString As String
    Dim _koneksi As New OleDbConnection
    Dim komandambil As New OleDbCommand
    Dim datatabelku As New DataTable
    Dim dataadapterku As New OleDbDataAdapter
    Dim x As String

    Private Sub dgv_coba_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles dgv_coba.CellFormatting
        If dgv_coba.Columns(e.ColumnIndex).Name = "Tanggal Lahir" Then
            If e.Value IsNot Nothing Then
                Dim tgl As DateTime = Convert.ToDateTime(e.Value)
                e.Value = tgl.ToString("dd MMMM yyyy", New System.Globalization.CultureInfo("id-ID"))
                e.FormattingApplied = True
            End If
        End If
    End Sub

    Private Sub Data_Siswa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _koneksiString = "Provider=Microsoft.Jet.OleDb.4.0;" + "Data Source=D:\Campus\Semester V\Kecerdasan Komputasi\Membuat Menu Panel\database\Data Siswa.mdb;"
        _koneksi.ConnectionString = _koneksiString
        _koneksi.Open()

        komandambil.Connection = _koneksi
        komandambil.CommandType = CommandType.Text

        komandambil.CommandText = "SELECT * FROM Siswa"
        dataadapterku.SelectCommand = komandambil
        dataadapterku.Fill(datatabelku)
        Bs_Coba.DataSource = datatabelku
        dgv_coba.DataSource = Bs_Coba
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cmdTambah As New OleDbCommand
        Dim tanya As String
        Dim x As DataRow
        cmdTambah.Connection = _koneksi

        Dim tingkatPendidikan As String = ComboBox1.Text
        Dim jurusan As String = If(RadioButton3.Checked, "IPA", "IPS")
        Dim tingkatPendidikanJurusan As String = tingkatPendidikan + " " + jurusan

        cmdTambah.CommandText = "INSERT INTO " + "Siswa ([No Induk Siswa], [Nama Lengkap], Alamat, [Jenis Kelamin], [Tanggal Lahir], [No Telepon/HP], [Tingkat Pendidikan])" +
            "VALUES ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" +
            If(RadioButton1.Checked, "Laki-Laki", "Perempuan") + "','" + DateTimePicker1.Text + "','" +
            TextBox4.Text + "','" + tingkatPendidikanJurusan + " ')"
        tanya = MessageBox.Show("Data Ini di Simpan ?", "info", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If tanya = vbYes Then
            cmdTambah.ExecuteNonQuery()
            x = datatabelku.NewRow
            x("No Induk Siswa") = TextBox1.Text
            x("Nama Lengkap") = TextBox2.Text
            x("Alamat") = TextBox3.Text
            x("Jenis Kelamin") = If(RadioButton1.Checked, "Laki-Laki", "Perempuan")
            x("Tanggal Lahir") = DateTimePicker1.Text
            x("No Telepon/HP") = TextBox4.Text
            x("Tingkat Pendidikan") = tingkatPendidikanJurusan
            datatabelku.Rows.Add(x)
            Bs_Coba.DataSource = Nothing
            Bs_Coba.DataSource = datatabelku

            dgv_coba.Refresh()
            Bs_Coba.MoveFirst()
        End If
    End Sub

    Private Sub dgv_coba_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_coba.CellContentClick
        TextBox1.Text = dgv_coba.CurrentRow.Cells(0).Value.ToString()
        TextBox2.Text = dgv_coba.CurrentRow.Cells(1).Value.ToString()
        TextBox3.Text = dgv_coba.CurrentRow.Cells(2).Value.ToString()

        Dim jenisKelamin As String = dgv_coba.CurrentRow.Cells(3).Value.ToString()
        RadioButton1.Checked = (jenisKelamin = "Laki-Laki")
        RadioButton2.Checked = (jenisKelamin = "Perempuan")

        DateTimePicker1.Value = Convert.ToDateTime(dgv_coba.CurrentRow.Cells(4).Value)
        TextBox4.Text = dgv_coba.CurrentRow.Cells(5).Value.ToString()

        Dim tingkatPendidikanJurusan As String = dgv_coba.CurrentRow.Cells(6).Value.ToString()
        Dim parts As String() = tingkatPendidikanJurusan.Split(" "c)
        If parts.Length >= 3 Then
            ComboBox1.Text = parts(0) + " " + parts(1)
            If parts(2).Equals("IPA", StringComparison.OrdinalIgnoreCase) Then
                RadioButton3.Checked = True ' IPA
                RadioButton4.Checked = False ' IPS
            Else
                RadioButton3.Checked = False ' IPA
                RadioButton4.Checked = True ' IPS
            End If
        End If
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cmdUpdate As New OleDbCommand
        cmdUpdate.Connection = _koneksi

        Dim tingkatPendidikan As String = ComboBox1.Text
        Dim jurusan As String = If(RadioButton3.Checked, "IPA", "IPS")
        Dim tingkatPendidikanJurusan As String = tingkatPendidikan + " " + jurusan

        cmdUpdate.CommandType = CommandType.Text
        Dim x = MessageBox.Show("Yakin Data Ingin di Perbarui?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = vbYes Then
            cmdUpdate.CommandText = "UPDATE Siswa SET " +
                "[Nama Lengkap] = '" + TextBox2.Text + "', " +
                "Alamat = '" + TextBox3.Text + "', " +
                "[Jenis Kelamin] = '" + If(RadioButton1.Checked, "Laki-Laki", "Perempuan") + "', " +
                "[Tanggal Lahir] = '" + DateTimePicker1.Text + "', " +
                "[No Telepon/HP] = '" + TextBox4.Text + "', " +
                "[Tingkat Pendidikan] = '" + tingkatPendidikanJurusan + "' " +
                "WHERE [No Induk Siswa] = " + TextBox1.Text
            cmdUpdate.ExecuteNonQuery()

            Dim rowToUpdate As DataRow = datatabelku.Select("[No Induk Siswa] = " + TextBox1.Text).FirstOrDefault()
            If rowToUpdate IsNot Nothing Then
                rowToUpdate("No Induk Siswa") = TextBox1.Text
                rowToUpdate("Nama Lengkap") = TextBox2.Text
                rowToUpdate("Alamat") = TextBox3.Text
                rowToUpdate("Jenis Kelamin") = If(RadioButton1.Checked, "Laki-Laki", "Perempuan")
                rowToUpdate("Tanggal Lahir") = DateTimePicker1.Text
                rowToUpdate("No Telepon/HP") = TextBox4.Text
                rowToUpdate("Tingkat Pendidikan") = tingkatPendidikanJurusan
            End If

            Bs_Coba.DataSource = Nothing
            Bs_Coba.DataSource = datatabelku
            dgv_coba.Refresh()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim cmdHapus As New OleDbCommand
        cmdHapus.Connection = _koneksi
        cmdHapus.CommandType = CommandType.Text
        x = MessageBox.Show("Yakin Data Akan di Hapus ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = vbYes Then
            cmdHapus.CommandText = "DELETE FROM " + "Siswa WHERE [No Induk Siswa]=" + TextBox1.Text
            cmdHapus.ExecuteNonQuery()
        End If
        Bs_Coba.RemoveCurrent()
        dgv_coba.Refresh()

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        DateTimePicker1.Value = DateTime.Now
        TextBox4.Clear()
        ComboBox1.SelectedIndex = -1
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        TextBox1.Focus()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        DateTimePicker1.Value = DateTime.Now
        TextBox4.Clear()
        ComboBox1.SelectedIndex = -1
        RadioButton3.Checked = False
        RadioButton4.Checked = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        datatabelku.Clear()
        komandambil.Connection = _koneksi
        komandambil.CommandType = CommandType.Text
        komandambil.CommandText = "SELECT * FROM " + "Siswa WHERE [No Induk Siswa] LIKE '%" + TextBox1.Text + "%'"

        dataadapterku.SelectCommand = komandambil
        dataadapterku.Fill(datatabelku)

        dgv_coba.Refresh()
        Bs_Coba.DataSource = datatabelku
        dgv_coba.DataSource = Bs_Coba
        Bs_Coba.MoveFirst()
    End Sub
End Class