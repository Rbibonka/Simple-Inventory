using System.Collections.Generic;

public class GridModel
{
    private GridMatcher gridMatcher;

    private List<GridCellController> currentSelectedCells;

    public List<GridCellController> CurrentSelectedCells => currentSelectedCells;

    public void SetCells(GridCellController[] gridCellControllers)
    {
        foreach (var gridCell in gridCellControllers)
        {
            gridCell.Initialize();
        }

        gridMatcher = new(gridCellControllers);
    }

    public List<GridCellController> FindNearestICells(ItemController item)
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
        var centerPoint = gridMatcher.GetCenterPoint(currentSelectedCells.ToArray());

        item.RectTransform.position = centerPoint;
    }
}