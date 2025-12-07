using UnityEngine;

[DefaultExecutionOrder(-1)]
public sealed class Bootstrap : MonoBehaviour
{
    [SerializeField]
    private ItemsContainerController itemsContainer;

    [SerializeField]
    private GridController gridController;

    [SerializeField]
    private ItemController itemPrefab;

    [SerializeField]
    private GridCellController cellController;

    [SerializeField]
    private GridConfig gridConfig;

    private GameLoop gameLoop;

    private void Awake()
    {
        gameLoop = new(gridConfig, itemsContainer, gridController, cellController, itemPrefab);
        gameLoop.Initialize();
    }
}