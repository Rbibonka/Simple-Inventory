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
    private ItemLevelsConfig itemLevels;

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

    private CancellationTokenSource cts;

    private void Awake()
    {
        cts = new();

        gameLoop = new(gridConfig, itemsContainer, gridController, menuController, gameUIController, cellController, mainMenuLoaderController, itemLevels);
        gameLoop.InitializeAsync(cts.Token).Forget();
    }

    private void OnDestroy()
    {
        cts?.Cancel();
        cts?.Dispose();

        cts = null;

        gameLoop.Dispose();
    }
}