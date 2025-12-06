using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private RectTransform gridRectTransform;

    private GridModel gridModel;

    public void Initialize(GridCellController gridCellPrefab)
    {
        gridModel = new(gridCellPrefab, gridRectTransform);

        CreateCells();
    }

    public void CreateCells()
    {
        gridModel.CreateCells();
    }
}