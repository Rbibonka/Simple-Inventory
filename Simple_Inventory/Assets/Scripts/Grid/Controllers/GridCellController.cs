using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct GridCellConfig
{
    public Color DefaultColor;

    public Color SelectedColor;
}

public class GridCellController : MonoBehaviour, IDisposable
{
    [SerializeField]
    private Image img_GridCell;

    [SerializeField]
    private GridCellEventsObserver gridCellEventsObserver;

    [SerializeField]
    private GridCellConfig gridCellConfig;

    private GridCellView cellView;
    private GridCellModel cellModel;

    private bool disposed;

    public void Initialize()
    {
        cellView = new(img_GridCell, gridCellConfig);

        gridCellEventsObserver.PointerEnter += OnPointerEnter;
        gridCellEventsObserver.PointerExit += OnPointerExit;
    }

    private void OnPointerExit()
    {
        cellView.UnselectCell();
    }

    private void OnPointerEnter()
    {
        cellView.SelectCell();
    }

    public void Dispose()
    {
        if (disposed)
        {
            return;
        }

        gridCellEventsObserver.PointerEnter -= OnPointerEnter;
        gridCellEventsObserver.PointerExit -= OnPointerExit;

        disposed = true;
    }
}