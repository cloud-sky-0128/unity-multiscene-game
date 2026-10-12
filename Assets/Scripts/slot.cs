using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        if (draggableItem != null)
        {
            // 检查槽是否已经有子对象
            if (transform.childCount > 0)
            {
                // 如果槽已满，将可拖动的物品退回到原来的父对象
                draggableItem.parentAfterDrag = draggableItem.originalParent;  // 退回到原始父对象
            }
            else
            {
                // 如果槽为空，将可拖动的物品的父对象设置为槽
                draggableItem.parentAfterDrag = transform;
            }
        }
    }
}