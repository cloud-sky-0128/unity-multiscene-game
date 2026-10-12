using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public float duration; // 持續時間，用於對敵人造成效果
    public float DisappearTime; // 消失時間，物件在該時間後銷毀
    public Vector2 startSpeed; // 初始速度，用於設定拋物的速度和方向
    public Transform target; // 目標（玩家）的 Transform 組件
    private Rigidbody2D rb2d; // 物件的剛體組件

    void Start()
    {
        // 獲取玩家的 Transform 組件
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // 獲取物件的剛體組件
        rb2d = GetComponent<Rigidbody2D>();
        // 設定初始速度和方向
        if (target.localScale.x > 0)
        {
            // 如果目標的 x 軸縮放大於 0，設置物件向右上方移動
            rb2d.velocity = transform.up * startSpeed.y + transform.right * (startSpeed.x + target.localScale.x);
        }
        else
        {
            // 如果目標的 x 軸縮放小於 0，設置物件向左上方移動
            rb2d.velocity = transform.up * startSpeed.y - transform.right * (startSpeed.x - target.localScale.x);
        }
        // 在指定時間後銷毀物件
        Invoke("DestroyThisItem", DisappearTime);
    }

    void Update()
    {

    }

    // 當物件進入2D碰撞觸發器時調用此方法
    void OnTriggerEnter2D(Collider2D other)
    {
        // 檢查碰撞對象是否有 "Enemy" 標籤
        if (other.gameObject.CompareTag("Enemy"))
        {
            // 對敵人造成傷害並使其受到效果
            other.GetComponent<Enemy>().TakeDamage(duration);
        }
    }

    // 銷毀物件的方法
    void DestroyThisItem()
    {
        // 銷毀當前物件
        Destroy(gameObject);
    }
}
