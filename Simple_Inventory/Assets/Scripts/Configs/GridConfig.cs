using System;
using UnityEngine;

[Serializable]
public struct BoolRow
{
    public bool[] row;
}

[CreateAssetMenu(fileName = "NewGridConfig", menuName = "Grid/Grid Data")]
public sealed class GridConfig : ScriptableObject
{
    public int Rows = 3;
    public int Columns = 3;

    public BoolRow[] Grid;
}