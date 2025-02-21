using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public void BackToTitle()
    {
        Debug.Log("BackToTitle() called"); // Check if the function is called
        if (Application.CanStreamedLevelBeLoaded("TitleScreen"))
        {
            SceneManager.LoadScene("TitleScreen");
        }
        else
        {
            Debug.LogError("Scene 'TitleScreen' not found! Make sure it is added in Build Settings.");
        }
    }
}
