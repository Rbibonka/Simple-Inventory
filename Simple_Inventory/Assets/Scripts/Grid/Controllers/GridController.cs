using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private RectTransform gridRectTransform;

    private GridCellController gridCellPrefab;

    private GridModel gridModel;

    private int cellsCount = 16;

    public void Initialize(GridCellController gridCellPrefab)
    {
        this.gridCellPrefab = gridCellPrefab;
        gridModel = new(gridRectTransform);

        CreateCells();
    }

    public bool TrySetItem(ItemController itemController)
    {
        return false;
    }

    public void CreateCells()
    {
        GridCellController[] gridCellControllers = new GridCellController[cellsCount];

        for (int i = 0; i < cellsCount; i++)
        {
            var cell = GameObject.Instantiate(gridCellPrefab, gridRectTransform);
            gridCellControllers[i] = cell;
        }

        gridModel.SetCells(gridCellControllers);
    }
}