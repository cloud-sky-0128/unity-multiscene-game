using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWay : MonoBehaviour
{
    private AreaEffector2D areaEffector;
    void Start()
    {
        areaEffector = GetComponent<AreaEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerExit2D(Collider2D other)
    {
        // 檢查碰撞對象是否有 "Player" 標籤
        if (other.gameObject.CompareTag("Player"))
        {
            if(areaEffector.forceMagnitude != 0)
            areaEffector.forceMagnitude = 0;
            gameObject.SetActive(false);
        }
    }
}