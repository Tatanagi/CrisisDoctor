using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class PlayerLevel : MonoBehaviour
{
    public int level = 1;
    public int currentExp = 0;
    public int expToNextLevel = 100;
    public int maxHealth = 100;
    public int currentHealth;
    public ExpBar expBar;
    public HealthBar healthBar;
    public TMP_Text levelText; // Changed from Text to TMP_Text
    public PlayerHealth playerHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        expBar.SetMaxExp(expToNextLevel);
        UpdateLevelText();
    }

    public void GainExp(int amount)
    {
        currentExp += amount;
        expBar.SetExp(currentExp);

        if (currentExp >= expToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        currentExp -= expToNextLevel;
        expToNextLevel += 50; // Increase required exp for next level
        maxHealth += 20; // Increase max health on level up
        currentHealth = maxHealth; // Restore health on level up

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        expBar.SetMaxExp(expToNextLevel);
        expBar.SetExp(currentExp);
        UpdateLevelText();

        if (playerHealth != null)
        {
            playerHealth.IncreaseMaxHealth(20); // Increase PlayerHealth max health
        }
    }

    void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + level;
        }
    }
}
