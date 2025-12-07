using UnityEngine;

public sealed class ItemModel
{
    public int CellsCount => cellsCount;

    private ItemMover itemMover;
    private RectTransform rectTransform;

    private int cellsCount;

    public ItemModel(RectTransform rectTransform, int cellsCount, Canvas canvas)
    {
        this.rectTransform = rectTransform;
        this.cellsCount = cellsCount;

        itemMover = new(rectTransform, canvas);
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

    public void MoveToDefault()
    {
        itemMover.MoveToDefault();
    }

    public void SetPosition(Vector3 targetPosition)
    {
        rectTransform.position = targetPosition;
    }
}