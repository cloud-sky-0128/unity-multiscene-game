using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public int score; // 記錄分數
    public int blinks; // 閃爍次數
    public float time; // 每次閃爍的時間
    public float cd; // 無敵狀態持續時間
    private Renderer myRender; // 角色渲染器
    private screenflash sf; // 屏幕閃爍效果
    private CapsuleCollider2D cc2d; // 角色的 2D 膠囊碰撞器
    [SerializeField] private Text textscore; // 用於顯示分數的 UI 文本

    void Awake()
    {
        score = 0; // 初始化分數
    }
    void Start()
    {
        myRender = GetComponent<Renderer>(); // 獲取渲染器
        sf = GetComponent<screenflash>(); // 獲取屏幕閃爍效果
        cc2d = GetComponent<CapsuleCollider2D>(); // 獲取 2D 膠囊碰撞器
        UpdateScoreText(); // 更新分數顯示
    }

    void Update()
    {

    }

    public void DamegePlayer(int damage)
    {
        AudioManager.instance.Play(2, "seBlock", false);
        sf.FlashScreen(); // 閃爍屏幕效果
        score -= damage; // 減少分數
        if (score <= 0)
        {
            score = 0; // 確保分數不低於 0
        }
        BlinkPlayer(blinks, time); // 角色閃爍效果
        cc2d.enabled = false; // 暫時禁用碰撞器
        StartCoroutine(InvincibleTime()); // 無敵時間協程
        UpdateScoreText(); // 更新分數顯示
    }

    public void IncreaseScore(int amount)
    {
        score += amount; // 增加分數
        if(score >= 100)
        {
            score = 100; // 確保分數不高於 100
        }
        UpdateScoreText(); // 更新分數顯示
    }

    public void UpdateScoreText()
    {
        textscore.text = "" + score; // 更新 UI 文本顯示分數
    }

    public void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds)); // 啟動閃爍協程
    }

    IEnumerator InvincibleTime()
    {
        yield return new WaitForSeconds(cd); // 等待無敵時間結束
        cc2d.enabled = true; // 重新啟用碰撞器
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for (int i = 0; i < numBlinks * 2; i++)
        {
            myRender.enabled = !myRender.enabled; // 切換渲染器的可見性
            yield return new WaitForSeconds(seconds); // 等待
        }
        myRender.enabled = true; // 確保最後是可見的
    }
}