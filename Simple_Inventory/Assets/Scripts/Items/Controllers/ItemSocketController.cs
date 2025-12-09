using System;
using UnityEngine;

public sealed class ItemSocketController : MonoBehaviour, IDisposable
{
    public ItemController CurrentItem => currentItem;

    public event Action<ItemSocketController> ItemDragged;
    public event Action<ItemSocketController> ItemDereleased;

    [SerializeField]
    private RectTransform rectTransform;

    private ItemController currentItem;

    private bool isDisposed;

    public void SetItem(ItemController item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), $"{nameof(item)} cannot be null.");
        }

        currentItem = item;
        currentItem.ItemDragged += OnItemDragged;
        currentItem.ItemPointerUp += OnItemDeselected;
        currentItem.SetToSocket(rectTransform);
    }

    public ItemController UnsetItem()
    {
        if (currentItem == null)
        {
            throw new ArgumentNullException(nameof(currentItem), $"{nameof(currentItem)} cannot be null.");
        }

        var tempItem = currentItem;
        currentItem = null;

        return tempItem;
    }

    public void MoveItemToSocket()
    {
        if (currentItem == null)
        {
            throw new ArgumentNullException(nameof(currentItem), $"{nameof(currentItem)} cannot be null.");
        }

        currentItem.MoveToDefault();
    }

    private void OnItemDeselected()
    {
        ItemDereleased?.Invoke(this);
    }

    private void OnItemDragged()
    {
        ItemDragged?.Invoke(this);
    }

    public void Dispose()
    {
        if (isDisposed)
        {
            return;
        }

        if (currentItem != null)
        {
            currentItem.ItemDragged -= OnItemDragged;
            currentItem.ItemPointerUp -= OnItemDeselected;
        }

        isDisposed = true;
    }
}