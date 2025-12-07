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

    private GameLoop uiInitializer;

    private void Awake()
    {
        uiInitializer = new(itemsContainer, gridController, cellController, itemPrefab);
        uiInitializer.Initialize();
    }
}