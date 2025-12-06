using System;
using UnityEngine;

public class ItemSocketController : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;

    private ItemController currentItem;

    public ItemController CurrentItem => currentItem;

    public event Action<ItemSocketController> ItemReleased;

    public void SetItem(ItemController item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), $"{nameof(item)} cannot be null.");
        }

        currentItem = item;
        currentItem.ItemSelected += OnItemSelected;
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

    private void OnItemSelected()
    {
        ItemReleased?.Invoke(this);
    }
}