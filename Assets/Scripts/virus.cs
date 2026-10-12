using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virus : MonoBehaviour
{
    public float DisappearTime;
    private PlayerScore playerScore;
    private copybug copybug;
    private bool is_copy = false;
    void Start()
    {
        playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        copybug = GameObject.FindGameObjectWithTag("Player").GetComponent<copybug>();
        Invoke("DestroyThisItem", DisappearTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // 檢查碰撞對象是否有 "Player" 標籤
        if (other.gameObject.CompareTag("Player") && !is_copy)
        {
            is_copy = true;
            playerScore.DamegePlayer(0);
            copybug.copy();
        }
    }

    // 銷毀物件的方法
    void DestroyThisItem()
    {
        // 銷毀當前物件
        Destroy(gameObject);
    }
}
