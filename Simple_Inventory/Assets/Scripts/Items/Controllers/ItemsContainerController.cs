using UnityEngine;

public class ItemsContainerController : MonoBehaviour
{
    [SerializeField]
    private ItemSocketController[] itemSockets;

    [SerializeField]
    private Canvas canvas;

    private ItemController itemPrefab;

    public void Initiailze(ItemController itemPrefab)
    {
        this.itemPrefab = itemPrefab;

        CreateItems();
    }

    public void CreateItems()
    {
        foreach (var itemSocket in itemSockets)
        {
            var item = GameObject.Instantiate(itemPrefab, canvas.transform);
            item.Initialize(canvas);

            itemSocket.SetItem(item);
        }
    }
}