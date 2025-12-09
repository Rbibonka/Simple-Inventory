using System;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Simple,
    Wooden
}

[Serializable]
public struct ItemLevels
{
    public ItemType itemType;

    public List<Sprite> sprites;

    public ItemController item;
}

[CreateAssetMenu(fileName = "NewLevelsItemConfig", menuName = "Items/ItemLevels")]
public sealed class ItemLevelsConfig : ScriptableObject
{
    [field: SerializeField]
    public List<ItemLevels> ItemLevels { get; private set; }
}