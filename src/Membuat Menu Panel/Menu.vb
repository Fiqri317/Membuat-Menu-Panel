Imports System.Data.OleDb
Imports Aplikasi_Database_Mahasiswa
Imports Aplikasi_Apotek
Imports Aplikasi_Langganan_Anime
Imports Aplikasi_Hotel

Public Class Menu
    Private Sub MahasiswaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MahasiswaToolStripMenuItem.Click
        Dim formMahasiswa As New Aplikasi_Database_Mahasiswa.Form1
        formMahasiswa.Show()
    End Sub

    Private Sub ApotekToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApotekToolStripMenuItem.Click
        Dim formApotek As New Aplikasi_Apotek.Form1
        formApotek.Show()
    End Sub

    Private Sub FilmAnimeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilmAnimeToolStripMenuItem.Click
        Dim formAnime As New Aplikasi_Langganan_Anime.Form1
        formAnime.Show()
    End Sub

    Private Sub HotelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HotelToolStripMenuItem.Click
        Dim formHotel As New Aplikasi_Hotel.Hotel
        formHotel.Show()
    End Sub

    Private Sub SiswaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SiswaToolStripMenuItem.Click
        Data_Siswa.Show()
    End Sub

    Private Sub MahasiswaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MahasiswaToolStripMenuItem1.Click
        Dim Data As New Data()
        Data.Label1.Text = "Data Aplikasi Database Mahasiswa"
        Dim _koneksiString As String = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=D:\Campus\Semester V\Kecerdasan Komputasi\Aplikasi Database Mahasiswa\database\Mahasiswa.mdb;"
        Dim _koneksi As New OleDbConnection(_koneksiString)
        Dim komandambil As New OleDbCommand()
        Dim dataadapterku As New OleDbDataAdapter()
        Dim datatabelku As New DataTable()
        _koneksi.Open()
        komandambil.Connection = _koneksi
        komandambil.CommandType = CommandType.Text
        komandambil.CommandText = "SELECT * FROM TMhs"
        dataadapterku.SelectCommand = komandambil
        dataadapterku.Fill(datatabelku)
        Data.DataGridView1.DataSource = datatabelku

        Data.Show()
    End Sub

    Private Sub ApotekToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApotekToolStripMenuItem1.Click
        Dim Data As New Data()
        Data.Label1.Text = "Data Aplikasi Apotek"
        Dim _koneksiString As String = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=D:\Campus\Semester V\Kecerdasan Komputasi\Aplikasi Apotek\database\Aplikasi Apotek.mdb;"
        Dim _koneksi As New OleDbConnection(_koneksiString)
        Dim komandambil As New OleDbCommand()
        Dim dataadapterku As New OleDbDataAdapter()
        Dim datatabelku As New DataTable()
        _koneksi.Open()
        komandambil.Connection = _koneksi
        komandambil.CommandType = CommandType.Text
        komandambil.CommandText = "SELECT * FROM Pegawai"
        dataadapterku.SelectCommand = komandambil
        dataadapterku.Fill(datatabelku)
        Data.DataGridView1.DataSource = datatabelku

        Data.Show()
    End Sub

    Private Sub FilmAnimeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilmAnimeToolStripMenuItem1.Click
        Dim Data As New Data()
        Data.Label1.Text = "Data Aplikasi Langganan Film"
        Dim _koneksiString As String = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=D:\Campus\Semester V\Kecerdasan Komputasi\Aplikasi Langganan Film\database\Langganan.mdb;"
        Dim _koneksi As New OleDbConnection(_koneksiString)
        Dim komandambil As New OleDbCommand()
        Dim dataadapterku As New OleDbDataAdapter()
        Dim datatabelku As New DataTable()
        _koneksi.Open()
        komandambil.Connection = _koneksi
        komandambil.CommandType = CommandType.Text
        komandambil.CommandText = "SELECT * FROM Pengguna"
        dataadapterku.SelectCommand = komandambil
        dataadapterku.Fill(datatabelku)
        Data.DataGridView1.DataSource = datatabelku

        Data.Show()
    End Sub

    Private Sub HotelToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HotelToolStripMenuItem1.Click
        Dim Data As New Data()
        Data.Label1.Text = "Data Aplikasi Hotel"
        Dim _koneksiString As String = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=D:\Campus\Semester V\Kecerdasan Komputasi\Aplikasi Hotel\database\Hotel.mdb;"
        Dim _koneksi As New OleDbConnection(_koneksiString)
        Dim komandambil As New OleDbCommand()
        Dim dataadapterku As New OleDbDataAdapter()
        Dim datatabelku As New DataTable()
        _koneksi.Open()
        komandambil.Connection = _koneksi
        komandambil.CommandType = CommandType.Text
        komandambil.CommandText = "SELECT * FROM Hotel"
        dataadapterku.SelectCommand = komandambil
        dataadapterku.Fill(datatabelku)
        Data.DataGridView1.DataSource = datatabelku

        Data.Show()
    End Sub

    Private Sub SiswaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SiswaToolStripMenuItem1.Click
        Dim Data As New Data()
        Data.Label1.Text = "Data Aplikasi Data Siswa"
        Dim _koneksiString As String = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=D:\Campus\Semester V\Kecerdasan Komputasi\Membuat Menu Panel\database\Data Siswa.mdb;"
        Dim _koneksi As New OleDbConnection(_koneksiString)
        Dim komandambil As New OleDbCommand()
        Dim dataadapterku As New OleDbDataAdapter()
        Dim datatabelku As New DataTable()
        _koneksi.Open()
        komandambil.Connection = _koneksi
        komandambil.CommandType = CommandType.Text
        komandambil.CommandText = "SELECT * FROM Siswa"
        dataadapterku.SelectCommand = komandambil
        dataadapterku.Fill(datatabelku)
        Data.DataGridView1.DataSource = datatabelku

        Data.Show()
    End Sub

    Private Sub BackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackToolStripMenuItem.Click
        Me.Close()
        Login.Show()
        Login.TextBox1.Clear()
        Login.TextBox2.Clear()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub
End Class