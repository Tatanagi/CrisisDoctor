using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Toggle soundToggle; // Assign this in the Inspector if using UI Toggle
    private static bool isMuted = false;

    void Start()
    {
        // Load the saved sound preference
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        ApplySoundSetting();

        // If there's a UI toggle, update its state
        if (soundToggle != null)
        {
            soundToggle.isOn = !isMuted;
            soundToggle.onValueChanged.AddListener(ToggleSound);
        }
    }

    public void ToggleSound(bool enabled)
    {
        isMuted = !enabled;
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
        ApplySoundSetting();
    }

    private void ApplySoundSetting()
    {
        AudioListener.volume = isMuted ? 0 : 1;
    }
}
