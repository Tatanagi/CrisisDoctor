using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Master");
    }
    public void TitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
