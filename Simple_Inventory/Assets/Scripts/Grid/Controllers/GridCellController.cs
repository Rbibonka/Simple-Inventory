using UnityEngine;
using UnityEngine.UI;

public sealed class GridCellController : MonoBehaviour
{
    public RectTransform RectTransform => rectTransform;

    public bool IsActive => cellModel.IsActive;

    public Vector2 MatrixGridPosition => matrixGridPosition;

    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private Image img_GridCell;

    [SerializeField]
    private GridCellConfig gridCellConfig;

    private GridCellView cellView;
    private GridCellModel cellModel;

    private Vector2 matrixGridPosition;

    public void Initialize(bool isActive, Vector2 matrixGridPosition)
    {
        this.matrixGridPosition = matrixGridPosition;

        cellView = new(img_GridCell, gridCellConfig);
        cellModel = new(isActive);
    }

    public void Deactivate()
    {
        cellView.Deactivate();
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