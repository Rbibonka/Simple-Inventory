using System.Collections.Generic;
using System.Linq;
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
        gridModel = new(gridRectTransform);

        CreateCells();
    }

    public void TryHoverCells(ItemController item)
    {
        List<GridCellController> data = new();

        var occupyCells = new GridCellController[item.CellsCount];
        int counter = 0;

        foreach (var cell in gridCellControllers)
        {
            cell.UnselectCell();

            if (RectTransformUtils.IsRectTransformTouching(item.RectTransform, cell.RectTransform))
            {
                data.Add(cell);
            }
            else
            {
                data.Remove(cell);
            }
        }

        foreach (var rectTransform in item.RectTransforms)
        {
            foreach (var cell in data)
            {
                if (occupyCells[counter] == null)
                {
                    occupyCells[counter] = cell;
                }

                var currentCellDistance = Vector3.Distance(occupyCells[counter].RectTransform.position, rectTransform.position);
                var newCellDistance = Vector3.Distance(cell.RectTransform.position, rectTransform.position);

                if (currentCellDistance > newCellDistance)
                {
                    occupyCells[counter] = cell;
                }
            }

            counter++;
        }

        foreach (var occupyCell in occupyCells)
        {
            if (occupyCell != null)
            {
                occupyCell.SelectCell();
            }
        }
    }

    public void CreateCells()
    {
        gridCellControllers = new GridCellController[cellsCount];

        for (int i = 0; i < cellsCount; i++)
        {
            var cell = GameObject.Instantiate(gridCellPrefab, gridRectTransform);

            gridCellControllers[i] = cell;
            gridCellControllers[i].PointerEnter += OnPointerEnter;
            gridCellControllers[i].PointerExit += OnPointerExit;
        }

        gridModel.SetCells(gridCellControllers);
    }

    private void OnPointerExit(GridCellController gridCell)
    {
        //gridCell.UnselectCell();
    }

    private void OnPointerEnter(GridCellController gridCell)
    {
        //gridCell.SelectCell();
    }
}