using UnityEngine;
using UnityEngine.EventSystems;

public class inventorySlot : MonoBehaviour, IDropHandler
{
    public bool InInventoryOther = true;
    public bool Garbage = false;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (transform.childCount > 0)
        {
            dropped.GetComponent<DraggableItem>().transform.SetParent(dropped.GetComponent<DraggableItem>().ParentBeforeDrag);
        }
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        draggableItem.ParentAfterDrag = transform;
        if (Garbage)
        {
            Destroy(draggableItem.transform.gameObject);
        }
    }
}
