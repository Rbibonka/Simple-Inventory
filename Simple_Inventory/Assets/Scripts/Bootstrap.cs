using UnityEngine;

[DefaultExecutionOrder(-1)]
public class Bootstrap : MonoBehaviour
{
    [SerializeField]
    private ItemsContainerController itemsContainer;

    [SerializeField]
    private ItemController itemPrefab;

    private UIInitializer uiInitializer;

    private void Awake()
    {
        uiInitializer = new(itemsContainer, itemPrefab);
        uiInitializer.Initialize();
    }
}