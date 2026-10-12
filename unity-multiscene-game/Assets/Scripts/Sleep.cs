using UnityEngine;
using System.Collections;

public class Sleep : MonoBehaviour
{
    public GameObject smallThing;
    public float displayTime = 2.0f;
    void Start()
    {
        // 在遊戲開始時隱藏物件
        smallThing.SetActive(false);
    }

    public void ShowObject()
    {
        // 在需要時顯示物件並啟動協程
        smallThing.SetActive(true);
        StartCoroutine(ShowAndHideObject()); // 兩秒後開始淡出
        Debug.Log("Start");
    }

    private IEnumerator ShowAndHideObject()
    {
        // 使物體可見
        smallThing.SetActive(true);

        // 等待指定的時間
        yield return new WaitForSeconds(displayTime);

        // 隱藏物體
        smallThing.SetActive(false);
    }

}