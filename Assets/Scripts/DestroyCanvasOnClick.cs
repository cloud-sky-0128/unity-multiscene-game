using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyCanvasOnClick : MonoBehaviour 
{
	//要移除的canvas
    public GameObject canvasPrefab;
    void Start()
    {
		//按下按鈕後，呼叫ClickEvent()
        GetComponent<Button> ().onClick.AddListener(ClickEvent);
    }
    
    void ClickEvent()
    {
		//刪掉canvas
        canvasPrefab.SetActive(false);
    }
}