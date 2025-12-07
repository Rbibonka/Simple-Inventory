using System;
using UnityEngine;

[Serializable]
public struct GridCellConfig
{
    [field: SerializeField]
    public Color DefaultColor { get; private set; }

    [field: SerializeField]
    public Color SelectedColor { get; private set; }

    [field: SerializeField]
    public Color HoveredColor { get; private set; }
}