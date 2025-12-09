using UnityEngine;

public sealed class ItemCellController : MonoBehaviour
{
    public RectTransform RectTransform => rectTransform;

    public Vector2 CellPosition => cellPosition;

    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private Vector2 cellPosition;
}