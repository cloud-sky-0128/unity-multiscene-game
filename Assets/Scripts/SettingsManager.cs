using UnityEngine;

public class Start_SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel; // 設定面板的遊戲物件

    void Start()
    {
        // 在遊戲開始時將設定面板隱藏
        settingsPanel.SetActive(false);
    }

    // 顯示設定面板
    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    // 隱藏設定面板
    public void HideSettings()
    {
        settingsPanel.SetActive(false);
    }
}
