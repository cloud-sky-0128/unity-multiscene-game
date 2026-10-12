using System;
using UnityEngine;
using UnityEngine.UI;

public class GetGrade : MonoBehaviour
{
    private int flunked; // 被当掉的科目有几科
    public static event Action<string> OnGameEnd;

    public GameObject fail1Image;
    public GameObject fail2Image;
    public GameObject fail3Image;
    public GameObject fail4Image;
    public GameObject fail5Image;
    public GameObject transcript;
    public GameObject bookAward;

    [Range(0, 100)] public int score1; // 第一关分数
    [Range(0, 100)] public int score2; // 第二关分数
    [Range(0, 100)] public int score3; // 第三关分数
    [Range(0, 100)] public int score4; // 第四关分数
    [Range(0, 100)] public int score5; // 第五关分数

    void Start()
    {
        ScoreManager scoreManager = ScoreManager.Instance;
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager instance is null!");
            return;
        }

        score1 = scoreManager.GetLevelScore(0);
        score2 = scoreManager.GetLevelScore(1);
        score3 = scoreManager.GetLevelScore(2);
        score4 = scoreManager.GetLevelScore(3);
        score5 = scoreManager.GetLevelScore(4);

        Debug.Log($"Scores: {score1}, {score2}, {score3}, {score4}, {score5}");
    }


    void Update()
    {
        CheckEndCondition();
        string endingScene = DetermineEndingScene();
    }


    int CheckEndCondition()
    {
        flunked = 0;
        int[] scores = { score1, score2, score3, score4, score5 };

        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] < 60)
            {
                flunked++;
            }
        }

        if(score1 < 60) fail1Image.SetActive(true);
        if(score2 < 60) fail2Image.SetActive(true);
        if(score3 < 60) fail3Image.SetActive(true);
        if(score4 < 60) fail4Image.SetActive(true);
        if(score5 < 60) fail5Image.SetActive(true);

        return flunked;
    }

    string DetermineEndingScene()
    {
        string endingScene = "";

        bool allAchievementsUnlocked = DataManager.instance != null && DataManager.instance.AllAchievementsUnlocked();
        if (allAchievementsUnlocked && flunked == 0)
        {
            endingScene = "end_achieve";
        }
        else if (!allAchievementsUnlocked && flunked == 0)
        {
            endingScene = "end_ap";
        }
        else if (flunked < 3)
        {
            endingScene = "end_flunk";
        }
        else
        {
            endingScene = "end_21";
        }

        OnGameEnd?.Invoke(endingScene);

        return endingScene;
    }
    
}
