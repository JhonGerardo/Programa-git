<?php
include "dbConnection.php";

$userName = $_POST['userName'];
$pass = hash("sha256", $_POST['pass']);

$sql    ="SELECT userName  FROM usuarios WHERE userName = '$userName' AND pass = '$pass'";
$result = $pdo->query($sql);

if($result->rowCount()> 0)
{
  $data =array('done'=> true , 'message'=> "Bienbenido a esta gran aventura $userName");
  Header('Content-Type: application/json');
  echo json_encode($data);
  exit();
}

else
{
  
  $data = array('done'=> false, ´$messaje´=> "Error datos incorrectos");
  Header('Content-Type: application/json');
  echo json_encode($data);
  exit();
}
?>
