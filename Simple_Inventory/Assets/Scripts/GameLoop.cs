using Cysharp.Threading.Tasks;
using System.Threading;

public sealed class GameLoop
{
    private ItemsContainerController itemsContainer;
    private GridController gridController;

    private ItemController itemPrefab;
    private GridCellController gridCellPrefab;
    private MainMenuLoaderController mainMenuLoaderController;

    private MainMenuController menuController;
    private GameUIController gameUIController;
    private ItemSelector itemSelector;
    private GridConfig gridConfig;

    private bool isGameStarted;

    public GameLoop(
        GridConfig gridConfig,
        ItemsContainerController itemsContainer,
        GridController gridController,
        MainMenuController menuController,
        GameUIController gameUIController,
        GridCellController gridCellPrefab,
        MainMenuLoaderController mainMenuLoaderController,
        ItemController itemPrefab)
    {
        this.gridConfig = gridConfig;
        this.itemsContainer = itemsContainer;
        this.gridController = gridController;
        this.menuController = menuController;
        this.gameUIController = gameUIController;
        this.gridCellPrefab = gridCellPrefab;
        this.mainMenuLoaderController = mainMenuLoaderController;
        this.itemPrefab = itemPrefab;
    }

    public async UniTask InitializeAsync(CancellationToken ct)
    {
        gridController.Initialize(gridCellPrefab, gridConfig);
        menuController.Initialize(mainMenuLoaderController);

        menuController.StartButtonClicked += OnStartButtonClicked;

        await menuController.ShowAsync(ct);
        await UniTask.WaitUntil(() => isGameStarted);
        await menuController.HideAsync(ct);

        gameUIController.Show();
        gameUIController.EnableUI();

        itemsContainer.Initiailze(itemPrefab);
        itemSelector = new(itemsContainer, gridController);

        await UniTask.WaitForSeconds(0.5f);
        await mainMenuLoaderController.HideAsync(ct);
        
    }

    private void OnStartButtonClicked()
    {
        isGameStarted = true;
    }
}