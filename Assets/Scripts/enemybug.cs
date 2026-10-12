using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybug : Enemy
{
    public float speed; // 敵人的移動速度
    public float startWaitTime; // 敵人在移動點之間等待的初始時間
    public float followDistance; // 敵人跟隨玩家的距離
    private float waitTime; // 當前等待時間

    public Transform target; // 目標（玩家）的 Transform 組件
    public Transform movePos; // 敵人的目標移動位置
    public Transform leftDownPos; // 移動區域的左下角位置
    public Transform rightUpPos; // 移動區域的右上角位置

    public void Start()
    {
        // 調用父類的 Start 方法
        base.Start();
        // 獲取玩家的 Transform 組件
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // 初始化等待時間
        waitTime = startWaitTime;
        // 設置初始隨機移動位置
        movePos.position = GetRandomPos();
    }

    public void Update()
    {
        // 調用父類的 Update 方法
        base.Update();

        // 如果敵人與玩家的水平距離小於跟隨距離
        if (Mathf.Abs(transform.position.x - target.position.x) < followDistance)
        {
            // 跟隨玩家移動
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            // 根據玩家位置翻轉敵人
            if (transform.position.x - target.position.x < 0)
                transform.eulerAngles = new Vector3(0, 180, 0);
            if (transform.position.x - target.position.x > 0)
                transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            // 移動到目標移動位置
            transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
            // 根據移動位置翻轉敵人
            if (transform.position.x - movePos.position.x < 0)
                transform.eulerAngles = new Vector3(0, 180, 0);
            if (transform.position.x - movePos.position.x > 0)
                transform.eulerAngles = new Vector3(0, 0, 0);

            // 如果到達目標位置
            if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
            {
                // 如果等待時間結束
                if (waitTime <= 0)
                {
                    // 設置新的隨機位置
                    movePos.position = GetRandomPos();
                    // 重置等待時間
                    waitTime = startWaitTime;
                }
                else
                {
                    // 減少等待時間
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    // 獲取隨機位置
    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
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
