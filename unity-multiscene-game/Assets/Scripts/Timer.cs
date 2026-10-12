using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int m_seconds;          // 倒數計時經換算的總秒數
    public int m_min;              // 用於設定倒數計時的分鐘
    public int m_sec;              // 用於設定倒數計時的秒數
    public TMP_Text m_timer;       // 設定畫面倒數計時的文字
    public GameObject m_gameOver;  // 設定 GAME OVER 物件
    public Button NextButton;      // Next 按鈕

    public int levelNumber;
    private PlayerScore playerScore;
    public string SceneName;
    public GameObject canvasPrefab;

    public int bubbleNum = 0;

    void Start()
    {
        StartCoroutine(Countdown());   // 呼叫倒數計時的協程
        m_gameOver.SetActive(false);
        if(NextButton != null) NextButton.gameObject.SetActive(false); // 隱藏 Next 按鈕

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerScore = player.GetComponent<PlayerScore>();
        }
        else
        {
            Debug.LogError("Player object not found!");
        }
        if (ScoreManager.Instance == null)
        {
            Debug.LogError("ScoreManager instance is null!");
        }

        if (NextButton == null)
        {
            Debug.LogError("NextButton is not assigned in the Inspector.");
        }
        else
        {
            NextButton.onClick.AddListener(NextButtonPressed);
        }
    }

    void Update()
    {

        if (bubbleNum == 0)
        {
            m_gameOver.SetActive(true);           // 時間結束時，畫面出現 GAME COMPLETE
            Time.timeScale = 0;                   // 時間結束時，控制遊戲暫停無法操作

            if (levelNumber < 0)
            {
                LAScore.instance?.AddScore(20); // 使用空條件操作符以防止空引用異常
            }
            else
            {
                if (ScoreManager.Instance != null && playerScore != null)
                {
                    ScoreManager.Instance.SetLevelScore(levelNumber, playerScore.score);
                }
                else
                {
                    Debug.LogError("ScoreManager instance or playerScore is null!");
                }
            }

            if (SceneManager.GetActiveScene().name == "programming2")
            {
                //canvasPrefab.SetActive(true);
                NextButton.gameObject.SetActive(true); // 顯示 Next 按鈕
            }
            else
            {
                SceneManager.LoadScene(SceneName);
            }
        }
    }

    void NextButtonPressed()
    {
        SceneManager.LoadScene("end");
    }

    IEnumerator Countdown()
    {
        m_seconds = (m_min * 60) + m_sec; // 將時間換算為秒數

        while (m_seconds > 0) // 如果時間尚未結束
        {
            yield return new WaitForSeconds(1); // 等待一秒再次執行

            m_seconds--; // 總秒數減 1
            m_sec--; // 將秒數減 1

            if (m_sec < 0 && m_min > 0) // 如果秒數為 0 且分鐘大於 0
            {
                m_min -= 1; // 先將分鐘減去 1
                m_sec = 59; // 再將秒數設為 59
            }
            else if (m_sec < 0 && m_min == 0) // 如果秒數為 0 且分鐘等於 0
            {
                m_sec = 0; // 設定秒數等於 0
            }

            // 更新顯示倒計時的文本字段
            m_timer.text = string.Format("{0:00}:{1:00}", m_min, m_sec);
        }

        yield return new WaitForSeconds(1); // 時間結束時，顯示 00:00 停留一秒
        m_timer.text = "00:00"; // 確保顯示 00:00
        m_gameOver.SetActive(true); // 時間結束時，畫面出現 GAME COMPLETE
        Time.timeScale = 0; // 時間結束時，控制遊戲暫停無法操作

        if (levelNumber < 0)
        {
            LAScore.instance?.AddScore(0); // 使用空條件操作符以防止空引用異常
        }
        else
        {
            if (ScoreManager.Instance != null && playerScore != null)
            {
                print("111");
                ScoreManager.Instance.SetLevelScore(levelNumber, playerScore.score);
            }
            else
            {
                Debug.LogError("ScoreManager instance or playerScore is null!");
            }
        }

        if (SceneManager.GetActiveScene().name == "programming2")
        {
            canvasPrefab.SetActive(true);
            NextButton.gameObject.SetActive(true); // 顯示 Next 按鈕
        }
        else
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
