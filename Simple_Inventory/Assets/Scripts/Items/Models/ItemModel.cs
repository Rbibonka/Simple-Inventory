using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public sealed class ItemModel
{
    public int CellsCount => cellsCount;

    private ItemMover itemMover;
    private RectTransform rectTransform;

    private int cellsCount;

    private IReadOnlyList<GridCellController> occupyCells;

    private Vector3 defaultPosition;

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
            cell.DeselectCell();
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
        defaultPosition = socketTransform.position;

        rectTransform.position = defaultPosition;
    }

    public void Drag(PointerEventData delta)
    {
        itemMover.Move(delta);
    }

    public void MoveToDefault()
    {
        itemMover.MoveTo(defaultPosition);
    }

    public void SetPosition(PointerEventData delta)
    {
        itemMover.Move(delta);
    }
}