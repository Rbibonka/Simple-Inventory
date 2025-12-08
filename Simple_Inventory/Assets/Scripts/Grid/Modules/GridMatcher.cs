using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class GridMatcher
{
    private GridCellController[,] gridCellControllers;

    public GridMatcher(GridCellController[,] gridCellControllers)
    {
        this.gridCellControllers = gridCellControllers;
    }

    public List<GridCellController> FindNearestCells(ItemController item)
    {
        List<GridCellController> hoveredCells = new();
        
        hoveredCells = FindCells(item.RectTransform);

        if (hoveredCells.Count < 1)
        {
            return hoveredCells;
        }

        return FindNearestCells(hoveredCells, item.ItemsCells, item.RectTransform);
    }

    private List<GridCellController> FindNearestCells(List<GridCellController> hoveredCells, IReadOnlyList<ItemCellController> itemCells, RectTransform itemRectTransform)
    {
        List<List<GridCellController>> availablePaths = new();
        List<GridCellController> firstNearCells = new();

        foreach (var cell in hoveredCells)
        {
            if (RectTransformUtils.IsRectTransformTouching(itemCells[0].RectTransform, cell.RectTransform))
            {
                firstNearCells.Add(cell);
            }
        }

        foreach (var cell in firstNearCells)
        {
            List<GridCellController> availablePath = new();

            int x = (int)cell.MatrixGridPosition.x;
            int y = (int)cell.MatrixGridPosition.y;

            for (var i = 0; i < itemCells.Count; i++)
            {
                int gridX = x + (int)itemCells[i].CellPosition.x;
                int gridY = y + (int)itemCells[i].CellPosition.y;

                if (gridCellControllers.GetLength(0) <= gridX || gridCellControllers.GetLength(1) <= gridY
                    || gridCellControllers[gridX, gridY].IsOccupy)
                {
                    continue;
                }

                availablePath.Add(gridCellControllers[gridX, gridY]);
            }

            if (availablePath.Count > 0)
            {
                availablePaths.Add(availablePath);
            }
        }

        if (firstNearCells.Count < 1)
        {
            return null;
        }

        return FindNearestPath(availablePaths, itemRectTransform);
    }

    private List<GridCellController> FindNearestPath(List<List<GridCellController>> allPaths, RectTransform itemRectTransform)
    {
        Dictionary<List<GridCellController>, float> paths = new();

        foreach (var path in allPaths)
        {
            var centerPoint = GetCenterPoint(path);

            paths.Add(path, Vector3.Distance(centerPoint, itemRectTransform.position));
        }

        return paths.OrderBy(pair => pair.Value).First().Key;
    }

    private List<GridCellController> FindCells(RectTransform rectTransform)
    {
        List<GridCellController> hoveredCells = new();

        foreach (var cell in gridCellControllers)
        {
            if (RectTransformUtils.IsRectTransformTouching(rectTransform, cell.RectTransform)
                && cell.IsActive
                && !cell.IsOccupy)
            {
                hoveredCells.Add(cell);
            }
        }

        return hoveredCells;
    }

    public Vector3 GetCenterPoint(IReadOnlyList<GridCellController> gridCellControllers)
    {
        Vector3 cumulativePosition = Vector3.zero;

        foreach (var gridCell in gridCellControllers)
        {
            cumulativePosition += gridCell.RectTransform.position;
        }

        Vector3 center = cumulativePosition / gridCellControllers.Count;
        return center;
    }

    private void CollectionCells(List<GridCellController> hoveredCells, ItemCellController itemCellController, int counter)
    {
        foreach (var cell in gridCellControllers)
        {
            if (hoveredCells.Contains(cell)
                || !RectTransformUtils.IsRectTransformTouching(itemCellController.RectTransform, cell.RectTransform)
                || !cell.IsActive)
            {
                continue;
            }

            if (hoveredCells.Count > 0)
            {

            }

            if (hoveredCells.Count < counter)
            {
                hoveredCells.Add(cell);
            }

            var currentCellDistance = Vector3.Distance(hoveredCells[counter - 1].RectTransform.position, itemCellController.RectTransform.position);
            var newCellDistance = Vector3.Distance(cell.RectTransform.position, itemCellController.RectTransform.position);

            if (currentCellDistance > newCellDistance)
            {
                hoveredCells[counter - 1] = cell;
            }
        }
    }
}