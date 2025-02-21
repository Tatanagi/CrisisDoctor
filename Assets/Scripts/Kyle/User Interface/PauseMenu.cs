using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public Button pauseButton;
    public GameObject pauseUI;
    public GameObject crosshair; // Assign in Inspector

    void Start()
    {
        pauseButton.onClick.AddListener(TogglePause);
    }

    void Update()
    {
        // Check if P key is pressed to toggle pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        bool isMouseOverPauseUI = pauseUI != null && RectTransformUtility.RectangleContainsScreenPoint(
            pauseUI.GetComponent<RectTransform>(), Input.mousePosition);

        // Show mouse cursor when hovering over pause UI or when paused
        Cursor.visible = isMouseOverPauseUI || isPaused;

        // Hide crosshair when paused
        if (crosshair != null)
        {
            crosshair.SetActive(!isPaused);
        }

        // Disable shooting if hovering over pause UI
        if (isMouseOverPauseUI || isPaused)
        {
            DisableShooting();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        Debug.Log("Pause button clicked. Game is " + (isPaused ? "paused" : "resumed"));
    }

    void DisableShooting()
    {
        // Assuming a PlayerShoot script exists that handles shooting
        PlayerShoot playerShoot = FindObjectOfType<PlayerShoot>();
        if (playerShoot != null)
        {
            playerShoot.enabled = !isPaused; // Disable when paused, enable when unpaused
        }
    }
}
