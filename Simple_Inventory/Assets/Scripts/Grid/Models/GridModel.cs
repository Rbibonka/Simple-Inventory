using System;
using UnityEngine;

public class GridModel : IDisposable
{
    private GridCellController[] gridCellControllers;

    private RectTransform gridRectTransform;

    private GridMatcher gridMatcher;

    private bool isDisposed;

    public GridModel(RectTransform gridRectTransform)
    {
        this.gridRectTransform = gridRectTransform;
        gridMatcher = new();
    }

    public void SetCells(GridCellController[] gridCellControllers)
    {
        this.gridCellControllers = gridCellControllers;

        foreach (var gridCell in gridCellControllers)
        {
            gridCell.Initialize();

            gridCell.PointerEnter += OnCellEntered;
            gridCell.PointerExit += OnCellExited;
        }

        gridMatcher.SetGrid(this.gridCellControllers);
    }

    public void Dispose()
    {
        if (isDisposed)
        {
            return;
        }

        foreach (var gridCell in gridCellControllers)
        {
            gridCell.PointerEnter -= OnCellEntered;
            gridCell.PointerExit -= OnCellExited;
        }

        isDisposed = true;
    }

    private void OnCellEntered(GridCellController gridCell)
    {
        gridCell.SelectCell();
    }

    private void OnCellExited(GridCellController gridCell)
    {
        gridCell.UnselectCell();
    }
}