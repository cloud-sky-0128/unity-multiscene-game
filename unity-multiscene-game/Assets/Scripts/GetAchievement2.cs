using UnityEngine;

public class GetAchievement2 : MonoBehaviour
{
    public GameObject timer;
    private Timer timerScript;
    private bool is_eat = false;
    private Achievement achievementManager;

    void Start()
    {
        // 查找 AchievementManager
        achievementManager = FindObjectOfType<Achievement>();
        if (achievementManager == null)
        {
            Debug.LogError("AchievementManager is null");
        }
        timerScript = timer.GetComponent<Timer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !is_eat) // 檢查碰撞的對象是否為 Player
        {
            is_eat = true;
            achievementManager.UnlockAchievement2();
            timerScript.bubbleNum--;
            Destroy(gameObject); // 銷毀成就對象
            AudioManager.instance.Play(1, "seBubble", false);
        }
    }
}
