using UnityEngine;

public class ItemModel
{
    private ItemMover itemMover;
    private RectTransform rectTransform;

    public ItemModel(ItemMover itemMover, RectTransform rectTransform)
    {
        this.itemMover = itemMover;
        this.rectTransform = rectTransform;
    }

    public void SetToSocker(RectTransform socketTransform)
    {
        rectTransform.SetParent(socketTransform, false);
        rectTransform.localPosition = Vector3.zero;
    }

    public void Drag(Vector2 delta)
    {
        itemMover.Move(delta);
    }

    public void MoveTo()
    {
        itemMover.MoveToDefault();
    }

    public void SetPosition(Vector3 targetPosition)
    {
        rectTransform.position = targetPosition;
    }
}