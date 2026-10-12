using UnityEngine;
using UnityEngine.EventSystems;

public class rotate : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject arrowUp;
    public GameObject arrowRight;
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition; // 記錄初始位置
    private int count, countUp = 0, countLeft = 0; // 計數器
    private Arrow arrowU;
    private Arrow arrowR;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        initialPosition = rectTransform.anchoredPosition; // 在 Awake 中記錄初始位置
        arrowU = arrowUp.GetComponentInParent<Arrow>();
        arrowR = arrowRight.GetComponentInParent<Arrow>();
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
            if (hitObject.CompareTag("Manipulatable2"))
            {
                Debug.Log("Manipulatable object detected: " + hitObject.name); // 確認物體具有正確的標籤(up)
                RotateObject(hitObject);
                countUp++;
                if(countUp % 2 == 0)
                {
                    arrowU.changeMagnitude(100);
                    Debug.Log("changeMagnitude(100)");
                }
                else
                {
                    arrowU.changeMagnitude(1000);
                    Debug.Log("changeMagnitude(1000)");
                }
            }
            else if (hitObject.CompareTag("Manipulatable3"))
            {
                Debug.Log("Manipulatable object detected: " + hitObject.name); // 確認物體具有正確的標籤(left)
                countLeft++;
                if (countLeft % 2 == 0)
                {
                    arrowR.changeMagnitude(1000);
                    Debug.Log("changeMagnitude(1000)");
                }
                else
                {
                    arrowR.changeMagnitude(100);
                    Debug.Log("changeMagnitude(100)");
                }
                RotateObject(hitObject);
            }
            else if(hitObject.CompareTag("electricity")){
                RotateObject(hitObject);
                Debug.Log("Manipulatable object detected: " + hitObject.name); // 確認物體具有正確的標籤
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
    }

    private void RotateObject(GameObject obj)
    {
        count++;
        obj.transform.Rotate(Vector3.forward, 90f);
        Debug.Log("Rotated " + obj.name + " to " + obj.transform.rotation);
    }
}