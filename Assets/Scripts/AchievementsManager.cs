using UnityEngine;
using UnityEngine.UI;

public class AchievementsManager : MonoBehaviour
{
    public GameObject AchievementsPanel; // 設定面板的遊戲物件
    // public static AchievementsManager instance;
    

    void Start()
    {
        // 在遊戲開始時將設定面板隱藏
        AchievementsPanel.SetActive(false);
    }

    // private void Awake()
    // {
    //     // Singleton pattern implementation
    //     if (instance == null)
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }
    // }

    // 顯示設定面板
    public void ShowAchievements()
    {
        AchievementsPanel.SetActive(true);
    }

    // 隱藏設定面板
    public void HideAchievements()
    {
        AchievementsPanel.SetActive(false);
    }
}
