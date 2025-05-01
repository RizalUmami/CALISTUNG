<?php
include 'db_connection.php';

$nama = $_POST['nama'];
$email = $_POST['email'];
$namapanggilan = $_POST['namapanggilan'];
$asalsekolah = $_POST['asalsekolah'];
$gender = $_POST['gender'];

$sql = "INSERT INTO siswa (nama, email, namapanggilan, asalsekolah, gender) 
        VALUES ('$nama', '$email', '$namapanggilan', '$asalsekolah', '$gender')";

if ($conn->query($sql) === TRUE) {
    echo json_encode(array("status" => "success", "message" => "Data berhasil ditambahkan"));
} else {
    echo json_encode(array("status" => "error", "message" => "Terjadi kesalahan: " . $conn->error));
}

$conn->close();
?>
