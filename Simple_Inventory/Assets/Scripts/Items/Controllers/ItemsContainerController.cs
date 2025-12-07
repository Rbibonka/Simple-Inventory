using System;
using UnityEngine;

public class ItemsContainerController : MonoBehaviour, IDisposable
{
    [SerializeField]
    private ItemSocketController[] itemSockets;

    [SerializeField]
    private Canvas canvas;

    private ItemController itemPrefab;

    public event Action<ItemSocketController> ItemReleased;

    private bool isDisposed;

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
            item.Initialize(canvas, 2);

            itemSocket.SetItem(item);

            itemSocket.ItemReleased += OnItemReleased;
        }
    }

    private void OnItemReleased(ItemSocketController socket)
    {
        ItemReleased?.Invoke(socket);
    }

    public void Dispose()
    {
        if (isDisposed)
        {
            return;
        }

        foreach (var itemSocket in itemSockets)
        {
            itemSocket.ItemReleased -= OnItemReleased;
        }

        isDisposed = true;
    }
}