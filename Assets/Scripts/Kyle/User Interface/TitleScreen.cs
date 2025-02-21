using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreen : MonoBehaviour
{
    public GameObject Title, Story, Settings;
    public void LoadGame()
    {
        SceneManager.LoadScene("Master");
    }
    public void QuitApplication()
    {
        Application.Quit();
    }

    public void StoryButton()
    {
        Title.SetActive(false);
        Story.SetActive(true);
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene("Options");
    }
}
