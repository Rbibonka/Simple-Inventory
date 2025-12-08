using Cysharp.Threading.Tasks;
using System.Threading;

public sealed class GameLoop
{
    private ItemsContainerController itemsContainer;
    private GridController gridController;

    private ItemController itemPrefab;
    private GridCellController gridCellPrefab;

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
        ItemController itemPrefab)
    {
        this.gridConfig = gridConfig;
        this.itemsContainer = itemsContainer;
        this.gridController = gridController;
        this.menuController = menuController;
        this.gameUIController = gameUIController;
        this.gridCellPrefab = gridCellPrefab;
        this.itemPrefab = itemPrefab;
    }

    public async UniTask InitializeAsync(CancellationToken ct)
    {
        itemsContainer.Initiailze(itemPrefab);
        gridController.Initialize(gridCellPrefab, gridConfig);
        menuController.Initialize();

        menuController.StartButtonClicked += OnStartButtonClicked;

        await menuController.ShowAsync(ct);
        await UniTask.WaitUntil(() => isGameStarted);
        await menuController.HideAsync(ct);

        gameUIController.Show();

        await UniTask.WaitForSeconds(0.2f);
        await menuController.ShowAsync(ct);

        gameUIController.EnableUI();

        itemSelector = new(itemsContainer, gridController);
    }

    private void OnStartButtonClicked()
    {
        isGameStarted = true;
    }
}