using UnityEngine;

public class ItemCellController : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;

    public RectTransform RectTransform => rectTransform;

    [SerializeField]
    private Vector2 cellPosition;

    public Vector2 CellPosition => cellPosition;
}