using System.Collections.Generic;
using UnityEngine;

public sealed class GridMatcher
{
    private IReadOnlyList<GridCellController> gridCellControllers;

    public GridMatcher(IReadOnlyList<GridCellController> gridCellControllers)
    {
        this.gridCellControllers = gridCellControllers;
    }

    public List<GridCellController> FindNearestCells(ItemController item)
    {
        List<GridCellController> hoveredCells = new();
        int counter = 1;

        foreach (var rectTransform in item.RectTransforms)
        {
            foreach (var cell in gridCellControllers)
            {
                if (hoveredCells.Contains(cell)
                    || !RectTransformUtils.IsRectTransformTouching(rectTransform, cell.RectTransform))
                {
                    continue;
                }

                if (hoveredCells.Count < counter)
                {
                    hoveredCells.Add(cell);
                }

                var currentCellDistance = Vector3.Distance(hoveredCells[counter - 1].RectTransform.position, rectTransform.position);
                var newCellDistance = Vector3.Distance(cell.RectTransform.position, rectTransform.position);

                if (currentCellDistance > newCellDistance)
                {
                    hoveredCells[counter - 1] = cell;
                }
            }

            if (hoveredCells.Count == counter)
            {
                counter++;
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
}