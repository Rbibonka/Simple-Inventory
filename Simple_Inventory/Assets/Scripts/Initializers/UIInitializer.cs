public class UIInitializer
{
    private ItemsContainerController itemsContainer;
    private ItemController itemPrefab;

    public UIInitializer(ItemsContainerController itemsContainer, ItemController itemPrefab)
    {
        this.itemsContainer = itemsContainer;
        this.itemPrefab = itemPrefab;
    }

    public void Initialize()
    {
        itemsContainer.Initiailze(itemPrefab);
    }
}