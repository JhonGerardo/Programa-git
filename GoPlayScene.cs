using UnityEngine;
using UnityEngine.SceneManagement;


public class GoPlayScene: MonoBehaviour
{
    public void LoadGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Juego");

    }
}
