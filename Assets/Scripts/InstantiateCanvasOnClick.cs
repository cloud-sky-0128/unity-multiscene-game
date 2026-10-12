using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstantiateCanvasOnClick : MonoBehaviour 
{
	//要產生的canvas
    public GameObject canvasPrefab;
    
    void Start()
    {
		//按下按鈕時，呼叫ClickEvent()
        GetComponent<Button> ().onClick.AddListener(ClickEvent);
    }
    
    void ClickEvent()
    {
		//生產canvasPrefab
        canvasPrefab.SetActive(true);
    }
}