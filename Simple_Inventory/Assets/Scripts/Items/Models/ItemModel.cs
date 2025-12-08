using System.Collections.Generic;
using UnityEngine;

public sealed class ItemModel
{
    public int CellsCount => cellsCount;

    private ItemMover itemMover;
    private RectTransform rectTransform;

    private int cellsCount;

    private IReadOnlyList<GridCellController> occupyCells;

    public ItemModel(RectTransform rectTransform, int cellsCount, Canvas canvas)
    {
        this.rectTransform = rectTransform;
        this.cellsCount = cellsCount;

        itemMover = new(rectTransform, canvas);
    }

    public void SetOccupyCells(IReadOnlyList<GridCellController> occupyCells)
    {
        this.occupyCells = occupyCells;

        foreach (var cell in this.occupyCells)
        {
            cell.Occupy();
        }
    }

    public void ClearOccupyCells()
    {
        if (occupyCells == null || occupyCells.Count < 1)
        {
            return;
        }

        foreach (var cell in occupyCells)
        {
            cell.Free();
        }
    }

    public void SetToSocket(RectTransform socketTransform)
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