using System;

public sealed class ItemSelector : IDisposable
{
    private ItemsContainerController itemsContainer;
    private GridController gridController;
    private ItemLevelUpdater itemLevelUpdater;

    private bool isDisposed;

    public ItemSelector(ItemsContainerController itemsContainer, GridController gridController, ItemLevelsConfig itemLevelsConfig)
    {
        this.itemsContainer = itemsContainer;
        this.gridController = gridController;

        itemLevelUpdater = new(itemsContainer.ItemSockets, itemLevelsConfig);

        this.itemsContainer.ItemDragged += OnItemDragged;
        this.itemsContainer.ItemDeselected += OnItemDereleased;
    }

    public void Dispose()
    {
        if (isDisposed)
        {
            return;
        }

        itemsContainer.ItemDragged += OnItemDragged;
        itemsContainer.ItemDeselected += OnItemDereleased;

        isDisposed = true;
    }

    private void OnItemDereleased(ItemSocketController socket)
    {
        var item = itemLevelUpdater.FindItem(socket.CurrentItem);

        if (item != null)
        {
            itemLevelUpdater.UpdateItem(item, socket);

            return;
        }

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