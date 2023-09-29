using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    public void CreateUser(string userName, string edad, string pass, Action<Response> response)
    {
        StartCoroutine(CO_CreateUser(userName, edad, pass, response));
    }

    private IEnumerator CO_CreateUser(string userName, string edad, string pass, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", userName);
        form.AddField("edad", edad);
        form.AddField("pass", pass);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/Game/createUser.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            response.Invoke(JsonUtility.FromJson<Response>(www.downloadHandler.text));
        }
        else
        {
            Debug.Log("Error al enviar la solicitud: " + www.error);
        }
 
    }

    public void  CheckUser(string userName, string pass, Action<Response> response)
    {
        StartCoroutine(CO_CheckUser(userName, pass, response));
    }

    private IEnumerator CO_CheckUser(string userName, string pass, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", userName);
        form.AddField("pass", pass);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/Game/checkUser.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            response.Invoke(JsonUtility.FromJson<Response>(www.downloadHandler.text));
        }
        else
        {
            Debug.Log("Error al enviar la solicitud: " + www.error);
        }
    }

}
[Serializable]
public class Response
{
    public bool done = false;
    public string message = "";
}






