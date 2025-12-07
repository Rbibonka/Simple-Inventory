public sealed class GameLoop
{
    private ItemsContainerController itemsContainer;
    private GridController gridController;

    private ItemController itemPrefab;
    private GridCellController gridCellPrefab;

    private ItemSelector itemSelector;

    public GameLoop(
        ItemsContainerController itemsContainer,
        GridController gridController,
        GridCellController gridCellPrefab,
        ItemController itemPrefab)
    {
        this.itemsContainer = itemsContainer;
        this.gridController = gridController;
        this.gridCellPrefab = gridCellPrefab;
        this.itemPrefab = itemPrefab;
    }

    public void Initialize()
    {
        itemsContainer.Initiailze(itemPrefab);
        gridController.Initialize(gridCellPrefab);

        itemSelector = new(itemsContainer, gridController);
    }
}