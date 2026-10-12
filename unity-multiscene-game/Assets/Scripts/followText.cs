using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class followText : MonoBehaviour
{
    public Transform For;  // 玩家角色的Transform
    private RectTransform textRectTransform;  // Text的RectTransform

    void Start()
    {
        textRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // 将玩家角色的位置转换为屏幕坐标
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(For.position);
        textRectTransform.position = screenPosition;
    }
}
