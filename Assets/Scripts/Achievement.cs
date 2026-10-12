using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public Image achievement1Image;
    public Image achievement2Image;
    public Image achievement3Image;
    public Image achievement4Image;

    private bool isAchievement1Unlocked = false;
    private bool isAchievement2Unlocked = false;
    private bool isAchievement3Unlocked = false;
    private bool isAchievement4Unlocked = false;

    public GameObject achievement1UnlockedImage;
    public GameObject achievement2UnlockedImage;
    public GameObject achievement3UnlockedImage;
    public GameObject achievement4UnlockedImage;

    public static bool allAchievementsUnlocked = false; // 将所有成就解锁状态设为静态变量

    void Start()
    {
        // Check if any of the achievement images are not assigned
        if (achievement1UnlockedImage == null || achievement2UnlockedImage == null ||
            achievement3UnlockedImage == null || achievement4UnlockedImage == null)
        {
            Debug.LogError("One or more achievement unlocked images are not assigned in the Inspector.");
            return;
        }

        // Proceed with the initialization
        achievement1UnlockedImage.SetActive(false);
        achievement2UnlockedImage.SetActive(false);
        achievement3UnlockedImage.SetActive(false);
        achievement4UnlockedImage.SetActive(false);

        // Load achievement statuses from DataManager if available
        if (DataManager.instance != null)
        {
            isAchievement1Unlocked = DataManager.instance.isAchievement1Unlocked;
            isAchievement2Unlocked = DataManager.instance.isAchievement2Unlocked;
            isAchievement3Unlocked = DataManager.instance.isAchievement3Unlocked;
            isAchievement4Unlocked = DataManager.instance.isAchievement4Unlocked;
            UpdatePhoto();
        }
    }


    void UpdatePhoto()
    {
        if (isAchievement1Unlocked)
        {
            achievement1UnlockedImage.SetActive(true);
        }
        if (isAchievement2Unlocked)
        {
            achievement2UnlockedImage.SetActive(true);
        }
        if (isAchievement3Unlocked)
        {
            achievement3UnlockedImage.SetActive(true);
        }
        if (isAchievement4Unlocked)
        {
            achievement4UnlockedImage.SetActive(true);
        }

        if (isAchievement1Unlocked && isAchievement2Unlocked && isAchievement3Unlocked && isAchievement4Unlocked)
        {
            Complete();
            allAchievementsUnlocked = true; // 更新所有成就解锁状态为真
            DataManager.instance?.SaveAchievementStatus(true, true, true, true);
        }
    }

    public void UnlockAchievement1()
    {
        isAchievement1Unlocked = true;
        DataManager.instance?.SaveAchievementStatus(isAchievement1Unlocked, isAchievement2Unlocked, isAchievement3Unlocked, isAchievement4Unlocked);
        UpdatePhoto();
    }

    public void UnlockAchievement2()
    {
        isAchievement2Unlocked = true;
        DataManager.instance?.SaveAchievementStatus(isAchievement1Unlocked, isAchievement2Unlocked, isAchievement3Unlocked, isAchievement4Unlocked);
        UpdatePhoto();
    }

    public void UnlockAchievement3()
    {
        isAchievement3Unlocked = true;
        DataManager.instance?.SaveAchievementStatus(isAchievement1Unlocked, isAchievement2Unlocked, isAchievement3Unlocked, isAchievement4Unlocked);
        UpdatePhoto();
    }

    public void UnlockAchievement4()
    {
        isAchievement4Unlocked = true;
        DataManager.instance?.SaveAchievementStatus(isAchievement1Unlocked, isAchievement2Unlocked, isAchievement3Unlocked, isAchievement4Unlocked);
        UpdatePhoto();
    }

    public void Complete()
    {
        Debug.Log("Complete");
    }
}
