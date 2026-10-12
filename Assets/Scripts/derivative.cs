using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class derivative : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Sleep Sleep;
    public GameObject smallThing;
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition; // 記錄初始位置
    private int count; // 計數器
    private void Awake()
    {
        Sleep = smallThing.GetComponent<Sleep>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        initialPosition = rectTransform.anchoredPosition; // 在 Awake 中記錄初始位置
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // 拖動過程中使 UI 元素半透明
        canvasGroup.blocksRaycasts = false; // 允許射線穿透這個 UI 元素
        Debug.Log("Begin Drag: " + gameObject.name);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        Debug.Log("End Drag: " + gameObject.name);

        // 執行 2D 射線檢測來檢測非 UI 物體
        Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);
        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Hit: " + hitObject.name); // 確認射線檢測到的物體
            if (hitObject.CompareTag("Manipulatable")) // 檢查檢測到的物體是否具有正確的標籤
            {
                Debug.Log("Manipulatable object detected: " + hitObject.name); // 確認物體具有正確的標籤
                ShrinkObject(hitObject);
            }
            else if (hitObject.CompareTag("fan") || hitObject.CompareTag("fan2") || hitObject.CompareTag("fan3")) // 檢查檢測到的物體是否具有正確的標籤
            {
                Debug.Log("Manipulatable object detected: " + hitObject.name); // 確認物體具有正確的標籤
                ShrinkObject1(hitObject);
                rectTransform.anchoredPosition = initialPosition; // 返回初始位置
            }
            else
            {
                Debug.Log("Hit object does not have the correct tag, returning to original position");
                rectTransform.anchoredPosition = initialPosition; // 返回初始位置
            }
        }
        else
        {
            Debug.Log("No object hit by Raycast, returning to original position");
            rectTransform.anchoredPosition = initialPosition; // 如果沒有檢測到目標物體，返回初始位置
        }
        // if(count == 5){
        //     rectTransform.gameObject.SetActive(false); // 隱藏 UI 元素
        // }
    }

    public void ShrinkObject(GameObject obj)
    {
        // count++;
        if (obj.transform.localScale.x < 0.05f) {
            // obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // 防止縮放為負或零
            count--;
            Sleep.ShowObject();
        }
        else {
            obj.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f); // 顯著減少縮放
        }
        Debug.Log("Shrunk " + obj.name + " to " + obj.transform.localScale);
    }
    public void ShrinkObject1(GameObject obj)
    {
        // count++;
        if (obj.transform.localScale.x < 0.15f) {
            // obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // 防止縮放為負或零
            count--;
            Sleep.ShowObject();
        }
        else{
            obj.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f); // 顯著減少縮放
        }
        Debug.Log("Shrunk " + obj.name + " to " + obj.transform.localScale);
    }
    
}