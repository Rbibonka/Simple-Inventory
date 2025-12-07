using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class GridController : MonoBehaviour
{
    [SerializeField]
    private RectTransform gridRectTransform;

    private GridCellController gridCellPrefab;
    private GridCellController[,] gridCellControllers;
    private GridModel gridModel;

    public void Initialize(GridCellController gridCellPrefab, GridConfig gridConfig)
    {
        this.gridCellPrefab = gridCellPrefab;
        gridModel = new();

        CreateCells(gridConfig);
    }

    public void HighlightCells(ItemController item)
    {
        var occupyCells = gridModel.FindNearestItemCells(item);

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

    public void CreateCells(GridConfig gridConfig)
    {
        gridCellControllers = new GridCellController[gridConfig.Grid.Length, gridConfig.Grid[0].row.Length];

        int row = 0;
        int column = 0;

        foreach (var gridRow in gridConfig.Grid)
        {
            foreach (var gridColumn in gridRow.row)
            {
                var cell = GameObject.Instantiate(gridCellPrefab, gridRectTransform);

                cell.Initialize(gridColumn, new Vector2(row, column));

                gridCellControllers[row, column] = cell;
                column++;
            }
            row++;
            column = 0;
        }

        gridModel.SetCells(gridCellControllers);
    }

    public void DeselectGridCells()
    {
        foreach (var cell in gridCellControllers)
        {
            if (cell.IsActive)
            {
                cell.DeselectCell();
            }
            else
            {
                cell.Deactivate();
            }
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