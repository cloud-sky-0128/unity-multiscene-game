using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class control : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition;
    public GameObject fan;
    private Animator fanAnimator;
    [SerializeField] private GameObject fly;
    private AreaEffector2D areaEffector;
    public void Start()
    {
        areaEffector = fly.GetComponent<AreaEffector2D>();
        if (fan != null)
        {
            fanAnimator = fan.GetComponent<Animator>();
        }
    }
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        initialPosition = rectTransform.anchoredPosition;

        if (fan != null)
        {
            areaEffector = fan.GetComponent<AreaEffector2D>();
            fanAnimator = fan.GetComponent<Animator>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
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

        Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);

        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Hit: " + hitObject.name);
            if (hitObject.CompareTag("fan2"))
            {
                Debug.Log("Manipulatable object detected: " + hitObject.name);

                if (areaEffector != null && areaEffector.forceMagnitude == 0)
                {
                    areaEffector.forceMagnitude = 70f;
                    if (fanAnimator != null)
                    {
                        fanAnimator.SetTrigger("On");
                    }
                }
                else
                {
                    Debug.LogError("AreaEffector2D is not found or forceMagnitude is already set.");
                }
                rectTransform.anchoredPosition = initialPosition;
            }
            else
            {
                Debug.Log("Hit object does not have the correct tag, returning to original position");
                rectTransform.anchoredPosition = initialPosition;
            }
        }
        else
        {
            Debug.Log("No object hit by Raycast, returning to original position");
            rectTransform.anchoredPosition = initialPosition;
        }
    }
}
