using System;
using UnityEngine;

public class GridModel : IDisposable
{
    private int cellsCount = 16;

    private GridCellController[] gridCellControllers;

    private GridCellController gridCellPrefab;
    private RectTransform gridRectTransform;

    private bool disposed;

    public GridModel(GridCellController gridCellPrefab, RectTransform gridRectTransform)
    {
        this.gridCellPrefab = gridCellPrefab;
        this.gridRectTransform = gridRectTransform;
    }

    public void CreateCells()
    {
        gridCellControllers = new GridCellController[cellsCount];

        for (int i = 0; i < cellsCount; i++)
        {
            var cell = GameObject.Instantiate(gridCellPrefab, gridRectTransform);
            cell.Initialize();
            cell.PointerEnter += OnCellEntered;
            cell.PointerExit += OnCellExited;

            gridCellControllers[i] = cell;
        }
    }

    public void Dispose()
    {
        if (disposed)
        {
            return;
        }

        foreach (var gridCell in gridCellControllers)
        {
            gridCell.PointerEnter -= OnCellEntered;
            gridCell.PointerExit -= OnCellExited;
        }

        disposed = true;
    }

    private void OnCellEntered(GridCellController gridCell)
    {

    }

    private void OnCellExited(GridCellController gridCell)
    {

    }
}