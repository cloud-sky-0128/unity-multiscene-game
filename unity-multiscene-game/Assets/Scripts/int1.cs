using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class int1 : MonoBehaviour
{
    public GameObject next;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 檢查碰撞對象是否有 "Player" 標籤
        if (other.gameObject.CompareTag("Player"))
        {
            next.SetActive(true);
        }
    }
}
