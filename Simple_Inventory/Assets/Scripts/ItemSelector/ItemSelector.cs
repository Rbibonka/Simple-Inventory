public class ItemSelector
{
    private ItemsContainerController itemsContainer;
    private GridController gridController;

    public ItemSelector(ItemsContainerController itemsContainer, GridController gridController)
    {
        this.itemsContainer = itemsContainer;
        this.gridController = gridController;

        this.itemsContainer.ItemDragged += OnItemDragged;
        this.itemsContainer.ItemDeselected += OnItemDereleased;
    }

    private void OnItemDereleased(ItemSocketController socket)
    {
        if (gridController.TrySetItem(socket.CurrentItem.CellsCount))
        {
            gridController.SetItemToGrid(socket.CurrentItem);
        }
        else
        {
            gridController.DeselectGridCells();
            socket.MoveItemToSocket();
        }
    }

    private void OnItemDragged(ItemSocketController socket)
    {
        gridController.DeselectGridCells();
        gridController.ClearSelectedCells();
        gridController.HighlightCells(socket.CurrentItem);
    }
}