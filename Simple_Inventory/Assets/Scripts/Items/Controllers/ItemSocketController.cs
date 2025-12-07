using System;
using UnityEngine;

public sealed class ItemSocketController : MonoBehaviour
{
    public ItemController CurrentItem => currentItem;

    public event Action<ItemSocketController> ItemDragged;
    public event Action<ItemSocketController> ItemDereleased;

    [SerializeField]
    private RectTransform rectTransform;

    private ItemController currentItem;

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

    public ItemController UnsetCurrentItem()
    {
        if (currentItem == null)
        {
            throw new ArgumentNullException(nameof(currentItem), $"{nameof(currentItem)} cannot be null.");
        }

        var tempCurrentItem = currentItem;
        currentItem = null;

        currentItem.ItemDragged -= OnItemDragged;
        currentItem.ItemPointerUp -= OnItemDeselected;

        return tempCurrentItem;
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
}