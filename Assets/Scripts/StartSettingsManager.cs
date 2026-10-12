using UnityEngine;
using UnityEngine.UI;

public class StartSettingsManager : MonoBehaviour
{
    public GameObject settingsPanel; // 設定面板的遊戲物件

    void Start()
    {
        // 在遊戲開始時將設定面板隱藏
        settingsPanel.SetActive(false);
    }

    // 顯示設定面板
    public void ShowStartSettings()
    {
        settingsPanel.SetActive(true);
    }

    // 隱藏設定面板
    public void HideStartSettings()
    {
        settingsPanel.SetActive(false);
    }
}
