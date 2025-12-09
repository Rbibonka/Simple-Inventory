using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class ItemsContainerController : MonoBehaviour, IDisposable
{
    public event Action<ItemSocketController> ItemDragged;
    public event Action<ItemSocketController> ItemDeselected;

    public ItemSocketController[] ItemSockets => itemSockets;

    [SerializeField]
    private ItemSocketController[] itemSockets;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private List<ItemController> itemControllers;

    private ItemLevelsConfig itemLevels;

    private bool isDisposed;

    public void Initiailze(ItemLevelsConfig itemLevels)
    {
        this.itemLevels = itemLevels;

        CreateItems();
    }

    public void CreateItems()
    {
        foreach (var itemSocket in itemSockets)
        {
            var itemId = UnityEngine.Random.Range(0, itemLevels.ItemLevels.Count);

            var item = GameObject.Instantiate(itemLevels.ItemLevels[itemId].item, canvas.transform);
            item.Initialize(canvas, itemLevels.ItemLevels[itemId].itemType);
            item.UpdateImage(itemLevels.ItemLevels[itemId].sprites[item.Level]);

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
            itemSocket.Dispose();

            itemSocket.ItemDragged -= OnItemDragged;
            itemSocket.ItemDereleased -= OnItemDereleased;
        }

        isDisposed = true;
    }
}