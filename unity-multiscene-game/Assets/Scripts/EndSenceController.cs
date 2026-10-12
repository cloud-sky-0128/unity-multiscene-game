using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;

public class EndSenceController : MonoBehaviour
{
    private FlowerSystem fs;
    private string ending = "";
    private bool isGameEnd = false;
    private int progress = 0;
    public GameObject transcript; // 添加此行以引用成绩单对象
    public GameObject bookAward;
    public GameObject fail1Image;
    public GameObject fail2Image;
    public GameObject fail3Image;
    public GameObject fail4Image;
    public GameObject fail5Image;

    void Start()
    {
        if (FlowerManager.Instance == null)
        {
            Debug.LogError("FlowerManager.Instance is null!");
            return;
        }

        // 尝试创建 FlowerSystem，确保键值唯一性
        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);
        if (fs == null)
        {
            Debug.LogError("Failed to create FlowerSystem!");
            return;
        }

        // 初始化 FlowerSystem
        fs.SetupDialog();
        fs.SetupUIStage();

        // 注册自定义命令
        fs.RegisterCommand("load_scene", (List<string> _params) =>
        {
            LoadScene(_params[0]);
        });

        // 订阅游戏结束事件
        GetGrade.OnGameEnd += HandleGameEnd;

        // 初始化成绩单和奖励对象
        transcript.SetActive(false);
        bookAward.SetActive(false);
        fail1Image.SetActive(false);
        fail2Image.SetActive(false);
        fail3Image.SetActive(false);
        fail4Image.SetActive(false);
        fail5Image.SetActive(false);
        var audioManager = AudioManager.instance;
        if (audioManager != null)
        {
            audioManager.DisableAudioManager();
        }
    }

    void HandleGameEnd(string endingScene)
    {
        if (!string.IsNullOrEmpty(endingScene))
        {
            ending = endingScene;
            Debug.LogWarning("Ending Scene: " + ending);
        }
        else
        {
            Debug.Log("Ending scene name is empty!");
        }
    }

    void Update()
    {
        if (fs == null)
        {
            Debug.LogError("FlowerSystem is not initialized!");
            return;
        }

        if (fs.isCompleted && !isGameEnd)
        {
            switch (progress)
            {
                case 0:
                    Debug.Log("Loading end text from resource");
                    fs.ReadTextFromResource("end1");
                    break;
                case 1:
                    transcript.SetActive(true);
                    if (ending == "end_achieve")
                    {
                        bookAward.SetActive(true);
                    }
                    break;
                case 2:
                    Debug.Log("Loading ending text from resource: " + ending);
                    fs.ReadTextFromResource(ending);
                    fs.Resume();
                    break;
                case 3:
                    transcript.SetActive(false);
                    bookAward.SetActive(false);
                    fs.ReadTextFromResource("endEnd");
                    break;
                case 4:
                    isGameEnd = true;
                    break;
            }
            progress++;
        }

        if (!isGameEnd)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fs.Next();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                fs.Resume();
            }
        }

        if (isGameEnd)
        {
            Debug.Log("Game end, loading Start scene");
            LoadScene("Start");
        }
    }

    private void LoadScene(string sceneName)
    {
        Debug.Log("Loading scene: " + sceneName);
        // 销毁所有 DontDestroyOnLoad 的对象
        DestroyAllDontDestroyOnLoadObjects();
        // 加载新场景
        SceneManager.LoadScene(sceneName);
    }

    private void DestroyAllDontDestroyOnLoadObjects()
    {
        // 获取当前场景
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();

        // 获取所有根对象
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        // 销毁不属于当前场景的对象
        foreach (GameObject go in allObjects)
        {
            if (go.scene != currentScene && !string.IsNullOrEmpty(go.scene.name))
            {
                Destroy(go);
            }
        }
    }
}
