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
    public event Action<GridCellController> PointerEnter;
    public event Action<GridCellController> PointerExit;

    public RectTransform RectTransform => rectTransform;

    [SerializeField]
    private RectTransform rectTransform;

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

    public void SelectCell()
    {
        cellView.SelectCell();
    }

    public void UnselectCell()
    {
        cellView.UnselectCell();
    }

    private void OnPointerExit()
    {
        PointerExit?.Invoke(this);
    }

    private void OnPointerEnter()
    {
        PointerEnter?.Invoke(this);
    }
}