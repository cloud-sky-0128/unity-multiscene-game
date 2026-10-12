using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowImageOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image imageToShow;

    private void Awake()
    {
        if (imageToShow == null)
        {
            Debug.LogError("Image to show is not assigned. Please assign an image in the inspector.");
        }
    }

    private void Start()
    {
        // 確保圖片在開始時處於隱藏狀態
        if (imageToShow != null)
        {
            imageToShow.enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (imageToShow != null)
        {
            imageToShow.enabled = true; // 顯示圖片
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (imageToShow != null)
        {
            imageToShow.enabled = false; // 隱藏圖片
        }
    }
}
