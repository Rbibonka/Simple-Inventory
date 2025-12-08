using UnityEngine;
using UnityEngine.UI;

public sealed class GridCellController : MonoBehaviour
{
    public RectTransform RectTransform => rectTransform;

    public bool IsActive => cellModel.IsActive;

    public bool IsOccupy => cellModel.IsOccupy;

    public Vector2 MatrixGridPosition => matrixGridPosition;

    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private Image img_GridCell;

    [SerializeField]
    private GridCellConfig gridCellConfig;

    private GridCellView cellView;
    private GridCellModel cellModel;

    [SerializeField]
    private Vector2 matrixGridPosition;

    public void Initialize(bool isActive, Vector2 matrixGridPosition)
    {
        this.matrixGridPosition = matrixGridPosition;

        cellView = new(img_GridCell, gridCellConfig);
        cellModel = new(isActive);
    }

    public void Occupy()
    {
        cellModel.OccupyCell();
    }

    public void Free()
    {
        cellModel.FreeCell();
    }

    public void Deactivate()
    {
        cellView.Deactivate();
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