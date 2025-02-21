using UnityEngine;
using TMPro;

public class ScoreManagement : MonoBehaviour
{
    public static ScoreManagement instance;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // Keep across scenes
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddKill(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Zombies Killed: " + score;
        }
    }

    public void SaveScoreAndLoadGameOver()
    {
        PlayerPrefs.SetInt("FinalScore", score); // Save score
        PlayerPrefs.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene"); // Load game over scene
    }
}
