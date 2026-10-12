using UnityEngine;
using UnityEngine.EventSystems;

public class DragUIElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition; // 記錄初始位置

    private void Awake()
    {
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

        // 執行射線檢測來檢測非 UI 物體
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Hit: " + hitObject.name); // 確認射線檢測到的物體
            if (hitObject.CompareTag("Manipulatable"))
            {
                Debug.Log("Manipulatable object detected: " + hitObject.name); // 確認物體具有正確的標籤
                PerformAction(hitObject);
            }
        }
        else
        {
            Debug.Log("No object hit by Raycast, returning to original position");
            rectTransform.anchoredPosition = initialPosition; // 如果沒有檢測到目標物體，返回初始位置
        }
    }

    private void PerformAction(GameObject hitObject)
    {
        Debug.Log("Performing action on: " + hitObject.name + " with UI element: " + gameObject.name); // 添加調試信息
        switch (gameObject.name)
        {
            case "integral":
                Debug.Log("Calling EnlargeObject");
                EnlargeObject(hitObject);
                break;
            case "derivative":
                Debug.Log("Calling ShrinkObject");
                ShrinkObject(hitObject);
                break;
            case "rotate":
                Debug.Log("Calling RotateObject");
                RotateObject(hitObject);
                break;
            case "long":
                Debug.Log("Calling StretchObject");
                StretchObject(hitObject);
                break;
            case "disappear":
                Debug.Log("Calling Destroy");
                Destroy(hitObject);
                break;
            default:
                Debug.Log("Unknown action");
                break;
        }
    }

    private void EnlargeObject(GameObject obj)
    {
        obj.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f); // 顯著增加縮放
        Debug.Log("Enlarged " + obj.name + " to " + obj.transform.localScale);
    }

    private void ShrinkObject(GameObject obj)
    {
        obj.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f); // 顯著減少縮放
        if (obj.transform.localScale.x < 0.1f) obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // 防止縮放為負或零
        Debug.Log("Shrunk " + obj.name + " to " + obj.transform.localScale);
    }

    private void RotateObject(GameObject obj)
    {
        obj.transform.Rotate(Vector3.forward, 90f);
        Debug.Log("Rotated " + obj.name + " to " + obj.transform.rotation);
    }

    private void StretchObject(GameObject obj)
    {
        Vector3 scale = obj.transform.localScale;
        if (scale.x >= scale.y)
        {
            obj.transform.localScale += new Vector3(1f, 0, 0);
        }
        else
        {
            obj.transform.localScale += new Vector3(0, 1f, 0);
        }
        Debug.Log("Stretched " + obj.name + " to " + obj.transform.localScale);
    }
}