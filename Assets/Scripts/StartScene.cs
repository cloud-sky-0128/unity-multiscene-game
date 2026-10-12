using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public Button startButton; // 開始按鈕
    public Button quitButton; // 退出按鈕
    private Game_SettingsManager settingsManager;


    void Start()
    {
        // 添加開始按鈕點擊事件監聽器
        startButton.onClick.AddListener(OnStartButtonPressed);
        // 添加退出按鈕點擊事件監聽器
        quitButton.onClick.AddListener(OnQuitButtonPressed);

        var settingsManager = FindObjectOfType<Game_SettingsManager>();
        if (settingsManager != null && settingsManager.audioManager != null)
        {
            settingsManager.audioManager.Play(0, "bgm", true);
        }
        var audioManager = AudioManager.instance;
        if (audioManager != null)
        {
            audioManager.EnableAudioManager(); // 禁用 AudioManager
        }
    }

    void OnStartButtonPressed()
    {
        // LoadScene("intro");
        SceneManager.LoadScene("intro");
    }

    void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    // private void LoadScene(string sceneName)
    // {
    //     // 销毁所有 DontDestroyOnLoad 的对象
    //     DestroyAllDontDestroyOnLoadObjects();
    //     // 加载新场景
    //     SceneManager.LoadScene(sceneName);
    // }

    // private void DestroyAllDontDestroyOnLoadObjects()
    // {
    //     // 获取当前场景
    //     UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();

    //     // 获取所有根对象
    //     GameObject[] allObjects = FindObjectsOfType<GameObject>();

    //     // 销毁不属于当前场景的对象
    //     foreach (GameObject go in allObjects)
    //     {
    //         if (go.scene != currentScene && !string.IsNullOrEmpty(go.scene.name))
    //         {
    //             Destroy(go);
    //         }
    //     }
    // }
}


// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class StartScene : MonoBehaviour
// {
//     public Button startButton; // 開始按鈕
//     public Button quitButton; // 退出按鈕

//     void Start()
//     {
//         // 添加開始按鈕點擊事件監聽器
//         startButton.onClick.AddListener(OnStartButtonPressed);

//         // 確保 Game_SettingsManager.instance 和 audioManager 不為空
//         if (Game_SettingsManager.instance != null && Game_SettingsManager.instance.audioManager != null)
//         {
//             Game_SettingsManager.instance.audioManager.Play(0, "bgm", true);
//         }
//     }

//     void OnStartButtonPressed()
//     {
//         SceneManager.LoadScene("intro");
//     }

//     private void LoadScene(string sceneName)
//     {
//         // 销毁所有 DontDestroyOnLoad 的对象
//         DestroyAllDontDestroyOnLoadObjects();
//         // 加载新场景
//         SceneManager.LoadScene(sceneName);
//     }

//     private void DestroyAllDontDestroyOnLoadObjects()
//     {
//         // 获取当前场景
//         UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();

//         // 获取所有根对象
//         GameObject[] allObjects = FindObjectsOfType<GameObject>();

//         // 销毁不属于当前场景的对象
//         foreach (GameObject go in allObjects)
//         {
//             if (go.scene != currentScene && !string.IsNullOrEmpty(go.scene.name))
//             {
//                 Destroy(go);
//             }
//         }
//     }
// }
