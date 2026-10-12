using UnityEngine;
using UnityEngine.EventSystems;

public class Delta : MonoBehaviour, IDropHandler
{
    public GameObject myObject;
    public float offset = 0.1f;

    // 調整這個變量來控制拉長的速度
    public float stretchSpeed = 1.0f;
    // 最大長度
    public float maxLength = 10.0f;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped != null)
        {
            if (dropped.name == "Imagelarge")
            {
                EnlargeObject();
            }
            else if (dropped.name == "derivative")
            {
                ShrinkObject();
            }
            else if (dropped.name == "rotate")
            {
                RotateObject();
            }
            else if (dropped.name == "long")
            {
                StretchObject();
            }
            else if (dropped.name == "disappear")
            {
                Destroy(myObject); // 只有在拖放 "disappear" 時才銷毀物體
            }
        }
    }

    void ShrinkObject()
    {
        if (myObject != null)
        {
            myObject.transform.localScale = new Vector3(myObject.transform.localScale.x - offset,
                                                         myObject.transform.localScale.y - offset,
                                                         myObject.transform.localScale.z - offset);
        }
    }

    void EnlargeObject()
    {
        if (myObject != null)
        {
            myObject.transform.localScale = new Vector3(myObject.transform.localScale.x + offset,
                                                         myObject.transform.localScale.y + offset,
                                                         myObject.transform.localScale.z + offset);
        }
    }

    void RotateObject()
    {
        if (myObject != null)
        {
            myObject.transform.Rotate(Vector3.forward, 90f);
        }
    }

    void StretchObject()
    {
        if (myObject != null)
        {
            // 獲取物體當前的 x 和 y 軸長度
            float currentLengthX = myObject.transform.localScale.x;
            float currentLengthY = myObject.transform.localScale.y;

            // 判斷哪個軸向的長度更長
            if (currentLengthX >= currentLengthY)
            {
                // 如果 x 軸長度更長，檢查是否需要拉長並拉長 x 軸
                if (currentLengthX < maxLength)
                {
                    myObject.transform.localScale += new Vector3(stretchSpeed * Time.deltaTime, 0, 0);
                }
            }
            else
            {
                // 如果 y 軸長度更長，檢查是否需要拉長並拉長 y 軸
                if (currentLengthY < maxLength)
                {
                    myObject.transform.localScale += new Vector3(0, stretchSpeed * Time.deltaTime, 0);
                }
            }
        }
    }
}