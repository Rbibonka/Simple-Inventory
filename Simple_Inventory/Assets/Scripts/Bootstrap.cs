using Cysharp.Threading.Tasks;
using System.Threading;
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

    [SerializeField]
    private MainMenuController menuController;

    [SerializeField]
    private MainMenuLoaderController mainMenuLoaderController;

    [SerializeField]

    private GameUIController gameUIController;

    private GameLoop gameLoop;

    private void Awake()
    {
        CancellationTokenSource cts = new();

        gameLoop = new(gridConfig, itemsContainer, gridController, menuController, gameUIController, cellController, mainMenuLoaderController, itemPrefab);
        gameLoop.InitializeAsync(cts.Token).Forget();
    }
}