using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copybug : MonoBehaviour
{
    public Transform leftDownPos; // 移動區域的左下角位置
    public Transform rightUpPos;
    public GameObject bug;
    public void copy()
    {
        Instantiate(bug, GetRandomPos(), transform.rotation);
    }
    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }
}
