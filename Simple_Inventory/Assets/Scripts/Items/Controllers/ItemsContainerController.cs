using System;
using UnityEngine;

public class ItemsContainerController : MonoBehaviour, IDisposable
{
    [SerializeField]
    private ItemSocketController[] itemSockets;

    [SerializeField]
    private Canvas canvas;

    private ItemController itemPrefab;

    public event Action<ItemSocketController> ItemDragged;
    public event Action<ItemSocketController> ItemDeselected;

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

            itemSocket.ItemDragged += OnItemDragged;
            itemSocket.ItemDereleased += OnItemDereleased;
        }
    }

    private void OnItemDereleased(ItemSocketController socket)
    {
        ItemDeselected?.Invoke(socket);
    }

    private void OnItemDragged(ItemSocketController socket)
    {
        ItemDragged?.Invoke(socket);
    }

    public void Dispose()
    {
        if (isDisposed)
        {
            return;
        }

        foreach (var itemSocket in itemSockets)
        {
            itemSocket.ItemDragged -= OnItemDragged;
        }

        isDisposed = true;
    }
}