<?php
include 'db_connection.php';

$id = $_POST['id'];
$nama = $_POST['nama'];
$email = $_POST['email'];
$namapanggilan = $_POST['namapanggilan'];
$asalsekolah = $_POST['asalsekolah'];
$gender = $_POST['gender'];

$stmt = $conn->prepare("UPDATE siswa SET nama=?, email=?, namapanggilan=?, asalsekolah=?, gender=? WHERE id=?");
$stmt->bind_param("sssssi", $nama, $email, $namapanggilan, $asalsekolah, $gender, $id);

if ($stmt->execute()) {
    echo json_encode(["status" => "success", "message" => "Data berhasil diperbarui"]);
} else {
    echo json_encode(["status" => "error", "message" => "Terjadi kesalahan: " . $stmt->error]);
}

$stmt->close();
$conn->close();
?>
