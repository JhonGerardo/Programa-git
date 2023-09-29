<?php

include "dbConnection.php";

$userName = $_POST['userName'];
$edad = $_POST['edad'];
$pass = hash("sha256", $_POST['pass']);

$sql = "SELECT userName FROM usuarios WHERE userName = '$userName'";
$result = $pdo->query($sql);

if ($result->rowCount() > 0) {
    $data = array('done' => false, 'message' => "Error, el nombre de Usuario ya existe");
    echo json_encode($data);
    exit();
} else {
    $sql = "INSERT INTO usuarios SET userName = '$userName', edad = '$edad', pass = '$pass'";
    $pdo->query($sql);

    $data = array('done' => true, 'message' => "Nuevo Usuario Registrado");
    echo json_encode($data);
    exit();
}
?>
