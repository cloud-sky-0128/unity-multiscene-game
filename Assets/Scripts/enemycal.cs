using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycal : Enemy
{
    
    public float speed; // 敵人的移動速度
    public float followDistance; // 敵人跟隨玩家的距離
    public float waitTime; // 敵人在移動點之間等待的時間
    public Transform target; // 目標（玩家）的 Transform 組件
    public Transform[] moveSpots; // 敵人巡邏的移動點陣列

    private int i = 0; // 當前移動點的索引
    private bool movingRight = true; // 控制敵人左右移動的標誌
    private float wait; // 當前等待時間

    void Start()
    {
        // 調用父類的 Start 方法
        base.Start();
        // 初始化等待時間
        wait = waitTime;
        // 獲取玩家的 Transform 組件
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // 調用父類的 Update 方法
        base.Update();

        // 移動敵人到當前移動點
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);

        // 如果敵人到達移動點
        if (Vector2.Distance(transform.position, moveSpots[i].position) < 0.1f)
        {
            // 如果等待時間結束
            if (waitTime <= 0)
            {
                // 切換敵人的朝向
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }

                // 切換到另一個移動點
                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }

                // 重置等待時間
                waitTime = wait;
            }
            else
            {
                // 減少等待時間
                waitTime -= Time.deltaTime;
            }
        }
    }

    // 暫停敵人的移動
    public void PauseMovement(float duration)
    {
        // 將速度設置為 0
        speed = 0;
        // 啟動協程來恢復移動
        StartCoroutine(StopMoving(duration));
    }

    // 協程：暫停移動
    IEnumerator StopMoving(float duration)
    {
        // 等待指定時間
        yield return new WaitForSeconds(duration);
        // 恢復速度
        speed = 6f;
        is_stop = false;
    }
}
