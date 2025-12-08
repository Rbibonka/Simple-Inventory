using System.Collections.Generic;
using UnityEngine;

public sealed class GridModel
{
    private GridMatcher gridMatcher;

    private List<GridCellController> currentSelectedCells;

    public IReadOnlyList<GridCellController> CurrentSelectedCells => currentSelectedCells;

    public void SetCells(GridCellController[,] gridCellControllers)
    {
        foreach (var gridCell in gridCellControllers)
        {
            if (!gridCell.IsActive)
            {
                gridCell.Deactivate();
            }
        }

        gridMatcher = new(gridCellControllers);
    }

    public List<GridCellController> FindNearestItemCells(ItemController item)
    {
        return gridMatcher.FindNearestCells(item);
    }

    public void ClearSelectedCells()
    {
        currentSelectedCells?.Clear();
    }

    public void SetSelectedCells(List<GridCellController> gridCells)
    {
        currentSelectedCells = gridCells;
    }

    public void SetItemToGrid(ItemController item)
    {
        var centerPoint = gridMatcher.GetCenterPoint(currentSelectedCells);

        item.SetToGrid(centerPoint, currentSelectedCells.ToArray());
    }
}