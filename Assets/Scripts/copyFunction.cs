using UnityEngine;
using UnityEngine.EventSystems;

public class copyFunction : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition; // �O����l��m
    private CopyObjectOnDrop copyObjectScript; // �Ѧ� CopyObjectOnDrop �}��

    public void appear(GameObject obj){
        rectTransform.gameObject.SetActive(true); // ���� UI ����
    }
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        initialPosition = rectTransform.anchoredPosition; // �b Awake ���O����l��m
        copyObjectScript = FindObjectOfType<CopyObjectOnDrop>(); // �M��������� CopyObjectOnDrop �}�����
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // ��ʹL�{���� UI �����b�z��
        canvasGroup.blocksRaycasts = false; // ���\�g�u��z�o�� UI ����
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

        // �T�{ Camera.main ���O null
        if (Camera.main == null)
        {
            Debug.LogError("Camera.main �O null�C�нT�O���������@�� Main Camera�A�ñN����ҳ]�m�� MainCamera�C");
            rectTransform.anchoredPosition = initialPosition;
            return;
        }

        // ���� 2D �g�u�˴����˴��D UI ����
        Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);
        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Hit: " + hitObject.name); // �T�{�g�u�˴��쪺����
            if (hitObject.CompareTag("Manipulatable"))
            {
                Debug.Log("Manipulatable object detected: " + hitObject.name); // �T�{����㦳���T������
                if (copyObjectScript != null)
                {
                    Debug.Log("great");
                    copyObjectScript.CopyObject(); // �ե� CopyObjectOnDrop ���� CopyObject ��k
                    rectTransform.anchoredPosition = initialPosition;
                    rectTransform.gameObject.SetActive(false); // ���� UI ����
                }
                else
                {
                    Debug.LogError("copyObjectScript �O null�C�Цb�������K�[ CopyObjectOnDrop �}����ҡC");
                    rectTransform.anchoredPosition = initialPosition;
                }
            }
            else
            {
                Debug.Log("Not");
                rectTransform.anchoredPosition = initialPosition; // ��^��l��m
            }
        }
        else
        {
            Debug.Log("123");
            rectTransform.anchoredPosition = initialPosition; // �p�G�S���˴���ؼЪ���A��^��l��m
        }
    }
}
