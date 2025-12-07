using UnityEngine;

public class ItemModel
{
    private ItemMover itemMover;
    private RectTransform rectTransform;

    private int cellsCount;

    public int CellsCount => cellsCount;

    public ItemModel(ItemMover itemMover, RectTransform rectTransform, int cellsCount)
    {
        this.itemMover = itemMover;
        this.rectTransform = rectTransform;
        this.cellsCount = cellsCount;
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