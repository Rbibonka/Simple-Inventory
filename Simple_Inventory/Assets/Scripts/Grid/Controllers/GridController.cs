using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private RectTransform gridRectTransform;

    private GridCellController gridCellPrefab;

    private GridCellController[] gridCellControllers;

    private int cellsCount = 16;

    public void Initialize(GridCellController gridCellPrefab)
    {
        this.gridCellPrefab = gridCellPrefab;

        CreateCells();
    }

    public void CreateCells()
    {
        gridCellControllers = new GridCellController[cellsCount];

        for (int i = 0; i < cellsCount; i++)
        {
            var cell = Instantiate(gridCellPrefab, gridRectTransform);
            cell.Initialize();

            gridCellControllers[i] = cell;
        }
    }
}