using UnityEngine;
using UnityEngine.EventSystems;

public class Append : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition; // 記錄初始位置
    private int count; // 計數器

    private float offsetX; // 每个副本之间的水平偏移量

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        initialPosition = rectTransform.anchoredPosition; // 在 Awake 中記錄初始位置
        count = 0; // 初始化計數器
        offsetX = 2f; // 初始化 offsetX
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
            if (hitObject.CompareTag("Manipulatable"))
            {
                Debug.Log("Manipulatable object detected: " + hitObject.name); // 確認物體具有正確的標籤
                AppendObject(hitObject);
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

        if(count >= 5){
            rectTransform.gameObject.SetActive(false); // 隱藏 UI 元素
        }
    }

    private void AppendObject(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogWarning("Object is null.");
            return;
        }

        count++;
        Vector3 originalPosition = obj.transform.position;
        Vector3 newPosition = originalPosition + new Vector3(offsetX * count, 0f, 0f);
        GameObject newObj = Instantiate(obj, newPosition, obj.transform.rotation);
        
        // 清空新物體的標籤
        newObj.tag = "Untagged"; // 或者直接設置為 "Untagged"
        
        rectTransform.anchoredPosition = initialPosition; // 返回初始位置
    }


}
