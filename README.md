
# Membuat Menu Panel

Proyek ini merupakan aplikasi sederhana yang menggunakan MenuStrip sebagai navigasi utama, memungkinkan pengguna untuk berpindah antara form yang berbeda dalam aplikasi. Setiap form memiliki fungsionalitas tertentu yang dapat digunakan untuk mengelola data.

## Fitur Utama
- **MenuStrip Navigation:** MenuStrip mempermudah navigasi antar form dalam aplikasi ini.
- **Data Siswa Management:** Aplikasi ini menyimpan dan mengelola data siswa yang tersimpan di dalam database `Data Siswa.mdb`.
  
## Pengaturan Awal
Sebelum menjalankan aplikasi, pastikan untuk mengatur *data source* pada Form Data Siswa dan Form Menu agar sesuai dengan lokasi database `Data Siswa.mdb` di komputer Anda. Lokasi *data source* saat ini disetel sebagai berikut:

```plaintext
Data Source=D:\Campus\Semester V\Kecerdasan Komputasi\Membuat Menu Panel\database\Data Siswa.mdb;
```

### Langkah-langkah Menyesuaikan Data Source
1. Buka file `Form Data Siswa` dan `Form Menu` dalam proyek ini.
2. Cari *connection string* yang berisi lokasi *data source* di kedua form tersebut.
3. Ganti jalur di `Data Source` agar sesuai dengan lokasi tempat Anda menyimpan file `Data Siswa.mdb`. Contoh:

    ```plaintext
    Data Source=C:\path\to\your\project\database\Data Siswa.mdb;
    ```

   **Catatan:** Jika jalur *data source* tidak sesuai, data dari database tidak akan muncul di GridView dan Anda tidak akan dapat menyimpan atau mengubah data yang ada.

## Penggunaan
1. Setelah *data source* diatur, jalankan aplikasi.
2. Gunakan MenuStrip di bagian atas untuk memilih dan membuka form yang diinginkan.
3. Pada Form Data Siswa, Anda dapat menambahkan, menyimpan, atau mengedit data siswa yang tersimpan di database.

---

Jika Anda memerlukan bantuan lebih lanjut terkait konfigurasi atau penggunaan aplikasi, silakan cek dokumentasi pada direktori proyek atau buka masalah (issue) di repositori ini.
