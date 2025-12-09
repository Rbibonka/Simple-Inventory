using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class ItemLevelUpdater
{
    private ItemSocketController[] itemSockets;
    private ItemLevelsConfig itemLevelsConfig;

    public ItemLevelUpdater(ItemSocketController[] itemSockets, ItemLevelsConfig itemLevelsConfig)
    {
        this.itemSockets = itemSockets;
        this.itemLevelsConfig = itemLevelsConfig;
    }

    public ItemController FindItem(ItemController item)
    {
        Dictionary<ItemController, float> avaliableItems = new();

        foreach (var itemSocket in itemSockets)
        {
            if (itemSocket.CurrentItem == null
                || itemSocket.CurrentItem == item)
            {
                continue;
            }

            if (RectTransformUtils.IsRectTransformTouching(item.RectTransform, itemSocket.CurrentItem.RectTransform)
                && item.Level == itemSocket.CurrentItem.Level
                && item.ItemType == itemSocket.CurrentItem.ItemType)
            {
                var distance = Vector3.Distance(item.RectTransform.position, itemSocket.CurrentItem.RectTransform.position);

                avaliableItems.Add(itemSocket.CurrentItem, distance);
            }
        }

        if (avaliableItems.Count < 1)
        {
            return null;
        }

        return avaliableItems.OrderBy(pair => pair.Value).First().Key;
    }

    public void UpdateItem(ItemController item, ItemSocketController socket)
    {
        var index = itemLevelsConfig.ItemLevels.FindIndex(itemLevel => itemLevel.itemType == item.ItemType);
        var socketItem = socket.UnsetItem();

        item.UpdateLevel();
        item.UpdateImage(itemLevelsConfig.ItemLevels[index].sprites[item.Level]);

        GameObject.Destroy(socketItem.gameObject);
    }
}