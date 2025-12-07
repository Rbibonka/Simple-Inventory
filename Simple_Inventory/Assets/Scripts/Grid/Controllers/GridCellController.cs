using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

[Serializable]
public struct GridCellConfig
{
    public Color DefaultColor;

    public Color SelectedColor;

    public Color HoveredColor;
}

public class GridCellController : MonoBehaviour
{
    public RectTransform RectTransform => rectTransform;

    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private Image img_GridCell;

    [SerializeField]
    private GridCellConfig gridCellConfig;

    private GridCellView cellView;
    private GridCellModel cellModel;

    public void Initialize()
    {
        cellView = new(img_GridCell, gridCellConfig);
        cellModel = new();
    }

    public void HoverCell()
    {
        cellView.HoverCell();
    }

    public void SelectCell()
    {
        cellView.SelectCell();
    }

    public void DeselectCell()
    {
        cellView.DefaultCell();
    }
}