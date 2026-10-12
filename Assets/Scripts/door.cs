using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class door : MonoBehaviour
{
    private CapsuleCollider2D cc2d;
    public bool condition = false;
    private bool is_open = false;
    private Animator openAnimator;
    void Start()
    {
        cc2d = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // 檢查碰撞對象是否有 "Player" 標籤
        if (other.gameObject.CompareTag("Player") && condition == true && !is_open)
        {
            cc2d.enabled = false;
            is_open = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && condition == true && is_open)
        {
            cc2d.enabled = true;
            is_open = false;
        }
    }
}
