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
            Destroy(gameObject); // Prevent duplicate instances
            return;
        }

        DontDestroyOnLoad(gameObject); // Keep across scenes if needed
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddKill(int points)
    {
        score += points; // Increments score by 1 per enemy kill
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Zombies Killed: " + score;
        }
    }
}
