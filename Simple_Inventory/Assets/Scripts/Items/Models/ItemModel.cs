using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class ItemModel
{
    public int Level => level;

    public ItemType ItemType => itemType;

    public int CellsCount => cellsCount;

    private ItemMover itemMover;
    private RectTransform rectTransform;

    private int cellsCount;

    private IReadOnlyList<GridCellController> occupyCells;

    private Vector3 defaultPosition;

    private int level;
    private ItemType itemType;

    public ItemModel(RectTransform rectTransform, int cellsCount, ItemType itemType, Canvas canvas)
    {
        this.rectTransform = rectTransform;
        this.cellsCount = cellsCount;
        this.itemType = itemType;

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

    public void UpdateLevel()
    {
        level++;
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