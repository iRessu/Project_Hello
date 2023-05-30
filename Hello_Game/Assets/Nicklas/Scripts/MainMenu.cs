using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Start()
    {
        Cursor.visible = true;
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("GameClosed");
    }

    public void SecretButton()
    {
        SceneManager.LoadScene("Secret");
    }
}
