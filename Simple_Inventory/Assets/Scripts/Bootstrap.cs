using UnityEngine;

[DefaultExecutionOrder(-1)]
public class Bootstrap : MonoBehaviour
{
    [SerializeField]
    private ItemsContainerController itemsContainer;

    [SerializeField]
    private GridController gridController;

    [SerializeField]
    private ItemController itemPrefab;

    [SerializeField]
    private GridCellController cellController;

    private UIInitializer uiInitializer;

    private void Awake()
    {
        uiInitializer = new(itemsContainer, gridController, cellController, itemPrefab);
        uiInitializer.Initialize();
    }
}