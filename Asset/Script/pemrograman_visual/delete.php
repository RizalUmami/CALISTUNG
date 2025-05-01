<?php
include 'db_connection.php';

$id = $_POST['id'];

$sql = "DELETE FROM siswa WHERE id=$id";

if ($conn->query($sql) === TRUE) {
    echo json_encode(array("status" => "success", "message" => "Data berhasil dihapus"));
} else {
    echo json_encode(array("status" => "error", "message" => "Terjadi kesalahan: " . $conn->error));
}

$conn->close();
?>
