using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Button exitButton;
    public Button closeButton;
    public Button achievementsButton;
    public Button restartButton;
    public GameObject achievementsPanel;
    public AudioManager audioManager;

    void Start()
    {
        // Find AudioManager in the scene
        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene.");
        }

        // Hide settings panel and achievements panel by default
        settingsPanel.SetActive(false);
        achievementsPanel.SetActive(false);

        // Bind button events
        exitButton.onClick.AddListener(ExitGame);
        closeButton.onClick.AddListener(CloseSettings);
        achievementsButton.onClick.AddListener(ShowAchievements);
        restartButton.onClick.AddListener(RestartLevel);
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    private void ExitGame()
    {
        DataManager dataManager = FindObjectOfType<DataManager>();
        dataManager.ResetAchievements("Start");
        SceneManager.LoadScene("Start");
    }

    private void ShowAchievements()
    {
        achievementsPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        DataManager dataManager = FindObjectOfType<DataManager>();
        if (dataManager != null)
        {
            dataManager.ResetAchievements(SceneManager.GetActiveScene().name);
            Debug.LogWarning("ResetAchievements");
        }
        else
        {
            Debug.LogError("DataManager component not found in the scene.");
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
