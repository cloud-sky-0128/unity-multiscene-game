using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float duration; // 敵人受到攻擊時停止移動的持續時間
    public float flashTime; // 敵人受到攻擊時閃爍紅色的持續時間
    public int damage = 5; // 敵人對玩家造成的傷害數值
    public bool is_stop = false;

    private SpriteRenderer sr; // 用於控制敵人的 SpriteRenderer 組件
    private Color originalColor; // 保存敵人的原始顏色
    private PlayerScore playerScore; // 用於存取玩家的得分組件

    public void Start()
    {
        // 找到帶有 "Player" 標籤的遊戲物件，並取得其 PlayerScore 組件
        playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        // 取得敵人的 SpriteRenderer 組件
        sr = GetComponent<SpriteRenderer>();
        // 保存敵人的原始顏色
        originalColor = sr.color;
    }

    public void Update()
    {
        
    }

    // 當 2D 碰撞器進入觸發器區域時調用此方法
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            // 如果玩家得分組件存在，對玩家造成傷害
            if (playerScore != null && !is_stop)
            {
                playerScore.DamegePlayer(damage);
                
            }
        }
    }

    // 敵人受到傷害時調用此方法
    public void TakeDamage(float duration)
    {
        is_stop = true;
        // 讓敵人顏色閃爍紅色
        FlashColor(flashTime);
        // 暫停敵人的移動
        SendMessage("PauseMovement", duration);
    }

    // 讓敵人顏色閃爍紅色
    void FlashColor(float time)
    {
        // 將顏色設置為紅色
        sr.color = Color.red;
        // 在指定時間後重置顏色
        Invoke("ResetColor", time);
    }

    // 重置敵人的顏色為原始顏色
    void ResetColor()
    {
        sr.color = originalColor;
    }
}