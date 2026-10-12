using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Singleton instance
    public static DataManager instance;

    // Audio settings
    public float bgmVolume = 1.0f;
    public float seVolume = 1.0f;
    public bool isBgmMuted = false;
    public bool isSeMuted = false;

    // Achievement statuses
    public bool isAchievement1Unlocked = false;
    public bool isAchievement2Unlocked = false;
    public bool isAchievement3Unlocked = false;
    public bool isAchievement4Unlocked = false;

    void Awake()
    {
        // Implement the Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Saves the audio settings.
    /// </summary>
    /// <param name="bgmVolume">The volume of the background music.</param>
    /// <param name="seVolume">The volume of the sound effects.</param>
    /// <param name="isBgmMuted">Whether the background music is muted.</param>
    /// <param name="isSeMuted">Whether the sound effects are muted.</param>
    public void SaveAudioSettings(float bgmVolume, float seVolume, bool isBgmMuted, bool isSeMuted)
    {
        this.bgmVolume = bgmVolume;
        this.seVolume = seVolume;
        this.isBgmMuted = isBgmMuted;
        this.isSeMuted = isSeMuted;
    }

    /// <summary>
    /// Saves the achievement statuses.
    /// </summary>
    /// <param name="ach1">Whether achievement 1 is unlocked.</param>
    /// <param name="ach2">Whether achievement 2 is unlocked.</param>
    /// <param name="ach3">Whether achievement 3 is unlocked.</param>
    /// <param name="ach4">Whether achievement 4 is unlocked.</param>
    public void SaveAchievementStatus(bool ach1, bool ach2, bool ach3, bool ach4)
    {
        isAchievement1Unlocked = ach1;
        isAchievement2Unlocked = ach2;
        isAchievement3Unlocked = ach3;
        isAchievement4Unlocked = ach4;
    }

    /// <summary>
    /// Checks if all achievements are unlocked.
    /// </summary>
    /// <returns>True if all achievements are unlocked, otherwise false.</returns>
    public bool AllAchievementsUnlocked()
    {
        return isAchievement1Unlocked && isAchievement2Unlocked && isAchievement3Unlocked && isAchievement4Unlocked;
    }
    public void ResetAchievements(string sceneName)
    {
        if (sceneName == "LA5")
        {
            isAchievement1Unlocked = false;
        }
        if (sceneName == "Cal")
        {
            isAchievement2Unlocked = false;
        }
        if (sceneName == "Discrete")
        {
            isAchievement3Unlocked = false;
        }
        if (sceneName == "programming2")
        {
            isAchievement4Unlocked = false;
        }
        if (sceneName == "Start")
        {
            isAchievement1Unlocked = false;
            isAchievement2Unlocked = false;
            isAchievement3Unlocked = false;
            isAchievement4Unlocked = false;
        }
    }
}
