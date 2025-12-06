public class ItemSelector
{
    private ItemsContainerController itemsContainer;
    private GridController gridController;

    public ItemSelector(ItemsContainerController itemsContainer, GridController gridController)
    {
        this.itemsContainer = itemsContainer;
        this.gridController = gridController;

        itemsContainer.ItemReleased += OnItemReleased;
    }

    private void OnItemReleased(ItemSocketController socket)
    {
        if (gridController.TrySetItem(socket.CurrentItem))
        {
            socket.UnsetCurrentItem();
        }

        socket.MoveItemToSocket();
    }
}