using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private RectTransform gridRectTransform;

    private GridCellController gridCellPrefab;
    private GridCellController[] gridCellControllers;
    private GridModel gridModel;

    private int cellsCount = 16;

    public void Initialize(GridCellController gridCellPrefab)
    {
        this.gridCellPrefab = gridCellPrefab;
        gridModel = new();

        CreateCells();
    }

    public void HighlightCells(ItemController item)
    {
        var occupyCells = gridModel.FindNearestICells(item);

        if (occupyCells.Count < 1)
        {
            return;
        }

        if (occupyCells.Count < item.CellsCount)
        {
            foreach (var cell in occupyCells)
            {
                cell.HoverCell();
            }

            gridModel.ClearSelectedCells();
        }
        else if (occupyCells.Count == item.CellsCount)
        {
            foreach (var cell in occupyCells)
            {
                cell.SelectCell();
            }

            gridModel.SetSelectedCells(occupyCells);
        }
    }

    public void CreateCells()
    {
        gridCellControllers = new GridCellController[cellsCount];

        for (int i = 0; i < cellsCount; i++)
        {
            var cell = GameObject.Instantiate(gridCellPrefab, gridRectTransform);

            gridCellControllers[i] = cell;
        }

        gridModel.SetCells(gridCellControllers);
    }

    public void DeselectGridCells()
    {
        foreach (var cell in gridCellControllers)
        {
            cell.DeselectCell();
        }
    }

    public bool TrySetItem(int cellsCount)
    {
        if (gridModel.CurrentSelectedCells == null || gridModel.CurrentSelectedCells.Count != cellsCount)
        {
            return false;
        }

        return true;
    }

    public void ClearSelectedCells()
    {
        gridModel.ClearSelectedCells();
    }

    public void SetItemToGrid(ItemController item)
    {
        gridModel.SetItemToGrid(item);
    }
}