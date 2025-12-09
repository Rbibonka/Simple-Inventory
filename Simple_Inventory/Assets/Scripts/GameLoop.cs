using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public sealed class GameLoop
{
    private ItemsContainerController itemsContainer;
    private GridController gridController;

    private ItemLevelsConfig itemLevels;
    private GridCellController gridCellPrefab;
    private MainMenuLoaderController mainMenuLoaderController;

    private MainMenuController menuController;
    private GameUIController gameUIController;
    private ItemSelector itemSelector;
    private GridConfig gridConfig;

    private bool isGameStarted;

    private const float waitTime = 0.5f;

    public GameLoop(
        GridConfig gridConfig,
        ItemsContainerController itemsContainer,
        GridController gridController,
        MainMenuController menuController,
        GameUIController gameUIController,
        GridCellController gridCellPrefab,
        MainMenuLoaderController mainMenuLoaderController,
        ItemLevelsConfig itemLevels)
    {
        this.gridConfig = gridConfig;
        this.itemsContainer = itemsContainer;
        this.gridController = gridController;
        this.menuController = menuController;
        this.gameUIController = gameUIController;
        this.gridCellPrefab = gridCellPrefab;
        this.mainMenuLoaderController = mainMenuLoaderController;
        this.itemLevels = itemLevels;
    }

    public async UniTask InitializeAsync(CancellationToken ct)
    {
        gridController.Initialize(gridCellPrefab, gridConfig);
        menuController.Initialize();

        mainMenuLoaderController.Initialize();

        menuController.StartButtonClicked += OnStartButtonClicked;
        menuController.ExitButtonClicked += OnExitButtonClicked;

        await menuController.ShowAsync(ct);
        await UniTask.WaitUntil(() => isGameStarted);
        await mainMenuLoaderController.ShowAsync(ct);
        menuController.HideAsync();

        gameUIController.Show();
        gameUIController.EnableUI();

        itemsContainer.Initiailze(itemLevels);
        itemSelector = new(itemsContainer, gridController, itemLevels);

        await UniTask.WaitForSeconds(waitTime);
        await mainMenuLoaderController.HideAsync(ct);
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }

    private void OnStartButtonClicked()
    {
        isGameStarted = true;
    }
}