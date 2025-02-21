using UnityEngine;
using TMPro;

public class GameOverScore : MonoBehaviour
{
    public TextMeshProUGUI gameOverScoreText; // Assign in Inspector

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0); // Get saved score
        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = "Final Score: " + finalScore;
        }
    }
}
