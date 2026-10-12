using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherOnKeyPress : MonoBehaviour
{
    public string nextSceneName;

    void Update()
    {
        // 檢查是否按下了任意鍵
        if (Input.anyKeyDown)
        {
            // 當按下任意鍵時，切換到下一個場景
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
